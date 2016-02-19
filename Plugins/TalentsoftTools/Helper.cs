using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using GitUIPluginInterfaces;

namespace TalentsoftTools
{
    public class Helper
    {
        #region AsyncMethods

        public static async Task<bool> ExitVisualStudioAsync(string solutionFileName)
        {
            var tcs = new TaskCompletionSource<bool>();
            solutionFileName = Path.GetFileNameWithoutExtension(solutionFileName);
            var process = Process.GetProcessesByName("devenv");
            foreach (Process p in process)
            {
                //if (solutionFileName.Equals(p.MainWindowTitle.Split(' ')[0]))
                if (p.MainWindowTitle.Contains(solutionFileName))
                {
                    try
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                    catch (Win32Exception winException)
                    {
                        //tcs.SetResult(false);
                        // process was terminating or can't be terminated - deal with it
                    }
                    catch (InvalidOperationException invalidException)
                    {
                        // tcs.SetResult(false);
                        // process has already exited - might be able to let this one go
                    }
                }
            }
            tcs.SetResult(true);
            return tcs.Task.IsCompleted;
        }

        public static async Task<CmdResult> GitCmdAsync(GitUIBaseEventArgs gitCommands, string command)
        {
            var tcs = new TaskCompletionSource<bool>();
            CmdResult cmdResult = gitCommands.GitModule.RunGitCmdResult(command);
            tcs.SetResult(true);
            await tcs.Task;
            return cmdResult;
        }

        public static async Task<CmdResult> GitStashAsync(GitUIBaseEventArgs gitCommands)
        {
            var tcs = new TaskCompletionSource<bool>();
            CmdResult cmdResult = gitCommands.GitModule.RunGitCmdResult("stash --include-untracked");
            tcs.SetResult(true);
            await tcs.Task;
            return cmdResult;
        }

        public static async Task<CmdResult> GitCheckoutAsync(GitUIBaseEventArgs gitCommands, string branch)
        {
            var tcs = new TaskCompletionSource<bool>();
            CmdResult cmdResult = gitCommands.GitModule.RunGitCmdResult(branch);
            tcs.SetResult(true);
            await tcs.Task;
            return cmdResult;
        }

        public static async Task<CmdResult> GitCleanAsync(GitUIBaseEventArgs gitCommands)
        {
            var tcs = new TaskCompletionSource<bool>();
            CmdResult cmdResult = gitCommands.GitModule.RunGitCmdResult("clean -d -x -f");
            tcs.SetResult(true);
            await tcs.Task;
            return cmdResult;
        }

        public static async Task<bool> BuildAsync(string solutionFileFullPath, string pathToMsBuild)
        {
            var tcs = new TaskCompletionSource<bool>();
            if (string.IsNullOrEmpty(pathToMsBuild) || string.IsNullOrEmpty(solutionFileFullPath))
            {
                tcs.SetResult(false);
            }
            else
            {
                RunCommandLine(new List<string> { $"{pathToMsBuild} /t:Build /p:Configuration=Debug /m:4 {solutionFileFullPath}" });
                tcs.SetResult(true);
            }
            await tcs.Task;
            return tcs.Task.IsCompleted;
            //return await RunCommandLineAsync(new List<string> { $"{validPathToMsBuild} /t:Build /p:Configuration=Debug /m:4 {solutionFileFullPath}" });
        }

        /// <summary>
        /// Restore all nugets.
        /// </summary>
        /// <param name="solutionFileFullPath">Full path of solution file.</param>
        public static async Task<bool> NugetRestoreAsync(string solutionFileFullPath)
        {
            var tcs = new TaskCompletionSource<bool>();
            RunCommandLine(new List<string> { $"nuget restore {solutionFileFullPath}" });
            //return await RunCommandLineAsync(new List<string> { $"nuget restore {solutionFileFullPath}" });
            tcs.SetResult(true);
            await tcs.Task;
            return tcs.Task.IsCompleted;
        }

        private static async Task<bool> RunCommandLineAsync(List<string> commands)
        {
            string output;
            string error;
            // there is no non-generic TaskCompletionSource
            var tcs = new TaskCompletionSource<bool>();
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            var process = new Process
            {
                StartInfo = processStartInfo,
                EnableRaisingEvents = true
            };
            process.Exited += (sender, args) =>
            {
                tcs.SetResult(true);
                process.Dispose();
            };
            process.Start();
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

            process.WaitForExit();
            return tcs.Task.Result;
        }

        #endregion

        public static bool ExitVisualStudio(string solutionFileName)
        {
            solutionFileName = Path.GetFileNameWithoutExtension(solutionFileName);
            var process = Process.GetProcessesByName("devenv");
            foreach (Process p in process)
            {
                //if (solutionFileName.Equals(p.MainWindowTitle.Split(' ')[0]))
                if (p.MainWindowTitle.Contains(solutionFileName))
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

        public static List<string> GetSolutionsFile(string directory)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(directory))
                {
                    if (f.EndsWith(".sln"))
                    {
                        files.Add(f);
                    }
                }
                foreach (string d in Directory.GetDirectories(directory))
                {
                    files.AddRange(GetSolutionsFile(d));
                }
            }
            catch (System.Exception excpt)
            {

            }
            return files;
        }

        /// <summary>
        /// Build solution.
        /// </summary>
        /// <param name="solutionFileFullPath">Full path of solution file to build.</param>
        /// <param name="outputPath">bin\Debug\ / bin\Release\ </param>
        /// <param name="configuration">Debug / Release</param>
        /// <param name="platform">Any CPU / x86 / x64</param>
        /// <param name="buildParams">Params to build. Clean / Build / ReBuild. Default value { "Clean", "Build" }.</param>
        /// <returns></returns>
        public static bool Build(string solutionFileFullPath, string[] buildParams, string outputPath = @"bin\Debug\", string configuration = "Debug", string platform = "Any CPU", string toolsVersion = "4.0")
        {
            if (buildParams == null)
            {
                buildParams = new[] { "Clean", "Build" };
            }

            ProjectCollection projectCollection = new ProjectCollection();

            var globalProperty = new Dictionary<string, string>
                                     {
                                         { "EnableNuGetPackageRestore", "true" },
                                         { "OutputPath", outputPath },
                                         { "Configuration", configuration },
                                         { "Platform", platform }
                                     };

            BuildParameters buildParameters = new BuildParameters(projectCollection);
            BuildRequestData buidlRequest = new BuildRequestData(
                solutionFileFullPath,
                globalProperty,
                toolsVersion,
                buildParams,
                null);
            BuildResult buildResult = BuildManager.DefaultBuildManager.Build(buildParameters, buidlRequest);

            if (buildResult.OverallResult == BuildResultCode.Success)
            {
                return true;
            }
            return false;
        }

        public static bool Build(string solutionFileFullPath, string pathToMsBuild)
        {
            //string validPathToMsBuild = GetMsBuildPath();
            if (string.IsNullOrEmpty(pathToMsBuild) || string.IsNullOrEmpty(solutionFileFullPath))
            {
                return false;
            }
            return RunCommandLine(new List<string> { $"{pathToMsBuild} /t:Build /p:Configuration=Debug /m:4 {solutionFileFullPath}" });
        }

        private static bool RunCommandLine(List<string> commands)
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
            if (!string.IsNullOrEmpty(error))
            {
                return false;
            }
            return true;
        }

        public static bool LaunchVisualStudio(string solutionFileFullPath)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(solutionFileFullPath) { UseShellExecute = true };
            try
            {
                Process.Start(processStartInfo);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public static bool LaunchWebUri(string uri)
        {
            try
            {
                Process.Start(uri);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
