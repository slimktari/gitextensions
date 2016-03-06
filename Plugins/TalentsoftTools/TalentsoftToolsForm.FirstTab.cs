using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitCommands;
using GitUIPluginInterfaces;

namespace TalentsoftTools
{
    public partial class TalentsoftToolsForm
    {
        #region Fields & Properties

        bool IsExitVisualStudio { get; set; }
        bool IsStashCahnges { get; set; }
        bool IsCheckoutBranch { get; set; }
        bool IsGitClean { get; set; }
        bool IsStashPop { get; set; }
        bool IsBuildSolution { get; set; }
        bool IsRunVisualStudio { get; set; }
        bool IsRunUri { get; set; }
        bool IsCreateNewBranch { get; set; }
        bool? CanStashPop { get; set; }
        bool LastStashPopValue { get; set; }
        string Uris { get; set; }
        string NewBranchName { get; set; }
        string TargetSolutionName { get; set; }
        GitRef TargetBranch { get; set; }
        bool IsProcessAborted { get; set; }
        private Task Task { get; set; }
        private CancellationTokenSource TokenTask { get; set; }

        #endregion

        #region Methods

        void InitProcessTab()
        {
            _gitUiCommands.GitModule.RunGitCmd("git fetch -n --all");
            IsProcessAborted = true;
            CblSolutions.DataSource = Helper.GetSolutionsFile(_gitUiCommands.GitModule.WorkingDir);
            CheckDefaultSolutionFileFromSettings();

            SetMsBuildPath();

            LoadDefaultStepsValuesFromSettings();

            ResetControls();
        }

        void ResetControls()
        {
            BtnStopProcess.Enabled = false;
            LblActualBranchName.Text = _gitUiCommands.GitModule.GetSelectedBranch();
            LblActualRepository.Text = _gitUiCommands.GitModule.WorkingDir;
            TxbNewBranchName.Enabled = false;
        }

        void SetMsBuildPath()
        {
            TalentsoftToolsPlugin.PathToMsBuildFramework[_settings] = string.Empty;
            if (string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.PathToMsBuildFramework[_settings]))
            {
                List<string> pathsToMsBuild = new List<string>
                                                  {
                    "C:/Windows/Microsoft.Net/Framework/v2.0.50727/MsBuild.exe",
                    "C:/Windows/Microsoft.Net/Framework/v3.5/MsBuild.exe",
                    "C:/Windows/Microsoft.NET/Framework/v4.0.30319/MsBuild.exe",
                    @"C:\Program Files (x86)\MSBuild\12.0\Bin\MsBuild.exe",
                    @"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe"
                                                  };
                foreach (var pathToMsBuild in pathsToMsBuild)
                {
                    if (File.Exists(pathToMsBuild))
                    {
                        TalentsoftToolsPlugin.PathToMsBuildFramework[_settings] = pathToMsBuild;
                    }
                }
            }
        }

