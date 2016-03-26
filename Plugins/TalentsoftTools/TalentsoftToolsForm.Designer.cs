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
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.CbxIsNugetRestore = new System.Windows.Forms.CheckBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.TxbDatabases = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.CbxIsRestoreDatabases = new System.Windows.Forms.CheckBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.CbxIsPreBuild = new System.Windows.Forms.CheckBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.CbxIsPostBuild = new System.Windows.Forms.CheckBox();
            this.TxbUri = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.CbxIsStashPop = new System.Windows.Forms.CheckBox();
            this.PbxLoadingProcess = new System.Windows.Forms.PictureBox();
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
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.BtnDeleteWithRemote = new System.Windows.Forms.Button();
            this.BtnDeleteLocalsBranches = new System.Windows.Forms.Button();
            this.DgvLocalsBranches = new System.Windows.Forms.DataGridView();
            this.NotifWhenUpdate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TpbTabPage = new System.Windows.Forms.TabPage();
            this.GbxDashboardActions = new System.Windows.Forms.GroupBox();
            this.BtnDsbRebuildSolution = new System.Windows.Forms.Button();
            this.BtnDsbExitAllVisualStudio = new System.Windows.Forms.Button();
            this.BtnDsbRunScriptPostbuild = new System.Windows.Forms.Button();
            this.BtnDsbRunScriptPrebuild = new System.Windows.Forms.Button();
            this.BtnDsbBuildSolution = new System.Windows.Forms.Button();
            this.BtnDsbNugetRestore = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.TxbDsbGitClean = new System.Windows.Forms.TextBox();
            this.BtnDsbGitClean = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxbDsbDatabases = new System.Windows.Forms.TextBox();
            this.BtnDsbRestoreDatabases = new System.Windows.Forms.Button();
            this.BtnDsbFetchAll = new System.Windows.Forms.Button();
            this.BtnDsbStashPop = new System.Windows.Forms.Button();
            this.BtnDsbStartSolution = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.CblDsbSolutions = new System.Windows.Forms.ComboBox();
            this.BtnDsbExitSolution = new System.Windows.Forms.Button();
            this.BtnDsbStashChanges = new System.Windows.Forms.Button();
            this.PbxDsbLoadingAction = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GbxActualInfos = new System.Windows.Forms.GroupBox();
            this.LblUnmergedBranches = new System.Windows.Forms.Label();
            this.PbxUnmergedBranches = new System.Windows.Forms.PictureBox();
            this.LblNeedToUpdate = new System.Windows.Forms.Label();
            this.PbxBranchesMustUpdate = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLoadingProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TbpLocalsBranches.SuspendLayout();
            this.GbxLocalsBranchesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchDtoBindingSource)).BeginInit();
            this.TpbTabPage.SuspendLayout();
            this.GbxDashboardActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDsbLoadingAction)).BeginInit();
            this.GbxActualInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxUnmergedBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxBranchesMustUpdate)).BeginInit();
            this.SuspendLayout();
            //
            // TbcMain
            //
            this.TbcMain.Controls.Add(this.TbpProcess);
            this.TbcMain.Controls.Add(this.TbpLocalsBranches);
            this.TbcMain.Controls.Add(this.TpbTabPage);
            this.TbcMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TbcMain.Location = new System.Drawing.Point(0, 87);
            this.TbcMain.Name = "TbcMain";
            this.TbcMain.SelectedIndex = 0;
            this.TbcMain.Size = new System.Drawing.Size(895, 650);
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
            this.TbpProcess.Size = new System.Drawing.Size(887, 622);
            this.TbpProcess.TabIndex = 2;
            this.TbpProcess.Text = "Process";
            this.TbpProcess.UseVisualStyleBackColor = true;
            //
            // BgxLogInfo
            //
            this.BgxLogInfo.Controls.Add(this.TbxLogInfo);
            this.BgxLogInfo.Location = new System.Drawing.Point(1, 374);
            this.BgxLogInfo.Name = "BgxLogInfo";
            this.BgxLogInfo.Size = new System.Drawing.Size(877, 250);
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
            this.TbxLogInfo.Size = new System.Drawing.Size(871, 228);
            this.TbxLogInfo.TabIndex = 1;
            //
            // GbxTargetSolution
            //
            this.GbxTargetSolution.Controls.Add(this.CblSolutions);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileNameLabel);
            this.GbxTargetSolution.Controls.Add(this.LblTargetSolutionFileName);
            this.GbxTargetSolution.Location = new System.Drawing.Point(1, 3);
            this.GbxTargetSolution.Name = "GbxTargetSolution";
            this.GbxTargetSolution.Size = new System.Drawing.Size(877, 73);
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
            this.CblSolutions.Size = new System.Drawing.Size(740, 23);
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
            this.GbxTargetBranch.Size = new System.Drawing.Size(875, 108);
            this.GbxTargetBranch.TabIndex = 2;
            this.GbxTargetBranch.TabStop = false;
            this.GbxTargetBranch.Text = "Target branch";
            //
            // ActBranches
            //
            this.ActBranches.Enabled = false;
            this.ActBranches.Location = new System.Drawing.Point(352, 30);
            this.ActBranches.Name = "ActBranches";
            this.ActBranches.Size = new System.Drawing.Size(505, 23);
            this.ActBranches.TabIndex = 6;
            this.ActBranches.Values = null;
            //
            // TxbNewBranchName
            //
            this.TxbNewBranchName.Location = new System.Drawing.Point(352, 67);
            this.TxbNewBranchName.Name = "TxbNewBranchName";
            this.TxbNewBranchName.Size = new System.Drawing.Size(505, 23);
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
            this.GbxProcess.Controls.Add(this.pictureBox6);
            this.GbxProcess.Controls.Add(this.CbxIsNugetRestore);
            this.GbxProcess.Controls.Add(this.pictureBox11);
            this.GbxProcess.Controls.Add(this.TxbDatabases);
            this.GbxProcess.Controls.Add(this.pictureBox8);
            this.GbxProcess.Controls.Add(this.CbxIsRestoreDatabases);
            this.GbxProcess.Controls.Add(this.pictureBox10);
            this.GbxProcess.Controls.Add(this.CbxIsPreBuild);
            this.GbxProcess.Controls.Add(this.pictureBox9);
            this.GbxProcess.Controls.Add(this.CbxIsPostBuild);
            this.GbxProcess.Controls.Add(this.TxbUri);
            this.GbxProcess.Controls.Add(this.pictureBox7);
            this.GbxProcess.Controls.Add(this.CbxIsStashPop);
            this.GbxProcess.Controls.Add(this.PbxLoadingProcess);
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
            this.GbxProcess.Size = new System.Drawing.Size(877, 181);
            this.GbxProcess.TabIndex = 3;
            this.GbxProcess.TabStop = false;
            this.GbxProcess.Text = "Process";
            //
            // pictureBox6
            //
            this.pictureBox6.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox6.Location = new System.Drawing.Point(493, 100);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(33, 30);
            this.pictureBox6.TabIndex = 38;
            this.pictureBox6.TabStop = false;
            //
            // CbxIsNugetRestore
            //
            this.CbxIsNugetRestore.AutoSize = true;
            this.CbxIsNugetRestore.Checked = true;
            this.CbxIsNugetRestore.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsNugetRestore.Location = new System.Drawing.Point(181, 67);
            this.CbxIsNugetRestore.Name = "CbxIsNugetRestore";
            this.CbxIsNugetRestore.Size = new System.Drawing.Size(98, 19);
            this.CbxIsNugetRestore.TabIndex = 37;
            this.CbxIsNugetRestore.Text = "Nuget restore";
            this.CbxIsNugetRestore.UseVisualStyleBackColor = true;
            //
            // pictureBox11
            //
            this.pictureBox11.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox11.Location = new System.Drawing.Point(644, 60);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(33, 30);
            this.pictureBox11.TabIndex = 36;
            this.pictureBox11.TabStop = false;
            //
            // TxbDatabases
            //
            this.TxbDatabases.Location = new System.Drawing.Point(142, 104);
            this.TxbDatabases.Name = "TxbDatabases";
            this.TxbDatabases.Size = new System.Drawing.Size(346, 23);
            this.TxbDatabases.TabIndex = 35;
            //
            // pictureBox8
            //
            this.pictureBox8.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox8.Location = new System.Drawing.Point(287, 60);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(33, 30);
            this.pictureBox8.TabIndex = 34;
            this.pictureBox8.TabStop = false;
            //
            // CbxIsRestoreDatabases
            //
            this.CbxIsRestoreDatabases.AutoSize = true;
            this.CbxIsRestoreDatabases.Checked = true;
            this.CbxIsRestoreDatabases.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsRestoreDatabases.Location = new System.Drawing.Point(13, 106);
            this.CbxIsRestoreDatabases.Name = "CbxIsRestoreDatabases";
            this.CbxIsRestoreDatabases.Size = new System.Drawing.Size(120, 19);
            this.CbxIsRestoreDatabases.TabIndex = 33;
            this.CbxIsRestoreDatabases.Text = "Restore databases";
            this.CbxIsRestoreDatabases.UseVisualStyleBackColor = true;
            this.CbxIsRestoreDatabases.CheckedChanged += new System.EventHandler(this.CbxIsRestoreDatabasesCheckedChanged);
            //
            // pictureBox10
            //
            this.pictureBox10.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox10.Location = new System.Drawing.Point(142, 60);
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
            this.CbxIsPreBuild.Location = new System.Drawing.Point(13, 67);
            this.CbxIsPreBuild.Name = "CbxIsPreBuild";
            this.CbxIsPreBuild.Size = new System.Drawing.Size(94, 19);
            this.CbxIsPreBuild.TabIndex = 31;
            this.CbxIsPreBuild.Text = "Run PreBuild";
            this.CbxIsPreBuild.UseVisualStyleBackColor = true;
            //
            // pictureBox9
            //
            this.pictureBox9.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox9.Location = new System.Drawing.Point(826, 60);
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
            this.CbxIsPostBuild.Location = new System.Drawing.Point(532, 67);
            this.CbxIsPostBuild.Name = "CbxIsPostBuild";
            this.CbxIsPostBuild.Size = new System.Drawing.Size(103, 19);
            this.CbxIsPostBuild.TabIndex = 29;
            this.CbxIsPostBuild.Text = "Run post build";
            this.CbxIsPostBuild.UseVisualStyleBackColor = true;
            //
            // TxbUri
            //
            this.TxbUri.Location = new System.Drawing.Point(644, 104);
            this.TxbUri.Name = "TxbUri";
            this.TxbUri.Size = new System.Drawing.Size(215, 23);
            this.TxbUri.TabIndex = 27;
            //
            // pictureBox7
            //
            this.pictureBox7.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox7.Location = new System.Drawing.Point(644, 19);
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
            this.CbxIsStashPop.Location = new System.Drawing.Point(688, 25);
            this.CbxIsStashPop.Name = "CbxIsStashPop";
            this.CbxIsStashPop.Size = new System.Drawing.Size(78, 19);
            this.CbxIsStashPop.TabIndex = 25;
            this.CbxIsStashPop.Text = "Stash pop";
            this.CbxIsStashPop.UseVisualStyleBackColor = true;
            //
            // PbxLoadingProcess
            //
            this.PbxLoadingProcess.Image = global::TalentsoftTools.Properties.Resources.SwitchingCircleGreenBlueTransparentM;
            this.PbxLoadingProcess.Location = new System.Drawing.Point(704, 146);
            this.PbxLoadingProcess.Name = "PbxLoadingProcess";
            this.PbxLoadingProcess.Size = new System.Drawing.Size(37, 19);
            this.PbxLoadingProcess.TabIndex = 24;
            this.PbxLoadingProcess.TabStop = false;
            this.PbxLoadingProcess.Visible = false;
            //
            // pictureBox5
            //
            this.pictureBox5.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox5.Location = new System.Drawing.Point(493, 60);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(33, 30);
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            //
            // pictureBox4
            //
            this.pictureBox4.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox4.Location = new System.Drawing.Point(826, 19);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(33, 30);
            this.pictureBox4.TabIndex = 21;
            this.pictureBox4.TabStop = false;
            //
            // pictureBox3
            //
            this.pictureBox3.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox3.Location = new System.Drawing.Point(493, 19);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 30);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            //
            // pictureBox2
            //
            this.pictureBox2.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox2.Location = new System.Drawing.Point(287, 19);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 30);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            //
            // pictureBox1
            //
            this.pictureBox1.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox1.Location = new System.Drawing.Point(142, 19);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 30);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            //
            // BtnStopProcess
            //
            this.BtnStopProcess.Location = new System.Drawing.Point(7, 139);
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
            this.CbxLaunchUri.Location = new System.Drawing.Point(532, 106);
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
            this.CbxIsGitClean.Location = new System.Drawing.Point(532, 25);
            this.CbxIsGitClean.Name = "CbxIsGitClean";
            this.CbxIsGitClean.Size = new System.Drawing.Size(72, 19);
            this.CbxIsGitClean.TabIndex = 14;
            this.CbxIsGitClean.Text = "Git clean";
            this.CbxIsGitClean.UseVisualStyleBackColor = true;
            //
            // BtnRunProcess
            //
            this.BtnRunProcess.Location = new System.Drawing.Point(741, 139);
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
            this.CbxIsRunVisualStudio.Location = new System.Drawing.Point(688, 67);
            this.CbxIsRunVisualStudio.Name = "CbxIsRunVisualStudio";
            this.CbxIsRunVisualStudio.Size = new System.Drawing.Size(118, 19);
            this.CbxIsRunVisualStudio.TabIndex = 12;
            this.CbxIsRunVisualStudio.Text = "Run Visual Studio";
            this.CbxIsRunVisualStudio.UseVisualStyleBackColor = true;
            //
            // CbxIsStashChanges
            //
            this.CbxIsStashChanges.AutoSize = true;
            this.CbxIsStashChanges.Checked = true;
            this.CbxIsStashChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsStashChanges.Location = new System.Drawing.Point(181, 25);
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
            this.CbxIsCheckoutBranch.Location = new System.Drawing.Point(326, 25);
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
            this.CbxIsBuildSolution.Location = new System.Drawing.Point(326, 67);
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
            this.TbpLocalsBranches.Size = new System.Drawing.Size(887, 622);
            this.TbpLocalsBranches.TabIndex = 0;
            this.TbpLocalsBranches.Text = "Locals branches";
            this.TbpLocalsBranches.UseVisualStyleBackColor = true;
            //
            // GbxLocalsBranchesActions
            //
            this.GbxLocalsBranchesActions.Controls.Add(this.label4);
            this.GbxLocalsBranchesActions.Controls.Add(this.pictureBox14);
            this.GbxLocalsBranchesActions.Controls.Add(this.label3);
            this.GbxLocalsBranchesActions.Controls.Add(this.label1);
            this.GbxLocalsBranchesActions.Controls.Add(this.pictureBox13);
            this.GbxLocalsBranchesActions.Controls.Add(this.pictureBox12);
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnDeleteWithRemote);
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnDeleteLocalsBranches);
            this.GbxLocalsBranchesActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GbxLocalsBranchesActions.Location = new System.Drawing.Point(3, 545);
            this.GbxLocalsBranchesActions.Name = "GbxLocalsBranchesActions";
            this.GbxLocalsBranchesActions.Size = new System.Drawing.Size(881, 74);
            this.GbxLocalsBranchesActions.TabIndex = 1;
            this.GbxLocalsBranchesActions.TabStop = false;
            this.GbxLocalsBranchesActions.Text = "Actions";
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(320, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Branches must update";
            //
            // pictureBox14
            //
            this.pictureBox14.BackColor = System.Drawing.Color.Red;
            this.pictureBox14.Location = new System.Drawing.Point(297, 34);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(20, 20);
            this.pictureBox14.TabIndex = 8;
            this.pictureBox14.TabStop = false;
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Branches up to date";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Unmerged branches";
            //
            // pictureBox13
            //
            this.pictureBox13.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.pictureBox13.Location = new System.Drawing.Point(13, 34);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(20, 20);
            this.pictureBox13.TabIndex = 5;
            this.pictureBox13.TabStop = false;
            //
            // pictureBox12
            //
            this.pictureBox12.BackColor = System.Drawing.Color.Coral;
            this.pictureBox12.Location = new System.Drawing.Point(154, 34);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(20, 20);
            this.pictureBox12.TabIndex = 4;
            this.pictureBox12.TabStop = false;
            //
            // BtnDeleteWithRemote
            //
            this.BtnDeleteWithRemote.Enabled = false;
            this.BtnDeleteWithRemote.Location = new System.Drawing.Point(741, 26);
            this.BtnDeleteWithRemote.Name = "BtnDeleteWithRemote";
            this.BtnDeleteWithRemote.Size = new System.Drawing.Size(135, 34);
            this.BtnDeleteWithRemote.TabIndex = 3;
            this.BtnDeleteWithRemote.Text = "Delete with remote";
            this.BtnDeleteWithRemote.UseVisualStyleBackColor = true;
            //
            // BtnDeleteLocalsBranches
            //
            this.BtnDeleteLocalsBranches.Location = new System.Drawing.Point(600, 26);
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
            this.DgvLocalsBranches.AllowUserToResizeRows = false;
            this.DgvLocalsBranches.AutoGenerateColumns = false;
            this.DgvLocalsBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvLocalsBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLocalsBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NotifWhenUpdate,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.NeedUpdate});
            this.DgvLocalsBranches.DataSource = this.branchDtoBindingSource;
            this.DgvLocalsBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvLocalsBranches.Location = new System.Drawing.Point(3, 3);
            this.DgvLocalsBranches.Name = "DgvLocalsBranches";
            this.DgvLocalsBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLocalsBranches.Size = new System.Drawing.Size(881, 616);
            this.DgvLocalsBranches.TabIndex = 0;
            this.DgvLocalsBranches.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLocalsBranches_CellContentClick);
            //
            // NotifWhenUpdate
            //
            this.NotifWhenUpdate.HeaderText = "Notif when Update";
            this.NotifWhenUpdate.Name = "NotifWhenUpdate";
            this.NotifWhenUpdate.Width = 102;
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
            this.dataGridViewTextBoxColumn9.Width = 78;
            //
            // NeedUpdate
            //
            this.NeedUpdate.DataPropertyName = "NeedUpdate";
            this.NeedUpdate.HeaderText = "Must update";
            this.NeedUpdate.Name = "NeedUpdate";
            this.NeedUpdate.ReadOnly = true;
            this.NeedUpdate.Width = 91;
            //
            // branchDtoBindingSource
            //
            this.branchDtoBindingSource.DataSource = typeof(TalentsoftTools.BranchDto);
            //
            // TpbTabPage
            //
            this.TpbTabPage.Controls.Add(this.GbxDashboardActions);
            this.TpbTabPage.Location = new System.Drawing.Point(4, 24);
            this.TpbTabPage.Name = "TpbTabPage";
            this.TpbTabPage.Size = new System.Drawing.Size(887, 622);
            this.TpbTabPage.TabIndex = 3;
            this.TpbTabPage.Text = "Dashboard";
            this.TpbTabPage.UseVisualStyleBackColor = true;
            //
            // GbxDashboardActions
            //
            this.GbxDashboardActions.Controls.Add(this.BtnDsbRebuildSolution);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbExitAllVisualStudio);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbRunScriptPostbuild);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbRunScriptPrebuild);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbBuildSolution);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbNugetRestore);
            this.GbxDashboardActions.Controls.Add(this.label7);
            this.GbxDashboardActions.Controls.Add(this.TxbDsbGitClean);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbGitClean);
            this.GbxDashboardActions.Controls.Add(this.label6);
            this.GbxDashboardActions.Controls.Add(this.TxbDsbDatabases);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbRestoreDatabases);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbFetchAll);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbStashPop);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbStartSolution);
            this.GbxDashboardActions.Controls.Add(this.label5);
            this.GbxDashboardActions.Controls.Add(this.CblDsbSolutions);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbExitSolution);
            this.GbxDashboardActions.Controls.Add(this.BtnDsbStashChanges);
            this.GbxDashboardActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxDashboardActions.Location = new System.Drawing.Point(0, 0);
            this.GbxDashboardActions.Name = "GbxDashboardActions";
            this.GbxDashboardActions.Size = new System.Drawing.Size(887, 622);
            this.GbxDashboardActions.TabIndex = 0;
            this.GbxDashboardActions.TabStop = false;
            this.GbxDashboardActions.Text = "Actions";
            //
            // BtnDsbRebuildSolution
            //
            this.BtnDsbRebuildSolution.Location = new System.Drawing.Point(576, 51);
            this.BtnDsbRebuildSolution.Name = "BtnDsbRebuildSolution";
            this.BtnDsbRebuildSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRebuildSolution.TabIndex = 18;
            this.BtnDsbRebuildSolution.Text = "Rebuild solution";
            this.BtnDsbRebuildSolution.UseVisualStyleBackColor = true;
            this.BtnDsbRebuildSolution.Click += new System.EventHandler(this.BtnDsbRebuildSolutionClick);
            //
            // BtnDsbExitAllVisualStudio
            //
            this.BtnDsbExitAllVisualStudio.Location = new System.Drawing.Point(114, 154);
            this.BtnDsbExitAllVisualStudio.Name = "BtnDsbExitAllVisualStudio";
            this.BtnDsbExitAllVisualStudio.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbExitAllVisualStudio.TabIndex = 17;
            this.BtnDsbExitAllVisualStudio.Text = "Exit All Visual Studio";
            this.BtnDsbExitAllVisualStudio.UseVisualStyleBackColor = true;
            this.BtnDsbExitAllVisualStudio.Click += new System.EventHandler(this.BtnDsbExitAllVisualStudioClick);
            //
            // BtnDsbRunScriptPostbuild
            //
            this.BtnDsbRunScriptPostbuild.Location = new System.Drawing.Point(730, 156);
            this.BtnDsbRunScriptPostbuild.Name = "BtnDsbRunScriptPostbuild";
            this.BtnDsbRunScriptPostbuild.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRunScriptPostbuild.TabIndex = 16;
            this.BtnDsbRunScriptPostbuild.Text = "Run script Post-Build";
            this.BtnDsbRunScriptPostbuild.UseVisualStyleBackColor = true;
            this.BtnDsbRunScriptPostbuild.Click += new System.EventHandler(this.BtnDsbRunScriptPostbuildClick);
            //
            // BtnDsbRunScriptPrebuild
            //
            this.BtnDsbRunScriptPrebuild.Location = new System.Drawing.Point(576, 154);
            this.BtnDsbRunScriptPrebuild.Name = "BtnDsbRunScriptPrebuild";
            this.BtnDsbRunScriptPrebuild.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRunScriptPrebuild.TabIndex = 15;
            this.BtnDsbRunScriptPrebuild.Text = "Run script Pre-Build";
            this.BtnDsbRunScriptPrebuild.UseVisualStyleBackColor = true;
            this.BtnDsbRunScriptPrebuild.Click += new System.EventHandler(this.BtnDsbRunScriptPrebuildClick);
            //
            // BtnDsbBuildSolution
            //
            this.BtnDsbBuildSolution.Location = new System.Drawing.Point(422, 51);
            this.BtnDsbBuildSolution.Name = "BtnDsbBuildSolution";
            this.BtnDsbBuildSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbBuildSolution.TabIndex = 14;
            this.BtnDsbBuildSolution.Text = "Build solution";
            this.BtnDsbBuildSolution.UseVisualStyleBackColor = true;
            this.BtnDsbBuildSolution.Click += new System.EventHandler(this.BtnDsbBuildSolutionClick);
            //
            // BtnDsbNugetRestore
            //
            this.BtnDsbNugetRestore.Location = new System.Drawing.Point(268, 51);
            this.BtnDsbNugetRestore.Name = "BtnDsbNugetRestore";
            this.BtnDsbNugetRestore.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbNugetRestore.TabIndex = 13;
            this.BtnDsbNugetRestore.Text = "Nuget restore";
            this.BtnDsbNugetRestore.UseVisualStyleBackColor = true;
            this.BtnDsbNugetRestore.Click += new System.EventHandler(this.BtnDsbNugetRestoreClick);
            //
            // label7
            //
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Exclude pattern";
            //
            // TxbDsbGitClean
            //
            this.TxbDsbGitClean.Location = new System.Drawing.Point(114, 125);
            this.TxbDsbGitClean.Name = "TxbDsbGitClean";
            this.TxbDsbGitClean.Size = new System.Drawing.Size(610, 23);
            this.TxbDsbGitClean.TabIndex = 11;
            //
            // BtnDsbGitClean
            //
            this.BtnDsbGitClean.Location = new System.Drawing.Point(730, 121);
            this.BtnDsbGitClean.Name = "BtnDsbGitClean";
            this.BtnDsbGitClean.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbGitClean.TabIndex = 10;
            this.BtnDsbGitClean.Text = "Git clean";
            this.BtnDsbGitClean.UseVisualStyleBackColor = true;
            this.BtnDsbGitClean.Click += new System.EventHandler(this.BtnDsbGitCleanClick);
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "Databases";
            //
            // TxbDsbDatabases
            //
            this.TxbDsbDatabases.Location = new System.Drawing.Point(114, 90);
            this.TxbDsbDatabases.Name = "TxbDsbDatabases";
            this.TxbDsbDatabases.Size = new System.Drawing.Size(610, 23);
            this.TxbDsbDatabases.TabIndex = 8;
            //
            // BtnDsbRestoreDatabases
            //
            this.BtnDsbRestoreDatabases.Location = new System.Drawing.Point(730, 86);
            this.BtnDsbRestoreDatabases.Name = "BtnDsbRestoreDatabases";
            this.BtnDsbRestoreDatabases.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRestoreDatabases.TabIndex = 7;
            this.BtnDsbRestoreDatabases.Text = "Restore databases";
            this.BtnDsbRestoreDatabases.UseVisualStyleBackColor = true;
            this.BtnDsbRestoreDatabases.Click += new System.EventHandler(this.BtnDsbRestoreDatabasesClick);
            //
            // BtnDsbFetchAll
            //
            this.BtnDsbFetchAll.Location = new System.Drawing.Point(730, 191);
            this.BtnDsbFetchAll.Name = "BtnDsbFetchAll";
            this.BtnDsbFetchAll.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbFetchAll.TabIndex = 6;
            this.BtnDsbFetchAll.Text = "Fetch all";
            this.BtnDsbFetchAll.UseVisualStyleBackColor = true;
            this.BtnDsbFetchAll.Click += new System.EventHandler(this.BtnDsbFetchAllClick);
            //
            // BtnDsbStashPop
            //
            this.BtnDsbStashPop.Location = new System.Drawing.Point(422, 154);
            this.BtnDsbStashPop.Name = "BtnDsbStashPop";
            this.BtnDsbStashPop.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbStashPop.TabIndex = 5;
            this.BtnDsbStashPop.Text = "Stash pop";
            this.BtnDsbStashPop.UseVisualStyleBackColor = true;
            this.BtnDsbStashPop.Click += new System.EventHandler(this.BtnDsbStashPopClick);
            //
            // BtnDsbStartSolution
            //
            this.BtnDsbStartSolution.Location = new System.Drawing.Point(730, 51);
            this.BtnDsbStartSolution.Name = "BtnDsbStartSolution";
            this.BtnDsbStartSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbStartSolution.TabIndex = 4;
            this.BtnDsbStartSolution.Text = "Start Visual Studio";
            this.BtnDsbStartSolution.UseVisualStyleBackColor = true;
            this.BtnDsbStartSolution.Click += new System.EventHandler(this.BtnDsbStartSolutionClick);
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Solutions";
            //
            // CblDsbSolutions
            //
            this.CblDsbSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CblDsbSolutions.FormattingEnabled = true;
            this.CblDsbSolutions.Location = new System.Drawing.Point(114, 22);
            this.CblDsbSolutions.Name = "CblDsbSolutions";
            this.CblDsbSolutions.Size = new System.Drawing.Size(764, 23);
            this.CblDsbSolutions.TabIndex = 2;
            //
            // BtnDsbExitSolution
            //
            this.BtnDsbExitSolution.Location = new System.Drawing.Point(114, 51);
            this.BtnDsbExitSolution.Name = "BtnDsbExitSolution";
            this.BtnDsbExitSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbExitSolution.TabIndex = 1;
            this.BtnDsbExitSolution.Text = "Exit Visual Studio";
            this.BtnDsbExitSolution.UseVisualStyleBackColor = true;
            this.BtnDsbExitSolution.Click += new System.EventHandler(this.BtnDsbExitSolutionClick);
            //
            // BtnDsbStashChanges
            //
            this.BtnDsbStashChanges.Location = new System.Drawing.Point(268, 154);
            this.BtnDsbStashChanges.Name = "BtnDsbStashChanges";
            this.BtnDsbStashChanges.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbStashChanges.TabIndex = 0;
            this.BtnDsbStashChanges.Text = "Stash changes";
            this.BtnDsbStashChanges.UseVisualStyleBackColor = true;
            this.BtnDsbStashChanges.Click += new System.EventHandler(this.BtnDsbStashChangesClick);
            //
            // PbxDsbLoadingAction
            //
            this.PbxDsbLoadingAction.Image = ((System.Drawing.Image)(resources.GetObject("PbxDsbLoadingAction.Image")));
            this.PbxDsbLoadingAction.Location = new System.Drawing.Point(417, 29);
            this.PbxDsbLoadingAction.Name = "PbxDsbLoadingAction";
            this.PbxDsbLoadingAction.Size = new System.Drawing.Size(78, 38);
            this.PbxDsbLoadingAction.TabIndex = 25;
            this.PbxDsbLoadingAction.TabStop = false;
            this.PbxDsbLoadingAction.Visible = false;
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
            this.GbxActualInfos.Controls.Add(this.PbxDsbLoadingAction);
            this.GbxActualInfos.Controls.Add(this.LblUnmergedBranches);
            this.GbxActualInfos.Controls.Add(this.PbxUnmergedBranches);
            this.GbxActualInfos.Controls.Add(this.LblNeedToUpdate);
            this.GbxActualInfos.Controls.Add(this.PbxBranchesMustUpdate);
            this.GbxActualInfos.Controls.Add(this.LblActualRepository);
            this.GbxActualInfos.Controls.Add(this.LblActualRepositoryLabel);
            this.GbxActualInfos.Controls.Add(this.LblActualBranchName);
            this.GbxActualInfos.Controls.Add(this.LblActualBranchNameLabel);
            this.GbxActualInfos.Controls.Add(this.label2);
            this.GbxActualInfos.Location = new System.Drawing.Point(7, 5);
            this.GbxActualInfos.Name = "GbxActualInfos";
            this.GbxActualInfos.Size = new System.Drawing.Size(875, 75);
            this.GbxActualInfos.TabIndex = 5;
            this.GbxActualInfos.TabStop = false;
            this.GbxActualInfos.Text = "Current state";
            //
            // LblUnmergedBranches
            //
            this.LblUnmergedBranches.AutoSize = true;
            this.LblUnmergedBranches.Location = new System.Drawing.Point(678, 44);
            this.LblUnmergedBranches.Name = "LblUnmergedBranches";
            this.LblUnmergedBranches.Size = new System.Drawing.Size(0, 15);
            this.LblUnmergedBranches.TabIndex = 13;
            //
            // PbxUnmergedBranches
            //
            this.PbxUnmergedBranches.BackColor = System.Drawing.Color.Coral;
            this.PbxUnmergedBranches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxUnmergedBranches.Location = new System.Drawing.Point(655, 41);
            this.PbxUnmergedBranches.Name = "PbxUnmergedBranches";
            this.PbxUnmergedBranches.Size = new System.Drawing.Size(20, 20);
            this.PbxUnmergedBranches.TabIndex = 12;
            this.PbxUnmergedBranches.TabStop = false;
            this.PbxUnmergedBranches.Click += new System.EventHandler(this.PbxUnmergedBranchesClick);
            //
            // LblNeedToUpdate
            //
            this.LblNeedToUpdate.AutoSize = true;
            this.LblNeedToUpdate.Location = new System.Drawing.Point(678, 21);
            this.LblNeedToUpdate.Name = "LblNeedToUpdate";
            this.LblNeedToUpdate.Size = new System.Drawing.Size(0, 15);
            this.LblNeedToUpdate.TabIndex = 11;
            //
            // PbxBranchesMustUpdate
            //
            this.PbxBranchesMustUpdate.BackColor = System.Drawing.Color.Red;
            this.PbxBranchesMustUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxBranchesMustUpdate.Location = new System.Drawing.Point(655, 18);
            this.PbxBranchesMustUpdate.Name = "PbxBranchesMustUpdate";
            this.PbxBranchesMustUpdate.Size = new System.Drawing.Size(20, 20);
            this.PbxBranchesMustUpdate.TabIndex = 10;
            this.PbxBranchesMustUpdate.TabStop = false;
            this.PbxBranchesMustUpdate.Tag = "";
            this.PbxBranchesMustUpdate.Click += new System.EventHandler(this.PbxBranchesMustUpdateClick);
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
            this.ClientSize = new System.Drawing.Size(895, 737);
            this.Controls.Add(this.GbxActualInfos);
            this.Controls.Add(this.TbcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TalentsoftToolsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = Generic.PluginName;
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLoadingProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TbpLocalsBranches.ResumeLayout(false);
            this.GbxLocalsBranchesActions.ResumeLayout(false);
            this.GbxLocalsBranchesActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchDtoBindingSource)).EndInit();
            this.TpbTabPage.ResumeLayout(false);
            this.GbxDashboardActions.ResumeLayout(false);
            this.GbxDashboardActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDsbLoadingAction)).EndInit();
            this.GbxActualInfos.ResumeLayout(false);
            this.GbxActualInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxUnmergedBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxBranchesMustUpdate)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox TxbNewBranchName;
        private System.Windows.Forms.CheckBox CbxIsCreateNewBranch;
        private System.Windows.Forms.BindingSource branchDtoBindingSource;
        private System.Windows.Forms.PictureBox PbxLoadingProcess;
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
        private System.Windows.Forms.CheckBox CbxIsRestoreDatabases;
        private System.Windows.Forms.TextBox TxbDatabases;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.CheckBox CbxIsNugetRestore;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.Label LblNeedToUpdate;
        private System.Windows.Forms.PictureBox PbxBranchesMustUpdate;
        private System.Windows.Forms.Label LblUnmergedBranches;
        private System.Windows.Forms.PictureBox PbxUnmergedBranches;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage TpbTabPage;
        private System.Windows.Forms.GroupBox GbxDashboardActions;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CblDsbSolutions;
        private System.Windows.Forms.Button BtnDsbExitSolution;
        private System.Windows.Forms.Button BtnDsbStashChanges;
        private System.Windows.Forms.Button BtnDsbStartSolution;
        private System.Windows.Forms.Button BtnDsbStashPop;
        private System.Windows.Forms.Button BtnDsbFetchAll;
        private System.Windows.Forms.Button BtnDsbRestoreDatabases;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxbDsbDatabases;
        private System.Windows.Forms.Button BtnDsbGitClean;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxbDsbGitClean;
        private System.Windows.Forms.Button BtnDsbNugetRestore;
        private System.Windows.Forms.Button BtnDsbBuildSolution;
        private System.Windows.Forms.Button BtnDsbRunScriptPrebuild;
        private System.Windows.Forms.Button BtnDsbRunScriptPostbuild;
        private System.Windows.Forms.Button BtnDsbExitAllVisualStudio;
        private System.Windows.Forms.Button BtnDsbRebuildSolution;
        private System.Windows.Forms.PictureBox PbxDsbLoadingAction;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NotifWhenUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedUpdate;
    }
}