namespace TalentsoftTools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reactive.Concurrency;
    using System.Reactive.Linq;
    using System.Threading;
    using System.Windows.Forms;
    using GitUIPluginInterfaces;
    using ResourceManager;
    using Helpers;

    public class TalentsoftToolsPlugin : GitPluginBase, IGitPluginForRepository
    {
        #region Settings

        public static BoolSetting IsDefaultExitVisualStudio = new BoolSetting("Is default exit Visual Studio", true);
        public static BoolSetting IsDefaultStartVisualStudio = new BoolSetting("Is default start Visual Studio", true);
        public static BoolSetting IsDefaultStashChanges = new BoolSetting("Is default stash changes", false);
        public static BoolSetting IsDefaultCheckoutBranch = new BoolSetting("Is default checkout branch", true);
        public static BoolSetting IsDefaultGitClean = new BoolSetting("Is default git clean", false);
        public static BoolSetting IsDefaultStashPop = new BoolSetting("Is default stash pop", false);
        public static BoolSetting IsDefaultResetDatabases = new BoolSetting("Is default reset databases", true);
        public static BoolSetting IsDefaultNugetRestore = new BoolSetting("Is default Nuget restore", true);
        public static BoolSetting IsDefaultBuildSolution = new BoolSetting("Is default build solution", true);
        public static BoolSetting IsDefaultRunUri = new BoolSetting("Is default execute URI", true);
        public static BoolSetting IsDefaultPreBuildScripts = new BoolSetting("Is default PreBuild scripts", true);
        public static BoolSetting IsDefaultPostBuildProcess = new BoolSetting("Is default PostBuild scripts", true);
        public static StringSetting LocalUriWebApplication = new StringSetting("Local URIs web application (separator ;)", string.Empty);
        public static StringSetting DefaultSolutionFileName = new StringSetting("Default solution file (Eg: TalentSoft.sln)", Generic.DefaultSolutionFileName);
        public static StringSetting ExcludePatternGitClean = new StringSetting("Pattern exclude files Git Clean", Generic.DefaultGitCleanExcludePattern);
        public static StringSetting NewBranchPrefix = new StringSetting("Branch name prefix", string.Empty);
        public static StringSetting PreBuildBatch = new StringSetting("Pre-Build batch (separator ;)", string.Empty);
        public static StringSetting PostBuildBatch = new StringSetting("Post-Build batch (separator ;)", string.Empty);
        public static StringSetting DatabaseServerName = new StringSetting("Database server name", Generic.DefaultDatabaseServer);
        public static StringSetting DatabaseRelocateFile = new StringSetting("Database relocate file", String.Empty);
        public static StringSetting DatabasesToRestore = new StringSetting("Databases to restore", @"Initial Catalog=TSDEV;BackupFilePath=;");
        public static NumberSetting<int> CheckInterval = new NumberSetting<int>("Check branch if update every (seconds) - set to 0 to disable", Generic.DisableValueCheckMonitoInterval);
        public static StringSetting BranchesToMonitor = new StringSetting("Branches to monitor", string.Empty);

        #endregion

        private bool _isMonitorRunnig;
        private IDisposable _cancellationToken;
        private static IGitUICommands _currentGitUiCommands;
        public static GitUIBaseEventArgs GitUiCommands;
        public static ISettingsSource PluginSettings;

        /// <summary>
        /// Constructor of plugin.
        /// </summary>
        public TalentsoftToolsPlugin()
        {
            Description = Generic.PluginName;
            //Translate();
        }

        /// <summary>
        /// When register plugin. Before launching plugin and after choose repository.
        /// </summary>
        /// <param name="gitUiCommands">The <see cref="IGitUICommands"/>.</param>
        public override void Register(IGitUICommands gitUiCommands)
        {
            base.Register(gitUiCommands);
            _currentGitUiCommands = gitUiCommands;
            PluginSettings = Settings;
            _currentGitUiCommands.PostSettings += OnPostSettings;
            RecreateObservable();
        }

        /// <summary>
        /// When launching plugin.
        /// </summary>
        /// <param name="gitUiCommands">The <see cref="GitUIBaseEventArgs"/>.</param>
        /// <returns></returns>
        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            GitUiCommands = gitUiCommands;
            PluginSettings = Settings;
            using (var frm = new TalentsoftToolsForm(Settings))
            {
                frm.ShowDialog(gitUiCommands.OwnerForm);
                return true;
            }
        }

        /// <summary>
        /// When exit GitExtension or changes repository.
        /// </summary>
        /// <param name="gitUiCommands">The <see cref="IGitUICommands"/>.</param>
        public override void Unregister(IGitUICommands gitUiCommands)
        {
            CancelBackgroundOperation();
            if (_currentGitUiCommands != null)
            {
                _currentGitUiCommands.PostSettings -= OnPostSettings;
                _currentGitUiCommands = null;
            }

            base.Unregister(gitUiCommands);
        }

        private void OnPostSettings(object sender, GitUIPostActionEventArgs e)
        {
            RecreateObservable();
        }

        private void RecreateObservable()
        {
            CancelBackgroundOperation();
            int fetchInterval = CheckInterval[PluginSettings];
            IGitModule gitModule = _currentGitUiCommands.GitModule;
            if (fetchInterval > 0 && gitModule.IsValidGitWorkingDir())
            {
                IObservable<long> source =
                    Observable.Timer(TimeSpan.FromSeconds(fetchInterval))
                        .SkipWhile(
                            i =>
                                gitModule.IsRunningGitProcess() || _isMonitorRunnig ||
                                CheckInterval[PluginSettings] == Generic.DisableValueCheckMonitoInterval)
                        .Repeat()
                        .ObserveOn(ThreadPoolScheduler.Instance);

                _cancellationToken = source.Subscribe(i =>
                {
                    if (_currentGitUiCommands != null)
                    {
                        _currentGitUiCommands.GitModule.RunGitCmdResult("fetch -q --all");
                        _currentGitUiCommands.RepoChangedNotifier.Notify();
                        MonitorTask();
                        //source.Buffer(TimeSpan.FromSeconds(CheckInterval[PluginSettings]));
                    }
                });
            }
        }

        void MonitorTask()
        {
            if (!string.IsNullOrWhiteSpace(BranchesToMonitor[PluginSettings]))
            {
                var tab = BranchesToMonitor[PluginSettings].Split(';').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                if (tab.Any())
                {
                    _isMonitorRunnig = true;
                    foreach (var item in tab)
                    {
                        List<string> remotes = NeedToUpdate(item);
                        if (remotes.Any())
                        {
                            var localBranch = GitHelper.GetLocalsBranch(item, _currentGitUiCommands);
                            if (!remotes.Contains(string.Format("{0}/{1}", localBranch.TrackingRemote, localBranch.LocalName)))
                            {
                                continue;
                            }
                            DialogResult resultFormDialog = DialogResult.None;
                            if (Application.OpenForms.Count > Generic.DisableValueCheckMonitoInterval)
                            {
                                IAsyncResult iSyncResult = Application.OpenForms[0].BeginInvoke((ThreadStart)delegate
                                {
                                    resultFormDialog =
                                        new MonitorActionsForm(PluginSettings, _currentGitUiCommands, localBranch).ShowDialog(
                                            Application.OpenForms[0]);

                                });
                                iSyncResult.AsyncWaitHandle.WaitOne();
                                if (resultFormDialog == DialogResult.OK)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    _isMonitorRunnig = false;
                }
            }
        }

        private void CancelBackgroundOperation()
        {
            if (_cancellationToken != null)
            {
                _cancellationToken.Dispose();
                _cancellationToken = null;
            }
        }

        public List<string> NeedToUpdate(string brancheName)
        {
            if (_currentGitUiCommands != null)
            {
                CmdResult gitResult = _currentGitUiCommands.GitModule.RunGitCmdResult("show-ref " + brancheName);
                if (gitResult.ExitCode == 0)
                {
                    List<string> results = gitResult.StdOutput.SplitLines().Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                    string localBranch = results.FirstOrDefault(x => !x.Contains("refs/remotes/"));
                    if (!string.IsNullOrWhiteSpace(localBranch) && results.Any(x => x.Split(' ')[0] != localBranch.Split(' ')[0]))
                    {
                        return results.Where(x => !string.IsNullOrWhiteSpace(x) && x.Contains(" ") && x != localBranch).Select(x => x.Split(' ')[1]).Where(x => !string.IsNullOrWhiteSpace(x) && x.Contains("refs/remotes/")).Select(x => x.Replace("refs/remotes/", string.Empty)).ToList();
                    }
                    return new List<string>();
                }
            }
            return new List<string>();
        }
    }
}
