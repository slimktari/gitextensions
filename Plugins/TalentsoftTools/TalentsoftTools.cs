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
    using System.Drawing;
    using System.IO;
    using System.Threading.Tasks;

    public partial class TalentsoftTools : GitExtensionsFormBase
    {
        private static readonly Regex DefaultHeadPattern = new Regex("refs/remotes/[^/]+/HEAD", RegexOptions.Compiled);

        readonly ISettingsSource _settings;
        readonly GitUIBaseEventArgs _gitUiCommands;
        List<string> TargetSolutions { get; set; }
        string TargetSolution { get; set; }
        Dictionary<string, List<string>> Branches { get; set; }
        List<string> RemoteBranchesNames { get; set; }
        List<GitRef> RemoteBranches { get; set; }
        List<string> LocalBranchesNames { get; set; }
        List<GitRef> LocalBranches { get; set; }
        public bool IsRefreshNeeded { get; set; }

        public TalentsoftTools(GitUIBaseEventArgs gitUiCommands, ISettingsSource settings)
        {
            InitializeComponent();
            Translate();
            _settings = settings;
            _gitUiCommands = gitUiCommands;
            Branches = new Dictionary<string, List<string>>();
            Icon = _gitUiCommands.GitUICommands.FormIcon;
            Init();
        }

        private void ResetActualLabels()
        {
            LblActualBranchName.Text = _gitUiCommands.GitModule.GetSelectedBranch();
            LblActualRepository.Text = _gitUiCommands.GitModule.WorkingDir;
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

        private void Init()
        {
            BtnRunProcess.Enabled = false;
            _gitUiCommands.GitModule.RunGitCmd("git fetch --all");
            RemoteBranches = GetBranches().Where(h => h.IsRemote && !h.IsTag).ToList();
            RemoteBranchesNames = RemoteBranches.Select(b => b.Name).ToList();
            LocalBranches = GetBranches().Where(h => !h.IsRemote && !h.IsTag && !h.IsOther && !h.IsBisect).ToList();
            LocalBranchesNames = LocalBranches.Select(b => b.Name).ToList();
            TargetSolutions = Helper.GetSolutionsFile(_gitUiCommands.GitModule.WorkingDir);
            CbxSolutions.DataSource = TargetSolutions;
            DgvLocalsBranches.DataSource = LocalBranchesNames.Select(x => new { Name = x }).ToList();
            SetDedaultProcessValues();
            SelectDefaultSloutionFile();
            SetMsBuildPath();
            if(string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
            {
                CbxLaunchUri.Checked = false;
                CbxLaunchUri.Enabled = false;
            }
            this.ResetActualLabels();
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

        private void SetDedaultProcessValues()
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

        //private List<string> GetLocalBranches()
        //{
        //    string[] references = _gitUiCommands.GitModule.RunGitCmd("branch")
        //                                         .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        //    return references.Select(e => e.Trim('*', ' ', '\n', '\r')).ToList();
        //}

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
                CbxBranches.DataSource = LocalBranchesNames;
            }
            if (RbtIsRemoteTargetBranch.Checked)
            {
                CbxBranches.DataSource = RemoteBranchesNames;
            }
        }

        private async void BtnRunProcessClick(object sender, EventArgs e)
        {
            Task task = null;
            bool isRunProcess = true;
            DateTime startDateTime = DateTime.Now;
            TbxLogInfo.ClearUndo();
            TbxLogInfo.Clear();
            ResetCheckboxBackColor();
            TbxLogInfo.AppendText($"Start at: {startDateTime}\r\nCurrent branch: {_gitUiCommands.GitModule.GetSelectedBranch()}\r\nTarget branch: {CbxBranches.SelectedItem}\r\nTarget solution: {CbxSolutions.SelectedItem}\r\n");
            Cursor.Current = Cursors.WaitCursor;
            if (CbxIsExitVisualStudio.Checked)
            {
                //CbxIsExitVisualStudio.BackColor = Color.LimeGreen;
                TbxLogInfo.AppendText("\r\nExiting Visual Studio...");
                bool isExited = await Helper.ExitVisualStudioAsync(CbxSolutions.SelectedItem.ToString());
                if (!isExited)
                {
                    CbxIsExitVisualStudio.BackColor = Color.Red;
                    TbxLogInfo.AppendText("\r\nError when exit Visual Studio.");
                    TbxLogInfo.AppendText("\r\nProcess aborted.");
                    isRunProcess = false;
                }
            }
            if (CbxIsStashChanges.Checked && isRunProcess)
            {
                //CbxIsStashChanges.BackColor = Color.LimeGreen;
                TbxLogInfo.AppendText("\r\nStashing changes... 'stash --include-untracked'");
                CmdResult gitStashResult = await Helper.GitCmdAsync(_gitUiCommands, "stash --include-untracked");
                if (gitStashResult.ExitCode != 0)
                {
                    CbxIsStashChanges.BackColor = Color.Red;
                    TbxLogInfo.AppendText($"\r\nError when stashing changes. {gitStashResult.StdError}");
                    TbxLogInfo.AppendText("\r\nProcess aborted.");
                    isRunProcess = false;
                }
            }
            if (CbxIsCheckoutBranch.Checked && isRunProcess)
            {
                //CbxIsCheckoutBranch.BackColor = Color.LimeGreen;
                string newLocalBranch = CbxBranches.SelectedItem.ToString();
                if (RbtIsRemoteTargetBranch.Checked)
                {
                    newLocalBranch = RemoteBranches.Single(b => b.IsRemote && b.Name == newLocalBranch).LocalName;
                }
                TbxLogInfo.AppendText($"\r\nCheckout branch {CbxBranches.SelectedItem}... 'checkout -B {newLocalBranch} {CbxBranches.SelectedItem}'");
                CmdResult gitCheckoutResult = await Helper.GitCmdAsync(_gitUiCommands, $"checkout -B {newLocalBranch} {CbxBranches.SelectedItem}");
                if (gitCheckoutResult.ExitCode != 0)
                {
                    CbxIsCheckoutBranch.BackColor = Color.Red;
                    TbxLogInfo.AppendText($"\r\nError when checkout branch. {gitCheckoutResult.StdError}");
                    TbxLogInfo.AppendText("\r\nProcess aborted.");
                    isRunProcess = false;
                }
            }
            if (CbxIsGitClean.Checked && isRunProcess)
            {
                //CbxIsGitClean.BackColor = Color.LimeGreen;
                string excludeCommand = string.Empty;
                if(!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]))
                {
                    excludeCommand = $" --exclude {TalentsoftToolsPlugin.ExcludePatternGitClean[_settings]}";
                }
                TbxLogInfo.AppendText($"\r\nCleaning solution: {CbxSolutions.SelectedItem}... 'clean -d -x -f {excludeCommand}'");
                CmdResult gitCleanResult = await Helper.GitCmdAsync(_gitUiCommands, $"clean -d -x -f {excludeCommand}");
                if (gitCleanResult.ExitCode != 0)
                {
                    CbxIsGitClean.BackColor = Color.Red;
                    TbxLogInfo.AppendText($"\r\nError when cleaning solution: {CbxSolutions.SelectedItem}. {gitCleanResult.StdError}");
                    TbxLogInfo.AppendText("\r\nProcess aborted.");
                    isRunProcess = false;
                }
            }
            if (CbxIsBuildSolution.Checked && isRunProcess)
            {
                //CbxIsBuildSolution.BackColor = Color.LimeGreen;
                TbxLogInfo.AppendText($"\r\nRestoring Nugets in solution: {CbxSolutions.SelectedItem}... 'nuget restore {CbxSolutions.SelectedItem.ToString()}'");
                bool result = await Helper.NugetRestoreAsync(CbxSolutions.SelectedItem.ToString());
                if (!result)
                {
                    CbxIsBuildSolution.BackColor = Color.Red;
                    TbxLogInfo.AppendText($"\r\nError when restoring nugets in solution: {CbxSolutions.SelectedItem}.");
                    TbxLogInfo.AppendText("\r\nProcess aborted.");
                    isRunProcess = false;
                }
                else
                {
                    TbxLogInfo.AppendText($"\r\nBuilding solution: {CbxSolutions.SelectedItem}... '{TalentsoftToolsPlugin.PathToMsBuild[_settings]} /t:Build /p:Configuration=Debug /m:4 {CbxSolutions.SelectedItem.ToString()}'");
                    result = await Helper.BuildAsync(CbxSolutions.SelectedItem.ToString(), TalentsoftToolsPlugin.PathToMsBuild[_settings]);
                    if (!result)
                    {
                        TbxLogInfo.AppendText($"\r\nError when building solution: {CbxSolutions.SelectedItem}.");
                        TbxLogInfo.AppendText("\r\nProcess aborted.");
                        isRunProcess = false;
                    }
                }
            }
            if (CbxIsRunVisualStudio.Checked && isRunProcess)
            {
                //CbxIsRunVisualStudio.BackColor = Color.LimeGreen;
                TbxLogInfo.AppendText($"\r\nRunning Visual Studio with: {CbxSolutions.SelectedItem}...");
                if (!Helper.LaunchVisualStudio(CbxSolutions.SelectedItem.ToString()))
                {
                    CbxIsRunVisualStudio.BackColor = Color.Red;
                    TbxLogInfo.AppendText($"\r\nError when running Visual Studio with: {CbxSolutions.SelectedItem}.");
                    isRunProcess = false;
                }
            }
            if (CbxLaunchUri.Checked && isRunProcess)
            {
                //CbxLaunchUri.BackColor = Color.LimeGreen;
                TbxLogInfo.AppendText($"\r\nLaunching web URI: {TalentsoftToolsPlugin.LocalUriWebApplication[_settings]}...");
                if (!Helper.LaunchWebUri(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
                {
                    CbxLaunchUri.BackColor = Color.Red;
                    TbxLogInfo.AppendText($"\r\nError when launching web URI: {TalentsoftToolsPlugin.LocalUriWebApplication[_settings]}.");
                }
            }
            DateTime endateDateTime = DateTime.Now;
            TbxLogInfo.AppendText($"\r\nEnd at: {endateDateTime}");
            TbxLogInfo.AppendText($"\r\nElapsed time: {endateDateTime - startDateTime}");
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            ResetActualLabels();
            Cursor.Current = Cursors.Default;
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

        private void CbxBranchesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxBranches.SelectedItem != null && !string.IsNullOrEmpty(CbxBranches.SelectedItem.ToString()) && !string.IsNullOrEmpty(CbxSolutions.SelectedItem.ToString()))
            {
                BtnRunProcess.Enabled = true;
            }
            else
            {
                BtnRunProcess.Enabled = false;
            }
        }

        private void CbxSolutionsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbxBranches.SelectedItem != null && !string.IsNullOrEmpty(CbxBranches.SelectedItem.ToString()) && !string.IsNullOrEmpty(CbxSolutions.SelectedItem.ToString()))
            {
                BtnRunProcess.Enabled = true;
            }
            else
            {
                BtnRunProcess.Enabled = false;
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
                CbxBranches.SelectedText = "";
                CbxBranches.SelectedIndex = intIdx;
                CbxBranches.SelectionStart = strFindStr.Length;
                CbxBranches.SelectionLength = CbxBranches.Text.Length;
            }
            e.Handled = true;
        }

        private void TalentsoftToolsFormClosed(object sender, FormClosedEventArgs e)
        {
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
        }

        private void BtnDeleteLocalsBranchesClick(object sender, EventArgs e)
        {
            if (DgvLocalsBranches.SelectedRows.Count > 0)
            {
                DialogResult response = MessageBox.Show("Are sure you want to delete these branches ?",
                      "Talentsoft tools", MessageBoxButtons.YesNo);
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

        private async void DeleteSelectedLocalBranches()
        {
            foreach (DataGridViewRow row in DgvLocalsBranches.SelectedRows)
            {
                string branchToDelete = row.Cells[0].Value.ToString();
                CmdResult gitStashResult = await Helper.GitCmdAsync(_gitUiCommands, $"branch -d {branchToDelete}");
                if (gitStashResult.ExitCode != 0)
                {
                    MessageBox.Show($"Error when deleting {branchToDelete}. {gitStashResult.StdError}", "Error");
                }
            }
            await Helper.GitCmdAsync(_gitUiCommands, "fetch -p");
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            Init();
        }
    }
}
