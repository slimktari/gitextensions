namespace TalentsoftTools
{
    using System.Windows.Forms;
    using System;

    public partial class TalentsoftToolsForm
    {
        public void InitSettingsTab()
        {
            if (TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings].HasValue)
            {
                CbxSettingsProcessExitVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultStartVisualStudio[_settings].HasValue)
            {
                CbxSettingsProcessRunVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultStartVisualStudio[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].HasValue)
            {
                CbxSettingsProcessStashChanges.Checked = TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].HasValue)
            {
                CbxSettingsProcessCheckout.Checked = TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultGitClean[_settings].HasValue)
            {
                CbxSettingsProcessGitClean.Checked = TalentsoftToolsPlugin.IsDefaultGitClean[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultStashPop[_settings].HasValue)
            {
                CbxSettingsProcessStashPop.Checked = TalentsoftToolsPlugin.IsDefaultStashPop[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultResetDatabases[_settings].HasValue)
            {
                CbxSettingsProcessRestoreDatabases.Checked = TalentsoftToolsPlugin.IsDefaultResetDatabases[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultNugetRestore[_settings].HasValue)
            {
                CbxSettingsProcessNugetRestore.Checked = TalentsoftToolsPlugin.IsDefaultNugetRestore[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].HasValue)
            {
                CbxSettingsProcessBuild.Checked = TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultPreBuildScripts[_settings].HasValue)
            {
                CbxSettingsProcessRunPreBuild.Checked = TalentsoftToolsPlugin.IsDefaultPreBuildScripts[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultPostBuildProcess[_settings].HasValue)
            {
                CbxSettingsProcessPostBuild.Checked = TalentsoftToolsPlugin.IsDefaultPostBuildProcess[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultRunUri[_settings].HasValue)
            {
                CbxSettingsProcessRunUris.Checked = TalentsoftToolsPlugin.IsDefaultRunUri[_settings].Value;
            }
            TxbSettingsUris.Text = TalentsoftToolsPlugin.LocalUriWebApplication[_settings];
            TxbSettingsDefaultSolutionFileName.Text = TalentsoftToolsPlugin.DefaultSolutionFileName[_settings];
            TxbSettingsExcludeGitCleanPattern.Text = TalentsoftToolsPlugin.ExcludePatternGitClean[_settings];
            TxbSettingsNewBranchPrefix.Text = TalentsoftToolsPlugin.NewBranchPrefix[_settings];
            TxbSettingsBatchPreBuildScripts.Text = TalentsoftToolsPlugin.PreBuildBatch[_settings];
            TxbSettingsBatchPostBuildScripts.Text = TalentsoftToolsPlugin.PostBuildBatch[_settings];
            TxbSettingsDatabasesRestore.Text = TalentsoftToolsPlugin.DatabasesToRestore[_settings];
            TxbSettingsNotificationsCheckIntrerval.Text = TalentsoftToolsPlugin.CheckInterval[_settings].ToString();
            TxbSettingsNotificationsMonitorBranches.Text = TalentsoftToolsPlugin.BranchesToMonitor[_settings];
            TxbSettingsDatabaseServerName.Text = TalentsoftToolsPlugin.DatabaseServerName[_settings];
            TxbSettingsDatabaseUserName.Text = TalentsoftToolsPlugin.DatabaseUserName[_settings];
            TxbSettingsDatabasePassword.Text = TalentsoftToolsPlugin.DatabasePassword[_settings];
            TxbSettingsDatabaseRelocateFile.Text = TalentsoftToolsPlugin.DatabaseRelocateFile[_settings];

            int checkInterval;
            int.TryParse(TxbSettingsNotificationsCheckIntrerval.Text, out checkInterval);
            CbxSettingsNotificationsEnable.Checked = checkInterval > Generic.DisableValueCheckMonitoInterval;
            TxbSettingsNotificationsCheckIntrerval.Enabled = checkInterval > 0;
            TxbSettingsNotificationsMonitorBranches.Enabled = checkInterval > 0;
        }

        private void BtnSettingsSaveClick(object sender, EventArgs e)
        {
            int checkInterval = 0;
            if (TxbSettingsNotificationsCheckIntrerval.Enabled && !string.IsNullOrWhiteSpace(TxbSettingsNotificationsCheckIntrerval.Text))
            {
                if (!int.TryParse(TxbSettingsNotificationsCheckIntrerval.Text, out checkInterval))
                {
                    MessageBox.Show("Unable to save plugin settings.\r\nNotification check interval must be int value.", Generic.PluginName, MessageBoxButtons.OK);
                    return;
                }
            }
            if (!IsProcessAborted)
            {
                MessageBox.Show("Unable to save plugin settings.\r\nThe process is running.", Generic.PluginName, MessageBoxButtons.OK);
                return;
            }

            TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings] = CbxSettingsProcessExitVisualStudio.Checked;
            TalentsoftToolsPlugin.IsDefaultStartVisualStudio[_settings] = CbxSettingsProcessRunVisualStudio.Checked;
            TalentsoftToolsPlugin.IsDefaultStashChanges[_settings] = CbxSettingsProcessStashChanges.Checked;
            TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings] = CbxSettingsProcessCheckout.Checked;
            TalentsoftToolsPlugin.IsDefaultGitClean[_settings] = CbxSettingsProcessGitClean.Checked;
            TalentsoftToolsPlugin.IsDefaultStashPop[_settings] = CbxSettingsProcessStashPop.Checked;
            TalentsoftToolsPlugin.IsDefaultResetDatabases[_settings] = CbxSettingsProcessRestoreDatabases.Checked;
            TalentsoftToolsPlugin.IsDefaultNugetRestore[_settings] = CbxSettingsProcessNugetRestore.Checked;
            TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings] = CbxSettingsProcessBuild.Checked;
            TalentsoftToolsPlugin.IsDefaultPreBuildScripts[_settings] = CbxSettingsProcessRunPreBuild.Checked;
            TalentsoftToolsPlugin.IsDefaultPostBuildProcess[_settings] = CbxSettingsProcessPostBuild.Checked;
            TalentsoftToolsPlugin.IsDefaultRunUri[_settings] = CbxSettingsProcessRunUris.Checked;
            TalentsoftToolsPlugin.LocalUriWebApplication[_settings] = TxbSettingsUris.Text;
            TalentsoftToolsPlugin.DefaultSolutionFileName[_settings] = TxbSettingsDefaultSolutionFileName.Text;
            TalentsoftToolsPlugin.ExcludePatternGitClean[_settings] = TxbSettingsExcludeGitCleanPattern.Text;
            TalentsoftToolsPlugin.NewBranchPrefix[_settings] = TxbSettingsNewBranchPrefix.Text;
            TalentsoftToolsPlugin.PreBuildBatch[_settings] = TxbSettingsBatchPreBuildScripts.Text;
            TalentsoftToolsPlugin.PostBuildBatch[_settings] = TxbSettingsBatchPostBuildScripts.Text;
            TalentsoftToolsPlugin.DatabasesToRestore[_settings] = TxbSettingsDatabasesRestore.Text;
            TalentsoftToolsPlugin.CheckInterval[_settings] = checkInterval;
            TalentsoftToolsPlugin.BranchesToMonitor[_settings] = TxbSettingsNotificationsMonitorBranches.Text;
            TalentsoftToolsPlugin.DatabaseServerName[_settings] = TxbSettingsDatabaseServerName.Text;
            TalentsoftToolsPlugin.DatabaseUserName[_settings] = TxbSettingsDatabaseUserName.Text;
            TalentsoftToolsPlugin.DatabasePassword[_settings] = TxbSettingsDatabasePassword.Text;
            TalentsoftToolsPlugin.DatabaseRelocateFile[_settings] = TxbSettingsDatabaseRelocateFile.Text;
            LoadDefaultStepsValuesFromSettings();

            MessageBox.Show("Settings has been saved !", Generic.PluginName, MessageBoxButtons.OK);
        }

        private void CbxSettingsNotificationsEnableCheckedChanged(object sender, EventArgs e)
        {
            if (CbxSettingsNotificationsEnable.Checked && TxbSettingsNotificationsCheckIntrerval.Text == Generic.DisableValueCheckMonitoInterval.ToString())
            {
                TxbSettingsNotificationsCheckIntrerval.Enabled = true;
                TxbSettingsNotificationsCheckIntrerval.Text = Generic.DefaultValueCheckMonitoInterval.ToString();
                TxbSettingsNotificationsMonitorBranches.Enabled = true;
            }
            else if (!CbxSettingsNotificationsEnable.Checked)
            {
                TxbSettingsNotificationsCheckIntrerval.Enabled = false;
                TxbSettingsNotificationsCheckIntrerval.Text = Generic.DisableValueCheckMonitoInterval.ToString();
                TxbSettingsNotificationsMonitorBranches.Enabled = false;
            }
        }
    }
}
