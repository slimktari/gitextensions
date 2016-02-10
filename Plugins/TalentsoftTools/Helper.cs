using System.Collections.Generic;

namespace TalentsoftTools
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security.Principal;
    using System.Text.RegularExpressions;

    using GitCommands;
    using GitCommands.Config;

    using GitUIPluginInterfaces;

    using Microsoft.Build.Evaluation;
    using Microsoft.Build.Execution;

    public static class Helper
    {
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

        public static bool Build(string solutionFileFullPath)
        {
            string validPathToMsBuild = GetMsBuildPath();
            if (string.IsNullOrEmpty(validPathToMsBuild))
            {
                return false;
            }
            return RunCommandLine(new List<string> { $"{validPathToMsBuild} /t:Build /p:Configuration=Debug /m:4 {solutionFileFullPath}" });
        }

        private static string GetMsBuildPath()
        {
            List<string> pathsToMsBuild = new List<string>
                                             {
                                                 "C:/Windows/Microsoft.NET/Framework/v4.0.30319/MsBuild.exe",
                                                 "C:/Windows/Microsoft.Net/Framework/v3.5/MsBuild.exe",
                                                 "C:/Windows/Microsoft.Net/Framework/v2.0.50727/MsBuild.exe"
                                             };
            foreach (var pathToMsBuild in pathsToMsBuild)
            {
                if (File.Exists(pathToMsBuild))
                {
                    return pathToMsBuild;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Restore all nugets.
        /// </summary>
        /// <param name="solutionFileFullPath">Full path of solution file.</param>
        public static bool NugetRestore(string solutionFileFullPath)
        {
            return RunCommandLine(new List<string> { $"nuget restore {solutionFileFullPath}" });
        }

        public static bool ExitVisualStudio(string solutionFileName)
        {
            solutionFileName = Path.GetFileNameWithoutExtension(solutionFileName) + " ";
            var process = Process.GetProcessesByName("devenv");
            foreach (Process p in process)
            {
                if (solutionFileName.Equals(p.MainWindowTitle.Split('-')[0]))
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

        //public static Settings Parse(IGitModule gitModule, ISettingsSource setting)
        //{
        //    var result = new Settings
        //    {
        //        Username = StashPlugin.StashUsername[setting],
        //        Password = StashPlugin.StashPassword[setting],
        //        StashUrl = StashPlugin.StashBaseURL[setting],
        //        DisableSSL = StashPlugin.StashDisableSSL[setting].Value
        //    };

        //    var module = ((GitModule)gitModule);

        //    var remotes = module.GetRemotes()
        //        .Select(r => module.GetPathSetting(string.Format(SettingKeyString.RemoteUrl, r)))
        //        .ToArray();

        //    foreach (var url in remotes)
        //    {
        //        var pattern = url.Contains("http") ? StashHttpRegex : StashSshRegex;
        //        var match = Regex.Match(url, pattern);
        //        if (match.Success && result.StashUrl.Contains(match.Groups["url"].Value))
        //        {
        //            result.ProjectKey = match.Groups["project"].Value;
        //            result.RepoSlug = match.Groups["repo"].Value;
        //            return result;
        //        }
        //    }

        //    return null;
        //}
    }
}
