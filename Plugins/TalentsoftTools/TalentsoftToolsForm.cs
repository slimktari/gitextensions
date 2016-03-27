using GitCommands;
using GitUIPluginInterfaces;
using ResourceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TalentsoftTools.Helpers;

namespace TalentsoftTools
{
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

        void LunchSplashScreen()
        {
            SplashScreen.ShowSplashScreen();
            Application.DoEvents();
            SplashScreen.SetStatus("Initialize component");
            InitializeComponent();
            Text = Generic.PluginName;
            PbxBranchesMustUpdate.BackColor = Generic.ColorBranchNeedUpdate;
            PbxBranchesUpToDate.BackColor = Generic.ColorBranchUpToDate;
            Translate();
            SplashScreen.SetStatus("Fetching remote");
            GitHelper.FetchAll();
            GitHelper.NotifyGitExtensions();
            SplashScreen.SetStatus("Loading solutions files");
            LoadSolutionsFiles();
            SplashScreen.SetStatus("Loading settings values");
            LoadDefaultStepsValuesFromSettings();
            ResetControls();
            SplashScreen.SetStatus("Loading locals branches informations");
            LoadLocalBranches();
            InitLocalBranchTab();
            InitNotificationsTab();
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
            //if (TbcMain.SelectedIndex == 2)
            //{
            //    UpdateMonitorBranchBackColor();
            //}
        }

        void TalentsoftToolsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
                DialogResult response = MessageBox.Show("The process is running, are you sure to stop it ?", Generic.PluginName, MessageBoxButtons.YesNo);
                switch (response)
                {
                    case DialogResult.Yes:
                        ExitProcess();
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
    }
}