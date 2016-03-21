using GitCommands;
using GitUIPluginInterfaces;
using ResourceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TalentsoftTools
{
    public partial class TalentsoftToolsForm : GitExtensionsFormBase
    {
        #region Fields & Properties

        readonly GitUIBaseEventArgs _gitUiCommands;
        readonly ISettingsSource _settings;
        List<GitRef> RemoteBranches { get; set; }
        List<GitRef> LocalBranches { get; set; }

        #endregion


        public TalentsoftToolsForm(GitUIBaseEventArgs gitUiCommands, ISettingsSource settings)
        {
            IsProcessAborted = true;
            _settings = settings;
            _gitUiCommands = gitUiCommands;
            WorkingDirectory = _gitUiCommands.GitModule.WorkingDir;
            //Icon = _gitUiCommands.GitUICommands.FormIcon;
            LunchSplashScreen();
        }

        void LunchSplashScreen()
        {
            SplashScreen.ShowSplashScreen();
            Application.DoEvents();
            SplashScreen.SetStatus("Initialize component");
            InitializeComponent();
            Translate();
            SplashScreen.SetStatus("Fetching remote");
            //_gitUiCommands.GitModule.RunGitCmdResult("fetch -q -n --all");
            //_gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            Helper.FetchAll(_gitUiCommands);
            SplashScreen.SetStatus("Loading solutions files");
            LoadSolutionsFiles();
            SplashScreen.SetStatus("Loading settings values");
            LoadDefaultStepsValuesFromSettings();
            ResetControls();
            SplashScreen.SetStatus("Loading locals branches informations");
            LoadLocalBranches();
            UpdateNotifications();
            SplashScreen.CloseForm();
        }

        void TbcMainSelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbcMain.SelectedIndex == 1)
            {
                InitLocalBranchTab();
            }
        }

        void TalentsoftToolsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
                DialogResult response = MessageBox.Show("The process is running, are you sure to stop it ?", "Talentsoft tools", MessageBoxButtons.YesNo);
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
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
        }

        private void PbxBranchesMustUpdateClick(object sender, EventArgs e)
        {
            if (TbcMain.Enabled)
            {
                TbcMain.SelectedIndex = 1;
            }
        }

        private void PbxUnmergedBranchesClick(object sender, EventArgs e)
        {
            if (TbcMain.Enabled)
            {
                TbcMain.SelectedIndex = 1;
            }
        }

        private void DgvLocalsBranches_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var checkBoxCell = (DataGridViewCheckBoxCell)DgvLocalsBranches.Rows[DgvLocalsBranches.CurrentRow.Index].Cells[0];
                bool isChecked = checkBoxCell.Value.ToString() == "False";
                List<string> branchesMonitors = TalentsoftToolsPlugin.BranchesToMonitor[_settings].Split(';').ToList();
                string branchName = DgvLocalsBranches[1, e.RowIndex].Value.ToString();
                if (isChecked && branchesMonitors.All(x => x != DgvLocalsBranches[1, e.RowIndex].Value.ToString()))
                {
                    branchesMonitors.Add(branchName);
                }
                if (!isChecked && branchesMonitors.Any(x => x == branchName))
                {
                    branchesMonitors.Remove(branchName);
                }
                TalentsoftToolsPlugin.BranchesToMonitor[_settings] = string.Join(";", branchesMonitors);
            }
        }
    }
}