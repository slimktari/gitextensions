namespace TalentsoftTools
{
    using GitUIPluginInterfaces;

    using ResourceManager;

    public class TalentsoftToolsPlugin : GitPluginBase, IGitPluginForRepository
    {
        public TalentsoftToolsPlugin()
        {
            Description = "Talentsoft tools";
            Translate();
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            using (var frm = new  TalentsoftTools(gitUiCommands))
            {
                frm.ShowDialog(gitUiCommands.OwnerForm);
                return frm.IsRefreshNeeded;
            }
        }
    }
}
