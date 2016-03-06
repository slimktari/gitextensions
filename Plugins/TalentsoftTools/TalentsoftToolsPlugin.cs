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
        public static BoolSetting IsDefaultBuildSolution = new BoolSetting("Is default build solution", true);
        public static BoolSetting IsDefaultRunVisualStudio = new BoolSetting("Is default run VisualStudio", true);
        public static BoolSetting IsDefaultRunUri = new BoolSetting("Is default execute URI", true);
        public static StringSetting LocalUriWebApplication = new StringSetting("Local URI web application", string.Empty);
        public static StringSetting DefaultSolutionFileName = new StringSetting("Default solution file (Eg: TalentSoft.sln)", string.Empty);
        public static StringSetting PathToMsBuildFramework = new StringSetting("Path to MSBuild", string.Empty);
        public static StringSetting ExcludePatternGitClean = new StringSetting("Pattern exclude files Git Clean", "*.mdf *.ldf");
        public static StringSetting NewBranchPrefix = new StringSetting("Branch name prefix", string.Empty);

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
            yield return IsDefaultBuildSolution;
            yield return IsDefaultRunVisualStudio;
            yield return IsDefaultRunUri;
            yield return LocalUriWebApplication;
            yield return DefaultSolutionFileName;
            yield return NewBranchPrefix;
            yield return PathToMsBuildFramework;
            yield return ExcludePatternGitClean;
        }
    }
}
