using GitUIPluginInterfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TalentsoftTools
{
    public partial class TalentsoftToolsForm
    {
        #region Methods

        private void InitLocalBranchTab()
        {
            LocalBranches = Helper.GetLocalsBranches(_gitUiCommands);
            string[] unmerged = Helper.GetUnmergerBranches(_gitUiCommands);
            var listBranches = new BindingList<BranchDto>();

            foreach (var branchName in LocalBranches.Select(b => b.Name))
            {
                string[] info = Helper.GetBranchInfo(_gitUiCommands, branchName);
                bool isMerged = !unmerged.Contains(branchName);

                var item = new BranchDto
                {
                    Name = branchName,
                    IsMerged = isMerged.ToString()
                };
                if (info.Count() == 2)
                {
                    item.LastAuthor = info[0];
                    item.LastUpdate = info[1];
                }

                listBranches.Add(item);
            }
            DgvLocalsBranches.DataSource = listBranches;

            foreach (DataGridViewRow row in DgvLocalsBranches.Rows)
            {
                if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() == "False")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Coral };
                }
                else
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.MediumSeaGreen };
                }
            }
        }

        void DeleteSelectedLocalBranches()
        {
            foreach (DataGridViewRow row in DgvLocalsBranches.SelectedRows)
            {
                string branchToDelete = row.Cells[0].Value.ToString();
                bool isMerged = Convert.ToBoolean(row.Cells[3].Value);
                CmdResult gitResult = new CmdResult();
                if (!isMerged)
                {
                    DialogResult response = MessageBox.Show($"{branchToDelete} branch is not merged. Are you sure you want delete it ?", "Talentsoft tools", MessageBoxButtons.YesNo);
                    switch (response)
                    {
                        case DialogResult.Yes:
                            gitResult = Helper.DeleteUnmergedLocalBranch(_gitUiCommands, branchToDelete);
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else
                {
                    gitResult = Helper.DeleteMergedLocalBranch(_gitUiCommands, branchToDelete);
                }
                if (gitResult.ExitCode != 0)
                {
                    MessageBox.Show($"Error when deleting {branchToDelete}. {gitResult.StdError}", "Error");
                }
            }
            _gitUiCommands.GitUICommands.RepoChangedNotifier.Notify();
            InitLocalBranchTab();
        }

        #endregion

        #region Events

        void BtnDeleteLocalsBranchesClick(object sender, EventArgs e)
        {
            if (DgvLocalsBranches.SelectedRows.Count > 0)
            {
                DialogResult response = MessageBox.Show("Are you sure you want delete these branches ?", "Talentsoft tools", MessageBoxButtons.YesNo);
                switch (response)
                {
                    case DialogResult.Yes:
                        DeleteSelectedLocalBranches();
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        #endregion
    }
}
