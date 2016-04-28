namespace TalentsoftTools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using GitCommands;
    using GitUIPluginInterfaces;
    using Helpers;

    public partial class TalentsoftToolsForm
    {
        void DashboardProcess(bool isEnabled)
        {
            GbxDsbDatabases.Enabled = isEnabled;
            GbxDsbGeneric.Enabled = isEnabled;
            GbxDsbVisualStudioSolution.Enabled = isEnabled;
            BtnDsbCancelAction.Enabled = !isEnabled;
        }

        private void BtnDsbCancelActionClick(object sender, EventArgs e)
        {
            if (_workerThread != null && _workerThread.IsAlive)
            {
                _workerThread.Abort();
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
            }
        }

        private void BtnDsbExitSolutionClick(object sender, EventArgs e)
        {
            PbxDsbLoadingAction.Visible = true;
            string message;
            bool isExited = GenericHelper.ExitVisualStudio(CblDsbSolutions.SelectedItem.ToString());
            if (isExited)
            {
                message = CblDsbSolutions.SelectedItem + " is exited !";
            }
            else
            {
                message = "Error when exiting " + CblDsbSolutions.SelectedItem + " !";
            }
            PbxDsbLoadingAction.Visible = false;
            MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
        }

        private void BtnDsbBuildSolutionClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunDsbBuildSolution);
            _workerThread.Start();
        }

        void RunDsbBuildSolution()
        {
            string message;
            string solutionFileFullPath = null;
            string solutionFile = null;
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(false);
                PbxDsbLoadingAction.Visible = true;
                solutionFile = CblDsbSolutions.SelectedItem.ToString();
                solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
            }));
            string errors = string.Empty;
            if (GenericHelper.InvokeMsBuild(solutionFileFullPath, Generic.GenrateSolutionArguments.Build, ref errors))
            {
                message = $"Success of Building solution {solutionFile}";
            }
            else
            {
                message = $"Error when Building solution {solutionFile}\r\n{errors}";
            }
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbNugetRestoreClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunDsbNugetRestore);
            _workerThread.Start();
        }

        void RunDsbNugetRestore()
        {
            string message;
            string solutionFileFullPath = null;
            string solutionFile = null;
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(false);
                PbxDsbLoadingAction.Visible = true;
                solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
                solutionFile = CblDsbSolutions.SelectedItem.ToString();
            }));
            string errorMessages = string.Empty;
            if (GenericHelper.RunCommandLine(new List<string>
                {
                    string.Format("nuget restore {0}", solutionFileFullPath)
                }, ref errorMessages))
            {
                message = "Nuget restored for solution " + solutionFile;
            }
            else
            {
                message = "Error when restoring nuget for solution " + solutionFile + "\r\n" + errorMessages;
            }
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbRebuildSolutionClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunDsbRebuildSolution);
            _workerThread.Start();
        }

        void RunDsbRebuildSolution()
        {
            string message;
            string solutionFileFullPath = null;
            string solutionFile = null;
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(false);
                PbxDsbLoadingAction.Visible = true;
                solutionFile = CblDsbSolutions.SelectedItem.ToString();
                solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
            }));
            string errors = string.Empty;
            if (GenericHelper.InvokeMsBuild(solutionFileFullPath, Generic.GenrateSolutionArguments.Rebuild, ref errors))
            {
                message = $"Success of Rebuilding solution {solutionFile}";
            }
            else
            {
                message = $"Error when Rebuilding solution {solutionFile}\r\n{errors}";
            }
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbStartSolutionClick(object sender, EventArgs e)
        {
            PbxDsbLoadingAction.Visible = true;
            string message;
            string solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
            if (GenericHelper.LaunchVisualStudio(solutionFileFullPath))
            {
                message = "Success of launching solution " + CblDsbSolutions.SelectedItem;
            }
            else
            {
                message = "Error when launching solution " + CblDsbSolutions.SelectedItem;
            }
            PbxDsbLoadingAction.Visible = false;
            MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
        }

        private void BtnDsbRestoreDatabasesClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            Databases = DatabaseHelper.GetDatabasesFromSettings(TxbDsbDatabasesToRestore.Text);
            if (ValidateRestoreDatabases())
            {
                _workerThread = new Thread(RunDsbRestoreDatabases);
                _workerThread.Start();
            }
        }

        void RunDsbRestoreDatabases()
        {
            StringBuilder message = new StringBuilder();
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(false);
                PbxDsbLoadingAction.Visible = true;
            }));
            foreach (var database in Databases)
            {
                string errorMessages = string.Empty;
                if (DatabaseHelper.RestoreDatabase(database.DatabaseName, database.BackupFilePath,
                    TalentsoftToolsPlugin.DatabaseServerName[_settings],
                    TalentsoftToolsPlugin.DatabaseRelocateFile[_settings],
                    TalentsoftToolsPlugin.DatabaseRelocateFile[_settings],
                    ref errorMessages))
                {
                    message.Append(string.Format("\r\nSuccess of the restoration {0} database.", database.DatabaseName));
                }
                else
                {
                    message.Append(string.Format("\r\nError when restoring {0} database.{1}\r\n", database.DatabaseName, errorMessages));
                }
            }
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message.ToString(), Generic.PluginName, MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbGitCleanClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunDsbGitClean);
            _workerThread.Start();
        }

        void RunDsbGitClean()
        {
            string message;
            string excludeCommand = string.Empty;

            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(false);
                PbxDsbLoadingAction.Visible = true;
                if (!string.IsNullOrWhiteSpace(TxbDsbGitClean.Text))
                {
                    excludeCommand = $"{TxbDsbGitClean.Text}";
                }
            }));
            CmdResult gitCleanResult = GitHelper.Clean(excludeCommand);
            if (gitCleanResult.ExitCode != 0)
            {
                message = gitCleanResult.StdError;
            }
            else
            {
                message = "Success of cleaning directory !";
            }
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbFetchAllClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            PbxDsbLoadingAction.Visible = true;
            CmdResult results = GitHelper.FetchAllWithNotify(false);
            if (results.ExitCode != 0)
            {
                MessageBox.Show(results.StdError, "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Fetching success !", Generic.PluginName, MessageBoxButtons.OK);
            }
            PbxDsbLoadingAction.Visible = false;
        }

        private void BtnDsbExitAllVisualStudioClick(object sender, EventArgs e)
        {
            PbxDsbLoadingAction.Visible = true;
            string message;
            bool isExited = GenericHelper.ExitVisualStudio(string.Empty);
            if (isExited)
            {
                message = "All Visual Studio instances are exited !";
            }
            else
            {
                message = "Error when exiting all Visual Studio instances !";
            }
            PbxDsbLoadingAction.Visible = false;
            MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
        }

        private void BtnDsbStashChangesClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunStashChanges);
            _workerThread.Start();
        }

        void RunStashChanges()
        {
            bool canStash = GitHelper.IfChangedFiles();
            if (!canStash)
            {
                MessageBox.Show("There is no change to stash !", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    DashboardProcess(false);
                    PbxDsbLoadingAction.Visible = true;
                }));
                CmdResult gitStashResult = GitHelper.StashChanges();
                if (gitStashResult.ExitCode != 0)
                {
                    MessageBox.Show(gitStashResult.StdError, "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Stash changes success", Generic.PluginName, MessageBoxButtons.OK);
                }
                Invoke((MethodInvoker)(() =>
                {
                    DashboardProcess(true);
                    PbxDsbLoadingAction.Visible = false;
                }));
            }
        }

        private void BtnDsbStashPopClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunStashPop);
            _workerThread.Start();
        }

        void RunStashPop()
        {
            bool canStashPop = GitHelper.GetStashs().Any();
            if (!canStashPop)
            {
                MessageBox.Show("There is no stash to pop !", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    DashboardProcess(false);
                    PbxDsbLoadingAction.Visible = true;
                }));
                CmdResult gitStashPopResult = GitHelper.StashPop();
                if (gitStashPopResult.ExitCode != 0)
                {
                    MessageBox.Show(gitStashPopResult.StdError, "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Stash pop success", "Error", MessageBoxButtons.OK);
                }
                Invoke((MethodInvoker)(() =>
                {
                    DashboardProcess(true);
                    PbxDsbLoadingAction.Visible = false;
                }));
            }
        }

        private void BtnDsbRunScriptPrebuildClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunPreBuild);
            _workerThread.Start();
        }

        void RunPreBuild()
        {
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(false);
                PbxDsbLoadingAction.Visible = true;
            }));
            string errorMessages = string.Empty;
            if (GenericHelper.RunCommandLine(PreBuildFiles.ToList(), ref errorMessages))
            {
                MessageBox.Show("Commands PreBuild success !", Generic.PluginName, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error when launching commands PreBuild !\r\n" + errorMessages, "Error", MessageBoxButtons.OK);
            }
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
            }));
        }

        private void BtnDsbRunScriptPostbuildClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            _workerThread = new Thread(RunPostBuild);
            _workerThread.Start();
        }

        void RunPostBuild()
        {
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(false);
                PbxDsbLoadingAction.Visible = true;
            }));
            string errorMessages = string.Empty;
            if (GenericHelper.RunCommandLine(PostBuildFiles.ToList(), ref errorMessages))
            {
                MessageBox.Show("Commands PostBuild success !", Generic.PluginName, MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error when launching commands PostBuild !\r\n" + errorMessages, "Error", MessageBoxButtons.OK);
            }
            Invoke((MethodInvoker)(() =>
            {
                DashboardProcess(true);
                PbxDsbLoadingAction.Visible = false;
            }));
        }

        private void BtnDsbShowBranchClick(object sender, EventArgs e)
        {
            RemoteBranches = GitHelper.GetRemotesBranches();
            string message = string.Empty;
            if (!string.IsNullOrWhiteSpace(TxbDsbBranchPrefix.Text))
            {
                List<GitRef> results =
                    RemoteBranches.Where(
                        x =>
                            x.IsRemote &&
                            x.Name.StartsWith(TxbDsbBranchPrefix.Text, StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                if (results.Any())
                {
                    new ShowBranchesForm(results.Select(x => x.Name).ToList()).ShowDialog(this);
                }
                else
                {
                    message = "There is no branch that begins with : " + TxbDsbBranchPrefix.Text;
                }
            }
            else
            {
                message = "Please specify the branches prefix !";
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.OK);
            }
        }
    }
}
