using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GitCommands;
using GitUIPluginInterfaces;

namespace TalentsoftTools
{
    public class Helper
    {
        public static List<DatabaseDto> GetDatabasesFromPameters(string parameters, string databases)
        {
            if (string.IsNullOrWhiteSpace(parameters) || string.IsNullOrWhiteSpace(databases))
            {
                return new List<DatabaseDto>();
            }
            var databasesTab = databases.Split(';');
            var results = new List<DatabaseDto>();
            string userId = string.Empty;
            string password = string.Empty;
            string relocateDataFilePath = string.Empty;
            string dataSource = string.Empty;

            DatabaseDto databaseDto = null;
            foreach (var database in databasesTab)
            {
                if (!string.IsNullOrWhiteSpace(database) && database.Contains("="))
                {
                    string[] dict = database.Split('=');
                    if (dict.Length == 2)
                    {
                        switch (dict[0])
                        {
                            case "Initial Catalog":
                                databaseDto = new DatabaseDto
                                {
                                    DatabaseName = dict[1]
                                };
                                break;
                            case "BackupFilePath":
                                if (databaseDto != null && !string.IsNullOrWhiteSpace(databaseDto.DatabaseName))
                                {
                                    databaseDto.BackupFilePath = dict[1];
                                    results.Add(databaseDto);
                                }
                                break;
                        }
                    }
                }
            }
            foreach (var param in parameters.Split(';'))
            {
                if (!string.IsNullOrWhiteSpace(param) && param.Contains("="))
                {
                    string[] dict = param.Split('=');
                    if (dict.Length == 2)
                    {
                        switch (dict[0])
                        {
                            case "User ID":
                                userId = dict[1];
                                break;
                            case "Password":
                                password = dict[1];
                                break;
                            case "RelocateDataFilePath":
                                relocateDataFilePath = dict[1];
                                break;
                            case "Data Source":
                                dataSource = dict[1];
                                break;
                        }
                    }
                }
            }

            foreach (var result in results)
            {
                result.Password = password;
                result.PathToRelocate = relocateDataFilePath;
                result.ServerName = dataSource;
                result.UserId = userId;
            }
            return results;
        }

        public static bool ExitVisualStudio(string solutionFileName)
        {
            if (!string.IsNullOrWhiteSpace(solutionFileName))
            {
                solutionFileName = Path.GetFileNameWithoutExtension(solutionFileName);
            }

            var process = Process.GetProcessesByName("devenv");
            foreach (Process p in process)
            {
                if (string.IsNullOrWhiteSpace(solutionFileName) || (!string.IsNullOrWhiteSpace(solutionFileName) && p.MainWindowTitle.Contains(solutionFileName)))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                    catch (Win32Exception winException)
                    {
                        return false;
                        // process was terminating or can't be terminated - deal with it
                    }
                    catch (InvalidOperationException invalidException)
                    {
                        return false;
                        // process has already exited - might be able to let this one go
                    }
                }
            }
            return true;
        }

