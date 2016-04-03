namespace TalentsoftTools
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using GitCommands;
    using GitUIPluginInterfaces;

    public partial class MonitorActionsForm : Form
    {
        private ISettingsSource _settings;
        private IGitUICommands _gitCommands;
        private GitRef _currentItem;

        public MonitorActionsForm(ISettingsSource settings, IGitUICommands gitCommands, GitRef localBranch)
        {
            InitializeComponent();
            _settings = settings;
            _gitCommands = gitCommands;
            _currentItem = localBranch;
            Text = string.Format("{0} Monitor", Generic.PluginName);
            LblDescription.Text = localBranch.LocalName + LblDescription.Text;
            LblInfosRemoteBranch.Text = string.Format("Tracking branch : {0}/{1}", _currentItem.TrackingRemote, _currentItem.LocalName);
            CmdResult result = gitCommands.GitModule.RunGitCmdResult(string.Format("log -n 1 --pretty=format:\"Author : %an %cr\" {0}/{1}", _currentItem.TrackingRemote, _currentItem.LocalName));
            if (result.ExitCode == 0 && !string.IsNullOrWhiteSpace(result.StdOutput))
            {
                LblInfosAuthor.Text = result.StdOutput;
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
            Application.OpenForms[0].BeginInvoke((ThreadStart)delegate
            {
                _gitCommands.StartRebaseDialog(string.Format("{0}/{1}", _currentItem.TrackingRemote, _currentItem.LocalName));
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
            Application.OpenForms[0].BeginInvoke((ThreadStart)delegate
            {
                _gitCommands.StartMergeBranchDialog(string.Format("{0}/{1}", _currentItem.TrackingRemote, _currentItem.LocalName));
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
            TalentsoftToolsPlugin.BranchesToMonitor[_settings] = string.Join(";", TalentsoftToolsPlugin.BranchesToMonitor[_settings].Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).Where(x => x != _currentItem.LocalName).ToList());
            foreach (var form in Application.OpenForms)
            {
                var pluginForm = form as TalentsoftToolsForm;
                if (pluginForm != null)
                {
                    pluginForm.InitNotifications();
                }
            }
        }
    }
}
