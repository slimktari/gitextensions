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
        string Uri { get; set; }
        string NewBranchName { get; set; }
        string TargetSolutionName { get; set; } = string.Empty;
        GitRef TargetBranch { get; set; }
        bool IsProcessAborted { get; set; } = true;
        private Task Task { get; set; }
        private CancellationTokenSource TokenTask { get; set; }

        #endregion

        #region Methods

        void InitProcessTab()
        {
            CblSolutions.DataSource = Helper.GetSolutionsFile(_gitUiCommands.GitModule.WorkingDir);
            CheckDefaultSloutionFileFromSettings();

            SetMsBuildPath();

            LoadDefaultStepsValuesFromSettings();

            ResetControls();
        }

        void ResetControls()
        {
            BtnStopProcess.Enabled = false;
            LblActualBranchName.Text = _gitUiCommands.GitModule.GetSelectedBranch();
            LblActualRepository.Text = _gitUiCommands.GitModule.WorkingDir;
            CbxIsCheckoutBranch.Checked = false;
            CbxIsCheckoutBranch.Enabled = false;
            CbxIsStashChanges.Checked = false;
            CbxIsStashChanges.Enabled = false;
            TxbNewBranchName.Enabled = false;
            CbxIsCreateNewBranch.Enabled = false;

            if (!Helper.GetStashs(_gitUiCommands).Any())
            {
                CbxIsStashPop.Checked = false;
                CbxIsStashPop.Enabled = false;
            }
        }

        void SetMsBuildPath()
        {
            if (string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.PathToMsBuild[_settings]))
            {
                List<string> pathsToMsBuild = new List<string>
                                                  {
                    "C:/Windows/Microsoft.Net/Framework/v2.0.50727/MsBuild.exe",
                    "C:/Windows/Microsoft.Net/Framework/v3.5/MsBuild.exe",
                    "C:/Windows/Microsoft.NET/Framework/v4.0.30319/MsBuild.exe"
                                                  };
                foreach (var pathToMsBuild in pathsToMsBuild)
                {
                    if (File.Exists(pathToMsBuild))
                    {
                        TalentsoftToolsPlugin.PathToMsBuild[_settings] = pathToMsBuild;
                    }
                }
            }
        }

        void CheckDefaultSloutionFileFromSettings()
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
            if (TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].HasValue)
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
            if (TalentsoftToolsPlugin.IsDefaultStashPop[_settings].HasValue)
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
                TbxLogInfo.AppendText($"Start at: {startDateTime}\r\nCurrent branch: {_gitUiCommands.GitModule.GetSelectedBranch()}");
                if (CbxIsCheckoutBranch.Checked && TargetBranch != null)
                {
                    TbxLogInfo.AppendText($"\r\nTarget branch: {TargetBranch.Name}\r\nTarget solution: {TargetSolutionName}\r\n");
                }
                if (CbxIsBuildSolution.Checked || CbxIsGitClean.Checked)
                {
                    TbxLogInfo.AppendText($"\r\nTarget solution: {TargetSolutionName}\r\n");
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
                        TbxLogInfo.AppendText($"\r\nError when stashing changes. {gitStashResult.StdError}.");
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
                    TbxLogInfo.AppendText($"\r\nCheckout branch {CblBranches.SelectedItem}...");
                    TbxLogInfo.AppendText($" 'checkout -B {TargetBranch.LocalName} {TargetBranch.Name}'.");
                }));
                CmdResult gitCheckoutResult = _gitUiCommands.GitModule.RunGitCmdResult($"checkout -B {TargetBranch.LocalName} {TargetBranch.Name}");
                if (gitCheckoutResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsCheckoutBranch.BackColor = Color.Red;
                        TbxLogInfo.AppendText($"\r\nError when checkout branch. {gitCheckoutResult.StdError}.");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }

                if (!IsProcessAborted && IsCreateNewBranch && !string.IsNullOrWhiteSpace(NewBranchName))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nCreating new local branch {NewBranchName}... 'checkout -b {NewBranchName}'.");
                    }));
                    CmdResult gitCreateNewBranchResult = _gitUiCommands.GitModule.RunGitCmdResult($"checkout -b {NewBranchName}");
                    if (gitCreateNewBranchResult.ExitCode != 0)
                    {
                        CbxIsCheckoutBranch.Invoke((MethodInvoker)(() =>
                        {
                            CbxIsCheckoutBranch.BackColor = Color.Red;
                            TbxLogInfo.AppendText($"\r\nError when Creating new branch {NewBranchName}. {gitCheckoutResult.StdError}.");
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
                    excludeCommand = $" -e=\"{TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]}\"";
                }
                Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($"\r\nCleaning solution: {TargetSolutionName}... \"clean -d -x -f{excludeCommand}\".");
                }));

                CmdResult gitCleanResult = _gitUiCommands.GitModule.RunGitCmdResult($"clean -d -x -f{excludeCommand}");
                if (gitCleanResult.ExitCode != 0)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsGitClean.BackColor = Color.Red;
                        TbxLogInfo.AppendText($"\r\nError when cleaning solution: {TargetSolutionName}. {gitCleanResult.StdError}.");
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
                        TbxLogInfo.AppendText($"\r\nError when popping stash. {gitStashPopResult.StdError}");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsBuildSolution && !IsProcessAborted)
            {
                Invoke((MethodInvoker)(() =>
                {
                    CbxIsBuildSolution.BackColor = Color.LimeGreen;
                    TbxLogInfo.AppendText($"\r\nRestoring Nugets in solution: {TargetSolutionName}... 'nuget restore {TargetSolutionName}'.");
                }));
                bool result = Helper.RunCommandLine(new List<string> { $"nuget restore {TargetSolutionName}" });
                if (!result)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsBuildSolution.BackColor = Color.Red;
                        TbxLogInfo.AppendText($"\r\nError when restoring nugets in solution: {TargetSolutionName}.");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
                else
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nBuilding solution: {TargetSolutionName}... '{TalentsoftToolsPlugin.PathToMsBuild[_settings]} /t:Build /p:BuildInParallel=true /p:Configuration=Debug /maxcpucount {TargetSolutionName}'.");
                    }));
                    result = Helper.Build(TargetSolutionName, TalentsoftToolsPlugin.PathToMsBuild[_settings]);
                    if (!result)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsBuildSolution.BackColor = Color.Red;
                            TbxLogInfo.AppendText($"\r\nError when building solution: {TargetSolutionName}.");
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
                    TbxLogInfo.AppendText($"\r\nRunning Visual Studio with: {TargetSolutionName}...");
                }));
                if (!Helper.LaunchVisualStudio(TargetSolutionName))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsRunVisualStudio.BackColor = Color.Red;
                        TbxLogInfo.AppendText($"\r\nError when running Visual Studio with: {TargetSolutionName}.");
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
                    TbxLogInfo.AppendText($"\r\nLaunching web URI: {Uri}...");
                }));

                if (!Helper.LaunchWebUri(Uri))
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxLaunchUri.BackColor = Color.Red;
                        TbxLogInfo.AppendText($"\r\nError when launching web URI: {Uri}.");
                    }));
                }
            }
            DateTime endateDateTime = DateTime.Now;
            Invoke((MethodInvoker)(() =>
            {
                TbxLogInfo.AppendText($"\r\nEnd at: {endateDateTime}.");
                TbxLogInfo.AppendText($"\r\nElapsed time: {endateDateTime - startDateTime}.");
                _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
                LblActualBranchName.Text = _gitUiCommands.GitModule.GetSelectedBranch();
                LblActualRepository.Text = _gitUiCommands.GitModule.WorkingDir;
                ExitProcess();
            }));
        }

        #endregion

        #region Events

        private void CblBranchesKeyPress(object sender, KeyPressEventArgs e)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (CblBranches.SelectionStart <= 1)
                {
                    CblBranches.Text = "";
                    return;
                }

                if (CblBranches.SelectionLength == 0)
                    strFindStr = CblBranches.Text.Substring(0, CblBranches.Text.Length - 1);
                else
                    strFindStr = CblBranches.Text.Substring(0, CblBranches.SelectionStart - 1);
            }
            else
            {
                if (CblBranches.SelectionLength == 0)
                    strFindStr = CblBranches.Text + e.KeyChar;
                else
                    strFindStr = CblBranches.Text.Substring(0, CblBranches.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = CblBranches.FindString(strFindStr);

            if (intIdx != -1)
            {
                CblBranches.SelectedText = string.Empty;
                CblBranches.SelectedIndex = intIdx;
                CblBranches.SelectionStart = strFindStr.Length;
                CblBranches.SelectionLength = CblBranches.Text.Length;
            }
            e.Handled = true;
        }

        void RbtIsRemoteOrLocalTargetBranchCheckedChanged(object sender, EventArgs e)
        {
            if (RbtIsLocalTargetBranch.Checked)
            {
                CblBranches.DataSource = Helper.GetLocalsBranches(_gitUiCommands).Select(b => b.Name).ToList();
            }
            if (RbtIsRemoteTargetBranch.Checked)
            {
                CblBranches.DataSource = Helper.GetRemotesBranches(_gitUiCommands).Select(b => b.Name).ToList();
            }

            if (CblBranches.Items.Count > 0)
            {
                CbxIsCreateNewBranch.Enabled = true;
                if (!CbxIsCheckoutBranch.Enabled)
                {
                    CbxIsCheckoutBranch.Enabled = true;
                    if (TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].HasValue)
                    {
                        CbxIsCheckoutBranch.Checked = TalentsoftToolsPlugin.IsDefaultCheckoutBranch[_settings].Value;
                    }
                }
                if (!CbxIsStashChanges.Enabled)
                {
                    CbxIsStashChanges.Enabled = true;
                    if (TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].HasValue)
                    {
                        CbxIsStashChanges.Checked = TalentsoftToolsPlugin.IsDefaultStashChanges[_settings].Value;
                    }
                }
            }
            else
            {
                CbxIsCheckoutBranch.Checked = false;
                CbxIsCheckoutBranch.Enabled = false;
                CbxIsStashChanges.Checked = false;
                CbxIsStashChanges.Enabled = false;
                CbxIsCreateNewBranch.Enabled = false;
                CbxIsCreateNewBranch.Checked = false;
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
            Uri = TxbUri.Text;
            Task = Task.Factory.StartNew(RunProcess, TokenTask.Token);
        }

        bool ValidateUri()
        {
            string message = string.Empty;
            if (CbxLaunchUri.Checked && string.IsNullOrWhiteSpace(TxbUri.Text))
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
                if (string.IsNullOrWhiteSpace(CblBranches.Text))
                {
                    message = "There is no selected branch !";
                }
                if (RbtIsRemoteTargetBranch.Checked)
                {
                    RemoteBranches = Helper.GetRemotesBranches(_gitUiCommands);
                    TargetBranch = RemoteBranches.FirstOrDefault(b => b.Name.ToUpper() == CblBranches.Text.ToUpper());
                }
                else
                {
                    LocalBranches = Helper.GetLocalsBranches(_gitUiCommands);
                    TargetBranch = LocalBranches.FirstOrDefault(b => b.Name.ToUpper() == CblBranches.Text.ToUpper());
                }
                if (TargetBranch == null)
                {
                    message = "The selected branch does not exist !";
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

        void CblIsCheckoutBranchCheckedChanged(object sender, EventArgs e)
        {
            if (CblBranches.Items.Count == 0)
            {
                CbxIsCheckoutBranch.Checked = false;
            }
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

        #endregion
    }
}
