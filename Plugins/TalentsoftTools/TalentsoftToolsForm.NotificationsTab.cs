namespace TalentsoftTools
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class TalentsoftToolsForm
    {
        public void InitNotificationsTab()
        {
            string[] branchesMonitors = new string[0];
            if (!string.IsNullOrWhiteSpace(TalentsoftToolsPlugin.BranchesToMonitor[_settings]))
            {
                branchesMonitors = TalentsoftToolsPlugin.BranchesToMonitor[_settings].Split(';');
            }
            DgvNtfNotifications.DataSource = LbrGridBranches;
            foreach (DataGridViewRow row in DgvNtfNotifications.Rows)
            {
                row.Selected = false;
                if (row.Cells[Convert.ToInt32(Generic.NotificationsColumn.BrancheName)].Value != null)
                {
                    bool isMonitor = branchesMonitors.Contains(row.Cells[Convert.ToInt32(Generic.NotificationsColumn.BrancheName)].Value);
                    row.Cells[Convert.ToInt32(Generic.NotificationsColumn.IsNotificationWhenUpdate)].Value = isMonitor;
                }
            }
            DgvNtfNotifications.RefreshEdit();
        }

        public void UpdateNotificationsBackColor()
        {
            foreach (DataGridViewRow row in DgvNtfNotifications.Rows)
            {
                row.Selected = false;
                if (row.Cells[Convert.ToInt32(Generic.NotificationsColumn.IsObsolete)].Value != null && row.Cells[Convert.ToInt32(Generic.NotificationsColumn.IsObsolete)].Value.ToString() == "True")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Generic.ColorBranchObsolete };
                }
                else if (row.Cells[Convert.ToInt32(Generic.NotificationsColumn.MustUpdate)].Value != null && row.Cells[Convert.ToInt32(Generic.NotificationsColumn.MustUpdate)].Value.ToString() == "True")
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Generic.ColorBranchNeedUpdate };
                }
                else
                {
                    row.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Generic.ColorBranchUpToDate };
                }
            }
        }

        private void DgvNtfNotificationsCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                var checkBoxCell = (DataGridViewCheckBoxCell)DgvNtfNotifications.Rows[DgvNtfNotifications.CurrentRow.Index].Cells[Convert.ToInt32(Generic.NotificationsColumn.IsNotificationWhenUpdate)];
                bool isChecked = Convert.ToBoolean(checkBoxCell.EditingCellFormattedValue);
                List<string> branchesMonitors = TalentsoftToolsPlugin.BranchesToMonitor[_settings].Split(';').ToList();
                string branchName = DgvNtfNotifications[Convert.ToInt32(Generic.NotificationsColumn.BrancheName), e.RowIndex].Value.ToString();
                if (isChecked && branchesMonitors.All(x => x != DgvNtfNotifications[Convert.ToInt32(Generic.NotificationsColumn.BrancheName), e.RowIndex].Value.ToString()))
                {
                    branchesMonitors.Add(branchName);
                }
                if (!isChecked && branchesMonitors.Any(x => x == branchName))
                {
                    branchesMonitors.Remove(branchName);
                }
                TalentsoftToolsPlugin.BranchesToMonitor[_settings] = string.Join(";", branchesMonitors.Where(x => !string.IsNullOrWhiteSpace(x)));
                TxbSettingsNotificationsMonitorBranches.Text = TalentsoftToolsPlugin.BranchesToMonitor[_settings];
            }
        }
    }
}
