using System;
using System.Collections.Generic;

namespace TalentsoftTools
{
    using System.Drawing;
    using System.Windows.Forms;
    using Helpers;
    using System.Linq;

    public partial class TalentsoftToolsForm
    {
        public void InitNotificationsTab()
        {
            string[] branchesMonitors = new string[0];
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.BranchesToMonitor[_settings]))
            {
                branchesMonitors = TalentsoftToolsPlugin.BranchesToMonitor[_settings].Split(';');
            }
            DgvNtfNotifications.DataSource = LocalBranches.Select(x => new { Name = x.LocalName }).ToList();
            foreach (DataGridViewRow row in DgvNtfNotifications.Rows)
            {
                if (row.Cells[1].Value != null)
                {
                    bool isMonitor = branchesMonitors.Contains(row.Cells[1].Value);
                    row.Cells[0].Value = isMonitor;
                }
            }
            DgvNtfNotifications.RefreshEdit();
        }

        private void DgvNtfNotificationsCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var checkBoxCell = (DataGridViewCheckBoxCell)DgvNtfNotifications.Rows[DgvNtfNotifications.CurrentRow.Index].Cells[0];
                bool isChecked = checkBoxCell.Selected;
                List<string> branchesMonitors = TalentsoftToolsPlugin.BranchesToMonitor[_settings].Split(';').ToList();
                string branchName = DgvNtfNotifications[1, e.RowIndex].Value.ToString();
                if (isChecked && branchesMonitors.All(x => x != DgvNtfNotifications[1, e.RowIndex].Value.ToString()))
                {
                    branchesMonitors.Add(branchName);
                }
                if (!isChecked && branchesMonitors.Any(x => x == branchName))
                {
                    branchesMonitors.Remove(branchName);
                }
                TalentsoftToolsPlugin.BranchesToMonitor[_settings] = string.Join(";", branchesMonitors);
            }
        }
    }
}