        public static Dictionary<string, string> GetSolutionsFile(string directory, int currentDepth = 0)
        {
            var files = new Dictionary<string, string>();
            try
            {
                foreach (var file in Directory.GetFiles(directory, "*.sln"))
                {
                    files.Add(Path.GetFileName(file), Path.GetFullPath(file));
                }

                if (currentDepth < 2)
                {
                    foreach (string directoryItem in Directory.GetDirectories(directory))
                    {
                        foreach (var file in GetSolutionsFile(directoryItem, currentDepth + 1))
                        {
                            files.Add(file.Key, file.Value);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error when loading solution files. " + exception);
            }
            return files;
        }

        public static string Build(string solutionFileFullPath, string argument)
        {
            if (string.IsNullOrEmpty(solutionFileFullPath))
            {
                return "Error : No solution file !";
            }

            string logFileName = Path.GetTempFileName();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = @"devenv.exe";
            psi.ErrorDialog = true;
            psi.Arguments = string.Format(@"/{0} Debug /out {1} {2}", argument, logFileName, solutionFileFullPath);
            Process p = Process.Start(psi);
            p.WaitForExit();
            int exitCode = p.ExitCode;
            p.Close();
            string errorLog;
            if (exitCode != 0)
            {
                TextReader reader = File.OpenText(logFileName);
                errorLog = reader.ReadToEnd();
                reader.Close();
                return errorLog;
            }
            return string.Empty;
        }

        public static bool Rebuild(string solutionFileFullPath, string pathToMsBuild)
        {
            //string validPathToMsBuild = GetMsBuildPath();
            if (string.IsNullOrEmpty(pathToMsBuild) || string.IsNullOrEmpty(solutionFileFullPath))
            {
                return false;
            }
            return RunCommandLine(new List<string> { string.Format("\"{0}\" /t:Clean;Rebuild /p:BuildInParallel=true /p:Configuration=Debug /maxcpucount \"{1}\"", pathToMsBuild, solutionFileFullPath) });
        }

        public static bool RunCommandLine(List<string> commands)
        {
            string output = string.Empty;
            string error = string.Empty;

            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;

            Process process = Process.Start(processStartInfo);

            using (StreamWriter sw = process.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    foreach (var command in commands)
                    {
                        sw.WriteLine(command);
                    }
                }
            }

            using (StreamReader streamReader = process.StandardOutput)
            {
                output = streamReader.ReadToEnd();
            }

            using (StreamReader streamReader = process.StandardError)
            {
                error = streamReader.ReadToEnd();
            }
            process.WaitForExit();
            if (!string.IsNullOrEmpty(error) || process.ExitCode != 0)
            {
                return false;
            }
            return true;
        }

        public static bool LaunchVisualStudio(string solutionFileFullPath)
        {
            if (string.IsNullOrWhiteSpace(solutionFileFullPath))
            {
                return false;
            }
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.Verb = "runas";
            processStartInfo.FileName = "devenv.exe";
            processStartInfo.Arguments = solutionFileFullPath;
            try
            {
                Process.Start(processStartInfo);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public static bool LaunchWebUri(string uri)
        {
            try
            {
                Process.Start(new UriBuilder(uri).Uri.AbsoluteUri);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Git Helpers

        public static string[] GetBranchInfo(GitUIBaseEventArgs gitUiCommands, string branchName)
        {
            CmdResult result = gitUiCommands.GitModule.RunGitCmdResult(string.Format("log -n 1 --pretty=format:\" % an;% cr\" {0}", branchName));
            if (result.ExitCode == 0 && !string.IsNullOrWhiteSpace(result.StdOutput) && result.StdOutput.Contains(";"))
            {
                return result.StdOutput.Split(';');
            }
            return new string[0];
        }

        public static List<GitRef> GetBranches(GitUIBaseEventArgs gitUiCommands)
        {
            return GetTreeRefs(gitUiCommands, gitUiCommands.GitModule.RunGitCmd("show-ref --dereference")).ToList();
        }

        static List<GitRef> GetTreeRefs(GitUIBaseEventArgs gitUiCommands, string tree)
        {
            var defaultHeadPattern = new Regex("refs/remotes/[^/]+/HEAD", RegexOptions.Compiled);
            var itemsStrings = tree.Split('\n');

            var gitRefs = new List<GitRef>();
            var defaultHeads = new Dictionary<string, GitRef>(); // remote -> HEAD
            var remotes = gitUiCommands.GitModule.GetRemotes(false);

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

        public static List<GitRef> GetLocalsBranches(GitUIBaseEventArgs gitUiCommands)
        {
            return GetBranches(gitUiCommands).Where(h => !h.IsRemote && !h.IsTag && !h.IsOther && !h.IsBisect).ToList();
        }

        public static List<GitRef> GetRemotesBranches(GitUIBaseEventArgs gitUiCommands)
        {
            return GetBranches(gitUiCommands).Where(h => h.IsRemote && !h.IsTag).ToList();
        }

        public static string[] GetUnmergerBranches(GitUIBaseEventArgs gitUiCommands)
        {
            CmdResult gitResult = gitUiCommands.GitModule.RunGitCmdResult("branch --no-merged");
            if (gitResult.ExitCode == 0)
            {
                return gitResult.StdOutput.Replace(" ", string.Empty).SplitLines();
            }
            return new string[0];
        }

        public static bool NeedToUpdate(GitUIBaseEventArgs gitUiCommands, string brancheName)
        {
            CmdResult gitResult = gitUiCommands.GitModule.RunGitCmdResult("show-ref -s " + brancheName);
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

        public static CmdResult DeleteMergedLocalBranch(GitUIBaseEventArgs gitUiCommands, string branchToDelete)
        {
            return gitUiCommands.GitModule.RunGitCmdResult(string.Format("branch -d {0}", branchToDelete));
        }

        public static CmdResult DeleteUnmergedLocalBranch(GitUIBaseEventArgs gitUiCommands, string branchToDelete)
        {
            return gitUiCommands.GitModule.RunGitCmdResult(string.Format("branch -D {0}", branchToDelete));
        }
        public static CmdResult FetchAll(GitUIBaseEventArgs gitUiCommands)
        {
            CmdResult results = gitUiCommands.GitModule.RunGitCmdResult("fetch -q -n --all");
            gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            return results;
        }

        public static string[] GetStashs(GitUIBaseEventArgs gitUiCommands)
        {
            CmdResult gitResult = gitUiCommands.GitModule.RunGitCmdResult("stash list");
            if (gitResult.ExitCode == 0 && !string.IsNullOrWhiteSpace(gitResult.StdOutput))
            {
                return gitResult.StdOutput.SplitLines();
            }
            return new string[0];
        }

        public static string[] GetDiff(GitUIBaseEventArgs gitUiCommands)
        {
            CmdResult gitResult = gitUiCommands.GitModule.RunGitCmdResult("diff");
            if (gitResult.ExitCode == 0 && !string.IsNullOrWhiteSpace(gitResult.StdOutput))
            {
                return gitResult.StdOutput.SplitLines();
            }
            return new string[0];
        }
        public static bool IfChangedFiles(GitUIBaseEventArgs gitUiCommands)
        {
            return !string.IsNullOrWhiteSpace(gitUiCommands.GitModule.RunGitCmd(GitCommandHelpers.GetAllChangedFilesCmd(true, UntrackedFilesMode.All)));
        }

        #endregion
    }
}
