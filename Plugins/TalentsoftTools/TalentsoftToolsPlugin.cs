using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GitUIPluginInterfaces;
using ResourceManager;

namespace TalentsoftTools
{
    public class TalentsoftToolsPlugin : GitPluginBase, IGitPluginForRepository
    {
        public static BoolSetting IsDefaultExitAndStartVisualStudio = new BoolSetting("Is default exit and start Visual Studio", true);
        public static BoolSetting IsDefaultStashChanges = new BoolSetting("Is default stash changes", true);
        public static BoolSetting IsDefaultCheckoutBranch = new BoolSetting("Is default checkout branch", true);
        public static BoolSetting IsDefaultGitClean = new BoolSetting("Is default git clean", true);
        public static BoolSetting IsDefaultStashPop = new BoolSetting("Is default stash pop", true);
        public static BoolSetting IsDefaultResetDatabases = new BoolSetting("Is default reset databases", true);
        public static BoolSetting IsDefaultNugetRestore = new BoolSetting("Is default Nuget restore", true);
        public static BoolSetting IsDefaultBuildSolution = new BoolSetting("Is default build solution", true);
        public static BoolSetting IsDefaultRunUri = new BoolSetting("Is default execute URI", true);
        public static StringSetting LocalUriWebApplication = new StringSetting("Local URIs web application (separator ;)", string.Empty);
        public static StringSetting DefaultSolutionFileName = new StringSetting("Default solution file (Eg: TalentSoft.sln)", string.Empty);
        public static StringSetting PathToMsBuildFramework = new StringSetting("Path to MSBuild", string.Empty);
        public static StringSetting ExcludePatternGitClean = new StringSetting("Pattern exclude files Git Clean", "*.mdf *.ldf");
        public static StringSetting NewBranchPrefix = new StringSetting("Branch name prefix", string.Empty);
        public static StringSetting PreBuildBatch = new StringSetting("Pre-Build batch (separator ;)", string.Empty);
        public static StringSetting PostBuildBatch = new StringSetting("Post-Build batch (separator ;)", string.Empty);
        public static StringSetting DatabaseConnectionParams = new StringSetting("Database connection parameters", @"Data Source=.;User ID=ASPNET;Password=aspasp;RelocateDataFilePath=C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\");
        public static StringSetting DatabasesToRestore = new StringSetting("Databases to restore", @"Initial Catalog=TSDEV;BackupFilePath=;");

        public TalentsoftToolsPlugin()
        {
            Description = "Talentsoft tools";
            //Translate();
        }


        public override void Register(IGitUICommands gitUiCommands)
        {
            base.Register(gitUiCommands);
            SetMsBuildPath();
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
            yield return PathToMsBuildFramework;
            yield return DatabaseConnectionParams;
            yield return DatabasesToRestore;
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
        void SetMsBuildPath()
        {
            if (string.IsNullOrWhiteSpace(PathToMsBuildFramework[Settings]))
            {
                List<string> pathsToMsBuild = new List<string>
                                                  {
                    "C:/Windows/Microsoft.Net/Framework/v2.0.50727/MsBuild.exe",
                    "C:/Windows/Microsoft.Net/Framework/v3.5/MsBuild.exe",
                    "C:/Windows/Microsoft.NET/Framework/v4.0.30319/MsBuild.exe",
                    @"C:\Program Files (x86)\MSBuild\12.0\Bin\MsBuild.exe",
                    @"C:\Program Files (x86)\MSBuild\14.0\Bin\MsBuild.exe"
                                                  };
                foreach (var pathToMsBuild in pathsToMsBuild)
                {
                    if (File.Exists(pathToMsBuild))
                    {
                        PathToMsBuildFramework[Settings] = pathToMsBuild;
                    }
                }
            }
        }
    }
}
