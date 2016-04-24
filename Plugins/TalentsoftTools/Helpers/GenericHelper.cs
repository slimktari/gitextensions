namespace TalentsoftTools.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;
    using System.Reflection;

    public class GenericHelper
    {
        /// <summary>
        /// Gets the <see cref="Generic.VisualStudioVersion"/> according to a solution file.
        /// </summary>
        /// <param name="solutionFullPath">The solution file full path.</param>
        /// <returns>The <see cref="Generic.VisualStudioVersion"/>.</returns>
        public static Generic.VisualStudioVersion GetSolutionVersion(string solutionFullPath)
        {
            Type _solutionParser;
            PropertyInfo solutionParser_version;
            PropertyInfo solutionParser_solutionReader;
            MethodInfo solutionParser_parseSolution;


            _solutionParser = Type.GetType("Microsoft.Build.Construction.SolutionParser, Microsoft.Build, version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", false, false);

            if (_solutionParser == null)
            {

                throw new Exception("Can't load msbuild assembly. Is .Net FX 4.0 installed?");
            }

            solutionParser_solutionReader = _solutionParser.GetProperty("SolutionReader", BindingFlags.NonPublic | BindingFlags.Instance);
            solutionParser_version = _solutionParser.GetProperty("version", BindingFlags.NonPublic | BindingFlags.Instance);
            solutionParser_parseSolution = _solutionParser.GetMethod("ParseSolution", BindingFlags.NonPublic | BindingFlags.Instance);
            solutionParser_version = _solutionParser.GetProperty("Version", BindingFlags.NonPublic | BindingFlags.Instance);


            var solutionParserInstance = _solutionParser.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic)[0].Invoke(null);
            using (var streamReader = new StreamReader(solutionFullPath))
            {
                solutionParser_solutionReader.SetValue(solutionParserInstance, streamReader, null);
                solutionParser_parseSolution.Invoke(solutionParserInstance, null);
            }


            var solutionFileFormatNumber = solutionParser_version.GetValue(solutionParserInstance, null);

            return ConvertVsVersion(Convert.ToInt32(solutionFileFormatNumber));
        }

        /// <summary>
        /// Converts from Visual Studio version number to <see cref="Generic.VisualStudioVersion"/>.
        /// </summary>
        /// <param name="version">Visual Studio version number.</param>
        /// <returns>The <see cref="Generic.VisualStudioVersion"/>.</returns>
        private static Generic.VisualStudioVersion ConvertVsVersion(int version)
        {
            if (version > 14)
            {
                return Generic.VisualStudioVersion.VsNext;
            }
            if (version == 14) { return Generic.VisualStudioVersion.Vs2015; }
            if (version == 12) return Generic.VisualStudioVersion.Vs2013;
            if (version == 11) return Generic.VisualStudioVersion.Vs2010;
            if (version == 10) return Generic.VisualStudioVersion.Vs2008;
            if (version == 9) return Generic.VisualStudioVersion.Vs2005;
            if (version == 8) return Generic.VisualStudioVersion.Vs2003;

            return Generic.VisualStudioVersion.Previous;
        }

        /// <summary>
        /// Gets the MSBuild path according th <see cref="Generic.VisualStudioVersion"/>.
        /// </summary>
        /// <param name="version">The <see cref="Generic.VisualStudioVersion"/> to define version of Visual Studio.</param>
        /// <returns>Path to MsBuild.</returns>
        public static string GetMsBuildPath(Generic.VisualStudioVersion version)
        {
            switch (version)
            {
                case Generic.VisualStudioVersion.Vs2003:
                    if (File.Exists(Generic.PathToVisualStudio8))
                    {
                        return Generic.PathToVisualStudio8;
                    }
                    goto default;
                case Generic.VisualStudioVersion.Vs2005:
                    if (File.Exists(Generic.PathToVisualStudio9))
                    {
                        return Generic.PathToVisualStudio9;
                    }
                    goto default;
                case Generic.VisualStudioVersion.Vs2008:
                    if (File.Exists(Generic.PathToVisualStudio10))
                    {
                        return Generic.PathToVisualStudio10;
                    }
                    goto default;
                case Generic.VisualStudioVersion.Vs2010:
                    if (File.Exists(Generic.PathToVisualStudio11))
                    {
                        return Generic.PathToVisualStudio11;
                    }
                    goto default;
                case Generic.VisualStudioVersion.Vs2013:
                    if (File.Exists(Generic.PathToVisualStudio12))
                    {
                        return Generic.PathToVisualStudio12;
                    }
                    goto default;
                default:
                    if (File.Exists(Generic.PathToVisualStudio14))
                    {
                        return Generic.PathToVisualStudio14;
                    }
                    return string.Empty;
            }
        }

        /// <summary>
        /// Kill visual studio process.
        /// </summary>
        /// <param name="solutionFileName">Solution name.</param>
        /// <returns>True if there is no exception when exit solution.</returns>
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
                    catch (Exception exception)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Get solutions files from directory.
        /// </summary>
        /// <param name="directory">Directory path.</param>
        /// <param name="currentDepth">Depth number.</param>
        /// <returns>A dictionary, the key is solution file name and the value is the path to this file.</returns>
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

        /// <summary>
        /// Build solution with devenv program.
        /// </summary>
        /// <param name="solutionFileFullPath">Solution file path.</param>
        /// <param name="argument">Arguments tu build.</param>
        /// <returns></returns>
        public static string Build(string solutionFileFullPath, Generic.GenrateSolutionArguments argument)
        {
            if (string.IsNullOrEmpty(solutionFileFullPath))
            {
                return "Error : No solution file !";
            }

            string logFileName = Path.GetTempFileName();
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = @"devenv.exe",
                ErrorDialog = true,
                Arguments = string.Format(@"/{0} Debug /out {1} {2}", argument, logFileName, solutionFileFullPath)
            };
            Process process = Process.Start(processStartInfo);
            if (process != null)
            {
                process.WaitForExit();
                int exitCode = process.ExitCode;
                process.Close();
                if (exitCode != 0)
                {
                    TextReader reader = File.OpenText(logFileName);
                    string errorLog = reader.ReadToEnd();
                    reader.Close();
                    return errorLog;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Invokes MsBuild.
        /// </summary>
        /// <param name="solutionFileFullPath">Solution file path.</param>
        /// <param name="argument">Build or Rebuild.</param>
        /// <param name="errors">Errors if exist.</param>
        /// <returns>True if success, false otherwise.</returns>
        public static bool InvokeMsBuild(string solutionFileFullPath, Generic.GenrateSolutionArguments argument, ref string errors)
        {
            string msBuildFile = GetMsBuildPath(GetSolutionVersion(solutionFileFullPath));
            string arguments = "/nr:false /verbosity:quiet " +
                               //"/consoleloggerparameters:EnableMPLogging " +
                               //$"/t:Clean;{argument} " +
                               $"/t:{argument} " +
                               "/p:BuildInParallel=true " +
                               "/p:Configuration=Debug " +
                               $"/maxcpucount \"{solutionFileFullPath}\"";
            
            RunCommandLine(msBuildFile, arguments, ref errors);

            if (!string.IsNullOrWhiteSpace(errors))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Run command line.
        /// </summary>
        /// <param name="commands">Commands texts.</param>
        /// <param name="errorMessages">Error messages.</param>
        /// <returns>True if there is no exceptions, false otherwise.</returns>
        public static bool RunCommandLine(List<string> commands, ref string errorMessages)
        {
            string output = string.Empty;
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.ErrorDialog = false;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.Verb = "runas";

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
                errorMessages = streamReader.ReadToEnd();
            }
            process.WaitForExit();


            if (!string.IsNullOrEmpty(errorMessages) || process.ExitCode != 0)
            {
                return false;
            }
            return true;
        }

        public static bool RunCommandLine(string fileName,string arguments, ref string errorMessages)
        {
            string output;
            ProcessStartInfo processStartInfo = new ProcessStartInfo(Generic.PathToVisualStudio14);
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.Arguments = arguments;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processStartInfo.ErrorDialog = false;
            processStartInfo.UseShellExecute = false;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.Verb = "runas";

            Process process = Process.Start(processStartInfo);
            using (StreamReader streamReader = process.StandardOutput)
            {
                output = streamReader.ReadToEnd();
            }
            process.WaitForExit();
            if (process.ExitCode != 0)
            {
                errorMessages = output;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Launch visual studio solution.
        /// </summary>
        /// <param name="solutionFileFullPath">Solution file path.</param>
        /// <returns>True if there is no exceptions, false otherwise.</returns>
        public static bool LaunchVisualStudio(string solutionFileFullPath)
        {
            if (string.IsNullOrWhiteSpace(solutionFileFullPath))
            {
                return false;
            }
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.Verb = "runas";
            processStartInfo.FileName = Generic.PathToVsLauncher;
            processStartInfo.Arguments = solutionFileFullPath;
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

        /// <summary>
        /// Launch web URI.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>True if there is no exceptions, false otherwise.</returns>
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
    }
}
