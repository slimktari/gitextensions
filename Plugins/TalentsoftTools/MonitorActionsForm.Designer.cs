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
            this.LblDescription = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnRemoveFromMonitor = new System.Windows.Forms.Button();
            this.CbxRemoveFromMonitor = new System.Windows.Forms.CheckBox();
            this.LblInfosRemoteBranch = new System.Windows.Forms.Label();
            this.LblInfosAuthor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnRebase
            // 
            this.BtnRebase.Location = new System.Drawing.Point(270, 148);
            this.BtnRebase.Name = "BtnRebase";
            this.BtnRebase.Size = new System.Drawing.Size(128, 31);
            this.BtnRebase.TabIndex = 4;
            this.BtnRebase.Text = "Rebase";
            this.BtnRebase.UseVisualStyleBackColor = true;
            this.BtnRebase.Click += new System.EventHandler(this.BtnRebaseClick);
            // 
            // BtnCheckout
            // 
            this.BtnCheckout.Location = new System.Drawing.Point(270, 185);
            this.BtnCheckout.Name = "BtnCheckout";
            this.BtnCheckout.Size = new System.Drawing.Size(128, 31);
            this.BtnCheckout.TabIndex = 5;
            this.BtnCheckout.Text = "Checkout";
            this.BtnCheckout.UseVisualStyleBackColor = true;
            this.BtnCheckout.Click += new System.EventHandler(this.BtnCheckoutClick);
            // 
            // BtnMerge
            // 
            this.BtnMerge.Location = new System.Drawing.Point(270, 111);
            this.BtnMerge.Name = "BtnMerge";
            this.BtnMerge.Size = new System.Drawing.Size(128, 31);
            this.BtnMerge.TabIndex = 3;
            this.BtnMerge.Text = "Merge";
            this.BtnMerge.UseVisualStyleBackColor = true;
            this.BtnMerge.Click += new System.EventHandler(this.BtnMergeClick);
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Location = new System.Drawing.Point(9, 21);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(89, 13);
            this.LblDescription.TabIndex = 3;
            this.LblDescription.Text = " must be updated";
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(12, 185);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(128, 31);
            this.BtnCancel.TabIndex = 0;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            // 
            // BtnRemoveFromMonitor
            // 
            this.BtnRemoveFromMonitor.Location = new System.Drawing.Point(12, 147);
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
            this.CbxRemoveFromMonitor.Location = new System.Drawing.Point(270, 88);
            this.CbxRemoveFromMonitor.Name = "CbxRemoveFromMonitor";
            this.CbxRemoveFromMonitor.Size = new System.Drawing.Size(126, 17);
            this.CbxRemoveFromMonitor.TabIndex = 2;
            this.CbxRemoveFromMonitor.Text = "Remove from monitor";
            this.CbxRemoveFromMonitor.UseVisualStyleBackColor = true;
            // 
            // LblInfosRemoteBranch
            // 
            this.LblInfosRemoteBranch.AccessibleDescription = "";
            this.LblInfosRemoteBranch.AutoSize = true;
            this.LblInfosRemoteBranch.Location = new System.Drawing.Point(9, 45);
            this.LblInfosRemoteBranch.Name = "LblInfosRemoteBranch";
            this.LblInfosRemoteBranch.Size = new System.Drawing.Size(187, 13);
            this.LblInfosRemoteBranch.TabIndex = 7;
            this.LblInfosRemoteBranch.Text = "Must have remote branch informations";
            // 
            // LblInfosAuthor
            // 
            this.LblInfosAuthor.AutoSize = true;
            this.LblInfosAuthor.Location = new System.Drawing.Point(9, 70);
            this.LblInfosAuthor.Name = "LblInfosAuthor";
            this.LblInfosAuthor.Size = new System.Drawing.Size(149, 13);
            this.LblInfosAuthor.TabIndex = 8;
            this.LblInfosAuthor.Text = "Must have author informations";
            // 
            // MonitorActionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 227);
            this.Controls.Add(this.LblInfosAuthor);
            this.Controls.Add(this.LblInfosRemoteBranch);
            this.Controls.Add(this.CbxRemoveFromMonitor);
            this.Controls.Add(this.BtnRemoveFromMonitor);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.LblDescription);
            this.Controls.Add(this.BtnMerge);
            this.Controls.Add(this.BtnCheckout);
            this.Controls.Add(this.BtnRebase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitorActionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRebase;
        private System.Windows.Forms.Button BtnCheckout;
        private System.Windows.Forms.Button BtnMerge;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnRemoveFromMonitor;
        private System.Windows.Forms.CheckBox CbxRemoveFromMonitor;
        private System.Windows.Forms.Label LblInfosRemoteBranch;
        private System.Windows.Forms.Label LblInfosAuthor;
    }
}