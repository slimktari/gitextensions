using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GitCommands;
using GitUIPluginInterfaces;
using ResourceManager;
using System.Windows.Forms;

namespace TalentsoftTools
{
    using System.ComponentModel;
    using System.Diagnostics.Eventing.Reader;
    using System.Drawing;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class TalentsoftToolsForm : GitExtensionsFormBase
    {
        private static readonly Regex DefaultHeadPattern = new Regex("refs/remotes/[^/]+/HEAD", RegexOptions.Compiled);
        private Task Task { get; set; }

        private CancellationTokenSource TokenTask { get; set; }
        readonly GitUIBaseEventArgs _gitUiCommands;
        readonly ISettingsSource _settings;
        string TargetSolutionName { get; set; } = string.Empty;
        string TargetBranchName { get; set; } = string.Empty;
        private bool IsProcessAborted { get; set; } = true;
        List<string> TargetSolutions { get; set; }
        Dictionary<string, List<string>> Branches { get; set; }
        List<string> RemoteBranchesNames { get; set; }
        List<GitRef> RemoteBranches { get; set; }
        List<string> LocalBranchesNames { get; set; }
        List<GitRef> LocalBranches { get; set; }
        public bool IsRefreshNeeded { get; set; }

        string[] UnmergedBranches
        {
            get
            {
                CmdResult gitResult = _gitUiCommands.GitModule.RunGitCmdResult("branch --no-merged");
                if (gitResult.ExitCode == 0)
                {
                    return gitResult.StdOutput.Replace(" ", string.Empty).SplitLines();
                }
                return new string[0];
            }
        }

        public TalentsoftToolsForm(GitUIBaseEventArgs gitUiCommands, ISettingsSource settings)
        {
            InitializeComponent();
            Translate();
            _settings = settings;
            _gitUiCommands = gitUiCommands;
            Branches = new Dictionary<string, List<string>>();
            //Icon = _gitUiCommands.GitUICommands.FormIcon;
            InitProcessTab();
        }

        private void ResetCheckboxBackColor()
        {
            CbxIsBuildSolution.BackColor = Color.Transparent;
            CbxLaunchUri.BackColor = Color.Transparent;
            CbxIsCheckoutBranch.BackColor = Color.Transparent;
            CbxIsGitClean.BackColor = Color.Transparent;
            CbxIsRunVisualStudio.BackColor = Color.Transparent;
            CbxIsExitVisualStudio.BackColor = Color.Transparent;
            CbxIsStashChanges.BackColor = Color.Transparent;
        }

        private void InitLocalBranchTab()
        {
            LoadLocalsBranchsList();
            string[] unmerged = UnmergedBranches;
            var listBranches = new BindingList<BranchDto>();

            foreach (var branchName in LocalBranchesNames)
            {
                string[] info = GetBranchInfo(branchName);
                bool isMerged = !unmerged.Contains(branchName);

                var item = new BranchDto
                               {
                                   Name = branchName,
                                   IsMerged = isMerged.ToString()
                               };
                if (info.Count() == 2)
                {
                    item.LastAuthor = info[0];
                    item.LastUpdate = info[1];
                }

                listBranches.Add(item);
            }
            DgvLocalsBranches.DataSource = listBranches;

            foreach (DataGridViewRow row in DgvLocalsBranches.Rows)
            {
                if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() == "False")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Coral };
                }
                else
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.MediumSeaGreen };
                }
            }
        }

        private string[] GetBranchInfo(string branchName)
        {
            CmdResult result = _gitUiCommands.GitModule.RunGitCmdResult($"log -n 1 --pretty=format:\" % an;% cr\" {branchName}");
            if (result.ExitCode == 0 && !string.IsNullOrWhiteSpace(result.StdOutput) && result.StdOutput.Contains(";"))
            {
                return result.StdOutput.Split(';');
            }
            return new string[0];
        }

        private void InitProcessTab()
        {
            BtnStopProcess.Enabled = false;

            TargetSolutions = Helper.GetSolutionsFile(_gitUiCommands.GitModule.WorkingDir);
            CbxSolutions.DataSource = TargetSolutions;
            SetDefaultProcessValues();
            SelectDefaultSloutionFile();
            SetMsBuildPath();
            if (string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
            {
                CbxLaunchUri.Checked = false;
                CbxLaunchUri.Enabled = false;
            }
            LblActualBranchName.Text = _gitUiCommands.GitModule.GetSelectedBranch();
            LblActualRepository.Text = _gitUiCommands.GitModule.WorkingDir;
            CbxIsCheckoutBranch.Checked = false;
            CbxIsCheckoutBranch.Enabled = false;
            CbxIsStashChanges.Checked = false;
            CbxIsStashChanges.Enabled = false;
            TxbNewBranchName.Enabled = false;
            CbxIsCreateNewBranch.Enabled = false;
            //var ddss = this._gitUiCommands.GitUICommands.BrowseRepo;
            //var remotes = _gitUiCommands.GitUICommands.StartCheckoutBranch()
            //var remotess = _gitUiCommands.GitModule.GetRemotes(false);
            //var d = GetLocalBranches();
            //var sd = _gitUiCommands.GitModule.WorkingDir;
            //string[] references = _gitUiCommands.GitModule.RunGitCmd("remote").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //var dddlocal = _gitUiCommands.GitModule.RunGitCmd("show-ref --tags");
            //var dd =GetRemoteBranches();
        }

        private void SelectDefaultSloutionFile()
        {
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.DefaultSolutionFileName[_settings]) && CbxSolutions.Items.Count > 1)
            {
                foreach (var item in CbxSolutions.Items)
                {
                    if (item.ToString().EndsWith(TalentsoftToolsPlugin.DefaultSolutionFileName[_settings], StringComparison.InvariantCultureIgnoreCase))
                    {
                        CbxSolutions.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void SetDefaultProcessValues()
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
            if (TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].HasValue)
            {
                CbxIsBuildSolution.Checked = TalentsoftToolsPlugin.IsDefaultBuildSolution[_settings].Value;
            }
            if (TalentsoftToolsPlugin.IsDefaultRunVisualStudio[_settings].HasValue)
            {
                CbxIsRunVisualStudio.Checked = TalentsoftToolsPlugin.IsDefaultRunVisualStudio[_settings].Value;
            }
        }

        private List<GitRef> GetBranches()
        {
            return GetTreeRefs(_gitUiCommands.GitModule.RunGitCmd("show-ref --dereference")).ToList();
        }

        private List<GitRef> GetTreeRefs(string tree)
        {
            var itemsStrings = tree.Split('\n');

            var gitRefs = new List<GitRef>();
            var defaultHeads = new Dictionary<string, GitRef>(); // remote -> HEAD
            var remotes = _gitUiCommands.GitModule.GetRemotes(false);

            foreach (var itemsString in itemsStrings)
            {
                if (itemsString == null || itemsString.Length <= 42 || itemsString.StartsWith("error: "))
                    continue;

                var completeName = itemsString.Substring(41).Trim();
                var guid = itemsString.Substring(0, 40);
                var remoteName = GitCommandHelpers.GetRemoteName(completeName, remotes);
                var head = new GitRef(null, guid, completeName, remoteName);
                if (DefaultHeadPattern.IsMatch(completeName))
                    defaultHeads[remoteName] = head;
                else
                    gitRefs.Add(head);
            }

            // do not show default head if remote has a branch on the same commit
            GitRef defaultHead;
            foreach (var gitRef in gitRefs.Where(head => defaultHeads.TryGetValue(head.Remote, out defaultHead) && head.Guid == defaultHead.Guid))
            {
                defaultHeads.Remove(gitRef.Remote);
            }

            gitRefs.AddRange(defaultHeads.Values);

            return gitRefs;
        }

        private void RbtIsRemoteOrLocalTargetBranchCheckedChanged(object sender, EventArgs e)
        {
            if (RbtIsLocalTargetBranch.Checked)
            {
                LoadLocalsBranchsList();
                CbxBranches.DataSource = LocalBranchesNames;
            }
            if (RbtIsRemoteTargetBranch.Checked)
            {
                LoadRemotesBranchsList();
                CbxBranches.DataSource = RemoteBranchesNames;
            }

            if (CbxBranches.Items.Count > 0)
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

        private void LoadLocalsBranchsList()
        {
            LocalBranches = GetBranches().Where(h => !h.IsRemote && !h.IsTag && !h.IsOther && !h.IsBisect).ToList();
            LocalBranchesNames = LocalBranches.Select(b => b.Name).ToList();
        }

        private void LoadRemotesBranchsList()
        {
            _gitUiCommands.GitModule.RunGitCmd("git fetch --all");
            RemoteBranches = GetBranches().Where(h => h.IsRemote && !h.IsTag).ToList();
            RemoteBranchesNames = RemoteBranches.Select(b => b.Name).ToList();
        }

        private void RunProcess()
        {
            DateTime startDateTime = DateTime.Now;
            TbxLogInfo.Invoke((MethodInvoker)(() =>
            {
                TbxLogInfo.AppendText($"Start at: {startDateTime}\r\nCurrent branch: {_gitUiCommands.GitModule.GetSelectedBranch()}\r\nTarget branch: {TargetBranchName}\r\nTarget solution: {TargetSolutionName}\r\n");
            }));

            if (IsExitVisualStudio)
            {
                CbxIsExitVisualStudio.Invoke((MethodInvoker)(() => { CbxIsExitVisualStudio.BackColor = Color.LimeGreen; }));
                TbxLogInfo.Invoke(
                    (MethodInvoker)(() =>
                        {
                            TbxLogInfo.AppendText("\r\nExiting Visual Studio...");
                        }));
                bool isExited = Helper.ExitVisualStudio(TargetSolutionName);
                if (!isExited)
                {
                    CbxIsExitVisualStudio.Invoke((MethodInvoker)(() => { CbxIsExitVisualStudio.BackColor = Color.Red; }));
                    TbxLogInfo.Invoke(
                        (MethodInvoker)(() =>
                            {
                                TbxLogInfo.AppendText("\r\nError when exit Visual Studio.");
                                TbxLogInfo.AppendText("\r\nProcess aborted.");
                            }));
                    IsProcessAborted = true;
                }
            }
            if (IsStashCahnges && !IsProcessAborted)
            {
                this.CbxIsStashChanges.Invoke((MethodInvoker)(() => { CbxIsStashChanges.BackColor = Color.LimeGreen; }));
                TbxLogInfo.Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText("\r\nStashing changes... 'stash --include-untracked'");
                }));

                CmdResult gitStashResult = _gitUiCommands.GitModule.RunGitCmdResult("stash --include-untracked");
                if (gitStashResult.ExitCode != 0)
                {
                    CbxIsStashChanges.Invoke((MethodInvoker)(() => { CbxIsStashChanges.BackColor = Color.Red; }));
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nError when stashing changes. {gitStashResult.StdError}");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsCheckoutBranch && !IsProcessAborted)
            {
                CbxIsCheckoutBranch.Invoke((MethodInvoker)(() => { this.CbxIsCheckoutBranch.BackColor = Color.LimeGreen; }));
                TbxLogInfo.Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($"\r\nCheckout branch {CbxBranches.SelectedItem}...");
                }));

                string newLocalBranch = TargetBranchName;
                if (RbtIsRemoteTargetBranch.Checked)
                {
                    newLocalBranch = RemoteBranches.Single(b => b.IsRemote && b.Name == newLocalBranch).LocalName;
                }
                TbxLogInfo.Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($" 'checkout -B {newLocalBranch} {TargetBranchName}'");
                }));

                CmdResult gitCheckoutResult = _gitUiCommands.GitModule.RunGitCmdResult($"checkout -B {newLocalBranch} {TargetBranchName}");
                if (gitCheckoutResult.ExitCode != 0)
                {
                    CbxIsCheckoutBranch.Invoke((MethodInvoker)(() => { CbxIsCheckoutBranch.BackColor = Color.Red; }));
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nError when checkout branch. {gitCheckoutResult.StdError}");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }

                if (!IsProcessAborted && IsCreateNewBranch && !string.IsNullOrWhiteSpace(TxbNewBranchName.Text))
                {
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nCreating new local branch {TxbNewBranchName.Text}... 'checkout -b {TxbNewBranchName.Text}'");
                    }));
                    CmdResult gitCreateNewBranchResult = _gitUiCommands.GitModule.RunGitCmdResult($"checkout -b {TxbNewBranchName.Text}");
                    if (gitCreateNewBranchResult.ExitCode != 0)
                    {
                        CbxIsCheckoutBranch.Invoke((MethodInvoker)(() => { CbxIsCheckoutBranch.BackColor = Color.Red; }));
                        TbxLogInfo.Invoke((MethodInvoker)(() =>
                                {
                                    TbxLogInfo.AppendText($"\r\nError when Creating new branch {TxbNewBranchName.Text}. {gitCheckoutResult.StdError}");
                                    TbxLogInfo.AppendText("\r\nProcess aborted.");
                                }));
                        IsProcessAborted = true;
                    }
                }
            }
            if (IsGitClean && !IsProcessAborted)
            {
                CbxIsGitClean.Invoke((MethodInvoker)(() => { CbxIsGitClean.BackColor = Color.LimeGreen; }));
                string excludeCommand = string.Empty;
                if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]))
                {
                    excludeCommand = $" -e=\"{TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]}\"";
                }
                TbxLogInfo.Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($"\r\nCleaning solution: {TargetSolutionName}... \"clean -d -x -f{excludeCommand}\"");
                }));

                CmdResult gitCleanResult = _gitUiCommands.GitModule.RunGitCmdResult($"clean -d -x -f{excludeCommand}");
                if (gitCleanResult.ExitCode != 0)
                {
                    CbxIsGitClean.Invoke((MethodInvoker)(() => { CbxIsGitClean.BackColor = Color.Red; }));
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nError when cleaning solution: {TargetSolutionName}. {gitCleanResult.StdError}");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsBuildSolution && !IsProcessAborted)
            {
                this.CbxIsBuildSolution.Invoke((MethodInvoker)(() => { CbxIsBuildSolution.BackColor = Color.LimeGreen; }));
                TbxLogInfo.Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($"\r\nRestoring Nugets in solution: {TargetSolutionName}... 'nuget restore {TargetSolutionName}'");
                }));

                bool result = Helper.RunCommandLine(new List<string> { $"nuget restore {TargetSolutionName}" });
                if (!result)
                {
                    CbxIsBuildSolution.Invoke((MethodInvoker)(() => { CbxIsBuildSolution.BackColor = Color.Red; }));
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nError when restoring nugets in solution: {TargetSolutionName}.");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
                else
                {
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nBuilding solution: {TargetSolutionName}... '{TalentsoftToolsPlugin.PathToMsBuild[_settings]} /t:Build /p:BuildInParallel=true /p:Configuration=Debug /maxcpucount {TargetSolutionName}'");
                    }));

                    result = Helper.Build(TargetSolutionName, TalentsoftToolsPlugin.PathToMsBuild[_settings]);
                    if (!result)
                    {
                        CbxIsBuildSolution.Invoke((MethodInvoker)(() => { CbxIsBuildSolution.BackColor = Color.Red; }));
                        TbxLogInfo.Invoke((MethodInvoker)(() =>
                        {
                            TbxLogInfo.AppendText($"\r\nError when building solution: {TargetSolutionName}.");
                            TbxLogInfo.AppendText("\r\nProcess aborted.");
                        }));
                        IsProcessAborted = true;
                    }
                }
            }
            if (IsRunVisualStudio && !IsProcessAborted)
            {
                this.CbxIsRunVisualStudio.Invoke((MethodInvoker)(() => { CbxIsRunVisualStudio.BackColor = Color.LimeGreen; }));
                TbxLogInfo.Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($"\r\nRunning Visual Studio with: {TargetSolutionName}...");
                }));

                if (!Helper.LaunchVisualStudio(TargetSolutionName))
                {
                    CbxIsRunVisualStudio.Invoke((MethodInvoker)(() => { CbxIsRunVisualStudio.BackColor = Color.Red; }));
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nError when running Visual Studio with: {TargetSolutionName}.");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                    }));
                    IsProcessAborted = true;
                }
            }
            if (IsRunUri && !this.IsProcessAborted)
            {
                CbxLaunchUri.Invoke((MethodInvoker)(() => { CbxLaunchUri.BackColor = Color.LimeGreen; }));
                TbxLogInfo.Invoke((MethodInvoker)(() =>
                {
                    TbxLogInfo.AppendText($"\r\nLaunching web URI: {TalentsoftToolsPlugin.LocalUriWebApplication[_settings]}...");
                }));

                if (!Helper.LaunchWebUri(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
                {
                    CbxLaunchUri.Invoke((MethodInvoker)(() => { CbxLaunchUri.BackColor = Color.Red; }));
                    TbxLogInfo.Invoke((MethodInvoker)(() =>
                    {
                        TbxLogInfo.AppendText($"\r\nError when launching web URI: {TalentsoftToolsPlugin.LocalUriWebApplication[_settings]}.");
                    }));
                }
            }
            DateTime endateDateTime = DateTime.Now;
            TbxLogInfo.Invoke((MethodInvoker)(() =>
            {
                TbxLogInfo.AppendText($"\r\nEnd at: {endateDateTime}");
                TbxLogInfo.AppendText($"\r\nElapsed time: {endateDateTime - startDateTime}");
            }));
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            LblActualBranchName.Invoke((MethodInvoker)(() =>
            {
                LblActualBranchName.Text = _gitUiCommands.GitModule.GetSelectedBranch();
            }));
            LblActualRepository.Invoke((MethodInvoker)(() =>
            {
                LblActualRepository.Text = _gitUiCommands.GitModule.WorkingDir;
            }));
            IsProcessAborted = true;
            BtnRunProcess.Invoke((MethodInvoker)(() =>
                {
                    BtnRunProcess.Enabled = true;
                }));

            BtnStopProcess.Invoke((MethodInvoker)(() =>
                {
                    BtnStopProcess.Enabled = false;
                }));
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
                TokenTask.Cancel();
                TokenTask.Dispose();
            }
        }

        private bool IsExitVisualStudio { get; set; }
        private bool IsStashCahnges { get; set; }
        private bool IsCheckoutBranch { get; set; }
        private bool IsGitClean { get; set; }
        private bool IsBuildSolution { get; set; }
        private bool IsRunVisualStudio { get; set; }
        private bool IsRunUri { get; set; }
        private bool IsCreateNewBranch { get; set; }

        private void BtnRunProcessClick(object sender, EventArgs e)
        {
            TokenTask = new CancellationTokenSource();
            if (CbxSolutions.Items.Count > 0)
            {
                TargetSolutionName = CbxSolutions.SelectedItem.ToString();
            }
            if (CbxBranches.Items.Count > 0)
            {
                TargetBranchName = CbxBranches.SelectedItem.ToString();
            }
            IsExitVisualStudio = this.CbxIsExitVisualStudio.Checked;
            IsStashCahnges = this.CbxIsStashChanges.Checked;
            IsCheckoutBranch = this.CbxIsCheckoutBranch.Checked;
            IsGitClean = this.CbxIsGitClean.Checked;
            IsBuildSolution = this.CbxIsBuildSolution.Checked;
            IsRunVisualStudio = this.CbxIsRunVisualStudio.Checked;
            IsRunUri = this.CbxLaunchUri.Checked;
            IsCreateNewBranch = this.CbxIsCreateNewBranch.Checked;

            ResetCheckboxBackColor();
            TbxLogInfo.ClearUndo();
            IsProcessAborted = false;
            BtnRunProcess.Enabled = false;
            BtnStopProcess.Enabled = true;
            Task = Task.Factory.StartNew(RunProcess, TokenTask.Token);
        }

        private void DeleteSelectedLocalBranches()
        {
            foreach (DataGridViewRow row in DgvLocalsBranches.SelectedRows)
            {
                string branchToDelete = row.Cells[0].Value.ToString();
                CmdResult gitStashResult = _gitUiCommands.GitModule.RunGitCmdResult($"branch -d {branchToDelete}");
                if (gitStashResult.ExitCode != 0)
                {
                    MessageBox.Show($"Error when deleting {branchToDelete}. {gitStashResult.StdError}", "Error");
                }
            }
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            InitLocalBranchTab();
        }

        private void SetMsBuildPath()
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

        private void CbxBranchesKeyPress(object sender, KeyPressEventArgs e)
        {
            string strFindStr = "";

            if (e.KeyChar == (char)8)
            {
                if (CbxBranches.SelectionStart <= 1)
                {
                    CbxBranches.Text = "";
                    return;
                }

                if (CbxBranches.SelectionLength == 0)
                    strFindStr = CbxBranches.Text.Substring(0, CbxBranches.Text.Length - 1);
                else
                    strFindStr = CbxBranches.Text.Substring(0, CbxBranches.SelectionStart - 1);
            }
            else
            {
                if (CbxBranches.SelectionLength == 0)
                    strFindStr = CbxBranches.Text + e.KeyChar;
                else
                    strFindStr = CbxBranches.Text.Substring(0, CbxBranches.SelectionStart) + e.KeyChar;
            }

            int intIdx = -1;

            // Search the string in the ComboBox list.

            intIdx = CbxBranches.FindString(strFindStr);

            if (intIdx != -1)
            {
                CbxBranches.SelectedText = string.Empty;
                CbxBranches.SelectedIndex = intIdx;
                CbxBranches.SelectionStart = strFindStr.Length;
                CbxBranches.SelectionLength = CbxBranches.Text.Length;
            }
            e.Handled = true;
        }

        private void ExitProcess()
        {
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
                TokenTask.Cancel();
                TokenTask.Dispose();
                IsProcessAborted = true;
                BtnRunProcess.Enabled = true;
                BtnStopProcess.Enabled = false;
            }
        }

        private void BtnDeleteLocalsBranchesClick(object sender, EventArgs e)
        {
            if (DgvLocalsBranches.SelectedRows.Count > 0)
            {
                DialogResult response = MessageBox.Show("Are you sure you want delete these branches ?", "Talentsoft tools", MessageBoxButtons.YesNo);
                switch (response)
                {
                    case DialogResult.Yes:
                        DeleteSelectedLocalBranches();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void BtnStopProcessClick(object sender, EventArgs e)
        {
            ExitProcess();
        }

        private void CbxIsCheckoutBranchCheckedChanged(object sender, EventArgs e)
        {
            if (CbxBranches.Items.Count == 0)
            {
                CbxIsCheckoutBranch.Checked = false;
            }
        }

        private void CbxIsCreateNewBranchCheckedChanged(object sender, EventArgs e)
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

        private void TbcMainSelectedIndexChanged(object sender, EventArgs e)
        {
            if (TbcMain.SelectedIndex == 1)
            {
                InitLocalBranchTab();
            }
        }

        private void TalentsoftToolsFormClosing(object sender, FormClosingEventArgs e)
        {
            if (TokenTask != null && !TokenTask.IsCancellationRequested)
            {
                DialogResult response = MessageBox.Show("The process is running, are you sure to stop it ?", "Talentsoft tools", MessageBoxButtons.YesNo);
                switch (response)
                {
                    case DialogResult.Yes:
                        ExitProcess();
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
        }
    }
}
