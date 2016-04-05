namespace TalentsoftTools.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Windows.Forms;

    public class GenericHelper
    {
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
        /// Run command line.
        /// </summary>
        /// <param name="commands">Commands texts.</param>
        /// <returns>True if there is no exceptions, false otherwise.</returns>
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
                error = streamReader.ReadToEnd();
            }
            process.WaitForExit();
            if (!string.IsNullOrEmpty(error) || process.ExitCode != 0)
            {
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
            processStartInfo.FileName = "devenv.exe";
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
