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
            this.GbxActualInfos = new System.Windows.Forms.GroupBox();
            this.LblActualRepository = new System.Windows.Forms.Label();
            this.LblActualRepositoryLabel = new System.Windows.Forms.Label();
            this.LblActualBranchName = new System.Windows.Forms.Label();
            this.LblActualBranchNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BgxLogInfo = new System.Windows.Forms.GroupBox();
            this.TbxLogInfo = new System.Windows.Forms.TextBox();
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
            this.CbxLaunchUri = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CbxIsGitClean = new System.Windows.Forms.CheckBox();
            this.BtnRunProcess = new System.Windows.Forms.Button();
            this.CbxIsExitVisualStudio = new System.Windows.Forms.CheckBox();
            this.CbxIsRunVisualStudio = new System.Windows.Forms.CheckBox();
            this.LblNext1 = new System.Windows.Forms.Label();
            this.CbxIsStashChanges = new System.Windows.Forms.CheckBox();
            this.LblNext2 = new System.Windows.Forms.Label();
            this.LblNext6 = new System.Windows.Forms.Label();
            this.CbxIsCheckoutBranch = new System.Windows.Forms.CheckBox();
            this.CbxIsBuildSolution = new System.Windows.Forms.CheckBox();
            this.LblNext3 = new System.Windows.Forms.Label();
            this.LblNext4 = new System.Windows.Forms.Label();
            this.TbpLocalsBranches = new System.Windows.Forms.TabPage();
            this.GbxLocalsBranchesActions = new System.Windows.Forms.GroupBox();
            this.BtnDeleteWithRemote = new System.Windows.Forms.Button();
            this.BtnDeleteLocalsBranches = new System.Windows.Forms.Button();
            this.DgvLocalsBranches = new System.Windows.Forms.DataGridView();
            this.TbpTools = new System.Windows.Forms.TabPage();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbcMain.SuspendLayout();
            this.TbpProcess.SuspendLayout();
            this.GbxActualInfos.SuspendLayout();
            this.BgxLogInfo.SuspendLayout();
            this.GbxTargetSolution.SuspendLayout();
            this.GbxTargetBranch.SuspendLayout();
            this.GbxProcess.SuspendLayout();
            this.TbpLocalsBranches.SuspendLayout();
            this.GbxLocalsBranchesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).BeginInit();
            this.SuspendLayout();
            // 
            // TbcMain
            // 
            this.TbcMain.Controls.Add(this.TbpProcess);
            this.TbcMain.Controls.Add(this.TbpLocalsBranches);
            this.TbcMain.Controls.Add(this.TbpTools);
            this.TbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbcMain.Location = new System.Drawing.Point(0, 0);
            this.TbcMain.Name = "TbcMain";
            this.TbcMain.SelectedIndex = 0;
            this.TbcMain.Size = new System.Drawing.Size(990, 685);
            this.TbcMain.TabIndex = 0;
            // 
            // TbpProcess
            // 
            this.TbpProcess.Controls.Add(this.GbxActualInfos);
            this.TbpProcess.Controls.Add(this.BgxLogInfo);
            this.TbpProcess.Controls.Add(this.GbxTargetSolution);
            this.TbpProcess.Controls.Add(this.GbxTargetBranch);
            this.TbpProcess.Controls.Add(this.GbxProcess);
            this.TbpProcess.Location = new System.Drawing.Point(4, 24);
            this.TbpProcess.Name = "TbpProcess";
            this.TbpProcess.Size = new System.Drawing.Size(982, 657);
            this.TbpProcess.TabIndex = 2;
            this.TbpProcess.Text = "Process";
            this.TbpProcess.UseVisualStyleBackColor = true;
            // 
            // GbxActualInfos
            // 
            this.GbxActualInfos.Controls.Add(this.LblActualRepository);
            this.GbxActualInfos.Controls.Add(this.LblActualRepositoryLabel);
            this.GbxActualInfos.Controls.Add(this.LblActualBranchName);
            this.GbxActualInfos.Controls.Add(this.LblActualBranchNameLabel);
            this.GbxActualInfos.Controls.Add(this.label2);
            this.GbxActualInfos.Location = new System.Drawing.Point(4, 3);
            this.GbxActualInfos.Name = "GbxActualInfos";
            this.GbxActualInfos.Size = new System.Drawing.Size(972, 106);
            this.GbxActualInfos.TabIndex = 4;
            this.GbxActualInfos.TabStop = false;
            this.GbxActualInfos.Text = "Current state";
            // 
            // LblActualRepository
            // 
            this.LblActualRepository.AutoSize = true;
            this.LblActualRepository.Location = new System.Drawing.Point(94, 31);
            this.LblActualRepository.Name = "LblActualRepository";
            this.LblActualRepository.Size = new System.Drawing.Size(0, 15);
            this.LblActualRepository.TabIndex = 4;
            // 
            // LblActualRepositoryLabel
            // 
            this.LblActualRepositoryLabel.AutoSize = true;
            this.LblActualRepositoryLabel.Location = new System.Drawing.Point(12, 31);
            this.LblActualRepositoryLabel.Name = "LblActualRepositoryLabel";
            this.LblActualRepositoryLabel.Size = new System.Drawing.Size(69, 15);
            this.LblActualRepositoryLabel.TabIndex = 3;
            this.LblActualRepositoryLabel.Text = "Repository :";
            // 
            // LblActualBranchName
            // 
            this.LblActualBranchName.AutoSize = true;
            this.LblActualBranchName.Location = new System.Drawing.Point(114, 67);
            this.LblActualBranchName.Name = "LblActualBranchName";
            this.LblActualBranchName.Size = new System.Drawing.Size(0, 15);
            this.LblActualBranchName.TabIndex = 2;
            // 
            // LblActualBranchNameLabel
            // 
            this.LblActualBranchNameLabel.AutoSize = true;
            this.LblActualBranchNameLabel.Location = new System.Drawing.Point(12, 67);
            this.LblActualBranchNameLabel.Name = "LblActualBranchNameLabel";
            this.LblActualBranchNameLabel.Size = new System.Drawing.Size(89, 15);
            this.LblActualBranchNameLabel.TabIndex = 1;
            this.LblActualBranchNameLabel.Text = "Branche name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 15);
            this.label2.TabIndex = 0;
            // 
            // BgxLogInfo
            // 
            this.BgxLogInfo.Controls.Add(this.TbxLogInfo);
            this.BgxLogInfo.Location = new System.Drawing.Point(1, 369);
            this.BgxLogInfo.Name = "BgxLogInfo";
            this.BgxLogInfo.Size = new System.Drawing.Size(975, 285);
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
            this.TbxLogInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TbxLogInfo.Size = new System.Drawing.Size(969, 263);
            this.TbxLogInfo.TabIndex = 1;
            // 
            // GbxTargetSolution
            // 
            this.GbxTargetSolution.Controls.Add(this.CbxSolutions);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileNameLabel);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileName);
            this.GbxTargetSolution.Location = new System.Drawing.Point(1, 115);
            this.GbxTargetSolution.Name = "GbxTargetSolution";
            this.GbxTargetSolution.Size = new System.Drawing.Size(975, 81);
            this.GbxTargetSolution.TabIndex = 0;
            this.GbxTargetSolution.TabStop = false;
            this.GbxTargetSolution.Text = "Target solution";
            // 
            // CbxSolutions
            // 
            this.CbxSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxSolutions.FormattingEnabled = true;
            this.CbxSolutions.Location = new System.Drawing.Point(111, 36);
            this.CbxSolutions.Name = "CbxSolutions";
            this.CbxSolutions.Size = new System.Drawing.Size(850, 23);
            this.CbxSolutions.TabIndex = 3;
            this.CbxSolutions.SelectedIndexChanged += new System.EventHandler(this.CbxSolutionsSelectedIndexChanged);
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
            this.GbxTargetBranch.Location = new System.Drawing.Point(3, 197);
            this.GbxTargetBranch.Name = "GbxTargetBranch";
            this.GbxTargetBranch.Size = new System.Drawing.Size(973, 71);
            this.GbxTargetBranch.TabIndex = 2;
            this.GbxTargetBranch.TabStop = false;
            this.GbxTargetBranch.Text = "Target branch";
            // 
            // CbxBranches
            // 
            this.CbxBranches.FormattingEnabled = true;
            this.CbxBranches.Location = new System.Drawing.Point(395, 30);
            this.CbxBranches.Name = "CbxBranches";
            this.CbxBranches.Size = new System.Drawing.Size(566, 23);
            this.CbxBranches.TabIndex = 3;
            this.CbxBranches.SelectedIndexChanged += new System.EventHandler(this.CbxBranchesSelectedIndexChanged);
            this.CbxBranches.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CbxBranchesKeyPress);
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
            this.GbxProcess.Controls.Add(this.CbxLaunchUri);
            this.GbxProcess.Controls.Add(this.label1);
            this.GbxProcess.Controls.Add(this.CbxIsGitClean);
            this.GbxProcess.Controls.Add(this.BtnRunProcess);
            this.GbxProcess.Controls.Add(this.CbxIsExitVisualStudio);
            this.GbxProcess.Controls.Add(this.CbxIsRunVisualStudio);
            this.GbxProcess.Controls.Add(this.LblNext1);
            this.GbxProcess.Controls.Add(this.CbxIsStashChanges);
            this.GbxProcess.Controls.Add(this.LblNext2);
            this.GbxProcess.Controls.Add(this.LblNext6);
            this.GbxProcess.Controls.Add(this.CbxIsCheckoutBranch);
            this.GbxProcess.Controls.Add(this.CbxIsBuildSolution);
            this.GbxProcess.Controls.Add(this.LblNext3);
            this.GbxProcess.Controls.Add(this.LblNext4);
            this.GbxProcess.Location = new System.Drawing.Point(1, 269);
            this.GbxProcess.Name = "GbxProcess";
            this.GbxProcess.Size = new System.Drawing.Size(975, 97);
            this.GbxProcess.TabIndex = 3;
            this.GbxProcess.TabStop = false;
            this.GbxProcess.Text = "Process";
            // 
            // CbxLaunchUri
            // 
            this.CbxLaunchUri.AutoSize = true;
            this.CbxLaunchUri.Checked = true;
            this.CbxLaunchUri.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxLaunchUri.Location = new System.Drawing.Point(863, 25);
            this.CbxLaunchUri.Name = "CbxLaunchUri";
            this.CbxLaunchUri.Size = new System.Drawing.Size(86, 19);
            this.CbxLaunchUri.TabIndex = 16;
            this.CbxLaunchUri.Text = "Launch URI";
            this.CbxLaunchUri.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(836, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "==>";
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
            this.BtnRunProcess.Location = new System.Drawing.Point(845, 56);
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
            this.CbxIsRunVisualStudio.Location = new System.Drawing.Point(722, 25);
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
            this.LblNext6.Location = new System.Drawing.Point(685, 26);
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
            this.CbxIsBuildSolution.Location = new System.Drawing.Point(589, 25);
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
            // TbpLocalsBranches
            // 
            this.TbpLocalsBranches.Controls.Add(this.GbxLocalsBranchesActions);
            this.TbpLocalsBranches.Controls.Add(this.DgvLocalsBranches);
            this.TbpLocalsBranches.Location = new System.Drawing.Point(4, 24);
            this.TbpLocalsBranches.Name = "TbpLocalsBranches";
            this.TbpLocalsBranches.Padding = new System.Windows.Forms.Padding(3);
            this.TbpLocalsBranches.Size = new System.Drawing.Size(982, 657);
            this.TbpLocalsBranches.TabIndex = 0;
            this.TbpLocalsBranches.Text = "Locals branches";
            this.TbpLocalsBranches.UseVisualStyleBackColor = true;
            // 
            // GbxLocalsBranchesActions
            // 
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnDeleteWithRemote);
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnDeleteLocalsBranches);
            this.GbxLocalsBranchesActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GbxLocalsBranchesActions.Location = new System.Drawing.Point(3, 580);
            this.GbxLocalsBranchesActions.Name = "GbxLocalsBranchesActions";
            this.GbxLocalsBranchesActions.Size = new System.Drawing.Size(976, 74);
            this.GbxLocalsBranchesActions.TabIndex = 1;
            this.GbxLocalsBranchesActions.TabStop = false;
            this.GbxLocalsBranchesActions.Text = "Actions";
            // 
            // BtnDeleteWithRemote
            // 
            this.BtnDeleteWithRemote.Enabled = false;
            this.BtnDeleteWithRemote.Location = new System.Drawing.Point(835, 22);
            this.BtnDeleteWithRemote.Name = "BtnDeleteWithRemote";
            this.BtnDeleteWithRemote.Size = new System.Drawing.Size(135, 34);
            this.BtnDeleteWithRemote.TabIndex = 3;
            this.BtnDeleteWithRemote.Text = "Delete with remote";
            this.BtnDeleteWithRemote.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteLocalsBranches
            // 
            this.BtnDeleteLocalsBranches.Location = new System.Drawing.Point(6, 22);
            this.BtnDeleteLocalsBranches.Name = "BtnDeleteLocalsBranches";
            this.BtnDeleteLocalsBranches.Size = new System.Drawing.Size(135, 34);
            this.BtnDeleteLocalsBranches.TabIndex = 2;
            this.BtnDeleteLocalsBranches.Text = "Delete";
            this.BtnDeleteLocalsBranches.UseVisualStyleBackColor = true;
            this.BtnDeleteLocalsBranches.Click += new System.EventHandler(this.BtnDeleteLocalsBranchesClick);
            // 
            // DgvLocalsBranches
            // 
            this.DgvLocalsBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvLocalsBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLocalsBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvLocalsBranches.Location = new System.Drawing.Point(3, 3);
            this.DgvLocalsBranches.Name = "DgvLocalsBranches";
            this.DgvLocalsBranches.ReadOnly = true;
            this.DgvLocalsBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLocalsBranches.Size = new System.Drawing.Size(976, 651);
            this.DgvLocalsBranches.TabIndex = 0;
            // 
            // TbpTools
            // 
            this.TbpTools.Location = new System.Drawing.Point(4, 24);
            this.TbpTools.Name = "TbpTools";
            this.TbpTools.Padding = new System.Windows.Forms.Padding(3);
            this.TbpTools.Size = new System.Drawing.Size(982, 657);
            this.TbpTools.TabIndex = 1;
            this.TbpTools.Text = "Tools";
            this.TbpTools.UseVisualStyleBackColor = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ff";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // TalentsoftTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 685);
            this.Controls.Add(this.TbcMain);
            this.MaximizeBox = false;
            this.Name = "TalentsoftTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Talentsoft tools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TalentsoftToolsFormClosed);
            this.TbcMain.ResumeLayout(false);
            this.TbpProcess.ResumeLayout(false);
            this.GbxActualInfos.ResumeLayout(false);
            this.GbxActualInfos.PerformLayout();
            this.BgxLogInfo.ResumeLayout(false);
            this.BgxLogInfo.PerformLayout();
            this.GbxTargetSolution.ResumeLayout(false);
            this.GbxTargetSolution.PerformLayout();
            this.GbxTargetBranch.ResumeLayout(false);
            this.GbxTargetBranch.PerformLayout();
            this.GbxProcess.ResumeLayout(false);
            this.GbxProcess.PerformLayout();
            this.TbpLocalsBranches.ResumeLayout(false);
            this.GbxLocalsBranchesActions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TbcMain;
        private System.Windows.Forms.TabPage TbpLocalsBranches;
        private System.Windows.Forms.DataGridView DgvLocalsBranches;
        private System.Windows.Forms.TabPage TbpTools;
        private System.Windows.Forms.GroupBox GbxLocalsBranchesActions;
        private System.Windows.Forms.TabPage TbpProcess;
        private System.Windows.Forms.CheckBox CbxIsExitVisualStudio;
        private System.Windows.Forms.CheckBox CbxIsStashChanges;
        private System.Windows.Forms.Label LblNext3;
        private System.Windows.Forms.Label LblNext2;
        private System.Windows.Forms.Label LblNext1;
        private System.Windows.Forms.CheckBox CbxIsCheckoutBranch;
        private System.Windows.Forms.CheckBox CbxIsBuildSolution;
        private System.Windows.Forms.Label LblNext4;
        private System.Windows.Forms.Label LblNext6;
        private System.Windows.Forms.CheckBox CbxIsRunVisualStudio;
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
        private System.Windows.Forms.ComboBox CbxSolutions;
        private System.Windows.Forms.GroupBox BgxLogInfo;
        private System.Windows.Forms.TextBox TbxLogInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button BtnDeleteWithRemote;
        private System.Windows.Forms.Button BtnDeleteLocalsBranches;
        private System.Windows.Forms.GroupBox GbxActualInfos;
        private System.Windows.Forms.Label LblActualBranchNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblActualRepository;
        private System.Windows.Forms.Label LblActualRepositoryLabel;
        private System.Windows.Forms.Label LblActualBranchName;
        private System.Windows.Forms.CheckBox CbxLaunchUri;
        private System.Windows.Forms.Label label1;
    }
}