using System.Collections.Generic;

namespace TalentsoftTools
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;

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
                        files.Add(Path.GetFileName(f));
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
            NugetRestore(solutionFileFullPath);

            if (buildParams == null)
            {
                buildParams = new[] { "Clean", "Build" };
            }

            ProjectCollection projectCollection = new ProjectCollection();

            var globalProperty = new Dictionary<string, string>();
            globalProperty.Add("EnableNuGetPackageRestore", "true");
            globalProperty.Add("OutputPath", outputPath);
            globalProperty.Add("Configuration", configuration);
            globalProperty.Add("Platform", platform);

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

        /// <summary>
        /// Restore all nugets.
        /// </summary>
        /// <param name="solutionFileFullPath">Full path of solution file.</param>
        public static void NugetRestore(string solutionFileFullPath)
        {
            Process.Start("CMD.exe", "NUGET RESTORE" + solutionFileFullPath);
        }

        public static void ExitVisualStudio(string solutionFileName)
        {
            solutionFileName = Path.GetFileNameWithoutExtension(solutionFileName)+" ";
            var process = Process.GetProcessesByName("devenv");
            foreach (Process p in process)
            {
                try
                {
                    if (solutionFileName.Equals(p.MainWindowTitle.Split('-')[0]))
                    {
                        p.Kill();
                        p.WaitForExit(); // possibly with a timeout
                    }
                }
                catch (Win32Exception winException)
                {
                    // process was terminating or can't be terminated - deal with it
                }
                catch (InvalidOperationException invalidException)
                {
                    // process has already exited - might be able to let this one go
                }
            }
        }
    }
}
