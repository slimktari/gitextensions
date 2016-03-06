namespace TalentsoftTools
{
    partial class TalentsoftToolsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalentsoftToolsForm));
            this.TbcMain = new System.Windows.Forms.TabControl();
            this.TbpProcess = new System.Windows.Forms.TabPage();
            this.BgxLogInfo = new System.Windows.Forms.GroupBox();
            this.TbxLogInfo = new System.Windows.Forms.TextBox();
            this.GbxTargetSolution = new System.Windows.Forms.GroupBox();
            this.CblSolutions = new System.Windows.Forms.ComboBox();
            this.LblTargetSolutionFileNameLabel = new System.Windows.Forms.Label();
            this.LblTargetSolutionFileName = new System.Windows.Forms.Label();
            this.GbxTargetBranch = new System.Windows.Forms.GroupBox();
            this.ActBranches = new TalentsoftTools.Components.AutoCompleteTextBox();
            this.TxbNewBranchName = new System.Windows.Forms.TextBox();
            this.CbxIsCreateNewBranch = new System.Windows.Forms.CheckBox();
            this.LblSelectBranch = new System.Windows.Forms.Label();
            this.RbtIsRemoteTargetBranch = new System.Windows.Forms.RadioButton();
            this.RbtIsLocalTargetBranch = new System.Windows.Forms.RadioButton();
            this.GbxProcess = new System.Windows.Forms.GroupBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.CbxIsPreBuild = new System.Windows.Forms.CheckBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.CbxIsPostBuild = new System.Windows.Forms.CheckBox();
            this.TxbUri = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.CbxIsStashPop = new System.Windows.Forms.CheckBox();
            this.PbxLoading = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnStopProcess = new System.Windows.Forms.Button();
            this.CbxLaunchUri = new System.Windows.Forms.CheckBox();
            this.CbxIsGitClean = new System.Windows.Forms.CheckBox();
            this.BtnRunProcess = new System.Windows.Forms.Button();
            this.CbxIsExitVisualStudio = new System.Windows.Forms.CheckBox();
            this.CbxIsRunVisualStudio = new System.Windows.Forms.CheckBox();
            this.CbxIsStashChanges = new System.Windows.Forms.CheckBox();
            this.CbxIsCheckoutBranch = new System.Windows.Forms.CheckBox();
            this.CbxIsBuildSolution = new System.Windows.Forms.CheckBox();
            this.TbpLocalsBranches = new System.Windows.Forms.TabPage();
            this.GbxLocalsBranchesActions = new System.Windows.Forms.GroupBox();
            this.BtnDeleteWithRemote = new System.Windows.Forms.Button();
            this.BtnDeleteLocalsBranches = new System.Windows.Forms.Button();
            this.DgvLocalsBranches = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GbxActualInfos = new System.Windows.Forms.GroupBox();
            this.LblActualRepository = new System.Windows.Forms.Label();
            this.LblActualRepositoryLabel = new System.Windows.Forms.Label();
            this.LblActualBranchName = new System.Windows.Forms.Label();
            this.LblActualBranchNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TbcMain.SuspendLayout();
            this.TbpProcess.SuspendLayout();
            this.BgxLogInfo.SuspendLayout();
            this.GbxTargetSolution.SuspendLayout();
            this.GbxTargetBranch.SuspendLayout();
            this.GbxProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TbpLocalsBranches.SuspendLayout();
            this.GbxLocalsBranchesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchDtoBindingSource)).BeginInit();
            this.GbxActualInfos.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcMain
            // 
            this.TbcMain.Controls.Add(this.TbpProcess);
            this.TbcMain.Controls.Add(this.TbpLocalsBranches);
            this.TbcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TbcMain.Location = new System.Drawing.Point(0, 87);
            this.TbcMain.Name = "TbcMain";
            this.TbcMain.SelectedIndex = 0;
            this.TbcMain.Size = new System.Drawing.Size(990, 650);
            this.TbcMain.TabIndex = 0;
            this.TbcMain.SelectedIndexChanged += new System.EventHandler(this.TbcMainSelectedIndexChanged);
            // 
            // TbpProcess
            // 
            this.TbpProcess.Controls.Add(this.BgxLogInfo);
            this.TbpProcess.Controls.Add(this.GbxTargetSolution);
            this.TbpProcess.Controls.Add(this.GbxTargetBranch);
            this.TbpProcess.Controls.Add(this.GbxProcess);
            this.TbpProcess.Location = new System.Drawing.Point(4, 24);
            this.TbpProcess.Name = "TbpProcess";
            this.TbpProcess.Size = new System.Drawing.Size(982, 622);
            this.TbpProcess.TabIndex = 2;
            this.TbpProcess.Text = "Process";
            this.TbpProcess.UseVisualStyleBackColor = true;
            // 
            // BgxLogInfo
            // 
            this.BgxLogInfo.Controls.Add(this.TbxLogInfo);
            this.BgxLogInfo.Location = new System.Drawing.Point(1, 333);
            this.BgxLogInfo.Name = "BgxLogInfo";
            this.BgxLogInfo.Size = new System.Drawing.Size(975, 291);
            this.BgxLogInfo.TabIndex = 4;
            this.BgxLogInfo.TabStop = false;
            this.BgxLogInfo.Text = "Log info";
            // 
            // TbxLogInfo
            // 
            this.TbxLogInfo.BackColor = System.Drawing.SystemColors.MenuText;
            this.TbxLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbxLogInfo.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxLogInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.TbxLogInfo.Location = new System.Drawing.Point(3, 19);
            this.TbxLogInfo.Multiline = true;
            this.TbxLogInfo.Name = "TbxLogInfo";
            this.TbxLogInfo.ReadOnly = true;
            this.TbxLogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbxLogInfo.Size = new System.Drawing.Size(969, 269);
            this.TbxLogInfo.TabIndex = 1;
            // 
            // GbxTargetSolution
            // 
            this.GbxTargetSolution.Controls.Add(this.CblSolutions);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileNameLabel);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileName);
            this.GbxTargetSolution.Location = new System.Drawing.Point(1, 3);
            this.GbxTargetSolution.Name = "GbxTargetSolution";
            this.GbxTargetSolution.Size = new System.Drawing.Size(975, 73);
            this.GbxTargetSolution.TabIndex = 0;
            this.GbxTargetSolution.TabStop = false;
            this.GbxTargetSolution.Text = "Target solution";
            // 
            // CblSolutions
            // 
            this.CblSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CblSolutions.FormattingEnabled = true;
            this.CblSolutions.Location = new System.Drawing.Point(119, 28);
            this.CblSolutions.Name = "CblSolutions";
            this.CblSolutions.Size = new System.Drawing.Size(844, 23);
            this.CblSolutions.TabIndex = 3;
            // 
            // LblTargetSolutionFileNameLabel
            // 
            this.LblTargetSolutionFileNameLabel.AutoSize = true;
            this.LblTargetSolutionFileNameLabel.Location = new System.Drawing.Point(15, 31);
            this.LblTargetSolutionFileNameLabel.Name = "LblTargetSolutionFileNameLabel";
            this.LblTargetSolutionFileNameLabel.Size = new System.Drawing.Size(84, 15);
            this.LblTargetSolutionFileNameLabel.TabIndex = 1;
            this.LblTargetSolutionFileNameLabel.Text = "Solution path :";
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
            this.GbxTargetBranch.Controls.Add(this.ActBranches);
            this.GbxTargetBranch.Controls.Add(this.TxbNewBranchName);
            this.GbxTargetBranch.Controls.Add(this.CbxIsCreateNewBranch);
            this.GbxTargetBranch.Controls.Add(this.LblSelectBranch);
            this.GbxTargetBranch.Controls.Add(this.RbtIsRemoteTargetBranch);
            this.GbxTargetBranch.Controls.Add(this.RbtIsLocalTargetBranch);
            this.GbxTargetBranch.Location = new System.Drawing.Point(3, 78);
            this.GbxTargetBranch.Name = "GbxTargetBranch";
            this.GbxTargetBranch.Size = new System.Drawing.Size(973, 108);
            this.GbxTargetBranch.TabIndex = 2;
            this.GbxTargetBranch.TabStop = false;
            this.GbxTargetBranch.Text = "Target branch";
            // 
            // ActBranches
            // 
            this.ActBranches.Location = new System.Drawing.Point(352, 30);
            this.ActBranches.Name = "ActBranches";
            this.ActBranches.Size = new System.Drawing.Size(609, 23);
            this.ActBranches.TabIndex = 6;
            this.ActBranches.Values = null;
            // 
            // TxbNewBranchName
            // 
            this.TxbNewBranchName.Location = new System.Drawing.Point(352, 67);
            this.TxbNewBranchName.Name = "TxbNewBranchName";
            this.TxbNewBranchName.Size = new System.Drawing.Size(609, 23);
            this.TxbNewBranchName.TabIndex = 5;
            // 
            // CbxIsCreateNewBranch
            // 
            this.CbxIsCreateNewBranch.AutoSize = true;
            this.CbxIsCreateNewBranch.Location = new System.Drawing.Point(117, 69);
            this.CbxIsCreateNewBranch.Name = "CbxIsCreateNewBranch";
            this.CbxIsCreateNewBranch.Size = new System.Drawing.Size(200, 19);
            this.CbxIsCreateNewBranch.TabIndex = 4;
            this.CbxIsCreateNewBranch.Text = "Create and checkout new branch";
            this.CbxIsCreateNewBranch.UseVisualStyleBackColor = true;
            this.CbxIsCreateNewBranch.CheckedChanged += new System.EventHandler(this.CbxIsCreateNewBranchCheckedChanged);
            // 
            // LblSelectBranch
            // 
            this.LblSelectBranch.AutoSize = true;
            this.LblSelectBranch.Location = new System.Drawing.Point(268, 33);
            this.LblSelectBranch.Name = "LblSelectBranch";
            this.LblSelectBranch.Size = new System.Drawing.Size(78, 15);
            this.LblSelectBranch.TabIndex = 2;
            this.LblSelectBranch.Text = "Select branch";
            // 
            // RbtIsRemoteTargetBranch
            // 
            this.RbtIsRemoteTargetBranch.AutoSize = true;
            this.RbtIsRemoteTargetBranch.Location = new System.Drawing.Point(117, 31);
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
            this.GbxProcess.Controls.Add(this.pictureBox10);
            this.GbxProcess.Controls.Add(this.CbxIsPreBuild);
            this.GbxProcess.Controls.Add(this.pictureBox9);
            this.GbxProcess.Controls.Add(this.CbxIsPostBuild);
            this.GbxProcess.Controls.Add(this.TxbUri);
            this.GbxProcess.Controls.Add(this.pictureBox7);
            this.GbxProcess.Controls.Add(this.CbxIsStashPop);
            this.GbxProcess.Controls.Add(this.PbxLoading);
            this.GbxProcess.Controls.Add(this.pictureBox6);
            this.GbxProcess.Controls.Add(this.pictureBox5);
            this.GbxProcess.Controls.Add(this.pictureBox4);
            this.GbxProcess.Controls.Add(this.pictureBox3);
            this.GbxProcess.Controls.Add(this.pictureBox2);
            this.GbxProcess.Controls.Add(this.pictureBox1);
            this.GbxProcess.Controls.Add(this.BtnStopProcess);
            this.GbxProcess.Controls.Add(this.CbxLaunchUri);
            this.GbxProcess.Controls.Add(this.CbxIsGitClean);
            this.GbxProcess.Controls.Add(this.BtnRunProcess);
            this.GbxProcess.Controls.Add(this.CbxIsExitVisualStudio);
            this.GbxProcess.Controls.Add(this.CbxIsRunVisualStudio);
            this.GbxProcess.Controls.Add(this.CbxIsStashChanges);
            this.GbxProcess.Controls.Add(this.CbxIsCheckoutBranch);
            this.GbxProcess.Controls.Add(this.CbxIsBuildSolution);
            this.GbxProcess.Location = new System.Drawing.Point(1, 187);
            this.GbxProcess.Name = "GbxProcess";
            this.GbxProcess.Size = new System.Drawing.Size(975, 142);
            this.GbxProcess.TabIndex = 3;
            this.GbxProcess.TabStop = false;
            this.GbxProcess.Text = "Process";
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox10.Location = new System.Drawing.Point(892, 19);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(33, 30);
            this.pictureBox10.TabIndex = 32;
            this.pictureBox10.TabStop = false;
            // 
            // CbxIsPreBuild
            // 
            this.CbxIsPreBuild.AutoSize = true;
            this.CbxIsPreBuild.Checked = true;
            this.CbxIsPreBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsPreBuild.Location = new System.Drawing.Point(790, 25);
            this.CbxIsPreBuild.Name = "CbxIsPreBuild";
            this.CbxIsPreBuild.Size = new System.Drawing.Size(94, 19);
            this.CbxIsPreBuild.TabIndex = 31;
            this.CbxIsPreBuild.Text = "Run PreBuild";
            this.CbxIsPreBuild.UseVisualStyleBackColor = true;
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox9.Location = new System.Drawing.Point(272, 57);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(33, 30);
            this.pictureBox9.TabIndex = 30;
            this.pictureBox9.TabStop = false;
            // 
            // CbxIsPostBuild
            // 
            this.CbxIsPostBuild.AutoSize = true;
            this.CbxIsPostBuild.Checked = true;
            this.CbxIsPostBuild.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsPostBuild.Location = new System.Drawing.Point(318, 63);
            this.CbxIsPostBuild.Name = "CbxIsPostBuild";
            this.CbxIsPostBuild.Size = new System.Drawing.Size(103, 19);
            this.CbxIsPostBuild.TabIndex = 29;
            this.CbxIsPostBuild.Text = "Run post build";
            this.CbxIsPostBuild.UseVisualStyleBackColor = true;
            // 
            // TxbUri
            // 
            this.TxbUri.Location = new System.Drawing.Point(615, 62);
            this.TxbUri.Name = "TxbUri";
            this.TxbUri.Size = new System.Drawing.Size(348, 23);
            this.TxbUri.TabIndex = 27;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox7.Location = new System.Drawing.Point(615, 19);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(33, 30);
            this.pictureBox7.TabIndex = 26;
            this.pictureBox7.TabStop = false;
            // 
            // CbxIsStashPop
            // 
            this.CbxIsStashPop.AutoSize = true;
            this.CbxIsStashPop.Checked = true;
            this.CbxIsStashPop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsStashPop.Location = new System.Drawing.Point(660, 25);
            this.CbxIsStashPop.Name = "CbxIsStashPop";
            this.CbxIsStashPop.Size = new System.Drawing.Size(78, 19);
            this.CbxIsStashPop.TabIndex = 25;
            this.CbxIsStashPop.Text = "Stash pop";
            this.CbxIsStashPop.UseVisualStyleBackColor = true;
            // 
            // PbxLoading
            // 
            this.PbxLoading.Image = global::TalentsoftTools.Properties.Resources.switchingCircle;
            this.PbxLoading.Location = new System.Drawing.Point(808, 104);
            this.PbxLoading.Name = "PbxLoading";
            this.PbxLoading.Size = new System.Drawing.Size(37, 19);
            this.PbxLoading.TabIndex = 24;
            this.PbxLoading.TabStop = false;
            this.PbxLoading.Visible = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox6.Location = new System.Drawing.Point(486, 58);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(33, 30);
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox5.Location = new System.Drawing.Point(119, 58);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 30);
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox4.Location = new System.Drawing.Point(745, 19);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 30);
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox3.Location = new System.Drawing.Point(486, 19);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 30);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox2.Location = new System.Drawing.Point(273, 19);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 30);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox1.Location = new System.Drawing.Point(119, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // BtnStopProcess
            // 
            this.BtnStopProcess.Location = new System.Drawing.Point(13, 95);
            this.BtnStopProcess.Name = "BtnStopProcess";
            this.BtnStopProcess.Size = new System.Drawing.Size(118, 32);
            this.BtnStopProcess.TabIndex = 17;
            this.BtnStopProcess.Text = "Stop process";
            this.BtnStopProcess.UseVisualStyleBackColor = true;
            this.BtnStopProcess.Click += new System.EventHandler(this.BtnStopProcessClick);
            // 
            // CbxLaunchUri
            // 
            this.CbxLaunchUri.AutoSize = true;
            this.CbxLaunchUri.Checked = true;
            this.CbxLaunchUri.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxLaunchUri.Location = new System.Drawing.Point(531, 64);
            this.CbxLaunchUri.Name = "CbxLaunchUri";
            this.CbxLaunchUri.Size = new System.Drawing.Size(86, 19);
            this.CbxLaunchUri.TabIndex = 16;
            this.CbxLaunchUri.Text = "Launch URI";
            this.CbxLaunchUri.UseVisualStyleBackColor = true;
            // 
            // CbxIsGitClean
            // 
            this.CbxIsGitClean.AutoSize = true;
            this.CbxIsGitClean.Checked = true;
            this.CbxIsGitClean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsGitClean.Location = new System.Drawing.Point(531, 25);
            this.CbxIsGitClean.Name = "CbxIsGitClean";
            this.CbxIsGitClean.Size = new System.Drawing.Size(72, 19);
            this.CbxIsGitClean.TabIndex = 14;
            this.CbxIsGitClean.Text = "Git clean";
            this.CbxIsGitClean.UseVisualStyleBackColor = true;
            // 
            // BtnRunProcess
            // 
            this.BtnRunProcess.Location = new System.Drawing.Point(845, 95);
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
            this.CbxIsExitVisualStudio.Location = new System.Drawing.Point(13, 25);
            this.CbxIsExitVisualStudio.Name = "CbxIsExitVisualStudio";
            this.CbxIsExitVisualStudio.Size = new System.Drawing.Size(60, 19);
            this.CbxIsExitVisualStudio.TabIndex = 0;
            this.CbxIsExitVisualStudio.Text = "Exit VS";
            this.CbxIsExitVisualStudio.UseVisualStyleBackColor = true;
            // 
            // CbxIsRunVisualStudio
            // 
            this.CbxIsRunVisualStudio.AutoSize = true;
            this.CbxIsRunVisualStudio.Checked = true;
            this.CbxIsRunVisualStudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsRunVisualStudio.Location = new System.Drawing.Point(165, 64);
            this.CbxIsRunVisualStudio.Name = "CbxIsRunVisualStudio";
            this.CbxIsRunVisualStudio.Size = new System.Drawing.Size(63, 19);
            this.CbxIsRunVisualStudio.TabIndex = 12;
            this.CbxIsRunVisualStudio.Text = "Run VS";
            this.CbxIsRunVisualStudio.UseVisualStyleBackColor = true;
            // 
            // CbxIsStashChanges
            // 
            this.CbxIsStashChanges.AutoSize = true;
            this.CbxIsStashChanges.Checked = true;
            this.CbxIsStashChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsStashChanges.Location = new System.Drawing.Point(164, 25);
            this.CbxIsStashChanges.Name = "CbxIsStashChanges";
            this.CbxIsStashChanges.Size = new System.Drawing.Size(101, 19);
            this.CbxIsStashChanges.TabIndex = 1;
            this.CbxIsStashChanges.Text = "Stash changes";
            this.CbxIsStashChanges.UseVisualStyleBackColor = true;
            this.CbxIsStashChanges.CheckedChanged += new System.EventHandler(this.CbxIsStashChanges_CheckedChanged);
            // 
            // CbxIsCheckoutBranch
            // 
            this.CbxIsCheckoutBranch.AutoSize = true;
            this.CbxIsCheckoutBranch.Checked = true;
            this.CbxIsCheckoutBranch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsCheckoutBranch.Location = new System.Drawing.Point(317, 25);
            this.CbxIsCheckoutBranch.Name = "CbxIsCheckoutBranch";
            this.CbxIsCheckoutBranch.Size = new System.Drawing.Size(162, 19);
            this.CbxIsCheckoutBranch.TabIndex = 2;
            this.CbxIsCheckoutBranch.Text = "Checkout / Create branch";
            this.CbxIsCheckoutBranch.UseVisualStyleBackColor = true;
            // 
            // CbxIsBuildSolution
            // 
            this.CbxIsBuildSolution.AutoSize = true;
            this.CbxIsBuildSolution.Checked = true;
            this.CbxIsBuildSolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsBuildSolution.Location = new System.Drawing.Point(13, 64);
            this.CbxIsBuildSolution.Name = "CbxIsBuildSolution";
            this.CbxIsBuildSolution.Size = new System.Drawing.Size(99, 19);
            this.CbxIsBuildSolution.TabIndex = 8;
            this.CbxIsBuildSolution.Text = "Build solution";
            this.CbxIsBuildSolution.UseVisualStyleBackColor = true;
            // 
            // TbpLocalsBranches
            // 
            this.TbpLocalsBranches.Controls.Add(this.GbxLocalsBranchesActions);
            this.TbpLocalsBranches.Controls.Add(this.DgvLocalsBranches);
            this.TbpLocalsBranches.Location = new System.Drawing.Point(4, 24);
            this.TbpLocalsBranches.Name = "TbpLocalsBranches";
            this.TbpLocalsBranches.Padding = new System.Windows.Forms.Padding(3);
            this.TbpLocalsBranches.Size = new System.Drawing.Size(982, 622);
            this.TbpLocalsBranches.TabIndex = 0;
            this.TbpLocalsBranches.Text = "Locals branches";
            this.TbpLocalsBranches.UseVisualStyleBackColor = true;
            // 
            // GbxLocalsBranchesActions
            // 
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnDeleteWithRemote);
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnDeleteLocalsBranches);
            this.GbxLocalsBranchesActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GbxLocalsBranchesActions.Location = new System.Drawing.Point(3, 545);
            this.GbxLocalsBranchesActions.Name = "GbxLocalsBranchesActions";
            this.GbxLocalsBranchesActions.Size = new System.Drawing.Size(976, 74);
            this.GbxLocalsBranchesActions.TabIndex = 1;
            this.GbxLocalsBranchesActions.TabStop = false;
            this.GbxLocalsBranchesActions.Text = "Actions";
            // 
            // BtnDeleteWithRemote
            // 
            this.BtnDeleteWithRemote.Enabled = false;
            this.BtnDeleteWithRemote.Location = new System.Drawing.Point(834, 26);
            this.BtnDeleteWithRemote.Name = "BtnDeleteWithRemote";
            this.BtnDeleteWithRemote.Size = new System.Drawing.Size(135, 34);
            this.BtnDeleteWithRemote.TabIndex = 3;
            this.BtnDeleteWithRemote.Text = "Delete with remote";
            this.BtnDeleteWithRemote.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteLocalsBranches
            // 
            this.BtnDeleteLocalsBranches.Location = new System.Drawing.Point(5, 26);
            this.BtnDeleteLocalsBranches.Name = "BtnDeleteLocalsBranches";
            this.BtnDeleteLocalsBranches.Size = new System.Drawing.Size(135, 34);
            this.BtnDeleteLocalsBranches.TabIndex = 2;
            this.BtnDeleteLocalsBranches.Text = "Delete";
            this.BtnDeleteLocalsBranches.UseVisualStyleBackColor = true;
            this.BtnDeleteLocalsBranches.Click += new System.EventHandler(this.BtnDeleteLocalsBranchesClick);
            // 
            // DgvLocalsBranches
            // 
            this.DgvLocalsBranches.AllowUserToAddRows = false;
            this.DgvLocalsBranches.AllowUserToDeleteRows = false;
            this.DgvLocalsBranches.AllowUserToResizeColumns = false;
            this.DgvLocalsBranches.AllowUserToResizeRows = false;
            this.DgvLocalsBranches.AutoGenerateColumns = false;
            this.DgvLocalsBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvLocalsBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLocalsBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.DgvLocalsBranches.DataSource = this.branchDtoBindingSource;
            this.DgvLocalsBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvLocalsBranches.Location = new System.Drawing.Point(3, 3);
            this.DgvLocalsBranches.Name = "DgvLocalsBranches";
            this.DgvLocalsBranches.ReadOnly = true;
            this.DgvLocalsBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLocalsBranches.Size = new System.Drawing.Size(976, 616);
            this.DgvLocalsBranches.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "Branch name";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "LastAuthor";
            this.dataGridViewTextBoxColumn7.HeaderText = "Last author";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 160;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 160;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "LastUpdate";
            this.dataGridViewTextBoxColumn8.HeaderText = "Last update";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 120;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 120;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "IsMerged";
            this.dataGridViewTextBoxColumn9.HeaderText = "Is merged";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 84;
            // 
            // branchDtoBindingSource
            // 
            this.branchDtoBindingSource.DataSource = typeof(TalentsoftTools.BranchDto);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ff";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // GbxActualInfos
            // 
            this.GbxActualInfos.Controls.Add(this.LblActualRepository);
            this.GbxActualInfos.Controls.Add(this.LblActualRepositoryLabel);
            this.GbxActualInfos.Controls.Add(this.LblActualBranchName);
            this.GbxActualInfos.Controls.Add(this.LblActualBranchNameLabel);
            this.GbxActualInfos.Controls.Add(this.label2);
            this.GbxActualInfos.Location = new System.Drawing.Point(7, 5);
            this.GbxActualInfos.Name = "GbxActualInfos";
            this.GbxActualInfos.Size = new System.Drawing.Size(972, 75);
            this.GbxActualInfos.TabIndex = 5;
            this.GbxActualInfos.TabStop = false;
            this.GbxActualInfos.Text = "Current state";
            // 
            // LblActualRepository
            // 
            this.LblActualRepository.AutoSize = true;
            this.LblActualRepository.Location = new System.Drawing.Point(105, 21);
            this.LblActualRepository.Name = "LblActualRepository";
            this.LblActualRepository.Size = new System.Drawing.Size(0, 15);
            this.LblActualRepository.TabIndex = 4;
            // 
            // LblActualRepositoryLabel
            // 
            this.LblActualRepositoryLabel.AutoSize = true;
            this.LblActualRepositoryLabel.Location = new System.Drawing.Point(12, 21);
            this.LblActualRepositoryLabel.Name = "LblActualRepositoryLabel";
            this.LblActualRepositoryLabel.Size = new System.Drawing.Size(69, 15);
            this.LblActualRepositoryLabel.TabIndex = 3;
            this.LblActualRepositoryLabel.Text = "Repository :";
            // 
            // LblActualBranchName
            // 
            this.LblActualBranchName.AutoSize = true;
            this.LblActualBranchName.Location = new System.Drawing.Point(105, 44);
            this.LblActualBranchName.Name = "LblActualBranchName";
            this.LblActualBranchName.Size = new System.Drawing.Size(0, 15);
            this.LblActualBranchName.TabIndex = 2;
            // 
            // LblActualBranchNameLabel
            // 
            this.LblActualBranchNameLabel.AutoSize = true;
            this.LblActualBranchNameLabel.Location = new System.Drawing.Point(12, 44);
            this.LblActualBranchNameLabel.Name = "LblActualBranchNameLabel";
            this.LblActualBranchNameLabel.Size = new System.Drawing.Size(83, 15);
            this.LblActualBranchNameLabel.TabIndex = 1;
            this.LblActualBranchNameLabel.Text = "Branch name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 0;
            // 
            // TalentsoftToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 737);
            this.Controls.Add(this.GbxActualInfos);
            this.Controls.Add(this.TbcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TalentsoftToolsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talentsoft tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TalentsoftToolsFormClosing);
            this.TbcMain.ResumeLayout(false);
            this.TbpProcess.ResumeLayout(false);
            this.BgxLogInfo.ResumeLayout(false);
            this.BgxLogInfo.PerformLayout();
            this.GbxTargetSolution.ResumeLayout(false);
            this.GbxTargetSolution.PerformLayout();
            this.GbxTargetBranch.ResumeLayout(false);
            this.GbxTargetBranch.PerformLayout();
            this.GbxProcess.ResumeLayout(false);
            this.GbxProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TbpLocalsBranches.ResumeLayout(false);
            this.GbxLocalsBranchesActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchDtoBindingSource)).EndInit();
            this.GbxActualInfos.ResumeLayout(false);
            this.GbxActualInfos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcMain;
        private System.Windows.Forms.TabPage TbpLocalsBranches;
        private System.Windows.Forms.DataGridView DgvLocalsBranches;
        private System.Windows.Forms.GroupBox GbxLocalsBranchesActions;
        private System.Windows.Forms.TabPage TbpProcess;
        private System.Windows.Forms.CheckBox CbxIsExitVisualStudio;
        private System.Windows.Forms.CheckBox CbxIsStashChanges;
        private System.Windows.Forms.CheckBox CbxIsCheckoutBranch;
        private System.Windows.Forms.CheckBox CbxIsBuildSolution;
        private System.Windows.Forms.CheckBox CbxIsRunVisualStudio;
        private System.Windows.Forms.GroupBox GbxProcess;
        private System.Windows.Forms.Button BtnRunProcess;
        private System.Windows.Forms.GroupBox GbxTargetBranch;
        private System.Windows.Forms.RadioButton RbtIsLocalTargetBranch;
        private System.Windows.Forms.RadioButton RbtIsRemoteTargetBranch;
        private System.Windows.Forms.Label LblSelectBranch;
        private System.Windows.Forms.GroupBox GbxTargetSolution;
        private System.Windows.Forms.Label LblTargetSolutionFileName;
        private System.Windows.Forms.Label LblTargetSolutionFileNameLabel;
        private System.Windows.Forms.CheckBox CbxIsGitClean;
        private System.Windows.Forms.ComboBox CblSolutions;
        private System.Windows.Forms.GroupBox BgxLogInfo;
        private System.Windows.Forms.TextBox TbxLogInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button BtnDeleteWithRemote;
        private System.Windows.Forms.Button BtnDeleteLocalsBranches;
        private System.Windows.Forms.CheckBox CbxLaunchUri;
        private System.Windows.Forms.Button BtnStopProcess;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox TxbNewBranchName;
        private System.Windows.Forms.CheckBox CbxIsCreateNewBranch;
        private System.Windows.Forms.BindingSource branchDtoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.PictureBox PbxLoading;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.CheckBox CbxIsStashPop;
        private System.Windows.Forms.TextBox TxbUri;
        private System.Windows.Forms.GroupBox GbxActualInfos;
        private System.Windows.Forms.Label LblActualRepository;
        private System.Windows.Forms.Label LblActualRepositoryLabel;
        private System.Windows.Forms.Label LblActualBranchName;
        private System.Windows.Forms.Label LblActualBranchNameLabel;
        private System.Windows.Forms.Label label2;
        private Components.AutoCompleteTextBox ActBranches;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.CheckBox CbxIsPostBuild;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.CheckBox CbxIsPreBuild;
    }
}