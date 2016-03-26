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
    }
}
