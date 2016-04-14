namespace TalentsoftTools
{
    partial class ShowBranchesForm
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
            this.TbxShowBranches = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TbxShowBranches
            // 
            this.TbxShowBranches.BackColor = System.Drawing.SystemColors.MenuText;
            this.TbxShowBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbxShowBranches.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxShowBranches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TbxShowBranches.Location = new System.Drawing.Point(0, 0);
            this.TbxShowBranches.Multiline = true;
            this.TbxShowBranches.Name = "TbxShowBranches";
            this.TbxShowBranches.ReadOnly = true;
            this.TbxShowBranches.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbxShowBranches.Size = new System.Drawing.Size(742, 322);
            this.TbxShowBranches.TabIndex = 2;
            // 
            // ShowBranchesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 322);
            this.Controls.Add(this.TbxShowBranches);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowBranchesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TbxShowBranches;
    }
}