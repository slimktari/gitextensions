namespace TalentsoftTools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using GitCommands;
    using GitUIPluginInterfaces;
    using Helpers;
    using ResourceManager;

    public partial class TalentsoftToolsForm : GitExtensionsFormBase
    {
        #region Fields & Properties

        readonly ISettingsSource _settings;
        List<GitRef> RemoteBranches { get; set; }
        List<GitRef> LocalBranches { get; set; }

        #endregion

        public TalentsoftToolsForm(ISettingsSource settings)
        {
            IsProcessAborted = true;
            _settings = settings;
            WorkingDirectory = TalentsoftToolsPlugin.GitUiCommands.GitModule.WorkingDir;
            //Icon = _gitUiCommands.GitUICommands.FormIcon;
            LunchSplashScreen();
        }

        bool CheckIfCanRunProcess()
        {
            if (_workerThread != null && _workerThread.IsAlive)
            {
                MessageBox.Show("Unable to run process!\r\nAnother process is already running.", Generic.PluginName, MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        void LunchSplashScreen()
        {
            SplashScreen.ShowSplashScreen();
            Application.DoEvents();
            SplashScreen.SetStatus("Initialize component");
            InitializeComponent();
            Text = Generic.PluginName;
            PbxBranchesMustUpdate.BackColor = Generic.ColorBranchNeedUpdate;
            PbxBranchesObsoletesBranches.BackColor = Generic.ColorBranchObsolete;
            PbxLocalsBranchesObsoletes.BackColor = Generic.ColorBranchObsolete;
            PbxLocalsBranchesMustBeUpdate.BackColor = Generic.ColorBranchNeedUpdate;
            PbxLocalsBranchesUpToDate.BackColor = Generic.ColorBranchUpToDate;
            Translate();
            SplashScreen.SetStatus("Fetching remote");
            GitHelper.FetchAll();
            GitHelper.NotifyGitExtensions();
            SplashScreen.SetStatus("Loading solutions files");
            LoadSolutionsFiles();
            SplashScreen.SetStatus("Loading settings values");
            InitSettingsTab();
            LoadDefaultStepsValuesFromSettings();
            ResetControls();
            SplashScreen.SetStatus("Loading locals branches informations");
            LoadLocalBranches();
            InitLocalBranchTab();
            UpdateNotifications();
            SplashScreen.CloseForm();
        }

        public void LoadLocalBranches()
        {
            LocalBranches = GitHelper.GetLocalsBranches();
        }

        void TbcMainSelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbcMain.SelectedIndex == 1)
            {
                UpdateLocalBranchBackColor();
            }
            if (TbcMain.SelectedIndex == 1)
            {
                InitNotificationsTab();
            }
        }

        void TalentsoftToolsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_workerThread != null && _workerThread.IsAlive)
            {
                DialogResult response = MessageBox.Show("The process is running, are you sure to stop it ?", Generic.PluginName, MessageBoxButtons.YesNo);
                switch (response)
                {
                    case DialogResult.Yes:
                        if (_workerThread != null && _workerThread.IsAlive)
                        {
                            _workerThread.Abort();
                        }
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
            TalentsoftToolsPlugin.GitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
        }

        private void PbxBranchesMustUpdateClick(object sender, EventArgs e)
        {
            if (TbcMain.Enabled)
            {
                TbcMain.SelectedIndex = 1;
            }
        }

        private void PbxBranchesUpToDateClick(object sender, EventArgs e)
        {
            if (TbcMain.Enabled)
            {
                TbcMain.SelectedIndex = 2;
            }
        }

        void LoadDefaultStepsValuesFromSettings()
        {
            if (CblSolutions.Items.Count <= 0)
            {
                CbxIsExitVisualStudio.Enabled = false;
                CbxIsExitVisualStudio.Checked = false;
                CbxIsRunVisualStudio.Enabled = false;
                CbxIsRunVisualStudio.Checked = false;
                CbxIsBuildSolution.Checked = false;
                CbxIsBuildSolution.Enabled = false;
                CblDsbSolutions.Enabled = false;
                BtnDsbBuildSolution.Enabled = false;
                BtnDsbExitSolution.Enabled = false;
                BtnDsbNugetRestore.Enabled = false;
                BtnDsbRebuildSolution.Enabled = false;
                BtnDsbStartSolution.Enabled = false;
            }
            else if (TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings].HasValue)
            {
                CbxIsExitVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings].Value;
                CbxIsRunVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings].Value;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.DatabasesToRestore[_settings]) &&
                TalentsoftToolsPlugin.IsDefaultResetDatabases[_settings].HasValue)
            {
                CbxIsRestoreDatabases.Checked = TalentsoftToolsPlugin.IsDefaultResetDatabases[_settings].Value;
                TxbProcessDatabasesToRestore.Text = TalentsoftToolsPlugin.DatabasesToRestore[_settings];
                TxbDsbDatabasesToRestore.Text = TalentsoftToolsPlugin.DatabasesToRestore[_settings];
                CbxIsRestoreDatabases.Enabled = true;
                TxbProcessDatabasesToRestore.Enabled = true;
                TxbDsbDatabasesToRestore.Enabled = true;
                BtnDsbRestoreDatabases.Enabled = true;
            }
            else
            {
                CbxIsRestoreDatabases.Checked = false;
                CbxIsRestoreDatabases.Enabled = false;
                TxbProcessDatabasesToRestore.Enabled = false;
                TxbDsbDatabasesToRestore.Enabled = false;
                BtnDsbRestoreDatabases.Enabled = false;
            }

            bool canStash = GitHelper.IfChangedFiles();
            if (!canStash)
            {
                CbxIsStashChanges.Checked = false;
                CbxIsStashChanges.Enabled = false;
            }
            else if (TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].HasValue)
            {
                CbxIsStashChanges.Checked = TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].HasValue)
            {
                CbxIsCheckoutBranch.Checked = TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultGitClean[_settings].HasValue)
            {
                CbxIsGitClean.Checked = TalentsoftToolsPlugin.IsDefaultGitClean[_settings].Value;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]))
            {
                TxbDsbGitClean.Text = TalentsoftToolsPlugin.ExcludePatternGitClean[_settings];
            }
            CanStashPop = GitHelper.GetStashs().Any();
            if (!CanStashPop.Value && !CbxIsStashChanges.Checked)
            {
                CbxIsStashPop.Checked = false;
                CbxIsStashPop.Enabled = false;
            }
            else if (TalentsoftToolsPlugin.IsDefaultStashPop[_settings].HasValue)
            {
                CbxIsStashPop.Checked = TalentsoftToolsPlugin.IsDefaultStashPop[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultNugetRestore[_settings].HasValue)
            {
                CbxIsNugetRestore.Checked = TalentsoftToolsPlugin.IsDefaultNugetRestore[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].HasValue)
            {
                CbxIsBuildSolution.Checked = TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultRunUri[_settings].HasValue)
            {
                CbxLaunchUri.Checked = TalentsoftToolsPlugin.IsDefaultRunUri[_settings].Value;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
            {
                TxbUri.Text = TalentsoftToolsPlugin.LocalUriWebApplication[_settings];
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.PreBuildBatch[_settings]))
            {
                PreBuildFiles = new List<string>();
                string[] files = TalentsoftToolsPlugin.PreBuildBatch[_settings].Split(';');
                bool isError = false;
                foreach (var file in files)
                {
                    if (!string.IsNullOrWhiteSpace(file) && !File.Exists(file))
                    {
                        isError = true;
                    }
                    else
                    {
                        PreBuildFiles.Add(file);
                    }
                }
                if (!PreBuildFiles.Any() || isError)
                {
                    CbxIsPreBuild.Checked = false;
                    CbxIsPreBuild.Enabled = false;
                    BtnDsbRunScriptPrebuild.Enabled = false;
                }
                else
                {
                    CbxIsPreBuild.Enabled = true;
                    BtnDsbRunScriptPrebuild.Enabled = true;
                    if (TalentsoftToolsPlugin.IsDefaultPreBuildScripts[_settings].HasValue)
                    {
                        CbxIsPreBuild.Checked = TalentsoftToolsPlugin.IsDefaultPreBuildScripts[_settings].Value;
                    }
                }
            }
            else
            {
                CbxIsPreBuild.Checked = false;
                CbxIsPreBuild.Enabled = false;
                BtnDsbRunScriptPrebuild.Enabled = false;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.PostBuildBatch[_settings]))
            {
                PostBuildFiles = new List<string>();
                string[] files = TalentsoftToolsPlugin.PostBuildBatch[_settings].Split(';');
                bool isError = false;
                foreach (var file in files)
                {
                    if (!File.Exists(file))
                    {
                        isError = true;
                    }
                    else
                    {
                        PostBuildFiles.Add(file);
                    }
                }
                if (!PostBuildFiles.Any() || isError)
                {
                    CbxIsPostBuild.Checked = false;
                    CbxIsPostBuild.Enabled = false;
                    BtnDsbRunScriptPostbuild.Enabled = false;
                }
                else
                {
                    CbxIsPostBuild.Enabled = true;
                    BtnDsbRunScriptPostbuild.Enabled = true;
                    if (TalentsoftToolsPlugin.IsDefaultPostBuildProcess[_settings].HasValue)
                    {
                        CbxIsPostBuild.Checked = TalentsoftToolsPlugin.IsDefaultPostBuildProcess[_settings].Value;
                    }
                }
            }
            else
            {
                CbxIsPostBuild.Checked = false;
                CbxIsPostBuild.Enabled = false;
                BtnDsbRunScriptPostbuild.Enabled = false;
            }
        }
    }
}