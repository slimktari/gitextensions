using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GitCommands;
using GitUIPluginInterfaces;
using ResourceManager;

namespace TalentsoftTools
{
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using GitCommands.Git;

    public partial class TalentsoftTools : GitExtensionsFormBase
    {
        private static readonly Regex DefaultHeadPattern = new Regex("refs/remotes/[^/]+/HEAD", RegexOptions.Compiled);

        readonly GitUIBaseEventArgs _gitUiCommands;
        List<string> TargetSolutions { get; set; }
        string TargetSolution { get; set; }
        Dictionary<string, List<string>> Branches { get; set; }
        List<string> RemoteBranches { get; set; }
        List<string> LocalBranches { get; set; }
        public bool IsRefreshNeeded { get; set; }

        public TalentsoftTools(GitUIBaseEventArgs gitUiCommands)
        {
            InitializeComponent();
            Translate();
            _gitUiCommands = gitUiCommands;
            Branches = new Dictionary<string, List<string>>();
            Init();
        }

        private void Init()
        {
            RemoteBranches = GetRemoteBranches();
            LocalBranches = GetLocalBranches();
            var wd = _gitUiCommands.GitModule.WorkingDir;
            var selectedBranch = _gitUiCommands.GitModule.GetSelectedBranch();
            string localDirectory = _gitUiCommands.GitModule.WorkingDir;
            TargetSolutions = Helper.GetSolutionsFile(_gitUiCommands.GitModule.WorkingDir);
            CbxSolutions.DataSource = TargetSolutions;
            
            //var ddss = this._gitUiCommands.GitUICommands.BrowseRepo;
            //var remotes = _gitUiCommands.GitUICommands.StartCheckoutBranch()
            //var remotess = _gitUiCommands.GitModule.GetRemotes(false);
            //var d = GetLocalBranches();
            //var sd = _gitUiCommands.GitModule.WorkingDir;
            //string[] references = _gitUiCommands.GitModule.RunGitCmd("remote").Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            //var dddlocal = _gitUiCommands.GitModule.RunGitCmd("show-ref --tags");
            //var dd =GetRemoteBranches();
        }

        private List<string> GetLocalBranches()
        {
            string[] references = _gitUiCommands.GitModule.RunGitCmd("branch")
                                                 .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return references.Select(e => e.Trim('*', ' ', '\n', '\r')).ToList();
        }

        private List<string> GetRemoteBranches()
        {
           return GetTreeRefs(_gitUiCommands.GitModule.RunGitCmd("show-ref --dereference")).Where(h => h.IsRemote && !h.IsTag).Select(b => b.Name).ToList();
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
                CbxBranches.DataSource = LocalBranches;
            }
            if (RbtIsRemoteTargetBranch.Checked)
            {
                CbxBranches.DataSource = RemoteBranches;
            }
        }

        private void CbxBranches_SelectedIndexChanged(object sender, EventArgs e)
        {
            var d = CbxBranches.SelectedIndex;
            var dd = CbxBranches.SelectedItem;
            var ds = CbxBranches.SelectedText;
        }

        private void BtnRunProcessClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (CbxIsExitVisualStudio.Checked)
            {
                Helper.ExitVisualStudio(CbxSolutions.SelectedItem.ToString());
            }
            if (CbxIsStashChanges.Checked)
            {
                _gitUiCommands.GitModule.RunGitCmd("stash --all");
            }
            if (CbxIsCheckoutBranch.Checked)
            {
                _gitUiCommands.GitModule.RunGitCmd(GitCommandHelpers.CheckoutCmd(CbxBranches.SelectedItem.ToString(), LocalChangesAction.Reset));
                //_gitUiCommands.GitModule.RunGitCmd(string.Format("checkout -B {0} {1}", CbxBranches.SelectedItem, CbxBranches.SelectedItem));
                //GitCommandHelpers.CheckoutCmd(CbxBranches.SelectedItem.ToString(), LocalChangesAction.Reset);
            }
            if (CbxIsGitClean.Checked)
            {
                _gitUiCommands.GitModule.RunGitCmd("clean -xfd");
            }
            Cursor.Current = Cursors.Default;
        }

        //private void CheckoutBranch()
        //{
        //    GitCheckoutBranchCmd cmd = new GitCheckoutBranchCmd(CbxBranches.SelectedItem.ToString(), RbtIsRemoteTargetBranch.Checked);
        //    if (RbtIsRemoteTargetBranch.Checked)
        //        {
        //            if (false)
        //            {// if create new branch
        //                cmd.NewBranchName = CbxBranches.SelectedItem.ToString();
        //                cmd.NewBranchAction = GitCheckoutBranchCmd.NewBranch.Create;
        //                //if (!Module.CheckBranchFormat(cmd.NewBranchName))
        //                //{
        //                //    MessageBox.Show(string.Format(_customBranchNameIsNotValid.Text, cmd.NewBranchName), Text);
        //                //    DialogResult = DialogResult.None;
        //                //    return DialogResult.None;
        //                //}
        //        }// end of // if create new branch

        //        // if reset new branch
        //        else if (true)
        //            {
        //                cmd.NewBranchAction = GitCheckoutBranchCmd.NewBranch.Reset;
        //                cmd.NewBranchName = CbxBranches.SelectedItem.ToString();
        //            }
        //            else
        //            {
        //                cmd.NewBranchAction = GitCheckoutBranchCmd.NewBranch.DontCreate;
        //                cmd.NewBranchName = null;
        //            }
        //        }
        //    GitCommandHelpers.CheckoutCmd("", LocalChangesAction.Reset);
        //    IWin32Window owner = Visible ? this : Owner;
        //    this._gitUiCommands.GitModule.RunGitCmd(cmd)
        //}
        
    }
}
