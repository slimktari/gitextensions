using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GitCommands;
using GitUIPluginInterfaces;
using TalentsoftTools.Helpers;

namespace TalentsoftTools
{
    public partial class TalentsoftToolsForm
    {
        private void BtnDsbExitSolutionClick(object sender, EventArgs e)
        {
            PbxDsbLoadingAction.Visible = true;
            string message;
            bool isExited = GenericHelper.ExitVisualStudio(CblDsbSolutions.SelectedItem.ToString());
            if (isExited)
            {
                message = CblDsbSolutions.SelectedItem + " is exited !";
            }
            else
            {
                message = "Error when exiting " + CblDsbSolutions.SelectedItem + " !";
            }
            PbxDsbLoadingAction.Visible = false;
            MessageBox.Show(message, "Talentsoft Tools", MessageBoxButtons.OK);
        }

        private void BtnDsbBuildSolutionClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunDsbBuildSolution);
        }

        void RunDsbBuildSolution()
        {
            string message;
            string solutionFileFullPath = null;
            string solutionFile = null;
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = false;
                PbxDsbLoadingAction.Visible = true;
                solutionFile = CblDsbSolutions.SelectedItem.ToString();
                solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
            }));
            if (string.IsNullOrWhiteSpace(GenericHelper.Build(solutionFileFullPath, Generic.GenrateSolutionArguments.Build)))
            {
                message = "Success of Building solution " + solutionFile;
            }
            else
            {
                message = "Error when Building solution " + solutionFile;
            }
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = true;
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, "Talentsoft Tools", MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbNugetRestoreClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunDsbNugetRestore);
        }

        void RunDsbNugetRestore()
        {
            string message;
            string solutionFileFullPath = null;
            string solutionFile = null;
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = false;
                PbxDsbLoadingAction.Visible = true;
                solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
                solutionFile = CblDsbSolutions.SelectedItem.ToString();
            }));
            if (GenericHelper.RunCommandLine(new List<string>
                {
                    string.Format("nuget restore {0}", solutionFileFullPath)
                }))
            {
                message = "Nuget restored for solution " + solutionFile;
            }
            else
            {
                message = "Error when restoring nuget for solution " + solutionFile;
            }
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = true;
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, "Talentsoft Tools", MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbRebuildSolutionClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunDsbRebuildSolution);
        }

        void RunDsbRebuildSolution()
        {
            string message;
            string solutionFileFullPath = null;
            string solutionFile = null;
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = false;
                PbxDsbLoadingAction.Visible = true;
                solutionFile = CblDsbSolutions.SelectedItem.ToString();
                solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
            }));
            if (string.IsNullOrWhiteSpace(GenericHelper.Build(solutionFileFullPath, Generic.GenrateSolutionArguments.Rebuild)))
            {
                message = "Success of Rebuilding solution " + solutionFile;
            }
            else
            {
                message = "Error when Rebuilding solution " + solutionFile;
            }
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = true;
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, "Talentsoft Tools", MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbStartSolutionClick(object sender, EventArgs e)
        {
            PbxDsbLoadingAction.Visible = true;
            string message;
            string solutionFileFullPath = SolutionDictionary.FirstOrDefault(x => x.Key == CblDsbSolutions.SelectedItem.ToString()).Value;
            if (GenericHelper.LaunchVisualStudio(solutionFileFullPath))
            {
                message = "Success of launching solution " + CblDsbSolutions.SelectedItem;
            }
            else
            {
                message = "Error when launching solution " + CblDsbSolutions.SelectedItem;
            }
            PbxDsbLoadingAction.Visible = false;
            MessageBox.Show(message, "Talentsoft Tools", MessageBoxButtons.OK);
        }

        private void BtnDsbRestoreDatabasesClick(object sender, EventArgs e)
        {
            if (ValidateRestoreDatabasesFromDashboard())
            {
                System.Threading.Tasks.Task.Factory.StartNew(RunDsbRestoreDatabases);
            }
        }

        void RunDsbRestoreDatabases()
        {
            StringBuilder message = new StringBuilder();
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = false;
                PbxDsbLoadingAction.Visible = true;
                }));
            foreach (var database in Databases)
            {
                if (DatabaseHelper.RestoreDatabase(database.DatabaseName, database.BackupFilePath,
                    database.ServerName, database.UserId, database.Password, database.PathToRelocate,
                    database.PathToRelocate))
                {
                    message.Append(string.Format("\r\nSuccess of the restoration {0} database.", database.DatabaseName));
                }
                else
                {
                    message.Append(string.Format("\r\nError when restoring {0} database.", database.DatabaseName));
                }
            }
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = true;
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message.ToString(), "Talentsoft Tools", MessageBoxButtons.OK);
            }));
        }

        bool ValidateRestoreDatabasesFromDashboard()
        {
            string message = string.Empty;
            Databases = DatabaseHelper.GetDatabasesFromPameters(TalentsoftToolsPlugin.DatabaseConnectionParams[_settings], TxbDatabases.Text);
            if (string.IsNullOrWhiteSpace(TxbDsbDatabases.Text) || Databases.Any(d => string.IsNullOrWhiteSpace(d.DatabaseName) || string.IsNullOrWhiteSpace(d.BackupFilePath)))
            {
                message = "Databases not correctly defined.";
            }
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }

        private void BtnDsbGitCleanClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunDsbGitClean);
        }

        void RunDsbGitClean()
        {
            string message;
            string excludeCommand = string.Empty;

            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = false;
                PbxDsbLoadingAction.Visible = true;
                if (!string.IsNullOrWhiteSpace(TxbDsbGitClean.Text))
                {
                    excludeCommand = string.Format(" -e=\"{0}\"", TxbDsbGitClean.Text);
                }
            }));
            CmdResult gitCleanResult = GitHelper.Clean(excludeCommand);
            if (gitCleanResult.ExitCode != 0)
            {
                message = gitCleanResult.StdError;
            }
            else
            {
                message = "Success of cleaning directory !";
            }
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = true;
                PbxDsbLoadingAction.Visible = false;
                MessageBox.Show(message, "Talentsoft Tools", MessageBoxButtons.OK);
            }));
        }

        private void BtnDsbFetchAllClick(object sender, EventArgs e)
        {
            PbxDsbLoadingAction.Visible = true;
            CmdResult results = GitHelper.FetchAll();
            GitHelper.NotifyGitExtensions();
            if (results.ExitCode != 0)
            {
                MessageBox.Show(results.StdError, "Error", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Fetching success !", "Talentsoft tools", MessageBoxButtons.OK);
            }
            PbxDsbLoadingAction.Visible = false;
        }

        private void BtnDsbExitAllVisualStudioClick(object sender, EventArgs e)
        {
            PbxDsbLoadingAction.Visible = true;
            string message;
            bool isExited = GenericHelper.ExitVisualStudio(string.Empty);
            if (isExited)
            {
                message = "All Visual Studio instances are exited !";
            }
            else
            {
                message = "Error when exiting all Visual Studio instances !";
            }
            PbxDsbLoadingAction.Visible = false;
            MessageBox.Show(message, "Talentsoft Tools", MessageBoxButtons.OK);
        }

        private void BtnDsbStashChangesClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunStashChanges);
        }

        void RunStashChanges()
        {
            bool canStash = GitHelper.IfChangedFiles();
            if (!canStash)
            {
                MessageBox.Show("There is no change to stash !", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    TbcMain.Enabled = false;
                    PbxDsbLoadingAction.Visible = true;
                }));
                CmdResult gitStashResult = GitHelper.StashChanges();
                if (gitStashResult.ExitCode != 0)
                {
                    MessageBox.Show(gitStashResult.StdError, "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Stash changes success", "Talentsoft Tools", MessageBoxButtons.OK);
                }
                Invoke((MethodInvoker)(() =>
                {
                    TbcMain.Enabled = true;
                    PbxDsbLoadingAction.Visible = false;
                }));
            }
        }

        private void BtnDsbStashPopClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunStashPop);
        }

        void RunStashPop()
        {
            bool canStashPop = GitHelper.GetStashs().Any();
            if (!canStashPop)
            {
                MessageBox.Show("There is no stash to pop !", "Error", MessageBoxButtons.OK);
            }
            else
            {
                Invoke((MethodInvoker)(() =>
                {
                    TbcMain.Enabled = false;
                    PbxDsbLoadingAction.Visible = true;
                }));
                CmdResult gitStashPopResult = GitHelper.StashPop();
                if (gitStashPopResult.ExitCode != 0)
                {
                    MessageBox.Show(gitStashPopResult.StdError, "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Stash pop success", "Error", MessageBoxButtons.OK);
                }
                Invoke((MethodInvoker)(() =>
                {
                    TbcMain.Enabled = true;
                    PbxDsbLoadingAction.Visible = false;
                }));
            }
        }

        private void BtnDsbRunScriptPrebuildClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunPreBuild);
        }

        void RunPreBuild()
        {
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = false;
                PbxDsbLoadingAction.Visible = true;
            }));
            if (GenericHelper.RunCommandLine(PreBuildFiles.ToList()))
            {
                MessageBox.Show("Commands PreBuild success !", "Talentsoft Tools", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error when launching commands PreBuild !", "Error", MessageBoxButtons.OK);
            }
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = true;
                PbxDsbLoadingAction.Visible = false;
            }));
        }

        private void BtnDsbRunScriptPostbuildClick(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task.Factory.StartNew(RunPostBuild);
        }

        void RunPostBuild()
        {
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = false;
                PbxDsbLoadingAction.Visible = true;
            }));
            if (GenericHelper.RunCommandLine(PostBuildFiles.ToList()))
            {
                MessageBox.Show("Commands PostBuild success !", "Talentsoft Tools", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Error when launching commands PostBuild !", "Error", MessageBoxButtons.OK);
            }
            Invoke((MethodInvoker)(() =>
            {
                TbcMain.Enabled = true;
                PbxDsbLoadingAction.Visible = false;
            }));
        }
    }
}
