using GitUIPluginInterfaces;
using ResourceManager;

namespace TalentsoftTools
{
    using System.Windows.Forms;

    public class TalentsoftToolsPlugin : GitPluginBase, IGitPluginForRepository
    {
        public static StringSetting LocalUriWebApplication = new StringSetting("Local URI web application", string.Empty);
        
        public TalentsoftToolsPlugin()
        {
            Description = "Talentsoft tools";
            //Translate();
        }

        public override bool Execute(GitUIBaseEventArgs gitUiCommands)
        {
            using (var frm = new  TalentsoftTools(gitUiCommands, Settings))
            {
                frm.ShowDialog(gitUiCommands.OwnerForm);
                return frm.IsRefreshNeeded;
            }
        }

        public override System.Collections.Generic.IEnumerable<ISetting> GetSettings()
        {
            yield return LocalUriWebApplication;
        }
    }
}
