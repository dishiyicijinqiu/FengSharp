using FengSharp.UpdateMaker.Controls;
namespace FengSharp.UpdateMaker
{
    partial class MainForm
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
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.btnEditRtf = new System.Windows.Forms.Button();
            this.btnBrowserRtf = new System.Windows.Forms.Button();
            this.rtfPath = new System.Windows.Forms.TextBox();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveProject = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fileConfig = new FengSharp.UpdateMaker.Controls.FileConfiguration();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.txtPackagePath = new System.Windows.Forms.TextBox();
            this.txtNewSoftDir = new System.Windows.Forms.TextBox();
            this.txtPublishUrl = new System.Windows.Forms.TextBox();
            this.txtAppVersion = new System.Windows.Forms.TextBox();
            this.txtPreExecuteArgs = new System.Windows.Forms.TextBox();
            this.txtAfterExecuteArgs = new System.Windows.Forms.TextBox();
            this.txtStartApp = new System.Windows.Forms.TextBox();
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.browseFile = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnBrowseStartApp = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.fileAfterExecute = new FengSharp.UpdateMaker.Controls.FileComboBox();
            this.filePreExecute = new FengSharp.UpdateMaker.Controls.FileComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.epp = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOpen = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage6.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epp)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.txtDesc);
            this.tabPage6.Controls.Add(this.btnEditRtf);
            this.tabPage6.Controls.Add(this.btnBrowserRtf);
            this.tabPage6.Controls.Add(this.rtfPath);
            this.tabPage6.Controls.Add(this.txtUrl);
            this.tabPage6.Controls.Add(this.label13);
            this.tabPage6.Controls.Add(this.label12);
            this.tabPage6.Controls.Add(this.label11);
            this.tabPage6.Controls.Add(this.label8);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1009, 540);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "更新说明";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(3, 120);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(1003, 417);
            this.txtDesc.TabIndex = 12;
            // 
            // btnEditRtf
            // 
            this.btnEditRtf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnEditRtf.Location = new System.Drawing.Point(670, 293);
            this.btnEditRtf.Name = "btnEditRtf";
            this.btnEditRtf.Size = new System.Drawing.Size(62, 23);
            this.btnEditRtf.TabIndex = 16;
            this.btnEditRtf.Text = "编辑";
            this.btnEditRtf.UseVisualStyleBackColor = true;
            // 
            // btnBrowserRtf
            // 
            this.btnBrowserRtf.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowserRtf.Location = new System.Drawing.Point(607, 293);
            this.btnBrowserRtf.Name = "btnBrowserRtf";
            this.btnBrowserRtf.Size = new System.Drawing.Size(62, 23);
            this.btnBrowserRtf.TabIndex = 16;
            this.btnBrowserRtf.Text = "浏览";
            this.btnBrowserRtf.UseVisualStyleBackColor = true;
            // 
            // rtfPath
            // 
            this.rtfPath.Location = new System.Drawing.Point(115, 294);
            this.rtfPath.Name = "rtfPath";
            this.rtfPath.ReadOnly = true;
            this.rtfPath.Size = new System.Drawing.Size(486, 21);
            this.rtfPath.TabIndex = 15;
            this.tip.SetToolTip(this.rtfPath, "您可以拖放一个RTF文件到这里");
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(115, 267);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(617, 21);
            this.txtUrl.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(12, 299);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 12);
            this.label13.TabIndex = 14;
            this.label13.Text = "RTF格式说明文件";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label12.Location = new System.Drawing.Point(12, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "更新说明网址";
            // 
            // label11
            // 
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(6, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(726, 69);
            this.label11.TabIndex = 13;
            this.label11.Text = "在2.2.0.0版本之后的库中，同时支持纯文字、内嵌网页以及RTF样式的更新说明。默认情况下，内嵌网页如果填写，则优先显示内嵌网页；否则优先显示RTF格式文本，最" +
    "后再显示纯文字版。\r\n\r\n考虑到之前版本的兼容性，如果您有发布过使用老版本升级库的应用程序，建议始终填写纯文字版，在此基础上再填写网页链接或选择RTF文件。注意" +
    "，RTF文件可能导致最终的说明文件体积很大，请尽量使用压缩版XML信息文件。";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(6, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "纯文字版";
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveProject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSaveProject.Location = new System.Drawing.Point(12, 591);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(115, 30);
            this.btnSaveProject.TabIndex = 22;
            this.btnSaveProject.Text = "保存升级项目";
            this.btnSaveProject.UseVisualStyleBackColor = true;
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.fileConfig);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1009, 540);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "文件配置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fileConfig
            // 
            this.fileConfig.CurrentUpdateInfo = null;
            this.fileConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileConfig.Location = new System.Drawing.Point(3, 3);
            this.fileConfig.Name = "fileConfig";
            this.fileConfig.NewVersionFolder = null;
            this.fileConfig.Size = new System.Drawing.Size(1003, 534);
            this.fileConfig.TabIndex = 0;
            // 
            // tip
            // 
            this.tip.AutomaticDelay = 100;
            this.tip.AutoPopDelay = 10000;
            this.tip.InitialDelay = 0;
            this.tip.ReshowDelay = 20;
            this.tip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tip.ToolTipTitle = "提示";
            // 
            // txtPackagePath
            // 
            this.txtPackagePath.Location = new System.Drawing.Point(87, 221);
            this.txtPackagePath.Name = "txtPackagePath";
            this.txtPackagePath.Size = new System.Drawing.Size(840, 21);
            this.txtPackagePath.TabIndex = 14;
            this.tip.SetToolTip(this.txtPackagePath, "请选择保存升级文件的目录");
            this.txtPackagePath.TextChanged += new System.EventHandler(this.txtPackagePath_TextChanged);
            // 
            // txtNewSoftDir
            // 
            this.txtNewSoftDir.Location = new System.Drawing.Point(87, 83);
            this.txtNewSoftDir.Name = "txtNewSoftDir";
            this.txtNewSoftDir.Size = new System.Drawing.Size(841, 21);
            this.txtNewSoftDir.TabIndex = 14;
            this.tip.SetToolTip(this.txtNewSoftDir, "请选择最新版程序的目录");
            this.txtNewSoftDir.TextChanged += new System.EventHandler(this.txtNewSoftDir_TextChanged);
            // 
            // txtPublishUrl
            // 
            this.txtPublishUrl.Location = new System.Drawing.Point(87, 175);
            this.txtPublishUrl.Name = "txtPublishUrl";
            this.txtPublishUrl.Size = new System.Drawing.Size(912, 21);
            this.txtPublishUrl.TabIndex = 2;
            this.tip.SetToolTip(this.txtPublishUrl, "供用户点击查看更详细信息的网页地址, 留空则禁止这个链接显示");
            // 
            // txtAppVersion
            // 
            this.txtAppVersion.Location = new System.Drawing.Point(758, 37);
            this.txtAppVersion.Name = "txtAppVersion";
            this.txtAppVersion.Size = new System.Drawing.Size(242, 21);
            this.txtAppVersion.TabIndex = 2;
            this.tip.SetToolTip(this.txtAppVersion, "格式: 1.2.3.4");
            // 
            // txtPreExecuteArgs
            // 
            this.txtPreExecuteArgs.Location = new System.Drawing.Point(703, 267);
            this.txtPreExecuteArgs.Name = "txtPreExecuteArgs";
            this.txtPreExecuteArgs.Size = new System.Drawing.Size(297, 21);
            this.txtPreExecuteArgs.TabIndex = 7;
            this.tip.SetToolTip(this.txtPreExecuteArgs, "命令行参数");
            // 
            // txtAfterExecuteArgs
            // 
            this.txtAfterExecuteArgs.Location = new System.Drawing.Point(703, 313);
            this.txtAfterExecuteArgs.Name = "txtAfterExecuteArgs";
            this.txtAfterExecuteArgs.Size = new System.Drawing.Size(297, 21);
            this.txtAfterExecuteArgs.TabIndex = 9;
            this.tip.SetToolTip(this.txtAfterExecuteArgs, "命令行参数");
            // 
            // txtStartApp
            // 
            this.txtStartApp.Location = new System.Drawing.Point(87, 129);
            this.txtStartApp.Name = "txtStartApp";
            this.txtStartApp.ReadOnly = true;
            this.txtStartApp.Size = new System.Drawing.Size(602, 21);
            this.txtStartApp.TabIndex = 20;
            this.tip.SetToolTip(this.txtStartApp, "请选择主程序位置");
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpenProject.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpenProject.Location = new System.Drawing.Point(133, 591);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(115, 30);
            this.btnOpenProject.TabIndex = 23;
            this.btnOpenProject.Text = "打开升级项目";
            this.btnOpenProject.UseVisualStyleBackColor = true;
            this.btnOpenProject.Click += new System.EventHandler(this.btnOpenProject_Click);
            // 
            // browseFile
            // 
            this.browseFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.browseFile.Location = new System.Drawing.Point(934, 220);
            this.browseFile.Name = "browseFile";
            this.browseFile.Size = new System.Drawing.Size(66, 23);
            this.browseFile.TabIndex = 16;
            this.browseFile.Text = "浏览";
            this.browseFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.browseFile.UseVisualStyleBackColor = true;
            this.browseFile.Click += new System.EventHandler(this.browseFile_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowseFolder.Location = new System.Drawing.Point(934, 82);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(66, 23);
            this.btnBrowseFolder.TabIndex = 15;
            this.btnBrowseFolder.Text = "浏览";
            this.btnBrowseFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "应用程序名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(695, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前版本";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(256, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 13;
            this.label10.Text = "（秒,0为不限制）";
            this.label10.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(30, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "发布地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(18, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "新程序目录";
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnCreate.Location = new System.Drawing.Point(769, 591);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(115, 30);
            this.btnCreate.TabIndex = 19;
            this.btnCreate.Text = "创建升级包";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(87, 359);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(161, 21);
            this.txtTimeout.TabIndex = 12;
            this.txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTimeout.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(18, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "升级包路径";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblStatus.Location = new System.Drawing.Point(18, 413);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 12);
            this.lblStatus.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnBrowseStartApp);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.txtStartApp);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.fileAfterExecute);
            this.tabPage1.Controls.Add(this.filePreExecute);
            this.tabPage1.Controls.Add(this.browseFile);
            this.tabPage1.Controls.Add(this.btnBrowseFolder);
            this.tabPage1.Controls.Add(this.txtPackagePath);
            this.tabPage1.Controls.Add(this.txtNewSoftDir);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtTimeout);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtAfterExecuteArgs);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtPreExecuteArgs);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtAppName);
            this.tabPage1.Controls.Add(this.txtPublishUrl);
            this.tabPage1.Controls.Add(this.txtAppVersion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1009, 540);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基本信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnBrowseStartApp
            // 
            this.btnBrowseStartApp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnBrowseStartApp.Location = new System.Drawing.Point(697, 128);
            this.btnBrowseStartApp.Name = "btnBrowseStartApp";
            this.btnBrowseStartApp.Size = new System.Drawing.Size(66, 23);
            this.btnBrowseStartApp.TabIndex = 24;
            this.btnBrowseStartApp.Text = "浏览";
            this.btnBrowseStartApp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseStartApp.UseVisualStyleBackColor = true;
            this.btnBrowseStartApp.Click += new System.EventHandler(this.btnBrowseStartApp_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label16.Location = new System.Drawing.Point(794, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(197, 12);
            this.label16.TabIndex = 23;
            this.label16.Text = "相对于升级程序的位置加主程序名称";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label14.Location = new System.Drawing.Point(18, 133);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "主程序位置";
            // 
            // fileAfterExecute
            // 
            this.fileAfterExecute.AllowDrop = true;
            this.fileAfterExecute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileAfterExecute.FileTypeFilter = "exe";
            this.fileAfterExecute.FormattingEnabled = true;
            this.fileAfterExecute.Items.AddRange(new object[] {
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>"});
            this.fileAfterExecute.Location = new System.Drawing.Point(87, 313);
            this.fileAfterExecute.Name = "fileAfterExecute";
            this.fileAfterExecute.PreferFileName = null;
            this.fileAfterExecute.RootPath = null;
            this.fileAfterExecute.SelectedFileName = "";
            this.fileAfterExecute.ShowEmptyEntry = true;
            this.fileAfterExecute.Size = new System.Drawing.Size(600, 20);
            this.fileAfterExecute.TabIndex = 18;
            // 
            // filePreExecute
            // 
            this.filePreExecute.AllowDrop = true;
            this.filePreExecute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filePreExecute.FileTypeFilter = "exe";
            this.filePreExecute.FormattingEnabled = true;
            this.filePreExecute.Items.AddRange(new object[] {
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>",
            "<未选择>"});
            this.filePreExecute.Location = new System.Drawing.Point(87, 267);
            this.filePreExecute.Name = "filePreExecute";
            this.filePreExecute.PreferFileName = null;
            this.filePreExecute.RootPath = null;
            this.filePreExecute.SelectedFileName = "";
            this.filePreExecute.ShowEmptyEntry = true;
            this.filePreExecute.Size = new System.Drawing.Size(600, 20);
            this.filePreExecute.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(18, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "更新前执行";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(18, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "更新后执行";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(6, 363);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "执行时间限制";
            this.label9.Visible = false;
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(87, 37);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(601, 21);
            this.txtAppName.TabIndex = 1;
            // 
            // epp
            // 
            this.epp.ContainerControl = this;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnOpen.Location = new System.Drawing.Point(890, 591);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(115, 30);
            this.btnOpen.TabIndex = 20;
            this.btnOpen.Text = "打开升级包";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1017, 566);
            this.tabControl1.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 628);
            this.Controls.Add(this.btnSaveProject);
            this.Controls.Add(this.btnOpenProject);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "升级包创建工具";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epp)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip tip;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button btnEditRtf;
        private System.Windows.Forms.Button btnBrowserRtf;
        private System.Windows.Forms.TextBox rtfPath;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Button btnSaveProject;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Button btnOpenProject;
        private System.Windows.Forms.Button browseFile;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtPackagePath;
        private System.Windows.Forms.TextBox txtNewSoftDir;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.TextBox txtPublishUrl;
        private System.Windows.Forms.TextBox txtAppVersion;
        private System.Windows.Forms.ErrorProvider epp;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtAfterExecuteArgs;
        private System.Windows.Forms.TextBox txtPreExecuteArgs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private FileComboBox fileAfterExecute;
        private FileComboBox filePreExecute;
        private FileConfiguration fileConfig;
        private System.Windows.Forms.TextBox txtStartApp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnBrowseStartApp;
    }
}

