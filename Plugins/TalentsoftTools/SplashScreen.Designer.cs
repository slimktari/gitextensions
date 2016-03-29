namespace TalentsoftTools
{
    partial class SplashScreen
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
            this.components = new System.ComponentModel.Container();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.pnlStatus = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.BackColor = System.Drawing.Color.White;
            this.lblTimeRemaining.Location = new System.Drawing.Point(3, 156);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(279, 16);
            this.lblTimeRemaining.TabIndex = 5;
            this.lblTimeRemaining.Text = "Time remaining";
            this.lblTimeRemaining.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Transparent;
            this.pnlStatus.Location = new System.Drawing.Point(3, 125);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(279, 24);
            this.pnlStatus.TabIndex = 4;
            this.pnlStatus.DoubleClick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(3, 103);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(279, 14);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // SplashScreen
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.LightGray;
            this.BackgroundImage = global::TalentsoftTools.Properties.Resources.SplashTs;
            this.ClientSize = new System.Drawing.Size(421, 221);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashScreen";
            this.TopMost = true;
            this.DoubleClick += new System.EventHandler(this.SplashScreen_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer UpdateTimer;
    }
}