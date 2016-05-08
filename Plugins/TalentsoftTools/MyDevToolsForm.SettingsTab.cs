namespace MyDevTools
{
    using System.Windows.Forms;
    using System;

    public partial class MyDevToolsForm
    {
        public void InitSettingsTab()
        {
            if (MyDevToolsPlugin.IsDefaultExitVisualStudio[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessExitVisualStudio.Checked = MyDevToolsPlugin.IsDefaultExitVisualStudio[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultStartVisualStudio[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRunVisualStudio.Checked = MyDevToolsPlugin.IsDefaultStartVisualStudio[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultStashChanges[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessStashChanges.Checked = MyDevToolsPlugin.IsDefaultStashChanges[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultCheckoutBranch[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessCheckout.Checked = MyDevToolsPlugin.IsDefaultCheckoutBranch[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultGitClean[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessGitClean.Checked = MyDevToolsPlugin.IsDefaultGitClean[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultStashPop[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessStashPop.Checked = MyDevToolsPlugin.IsDefaultStashPop[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultResetDatabases[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRestoreDatabases.Checked = MyDevToolsPlugin.IsDefaultResetDatabases[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultNugetRestore[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessNugetRestore.Checked = MyDevToolsPlugin.IsDefaultNugetRestore[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultBuildSolution[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessBuild.Checked = MyDevToolsPlugin.IsDefaultBuildSolution[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultPreBuildScripts[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRunPreBuild.Checked = MyDevToolsPlugin.IsDefaultPreBuildScripts[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultPostBuildProcess[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessPostBuild.Checked = MyDevToolsPlugin.IsDefaultPostBuildProcess[MyDevToolsPlugin.PluginSettings].Value;
            }
            if (MyDevToolsPlugin.IsDefaultRunUri[MyDevToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRunUris.Checked = MyDevToolsPlugin.IsDefaultRunUri[MyDevToolsPlugin.PluginSettings].Value;
            }
            TxbSettingsUris.Text = MyDevToolsPlugin.LocalUriWebApplication[MyDevToolsPlugin.PluginSettings];
            TxbSettingsDefaultSolutionFileName.Text = MyDevToolsPlugin.DefaultSolutionFileName[MyDevToolsPlugin.PluginSettings];
            TxbSettingsExcludeGitCleanPattern.Text = MyDevToolsPlugin.ExcludePatternGitClean[MyDevToolsPlugin.PluginSettings];
            TxbSettingsNewBranchPrefix.Text = MyDevToolsPlugin.NewBranchPrefix[MyDevToolsPlugin.PluginSettings];
            TxbSettingsBatchPreBuildScripts.Text = MyDevToolsPlugin.PreBuildBatch[MyDevToolsPlugin.PluginSettings];
            TxbSettingsBatchPostBuildScripts.Text = MyDevToolsPlugin.PostBuildBatch[MyDevToolsPlugin.PluginSettings];
            TxbSettingsDatabasesRestore.Text = MyDevToolsPlugin.DatabasesToRestore[MyDevToolsPlugin.PluginSettings];
            TxbSettingsNotificationsCheckIntrerval.Text = MyDevToolsPlugin.CheckInterval[MyDevToolsPlugin.PluginSettings].ToString();
            TxbSettingsNotificationsMonitorBranches.Text = MyDevToolsPlugin.BranchesToMonitor[MyDevToolsPlugin.PluginSettings];
            TxbSettingsDatabaseServerName.Text = MyDevToolsPlugin.DatabaseServerName[MyDevToolsPlugin.PluginSettings];
            TxbSettingsDatabaseRelocateFile.Text = MyDevToolsPlugin.DatabaseRelocateFile[MyDevToolsPlugin.PluginSettings];

            int checkInterval;
            int.TryParse(TxbSettingsNotificationsCheckIntrerval.Text, out checkInterval);
            CbxSettingsNotificationsEnable.Checked = checkInterval > Generic.DisableValueCheckMonitoInterval;
            TxbSettingsNotificationsCheckIntrerval.Enabled = checkInterval > 0;
        }

        private void BtnSettingsSaveClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to save plugin settings!\r\nAnother process is already running."))
            {
                return;
            }
            _plugin.CancelBackgroundOperation();
            int checkInterval = 0;
            if (TxbSettingsNotificationsCheckIntrerval.Enabled && !string.IsNullOrWhiteSpace(TxbSettingsNotificationsCheckIntrerval.Text))
            {
                if (!int.TryParse(TxbSettingsNotificationsCheckIntrerval.Text, out checkInterval))
                {
                    MessageBox.Show("Unable to save plugin settings!\r\nNotification check interval must be int value.", Generic.PluginName, MessageBoxButtons.OK);
                    return;
                }
            }

            MyDevToolsPlugin.CheckInterval[MyDevToolsPlugin.PluginSettings] = checkInterval;
            if (checkInterval > 0)
            {
                _plugin.RecreateObservable();
            }

            MyDevToolsPlugin.IsDefaultExitVisualStudio[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessExitVisualStudio.Checked;
            MyDevToolsPlugin.IsDefaultStartVisualStudio[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessRunVisualStudio.Checked;
            MyDevToolsPlugin.IsDefaultStashChanges[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessStashChanges.Checked;
            MyDevToolsPlugin.IsDefaultCheckoutBranch[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessCheckout.Checked;
            MyDevToolsPlugin.IsDefaultGitClean[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessGitClean.Checked;
            MyDevToolsPlugin.IsDefaultStashPop[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessStashPop.Checked;
            MyDevToolsPlugin.IsDefaultResetDatabases[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessRestoreDatabases.Checked;
            MyDevToolsPlugin.IsDefaultNugetRestore[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessNugetRestore.Checked;
            MyDevToolsPlugin.IsDefaultBuildSolution[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessBuild.Checked;
            MyDevToolsPlugin.IsDefaultPreBuildScripts[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessRunPreBuild.Checked;
            MyDevToolsPlugin.IsDefaultPostBuildProcess[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessPostBuild.Checked;
            MyDevToolsPlugin.IsDefaultRunUri[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessRunUris.Checked;
            MyDevToolsPlugin.LocalUriWebApplication[MyDevToolsPlugin.PluginSettings] = TxbSettingsUris.Text;
            MyDevToolsPlugin.DefaultSolutionFileName[MyDevToolsPlugin.PluginSettings] = TxbSettingsDefaultSolutionFileName.Text;
            MyDevToolsPlugin.ExcludePatternGitClean[MyDevToolsPlugin.PluginSettings] = TxbSettingsExcludeGitCleanPattern.Text;
            MyDevToolsPlugin.NewBranchPrefix[MyDevToolsPlugin.PluginSettings] = TxbSettingsNewBranchPrefix.Text;
            MyDevToolsPlugin.PreBuildBatch[MyDevToolsPlugin.PluginSettings] = TxbSettingsBatchPreBuildScripts.Text;
            MyDevToolsPlugin.PostBuildBatch[MyDevToolsPlugin.PluginSettings] = TxbSettingsBatchPostBuildScripts.Text;
            MyDevToolsPlugin.DatabasesToRestore[MyDevToolsPlugin.PluginSettings] = TxbSettingsDatabasesRestore.Text;
            MyDevToolsPlugin.BranchesToMonitor[MyDevToolsPlugin.PluginSettings] = TxbSettingsNotificationsMonitorBranches.Text;
            MyDevToolsPlugin.DatabaseServerName[MyDevToolsPlugin.PluginSettings] = TxbSettingsDatabaseServerName.Text;
            MyDevToolsPlugin.DatabaseRelocateFile[MyDevToolsPlugin.PluginSettings] = TxbSettingsDatabaseRelocateFile.Text;
            LoadDefaultStepsValuesFromSettings();

            MessageBox.Show("Settings has been saved !", Generic.PluginName, MessageBoxButtons.OK);
        }

        private void CbxSettingsNotificationsEnableCheckedChanged(object sender, EventArgs e)
        {
            if (CbxSettingsNotificationsEnable.Checked && TxbSettingsNotificationsCheckIntrerval.Text == Generic.DisableValueCheckMonitoInterval.ToString())
            {
                TxbSettingsNotificationsCheckIntrerval.Enabled = true;
                TxbSettingsNotificationsCheckIntrerval.Text = Generic.DefaultValueCheckMonitoInterval.ToString();
            }
            else if (!CbxSettingsNotificationsEnable.Checked)
            {
                TxbSettingsNotificationsCheckIntrerval.Enabled = false;
                TxbSettingsNotificationsCheckIntrerval.Text = Generic.DisableValueCheckMonitoInterval.ToString();
            }
        }

        private void PbxSettingsResetMonitorBranchesClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TxbSettingsNotificationsMonitorBranches.Text))
            {
                DialogResult response = MessageBox.Show("Are you sure to remove all branches from notifications ?", Generic.PluginName, MessageBoxButtons.YesNo);
                if (response == DialogResult.Yes)
                {
                    TxbSettingsNotificationsMonitorBranches.Text = String.Empty;
                }
            }
        }
    }
}
