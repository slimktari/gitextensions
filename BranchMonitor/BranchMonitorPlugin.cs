using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitCommands;
using GitUIPluginInterfaces;
using ResourceManager;

namespace BranchMonitor
{
    public class BranchMonitorPlugin : GitPluginBase, IGitPluginForRepository
    {
        private IDisposable cancellationToken;
        private IGitUICommands currentGitUiCommands;

        private StringSetting BranchesToMonitor = new StringSetting("Branches to monitor", string.Empty);
        private NumberSetting<int> CheckInterval = new NumberSetting<int>("Check every (seconds) - set to 0 to disable", 0);

        public BranchMonitorPlugin()
        {
            Description = "Periodic background fetch";
            Translate();
        }

        private IGitUICommands gitUiCommands;
        public override void Register(IGitUICommands gitUiCommands)
        {
            base.Register(gitUiCommands);

            currentGitUiCommands = gitUiCommands;
            currentGitUiCommands.PostSettings += OnPostSettings;
            RecreateObservable();
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
                cancellationToken =
                    Observable.Timer(TimeSpan.FromSeconds(Math.Max(5, fetchInterval)))
                              .SkipWhile(i => gitModule.IsRunningGitProcess())
                              .Repeat()
                              .ObserveOn(ThreadPoolScheduler.Instance)
                              .Subscribe(i =>
                              {
                                  if (!string.IsNullOrWhiteSpace(BranchesToMonitor[Settings]))
                                  {
                                      var tab = BranchesToMonitor[Settings].Split(';');
                                      foreach (var item in tab)
                                      {
                                          if (NeedToUpdate(item))
                                          {
                                              MessageBox.Show(item + " is updated !");
                                          }
                                      }


                                  }
                              }
                                  );
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

        public override bool Execute(GitUIBaseEventArgs gitUiArgs)
        {
            gitUiArgs.GitUICommands.StartSettingsDialog(this);
            return false;
        }

        public bool NeedToUpdate(string brancheName)
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
    }
}
