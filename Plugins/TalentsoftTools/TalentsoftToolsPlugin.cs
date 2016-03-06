using GitUIPluginInterfaces;
using ResourceManager;

namespace TalentsoftTools
{
    public class TalentsoftToolsPlugin : GitPluginBase, IGitPluginForRepository
    {
        public static BoolSetting IsDefaultExitVisualStudio = new BoolSetting("Is default exit Visual Studio", true);
        public static BoolSetting IsDefaultStashChanges = new BoolSetting("Is default stash changes", true);
        public static BoolSetting IsDefaultCheckoutBranch = new BoolSetting("Is default checkout branch", true);
        public static BoolSetting IsDefaultGitClean = new BoolSetting("Is default git clean", true);
        public static BoolSetting IsDefaultStashPop = new BoolSetting("Is default stash pop", true);
        public static BoolSetting IsDefaultPreBuildSolution = new BoolSetting("Is default pre-build solution", true);
        public static BoolSetting IsDefaultBuildSolution = new BoolSetting("Is default build solution", true);
        public static BoolSetting IsDefaultPostBuildSolution = new BoolSetting("Is default post-build solution", true);
        public static BoolSetting IsDefaultRunVisualStudio = new BoolSetting("Is default run VisualStudio", true);
        public static BoolSetting IsDefaultRunUri = new BoolSetting("Is default execute URI", true);
        public static StringSetting LocalUriWebApplication = new StringSetting("Local URIs web application (separator ;)", string.Empty);
        public static StringSetting DefaultSolutionFileName = new StringSetting("Default solution file (Eg: TalentSoft.sln)", string.Empty);
        public static StringSetting PathToMsBuildFramework = new StringSetting("Path to MSBuild", string.Empty);
        public static StringSetting ExcludePatternGitClean = new StringSetting("Pattern exclude files Git Clean", "*.mdf *.ldf");
        public static StringSetting NewBranchPrefix = new StringSetting("Branch name prefix", string.Empty);
        public static StringSetting PreBuildBatch = new StringSetting("Pre-Build batch (separator ;)", string.Empty);
        public static StringSetting PostBuildBatch = new StringSetting("Post-Build batch (separator ;)", string.Empty);


        public TalentsoftToolsPlugin()
        {
            Description = "Talentsoft tools";
            //Translate();
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            using (var frm = new  TalentsoftToolsForm(gitUiCommands, Settings))
            {
                frm.ShowDialog(gitUiCommands.OwnerForm);
                return true;
            }
        }

        public override System.Collections.Generic.IEnumerable<ISetting> GetSettings()
        {
            yield return IsDefaultExitVisualStudio;
            yield return IsDefaultStashChanges;
            yield return IsDefaultCheckoutBranch;
            yield return IsDefaultGitClean;
            yield return IsDefaultStashPop;
            yield return IsDefaultPreBuildSolution;
            yield return IsDefaultBuildSolution;
            yield return IsDefaultPostBuildSolution;
            yield return IsDefaultRunVisualStudio;
            yield return IsDefaultRunUri;
            yield return LocalUriWebApplication;
            yield return PreBuildBatch;
            yield return PostBuildBatch;
            yield return DefaultSolutionFileName;
            yield return NewBranchPrefix;
            yield return PathToMsBuildFramework;
            yield return ExcludePatternGitClean;
        }
    }
}
