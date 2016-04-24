namespace TalentsoftTools
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using GitCommands;
    using GitUIPluginInterfaces;
    using Helpers;
    using Dto;

    public partial class TalentsoftToolsForm
    {
        #region Fields & Properties

        bool IsExitVisualStudio { get; set; }
        bool IsStashCahnges { get; set; }
        bool IsCheckoutBranch { get; set; }
        bool IsGitClean { get; set; }
        bool IsStashPop { get; set; }
        bool IsPreBuildSolution { get; set; }
        bool IsRestoreDatabase { get; set; }
        bool IsNugetRestore { get; set; }
        bool IsBuildSolution { get; set; }
        bool IsPostBuildSolution { get; set; }
        bool IsRunVisualStudio { get; set; }
        bool IsRunUri { get; set; }
        bool IsCreateNewBranch { get; set; }
        List<string> PreBuildFiles { get; set; }
        List<string> PostBuildFiles { get; set; }
        bool? CanStashPop { get; set; }
        bool LastStashPopValue { get; set; }
        string Uris { get; set; }
        string NewBranchName { get; set; }
        string TargetSolutionName { get; set; }
        GitRef TargetBranch { get; set; }
        bool IsProcessAborted { get; set; }
        private Thread _workerThread;
        private string WorkingDirectory { get; set; }
        private List<DatabaseDto> Databases { get; set; }
        private Dictionary<string, string> SolutionDictionary { get; set; }

        #endregion

        #region Methods

        void LoadSolutionsFiles()
        {
            SolutionDictionary = GenericHelper.GetSolutionsFile(WorkingDirectory);

            CblSolutions.DataSource = SolutionDictionary.Select(x => x.Key).ToList();
            CblDsbSolutions.DataSource = SolutionDictionary.Select(x => x.Key).ToList();
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.DefaultSolutionFileName[_settings]) && CblSolutions.Items.Count > 1)
            {
                foreach (var item in CblSolutions.Items)
                {
                    if (item.ToString().EndsWith(TalentsoftToolsPlugin.DefaultSolutionFileName[_settings], StringComparison.InvariantCultureIgnoreCase))
                    {
                        CblSolutions.SelectedItem = item;
                        break;
                    }
                }
                foreach (var item in CblDsbSolutions.Items)
                {
                    if (item.ToString().EndsWith(TalentsoftToolsPlugin.DefaultSolutionFileName[_settings], StringComparison.InvariantCultureIgnoreCase))
                    {
                        CblDsbSolutions.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        void ResetControls()
        {
            BtnStopProcess.Enabled = false;
            LblActualBranchName.Text = GitHelper.GetSelectedBranch();
            LblActualRepository.Text = WorkingDirectory;
            TxbNewBranchName.Enabled = false;
        }

        void ResetCheckboxBackColor()
        {
            CbxIsBuildSolution.BackColor = Color.Transparent;
            CbxLaunchUri.BackColor = Color.Transparent;
            CbxIsCheckoutBranch.BackColor = Color.Transparent;
            CbxIsGitClean.BackColor = Color.Transparent;
            CbxIsStashPop.BackColor = Color.Transparent;
            CbxIsRunVisualStudio.BackColor = Color.Transparent;
            CbxIsExitVisualStudio.BackColor = Color.Transparent;
            CbxIsStashChanges.BackColor = Color.Transparent;
            CbxIsNugetRestore.BackColor = Color.Transparent;
            CbxIsPreBuild.BackColor = Color.Transparent;
            CbxIsPostBuild.BackColor = Color.Transparent;
            CbxIsRestoreDatabases.BackColor = Color.Transparent;
        }

        void ExitProcess()
        {
            if (_workerThread != null && _workerThread.IsAlive)
            {
                _workerThread.Abort();
                IsProcessAborted = true;
                BtnRunProcess.Enabled = true;
                BtnStopProcess.Enabled = false;
                PbxDsbLoadingAction.Visible = false;
                TbcMain.TabPages[2].Enabled = true;
                LoadLocalBranches();
                InitLocalBranchTab();
                InitNotificationsTab();
                UpdateNotifications();
            }
        }

        void RunProcess()
        {
            string solutionFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == TargetSolutionName).Value;
            DateTime startDateTime = DateTime.Now;
            Invoke((MethodInvoker)(() =>
            {
                TbxLogInfo.AppendText(string.Format("Start at: {0}\r\nCurrent branch: {1}", startDateTime,
                    GitHelper.GetSelectedBranch()));
                if (CbxIsCheckoutBranch.Checked && TargetBranch != null)
                {
                    TbxLogInfo.AppendText(string.Format("\r\nTarget branch: {0}\r\nTarget solution: {1}\r\n",
                        TargetBranch.Name, TargetSolutionName));
                }
                if (CbxIsBuildSolution.Checked || CbxIsGitClean.Checked)
                {
                    TbxLogInfo.AppendText(string.Format("\r\nTarget solution: {0}\r\n", TargetSolutionName));
                }
            }));

            if (IsExitVisualStudio)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsExitVisualStudio.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText("\r\nExiting Visual Studio...");
                }));
                bool isExited = GenericHelper.ExitVisualStudio(TargetSolutionName);
                if (!isExited)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsExitVisualStudio.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText("\r\nError when exit Visual Studio.");
                    }));
                    IsProcessAborted = true;
                }
                else
                {

                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsExitVisualStudio.BackColor = Generic.ColorProcessTaskSuccess;
                    }));
                }
            }
            if (IsStashCahnges)
            {

                Invoke((MethodInvoker)(() =>
                {
                    CbxIsStashChanges.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText("\r\nStashing changes... 'stash --include-untracked'.");
                }));

                CmdResult gitStashResult = GitHelper.StashChanges();
                if (gitStashResult.ExitCode != 0)
                {

                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashChanges.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText($"\r\nError when stashing changes. {gitStashResult.StdError}.");
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashChanges.BackColor = Generic.ColorProcessTaskSuccess;
                    }));
                }
            }
            if (IsCheckoutBranch)
            {
                bool isLocal = false;
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsCheckoutBranch.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText($"\r\nCheckout branch {TargetBranch.Name}...");
                    TbxLogInfo.AppendText($" 'checkout -B {TargetBranch.LocalName} {TargetBranch.Name}'.");
                    isLocal = RbtIsLocalTargetBranch.Checked;
                }));
                CmdResult gitCheckoutResult;
                if (isLocal)
                {
                    gitCheckoutResult = GitHelper.CheckoutBranch(TargetBranch.LocalName);
                }
                else
                {
                    gitCheckoutResult = GitHelper.CheckoutBranch(TargetBranch.LocalName, TargetBranch.Name);
                }

                if (gitCheckoutResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsCheckoutBranch.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText($"\r\nError when checkout branch. {gitCheckoutResult.StdError}.");
                    }));
                }

                if (IsCreateNewBranch && !string.IsNullOrWhiteSpace(NewBranchName))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nCreating new local branch {NewBranchName}... 'checkout -b {NewBranchName}'.");
                    }));
                    CmdResult gitCreateNewBranchResult = GitHelper.CreateAndCheckoutBranch(NewBranchName);
                    if (gitCreateNewBranchResult.ExitCode != 0)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsCheckoutBranch.BackColor = Generic.ColorProcessTaskFailed;
                            TbxLogInfo.AppendText($"\r\nError when Creating new branch {NewBranchName}. {gitCheckoutResult.StdError}.");
                        }));
                    }
                }
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsCheckoutBranch.BackColor = Generic.ColorProcessTaskSuccess;
                }));
            }
            if (IsGitClean)
            {
                Invoke((MethodInvoker)(() => { CbxIsGitClean.BackColor = Generic.ColorProcessTaskInProgress; }));
                string excludeCommand = string.Empty;
                if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]))
                {
                    excludeCommand = $"{TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]}";
                }
                Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($"\r\nCleaning solution: {TargetSolutionName}...");
                }));
                CmdResult gitCleanResult = GitHelper.Clean(excludeCommand);
                if (gitCleanResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsGitClean.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText($"\r\nError when cleaning solution: {TargetSolutionName}. {gitCleanResult.StdError}.");
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsGitClean.BackColor = Generic.ColorProcessTaskSuccess;
                    }));
                }
            }
            if (IsStashPop)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsStashPop.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText("\r\nPopping stash... \"stash pop");
                }));
                CmdResult gitStashPopResult = GitHelper.StashPop();
                if (gitStashPopResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashPop.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText($"\r\nError when popping stash. {gitStashPopResult.StdError}");
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashPop.BackColor = Generic.ColorProcessTaskSuccess;
                    }));
                }
            }
            if (IsRestoreDatabase && Databases.Any())
            {
                bool isRestore = false;
                bool isError = false;
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsRestoreDatabases.BackColor = Generic.ColorProcessTaskInProgress;
                }));
                foreach (var database in Databases)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText("\r\nRestoring database : " + database.DatabaseName);
                    }));
                    string errorMessages = string.Empty;
                    if (DatabaseHelper.RestoreDatabase(database.DatabaseName, database.BackupFilePath,
                        TalentsoftToolsPlugin.DatabaseServerName[_settings],
                        TalentsoftToolsPlugin.DatabaseRelocateFile[_settings],
                        TalentsoftToolsPlugin.DatabaseRelocateFile[_settings], ref errorMessages))
                    {
                        isRestore = true;
                        Invoke((MethodInvoker)(() =>
                        {
                            TbxLogInfo.AppendText($"\r\nSuccess of the restoration {database.DatabaseName} database.");
                        }));
                    }
                    else
                    {
                        isError = true;
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsRestoreDatabases.BackColor = Generic.ColorProcessTaskFailed;
                            TbxLogInfo.AppendText(string.Format("\r\nError when restoring {0} database.\r\n{1}",
                                database.DatabaseName, errorMessages));
                        }));
                    }
                    if (isRestore && isError)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsRestoreDatabases.BackColor = Generic.ColorProcessTaskWarning;
                            TbxLogInfo.AppendText("\r\nSome database was not restored.");
                        }));
                    }
                    else if (isRestore)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsRestoreDatabases.BackColor = Generic.ColorProcessTaskSuccess;
                        }));
                    }
                }
            }
            if (IsPreBuildSolution)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsPreBuild.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText($"\r\nRunning Pre-Build scripts:\r\n{string.Join("\r\n", PreBuildFiles)}");
                }));
                string errorMessages = string.Empty;
                bool result = GenericHelper.RunCommandLine(PreBuildFiles.ToList(), ref errorMessages);
                if (!result)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsPreBuild.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText("\r\nError when running Pre-Build scripts.\r\n" + errorMessages);
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsPreBuild.BackColor = Generic.ColorProcessTaskSuccess;
                    }));
                }
            }
            if (IsNugetRestore)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsNugetRestore.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText($"\r\nRestoring Nugets in solution: {TargetSolutionName}... 'nuget restore {solutionFullPath}'.");
                }));
                string errorMessages = string.Empty;
                if (GenericHelper.RunCommandLine(new List<string> { $"nuget restore {solutionFullPath}" }, ref errorMessages))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsNugetRestore.BackColor = Generic.ColorProcessTaskSuccess;
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsNugetRestore.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText($"\r\nError when restoring nugets in solution: {solutionFullPath}.\r\n{errorMessages}");
                    }));
                }
            }
            if (IsBuildSolution)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsBuildSolution.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText($"\r\nBuilding solution: {TargetSolutionName}...");
                }));
                string errorResult = string.Empty;
                if (GenericHelper.InvokeMsBuild(solutionFullPath, Generic.GenrateSolutionArguments.Build, ref errorResult))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsBuildSolution.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText($"\r\nError when building solution: {solutionFullPath}.");
                        TbxLogInfo.AppendText($"\r\n{errorResult}");
                    }));
                }
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsBuildSolution.BackColor = Generic.ColorProcessTaskSuccess;
                }));
            }
            if (IsPostBuildSolution)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsPostBuild.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText($"\r\nRunning Post-Build scripts:\r\n{string.Join("\r\n", PostBuildFiles)}");
                }));
                string errorMessages = string.Empty;
                bool result = GenericHelper.RunCommandLine(PostBuildFiles.ToList(), ref errorMessages);
                if (!result)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsPostBuild.BackColor = Generic.ColorProcessTaskFailed;
                        TbxLogInfo.AppendText("\r\nError when running Post-Build scripts.\r\n" + errorMessages);
                    }));
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsPostBuild.BackColor = Generic.ColorProcessTaskSuccess;
                    }));
                }
            }
            if (IsRunVisualStudio)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsRunVisualStudio.BackColor = Generic.ColorProcessTaskInProgress;
                    TbxLogInfo.AppendText($"\r\nRunning Visual Studio with: {TargetSolutionName}...");
                }));

                new Thread(() => GenericHelper.LaunchVisualStudio(solutionFullPath)).Start();
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsRunVisualStudio.BackColor = Generic.ColorProcessTaskSuccess;
                }));
            }
            if (IsRunUri)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxLaunchUri.BackColor = Generic.ColorProcessTaskInProgress;
                }));
                foreach (var uri in Uris.Split(';'))
                {
                    if (!string.IsNullOrWhiteSpace(uri))
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            TbxLogInfo.AppendText($"\r\nLaunching web URI: {Uris}...");
                        }));
                        if (!GenericHelper.LaunchWebUri(uri))
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                CbxLaunchUri.BackColor = Generic.ColorProcessTaskFailed;
                                TbxLogInfo.AppendText($"\r\nError when launching web URI: {uri}.");
                            }));
                        }
                        else
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                CbxLaunchUri.BackColor = Generic.ColorProcessTaskSuccess;
                            }));
                        }
                    }
                }
            }
            DateTime endateDateTime = DateTime.Now;
            Invoke((MethodInvoker)(() =>
            {
                TbxLogInfo.AppendText($"\r\n\r\nEnd at: {endateDateTime}.");
                TbxLogInfo.AppendText($"\r\nElapsed time: {endateDateTime - startDateTime}.");
                GitHelper.NotifyGitExtensions();
                LblActualBranchName.Text = GitHelper.GetSelectedBranch();
                LblActualRepository.Text = GitHelper.GetWorkingDirectory();
                ExitProcess();
            }));
        }

        bool ValidateUri()
        {
            string message = string.Empty;
            if (CbxLaunchUri.Checked && (string.IsNullOrWhiteSpace(TxbUri.Text) || (TxbUri.Text.Contains(";") && string.IsNullOrWhiteSpace(TxbUri.Text.Remove(';')))))
            {
                message = "URI not defined.";
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        bool ValidateRestoreDatabases()
        {
            string message = string.Empty;
            if (!Databases.Any() || Databases.Any(d => string.IsNullOrWhiteSpace(d.DatabaseName) || string.IsNullOrWhiteSpace(d.BackupFilePath) || !File.Exists(d.BackupFilePath)))
            {
                message = "Databases not correctly defined.";
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        bool ValidateCreateBranch()
        {
            string message = string.Empty;
            if (CbxIsCreateNewBranch.Checked && CbxIsCheckoutBranch.Checked)
            {
                if (string.IsNullOrWhiteSpace(TxbNewBranchName.Text))
                {
                    message = "Please specify the name of the branch to create.";
                }
                else
                {
                    LocalBranches = GitHelper.GetLocalsBranches();
                    if (LocalBranches.Any(b => b.Name.ToUpper() == TxbNewBranchName.Text.ToUpper()))
                    {
                        message = "There is already a branch that has the same name.";
                    }
                }
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        bool ValidateCheckoutBranch()
        {
            string message = string.Empty;
            if (CbxIsCheckoutBranch.Checked)
            {
                if (string.IsNullOrWhiteSpace(ActBranches.Text))
                {
                    message = "There is no selected branch !";
                }
                else
                {
                    if (RbtIsRemoteTargetBranch.Checked)
                    {
                        RemoteBranches = GitHelper.GetRemotesBranches();
                        TargetBranch = RemoteBranches.FirstOrDefault(b => b.Name.ToUpper() == ActBranches.Text.ToUpper());
                    }
                    else
                    {
                        LocalBranches = GitHelper.GetLocalsBranches();
                        TargetBranch = LocalBranches.FirstOrDefault(b => b.Name.ToUpper() == ActBranches.Text.ToUpper());
                    }
                    if (TargetBranch == null)
                    {
                        message = "The selected branch does not exist !";
                    }
                }
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        private void BtnRunProcessClick(object sender, EventArgs e)
        {
            if (!CheckIfCanRunProcess("Unable to run process!\r\nAnother process is already running."))
            {
                return;
            }
            Databases = DatabaseHelper.GetDatabasesFromSettings(TxbProcessDatabasesToRestore.Text);
            if (!ValidateCheckoutBranch() || !ValidateCreateBranch() || !ValidateUri() || (CbxIsRestoreDatabases.Checked && !ValidateRestoreDatabases()))
            {
                return;
            }
            PbxDsbLoadingAction.Visible = true;
            if (CblSolutions.Items.Count > 0)
            {
                TargetSolutionName = CblSolutions.SelectedItem.ToString();
            }
            TbcMain.TabPages[2].Enabled = false;
            IsExitVisualStudio = CbxIsExitVisualStudio.Checked;
            IsStashCahnges = CbxIsStashChanges.Checked;
            IsCheckoutBranch = CbxIsCheckoutBranch.Checked;
            IsGitClean = CbxIsGitClean.Checked;
            IsStashPop = CbxIsStashPop.Checked;
            IsPreBuildSolution = CbxIsPreBuild.Checked;
            IsRestoreDatabase = CbxIsRestoreDatabases.Checked;
            IsNugetRestore = CbxIsNugetRestore.Checked;
            IsBuildSolution = CbxIsBuildSolution.Checked;
            IsPostBuildSolution = CbxIsPostBuild.Checked;
            IsRunVisualStudio = CbxIsRunVisualStudio.Checked;
            IsRunUri = CbxLaunchUri.Checked;
            IsCreateNewBranch = CbxIsCreateNewBranch.Checked;
            ResetCheckboxBackColor();
            IsProcessAborted = false;
            BtnRunProcess.Enabled = false;
            BtnStopProcess.Enabled = true;
            NewBranchName = TxbNewBranchName.Text;
            Uris = TxbUri.Text;
            _workerThread = new Thread(RunProcess);
            _workerThread.Start();
        }

        void RbtIsRemoteOrLocalTargetBranchCheckedChanged(object sender, EventArgs e)
        {
            ActBranches.Enabled = true;
            if (RbtIsLocalTargetBranch.Checked)
            {
                ActBranches.Values = GitHelper.GetLocalsBranches().Select(b => b.Name).ToArray();
            }
            if (RbtIsRemoteTargetBranch.Checked)
            {
                ActBranches.Values = GitHelper.GetRemotesBranches().Select(b => b.Name).ToArray();
            }
        }

        void BtnStopProcessClick(object sender, EventArgs e)
        {
            ExitProcess();
        }

        void CbxIsCreateNewBranchCheckedChanged(object sender, EventArgs e)
        {
            if (CbxIsCreateNewBranch.Checked)
            {
                TxbNewBranchName.Enabled = true;
                if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.NewBranchPrefix[_settings]))
                {
                    TxbNewBranchName.Text = TalentsoftToolsPlugin.NewBranchPrefix[_settings];
                }
            }
            else
            {
                TxbNewBranchName.Enabled = false;
                TxbNewBranchName.Text = string.Empty;
            }
        }

        void CbxIsStashChanges_CheckedChanged(object sender, EventArgs e)
        {
            if (CanStashPop.HasValue && !CanStashPop.Value)
            {
                if (!CbxIsStashChanges.Checked)
                {
                    LastStashPopValue = CbxIsStashPop.Checked;
                    CbxIsStashPop.Checked = false;
                    CbxIsStashPop.Enabled = false;
                }
                else if (CbxIsStashChanges.Checked)
                {
                    CbxIsStashPop.Checked = LastStashPopValue;
                    CbxIsStashPop.Enabled = true;
                }
            }
        }

        private void CbxIsRestoreDatabasesCheckedChanged(object sender, EventArgs e)
        {
            TxbProcessDatabasesToRestore.Enabled = CbxIsRestoreDatabases.Checked;
        }

        #endregion
    }
}
