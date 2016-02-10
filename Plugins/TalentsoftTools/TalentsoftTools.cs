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

        private void Init()
        {
            BtnRunProcess.Enabled = false;
            _gitUiCommands.GitModule.RunGitCmd("git fetch--all");
            RemoteBranches = GetBranches().Where(h => h.IsRemote && !h.IsTag).ToList();
            RemoteBranchesNames = RemoteBranches.Select(b => b.Name).ToList();
            LocalBranches = GetBranches().Where(h => !h.IsRemote && !h.IsTag).ToList();
            LocalBranchesNames = LocalBranches.Select(b => b.Name).ToList();
            TargetSolutions = Helper.GetSolutionsFile(_gitUiCommands.GitModule.WorkingDir);
            CbxSolutions.DataSource = TargetSolutions;
            // DgvLocalsBranches.DataSource = LocalBranches.Select(x => new { Value = x }).ToList();
             DgvLocalsBranches.DataSource = LocalBranchesNames.Select(x => new { Name = x}).ToList();

            //DgvLocalsBranches.Columns[0].AutoSizeMode

            var wd = _gitUiCommands.GitModule.WorkingDir;
            var selectedBranch = _gitUiCommands.GitModule.GetSelectedBranch();
            string localDirectory = _gitUiCommands.GitModule.WorkingDir;
            

            //var ddss = this._gitUiCommands.GitUICommands.BrowseRepo;
            //var remotes = _gitUiCommands.GitUICommands.StartCheckoutBranch()
            //var remotess = _gitUiCommands.GitModule.GetRemotes(false);
            //var d = GetLocalBranches();
            //var sd = _gitUiCommands.GitModule.WorkingDir;
            //string[] references = _gitUiCommands.GitModule.RunGitCmd("remote").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //var dddlocal = _gitUiCommands.GitModule.RunGitCmd("show-ref --tags");
            //var dd =GetRemoteBranches();
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

        private void BtnRunProcessClick(object sender, EventArgs e)
        {
            bool isRunProcess = true;
            TbxLogInfo.Clear();
            TbxLogInfo.AppendText($"Start at: {DateTime.Now}\r\nCurrent branch: {_gitUiCommands.GitModule.GetSelectedBranch()}\r\nTarget branch: {CbxBranches.SelectedItem}\r\nTarget solution: {CbxSolutions.SelectedItem}\r\n");
            Cursor.Current = Cursors.WaitCursor;
            if (CbxIsExitVisualStudio.Checked)
            {
                TbxLogInfo.AppendText("\r\nExiting Visual Studio...");
                if (!Helper.ExitVisualStudio(CbxSolutions.SelectedItem.ToString()))
                {
                    TbxLogInfo.AppendText("\r\nError when exit Visual Studio.");
                    TbxLogInfo.AppendText("\r\nProcess aborded.");
                    isRunProcess = false;
                }
            }
            if (CbxIsStashChanges.Checked && isRunProcess)
            {
                TbxLogInfo.AppendText("\r\nStashing changes...");
                CmdResult gitStashResult = _gitUiCommands.GitModule.RunGitCmdResult("stash --all");
                if (gitStashResult.ExitCode != 0)
                {
                    TbxLogInfo.AppendText($"\r\nError when stashing changes. {gitStashResult.StdError}");
                    TbxLogInfo.AppendText("\r\nProcess aborded.");
                    isRunProcess = false;
                }
            }
            if (CbxIsCheckoutBranch.Checked && isRunProcess)
            {
                TbxLogInfo.AppendText($"\r\nCheckout branch {CbxBranches.SelectedItem}...");
                string newLocalBranch = CbxBranches.SelectedItem.ToString();
                if (RbtIsRemoteTargetBranch.Checked)
                {
                    newLocalBranch = RemoteBranches.Single(b => b.IsRemote && b.Name == newLocalBranch).LocalName;
                }
                CmdResult gitCheckoutResult = _gitUiCommands.GitModule.RunGitCmdResult($"checkout -B {newLocalBranch} {CbxBranches.SelectedItem}");
                if (gitCheckoutResult.ExitCode != 0)
                {
                    TbxLogInfo.AppendText($"\r\nError when checkout branch {CbxBranches.SelectedItem}. {gitCheckoutResult.StdError}");
                    TbxLogInfo.AppendText("\r\nProcess aborded.");
                    isRunProcess = false;
                }
            }
            if (CbxIsGitClean.Checked && isRunProcess)
            {
                TbxLogInfo.AppendText($"\r\nCleaning solution: {CbxSolutions.SelectedItem}...");
                CmdResult gitCleanResult = _gitUiCommands.GitModule.RunGitCmdResult("clean -xfd");
                if (gitCleanResult.ExitCode != 0)
                {
                    TbxLogInfo.AppendText($"\r\nError when cleaning solution: {CbxSolutions.SelectedItem}. {gitCleanResult.StdError}");
                    TbxLogInfo.AppendText("\r\nProcess aborded.");
                    isRunProcess = false;
                }
            }
            if (CbxIsBuildSolution.Checked && isRunProcess)
            {
                TbxLogInfo.AppendText($"\r\nRestoring Nugets in solution: {CbxSolutions.SelectedItem}...");
                if (!Helper.NugetRestore(CbxSolutions.SelectedItem.ToString()))
                {
                    TbxLogInfo.AppendText($"\r\nError when restoring nugets in solution: {CbxSolutions.SelectedItem}.");
                    TbxLogInfo.AppendText("\r\nProcess aborded.");
                    isRunProcess = false;
                }
                TbxLogInfo.AppendText($"\r\nBuilding solution: {CbxSolutions.SelectedItem}...");
                if (!Helper.Build(CbxSolutions.SelectedItem.ToString()))
                {
                    TbxLogInfo.AppendText($"\r\nError when building solution: {CbxSolutions.SelectedItem}.");
                    TbxLogInfo.AppendText("\r\nProcess aborded.");
                    isRunProcess = false;
                }
            }
            if (CbxIsRunScriptNextVersion.Checked && isRunProcess)
            {
                TbxLogInfo.AppendText("\r\nScript next version not implemented.");
            }
            if (CbxIsRunVisualStudio.Checked)
            {
                TbxLogInfo.AppendText($"\r\nRunning Visual Studio with: {CbxSolutions.SelectedItem}...");
                if (!Helper.LaunchVisualStudio(CbxSolutions.SelectedItem.ToString()))
                {
                    TbxLogInfo.AppendText($"\r\nError when running Visual Studio with: {CbxSolutions.SelectedItem}.");
                }
            }
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
            {
                TbxLogInfo.AppendText($"\r\nLaunching web URI: {TalentsoftToolsPlugin.LocalUriWebApplication[_settings]}...");
                if (!Helper.LaunchWebUri(TalentsoftToolsPlugin.LocalUriWebApplication[_settings]))
                {
                    TbxLogInfo.AppendText($"\r\nError when launching web URI: {TalentsoftToolsPlugin.LocalUriWebApplication[_settings]}.");
                }
            }
            TbxLogInfo.AppendText($"\r\nEnd at: {DateTime.Now}");
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            Init();
            Cursor.Current = Cursors.Default;
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
    }
}
