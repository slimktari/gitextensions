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
using TalentsoftTools.Helpers;

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
        private Task Task { get; set; }
        private CancellationTokenSource TokenTask { get; set; }
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

        void LoadDefaultStepsValuesFromSettings()
        {
            if (CblSolutions.Items.Count <= 0)
            {
                CbxIsExitVisualStudio.Enabled = false;
                CbxIsExitVisualStudio.Checked = false;
                CbxIsRunVisualStudio.Enabled = false;
                CbxIsRunVisualStudio.Checked = false;
                CbxIsBuildSolution.Checked = false;
                CbxIsBuildSolution.Enabled = false;
                CblDsbSolutions.Enabled = false;
                BtnDsbBuildSolution.Enabled = false;
                BtnDsbExitSolution.Enabled = false;
                BtnDsbNugetRestore.Enabled = false;
                BtnDsbRebuildSolution.Enabled = false;
                BtnDsbStartSolution.Enabled = false;
            }
            else if (TalentsoftToolsPlugin.IsDefaultExitAndStartVisualStudio[_settings].HasValue)
            {
                CbxIsExitVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultExitAndStartVisualStudio[_settings].Value;
                CbxIsRunVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultExitAndStartVisualStudio[_settings].Value;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.DatabasesToRestore[_settings]) &&
                !string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.DatabaseConnectionParams[_settings]) &&
                TalentsoftToolsPlugin.IsDefaultResetDatabases[_settings].HasValue)
            {
                CbxIsRestoreDatabases.Checked = TalentsoftToolsPlugin.IsDefaultResetDatabases[_settings].Value;
                TxbDatabases.Text = TalentsoftToolsPlugin.DatabasesToRestore[_settings];
                TxbDsbDatabases.Text = TalentsoftToolsPlugin.DatabasesToRestore[_settings];
            }
            else
            {
                CbxIsRestoreDatabases.Checked = false;
                CbxIsRestoreDatabases.Enabled = false;
                TxbDatabases.Enabled = false;
                TxbDsbDatabases.Enabled = false;
                BtnDsbRestoreDatabases.Enabled = false;
            }

            bool canStash = GitHelper.IfChangedFiles();
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
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]))
            {
                TxbDsbGitClean.Text = TalentsoftToolsPlugin.ExcludePatternGitClean[_settings];
            }
            CanStashPop = GitHelper.GetStashs().Any();
            if (!CanStashPop.Value && !CbxIsStashChanges.Checked)
            {
                CbxIsStashPop.Checked = false;
                CbxIsStashPop.Enabled = false;
            }
            else if (TalentsoftToolsPlugin.IsDefaultStashPop[_settings].HasValue)
            {
                CbxIsStashPop.Checked = TalentsoftToolsPlugin.IsDefaultStashPop[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultNugetRestore[_settings].HasValue)
            {
                CbxIsNugetRestore.Checked = TalentsoftToolsPlugin.IsDefaultNugetRestore[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].HasValue)
            {
                CbxIsBuildSolution.Checked = TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultRunUri[_settings].HasValue)
            {
                CbxLaunchUri.Checked = TalentsoftToolsPlugin.IsDefaultRunUri[_settings].Value;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
            {
                TxbUri.Text = TalentsoftToolsPlugin.LocalUriWebApplication[_settings];
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.PreBuildBatch[_settings]))
            {
                PreBuildFiles = new List<string>();
                string[] files = TalentsoftToolsPlugin.PreBuildBatch[_settings].Split(';');
                bool isError = false;
                foreach (var file in files)
                {
                    if (!string.IsNullOrWhiteSpace(file) && !File.Exists(file))
                    {
                        isError = true;
                    }
                    else
                    {
                        PreBuildFiles.Add(file);
                    }
                }
                if (!PreBuildFiles.Any() || isError)
                {
                    CbxIsPreBuild.Checked = false;
                    CbxIsPreBuild.Enabled = false;
                    BtnDsbRunScriptPrebuild.Enabled = false;
                }
            }
            else
            {
                CbxIsPreBuild.Checked = false;
                CbxIsPreBuild.Enabled = false;
                BtnDsbRunScriptPrebuild.Enabled = false;
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.PostBuildBatch[_settings]))
            {
                PostBuildFiles = new List<string>();
                string[] files = TalentsoftToolsPlugin.PostBuildBatch[_settings].Split(';');
                bool isError = false;
                foreach (var file in files)
                {
                    if (!File.Exists(file))
                    {
                        isError = true;
                    }
                    else
                    {
                        PostBuildFiles.Add(file);
                    }
                }
                if (!PostBuildFiles.Any() || isError)
                {
                    CbxIsPostBuild.Checked = false;
                    CbxIsPostBuild.Enabled = false;
                    BtnDsbRunScriptPostbuild.Enabled = false;
                }
            }
            else
            {
                CbxIsPostBuild.Checked = false;
                CbxIsPostBuild.Enabled = false;
                BtnDsbRunScriptPostbuild.Enabled = false;
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
                PbxLoadingProcess.Visible = false;
                TbcMain.TabPages[2].Enabled = true;
                LoadLocalBranches();
                UpdateNotifications();
            }
        }

        void RunProcess()
        {
            string solutionFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == TargetSolutionName).Value;
            DateTime startDateTime = DateTime.Now;
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
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
            }

            if (IsExitVisualStudio)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsExitVisualStudio.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText("\r\nExiting Visual Studio...");
                    }));
                }
                bool isExited = GenericHelper.ExitVisualStudio(TargetSolutionName);
                if (!isExited)
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsExitVisualStudio.BackColor = Color.Red;
                            TbxLogInfo.AppendText("\r\nError when exit Visual Studio.");
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                    IsProcessAborted = true;
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsExitVisualStudio.BackColor = Color.LimeGreen;
                        }));
                    }
                }
            }
            if (IsStashCahnges && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashChanges.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText("\r\nStashing changes... 'stash --include-untracked'.");
                    }));
                }

                CmdResult gitStashResult = GitHelper.StashChanges();
                if (gitStashResult.ExitCode != 0)
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsStashChanges.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when stashing changes. {0}.",
                                gitStashResult.StdError));
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                    IsProcessAborted = true;
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsStashChanges.BackColor = Color.LimeGreen;
                        }));
                    }
                }
            }
            if (IsCheckoutBranch && !IsProcessAborted)
            {
                bool isLocal = false;
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsCheckoutBranch.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText(string.Format("\r\nCheckout branch {0}...", TargetBranch.Name));
                        TbxLogInfo.AppendText(string.Format(" 'checkout -B {0} {1}'.", TargetBranch.LocalName, TargetBranch.Name));
                        isLocal = RbtIsLocalTargetBranch.Checked;
                    }));
                }
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
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsCheckoutBranch.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when checkout branch. {0}.",
                                gitCheckoutResult.StdError));
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                    IsProcessAborted = true;
                }

                if (!IsProcessAborted && IsCreateNewBranch && !string.IsNullOrWhiteSpace(NewBranchName))
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            TbxLogInfo.AppendText(
                                string.Format("\r\nCreating new local branch {0}... 'checkout -b {1}'.", NewBranchName,
                                    NewBranchName));
                        }));
                    }
                    CmdResult gitCreateNewBranchResult = GitHelper.CreateAndCheckoutBranch(NewBranchName);
                    if (gitCreateNewBranchResult.ExitCode != 0)
                    {
                        if (TokenTask != null && !TokenTask.IsCancellationRequested)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                CbxIsCheckoutBranch.BackColor = Color.Red;
                                TbxLogInfo.AppendText(string.Format("\r\nError when Creating new branch {0}. {1}.",
                                    NewBranchName, gitCheckoutResult.StdError));
                                TbxLogInfo.AppendText("\r\nProcess aborted.");
                            }));
                        }
                        IsProcessAborted = true;
                    }
                }
                if (!IsProcessAborted && TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                        {
                            CbxIsCheckoutBranch.BackColor = Color.LimeGreen;
                        }));
                }
            }
            if (IsGitClean && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() => { CbxIsGitClean.BackColor = Color.DodgerBlue; }));
                }
                string excludeCommand = string.Empty;
                if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]))
                {
                    excludeCommand = string.Format(" -e=\"{0}\"", TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]);
                }
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText(string.Format("\r\nCleaning solution: {0}... \"clean -d -x -f{1}\".",
                            TargetSolutionName, excludeCommand));
                    }));
                }

                CmdResult gitCleanResult = GitHelper.Clean(excludeCommand);
                if (gitCleanResult.ExitCode != 0)
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsGitClean.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when cleaning solution: {0}. {1}.",
                                TargetSolutionName, gitCleanResult.StdError));
                        }));
                    }
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsGitClean.BackColor = Color.LimeGreen;
                        }));
                    }
                }
            }
            if (IsStashPop && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsStashPop.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText("\r\nPopping stash... \"stash pop");
                    }));
                }
                CmdResult gitStashPopResult = GitHelper.StashPop();
                if (gitStashPopResult.ExitCode != 0)
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsStashPop.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when popping stash. {0}",
                                gitStashPopResult.StdError));
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                    IsProcessAborted = true;
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsStashPop.BackColor = Color.LimeGreen;
                        }));
                    }
                }
            }
            if (IsPreBuildSolution && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsPreBuild.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText(string.Format("\r\nRunning Pre-Build scripts:\r\n{0}",
                            string.Join("\r\n", PreBuildFiles)));
                    }));
                }
                bool result = GenericHelper.RunCommandLine(PreBuildFiles.ToList());
                if (!result)
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsPreBuild.BackColor = Color.Red;
                            TbxLogInfo.AppendText("\r\nError when running Pre-Build scripts.");
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                    IsProcessAborted = true;
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsPreBuild.BackColor = Color.LimeGreen;
                        }));
                    }
                }
            }
            if (IsNugetRestore && !IsProcessAborted)
            {

                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsNugetRestore.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText(
                            string.Format("\r\nRestoring Nugets in solution: {0}... 'nuget restore {1}'.",
                                TargetSolutionName, solutionFullPath));
                    }));
                }
                if (GenericHelper.RunCommandLine(new List<string>
                {
                    string.Format("nuget restore {0}", solutionFullPath)
                }))
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsNugetRestore.BackColor = Color.LimeGreen;
                        }));
                    }
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsNugetRestore.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when restoring nugets in solution: {0}.", solutionFullPath));
                        }));
                    }
                }
            }
            if (IsBuildSolution && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsBuildSolution.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText(
                                string.Format(
                                    "\r\nBuilding solution: {0}...",
                                    TargetSolutionName));
                    }));
                }
                string errorResult = GenericHelper.Build(solutionFullPath, Generic.GenrateSolutionArguments.Build);
                if (!string.IsNullOrWhiteSpace(errorResult))
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsBuildSolution.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when building solution: {0}.", solutionFullPath));
                            TbxLogInfo.AppendText(errorResult);
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                    IsProcessAborted = true;
                }
                else if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsBuildSolution.BackColor = Color.LimeGreen;
                    }));
                }
            }
            if (IsPostBuildSolution && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsPostBuild.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText(string.Format("\r\nRunning Post-Build scripts:\r\n{0}",
                            string.Join("\r\n", PostBuildFiles)));
                    }));
                }
                bool result = GenericHelper.RunCommandLine(PostBuildFiles.ToList());
                if (!result)
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsPostBuild.BackColor = Color.Red;
                            TbxLogInfo.AppendText("\r\nError when running Post-Build scripts.");
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsPostBuild.BackColor = Color.LimeGreen;
                        }));
                    }
                }
            }
            if (IsRunVisualStudio && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsRunVisualStudio.BackColor = Color.DodgerBlue;
                        TbxLogInfo.AppendText(string.Format("\r\nRunning Visual Studio with: {0}...", TargetSolutionName));
                    }));
                }
                if (!GenericHelper.LaunchVisualStudio(solutionFullPath))
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsRunVisualStudio.BackColor = Color.Red;
                            TbxLogInfo.AppendText(string.Format("\r\nError when running Visual Studio with: {0}.", solutionFullPath));
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                    }
                }
                else
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            CbxIsRunVisualStudio.BackColor = Color.LimeGreen;
                        }));
                    }
                }
            }
            if (!IsProcessAborted && IsRestoreDatabase && Databases.Any())
            {
                bool isRestore = false;
                bool isError = false;
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxIsRestoreDatabases.BackColor = Color.DodgerBlue;
                    }));
                }
                foreach (var database in Databases)
                {
                    if (TokenTask != null && !TokenTask.IsCancellationRequested)
                    {
                        Invoke((MethodInvoker)(() =>
                        {
                            TbxLogInfo.AppendText("\r\nRestoring database : " + database.DatabaseName);
                        }));
                    }
                    if (DatabaseHelper.RestoreDatabase(database.DatabaseName, database.BackupFilePath,
                        database.ServerName, database.UserId, database.Password, database.PathToRelocate,
                        database.PathToRelocate))
                    {
                        isRestore = true;
                        if (TokenTask != null && !TokenTask.IsCancellationRequested)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                TbxLogInfo.AppendText(string.Format("\r\nSuccess of the restoration {0} database.",
                                    database.DatabaseName));
                            }));
                        }
                    }
                    else
                    {
                        isError = true;
                        if (TokenTask != null && !TokenTask.IsCancellationRequested)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                CbxIsRestoreDatabases.BackColor = Color.Red;
                                TbxLogInfo.AppendText(string.Format("\r\nError when restoring {0} database.",
                                    database.DatabaseName));
                            }));
                        }
                    }
                    if (isRestore && isError)
                    {
                        if (TokenTask != null && !TokenTask.IsCancellationRequested)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                CbxIsRestoreDatabases.BackColor = Color.Gold;
                                TbxLogInfo.AppendText("\r\nSome database was not restored.");
                            }));
                        }
                    }
                    else if (isRestore)
                    {
                        if (TokenTask != null && !TokenTask.IsCancellationRequested)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                CbxIsRestoreDatabases.BackColor = Color.LimeGreen;
                            }));
                        }
                    }
                }
            }
            if (IsRunUri && !IsProcessAborted)
            {
                if (TokenTask != null && !TokenTask.IsCancellationRequested)
                {
                    Invoke((MethodInvoker)(() =>
                    {
                        CbxLaunchUri.BackColor = Color.DodgerBlue;
                    }));
                }
                foreach (var uri in Uris.Split(';'))
                {
                    if (!string.IsNullOrWhiteSpace(uri))
                    {
                        if (TokenTask != null && !TokenTask.IsCancellationRequested)
                        {
                            Invoke((MethodInvoker)(() =>
                            {
                                TbxLogInfo.AppendText(string.Format("\r\nLaunching web URI: {0}...", Uris));
                            }));
                        }
                        if (!GenericHelper.LaunchWebUri(uri))
                        {
                            if (TokenTask != null && !TokenTask.IsCancellationRequested)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    CbxLaunchUri.BackColor = Color.Red;
                                    TbxLogInfo.AppendText(string.Format("\r\nError when launching web URI: {0}.", uri));
                                }));
                            }
                        }
                        else
                        {
                            if (TokenTask != null && !TokenTask.IsCancellationRequested)
                            {
                                Invoke((MethodInvoker)(() =>
                                {
                                    CbxLaunchUri.BackColor = Color.LimeGreen;
                                }));
                            }
                        }
                    }
                }
            }
            DateTime endateDateTime = DateTime.Now;
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
                Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText(string.Format("\r\nEnd at: {0}.", endateDateTime));
                    TbxLogInfo.AppendText(string.Format("\r\nElapsed time: {0}.", endateDateTime - startDateTime));
                    GitHelper.NotifyGitExtensions();
                    LblActualBranchName.Text = GitHelper.GetSelectedBranch();
                    LblActualRepository.Text = GitHelper.GetWorkingDirectory();
                    ExitProcess();
                }));
            }
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
            Databases = DatabaseHelper.GetDatabasesFromPameters(TalentsoftToolsPlugin.DatabaseConnectionParams[_settings], TxbDatabases.Text);
            if (CbxIsRestoreDatabases.Checked && (string.IsNullOrWhiteSpace(TxbDatabases.Text) || Databases.Any(d => string.IsNullOrWhiteSpace(d.DatabaseName) || string.IsNullOrWhiteSpace(d.BackupFilePath))))
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
            if (!ValidateCheckoutBranch() || !ValidateCreateBranch() || !ValidateUri() || !ValidateRestoreDatabases())
            {
                return;
            }
            PbxLoadingProcess.Visible = true;
            TokenTask = new CancellationTokenSource();
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
            Task = Task.Factory.StartNew(RunProcess, TokenTask.Token).ContinueWith(t => t.Dispose());
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
            TxbDatabases.Enabled = CbxIsRestoreDatabases.Checked;
        }

        #endregion
    }
}
