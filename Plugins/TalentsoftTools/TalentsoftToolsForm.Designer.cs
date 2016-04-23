using TalentsoftTools.Dto;

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
            this.TxbProcessDatabasesToRestore = new System.Windows.Forms.TextBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.CbxIsRestoreDatabases = new System.Windows.Forms.CheckBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.CbxIsPreBuild = new System.Windows.Forms.CheckBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.CbxIsPostBuild = new System.Windows.Forms.CheckBox();
            this.TxbUri = new System.Windows.Forms.TextBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.CbxIsStashPop = new System.Windows.Forms.CheckBox();
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
            this.label1 = new System.Windows.Forms.Label();
            this.PbxLocalsBranchesObsoletes = new System.Windows.Forms.PictureBox();
            this.BtnLocalsBranchesSelectObsoletes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PbxLocalsBranchesMustBeUpdate = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PbxLocalsBranchesUpToDate = new System.Windows.Forms.PictureBox();
            this.BtnDeleteLocalsBranches = new System.Windows.Forms.Button();
            this.DgvLocalsBranches = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsObsolete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TpbNotifications = new System.Windows.Forms.TabPage();
            this.DgvNtfNotifications = new System.Windows.Forms.DataGridView();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TpbDashboard = new System.Windows.Forms.TabPage();
            this.BtnDsbCancelAction = new System.Windows.Forms.Button();
            this.GbxDsbVisualStudioSolution = new System.Windows.Forms.GroupBox();
            this.CblDsbSolutions = new System.Windows.Forms.ComboBox();
            this.BtnDsbExitSolution = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnDsbRebuildSolution = new System.Windows.Forms.Button();
            this.BtnDsbStartSolution = new System.Windows.Forms.Button();
            this.BtnDsbNugetRestore = new System.Windows.Forms.Button();
            this.BtnDsbBuildSolution = new System.Windows.Forms.Button();
            this.GbxDsbDatabases = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnDsbRestoreDatabases = new System.Windows.Forms.Button();
            this.TxbDsbDatabasesToRestore = new System.Windows.Forms.TextBox();
            this.GbxDsbGeneric = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BtnDsbStashChanges = new System.Windows.Forms.Button();
            this.BtnDsbGitClean = new System.Windows.Forms.Button();
            this.BtnDsbFetchAll = new System.Windows.Forms.Button();
            this.TxbDsbGitClean = new System.Windows.Forms.TextBox();
            this.BtnDsbStashPop = new System.Windows.Forms.Button();
            this.BtnDsbRunScriptPostbuild = new System.Windows.Forms.Button();
            this.BtnDsbExitAllVisualStudio = new System.Windows.Forms.Button();
            this.BtnDsbRunScriptPrebuild = new System.Windows.Forms.Button();
            this.TpbSettings = new System.Windows.Forms.TabPage();
            this.BtnSettingsSave = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.TxbSettingsDefaultSolutionFileName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxbSettingsNewBranchPrefix = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.TxbSettingsExcludeGitCleanPattern = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.TxbSettingsUris = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CbxSettingsProcessNugetRestore = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessRestoreDatabases = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessPostBuild = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessRunPreBuild = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessRunUris = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessGitClean = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessCheckout = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessStashPop = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessStashChanges = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessRunVisualStudio = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessExitVisualStudio = new System.Windows.Forms.CheckBox();
            this.CbxSettingsProcessBuild = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxbSettingsBatchPostBuildScripts = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxbSettingsBatchPreBuildScripts = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxbSettingsDatabasesRestore = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxbSettingsDatabaseRelocateFile = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxbSettingsDatabaseServerName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CbxSettingsNotificationsEnable = new System.Windows.Forms.CheckBox();
            this.TxbSettingsNotificationsMonitorBranches = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.TxbSettingsNotificationsCheckIntrerval = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PbxDsbLoadingAction = new System.Windows.Forms.PictureBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GbxActualInfos = new System.Windows.Forms.GroupBox();
            this.LblBranchesObsoletes = new System.Windows.Forms.Label();
            this.PbxBranchesObsoletesBranches = new System.Windows.Forms.PictureBox();
            this.LblNeedToUpdate = new System.Windows.Forms.Label();
            this.PbxBranchesMustUpdate = new System.Windows.Forms.PictureBox();
            this.LblActualRepository = new System.Windows.Forms.Label();
            this.LblActualRepositoryLabel = new System.Windows.Forms.Label();
            this.LblActualBranchName = new System.Windows.Forms.Label();
            this.LblActualBranchNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnDsbShowBranch = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.TxbDsbBranchPrefix = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.TbpLocalsBranches.SuspendLayout();
            this.GbxLocalsBranchesActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLocalsBranchesObsoletes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLocalsBranchesMustBeUpdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLocalsBranchesUpToDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchDtoBindingSource)).BeginInit();
            this.TpbNotifications.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvNtfNotifications)).BeginInit();
            this.TpbDashboard.SuspendLayout();
            this.GbxDsbVisualStudioSolution.SuspendLayout();
            this.GbxDsbDatabases.SuspendLayout();
            this.GbxDsbGeneric.SuspendLayout();
            this.TpbSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDsbLoadingAction)).BeginInit();
            this.GbxActualInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxBranchesObsoletesBranches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxBranchesMustUpdate)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // TbcMain
            // 
            this.TbcMain.Controls.Add(this.TbpProcess);
            this.TbcMain.Controls.Add(this.TbpLocalsBranches);
            this.TbcMain.Controls.Add(this.TpbNotifications);
            this.TbcMain.Controls.Add(this.TpbDashboard);
            this.TbcMain.Controls.Add(this.TpbSettings);
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
            this.CblSolutions.TabIndex = 0;
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
            this.ActBranches.TabIndex = 3;
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
            this.RbtIsRemoteTargetBranch.TabIndex = 2;
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
            this.RbtIsLocalTargetBranch.TabIndex = 1;
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
            this.GbxProcess.Controls.Add(this.TxbProcessDatabasesToRestore);
            this.GbxProcess.Controls.Add(this.pictureBox8);
            this.GbxProcess.Controls.Add(this.CbxIsRestoreDatabases);
            this.GbxProcess.Controls.Add(this.pictureBox10);
            this.GbxProcess.Controls.Add(this.CbxIsPreBuild);
            this.GbxProcess.Controls.Add(this.pictureBox9);
            this.GbxProcess.Controls.Add(this.CbxIsPostBuild);
            this.GbxProcess.Controls.Add(this.TxbUri);
            this.GbxProcess.Controls.Add(this.pictureBox7);
            this.GbxProcess.Controls.Add(this.CbxIsStashPop);
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
            this.pictureBox6.Location = new System.Drawing.Point(503, 100);
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
            this.CbxIsNugetRestore.Location = new System.Drawing.Point(694, 67);
            this.CbxIsNugetRestore.Name = "CbxIsNugetRestore";
            this.CbxIsNugetRestore.Size = new System.Drawing.Size(98, 19);
            this.CbxIsNugetRestore.TabIndex = 12;
            this.CbxIsNugetRestore.Text = "Nuget restore";
            this.CbxIsNugetRestore.UseVisualStyleBackColor = true;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox11.Location = new System.Drawing.Point(142, 100);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(33, 30);
            this.pictureBox11.TabIndex = 36;
            this.pictureBox11.TabStop = false;
            // 
            // TxbProcessDatabasesToRestore
            // 
            this.TxbProcessDatabasesToRestore.Location = new System.Drawing.Point(142, 65);
            this.TxbProcessDatabasesToRestore.Name = "TxbProcessDatabasesToRestore";
            this.TxbProcessDatabasesToRestore.Size = new System.Drawing.Size(355, 23);
            this.TxbProcessDatabasesToRestore.TabIndex = 17;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox8.Location = new System.Drawing.Point(298, 100);
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
            this.CbxIsRestoreDatabases.Location = new System.Drawing.Point(13, 67);
            this.CbxIsRestoreDatabases.Name = "CbxIsRestoreDatabases";
            this.CbxIsRestoreDatabases.Size = new System.Drawing.Size(120, 19);
            this.CbxIsRestoreDatabases.TabIndex = 16;
            this.CbxIsRestoreDatabases.Tag = "";
            this.CbxIsRestoreDatabases.Text = "Restore databases";
            this.CbxIsRestoreDatabases.UseVisualStyleBackColor = true;
            this.CbxIsRestoreDatabases.CheckedChanged += new System.EventHandler(this.CbxIsRestoreDatabasesCheckedChanged);
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox10.Location = new System.Drawing.Point(645, 60);
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
            this.CbxIsPreBuild.Location = new System.Drawing.Point(542, 67);
            this.CbxIsPreBuild.Name = "CbxIsPreBuild";
            this.CbxIsPreBuild.Size = new System.Drawing.Size(94, 19);
            this.CbxIsPreBuild.TabIndex = 11;
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
            this.CbxIsPostBuild.Location = new System.Drawing.Point(181, 106);
            this.CbxIsPostBuild.Name = "CbxIsPostBuild";
            this.CbxIsPostBuild.Size = new System.Drawing.Size(103, 19);
            this.CbxIsPostBuild.TabIndex = 14;
            this.CbxIsPostBuild.Text = "Run post build";
            this.CbxIsPostBuild.UseVisualStyleBackColor = true;
            // 
            // TxbUri
            // 
            this.TxbUri.Location = new System.Drawing.Point(645, 104);
            this.TxbUri.Name = "TxbUri";
            this.TxbUri.Size = new System.Drawing.Size(214, 23);
            this.TxbUri.TabIndex = 19;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox7.Location = new System.Drawing.Point(645, 19);
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
            this.CbxIsStashPop.Location = new System.Drawing.Point(694, 25);
            this.CbxIsStashPop.Name = "CbxIsStashPop";
            this.CbxIsStashPop.Size = new System.Drawing.Size(78, 19);
            this.CbxIsStashPop.TabIndex = 10;
            this.CbxIsStashPop.Text = "Stash pop";
            this.CbxIsStashPop.UseVisualStyleBackColor = true;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox5.Location = new System.Drawing.Point(503, 60);
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
            this.pictureBox3.Location = new System.Drawing.Point(503, 19);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(33, 30);
            this.pictureBox3.TabIndex = 20;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::TalentsoftTools.Properties.Resources.Arrow_Direction_Move_Next_Forward_Right;
            this.pictureBox2.Location = new System.Drawing.Point(298, 19);
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
            this.BtnStopProcess.TabIndex = 21;
            this.BtnStopProcess.Text = "Stop process";
            this.BtnStopProcess.UseVisualStyleBackColor = true;
            this.BtnStopProcess.Click += new System.EventHandler(this.BtnStopProcessClick);
            // 
            // CbxLaunchUri
            // 
            this.CbxLaunchUri.AutoSize = true;
            this.CbxLaunchUri.Checked = true;
            this.CbxLaunchUri.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxLaunchUri.Location = new System.Drawing.Point(542, 106);
            this.CbxLaunchUri.Name = "CbxLaunchUri";
            this.CbxLaunchUri.Size = new System.Drawing.Size(86, 19);
            this.CbxLaunchUri.TabIndex = 18;
            this.CbxLaunchUri.Text = "Launch URI";
            this.CbxLaunchUri.UseVisualStyleBackColor = true;
            // 
            // CbxIsGitClean
            // 
            this.CbxIsGitClean.AutoSize = true;
            this.CbxIsGitClean.Checked = true;
            this.CbxIsGitClean.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsGitClean.Location = new System.Drawing.Point(542, 25);
            this.CbxIsGitClean.Name = "CbxIsGitClean";
            this.CbxIsGitClean.Size = new System.Drawing.Size(72, 19);
            this.CbxIsGitClean.TabIndex = 9;
            this.CbxIsGitClean.Text = "Git clean";
            this.CbxIsGitClean.UseVisualStyleBackColor = true;
            // 
            // BtnRunProcess
            // 
            this.BtnRunProcess.Location = new System.Drawing.Point(741, 139);
            this.BtnRunProcess.Name = "BtnRunProcess";
            this.BtnRunProcess.Size = new System.Drawing.Size(118, 32);
            this.BtnRunProcess.TabIndex = 20;
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
            this.CbxIsExitVisualStudio.TabIndex = 6;
            this.CbxIsExitVisualStudio.Text = "Exit Visual Studio";
            this.CbxIsExitVisualStudio.UseVisualStyleBackColor = true;
            // 
            // CbxIsRunVisualStudio
            // 
            this.CbxIsRunVisualStudio.AutoSize = true;
            this.CbxIsRunVisualStudio.Checked = true;
            this.CbxIsRunVisualStudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsRunVisualStudio.Location = new System.Drawing.Point(345, 106);
            this.CbxIsRunVisualStudio.Name = "CbxIsRunVisualStudio";
            this.CbxIsRunVisualStudio.Size = new System.Drawing.Size(118, 19);
            this.CbxIsRunVisualStudio.TabIndex = 15;
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
            this.CbxIsStashChanges.TabIndex = 7;
            this.CbxIsStashChanges.Text = "Stash changes";
            this.CbxIsStashChanges.UseVisualStyleBackColor = true;
            this.CbxIsStashChanges.CheckedChanged += new System.EventHandler(this.CbxIsStashChanges_CheckedChanged);
            // 
            // CbxIsCheckoutBranch
            // 
            this.CbxIsCheckoutBranch.AutoSize = true;
            this.CbxIsCheckoutBranch.Checked = true;
            this.CbxIsCheckoutBranch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsCheckoutBranch.Location = new System.Drawing.Point(337, 25);
            this.CbxIsCheckoutBranch.Name = "CbxIsCheckoutBranch";
            this.CbxIsCheckoutBranch.Size = new System.Drawing.Size(162, 19);
            this.CbxIsCheckoutBranch.TabIndex = 8;
            this.CbxIsCheckoutBranch.Text = "Checkout / Create branch";
            this.CbxIsCheckoutBranch.UseVisualStyleBackColor = true;
            // 
            // CbxIsBuildSolution
            // 
            this.CbxIsBuildSolution.AutoSize = true;
            this.CbxIsBuildSolution.Checked = true;
            this.CbxIsBuildSolution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxIsBuildSolution.Location = new System.Drawing.Point(13, 106);
            this.CbxIsBuildSolution.Name = "CbxIsBuildSolution";
            this.CbxIsBuildSolution.Size = new System.Drawing.Size(99, 19);
            this.CbxIsBuildSolution.TabIndex = 13;
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
            this.GbxLocalsBranchesActions.Controls.Add(this.label1);
            this.GbxLocalsBranchesActions.Controls.Add(this.PbxLocalsBranchesObsoletes);
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnLocalsBranchesSelectObsoletes);
            this.GbxLocalsBranchesActions.Controls.Add(this.label4);
            this.GbxLocalsBranchesActions.Controls.Add(this.PbxLocalsBranchesMustBeUpdate);
            this.GbxLocalsBranchesActions.Controls.Add(this.label3);
            this.GbxLocalsBranchesActions.Controls.Add(this.PbxLocalsBranchesUpToDate);
            this.GbxLocalsBranchesActions.Controls.Add(this.BtnDeleteLocalsBranches);
            this.GbxLocalsBranchesActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GbxLocalsBranchesActions.Location = new System.Drawing.Point(3, 545);
            this.GbxLocalsBranchesActions.Name = "GbxLocalsBranchesActions";
            this.GbxLocalsBranchesActions.Size = new System.Drawing.Size(881, 74);
            this.GbxLocalsBranchesActions.TabIndex = 1;
            this.GbxLocalsBranchesActions.TabStop = false;
            this.GbxLocalsBranchesActions.Text = "Actions";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Obsoletes branches";
            // 
            // PbxLocalsBranchesObsoletes
            // 
            this.PbxLocalsBranchesObsoletes.BackColor = System.Drawing.Color.Gray;
            this.PbxLocalsBranchesObsoletes.Location = new System.Drawing.Point(311, 34);
            this.PbxLocalsBranchesObsoletes.Name = "PbxLocalsBranchesObsoletes";
            this.PbxLocalsBranchesObsoletes.Size = new System.Drawing.Size(20, 20);
            this.PbxLocalsBranchesObsoletes.TabIndex = 11;
            this.PbxLocalsBranchesObsoletes.TabStop = false;
            // 
            // BtnLocalsBranchesSelectObsoletes
            // 
            this.BtnLocalsBranchesSelectObsoletes.Location = new System.Drawing.Point(517, 29);
            this.BtnLocalsBranchesSelectObsoletes.Name = "BtnLocalsBranchesSelectObsoletes";
            this.BtnLocalsBranchesSelectObsoletes.Size = new System.Drawing.Size(176, 29);
            this.BtnLocalsBranchesSelectObsoletes.TabIndex = 0;
            this.BtnLocalsBranchesSelectObsoletes.Text = "Select obsoletes branches";
            this.BtnLocalsBranchesSelectObsoletes.UseVisualStyleBackColor = true;
            this.BtnLocalsBranchesSelectObsoletes.Click += new System.EventHandler(this.BtnLocalsBranchesSelectObsoletesClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(180, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Branches must update";
            // 
            // PbxLocalsBranchesMustBeUpdate
            // 
            this.PbxLocalsBranchesMustBeUpdate.BackColor = System.Drawing.Color.Tomato;
            this.PbxLocalsBranchesMustBeUpdate.Location = new System.Drawing.Point(154, 34);
            this.PbxLocalsBranchesMustBeUpdate.Name = "PbxLocalsBranchesMustBeUpdate";
            this.PbxLocalsBranchesMustBeUpdate.Size = new System.Drawing.Size(20, 20);
            this.PbxLocalsBranchesMustBeUpdate.TabIndex = 8;
            this.PbxLocalsBranchesMustBeUpdate.TabStop = false;
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
            // PbxLocalsBranchesUpToDate
            // 
            this.PbxLocalsBranchesUpToDate.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.PbxLocalsBranchesUpToDate.Location = new System.Drawing.Point(13, 34);
            this.PbxLocalsBranchesUpToDate.Name = "PbxLocalsBranchesUpToDate";
            this.PbxLocalsBranchesUpToDate.Size = new System.Drawing.Size(20, 20);
            this.PbxLocalsBranchesUpToDate.TabIndex = 5;
            this.PbxLocalsBranchesUpToDate.TabStop = false;
            // 
            // BtnDeleteLocalsBranches
            // 
            this.BtnDeleteLocalsBranches.Location = new System.Drawing.Point(699, 29);
            this.BtnDeleteLocalsBranches.Name = "BtnDeleteLocalsBranches";
            this.BtnDeleteLocalsBranches.Size = new System.Drawing.Size(176, 29);
            this.BtnDeleteLocalsBranches.TabIndex = 1;
            this.BtnDeleteLocalsBranches.Text = "Delete selected branches";
            this.BtnDeleteLocalsBranches.UseVisualStyleBackColor = true;
            this.BtnDeleteLocalsBranches.Click += new System.EventHandler(this.BtnDeleteLocalsBranchesClick);
            // 
            // DgvLocalsBranches
            // 
            this.DgvLocalsBranches.AllowUserToAddRows = false;
            this.DgvLocalsBranches.AllowUserToDeleteRows = false;
            this.DgvLocalsBranches.AllowUserToOrderColumns = true;
            this.DgvLocalsBranches.AutoGenerateColumns = false;
            this.DgvLocalsBranches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvLocalsBranches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvLocalsBranches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.NeedUpdate,
            this.IsObsolete});
            this.DgvLocalsBranches.DataSource = this.branchDtoBindingSource;
            this.DgvLocalsBranches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvLocalsBranches.Location = new System.Drawing.Point(3, 3);
            this.DgvLocalsBranches.Name = "DgvLocalsBranches";
            this.DgvLocalsBranches.ReadOnly = true;
            this.DgvLocalsBranches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLocalsBranches.Size = new System.Drawing.Size(881, 616);
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
            // NeedUpdate
            // 
            this.NeedUpdate.DataPropertyName = "NeedUpdate";
            this.NeedUpdate.HeaderText = "Must update";
            this.NeedUpdate.Name = "NeedUpdate";
            this.NeedUpdate.ReadOnly = true;
            this.NeedUpdate.Width = 99;
            // 
            // IsObsolete
            // 
            this.IsObsolete.DataPropertyName = "IsObsolete";
            this.IsObsolete.HeaderText = "Is obsolete";
            this.IsObsolete.Name = "IsObsolete";
            this.IsObsolete.ReadOnly = true;
            this.IsObsolete.Width = 88;
            // 
            // branchDtoBindingSource
            // 
            this.branchDtoBindingSource.DataSource = typeof(BranchDto);
            // 
            // TpbNotifications
            // 
            this.TpbNotifications.Controls.Add(this.DgvNtfNotifications);
            this.TpbNotifications.Location = new System.Drawing.Point(4, 24);
            this.TpbNotifications.Name = "TpbNotifications";
            this.TpbNotifications.Size = new System.Drawing.Size(887, 622);
            this.TpbNotifications.TabIndex = 5;
            this.TpbNotifications.Text = "Notifications";
            this.TpbNotifications.UseVisualStyleBackColor = true;
            // 
            // DgvNtfNotifications
            // 
            this.DgvNtfNotifications.AllowUserToAddRows = false;
            this.DgvNtfNotifications.AllowUserToDeleteRows = false;
            this.DgvNtfNotifications.AllowUserToOrderColumns = true;
            this.DgvNtfNotifications.AllowUserToResizeRows = false;
            this.DgvNtfNotifications.AutoGenerateColumns = false;
            this.DgvNtfNotifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DgvNtfNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvNtfNotifications.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.DgvNtfNotifications.DataSource = this.branchDtoBindingSource;
            this.DgvNtfNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvNtfNotifications.Location = new System.Drawing.Point(0, 0);
            this.DgvNtfNotifications.Name = "DgvNtfNotifications";
            this.DgvNtfNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvNtfNotifications.Size = new System.Drawing.Size(887, 622);
            this.DgvNtfNotifications.TabIndex = 1;
            this.DgvNtfNotifications.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNtfNotificationsCellContentClick);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Notif when update";
            this.dataGridViewCheckBoxColumn1.MinimumWidth = 140;
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Branch name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // TpbDashboard
            // 
            this.TpbDashboard.Controls.Add(this.groupBox6);
            this.TpbDashboard.Controls.Add(this.BtnDsbCancelAction);
            this.TpbDashboard.Controls.Add(this.GbxDsbVisualStudioSolution);
            this.TpbDashboard.Controls.Add(this.GbxDsbDatabases);
            this.TpbDashboard.Controls.Add(this.GbxDsbGeneric);
            this.TpbDashboard.Location = new System.Drawing.Point(4, 24);
            this.TpbDashboard.Name = "TpbDashboard";
            this.TpbDashboard.Size = new System.Drawing.Size(887, 622);
            this.TpbDashboard.TabIndex = 3;
            this.TpbDashboard.Text = "Dashboard";
            this.TpbDashboard.UseVisualStyleBackColor = true;
            // 
            // BtnDsbCancelAction
            // 
            this.BtnDsbCancelAction.Enabled = false;
            this.BtnDsbCancelAction.Location = new System.Drawing.Point(725, 384);
            this.BtnDsbCancelAction.Name = "BtnDsbCancelAction";
            this.BtnDsbCancelAction.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbCancelAction.TabIndex = 16;
            this.BtnDsbCancelAction.Text = "Cancel action";
            this.BtnDsbCancelAction.UseVisualStyleBackColor = true;
            this.BtnDsbCancelAction.Click += new System.EventHandler(this.BtnDsbCancelActionClick);
            // 
            // GbxDsbVisualStudioSolution
            // 
            this.GbxDsbVisualStudioSolution.Controls.Add(this.CblDsbSolutions);
            this.GbxDsbVisualStudioSolution.Controls.Add(this.BtnDsbExitSolution);
            this.GbxDsbVisualStudioSolution.Controls.Add(this.label5);
            this.GbxDsbVisualStudioSolution.Controls.Add(this.BtnDsbRebuildSolution);
            this.GbxDsbVisualStudioSolution.Controls.Add(this.BtnDsbStartSolution);
            this.GbxDsbVisualStudioSolution.Controls.Add(this.BtnDsbNugetRestore);
            this.GbxDsbVisualStudioSolution.Controls.Add(this.BtnDsbBuildSolution);
            this.GbxDsbVisualStudioSolution.Location = new System.Drawing.Point(4, 3);
            this.GbxDsbVisualStudioSolution.Name = "GbxDsbVisualStudioSolution";
            this.GbxDsbVisualStudioSolution.Size = new System.Drawing.Size(875, 100);
            this.GbxDsbVisualStudioSolution.TabIndex = 24;
            this.GbxDsbVisualStudioSolution.TabStop = false;
            this.GbxDsbVisualStudioSolution.Text = "Visual Studio Solution";
            // 
            // CblDsbSolutions
            // 
            this.CblDsbSolutions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CblDsbSolutions.FormattingEnabled = true;
            this.CblDsbSolutions.Location = new System.Drawing.Point(105, 22);
            this.CblDsbSolutions.Name = "CblDsbSolutions";
            this.CblDsbSolutions.Size = new System.Drawing.Size(764, 23);
            this.CblDsbSolutions.TabIndex = 0;
            // 
            // BtnDsbExitSolution
            // 
            this.BtnDsbExitSolution.Location = new System.Drawing.Point(105, 51);
            this.BtnDsbExitSolution.Name = "BtnDsbExitSolution";
            this.BtnDsbExitSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbExitSolution.TabIndex = 1;
            this.BtnDsbExitSolution.Text = "Exit Visual Studio";
            this.BtnDsbExitSolution.UseVisualStyleBackColor = true;
            this.BtnDsbExitSolution.Click += new System.EventHandler(this.BtnDsbExitSolutionClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Solutions";
            // 
            // BtnDsbRebuildSolution
            // 
            this.BtnDsbRebuildSolution.Location = new System.Drawing.Point(567, 51);
            this.BtnDsbRebuildSolution.Name = "BtnDsbRebuildSolution";
            this.BtnDsbRebuildSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRebuildSolution.TabIndex = 4;
            this.BtnDsbRebuildSolution.Text = "Rebuild solution";
            this.BtnDsbRebuildSolution.UseVisualStyleBackColor = true;
            this.BtnDsbRebuildSolution.Click += new System.EventHandler(this.BtnDsbRebuildSolutionClick);
            // 
            // BtnDsbStartSolution
            // 
            this.BtnDsbStartSolution.Location = new System.Drawing.Point(721, 51);
            this.BtnDsbStartSolution.Name = "BtnDsbStartSolution";
            this.BtnDsbStartSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbStartSolution.TabIndex = 5;
            this.BtnDsbStartSolution.Text = "Start Visual Studio";
            this.BtnDsbStartSolution.UseVisualStyleBackColor = true;
            this.BtnDsbStartSolution.Click += new System.EventHandler(this.BtnDsbStartSolutionClick);
            // 
            // BtnDsbNugetRestore
            // 
            this.BtnDsbNugetRestore.Location = new System.Drawing.Point(259, 51);
            this.BtnDsbNugetRestore.Name = "BtnDsbNugetRestore";
            this.BtnDsbNugetRestore.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbNugetRestore.TabIndex = 2;
            this.BtnDsbNugetRestore.Text = "Nuget restore";
            this.BtnDsbNugetRestore.UseVisualStyleBackColor = true;
            this.BtnDsbNugetRestore.Click += new System.EventHandler(this.BtnDsbNugetRestoreClick);
            // 
            // BtnDsbBuildSolution
            // 
            this.BtnDsbBuildSolution.Location = new System.Drawing.Point(413, 51);
            this.BtnDsbBuildSolution.Name = "BtnDsbBuildSolution";
            this.BtnDsbBuildSolution.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbBuildSolution.TabIndex = 3;
            this.BtnDsbBuildSolution.Text = "Build solution";
            this.BtnDsbBuildSolution.UseVisualStyleBackColor = true;
            this.BtnDsbBuildSolution.Click += new System.EventHandler(this.BtnDsbBuildSolutionClick);
            // 
            // GbxDsbDatabases
            // 
            this.GbxDsbDatabases.Controls.Add(this.label6);
            this.GbxDsbDatabases.Controls.Add(this.BtnDsbRestoreDatabases);
            this.GbxDsbDatabases.Controls.Add(this.TxbDsbDatabasesToRestore);
            this.GbxDsbDatabases.Location = new System.Drawing.Point(4, 109);
            this.GbxDsbDatabases.Name = "GbxDsbDatabases";
            this.GbxDsbDatabases.Size = new System.Drawing.Size(875, 64);
            this.GbxDsbDatabases.TabIndex = 23;
            this.GbxDsbDatabases.TabStop = false;
            this.GbxDsbDatabases.Text = "Databases";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "DB to restore";
            // 
            // BtnDsbRestoreDatabases
            // 
            this.BtnDsbRestoreDatabases.Location = new System.Drawing.Point(721, 22);
            this.BtnDsbRestoreDatabases.Name = "BtnDsbRestoreDatabases";
            this.BtnDsbRestoreDatabases.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRestoreDatabases.TabIndex = 7;
            this.BtnDsbRestoreDatabases.Text = "Restore databases";
            this.BtnDsbRestoreDatabases.UseVisualStyleBackColor = true;
            this.BtnDsbRestoreDatabases.Click += new System.EventHandler(this.BtnDsbRestoreDatabasesClick);
            // 
            // TxbDsbDatabasesToRestore
            // 
            this.TxbDsbDatabasesToRestore.Location = new System.Drawing.Point(105, 26);
            this.TxbDsbDatabasesToRestore.Name = "TxbDsbDatabasesToRestore";
            this.TxbDsbDatabasesToRestore.Size = new System.Drawing.Size(610, 23);
            this.TxbDsbDatabasesToRestore.TabIndex = 6;
            // 
            // GbxDsbGeneric
            // 
            this.GbxDsbGeneric.Controls.Add(this.label7);
            this.GbxDsbGeneric.Controls.Add(this.BtnDsbStashChanges);
            this.GbxDsbGeneric.Controls.Add(this.BtnDsbGitClean);
            this.GbxDsbGeneric.Controls.Add(this.BtnDsbFetchAll);
            this.GbxDsbGeneric.Controls.Add(this.TxbDsbGitClean);
            this.GbxDsbGeneric.Controls.Add(this.BtnDsbStashPop);
            this.GbxDsbGeneric.Controls.Add(this.BtnDsbRunScriptPostbuild);
            this.GbxDsbGeneric.Controls.Add(this.BtnDsbExitAllVisualStudio);
            this.GbxDsbGeneric.Controls.Add(this.BtnDsbRunScriptPrebuild);
            this.GbxDsbGeneric.Location = new System.Drawing.Point(4, 179);
            this.GbxDsbGeneric.Name = "GbxDsbGeneric";
            this.GbxDsbGeneric.Size = new System.Drawing.Size(875, 133);
            this.GbxDsbGeneric.TabIndex = 22;
            this.GbxDsbGeneric.TabStop = false;
            this.GbxDsbGeneric.Text = "Generic";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Exclude pattern";
            // 
            // BtnDsbStashChanges
            // 
            this.BtnDsbStashChanges.Location = new System.Drawing.Point(259, 58);
            this.BtnDsbStashChanges.Name = "BtnDsbStashChanges";
            this.BtnDsbStashChanges.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbStashChanges.TabIndex = 11;
            this.BtnDsbStashChanges.Text = "Stash changes";
            this.BtnDsbStashChanges.UseVisualStyleBackColor = true;
            this.BtnDsbStashChanges.Click += new System.EventHandler(this.BtnDsbStashChangesClick);
            // 
            // BtnDsbGitClean
            // 
            this.BtnDsbGitClean.Location = new System.Drawing.Point(721, 23);
            this.BtnDsbGitClean.Name = "BtnDsbGitClean";
            this.BtnDsbGitClean.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbGitClean.TabIndex = 9;
            this.BtnDsbGitClean.Text = "Git clean";
            this.BtnDsbGitClean.UseVisualStyleBackColor = true;
            this.BtnDsbGitClean.Click += new System.EventHandler(this.BtnDsbGitCleanClick);
            // 
            // BtnDsbFetchAll
            // 
            this.BtnDsbFetchAll.Location = new System.Drawing.Point(721, 93);
            this.BtnDsbFetchAll.Name = "BtnDsbFetchAll";
            this.BtnDsbFetchAll.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbFetchAll.TabIndex = 15;
            this.BtnDsbFetchAll.Text = "Fetch all";
            this.BtnDsbFetchAll.UseVisualStyleBackColor = true;
            this.BtnDsbFetchAll.Click += new System.EventHandler(this.BtnDsbFetchAllClick);
            // 
            // TxbDsbGitClean
            // 
            this.TxbDsbGitClean.Location = new System.Drawing.Point(105, 27);
            this.TxbDsbGitClean.Name = "TxbDsbGitClean";
            this.TxbDsbGitClean.Size = new System.Drawing.Size(610, 23);
            this.TxbDsbGitClean.TabIndex = 8;
            // 
            // BtnDsbStashPop
            // 
            this.BtnDsbStashPop.Location = new System.Drawing.Point(413, 58);
            this.BtnDsbStashPop.Name = "BtnDsbStashPop";
            this.BtnDsbStashPop.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbStashPop.TabIndex = 12;
            this.BtnDsbStashPop.Text = "Stash pop";
            this.BtnDsbStashPop.UseVisualStyleBackColor = true;
            this.BtnDsbStashPop.Click += new System.EventHandler(this.BtnDsbStashPopClick);
            // 
            // BtnDsbRunScriptPostbuild
            // 
            this.BtnDsbRunScriptPostbuild.Location = new System.Drawing.Point(721, 58);
            this.BtnDsbRunScriptPostbuild.Name = "BtnDsbRunScriptPostbuild";
            this.BtnDsbRunScriptPostbuild.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRunScriptPostbuild.TabIndex = 14;
            this.BtnDsbRunScriptPostbuild.Text = "Run script Post-Build";
            this.BtnDsbRunScriptPostbuild.UseVisualStyleBackColor = true;
            this.BtnDsbRunScriptPostbuild.Click += new System.EventHandler(this.BtnDsbRunScriptPostbuildClick);
            // 
            // BtnDsbExitAllVisualStudio
            // 
            this.BtnDsbExitAllVisualStudio.Location = new System.Drawing.Point(105, 58);
            this.BtnDsbExitAllVisualStudio.Name = "BtnDsbExitAllVisualStudio";
            this.BtnDsbExitAllVisualStudio.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbExitAllVisualStudio.TabIndex = 10;
            this.BtnDsbExitAllVisualStudio.Text = "Exit All Visual Studio";
            this.BtnDsbExitAllVisualStudio.UseVisualStyleBackColor = true;
            this.BtnDsbExitAllVisualStudio.Click += new System.EventHandler(this.BtnDsbExitAllVisualStudioClick);
            // 
            // BtnDsbRunScriptPrebuild
            // 
            this.BtnDsbRunScriptPrebuild.Location = new System.Drawing.Point(567, 58);
            this.BtnDsbRunScriptPrebuild.Name = "BtnDsbRunScriptPrebuild";
            this.BtnDsbRunScriptPrebuild.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbRunScriptPrebuild.TabIndex = 13;
            this.BtnDsbRunScriptPrebuild.Text = "Run script Pre-Build";
            this.BtnDsbRunScriptPrebuild.UseVisualStyleBackColor = true;
            this.BtnDsbRunScriptPrebuild.Click += new System.EventHandler(this.BtnDsbRunScriptPrebuildClick);
            // 
            // TpbSettings
            // 
            this.TpbSettings.Controls.Add(this.BtnSettingsSave);
            this.TpbSettings.Controls.Add(this.groupBox5);
            this.TpbSettings.Controls.Add(this.groupBox4);
            this.TpbSettings.Controls.Add(this.groupBox3);
            this.TpbSettings.Controls.Add(this.groupBox2);
            this.TpbSettings.Controls.Add(this.groupBox1);
            this.TpbSettings.Location = new System.Drawing.Point(4, 24);
            this.TpbSettings.Name = "TpbSettings";
            this.TpbSettings.Size = new System.Drawing.Size(887, 622);
            this.TpbSettings.TabIndex = 4;
            this.TpbSettings.Text = "Settings";
            this.TpbSettings.UseVisualStyleBackColor = true;
            // 
            // BtnSettingsSave
            // 
            this.BtnSettingsSave.Location = new System.Drawing.Point(731, 512);
            this.BtnSettingsSave.Name = "BtnSettingsSave";
            this.BtnSettingsSave.Size = new System.Drawing.Size(148, 29);
            this.BtnSettingsSave.TabIndex = 27;
            this.BtnSettingsSave.Text = "Save settings";
            this.BtnSettingsSave.UseVisualStyleBackColor = true;
            this.BtnSettingsSave.Click += new System.EventHandler(this.BtnSettingsSaveClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxbSettingsDefaultSolutionFileName);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.TxbSettingsNewBranchPrefix);
            this.groupBox5.Controls.Add(this.label19);
            this.groupBox5.Controls.Add(this.TxbSettingsExcludeGitCleanPattern);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.TxbSettingsUris);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Location = new System.Drawing.Point(8, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(871, 87);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Generic";
            // 
            // TxbSettingsDefaultSolutionFileName
            // 
            this.TxbSettingsDefaultSolutionFileName.Location = new System.Drawing.Point(741, 19);
            this.TxbSettingsDefaultSolutionFileName.Name = "TxbSettingsDefaultSolutionFileName";
            this.TxbSettingsDefaultSolutionFileName.Size = new System.Drawing.Size(124, 23);
            this.TxbSettingsDefaultSolutionFileName.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(592, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(143, 15);
            this.label20.TabIndex = 13;
            this.label20.Text = "Default solution file name";
            // 
            // TxbSettingsNewBranchPrefix
            // 
            this.TxbSettingsNewBranchPrefix.Location = new System.Drawing.Point(446, 19);
            this.TxbSettingsNewBranchPrefix.Name = "TxbSettingsNewBranchPrefix";
            this.TxbSettingsNewBranchPrefix.Size = new System.Drawing.Size(124, 23);
            this.TxbSettingsNewBranchPrefix.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(322, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(103, 15);
            this.label19.TabIndex = 11;
            this.label19.Text = "New branch prefix";
            // 
            // TxbSettingsExcludeGitCleanPattern
            // 
            this.TxbSettingsExcludeGitCleanPattern.Location = new System.Drawing.Point(169, 19);
            this.TxbSettingsExcludeGitCleanPattern.Name = "TxbSettingsExcludeGitCleanPattern";
            this.TxbSettingsExcludeGitCleanPattern.Size = new System.Drawing.Size(124, 23);
            this.TxbSettingsExcludeGitCleanPattern.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(65, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "URIs (sep ;)";
            // 
            // TxbSettingsUris
            // 
            this.TxbSettingsUris.Location = new System.Drawing.Point(169, 48);
            this.TxbSettingsUris.Name = "TxbSettingsUris";
            this.TxbSettingsUris.Size = new System.Drawing.Size(696, 23);
            this.TxbSettingsUris.TabIndex = 4;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(14, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(139, 15);
            this.label18.TabIndex = 2;
            this.label18.Text = "Exclude Git Clean pattern";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CbxSettingsProcessNugetRestore);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessRestoreDatabases);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessPostBuild);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessRunPreBuild);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessRunUris);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessGitClean);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessCheckout);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessStashPop);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessStashChanges);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessRunVisualStudio);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessExitVisualStudio);
            this.groupBox4.Controls.Add(this.CbxSettingsProcessBuild);
            this.groupBox4.Location = new System.Drawing.Point(8, 420);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(871, 86);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Default process actions";
            // 
            // CbxSettingsProcessNugetRestore
            // 
            this.CbxSettingsProcessNugetRestore.AutoSize = true;
            this.CbxSettingsProcessNugetRestore.Location = new System.Drawing.Point(735, 22);
            this.CbxSettingsProcessNugetRestore.Name = "CbxSettingsProcessNugetRestore";
            this.CbxSettingsProcessNugetRestore.Size = new System.Drawing.Size(98, 19);
            this.CbxSettingsProcessNugetRestore.TabIndex = 20;
            this.CbxSettingsProcessNugetRestore.Text = "Nuget restore";
            this.CbxSettingsProcessNugetRestore.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessRestoreDatabases
            // 
            this.CbxSettingsProcessRestoreDatabases.AutoSize = true;
            this.CbxSettingsProcessRestoreDatabases.Location = new System.Drawing.Point(469, 47);
            this.CbxSettingsProcessRestoreDatabases.Name = "CbxSettingsProcessRestoreDatabases";
            this.CbxSettingsProcessRestoreDatabases.Size = new System.Drawing.Size(120, 19);
            this.CbxSettingsProcessRestoreDatabases.TabIndex = 24;
            this.CbxSettingsProcessRestoreDatabases.Text = "Restore databases";
            this.CbxSettingsProcessRestoreDatabases.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessPostBuild
            // 
            this.CbxSettingsProcessPostBuild.AutoSize = true;
            this.CbxSettingsProcessPostBuild.Location = new System.Drawing.Point(300, 47);
            this.CbxSettingsProcessPostBuild.Name = "CbxSettingsProcessPostBuild";
            this.CbxSettingsProcessPostBuild.Size = new System.Drawing.Size(138, 19);
            this.CbxSettingsProcessPostBuild.TabIndex = 23;
            this.CbxSettingsProcessPostBuild.Text = "Run Post-Build batch";
            this.CbxSettingsProcessPostBuild.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessRunPreBuild
            // 
            this.CbxSettingsProcessRunPreBuild.AutoSize = true;
            this.CbxSettingsProcessRunPreBuild.Location = new System.Drawing.Point(18, 47);
            this.CbxSettingsProcessRunPreBuild.Name = "CbxSettingsProcessRunPreBuild";
            this.CbxSettingsProcessRunPreBuild.Size = new System.Drawing.Size(132, 19);
            this.CbxSettingsProcessRunPreBuild.TabIndex = 21;
            this.CbxSettingsProcessRunPreBuild.Text = "Run Pre-Build batch";
            this.CbxSettingsProcessRunPreBuild.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessRunUris
            // 
            this.CbxSettingsProcessRunUris.AutoSize = true;
            this.CbxSettingsProcessRunUris.Location = new System.Drawing.Point(735, 47);
            this.CbxSettingsProcessRunUris.Name = "CbxSettingsProcessRunUris";
            this.CbxSettingsProcessRunUris.Size = new System.Drawing.Size(68, 19);
            this.CbxSettingsProcessRunUris.TabIndex = 26;
            this.CbxSettingsProcessRunUris.Text = "Run URI";
            this.CbxSettingsProcessRunUris.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessGitClean
            // 
            this.CbxSettingsProcessGitClean.AutoSize = true;
            this.CbxSettingsProcessGitClean.Location = new System.Drawing.Point(469, 22);
            this.CbxSettingsProcessGitClean.Name = "CbxSettingsProcessGitClean";
            this.CbxSettingsProcessGitClean.Size = new System.Drawing.Size(72, 19);
            this.CbxSettingsProcessGitClean.TabIndex = 18;
            this.CbxSettingsProcessGitClean.Text = "Git clean";
            this.CbxSettingsProcessGitClean.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessCheckout
            // 
            this.CbxSettingsProcessCheckout.AutoSize = true;
            this.CbxSettingsProcessCheckout.Location = new System.Drawing.Point(300, 22);
            this.CbxSettingsProcessCheckout.Name = "CbxSettingsProcessCheckout";
            this.CbxSettingsProcessCheckout.Size = new System.Drawing.Size(166, 19);
            this.CbxSettingsProcessCheckout.TabIndex = 17;
            this.CbxSettingsProcessCheckout.Text = "Checkout or create branch";
            this.CbxSettingsProcessCheckout.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessStashPop
            // 
            this.CbxSettingsProcessStashPop.AutoSize = true;
            this.CbxSettingsProcessStashPop.Location = new System.Drawing.Point(600, 22);
            this.CbxSettingsProcessStashPop.Name = "CbxSettingsProcessStashPop";
            this.CbxSettingsProcessStashPop.Size = new System.Drawing.Size(78, 19);
            this.CbxSettingsProcessStashPop.TabIndex = 19;
            this.CbxSettingsProcessStashPop.Text = "Stash pop";
            this.CbxSettingsProcessStashPop.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessStashChanges
            // 
            this.CbxSettingsProcessStashChanges.AutoSize = true;
            this.CbxSettingsProcessStashChanges.Location = new System.Drawing.Point(156, 22);
            this.CbxSettingsProcessStashChanges.Name = "CbxSettingsProcessStashChanges";
            this.CbxSettingsProcessStashChanges.Size = new System.Drawing.Size(101, 19);
            this.CbxSettingsProcessStashChanges.TabIndex = 16;
            this.CbxSettingsProcessStashChanges.Text = "Stash changes";
            this.CbxSettingsProcessStashChanges.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessRunVisualStudio
            // 
            this.CbxSettingsProcessRunVisualStudio.AutoSize = true;
            this.CbxSettingsProcessRunVisualStudio.Location = new System.Drawing.Point(600, 47);
            this.CbxSettingsProcessRunVisualStudio.Name = "CbxSettingsProcessRunVisualStudio";
            this.CbxSettingsProcessRunVisualStudio.Size = new System.Drawing.Size(118, 19);
            this.CbxSettingsProcessRunVisualStudio.TabIndex = 25;
            this.CbxSettingsProcessRunVisualStudio.Text = "Run Visual Studio";
            this.CbxSettingsProcessRunVisualStudio.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessExitVisualStudio
            // 
            this.CbxSettingsProcessExitVisualStudio.AutoSize = true;
            this.CbxSettingsProcessExitVisualStudio.Location = new System.Drawing.Point(18, 22);
            this.CbxSettingsProcessExitVisualStudio.Name = "CbxSettingsProcessExitVisualStudio";
            this.CbxSettingsProcessExitVisualStudio.Size = new System.Drawing.Size(115, 19);
            this.CbxSettingsProcessExitVisualStudio.TabIndex = 15;
            this.CbxSettingsProcessExitVisualStudio.Text = "Exit Visual Studio";
            this.CbxSettingsProcessExitVisualStudio.UseVisualStyleBackColor = true;
            // 
            // CbxSettingsProcessBuild
            // 
            this.CbxSettingsProcessBuild.AutoSize = true;
            this.CbxSettingsProcessBuild.Location = new System.Drawing.Point(156, 47);
            this.CbxSettingsProcessBuild.Name = "CbxSettingsProcessBuild";
            this.CbxSettingsProcessBuild.Size = new System.Drawing.Size(110, 19);
            this.CbxSettingsProcessBuild.TabIndex = 22;
            this.CbxSettingsProcessBuild.Text = "Build or Rebuild";
            this.CbxSettingsProcessBuild.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxbSettingsBatchPostBuildScripts);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.TxbSettingsBatchPreBuildScripts);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(8, 328);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(871, 86);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Batch";
            // 
            // TxbSettingsBatchPostBuildScripts
            // 
            this.TxbSettingsBatchPostBuildScripts.Location = new System.Drawing.Point(167, 50);
            this.TxbSettingsBatchPostBuildScripts.Name = "TxbSettingsBatchPostBuildScripts";
            this.TxbSettingsBatchPostBuildScripts.Size = new System.Drawing.Size(698, 23);
            this.TxbSettingsBatchPostBuildScripts.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "Pre build scripts (sep ;)";
            // 
            // TxbSettingsBatchPreBuildScripts
            // 
            this.TxbSettingsBatchPreBuildScripts.Location = new System.Drawing.Point(167, 21);
            this.TxbSettingsBatchPreBuildScripts.Name = "TxbSettingsBatchPreBuildScripts";
            this.TxbSettingsBatchPreBuildScripts.Size = new System.Drawing.Size(698, 23);
            this.TxbSettingsBatchPreBuildScripts.TabIndex = 13;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(12, 53);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 15);
            this.label16.TabIndex = 2;
            this.label16.Text = "Post build scripts (sep ;)";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxbSettingsDatabasesRestore);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.TxbSettingsDatabaseRelocateFile);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.TxbSettingsDatabaseServerName);
            this.groupBox2.Location = new System.Drawing.Point(8, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(870, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Databases parameters";
            // 
            // TxbSettingsDatabasesRestore
            // 
            this.TxbSettingsDatabasesRestore.Location = new System.Drawing.Point(167, 58);
            this.TxbSettingsDatabasesRestore.Name = "TxbSettingsDatabasesRestore";
            this.TxbSettingsDatabasesRestore.Size = new System.Drawing.Size(698, 23);
            this.TxbSettingsDatabasesRestore.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "Databases to restore (sep ;)";
            // 
            // TxbSettingsDatabaseRelocateFile
            // 
            this.TxbSettingsDatabaseRelocateFile.Location = new System.Drawing.Point(167, 87);
            this.TxbSettingsDatabaseRelocateFile.Name = "TxbSettingsDatabaseRelocateFile";
            this.TxbSettingsDatabaseRelocateFile.Size = new System.Drawing.Size(698, 23);
            this.TxbSettingsDatabaseRelocateFile.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 15);
            this.label11.TabIndex = 6;
            this.label11.Text = "Relocate files path";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 1;
            this.label8.Text = "Server name";
            // 
            // TxbSettingsDatabaseServerName
            // 
            this.TxbSettingsDatabaseServerName.Location = new System.Drawing.Point(167, 29);
            this.TxbSettingsDatabaseServerName.Name = "TxbSettingsDatabaseServerName";
            this.TxbSettingsDatabaseServerName.Size = new System.Drawing.Size(126, 23);
            this.TxbSettingsDatabaseServerName.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CbxSettingsNotificationsEnable);
            this.groupBox1.Controls.Add(this.TxbSettingsNotificationsMonitorBranches);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.TxbSettingsNotificationsCheckIntrerval);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(8, 222);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(870, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notifications";
            // 
            // CbxSettingsNotificationsEnable
            // 
            this.CbxSettingsNotificationsEnable.AutoSize = true;
            this.CbxSettingsNotificationsEnable.Location = new System.Drawing.Point(322, 25);
            this.CbxSettingsNotificationsEnable.Name = "CbxSettingsNotificationsEnable";
            this.CbxSettingsNotificationsEnable.Size = new System.Drawing.Size(130, 19);
            this.CbxSettingsNotificationsEnable.TabIndex = 11;
            this.CbxSettingsNotificationsEnable.Text = "Enable notifications";
            this.CbxSettingsNotificationsEnable.UseVisualStyleBackColor = true;
            this.CbxSettingsNotificationsEnable.CheckedChanged += new System.EventHandler(this.CbxSettingsNotificationsEnableCheckedChanged);
            // 
            // TxbSettingsNotificationsMonitorBranches
            // 
            this.TxbSettingsNotificationsMonitorBranches.Location = new System.Drawing.Point(167, 55);
            this.TxbSettingsNotificationsMonitorBranches.Name = "TxbSettingsNotificationsMonitorBranches";
            this.TxbSettingsNotificationsMonitorBranches.Size = new System.Drawing.Size(698, 23);
            this.TxbSettingsNotificationsMonitorBranches.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "Monitor branches (sep ;)";
            // 
            // TxbSettingsNotificationsCheckIntrerval
            // 
            this.TxbSettingsNotificationsCheckIntrerval.Location = new System.Drawing.Point(167, 23);
            this.TxbSettingsNotificationsCheckIntrerval.Name = "TxbSettingsNotificationsCheckIntrerval";
            this.TxbSettingsNotificationsCheckIntrerval.Size = new System.Drawing.Size(126, 23);
            this.TxbSettingsNotificationsCheckIntrerval.TabIndex = 10;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(149, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Check interval (in seconds)";
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
            this.GbxActualInfos.Controls.Add(this.LblBranchesObsoletes);
            this.GbxActualInfos.Controls.Add(this.PbxBranchesObsoletesBranches);
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
            // LblBranchesObsoletes
            // 
            this.LblBranchesObsoletes.AutoSize = true;
            this.LblBranchesObsoletes.Location = new System.Drawing.Point(678, 44);
            this.LblBranchesObsoletes.Name = "LblBranchesObsoletes";
            this.LblBranchesObsoletes.Size = new System.Drawing.Size(0, 15);
            this.LblBranchesObsoletes.TabIndex = 13;
            // 
            // PbxBranchesObsoletesBranches
            // 
            this.PbxBranchesObsoletesBranches.BackColor = System.Drawing.Color.Gray;
            this.PbxBranchesObsoletesBranches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbxBranchesObsoletesBranches.Location = new System.Drawing.Point(655, 41);
            this.PbxBranchesObsoletesBranches.Name = "PbxBranchesObsoletesBranches";
            this.PbxBranchesObsoletesBranches.Size = new System.Drawing.Size(20, 20);
            this.PbxBranchesObsoletesBranches.TabIndex = 12;
            this.PbxBranchesObsoletesBranches.TabStop = false;
            this.PbxBranchesObsoletesBranches.Click += new System.EventHandler(this.PbxBranchesUpToDateClick);
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
            this.PbxBranchesMustUpdate.BackColor = System.Drawing.Color.Tomato;
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
            // BtnDsbShowBranch
            // 
            this.BtnDsbShowBranch.Location = new System.Drawing.Point(722, 22);
            this.BtnDsbShowBranch.Name = "BtnDsbShowBranch";
            this.BtnDsbShowBranch.Size = new System.Drawing.Size(148, 29);
            this.BtnDsbShowBranch.TabIndex = 25;
            this.BtnDsbShowBranch.Text = "Show remotes branches";
            this.BtnDsbShowBranch.UseVisualStyleBackColor = true;
            this.BtnDsbShowBranch.Click += new System.EventHandler(this.BtnDsbShowBranchClick);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label9);
            this.groupBox6.Controls.Add(this.TxbDsbBranchPrefix);
            this.groupBox6.Controls.Add(this.BtnDsbShowBranch);
            this.groupBox6.Location = new System.Drawing.Point(3, 318);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(876, 60);
            this.groupBox6.TabIndex = 26;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Branches";
            // 
            // TxbDsbBranchPrefix
            // 
            this.TxbDsbBranchPrefix.Location = new System.Drawing.Point(106, 26);
            this.TxbDsbBranchPrefix.Name = "TxbDsbBranchPrefix";
            this.TxbDsbBranchPrefix.Size = new System.Drawing.Size(610, 23);
            this.TxbDsbBranchPrefix.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Branch prefix";
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.TbpLocalsBranches.ResumeLayout(false);
            this.GbxLocalsBranchesActions.ResumeLayout(false);
            this.GbxLocalsBranchesActions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLocalsBranchesObsoletes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLocalsBranchesMustBeUpdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxLocalsBranchesUpToDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalsBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchDtoBindingSource)).EndInit();
            this.TpbNotifications.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvNtfNotifications)).EndInit();
            this.TpbDashboard.ResumeLayout(false);
            this.GbxDsbVisualStudioSolution.ResumeLayout(false);
            this.GbxDsbVisualStudioSolution.PerformLayout();
            this.GbxDsbDatabases.ResumeLayout(false);
            this.GbxDsbDatabases.PerformLayout();
            this.GbxDsbGeneric.ResumeLayout(false);
            this.GbxDsbGeneric.PerformLayout();
            this.TpbSettings.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxDsbLoadingAction)).EndInit();
            this.GbxActualInfos.ResumeLayout(false);
            this.GbxActualInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxBranchesObsoletesBranches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxBranchesMustUpdate)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
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
        private System.Windows.Forms.TextBox TxbProcessDatabasesToRestore;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.CheckBox CbxIsNugetRestore;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox PbxLocalsBranchesUpToDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PbxLocalsBranchesMustBeUpdate;
        private System.Windows.Forms.Label LblNeedToUpdate;
        private System.Windows.Forms.PictureBox PbxBranchesMustUpdate;
        private System.Windows.Forms.Label LblBranchesObsoletes;
        private System.Windows.Forms.PictureBox PbxBranchesObsoletesBranches;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage TpbDashboard;
        private System.Windows.Forms.PictureBox PbxDsbLoadingAction;
        private System.Windows.Forms.TabPage TpbSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage TpbNotifications;
        private System.Windows.Forms.DataGridView DgvNtfNotifications;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxbSettingsDatabaseServerName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxbSettingsDatabaseRelocateFile;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxbSettingsDatabasesRestore;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxbSettingsNotificationsMonitorBranches;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxbSettingsNotificationsCheckIntrerval;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxbSettingsBatchPostBuildScripts;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox TxbSettingsBatchPreBuildScripts;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox CbxSettingsProcessBuild;
        private System.Windows.Forms.CheckBox CbxSettingsProcessExitVisualStudio;
        private System.Windows.Forms.CheckBox CbxSettingsProcessRunVisualStudio;
        private System.Windows.Forms.CheckBox CbxSettingsProcessStashChanges;
        private System.Windows.Forms.CheckBox CbxSettingsProcessStashPop;
        private System.Windows.Forms.CheckBox CbxSettingsProcessCheckout;
        private System.Windows.Forms.CheckBox CbxSettingsProcessGitClean;
        private System.Windows.Forms.CheckBox CbxSettingsProcessRunUris;
        private System.Windows.Forms.CheckBox CbxSettingsProcessRunPreBuild;
        private System.Windows.Forms.CheckBox CbxSettingsProcessPostBuild;
        private System.Windows.Forms.CheckBox CbxSettingsProcessRestoreDatabases;
        private System.Windows.Forms.CheckBox CbxSettingsProcessNugetRestore;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox TxbSettingsDefaultSolutionFileName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TxbSettingsNewBranchPrefix;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxbSettingsExcludeGitCleanPattern;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox TxbSettingsUris;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button BtnSettingsSave;
        private System.Windows.Forms.CheckBox CbxSettingsNotificationsEnable;
        private System.Windows.Forms.GroupBox GbxDsbVisualStudioSolution;
        private System.Windows.Forms.ComboBox CblDsbSolutions;
        private System.Windows.Forms.Button BtnDsbExitSolution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnDsbRebuildSolution;
        private System.Windows.Forms.Button BtnDsbStartSolution;
        private System.Windows.Forms.Button BtnDsbNugetRestore;
        private System.Windows.Forms.Button BtnDsbBuildSolution;
        private System.Windows.Forms.GroupBox GbxDsbDatabases;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnDsbRestoreDatabases;
        private System.Windows.Forms.TextBox TxbDsbDatabasesToRestore;
        private System.Windows.Forms.GroupBox GbxDsbGeneric;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BtnDsbStashChanges;
        private System.Windows.Forms.Button BtnDsbGitClean;
        private System.Windows.Forms.Button BtnDsbFetchAll;
        private System.Windows.Forms.TextBox TxbDsbGitClean;
        private System.Windows.Forms.Button BtnDsbStashPop;
        private System.Windows.Forms.Button BtnDsbRunScriptPostbuild;
        private System.Windows.Forms.Button BtnDsbExitAllVisualStudio;
        private System.Windows.Forms.Button BtnDsbRunScriptPrebuild;
        private System.Windows.Forms.Button BtnDsbCancelAction;
        private System.Windows.Forms.Button BtnLocalsBranchesSelectObsoletes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn NeedUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsObsolete;
        private System.Windows.Forms.PictureBox PbxLocalsBranchesObsoletes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button BtnDsbShowBranch;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxbDsbBranchPrefix;
    }
}