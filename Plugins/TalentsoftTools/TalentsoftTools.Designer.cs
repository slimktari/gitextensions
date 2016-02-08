namespace TalentsoftTools
{
    partial class TalentsoftTools
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
            this.TbcMain = new System.Windows.Forms.TabControl();
            this.TbpProcess = new System.Windows.Forms.TabPage();
            this.GbxTargetSolution = new System.Windows.Forms.GroupBox();
            this.CbxSolutions = new System.Windows.Forms.ComboBox();
            this.LblTargetSolutionFileNameLabel = new System.Windows.Forms.Label();
            this.LblTargetSolutionFileName = new System.Windows.Forms.Label();
            this.GbxTargetBranch = new System.Windows.Forms.GroupBox();
            this.CbxBranches = new System.Windows.Forms.ComboBox();
            this.LblSelectBranch = new System.Windows.Forms.Label();
            this.RbtIsRemoteTargetBranch = new System.Windows.Forms.RadioButton();
            this.RbtIsLocalTargetBranch = new System.Windows.Forms.RadioButton();
            this.GbxProcess = new System.Windows.Forms.GroupBox();
            this.LblNext8 = new System.Windows.Forms.Label();
            this.CbxIsGitClean = new System.Windows.Forms.CheckBox();
            this.BtnRunProcess = new System.Windows.Forms.Button();
            this.CbxIsExitVisualStudio = new System.Windows.Forms.CheckBox();
            this.CbxIsRunVisualStudio = new System.Windows.Forms.CheckBox();
            this.LblNext1 = new System.Windows.Forms.Label();
            this.LblNext7 = new System.Windows.Forms.Label();
            this.CbxIsStashChanges = new System.Windows.Forms.CheckBox();
            this.CbxIsRunScriptNextVersion = new System.Windows.Forms.CheckBox();
            this.LblNext2 = new System.Windows.Forms.Label();
            this.LblNext6 = new System.Windows.Forms.Label();
            this.CbxIsCheckoutBranch = new System.Windows.Forms.CheckBox();
            this.CbxIsBuildSolution = new System.Windows.Forms.CheckBox();
            this.LblNext3 = new System.Windows.Forms.Label();
            this.LblNext4 = new System.Windows.Forms.Label();
            this.CbxIsNugetUpdate = new System.Windows.Forms.CheckBox();
            this.TbpSolutions = new System.Windows.Forms.TabPage();
            this.GbxSolutionsActions = new System.Windows.Forms.GroupBox();
            this.DgvSolutions = new System.Windows.Forms.DataGridView();
            this.DgcFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DgcPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbpSql = new System.Windows.Forms.TabPage();
            this.TbcMain.SuspendLayout();
            this.TbpProcess.SuspendLayout();
            this.GbxTargetSolution.SuspendLayout();
            this.GbxTargetBranch.SuspendLayout();
            this.GbxProcess.SuspendLayout();
            this.TbpSolutions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSolutions)).BeginInit();
            this.SuspendLayout();
            // 
            // TbcMain
            // 
            this.TbcMain.Controls.Add(this.TbpProcess);
            this.TbcMain.Controls.Add(this.TbpSolutions);
            this.TbcMain.Controls.Add(this.TbpSql);
            this.TbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcMain.Location = new System.Drawing.Point(0, 0);
            this.TbcMain.Name = "TbcMain";
            this.TbcMain.SelectedIndex = 0;
            this.TbcMain.Size = new System.Drawing.Size(1112, 421);
            this.TbcMain.TabIndex = 0;
            // 
            // TbpProcess
            // 
            this.TbpProcess.Controls.Add(this.GbxTargetSolution);
            this.TbpProcess.Controls.Add(this.GbxTargetBranch);
            this.TbpProcess.Controls.Add(this.GbxProcess);
            this.TbpProcess.Location = new System.Drawing.Point(4, 24);
            this.TbpProcess.Name = "TbpProcess";
            this.TbpProcess.Size = new System.Drawing.Size(1104, 393);
            this.TbpProcess.TabIndex = 2;
            this.TbpProcess.Text = "Process";
            this.TbpProcess.UseVisualStyleBackColor = true;
            // 
            // GbxTargetSolution
            // 
            this.GbxTargetSolution.Controls.Add(this.CbxSolutions);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileNameLabel);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileName);
            this.GbxTargetSolution.Dock = System.Windows.Forms.DockStyle.Top;
            this.GbxTargetSolution.Location = new System.Drawing.Point(0, 0);
            this.GbxTargetSolution.Name = "GbxTargetSolution";
            this.GbxTargetSolution.Size = new System.Drawing.Size(1104, 81);
            this.GbxTargetSolution.TabIndex = 0;
            this.GbxTargetSolution.TabStop = false;
            this.GbxTargetSolution.Text = "Target solution";
            // 
            // CbxSolutions
            // 
            this.CbxSolutions.FormattingEnabled = true;
            this.CbxSolutions.Location = new System.Drawing.Point(111, 36);
            this.CbxSolutions.Name = "CbxSolutions";
            this.CbxSolutions.Size = new System.Drawing.Size(194, 23);
            this.CbxSolutions.TabIndex = 3;
            // 
            // LblTargetSolutionFileNameLabel
            // 
            this.LblTargetSolutionFileNameLabel.AutoSize = true;
            this.LblTargetSolutionFileNameLabel.Location = new System.Drawing.Point(12, 39);
            this.LblTargetSolutionFileNameLabel.Name = "LblTargetSolutionFileNameLabel";
            this.LblTargetSolutionFileNameLabel.Size = new System.Drawing.Size(93, 15);
            this.LblTargetSolutionFileNameLabel.TabIndex = 1;
            this.LblTargetSolutionFileNameLabel.Text = "Target solution :";
            // 
            // LblTargetSolutionFileName
            // 
            this.LblTargetSolutionFileName.AutoSize = true;
            this.LblTargetSolutionFileName.Location = new System.Drawing.Point(105, 39);
            this.LblTargetSolutionFileName.Name = "LblTargetSolutionFileName";
            this.LblTargetSolutionFileName.Size = new System.Drawing.Size(0, 15);
            this.LblTargetSolutionFileName.TabIndex = 0;
            // 
            // GbxTargetBranch
            // 
            this.GbxTargetBranch.Controls.Add(this.CbxBranches);
            this.GbxTargetBranch.Controls.Add(this.LblSelectBranch);
            this.GbxTargetBranch.Controls.Add(this.RbtIsRemoteTargetBranch);
            this.GbxTargetBranch.Controls.Add(this.RbtIsLocalTargetBranch);
            this.GbxTargetBranch.Location = new System.Drawing.Point(0, 83);
            this.GbxTargetBranch.Name = "GbxTargetBranch";
            this.GbxTargetBranch.Size = new System.Drawing.Size(1101, 71);
            this.GbxTargetBranch.TabIndex = 2;
            this.GbxTargetBranch.TabStop = false;
            this.GbxTargetBranch.Text = "Target branch";
            // 
            // CbxBranches
            // 
            this.CbxBranches.FormattingEnabled = true;
            this.CbxBranches.Location = new System.Drawing.Point(395, 30);
            this.CbxBranches.Name = "CbxBranches";
            this.CbxBranches.Size = new System.Drawing.Size(546, 23);
            this.CbxBranches.TabIndex = 3;
            this.CbxBranches.SelectedIndexChanged += new System.EventHandler(this.CbxBranches_SelectedIndexChanged);
            // 
            // LblSelectBranch
            // 
            this.LblSelectBranch.AutoSize = true;
            this.LblSelectBranch.Location = new System.Drawing.Point(311, 33);
            this.LblSelectBranch.Name = "LblSelectBranch";
            this.LblSelectBranch.Size = new System.Drawing.Size(78, 15);
            this.LblSelectBranch.TabIndex = 2;
            this.LblSelectBranch.Text = "Select branch";
            // 
            // RbtIsRemoteTargetBranch
            // 
            this.RbtIsRemoteTargetBranch.AutoSize = true;
            this.RbtIsRemoteTargetBranch.Location = new System.Drawing.Point(152, 31);
            this.RbtIsRemoteTargetBranch.Name = "RbtIsRemoteTargetBranch";
            this.RbtIsRemoteTargetBranch.Size = new System.Drawing.Size(106, 19);
            this.RbtIsRemoteTargetBranch.TabIndex = 1;
            this.RbtIsRemoteTargetBranch.TabStop = true;
            this.RbtIsRemoteTargetBranch.Text = "Remote branch";
            this.RbtIsRemoteTargetBranch.UseVisualStyleBackColor = true;
            this.RbtIsRemoteTargetBranch.CheckedChanged += new System.EventHandler(this.RbtIsRemoteOrLocalTargetBranchCheckedChanged);
            // 
            // RbtIsLocalTargetBranch
            // 
            this.RbtIsLocalTargetBranch.AutoSize = true;
            this.RbtIsLocalTargetBranch.Location = new System.Drawing.Point(15, 31);
            this.RbtIsLocalTargetBranch.Name = "RbtIsLocalTargetBranch";
            this.RbtIsLocalTargetBranch.Size = new System.Drawing.Size(93, 19);
            this.RbtIsLocalTargetBranch.TabIndex = 0;
            this.RbtIsLocalTargetBranch.TabStop = true;
            this.RbtIsLocalTargetBranch.Text = "Local branch";
            this.RbtIsLocalTargetBranch.UseVisualStyleBackColor = true;
            this.RbtIsLocalTargetBranch.CheckedChanged += new System.EventHandler(this.RbtIsRemoteOrLocalTargetBranchCheckedChanged);
            // 
            // GbxProcess
            // 
            this.GbxProcess.Controls.Add(this.LblNext8);
            this.GbxProcess.Controls.Add(this.CbxIsGitClean);
            this.GbxProcess.Controls.Add(this.BtnRunProcess);
            this.GbxProcess.Controls.Add(this.CbxIsExitVisualStudio);
            this.GbxProcess.Controls.Add(this.CbxIsRunVisualStudio);
            this.GbxProcess.Controls.Add(this.LblNext1);
            this.GbxProcess.Controls.Add(this.LblNext7);
            this.GbxProcess.Controls.Add(this.CbxIsStashChanges);
            this.GbxProcess.Controls.Add(this.CbxIsRunScriptNextVersion);
            this.GbxProcess.Controls.Add(this.LblNext2);
            this.GbxProcess.Controls.Add(this.LblNext6);
            this.GbxProcess.Controls.Add(this.CbxIsCheckoutBranch);
            this.GbxProcess.Controls.Add(this.CbxIsBuildSolution);
            this.GbxProcess.Controls.Add(this.LblNext3);
            this.GbxProcess.Controls.Add(this.LblNext4);
            this.GbxProcess.Controls.Add(this.CbxIsNugetUpdate);
            this.GbxProcess.Location = new System.Drawing.Point(0, 156);
            this.GbxProcess.Name = "GbxProcess";
            this.GbxProcess.Size = new System.Drawing.Size(1096, 102);
            this.GbxProcess.TabIndex = 3;
            this.GbxProcess.TabStop = false;
            this.GbxProcess.Text = "Process";
            // 
            // LblNext8
            // 
            this.LblNext8.AutoSize = true;
            this.LblNext8.Location = new System.Drawing.Point(939, 26);
            this.LblNext8.Name = "LblNext8";
            this.LblNext8.Size = new System.Drawing.Size(31, 15);
            this.LblNext8.TabIndex = 15;
            this.LblNext8.Text = "==>";
            // 
            // CbxIsGitClean
            // 
            this.CbxIsGitClean.AutoSize = true;
            this.CbxIsGitClean.Checked = true;
            this.CbxIsGitClean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsGitClean.Location = new System.Drawing.Point(464, 25);
            this.CbxIsGitClean.Name = "CbxIsGitClean";
            this.CbxIsGitClean.Size = new System.Drawing.Size(96, 19);
            this.CbxIsGitClean.TabIndex = 14;
            this.CbxIsGitClean.Text = "Git clean -xfd";
            this.CbxIsGitClean.UseVisualStyleBackColor = true;
            // 
            // BtnRunProcess
            // 
            this.BtnRunProcess.Location = new System.Drawing.Point(972, 54);
            this.BtnRunProcess.Name = "BtnRunProcess";
            this.BtnRunProcess.Size = new System.Drawing.Size(118, 32);
            this.BtnRunProcess.TabIndex = 13;
            this.BtnRunProcess.Text = "Run process";
            this.BtnRunProcess.UseVisualStyleBackColor = true;
            this.BtnRunProcess.Click += new System.EventHandler(this.BtnRunProcessClick);
            // 
            // CbxIsExitVisualStudio
            // 
            this.CbxIsExitVisualStudio.AutoSize = true;
            this.CbxIsExitVisualStudio.Checked = true;
            this.CbxIsExitVisualStudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsExitVisualStudio.Location = new System.Drawing.Point(15, 25);
            this.CbxIsExitVisualStudio.Name = "CbxIsExitVisualStudio";
            this.CbxIsExitVisualStudio.Size = new System.Drawing.Size(115, 19);
            this.CbxIsExitVisualStudio.TabIndex = 0;
            this.CbxIsExitVisualStudio.Text = "Exit Visual Studio";
            this.CbxIsExitVisualStudio.UseVisualStyleBackColor = true;
            // 
            // CbxIsRunVisualStudio
            // 
            this.CbxIsRunVisualStudio.AutoSize = true;
            this.CbxIsRunVisualStudio.Checked = true;
            this.CbxIsRunVisualStudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsRunVisualStudio.Location = new System.Drawing.Point(972, 25);
            this.CbxIsRunVisualStudio.Name = "CbxIsRunVisualStudio";
            this.CbxIsRunVisualStudio.Size = new System.Drawing.Size(118, 19);
            this.CbxIsRunVisualStudio.TabIndex = 12;
            this.CbxIsRunVisualStudio.Text = "Run Visual Studio";
            this.CbxIsRunVisualStudio.UseVisualStyleBackColor = true;
            // 
            // LblNext1
            // 
            this.LblNext1.AutoSize = true;
            this.LblNext1.Location = new System.Drawing.Point(125, 26);
            this.LblNext1.Name = "LblNext1";
            this.LblNext1.Size = new System.Drawing.Size(31, 15);
            this.LblNext1.TabIndex = 3;
            this.LblNext1.Text = "==>";
            // 
            // LblNext7
            // 
            this.LblNext7.AutoSize = true;
            this.LblNext7.Location = new System.Drawing.Point(813, 26);
            this.LblNext7.Name = "LblNext7";
            this.LblNext7.Size = new System.Drawing.Size(31, 15);
            this.LblNext7.TabIndex = 11;
            this.LblNext7.Text = "==>";
            // 
            // CbxIsStashChanges
            // 
            this.CbxIsStashChanges.AutoSize = true;
            this.CbxIsStashChanges.Checked = true;
            this.CbxIsStashChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsStashChanges.Location = new System.Drawing.Point(157, 25);
            this.CbxIsStashChanges.Name = "CbxIsStashChanges";
            this.CbxIsStashChanges.Size = new System.Drawing.Size(101, 19);
            this.CbxIsStashChanges.TabIndex = 1;
            this.CbxIsStashChanges.Text = "Stash changes";
            this.CbxIsStashChanges.UseVisualStyleBackColor = true;
            // 
            // CbxIsRunScriptNextVersion
            // 
            this.CbxIsRunScriptNextVersion.AutoSize = true;
            this.CbxIsRunScriptNextVersion.Checked = true;
            this.CbxIsRunScriptNextVersion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsRunScriptNextVersion.Location = new System.Drawing.Point(844, 25);
            this.CbxIsRunScriptNextVersion.Name = "CbxIsRunScriptNextVersion";
            this.CbxIsRunScriptNextVersion.Size = new System.Drawing.Size(98, 19);
            this.CbxIsRunScriptNextVersion.TabIndex = 10;
            this.CbxIsRunScriptNextVersion.Text = "Run script NV";
            this.CbxIsRunScriptNextVersion.UseVisualStyleBackColor = true;
            // 
            // LblNext2
            // 
            this.LblNext2.AutoSize = true;
            this.LblNext2.Location = new System.Drawing.Point(253, 26);
            this.LblNext2.Name = "LblNext2";
            this.LblNext2.Size = new System.Drawing.Size(31, 15);
            this.LblNext2.TabIndex = 4;
            this.LblNext2.Text = "==>";
            // 
            // LblNext6
            // 
            this.LblNext6.AutoSize = true;
            this.LblNext6.Location = new System.Drawing.Point(688, 26);
            this.LblNext6.Name = "LblNext6";
            this.LblNext6.Size = new System.Drawing.Size(31, 15);
            this.LblNext6.TabIndex = 9;
            this.LblNext6.Text = "==>";
            // 
            // CbxIsCheckoutBranch
            // 
            this.CbxIsCheckoutBranch.AutoSize = true;
            this.CbxIsCheckoutBranch.Checked = true;
            this.CbxIsCheckoutBranch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsCheckoutBranch.Location = new System.Drawing.Point(286, 25);
            this.CbxIsCheckoutBranch.Name = "CbxIsCheckoutBranch";
            this.CbxIsCheckoutBranch.Size = new System.Drawing.Size(151, 19);
            this.CbxIsCheckoutBranch.TabIndex = 2;
            this.CbxIsCheckoutBranch.Text = "Checkout target branch";
            this.CbxIsCheckoutBranch.UseVisualStyleBackColor = true;
            // 
            // CbxIsBuildSolution
            // 
            this.CbxIsBuildSolution.AutoSize = true;
            this.CbxIsBuildSolution.Checked = true;
            this.CbxIsBuildSolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsBuildSolution.Location = new System.Drawing.Point(722, 25);
            this.CbxIsBuildSolution.Name = "CbxIsBuildSolution";
            this.CbxIsBuildSolution.Size = new System.Drawing.Size(99, 19);
            this.CbxIsBuildSolution.TabIndex = 8;
            this.CbxIsBuildSolution.Text = "Build solution";
            this.CbxIsBuildSolution.UseVisualStyleBackColor = true;
            // 
            // LblNext3
            // 
            this.LblNext3.AutoSize = true;
            this.LblNext3.Location = new System.Drawing.Point(432, 26);
            this.LblNext3.Name = "LblNext3";
            this.LblNext3.Size = new System.Drawing.Size(31, 15);
            this.LblNext3.TabIndex = 5;
            this.LblNext3.Text = "==>";
            // 
            // LblNext4
            // 
            this.LblNext4.AutoSize = true;
            this.LblNext4.Location = new System.Drawing.Point(558, 26);
            this.LblNext4.Name = "LblNext4";
            this.LblNext4.Size = new System.Drawing.Size(31, 15);
            this.LblNext4.TabIndex = 7;
            this.LblNext4.Text = "==>";
            // 
            // CbxIsNugetUpdate
            // 
            this.CbxIsNugetUpdate.AutoSize = true;
            this.CbxIsNugetUpdate.Checked = true;
            this.CbxIsNugetUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsNugetUpdate.Location = new System.Drawing.Point(592, 25);
            this.CbxIsNugetUpdate.Name = "CbxIsNugetUpdate";
            this.CbxIsNugetUpdate.Size = new System.Drawing.Size(99, 19);
            this.CbxIsNugetUpdate.TabIndex = 6;
            this.CbxIsNugetUpdate.Text = "Nuget update";
            this.CbxIsNugetUpdate.UseVisualStyleBackColor = true;
            // 
            // TbpSolutions
            // 
            this.TbpSolutions.Controls.Add(this.GbxSolutionsActions);
            this.TbpSolutions.Controls.Add(this.DgvSolutions);
            this.TbpSolutions.Location = new System.Drawing.Point(4, 24);
            this.TbpSolutions.Name = "TbpSolutions";
            this.TbpSolutions.Padding = new System.Windows.Forms.Padding(3);
            this.TbpSolutions.Size = new System.Drawing.Size(1104, 393);
            this.TbpSolutions.TabIndex = 0;
            this.TbpSolutions.Text = "Solutions";
            this.TbpSolutions.UseVisualStyleBackColor = true;
            // 
            // GbxSolutionsActions
            // 
            this.GbxSolutionsActions.Location = new System.Drawing.Point(8, 159);
            this.GbxSolutionsActions.Name = "GbxSolutionsActions";
            this.GbxSolutionsActions.Size = new System.Drawing.Size(200, 100);
            this.GbxSolutionsActions.TabIndex = 1;
            this.GbxSolutionsActions.TabStop = false;
            this.GbxSolutionsActions.Text = "groupBox1";
            // 
            // DgvSolutions
            // 
            this.DgvSolutions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSolutions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcFileName,
            this.DgcPath});
            this.DgvSolutions.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvSolutions.Location = new System.Drawing.Point(3, 3);
            this.DgvSolutions.Name = "DgvSolutions";
            this.DgvSolutions.Size = new System.Drawing.Size(1098, 150);
            this.DgvSolutions.TabIndex = 0;
            // 
            // DgcFileName
            // 
            this.DgcFileName.HeaderText = "FileName";
            this.DgcFileName.Name = "DgcFileName";
            this.DgcFileName.Width = 200;
            // 
            // DgcPath
            // 
            this.DgcPath.HeaderText = "Path";
            this.DgcPath.Name = "DgcPath";
            this.DgcPath.Width = 700;
            // 
            // TbpSql
            // 
            this.TbpSql.Location = new System.Drawing.Point(4, 24);
            this.TbpSql.Name = "TbpSql";
            this.TbpSql.Padding = new System.Windows.Forms.Padding(3);
            this.TbpSql.Size = new System.Drawing.Size(1104, 393);
            this.TbpSql.TabIndex = 1;
            this.TbpSql.Text = "SQL Server";
            this.TbpSql.UseVisualStyleBackColor = true;
            // 
            // TalentsoftTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 421);
            this.Controls.Add(this.TbcMain);
            this.Name = "TalentsoftTools";
            this.Text = "TalentsoftTools";
            this.TbcMain.ResumeLayout(false);
            this.TbpProcess.ResumeLayout(false);
            this.GbxTargetSolution.ResumeLayout(false);
            this.GbxTargetSolution.PerformLayout();
            this.GbxTargetBranch.ResumeLayout(false);
            this.GbxTargetBranch.PerformLayout();
            this.GbxProcess.ResumeLayout(false);
            this.GbxProcess.PerformLayout();
            this.TbpSolutions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSolutions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcMain;
        private System.Windows.Forms.TabPage TbpSolutions;
        private System.Windows.Forms.DataGridView DgvSolutions;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcPath;
        private System.Windows.Forms.TabPage TbpSql;
        private System.Windows.Forms.GroupBox GbxSolutionsActions;
        private System.Windows.Forms.TabPage TbpProcess;
        private System.Windows.Forms.CheckBox CbxIsExitVisualStudio;
        private System.Windows.Forms.CheckBox CbxIsStashChanges;
        private System.Windows.Forms.Label LblNext3;
        private System.Windows.Forms.Label LblNext2;
        private System.Windows.Forms.Label LblNext1;
        private System.Windows.Forms.CheckBox CbxIsCheckoutBranch;
        private System.Windows.Forms.CheckBox CbxIsBuildSolution;
        private System.Windows.Forms.Label LblNext4;
        private System.Windows.Forms.CheckBox CbxIsNugetUpdate;
        private System.Windows.Forms.CheckBox CbxIsRunScriptNextVersion;
        private System.Windows.Forms.Label LblNext6;
        private System.Windows.Forms.CheckBox CbxIsRunVisualStudio;
        private System.Windows.Forms.Label LblNext7;
        private System.Windows.Forms.GroupBox GbxProcess;
        private System.Windows.Forms.Button BtnRunProcess;
        private System.Windows.Forms.GroupBox GbxTargetBranch;
        private System.Windows.Forms.RadioButton RbtIsLocalTargetBranch;
        private System.Windows.Forms.RadioButton RbtIsRemoteTargetBranch;
        private System.Windows.Forms.Label LblSelectBranch;
        private System.Windows.Forms.ComboBox CbxBranches;
        private System.Windows.Forms.GroupBox GbxTargetSolution;
        private System.Windows.Forms.Label LblTargetSolutionFileName;
        private System.Windows.Forms.Label LblTargetSolutionFileNameLabel;
        private System.Windows.Forms.CheckBox CbxIsGitClean;
        private System.Windows.Forms.Label LblNext8;
        private System.Windows.Forms.ComboBox CbxSolutions;
    }
}