using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using GitUIPluginInterfaces;

namespace TalentsoftTools
{
    public partial class MonitorActionsForm : Form
    {
        private ISettingsSource _settings;
        private IGitUICommands _gitCommands;
        private List<string> _remotesDiff;
        private string _currentItem;

        public MonitorActionsForm(ISettingsSource settings, IGitUICommands gitCommands, List<string> remotesDiff, string branchName)
        {
            InitializeComponent();
            _settings = settings;
            _gitCommands = gitCommands;
            _remotesDiff = remotesDiff;
            _currentItem = branchName;
            LblBranchName.Text = branchName;
            CblRemotesList.DataSource = _remotesDiff;

            CmdResult result = gitCommands.GitModule.RunGitCmdResult(string.Format("log -n 1 --pretty=format:\" % an : % cr\" {0}", branchName));
            if (result.ExitCode == 0 && !string.IsNullOrWhiteSpace(result.StdOutput) && result.StdOutput.Contains(";"))
            {
                LblInfos.Text = result.StdOutput;
            }
        }

        private void BtnCheckoutClick(object sender, EventArgs e)
        {
            if (CbxRemoveFromMonitor.Checked)
            {
                RemoveFromMonitor();
            }
            Application.OpenForms[0].BeginInvoke((ThreadStart)delegate
            {
                _gitCommands.StartCheckoutBranch();
            });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnRebaseClick(object sender, EventArgs e)
        {
            if (CbxRemoveFromMonitor.Checked)
            {
                RemoveFromMonitor();
            }
            string selectedRemote = CblRemotesList.SelectedItem.ToString();
            Application.OpenForms[0].BeginInvoke((ThreadStart)delegate
            {
                _gitCommands.StartRebaseDialog(selectedRemote);
            });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnMergeClick(object sender, EventArgs e)
        {
            if (CbxRemoveFromMonitor.Checked)
            {
                RemoveFromMonitor();
            }
            string selectedRemote = CblRemotesList.SelectedItem.ToString();
            Application.OpenForms[0].BeginInvoke((ThreadStart)delegate
            {
                _gitCommands.StartMergeBranchDialog(selectedRemote);
            });
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnRemoveFromMonitorClick(object sender, EventArgs e)
        {
            RemoveFromMonitor();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        void RemoveFromMonitor()
        {
            TalentsoftToolsPlugin.BranchesToMonitor[_settings] = string.Join(";", TalentsoftToolsPlugin.BranchesToMonitor[_settings].Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).Where(x => x != _currentItem).ToList());
            foreach (var form in Application.OpenForms)
            {
                var pluginForm = form as TalentsoftToolsForm;
                if (pluginForm != null)
                {
                    pluginForm.SetLocalBranchesGrid();
                }
            }
        }
    }
}
