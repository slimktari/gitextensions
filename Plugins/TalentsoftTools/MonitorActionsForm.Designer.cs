namespace TalentsoftTools
{
    partial class MonitorActionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnRebase = new System.Windows.Forms.Button();
            this.BtnCheckout = new System.Windows.Forms.Button();
            this.BtnMerge = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.LblBranchName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CblRemotesList = new System.Windows.Forms.ComboBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnRemoveFromMonitor = new System.Windows.Forms.Button();
            this.CbxRemoveFromMonitor = new System.Windows.Forms.CheckBox();
            this.LblInfos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRebase
            // 
            this.BtnRebase.Location = new System.Drawing.Point(270, 229);
            this.BtnRebase.Name = "BtnRebase";
            this.BtnRebase.Size = new System.Drawing.Size(128, 31);
            this.BtnRebase.TabIndex = 4;
            this.BtnRebase.Text = "Rebase";
            this.BtnRebase.UseVisualStyleBackColor = true;
            this.BtnRebase.Click += new System.EventHandler(this.BtnRebaseClick);
            // 
            // BtnCheckout
            // 
            this.BtnCheckout.Location = new System.Drawing.Point(270, 266);
            this.BtnCheckout.Name = "BtnCheckout";
            this.BtnCheckout.Size = new System.Drawing.Size(128, 31);
            this.BtnCheckout.TabIndex = 5;
            this.BtnCheckout.Text = "Checkout";
            this.BtnCheckout.UseVisualStyleBackColor = true;
            this.BtnCheckout.Click += new System.EventHandler(this.BtnCheckoutClick);
            // 
            // BtnMerge
            // 
            this.BtnMerge.Location = new System.Drawing.Point(270, 192);
            this.BtnMerge.Name = "BtnMerge";
            this.BtnMerge.Size = new System.Drawing.Size(128, 31);
            this.BtnMerge.TabIndex = 3;
            this.BtnMerge.Text = "Merge";
            this.BtnMerge.UseVisualStyleBackColor = true;
            this.BtnMerge.Click += new System.EventHandler(this.BtnMergeClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "This branch must updated";
            // 
            // LblBranchName
            // 
            this.LblBranchName.AutoSize = true;
            this.LblBranchName.Location = new System.Drawing.Point(28, 44);
            this.LblBranchName.Name = "LblBranchName";
            this.LblBranchName.Size = new System.Drawing.Size(0, 13);
            this.LblBranchName.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "If you want merge or rebase please check remote branch from list";
            // 
            // CblRemotesList
            // 
            this.CblRemotesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CblRemotesList.FormattingEnabled = true;
            this.CblRemotesList.ItemHeight = 13;
            this.CblRemotesList.Location = new System.Drawing.Point(12, 124);
            this.CblRemotesList.Name = "CblRemotesList";
            this.CblRemotesList.Size = new System.Drawing.Size(386, 21);
            this.CblRemotesList.TabIndex = 6;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 266);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(128, 31);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // BtnRemoveFromMonitor
            // 
            this.BtnRemoveFromMonitor.Location = new System.Drawing.Point(12, 228);
            this.BtnRemoveFromMonitor.Name = "BtnRemoveFromMonitor";
            this.BtnRemoveFromMonitor.Size = new System.Drawing.Size(128, 31);
            this.BtnRemoveFromMonitor.TabIndex = 1;
            this.BtnRemoveFromMonitor.Text = "Remove from monitor";
            this.BtnRemoveFromMonitor.UseVisualStyleBackColor = true;
            this.BtnRemoveFromMonitor.Click += new System.EventHandler(this.BtnRemoveFromMonitorClick);
            // 
            // CbxRemoveFromMonitor
            // 
            this.CbxRemoveFromMonitor.AutoSize = true;
            this.CbxRemoveFromMonitor.Checked = true;
            this.CbxRemoveFromMonitor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxRemoveFromMonitor.Location = new System.Drawing.Point(270, 169);
            this.CbxRemoveFromMonitor.Name = "CbxRemoveFromMonitor";
            this.CbxRemoveFromMonitor.Size = new System.Drawing.Size(126, 17);
            this.CbxRemoveFromMonitor.TabIndex = 2;
            this.CbxRemoveFromMonitor.Text = "Remove from monitor";
            this.CbxRemoveFromMonitor.UseVisualStyleBackColor = true;
            // 
            // LblInfos
            // 
            this.LblInfos.AutoSize = true;
            this.LblInfos.Location = new System.Drawing.Point(28, 66);
            this.LblInfos.Name = "LblInfos";
            this.LblInfos.Size = new System.Drawing.Size(0, 13);
            this.LblInfos.TabIndex = 7;
            // 
            // MonitorActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 309);
            this.Controls.Add(this.LblInfos);
            this.Controls.Add(this.CbxRemoveFromMonitor);
            this.Controls.Add(this.BtnRemoveFromMonitor);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.CblRemotesList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblBranchName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnMerge);
            this.Controls.Add(this.BtnCheckout);
            this.Controls.Add(this.BtnRebase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitorActionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talentsoft tools monitor";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRebase;
        private System.Windows.Forms.Button BtnCheckout;
        private System.Windows.Forms.Button BtnMerge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblBranchName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CblRemotesList;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnRemoveFromMonitor;
        private System.Windows.Forms.CheckBox CbxRemoveFromMonitor;
        private System.Windows.Forms.Label LblInfos;
    }
}