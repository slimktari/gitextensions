namespace TalentsoftTools
{
    using System.Windows.Forms;
    using System;

    public partial class TalentsoftToolsForm
    {
        public void InitSettingsTab()
        {
            if (TalentsoftToolsPlugin.IsDefaultExitVisualStudio[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessExitVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultExitVisualStudio[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultStartVisualStudio[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRunVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultStartVisualStudio[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultStashChanges[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessStashChanges.Checked = TalentsoftToolsPlugin.IsDefaultStashChanges[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultCheckoutBranch[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessCheckout.Checked = TalentsoftToolsPlugin.IsDefaultCheckoutBranch[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultGitClean[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessGitClean.Checked = TalentsoftToolsPlugin.IsDefaultGitClean[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultStashPop[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessStashPop.Checked = TalentsoftToolsPlugin.IsDefaultStashPop[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultResetDatabases[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRestoreDatabases.Checked = TalentsoftToolsPlugin.IsDefaultResetDatabases[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultNugetRestore[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessNugetRestore.Checked = TalentsoftToolsPlugin.IsDefaultNugetRestore[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultBuildSolution[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessBuild.Checked = TalentsoftToolsPlugin.IsDefaultBuildSolution[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultPreBuildScripts[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRunPreBuild.Checked = TalentsoftToolsPlugin.IsDefaultPreBuildScripts[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultPostBuildProcess[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessPostBuild.Checked = TalentsoftToolsPlugin.IsDefaultPostBuildProcess[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultRunUri[TalentsoftToolsPlugin.PluginSettings].HasValue)
            {
                CbxSettingsProcessRunUris.Checked = TalentsoftToolsPlugin.IsDefaultRunUri[TalentsoftToolsPlugin.PluginSettings].Value;
            }
            TxbSettingsUris.Text = TalentsoftToolsPlugin.LocalUriWebApplication[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsDefaultSolutionFileName.Text = TalentsoftToolsPlugin.DefaultSolutionFileName[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsExcludeGitCleanPattern.Text = TalentsoftToolsPlugin.ExcludePatternGitClean[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsNewBranchPrefix.Text = TalentsoftToolsPlugin.NewBranchPrefix[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsBatchPreBuildScripts.Text = TalentsoftToolsPlugin.PreBuildBatch[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsBatchPostBuildScripts.Text = TalentsoftToolsPlugin.PostBuildBatch[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsDatabasesRestore.Text = TalentsoftToolsPlugin.DatabasesToRestore[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsNotificationsCheckIntrerval.Text = TalentsoftToolsPlugin.CheckInterval[TalentsoftToolsPlugin.PluginSettings].ToString();
            TxbSettingsNotificationsMonitorBranches.Text = TalentsoftToolsPlugin.BranchesToMonitor[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsDatabaseServerName.Text = TalentsoftToolsPlugin.DatabaseServerName[TalentsoftToolsPlugin.PluginSettings];
            TxbSettingsDatabaseRelocateFile.Text = TalentsoftToolsPlugin.DatabaseRelocateFile[TalentsoftToolsPlugin.PluginSettings];

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

            TalentsoftToolsPlugin.CheckInterval[TalentsoftToolsPlugin.PluginSettings] = checkInterval;
            if (checkInterval > 0)
            {
                _plugin.RecreateObservable();
            }

            TalentsoftToolsPlugin.IsDefaultExitVisualStudio[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessExitVisualStudio.Checked;
            TalentsoftToolsPlugin.IsDefaultStartVisualStudio[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessRunVisualStudio.Checked;
            TalentsoftToolsPlugin.IsDefaultStashChanges[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessStashChanges.Checked;
            TalentsoftToolsPlugin.IsDefaultCheckoutBranch[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessCheckout.Checked;
            TalentsoftToolsPlugin.IsDefaultGitClean[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessGitClean.Checked;
            TalentsoftToolsPlugin.IsDefaultStashPop[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessStashPop.Checked;
            TalentsoftToolsPlugin.IsDefaultResetDatabases[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessRestoreDatabases.Checked;
            TalentsoftToolsPlugin.IsDefaultNugetRestore[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessNugetRestore.Checked;
            TalentsoftToolsPlugin.IsDefaultBuildSolution[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessBuild.Checked;
            TalentsoftToolsPlugin.IsDefaultPreBuildScripts[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessRunPreBuild.Checked;
            TalentsoftToolsPlugin.IsDefaultPostBuildProcess[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessPostBuild.Checked;
            TalentsoftToolsPlugin.IsDefaultRunUri[TalentsoftToolsPlugin.PluginSettings] = CbxSettingsProcessRunUris.Checked;
            TalentsoftToolsPlugin.LocalUriWebApplication[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsUris.Text;
            TalentsoftToolsPlugin.DefaultSolutionFileName[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsDefaultSolutionFileName.Text;
            TalentsoftToolsPlugin.ExcludePatternGitClean[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsExcludeGitCleanPattern.Text;
            TalentsoftToolsPlugin.NewBranchPrefix[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsNewBranchPrefix.Text;
            TalentsoftToolsPlugin.PreBuildBatch[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsBatchPreBuildScripts.Text;
            TalentsoftToolsPlugin.PostBuildBatch[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsBatchPostBuildScripts.Text;
            TalentsoftToolsPlugin.DatabasesToRestore[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsDatabasesRestore.Text;
            TalentsoftToolsPlugin.BranchesToMonitor[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsNotificationsMonitorBranches.Text;
            TalentsoftToolsPlugin.DatabaseServerName[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsDatabaseServerName.Text;
            TalentsoftToolsPlugin.DatabaseRelocateFile[TalentsoftToolsPlugin.PluginSettings] = TxbSettingsDatabaseRelocateFile.Text;
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
