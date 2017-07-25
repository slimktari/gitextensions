using System.Threading;

namespace MyDevTools
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

    public partial class MyDevToolsForm : GitExtensionsFormBase
    {
        #region Fields & Properties

        readonly ISettingsSource _settings;
        List<GitRef> RemoteBranches { get; set; }
        List<GitRef> LocalBranches { get; set; }
        public MyDevToolsPlugin _plugin;

        #endregion

        public MyDevToolsForm(ISettingsSource settings, MyDevToolsPlugin plugin)
        {
            IsProcessAborted = true;
            _settings = settings;
            _plugin = plugin;
            WorkingDirectory = MyDevToolsPlugin.GitUiCommands.GitModule.WorkingDir;
            //Icon = _gitUiCommands.GitUICommands.FormIcon;
            LunchSplashScreen();
        }

        bool CheckIfCanRunProcess(string message)
        {
            if (_workerThread != null && (_workerThread.ThreadState == ThreadState.Background || _workerThread.ThreadState == ThreadState.Running))
            {
                MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
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
            Text = $"{Generic.PluginName} - {GenericHelper.GetProjectVersion()}";
            PbxBranchesMustUpdate.BackColor = Generic.ColorBranchNeedUpdate;
            PbxBranchesObsoletesBranches.BackColor = Generic.ColorBranchObsolete;
            PbxLocalsBranchesObsoletes.BackColor = Generic.ColorBranchObsolete;
            PbxLocalsBranchesMustBeUpdate.BackColor = Generic.ColorBranchNeedUpdate;
            PbxLocalsBranchesUpToDate.BackColor = Generic.ColorBranchUpToDate;
            Translate();
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
            if (TbcMain.SelectedIndex == Convert.ToInt32(Generic.TabItems.LocalBranchesTab))
            {
                UpdateLocalBranchBackColor();
            }
            if (TbcMain.SelectedIndex == Convert.ToInt32(Generic.TabItems.NotificationsTab))
            {
                InitNotificationsTab();
                UpdateNotificationsBackColor();
            }
        }

        void MyDevToolsFormClosing(object sender, FormClosingEventArgs e)
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
            MyDevToolsPlugin.GitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
        }

        private void PbxBranchesMustUpdateClick(object sender, EventArgs e)
        {
            if (TbcMain.Enabled)
            {
                TbcMain.SelectedIndex = Convert.ToInt32(Generic.TabItems.LocalBranchesTab);
            }
        }

        private void PbxBranchesUpToDateClick(object sender, EventArgs e)
        {
            if (TbcMain.Enabled)
            {
                TbcMain.SelectedIndex = Convert.ToInt32(Generic.TabItems.LocalBranchesTab);
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
            else
            {
                CbxIsBuildSolution.Checked = MyDevToolsPlugin.IsDefaultBuildSolution.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
                CbxIsBuildFrontSolution.Checked = MyDevToolsPlugin.IsDefaultBuildFrontSolution.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
                CbxIsRunVisualStudio.Checked = MyDevToolsPlugin.IsDefaultStartVisualStudio.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
                CbxIsExitVisualStudio.Checked = MyDevToolsPlugin.IsDefaultExitVisualStudio.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            }
            if (!string.IsNullOrWhiteSpace(MyDevToolsPlugin.DatabasesToRestore.ValueOrDefault(MyDevToolsPlugin.PluginSettings)))
            {
                CbxIsRestoreDatabases.Checked = MyDevToolsPlugin.IsDefaultResetDatabases.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
                TxbProcessDatabasesToRestore.Text = MyDevToolsPlugin.DatabasesToRestore.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
                TxbDsbDatabasesToRestore.Text = MyDevToolsPlugin.DatabasesToRestore.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
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
            else
            {
                CbxIsStashChanges.Checked = MyDevToolsPlugin.IsDefaultStashChanges.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            }
            CbxIsCheckoutBranch.Checked = MyDevToolsPlugin.IsDefaultCheckoutBranch.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxIsGitClean.Checked = MyDevToolsPlugin.IsDefaultGitClean.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbDsbGitClean.Text = MyDevToolsPlugin.ExcludePatternGitClean.ValueOrDefault(MyDevToolsPlugin.PluginSettings);

            CanStashPop = GitHelper.GetStashs().Any();
            if (!CanStashPop.Value && !CbxIsStashChanges.Checked)
            {
                CbxIsStashPop.Checked = false;
                CbxIsStashPop.Enabled = false;
            }
            else
            {
                CbxIsStashPop.Checked = MyDevToolsPlugin.IsDefaultStashPop.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            }
            CbxIsNugetRestore.Checked = MyDevToolsPlugin.IsDefaultNugetRestore.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxLaunchUri.Checked = MyDevToolsPlugin.IsDefaultRunUri.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbUri.Text = MyDevToolsPlugin.LocalUriWebApplication.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            if (!string.IsNullOrWhiteSpace(MyDevToolsPlugin.PreBuildBatch.ValueOrDefault(MyDevToolsPlugin.PluginSettings)))
            {
                PreBuildFiles = new List<string>();
                string[] files = MyDevToolsPlugin.PreBuildBatch.ValueOrDefault(MyDevToolsPlugin.PluginSettings).Split(';');
                bool isError = false;
                foreach (var file in files)
                {
                    if (!string.IsNullOrWhiteSpace(file) && !File.Exists(file))
                    {
                        isError = true;
                    }
                    else
                    {
                        PreBuildFiles.Add("\"" + file + "\"");
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
                    CbxIsPreBuild.Checked = MyDevToolsPlugin.IsDefaultPreBuildScripts.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
                }
            }
            else
            {
                CbxIsPreBuild.Checked = false;
                CbxIsPreBuild.Enabled = false;
                BtnDsbRunScriptPrebuild.Enabled = false;
            }
            if (!string.IsNullOrWhiteSpace(MyDevToolsPlugin.PostBuildBatch.ValueOrDefault(MyDevToolsPlugin.PluginSettings)))
            {
                PostBuildFiles = new List<string>();
                string[] files = MyDevToolsPlugin.PostBuildBatch.ValueOrDefault(MyDevToolsPlugin.PluginSettings).Split(';');
                bool isError = false;
                foreach (var file in files)
                {
                    if (!File.Exists(file))
                    {
                        isError = true;
                    }
                    else
                    {
                        PostBuildFiles.Add("\"" + file + "\"");
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

                    CbxIsPostBuild.Checked = MyDevToolsPlugin.IsDefaultPostBuildProcess.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
                }
            }
            else
            {
                CbxIsPostBuild.Checked = false;
                CbxIsPostBuild.Enabled = false;
                BtnDsbRunScriptPostbuild.Enabled = false;
            }
        }

        /// <summary>
        /// Init all notifications controls.
        /// </summary>
        public void InitNotifications()
        {
            InitNotificationsTab();
            TxbSettingsNotificationsMonitorBranches.Text = MyDevToolsPlugin.BranchesToMonitor[MyDevToolsPlugin.PluginSettings];
        }
    }
}