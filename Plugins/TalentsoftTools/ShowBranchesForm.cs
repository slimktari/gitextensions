namespace TalentsoftTools
{
    using System.Windows.Forms;
    using System.Collections.Generic;

    public partial class ShowBranchesForm : Form
    {
        public ShowBranchesForm(List<string> branchesName)
        {
            InitializeComponent();
            Text = string.Format("{0} Show Branches", Generic.PluginName);
            TbxShowBranches.Text = string.Join("\r\n", branchesName);
        }
    }
}
