using TalentsoftTools.Dto;

namespace TalentsoftTools
{
    using System;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using GitCommands;
    using GitUIPluginInterfaces;
    using Helpers;

    public partial class TalentsoftToolsForm
    {
        #region Methods
        
        public int BranchesObsoletesCounter { get; set; }
        public int BranchesNeedToUpdateCounter { get; set; }
        public BindingList<BranchDto> LbrGridBranches { get; set; }

        public void InitLocalBranchTab()
        {
            string[] unmerged = GitHelper.GetUnmergerBranches();
            LbrGridBranches = new BindingList<BranchDto>();
            BranchesNeedToUpdateCounter = 0;
            BranchesObsoletesCounter = 0;
            foreach (GitRef branch in LocalBranches)
            {
                bool isObsolete = !GitHelper.IsBranchExist($"{branch.TrackingRemote}/{branch.LocalName}");
                bool isMerged = !unmerged.Contains(branch.LocalName);
                bool needToUpdate = false;
                if (isObsolete)
                {
                    BranchesObsoletesCounter++;
                }
                else
                {
                    needToUpdate = GitHelper.NeedToUpdate(branch.LocalName);
                }
                if (needToUpdate)
                {
                    BranchesNeedToUpdateCounter++;
                }
                var item = new BranchDto
                {
                    Name = branch.LocalName,
                    IsMerged = isMerged.ToString(),
                    NeedUpdate = needToUpdate.ToString(),
                    IsObsolete = isObsolete.ToString(),
                    Remote = branch.TrackingRemote
                };

                // Load author info.
                if (!isObsolete)
                {
                    string[] info = GitHelper.GetBranchInfoFromRemote(branch);
                    if (info.Count() == 2)
                    {
                        item.LastAuthor = info[0];
                        item.LastUpdate = info[1];
                    }
                }
                LbrGridBranches.Add(item);
            }
            DgvLocalsBranches.DataSource = LbrGridBranches;
        }

        public void UpdateLocalBranchBackColor()
        {
            foreach (DataGridViewRow row in DgvLocalsBranches.Rows)
            {
                row.Selected = false;
                if (row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.IsObsolete)].Value != null && row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.IsObsolete)].Value.ToString() == "True")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Generic.ColorBranchObsolete };
                }
                else if (row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.MustUpdate)].Value != null && row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.MustUpdate)].Value.ToString() == "True")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Generic.ColorBranchNeedUpdate };
                }
                else
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Generic.ColorBranchUpToDate };
                }
            }
        }

        public void UpdateNotifications()
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

            if (BranchesObsoletesCounter == 0)
            {
                LblBranchesObsoletes.Text = "0 obsolete branch.";
            }
            else if (BranchesObsoletesCounter == 1)
            {
                LblBranchesObsoletes.Text = "One obsolete branch.";
            }
            else
            {
                LblBranchesObsoletes.Text = BranchesObsoletesCounter + " obsoletes branches.";
            }
        }

        void DeleteSelectedLocalBranches()
        {
            foreach (DataGridViewRow row in DgvLocalsBranches.SelectedRows)
            {
                string branchToDelete = row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.BranchName)].Value.ToString();
                bool isMerged = Convert.ToBoolean(row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.IsMerged)].Value);
                CmdResult gitResult = new CmdResult();
                if (!isMerged)
                {
                    DialogResult response = MessageBox.Show($"{branchToDelete} branch is not merged. Are you sure you want delete it ?", Generic.PluginName, MessageBoxButtons.YesNo);
                    switch (response)
                    {
                        case DialogResult.Yes:
                            gitResult = GitHelper.DeleteUnmergedLocalBranch(branchToDelete);
                            break;
                        case DialogResult.No:
                            break;
                    }
                }
                else
                {
                    gitResult = GitHelper.DeleteMergedLocalBranch(branchToDelete);
                }
                if (gitResult.ExitCode != 0)
                {
                    MessageBox.Show($"Error when deleting {branchToDelete}. {gitResult.StdError}", "Error");
                }
            }
            GitHelper.NotifyGitExtensions();
            LoadLocalBranches();
            InitLocalBranchTab();
            UpdateLocalBranchBackColor();
            UpdateNotifications();
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
                DialogResult response = MessageBox.Show(message, Generic.PluginName, MessageBoxButtons.YesNo);
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

        private void BtnLocalsBranchesSelectObsoletesClick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DgvLocalsBranches.Rows)
            {
                row.Selected = false;
                if (row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.IsObsolete)].Value != null && row.Cells[Convert.ToInt32(Generic.LocalBranchesColumn.IsObsolete)].Value.ToString() == "True")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Generic.ColorBranchObsolete };
                    row.Selected = true;
                }
            }
        }
        #endregion
    }
}
