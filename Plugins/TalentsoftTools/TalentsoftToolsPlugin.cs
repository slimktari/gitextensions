using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Forms;
using GitUIPluginInterfaces;
using ResourceManager;

namespace TalentsoftTools
{
    public class TalentsoftToolsPlugin : GitPluginBase, IGitPluginForRepository
    {
        public static BoolSetting IsDefaultExitAndStartVisualStudio =
            new BoolSetting("Is default exit and start Visual Studio", true);

        public static BoolSetting IsDefaultStashChanges = new BoolSetting("Is default stash changes", true);
        public static BoolSetting IsDefaultCheckoutBranch = new BoolSetting("Is default checkout branch", true);
        public static BoolSetting IsDefaultGitClean = new BoolSetting("Is default git clean", true);
        public static BoolSetting IsDefaultStashPop = new BoolSetting("Is default stash pop", true);
        public static BoolSetting IsDefaultResetDatabases = new BoolSetting("Is default reset databases", true);
        public static BoolSetting IsDefaultNugetRestore = new BoolSetting("Is default Nuget restore", true);
        public static BoolSetting IsDefaultBuildSolution = new BoolSetting("Is default build solution", true);
        public static BoolSetting IsDefaultRunUri = new BoolSetting("Is default execute URI", true);
        public static StringSetting LocalUriWebApplication =
            new StringSetting("Local URIs web application (separator ;)", string.Empty);
        public static StringSetting DefaultSolutionFileName =
            new StringSetting("Default solution file (Eg: TalentSoft.sln)", string.Empty);
        public static StringSetting ExcludePatternGitClean = new StringSetting("Pattern exclude files Git Clean",
            "*.mdf *.ldf");
        public static StringSetting NewBranchPrefix = new StringSetting("Branch name prefix", string.Empty);
        public static StringSetting PreBuildBatch = new StringSetting("Pre-Build batch (separator ;)", string.Empty);
        public static StringSetting PostBuildBatch = new StringSetting("Post-Build batch (separator ;)", string.Empty);
        public static StringSetting DatabaseConnectionParams = new StringSetting("Database connection parameters",
            @"Data Source=.;User ID=ASPNET;Password=aspasp;RelocateDataFilePath=C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\");
        public static StringSetting DatabasesToRestore = new StringSetting("Databases to restore",
            @"Initial Catalog=TSDEV;BackupFilePath=;");
        public static NumberSetting<int> CheckInterval =
                    new NumberSetting<int>("Check branch if update every (seconds) - set to 0 to disable", 0);

        private bool _isMonitorRunnig;
        private IDisposable cancellationToken;
        private IGitUICommands currentGitUiCommands;
        public static StringSetting BranchesToMonitor = new StringSetting("Branches to monitor", string.Empty);

        public TalentsoftToolsPlugin()
        {
            Description = "Talentsoft tools";
            //Translate();
        }


        public override void Register(IGitUICommands gitUiCommands)
        {
            base.Register(gitUiCommands);
            currentGitUiCommands = gitUiCommands;
            currentGitUiCommands.PostSettings += OnPostSettings;
            RecreateObservable();
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            using (var frm = new TalentsoftToolsForm(gitUiCommands, Settings))
            {
                frm.ShowDialog(gitUiCommands.OwnerForm);
                return true;
            }
        }

        public override IEnumerable<ISetting> GetSettings()
        {
            yield return LocalUriWebApplication;
            yield return PreBuildBatch;
            yield return PostBuildBatch;
            yield return DefaultSolutionFileName;
            yield return NewBranchPrefix;
            yield return ExcludePatternGitClean;
            yield return DatabaseConnectionParams;
            yield return DatabasesToRestore;
            yield return CheckInterval;
            yield return IsDefaultExitAndStartVisualStudio;
            yield return IsDefaultStashChanges;
            yield return IsDefaultCheckoutBranch;
            yield return IsDefaultGitClean;
            yield return IsDefaultStashPop;
            yield return IsDefaultNugetRestore;
            yield return IsDefaultBuildSolution;
            yield return IsDefaultResetDatabases;
            yield return IsDefaultRunUri;
        }

        private void OnPostSettings(object sender, GitUIPostActionEventArgs e)
        {
            RecreateObservable();
        }

        private void RecreateObservable()
        {
            CancelBackgroundOperation();
            int fetchInterval = CheckInterval[Settings];
            var gitModule = currentGitUiCommands.GitModule;
            if (fetchInterval > 0 && gitModule.IsValidGitWorkingDir())
            {
                currentGitUiCommands.GitModule.RunGitCmdResult("fetch -q -n --all");
                currentGitUiCommands.RepoChangedNotifier.Notify();
                cancellationToken =
                   Observable.Timer(TimeSpan.FromSeconds(Math.Max(5, fetchInterval)))
                              .SkipWhile(i => gitModule.IsRunningGitProcess() || _isMonitorRunnig)
                              .Repeat()
                              .ObserveOn(ThreadPoolScheduler.Instance)
                              .Subscribe(i => MonitorTask());
            }
        }

        void MonitorTask()
        {
            if (!string.IsNullOrWhiteSpace(BranchesToMonitor[Settings]))
            {
                var tab = BranchesToMonitor[Settings].Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                if (tab.Any())
                {
                    _isMonitorRunnig = true;
                    foreach (var item in tab)
                    {
                        var remotes = NeedToUpdate(item);
                        if (remotes.Any())
                        {
                            var resultFormDialog = new MonitorActionsForm(BranchesToMonitor, Settings, currentGitUiCommands, remotes, item).ShowDialog();
                            if (resultFormDialog == DialogResult.OK)
                            {
                                break;
                            }
                            //DialogResult dialogResult = MessageBox.Show(item + " must be updated.\nWould you like to rebase this branch ?\nClick on no if you would disable notifications for this branch.", "Talentsoft Tools", MessageBoxButtons.YesNoCancel);
                            //if (dialogResult == DialogResult.Yes)
                            //{
                            //    Application.OpenForms[0].BeginInvoke((ThreadStart)delegate { currentGitUiCommands.StartRebaseDialog(item); });
                            //    foreach (var form in Application.OpenForms)
                            //    {
                            //        var pluginForm = form as TalentsoftToolsForm;
                            //        if (pluginForm != null)
                            //        {
                            //            pluginForm.LoadLocalBranches();
                            //            pluginForm.SetLocalBranchesGrid();
                            //            pluginForm.UpdateNotifications();
                            //            pluginForm.SetLocalBranchesGrid();
                            //        }
                            //    }
                            //}
                            //else if (dialogResult == DialogResult.No)
                            //{
                            //    BranchesToMonitor[Settings] = string.Join(";", BranchesToMonitor[Settings].Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).Where(x => x != item).ToList());
                            //    foreach (var form in Application.OpenForms)
                            //    {
                            //        var pluginForm = form as TalentsoftToolsForm;
                            //        if (pluginForm != null)
                            //        {
                            //            pluginForm.SetLocalBranchesGrid();
                            //        }
                            //    }
                            //}
                        }
                    }
                    _isMonitorRunnig = false;
                }
            }
        }

        private void CancelBackgroundOperation()
        {
            if (cancellationToken != null)
            {
                cancellationToken.Dispose();
                cancellationToken = null;
            }
        }

        public override void Unregister(IGitUICommands gitUiCommands)
        {
            CancelBackgroundOperation();
            if (currentGitUiCommands != null)
            {
                currentGitUiCommands.PostSettings -= OnPostSettings;
                currentGitUiCommands = null;
            }

            base.Unregister(gitUiCommands);
        }

        public List<string> NeedToUpdate(string brancheName)
        {
            if (currentGitUiCommands != null)
            {
                CmdResult gitResult = currentGitUiCommands.GitModule.RunGitCmdResult("show-ref " + brancheName);
                if (gitResult.ExitCode == 0)
                {
                    List<string> results = gitResult.StdOutput.SplitLines().ToList();
                    if (results.Any(x => !string.IsNullOrWhiteSpace(results.FirstOrDefault()) && results.FirstOrDefault().Split(' ')[0] != x.Split(' ')[0]))
                    {
                        return results.Select(x => x.Split(' ')[1]).Where(x => !string.IsNullOrWhiteSpace(x) && x.Contains("refs/remotes/")).Select(x => x.Replace("refs/remotes/", string.Empty)).ToList();
                    }
                    return new List<string>();
                }
            }
            return new List<string>();
        }
    }
}