        void CheckDefaultSolutionFileFromSettings()
        {
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
            }
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
        }

        void LoadDefaultStepsValuesFromSettings()
        {
            if (TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings].HasValue)
            {
                CbxIsExitVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultExitVisualStudio[_settings].Value;
            }
            bool canStash = Helper.GetDiff(_gitUiCommands).Any();
            if (!canStash)
            {
                CbxIsStashChanges.Checked = false;
                CbxIsStashChanges.Enabled = false;
            }
            else if (TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].HasValue)
            {
                CbxIsStashChanges.Checked = TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].HasValue)
            {
                CbxIsCheckoutBranch.Checked = TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultGitClean[_settings].HasValue)
            {
                CbxIsGitClean.Checked = TalentsoftToolsPlugin.IsDefaultGitClean[_settings].Value;
            }
            CanStashPop = Helper.GetStashs(_gitUiCommands).Any();
            if (!CanStashPop.Value && !CbxIsStashChanges.Checked)
            {
                CbxIsStashPop.Checked = false;
                CbxIsStashPop.Enabled = false;
            }
            else if (TalentsoftToolsPlugin.IsDefaultStashPop[_settings].HasValue)
            {
                CbxIsStashPop.Checked = TalentsoftToolsPlugin.IsDefaultStashPop[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].HasValue)
            {
                CbxIsBuildSolution.Checked = TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultRunVisualStudio[_settings].HasValue)
            {
                CbxIsRunVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultRunVisualStudio[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultRunUri[_settings].HasValue)
            {
                CbxLaunchUri.Checked = TalentsoftToolsPlugin.IsDefaultRunUri[_settings].Value;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
            {
                TxbUri.Text = TalentsoftToolsPlugin.LocalUriWebApplication[_settings];
            }
        }
        void ExitProcess()
        {
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
                TokenTask.Cancel();
                TokenTask.Dispose();
                IsProcessAborted = true;
                BtnRunProcess.Enabled = true;
                BtnStopProcess.Enabled = false;
                PbxLoading.Visible = false;
            }
        }

        void RunProcess()
        {
            DateTime startDateTime = DateTime.Now;
            Invoke((MethodInvoker)(() =>
            {
                TbxLogInfo.AppendText(string.Format("Start at: {0}\r\nCurrent branch: {1}",startDateTime, _gitUiCommands.GitModule.GetSelectedBranch()));
                if (CbxIsCheckoutBranch.Checked && TargetBranch != null)
                {
                    TbxLogInfo.AppendText(string.Format("\r\nTarget branch: {0}\r\nTarget solution: {1}\r\n",TargetBranch.Name,TargetSolutionName));
                }
                if (CbxIsBuildSolution.Checked || CbxIsGitClean.Checked)
                {
                    TbxLogInfo.AppendText(string.Format("\r\nTarget solution: {0}\r\n",TargetSolutionName));
                }
            }));

            if (IsExitVisualStudio)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsExitVisualStudio.BackColor = Color.LimeGreen;
                    TbxLogInfo.AppendText("\r\nExiting Visual Studio...");
                }));
                bool isExited = Helper.ExitVisualStudio(TargetSolutionName);
                if (!isExited)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsExitVisualStudio.BackColor = Color.Red;
                        TbxLogInfo.AppendText("\r\nError when exit Visual Studio.");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsStashCahnges && !IsProcessAborted)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsStashChanges.BackColor = Color.LimeGreen;
                    TbxLogInfo.AppendText("\r\nStashing changes... 'stash --include-untracked'.");
                }));

                CmdResult gitStashResult = _gitUiCommands.GitModule.RunGitCmdResult("stash --include-untracked");
                if (gitStashResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashChanges.BackColor = Color.Red;
                        TbxLogInfo.AppendText(string.Format("\r\nError when stashing changes. {0}.",gitStashResult.StdError));
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsCheckoutBranch && !IsProcessAborted)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsCheckoutBranch.BackColor = Color.LimeGreen;
                    TbxLogInfo.AppendText(string.Format("\r\nCheckout branch {0}...",TargetBranch.Name));
                    TbxLogInfo.AppendText(string.Format(" 'checkout -B {0} {1}'.",TargetBranch.LocalName,TargetBranch.Name));
                }));
                CmdResult gitCheckoutResult = _gitUiCommands.GitModule.RunGitCmdResult(string.Format("checkout -B {0} {1}",TargetBranch.LocalName,TargetBranch.Name));
                if (gitCheckoutResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsCheckoutBranch.BackColor = Color.Red;
                        TbxLogInfo.AppendText(string.Format("\r\nError when checkout branch. {0}.",gitCheckoutResult.StdError));
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }

                if (!IsProcessAborted && IsCreateNewBranch && !string.IsNullOrWhiteSpace(NewBranchName))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText(string.Format("\r\nCreating new local branch {0}... 'checkout -b {1}'.",NewBranchName,NewBranchName));
                    }));
                    CmdResult gitCreateNewBranchResult = _gitUiCommands.GitModule.RunGitCmdResult(string.Format("checkout -b {0}",NewBranchName));
                    if (gitCreateNewBranchResult.ExitCode != 0)
                    {
                        CbxIsCheckoutBranch.Invoke((MethodInvoker)(() =>
                        {
                            CbxIsCheckoutBranch.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when Creating new branch {0}. {1}.",NewBranchName,gitCheckoutResult.StdError));
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                        IsProcessAborted = true;
                    }
                }
            }
            if (IsGitClean && !IsProcessAborted)
            {
                Invoke((MethodInvoker)(() => { CbxIsGitClean.BackColor = Color.LimeGreen; }));
                string excludeCommand = string.Empty;
                if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]))
                {
                    excludeCommand = string.Format(" -e=\"{0}\"",TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]);
                }
                Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText(string.Format("\r\nCleaning solution: {0}... \"clean -d -x -f{1}\".",TargetSolutionName,excludeCommand));
                }));

                CmdResult gitCleanResult = _gitUiCommands.GitModule.RunGitCmdResult(string.Format("clean -d -x -f{0}",excludeCommand));
                if (gitCleanResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsGitClean.BackColor = Color.Red;
                        TbxLogInfo.AppendText(string.Format("\r\nError when cleaning solution: {0}. {1}.",TargetSolutionName,gitCleanResult.StdError));
                    }));
                }
            }
            if (IsStashPop && !IsProcessAborted)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsStashPop.BackColor = Color.LimeGreen;
                    TbxLogInfo.AppendText("\r\nPopping stash... \"stash pop");
                }));
                CmdResult gitStashPopResult = _gitUiCommands.GitModule.RunGitCmdResult("stash pop");
                if (gitStashPopResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashPop.BackColor = Color.Red;
                        TbxLogInfo.AppendText(string.Format("\r\nError when popping stash. {0}",gitStashPopResult.StdError));
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsBuildSolution && !IsProcessAborted)
            {
                string workingDirectory = _gitUiCommands.GitModule.WorkingDir;
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsBuildSolution.BackColor = Color.LimeGreen;
                    TbxLogInfo.AppendText(string.Format("\r\nRestoring Nugets in solution: {0}... 'nuget restore {1}'.", workingDirectory + TargetSolutionName, TargetSolutionName));
                }));
                bool result = Helper.RunCommandLine(new List<string> { string.Format("nuget restore {0}", workingDirectory + TargetSolutionName) });
                if (!result)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsBuildSolution.BackColor = Color.Red;
                        TbxLogInfo.AppendText(string.Format("\r\nError when restoring nugets in solution: {0}.", workingDirectory + TargetSolutionName));
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText(string.Format("\r\nBuilding solution: {0}... '{1} /t:Build /p:BuildInParallel=true /p:Configuration=Debug /maxcpucount {2}'.",TargetSolutionName, TalentsoftToolsPlugin.PathToMsBuildFramework[_settings], workingDirectory + TargetSolutionName));
                    }));
                    result = Helper.Build(workingDirectory + TargetSolutionName, TalentsoftToolsPlugin.PathToMsBuildFramework[_settings]);
                    if (!result)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsBuildSolution.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when building solution: {0}.",TargetSolutionName));
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                        IsProcessAborted = true;
                    }
                }
            }
            if (IsRunVisualStudio && !IsProcessAborted)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsRunVisualStudio.BackColor = Color.LimeGreen;
                    TbxLogInfo.AppendText(string.Format("\r\nRunning Visual Studio with: {0}...",TargetSolutionName));
                }));
                if (!Helper.LaunchVisualStudio(TargetSolutionName))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsRunVisualStudio.BackColor = Color.Red;
                        TbxLogInfo.AppendText(string.Format("\r\nError when running Visual Studio with: {0}.",TargetSolutionName));
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsRunUri && !IsProcessAborted)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxLaunchUri.BackColor = Color.LimeGreen;
                }));
                foreach (var uri in Uris.Split(';'))
                {
                    if (!string.IsNullOrWhiteSpace(uri))
                    {
                        Invoke((MethodInvoker) (() =>
                        {
                            TbxLogInfo.AppendText(string.Format("\r\nLaunching web URI: {0}...", Uris));
                        }));
                        if (!Helper.LaunchWebUri(uri))
                        {
                            Invoke((MethodInvoker) (() =>
                            {
                                CbxLaunchUri.BackColor = Color.Red;
                                TbxLogInfo.AppendText(string.Format("\r\nError when launching web URI: {0}.", uri));
                            }));
                        }
                    }
                }
            }
            DateTime endateDateTime = DateTime.Now;
            Invoke((MethodInvoker)(() =>
            {
                TbxLogInfo.AppendText(string.Format("\r\nEnd at: {0}.",endateDateTime));
                TbxLogInfo.AppendText(string.Format("\r\nElapsed time: {0}.", endateDateTime - startDateTime));
                _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
                LblActualBranchName.Text = _gitUiCommands.GitModule.GetSelectedBranch();
                LblActualRepository.Text = _gitUiCommands.GitModule.WorkingDir;
                ExitProcess();
            }));
        }

        #endregion

        #region Events

        void RbtIsRemoteOrLocalTargetBranchCheckedChanged(object sender, EventArgs e)
        {
            if (RbtIsLocalTargetBranch.Checked)
            {
                ActBranches.Values = Helper.GetLocalsBranches(_gitUiCommands).Select(b => b.Name).ToArray();
            }
            if (RbtIsRemoteTargetBranch.Checked)
            {
                ActBranches.Values = Helper.GetRemotesBranches(_gitUiCommands).Select(b => b.Name).ToArray();
            }
        }

        private void BtnRunProcessClick(object sender, EventArgs e)
        {
            if (!ValidateCheckoutBranch() || !ValidateCreateBranch() || !ValidateUri())
            {
                return;
            }
            PbxLoading.Visible = true;
            TokenTask = new CancellationTokenSource();
            if (CblSolutions.Items.Count > 0)
            {
                TargetSolutionName = CblSolutions.SelectedItem.ToString();
            }
            IsExitVisualStudio = CbxIsExitVisualStudio.Checked;
            IsStashCahnges = CbxIsStashChanges.Checked;
            IsCheckoutBranch = CbxIsCheckoutBranch.Checked;
            IsGitClean = CbxIsGitClean.Checked;
            IsStashPop = CbxIsStashPop.Checked;
            IsBuildSolution = CbxIsBuildSolution.Checked;
            IsRunVisualStudio = CbxIsRunVisualStudio.Checked;
            IsRunUri = CbxLaunchUri.Checked;
            IsCreateNewBranch = CbxIsCreateNewBranch.Checked;
            ResetCheckboxBackColor();
            IsProcessAborted = false;
            BtnRunProcess.Enabled = false;
            BtnStopProcess.Enabled = true;
            NewBranchName = TxbNewBranchName.Text;
            Uris = TxbUri.Text;
            Task = Task.Factory.StartNew(RunProcess, TokenTask.Token);
        }

        bool ValidateUri()
        {
            string message = string.Empty;
            if (CbxLaunchUri.Checked && (string.IsNullOrWhiteSpace(TxbUri.Text) || string.IsNullOrWhiteSpace(TxbUri.Text.Remove(';'))))
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
                    LocalBranches = Helper.GetLocalsBranches(_gitUiCommands);
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
                        RemoteBranches = Helper.GetRemotesBranches(_gitUiCommands);
                        TargetBranch = RemoteBranches.FirstOrDefault(b => b.Name.ToUpper() == ActBranches.Text.ToUpper());
                    }
                    else
                    {
                        LocalBranches = Helper.GetLocalsBranches(_gitUiCommands);
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

        #endregion
    }
}
