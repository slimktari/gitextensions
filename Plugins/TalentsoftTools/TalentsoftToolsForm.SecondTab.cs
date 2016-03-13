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

        public int UnmergedBranchesCounter { get; set; }
        public int BranchesNeedToUpdateCounter { get; set; }
        private void InitLocalBranchTab()
        {
            LocalBranches = Helper.GetLocalsBranches(_gitUiCommands);
            string[] unmerged = Helper.GetUnmergerBranches(_gitUiCommands);
            var listBranches = new BindingList<BranchDto>();
            BranchesNeedToUpdateCounter = 0;
            UnmergedBranchesCounter = 0;
            foreach (var branchName in LocalBranches.Select(b => b.Name))
            {
                string[] info = Helper.GetBranchInfo(_gitUiCommands, branchName);
                bool isMerged = !unmerged.Contains(branchName);
                bool needToUpdate = Helper.NeedToUpdate(_gitUiCommands, branchName);
                if (needToUpdate)
                {
                    BranchesNeedToUpdateCounter++;
                }
                if (isMerged)
                {
                    UnmergedBranchesCounter++;
                }
                var item = new BranchDto
                {
                    Name = branchName,
                    IsMerged = isMerged.ToString(),
                    NeedUpdate = needToUpdate.ToString()
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
                if (row.Cells[4].Value != null && row.Cells[4].Value.ToString() == "True")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Red };
                }
                else if (row.Cells[3].Value != null && row.Cells[3].Value.ToString() == "False")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.Coral };
                }
                else
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.MediumSeaGreen };
                }
            }
            UpdateNotifications();
        }

        void UpdateNotifications()
        {
            if (BranchesNeedToUpdateCounter == 0)
            {
                LblNeedToUpdate.Text = "All branches are up to date.";
            }
            else if (BranchesNeedToUpdateCounter == 1)
            {
                LblNeedToUpdate.Text = "One branch must be updated.";
            }
            else
            {
                LblNeedToUpdate.Text = BranchesNeedToUpdateCounter + " branches must be updated.";
            }

            if (UnmergedBranchesCounter == 0)
            {
                LblUnmergedBranches.Text = "All branches are merged.";
            }
            else if (UnmergedBranchesCounter == 1)
            {
                LblUnmergedBranches.Text = "One branch is not merged.";
            }
            else
            {
                LblUnmergedBranches.Text = UnmergedBranchesCounter + " branches are not merged.";
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
                    DialogResult response = MessageBox.Show(string.Format("{0} branch is not merged. Are you sure you want delete it ?", branchToDelete), "Talentsoft tools", MessageBoxButtons.YesNo);
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
                    MessageBox.Show(string.Format("Error when deleting {0}. {1}", branchToDelete, gitResult.StdError), "Error");
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
                string message = "Are you sure you want delete these branches ?";
                if (DgvLocalsBranches.SelectedRows.Count == 1)
                {
                    message = "Are you sure you want delete this branch ?";
                }
                DialogResult response = MessageBox.Show(message, "Talentsoft tools", MessageBoxButtons.YesNo);
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
