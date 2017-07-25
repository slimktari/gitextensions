namespace MyDevTools
{
    using System.Windows.Forms;
    using System;

    public partial class MyDevToolsForm
    {
        public void InitSettingsTab()
        {
            CbxSettingsProcessExitVisualStudio.Checked = MyDevToolsPlugin.IsDefaultExitVisualStudio.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessRunVisualStudio.Checked = MyDevToolsPlugin.IsDefaultStartVisualStudio.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessStashChanges.Checked = MyDevToolsPlugin.IsDefaultStashChanges.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessCheckout.Checked = MyDevToolsPlugin.IsDefaultCheckoutBranch.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessGitClean.Checked = MyDevToolsPlugin.IsDefaultGitClean.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessStashPop.Checked = MyDevToolsPlugin.IsDefaultStashPop.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessRestoreDatabases.Checked = MyDevToolsPlugin.IsDefaultResetDatabases.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessNugetRestore.Checked = MyDevToolsPlugin.IsDefaultNugetRestore.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessBuild.Checked = MyDevToolsPlugin.IsDefaultBuildSolution.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessBuildFront.Checked = MyDevToolsPlugin.IsDefaultBuildFrontSolution.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessRunPreBuild.Checked = MyDevToolsPlugin.IsDefaultPreBuildScripts.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessPostBuild.Checked = MyDevToolsPlugin.IsDefaultPostBuildProcess.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            CbxSettingsProcessRunUris.Checked = MyDevToolsPlugin.IsDefaultRunUri.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsUris.Text = MyDevToolsPlugin.LocalUriWebApplication.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsDefaultSolutionFileName.Text = MyDevToolsPlugin.DefaultSolutionFileName.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsExcludeGitCleanPattern.Text = MyDevToolsPlugin.ExcludePatternGitClean.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsNewBranchPrefix.Text = MyDevToolsPlugin.NewBranchPrefix.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsBatchPreBuildScripts.Text = MyDevToolsPlugin.PreBuildBatch.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsBatchPostBuildScripts.Text = MyDevToolsPlugin.PostBuildBatch.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsDatabasesRestore.Text = MyDevToolsPlugin.DatabasesToRestore.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsNotificationsMonitorBranches.Text = MyDevToolsPlugin.BranchesToMonitor.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsDatabaseServerName.Text = MyDevToolsPlugin.DatabaseServerName.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsDatabaseRelocateFile.Text = MyDevToolsPlugin.DatabaseRelocateFile.ValueOrDefault(MyDevToolsPlugin.PluginSettings);
            TxbSettingsNotificationsCheckIntrerval.Text = MyDevToolsPlugin.CheckInterval.ValueOrDefault(MyDevToolsPlugin.PluginSettings).ToString();
            CbxSettingsNotificationsEnable.Checked = MyDevToolsPlugin.CheckInterval.ValueOrDefault(MyDevToolsPlugin.PluginSettings) > Generic.DisableValueCheckMonitoInterval;
            TxbSettingsNotificationsCheckIntrerval.Enabled = MyDevToolsPlugin.CheckInterval.ValueOrDefault(MyDevToolsPlugin.PluginSettings) > 0;
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
            MyDevToolsPlugin.IsDefaultBuildFrontSolution[MyDevToolsPlugin.PluginSettings] = CbxSettingsProcessBuildFront.Checked;
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
