using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GitCommands;
using GitUIPluginInterfaces;

namespace TalentsoftTools.Helpers
{
    /// <summary>
    /// Here we find all methods helper for interact with git.
    /// </summary>
    public static class GitHelper
    {
        /// <summary>
        /// Checkouts local branch or checkout remote branch and create local branch.
        /// </summary>
        /// <param name="localBranchName">Local branch name to create or to checkout.</param>
        /// <param name="remoteBranchName">Remote branch name.</param>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult CheckoutBranch(string localBranchName, string remoteBranchName = "")
        {
            if (string.IsNullOrWhiteSpace(remoteBranchName))
            {
                return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult(string.Format("checkout -B {0} {1}", localBranchName, remoteBranchName));
            }
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult(string.Format("checkout {0}", localBranchName));
        }

        /// <summary>
        /// Creates branch from current branch and checkout it.
        /// </summary>
        /// <param name="newBranchName">Name of branch to create.</param>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult CreateAndCheckoutBranch(string newBranchName)
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult(string.Format("checkout -b {0}", newBranchName));
        }

        /// <summary>
        /// Clean repository.
        /// </summary>
        /// <param name="excludePattern">Exclude files.</param>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult Clean(string excludePattern)
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult(string.Format("clean -d -x -f{0}", excludePattern));
        }

        /// <summary>
        /// Stash pop.
        /// </summary>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult StashPop()
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult("stash pop");
        }

        /// <summary>
        /// Stash changes.
        /// </summary>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult StashChanges()
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult("stash --include-untracked");
        }

        /// <summary>
        /// Gets the name of selected branch in current repository.
        /// </summary>
        /// <returns>Name of selected branch in current repository.</returns>
        public static string GetSelectedBranch()
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.GetSelectedBranch();
        }

        /// <summary>
        /// Gets path of current repository.
        /// </summary>
        /// <returns>Path of current repository.</returns>
        public static string GetWorkingDirectory()
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.WorkingDir;
        }

        /// <summary>
        /// Notify changes to repository.
        /// </summary>
        public static void NotifyGitExtensions()
        {
            TalentsoftToolsPlugin.GitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
        }

        /// <summary>
        /// Gets branch informations.
        /// </summary>
        /// <param name="branchName">Branch name.</param>
        /// <returns>List of branch informations.</returns>
        public static string[] GetBranchInfo(string branchName)
        {
            CmdResult result = TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult(string.Format("log -n 1 --pretty=format:\" % an;% cr\" {0}", branchName));
            if (result.ExitCode == 0 && !string.IsNullOrWhiteSpace(result.StdOutput) && result.StdOutput.Contains(";"))
            {
                return result.StdOutput.Split(';');
            }
            return new string[0];
        }

        /// <summary>
        /// Gets all branches.
        /// </summary>
        /// <returns>List of all branches.</returns>
        public static List<GitRef> GetBranches()
        {
            return GetTreeRefs(TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmd("show-ref --dereference")).ToList();
        }

        /// <summary>
        /// Gets tree of all object in repository.
        /// </summary>
        /// <param name="tree">The tree.</param>
        /// <returns>List of object.</returns>
        static List<GitRef> GetTreeRefs(string tree)
        {
            var defaultHeadPattern = new Regex("refs/remotes/[^/]+/HEAD", RegexOptions.Compiled);
            var itemsStrings = tree.Split('\n');

            var gitRefs = new List<GitRef>();
            var defaultHeads = new Dictionary<string, GitRef>(); // remote -> HEAD
            var remotes = TalentsoftToolsPlugin.GitUiCommands.GitModule.GetRemotes(false);

            foreach (var itemsString in itemsStrings)
            {
                if (itemsString == null || itemsString.Length <= 42 || itemsString.StartsWith("error: "))
                    continue;

                var completeName = itemsString.Substring(41).Trim();
                var guid = itemsString.Substring(0, 40);
                var remoteName = GitCommandHelpers.GetRemoteName(completeName, remotes);
                var head = new GitRef(null, guid, completeName, remoteName);
                if (defaultHeadPattern.IsMatch(completeName))
                {
                    defaultHeads[remoteName] = head;
                }
                else
                {
                    gitRefs.Add(head);
                }
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

        /// <summary>
        /// Gets locals branches.
        /// </summary>
        /// <returns>List of all locals branches.</returns>
        public static List<GitRef> GetLocalsBranches()
        {
            return GetBranches().Where(h => !h.IsRemote && !h.IsTag && !h.IsOther && !h.IsBisect).ToList();
        }

        /// <summary>
        /// Gets remotes branches.
        /// </summary>
        /// <returns>List of all remotes branches.</returns>
        public static List<GitRef> GetRemotesBranches()
        {
            return GetBranches().Where(h => h.IsRemote && !h.IsTag).ToList();
        }

        /// <summary>
        /// Gets not merged branches.
        /// </summary>
        /// <returns>List of not merged branches.</returns>
        public static string[] GetUnmergerBranches()
        {
            CmdResult gitResult = TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult("branch --no-merged");
            if (gitResult.ExitCode == 0)
            {
                return gitResult.StdOutput.Replace(" ", string.Empty).SplitLines();
            }
            return new string[0];
        }

        /// <summary>
        /// Test if branch need updates according to his remote.
        /// </summary>
        /// <param name="brancheName">Branch name to verify.</param>
        /// <returns>True if need to update, otherwise false.</returns>
        public static bool NeedToUpdate(string brancheName)
        {
            CmdResult gitResult = TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult("show-ref -s " + brancheName);
            if (gitResult.ExitCode == 0)
            {
                string[] results = gitResult.StdOutput.SplitLines();
                if (results.Any())
                {
                    return results.Any(x => !string.IsNullOrWhiteSpace(x) && x != results.FirstOrDefault());
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Delete local branch but only if its merged.
        /// </summary>
        /// <param name="branchToDelete">Branch name.</param>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult DeleteMergedLocalBranch(string branchToDelete)
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult(string.Format("branch -d {0}", branchToDelete));
        }

        /// <summary>
        /// Delete local branch.
        /// </summary>
        /// <param name="branchToDelete">Branch name.</param>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult DeleteUnmergedLocalBranch(string branchToDelete)
        {
            return TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult(string.Format("branch -D {0}", branchToDelete));
        }

        /// <summary>
        /// Fetch all objects quiet.
        /// </summary>
        /// <returns>The <see cref="CmdResult"/>.</returns>
        public static CmdResult FetchAll()
        {
            CmdResult results = TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult("fetch -q --all");
            TalentsoftToolsPlugin.GitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            return results;
        }

        /// <summary>
        /// Gets list of stash objects.
        /// </summary>
        /// <returns>List of stash objects.</returns>
        public static string[] GetStashs()
        {
            CmdResult gitResult = TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult("stash list");
            if (gitResult.ExitCode == 0 && !string.IsNullOrWhiteSpace(gitResult.StdOutput))
            {
                return gitResult.StdOutput.SplitLines();
            }
            return new string[0];
        }

        /// <summary>
        /// Gets difference branch with its related remote.
        /// </summary>
        /// <returns>List of difference.</returns>
        public static string[] GetDiff()
        {
            CmdResult gitResult = TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmdResult("diff");
            if (gitResult.ExitCode == 0 && !string.IsNullOrWhiteSpace(gitResult.StdOutput))
            {
                return gitResult.StdOutput.SplitLines();
            }
            return new string[0];
        }

        /// <summary>
        /// Test if there are any changes in current repository.
        /// </summary>
        /// <returns>True if there are any changes, otherwise false.</returns>
        public static bool IfChangedFiles()
        {
            return !string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.GitUiCommands.GitModule.RunGitCmd(GitCommandHelpers.GetAllChangedFilesCmd(true, UntrackedFilesMode.All)));
        }
    }
}
