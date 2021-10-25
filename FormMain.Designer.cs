namespace CrudClassGenerator
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlGeneration = new System.Windows.Forms.TabControl();
            this.tabPageCCG = new System.Windows.Forms.TabPage();
            this.labelConnStrName = new System.Windows.Forms.Label();
            this.textBoxConnectionStringName = new System.Windows.Forms.TextBox();
            this.groupBoxLogTable = new System.Windows.Forms.GroupBox();
            this.labelLogTable = new System.Windows.Forms.Label();
            this.textBoxFullTableNameForLog = new System.Windows.Forms.TextBox();
            this.groupBoxInheritPrmClassFrom = new System.Windows.Forms.GroupBox();
            this.textBoxInheritanceClassNameForPrm = new System.Windows.Forms.TextBox();
            this.labelPrmInheritPrmClassFrom = new System.Windows.Forms.Label();
            this.groupBoxPrm = new System.Windows.Forms.GroupBox();
            this.radioButtonUseCCPath = new System.Windows.Forms.RadioButton();
            this.radioButtonUseInterfacePath = new System.Windows.Forms.RadioButton();
            this.checkBoxPrmClassSeparate = new System.Windows.Forms.CheckBox();
            this.checkBoxPrmClassInCCFile = new System.Windows.Forms.CheckBox();
            this.checkBoxPrmClassInInterfaceFile = new System.Windows.Forms.CheckBox();
            this.lblPrm = new System.Windows.Forms.Label();
            this.groupBoxTemplate = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxTemplateInterface = new System.Windows.Forms.CheckBox();
            this.checkBoxTemplateCc = new System.Windows.Forms.CheckBox();
            this.groupBoxCRUD = new System.Windows.Forms.GroupBox();
            this.checkBoxCreateOnlySelectAsClass = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxAddServiceContract = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateOnlySelect = new System.Windows.Forms.CheckBox();
            this.labelCRUD = new System.Windows.Forms.Label();
            this.checkBoxAddNoLock = new System.Windows.Forms.CheckBox();
            this.checkBoxTypedDs = new System.Windows.Forms.CheckBox();
            this.checkBoxCrudCC = new System.Windows.Forms.CheckBox();
            this.checkBoxCrudInterface = new System.Windows.Forms.CheckBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonGenerateMulti = new System.Windows.Forms.Button();
            this.linkLabelGenerateTrigger = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabPageEndPoint = new System.Windows.Forms.TabPage();
            this.radioButtonCustomBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonWsHttpBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonBasicHttpBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonNetTcpBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonNetNamedBinding = new System.Windows.Forms.RadioButton();
            this.buttonCreateStrings = new System.Windows.Forms.Button();
            this.buttonCleanCacheItemWeb = new System.Windows.Forms.Button();
            this.textBoxCacheItemWeb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCleanCacheItemServer = new System.Windows.Forms.Button();
            this.textBoxCacheItemServer = new System.Windows.Forms.TextBox();
            this.labelCacheItem = new System.Windows.Forms.Label();
            this.buttonCleanEndPoint = new System.Windows.Forms.Button();
            this.textBoxEndPoint = new System.Windows.Forms.TextBox();
            this.labelEndPoint = new System.Windows.Forms.Label();
            this.tabPageTDG = new System.Windows.Forms.TabPage();
            this.buttonGenerateTypeDataSet = new System.Windows.Forms.Button();
            this.textBoxAttributesNamespace = new System.Windows.Forms.TextBox();
            this.labelAttributesNamespace = new System.Windows.Forms.Label();
            this.textBoxDataSetSuffix = new System.Windows.Forms.TextBox();
            this.labelDataSetSuffix = new System.Windows.Forms.Label();
            this.tabPageECG = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBoxEnumSuffix = new System.Windows.Forms.TextBox();
            this.labelEnumSuffix = new System.Windows.Forms.Label();
            this.textBoxEnumPrefix = new System.Windows.Forms.TextBox();
            this.labelEnumPrefix = new System.Windows.Forms.Label();
            this.linkLabelLoadColumns = new System.Windows.Forms.LinkLabel();
            this.textBoxDbScript = new System.Windows.Forms.TextBox();
            this.checkBoxUseEnumNameWithoutChange = new System.Windows.Forms.CheckBox();
            this.checkBoxUseDbScript = new System.Windows.Forms.CheckBox();
            this.checkBoxAddUnderscoreBetweenWords = new System.Windows.Forms.CheckBox();
            this.checkBoxEnumWithDescription = new System.Windows.Forms.CheckBox();
            this.comboBoxDescription = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.checkBoxCreateOnlyConstants = new System.Windows.Forms.CheckBox();
            this.buttonGenerateEnumClass = new System.Windows.Forms.Button();
            this.groupBoxAyirac = new System.Windows.Forms.GroupBox();
            this.comboBoxTextField = new System.Windows.Forms.ComboBox();
            this.labelTextField = new System.Windows.Forms.Label();
            this.comboBoxValueField = new System.Windows.Forms.ComboBox();
            this.labelValueField = new System.Windows.Forms.Label();
            this.textBoxInheritanceClassNameForCC = new System.Windows.Forms.TextBox();
            this.labelInherit = new System.Windows.Forms.Label();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.buttonProjectPath = new System.Windows.Forms.Button();
            this.checkBoxAutoSetNamesapce = new System.Windows.Forms.CheckBox();
            this.buttonGetSchemas = new System.Windows.Forms.Button();
            this.checkBoxPkIsIdentity = new System.Windows.Forms.CheckBox();
            this.textBoxLookupPrefix = new System.Windows.Forms.TextBox();
            this.rdbOracle = new System.Windows.Forms.RadioButton();
            this.rdbMsSql = new System.Windows.Forms.RadioButton();
            this.linkLabelSetNmSpsClassNames = new System.Windows.Forms.LinkLabel();
            this.checkBoxSelectMultyTables = new System.Windows.Forms.CheckBox();
            this.buttonConnectToDb = new System.Windows.Forms.Button();
            this.buttonGetTables = new System.Windows.Forms.Button();
            this.buttonSaveConnStr = new System.Windows.Forms.Button();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
            this.textBoxInterfaceClassName = new System.Windows.Forms.TextBox();
            this.textBoxCrudClassName = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSetClassName = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCcSubPath2 = new System.Windows.Forms.TextBox();
            this.textBoxCcSubPath1 = new System.Windows.Forms.TextBox();
            this.labelBsSubPath = new System.Windows.Forms.Label();
            this.textBoxProjectPath = new System.Windows.Forms.TextBox();
            this.labelProjectPath = new System.Windows.Forms.Label();
            this.textBoxInterfaceSubPath1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxInterfaceSubPath2 = new System.Windows.Forms.TextBox();
            this.LabelInterfaceSubPath = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lnkLabelSaveOptions = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbrMultiProc = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButtonSkin = new System.Windows.Forms.ToolStripDropDownButton();
            this.blackSkinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardSkinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelConnectedDbName = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLookupPrefix = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabelHideShow = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTable = new System.Windows.Forms.TextBox();
            this.textBoxSchema = new System.Windows.Forms.TextBox();
            this.labelTable = new System.Windows.Forms.Label();
            this.labelSchema = new System.Windows.Forms.Label();
            this.textBoxConnStr = new System.Windows.Forms.TextBox();
            this.labelConnStr = new System.Windows.Forms.Label();
            this.panelPath = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTypeNamespace = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCrudClassNamespace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxInterfaceNamespace = new System.Windows.Forms.TextBox();
            this.labelSubpathT = new System.Windows.Forms.Label();
            this.labelSubpathCC = new System.Windows.Forms.Label();
            this.labelSubPathI = new System.Windows.Forms.Label();
            this.textBoxTypeSubPath2 = new System.Windows.Forms.TextBox();
            this.textBoxTypeSubPath1 = new System.Windows.Forms.TextBox();
            this.labelTypeSubPath = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBoxTypes = new System.Windows.Forms.GroupBox();
            this.groupBoxCrudClass = new System.Windows.Forms.GroupBox();
            this.groupBoxInterface = new System.Windows.Forms.GroupBox();
            this.groupBoxProjectPath = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelDb = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.pictureBoxConnectionOk = new System.Windows.Forms.PictureBox();
            this.pictureBoxNoConnection = new System.Windows.Forms.PictureBox();
            this.groupBoxTable = new System.Windows.Forms.GroupBox();
            this.groupBoxSchema = new System.Windows.Forms.GroupBox();
            this.groupBoxConStr = new System.Windows.Forms.GroupBox();
            this.groupBoxDbType = new System.Windows.Forms.GroupBox();
            this.timerReadConnStr = new System.Windows.Forms.Timer(this.components);
            this.panelTables = new System.Windows.Forms.Panel();
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.tabControlGeneration.SuspendLayout();
            this.tabPageCCG.SuspendLayout();
            this.groupBoxLogTable.SuspendLayout();
            this.groupBoxInheritPrmClassFrom.SuspendLayout();
            this.groupBoxPrm.SuspendLayout();
            this.groupBoxTemplate.SuspendLayout();
            this.groupBoxCRUD.SuspendLayout();
            this.tabPageEndPoint.SuspendLayout();
            this.tabPageTDG.SuspendLayout();
            this.tabPageECG.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.panelPath.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panelDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoConnection)).BeginInit();
            this.panelTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGeneration
            // 
            this.tabControlGeneration.Controls.Add(this.tabPageCCG);
            this.tabControlGeneration.Controls.Add(this.tabPageEndPoint);
            this.tabControlGeneration.Controls.Add(this.tabPageTDG);
            this.tabControlGeneration.Controls.Add(this.tabPageECG);
            this.tabControlGeneration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlGeneration.Location = new System.Drawing.Point(6, 419);
            this.tabControlGeneration.Multiline = true;
            this.tabControlGeneration.Name = "tabControlGeneration";
            this.tabControlGeneration.SelectedIndex = 0;
            this.tabControlGeneration.Size = new System.Drawing.Size(696, 255);
            this.tabControlGeneration.TabIndex = 56;
            // 
            // tabPageCCG
            // 
            this.tabPageCCG.BackColor = System.Drawing.Color.FloralWhite;
            this.tabPageCCG.Controls.Add(this.labelConnStrName);
            this.tabPageCCG.Controls.Add(this.textBoxConnectionStringName);
            this.tabPageCCG.Controls.Add(this.groupBoxLogTable);
            this.tabPageCCG.Controls.Add(this.groupBoxInheritPrmClassFrom);
            this.tabPageCCG.Controls.Add(this.groupBoxPrm);
            this.tabPageCCG.Controls.Add(this.groupBoxTemplate);
            this.tabPageCCG.Controls.Add(this.groupBoxCRUD);
            this.tabPageCCG.Controls.Add(this.buttonGenerate);
            this.tabPageCCG.Controls.Add(this.buttonGenerateMulti);
            this.tabPageCCG.Controls.Add(this.linkLabelGenerateTrigger);
            this.tabPageCCG.Controls.Add(this.groupBox2);
            this.tabPageCCG.ForeColor = System.Drawing.Color.Black;
            this.tabPageCCG.Location = new System.Drawing.Point(4, 22);
            this.tabPageCCG.Name = "tabPageCCG";
            this.tabPageCCG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCCG.Size = new System.Drawing.Size(688, 229);
            this.tabPageCCG.TabIndex = 4;
            this.tabPageCCG.Text = "Crud Class Settings";
            // 
            // labelConnStrName
            // 
            this.labelConnStrName.AutoSize = true;
            this.labelConnStrName.BackColor = System.Drawing.Color.Transparent;
            this.labelConnStrName.Location = new System.Drawing.Point(9, 190);
            this.labelConnStrName.Name = "labelConnStrName";
            this.labelConnStrName.Size = new System.Drawing.Size(122, 13);
            this.labelConnStrName.TabIndex = 137;
            this.labelConnStrName.Text = "Connection String Name";
            // 
            // textBoxConnectionStringName
            // 
            this.textBoxConnectionStringName.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxConnectionStringName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxConnectionStringName.ForeColor = System.Drawing.Color.Chocolate;
            this.textBoxConnectionStringName.Location = new System.Drawing.Point(134, 187);
            this.textBoxConnectionStringName.Name = "textBoxConnectionStringName";
            this.textBoxConnectionStringName.Size = new System.Drawing.Size(162, 20);
            this.textBoxConnectionStringName.TabIndex = 136;
            this.textBoxConnectionStringName.Text = "ConnStrSql";
            // 
            // groupBoxLogTable
            // 
            this.groupBoxLogTable.Controls.Add(this.labelLogTable);
            this.groupBoxLogTable.Controls.Add(this.textBoxFullTableNameForLog);
            this.groupBoxLogTable.Location = new System.Drawing.Point(302, 144);
            this.groupBoxLogTable.Name = "groupBoxLogTable";
            this.groupBoxLogTable.Size = new System.Drawing.Size(374, 27);
            this.groupBoxLogTable.TabIndex = 133;
            this.groupBoxLogTable.TabStop = false;
            // 
            // labelLogTable
            // 
            this.labelLogTable.AutoSize = true;
            this.labelLogTable.Location = new System.Drawing.Point(2, 10);
            this.labelLogTable.Name = "labelLogTable";
            this.labelLogTable.Size = new System.Drawing.Size(59, 13);
            this.labelLogTable.TabIndex = 125;
            this.labelLogTable.Text = "LOG Table";
            // 
            // textBoxFullTableNameForLog
            // 
            this.textBoxFullTableNameForLog.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxFullTableNameForLog.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxFullTableNameForLog.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFullTableNameForLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFullTableNameForLog.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxFullTableNameForLog.Location = new System.Drawing.Point(71, 7);
            this.textBoxFullTableNameForLog.Name = "textBoxFullTableNameForLog";
            this.textBoxFullTableNameForLog.Size = new System.Drawing.Size(302, 20);
            this.textBoxFullTableNameForLog.TabIndex = 37;
            this.toolTipMain.SetToolTip(this.textBoxFullTableNameForLog, "Varsayılan log tablosu yerine başka bir tablo kullanılacak ise, \\r\\nbu alana o ta" +
        "blonun tam adı \"VeritabanıAdı.ŞemaAdı.TabloAdı\" şeklinde yazılır.");
            // 
            // groupBoxInheritPrmClassFrom
            // 
            this.groupBoxInheritPrmClassFrom.Controls.Add(this.textBoxInheritanceClassNameForPrm);
            this.groupBoxInheritPrmClassFrom.Controls.Add(this.labelPrmInheritPrmClassFrom);
            this.groupBoxInheritPrmClassFrom.Location = new System.Drawing.Point(6, 144);
            this.groupBoxInheritPrmClassFrom.Name = "groupBoxInheritPrmClassFrom";
            this.groupBoxInheritPrmClassFrom.Size = new System.Drawing.Size(290, 27);
            this.groupBoxInheritPrmClassFrom.TabIndex = 132;
            this.groupBoxInheritPrmClassFrom.TabStop = false;
            // 
            // textBoxInheritanceClassNameForPrm
            // 
            this.textBoxInheritanceClassNameForPrm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxInheritanceClassNameForPrm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxInheritanceClassNameForPrm.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInheritanceClassNameForPrm.ForeColor = System.Drawing.Color.DarkMagenta;
            this.textBoxInheritanceClassNameForPrm.Location = new System.Drawing.Point(129, 7);
            this.textBoxInheritanceClassNameForPrm.Name = "textBoxInheritanceClassNameForPrm";
            this.textBoxInheritanceClassNameForPrm.Size = new System.Drawing.Size(161, 20);
            this.textBoxInheritanceClassNameForPrm.TabIndex = 38;
            this.toolTipMain.SetToolTip(this.textBoxInheritanceClassNameForPrm, "Parametre sınıfı başka bir sınıftan türetilecek ise, \\r\\ntüretileceği sınıfın adı" +
        " buraya yazılır.");
            // 
            // labelPrmInheritPrmClassFrom
            // 
            this.labelPrmInheritPrmClassFrom.AutoSize = true;
            this.labelPrmInheritPrmClassFrom.Location = new System.Drawing.Point(3, 10);
            this.labelPrmInheritPrmClassFrom.Name = "labelPrmInheritPrmClassFrom";
            this.labelPrmInheritPrmClassFrom.Size = new System.Drawing.Size(111, 13);
            this.labelPrmInheritPrmClassFrom.TabIndex = 127;
            this.labelPrmInheritPrmClassFrom.Text = "Inherit Prm Class From";
            // 
            // groupBoxPrm
            // 
            this.groupBoxPrm.Controls.Add(this.radioButtonUseCCPath);
            this.groupBoxPrm.Controls.Add(this.radioButtonUseInterfacePath);
            this.groupBoxPrm.Controls.Add(this.checkBoxPrmClassSeparate);
            this.groupBoxPrm.Controls.Add(this.checkBoxPrmClassInCCFile);
            this.groupBoxPrm.Controls.Add(this.checkBoxPrmClassInInterfaceFile);
            this.groupBoxPrm.Controls.Add(this.lblPrm);
            this.groupBoxPrm.Location = new System.Drawing.Point(6, 67);
            this.groupBoxPrm.Name = "groupBoxPrm";
            this.groupBoxPrm.Size = new System.Drawing.Size(671, 30);
            this.groupBoxPrm.TabIndex = 131;
            this.groupBoxPrm.TabStop = false;
            // 
            // radioButtonUseCCPath
            // 
            this.radioButtonUseCCPath.AutoSize = true;
            this.radioButtonUseCCPath.Location = new System.Drawing.Point(603, 9);
            this.radioButtonUseCCPath.Name = "radioButtonUseCCPath";
            this.radioButtonUseCCPath.Size = new System.Drawing.Size(64, 17);
            this.radioButtonUseCCPath.TabIndex = 122;
            this.radioButtonUseCCPath.Text = "CC Path";
            this.toolTipMain.SetToolTip(this.radioButtonUseCCPath, "Parametre sınıfını Crud Class dizinine yazmak için bu seçeneği işaretleyin.");
            this.radioButtonUseCCPath.UseVisualStyleBackColor = true;
            this.radioButtonUseCCPath.Visible = false;
            // 
            // radioButtonUseInterfacePath
            // 
            this.radioButtonUseInterfacePath.AutoSize = true;
            this.radioButtonUseInterfacePath.Checked = true;
            this.radioButtonUseInterfacePath.Location = new System.Drawing.Point(502, 9);
            this.radioButtonUseInterfacePath.Name = "radioButtonUseInterfacePath";
            this.radioButtonUseInterfacePath.Size = new System.Drawing.Size(92, 17);
            this.radioButtonUseInterfacePath.TabIndex = 121;
            this.radioButtonUseInterfacePath.TabStop = true;
            this.radioButtonUseInterfacePath.Text = "Interface Path";
            this.toolTipMain.SetToolTip(this.radioButtonUseInterfacePath, "Parametre sınıfını Interface dizinine yazmak için bu seçeneği işaretleyin.\r\n");
            this.radioButtonUseInterfacePath.UseVisualStyleBackColor = true;
            this.radioButtonUseInterfacePath.Visible = false;
            // 
            // checkBoxPrmClassSeparate
            // 
            this.checkBoxPrmClassSeparate.AutoSize = true;
            this.checkBoxPrmClassSeparate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPrmClassSeparate.Location = new System.Drawing.Point(370, 10);
            this.checkBoxPrmClassSeparate.Name = "checkBoxPrmClassSeparate";
            this.checkBoxPrmClassSeparate.Size = new System.Drawing.Size(130, 17);
            this.checkBoxPrmClassSeparate.TabIndex = 34;
            this.checkBoxPrmClassSeparate.Text = "As a Separate \'cs\' File";
            this.toolTipMain.SetToolTip(this.checkBoxPrmClassSeparate, "Parametre sınıfını, ayrı bir\r\n \'cs\' dosyasına yazmak için bu seçeneği işaretleyin" +
        ".");
            this.checkBoxPrmClassSeparate.UseVisualStyleBackColor = true;
            this.checkBoxPrmClassSeparate.CheckedChanged += new System.EventHandler(this.PrmClassTypeChanged);
            // 
            // checkBoxPrmClassInCCFile
            // 
            this.checkBoxPrmClassInCCFile.AutoSize = true;
            this.checkBoxPrmClassInCCFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPrmClassInCCFile.Location = new System.Drawing.Point(268, 10);
            this.checkBoxPrmClassInCCFile.Name = "checkBoxPrmClassInCCFile";
            this.checkBoxPrmClassInCCFile.Size = new System.Drawing.Size(85, 17);
            this.checkBoxPrmClassInCCFile.TabIndex = 33;
            this.checkBoxPrmClassInCCFile.Text = "in CC \'cs\' file";
            this.toolTipMain.SetToolTip(this.checkBoxPrmClassInCCFile, "Parametre sınıfını, Crud Class sınıfı ile aynı \'cs\' dosyasına yazmak için bu seçe" +
        "neği işaretleyin.");
            this.checkBoxPrmClassInCCFile.UseVisualStyleBackColor = true;
            this.checkBoxPrmClassInCCFile.CheckedChanged += new System.EventHandler(this.PrmClassTypeChanged);
            // 
            // checkBoxPrmClassInInterfaceFile
            // 
            this.checkBoxPrmClassInInterfaceFile.AutoSize = true;
            this.checkBoxPrmClassInInterfaceFile.Checked = true;
            this.checkBoxPrmClassInInterfaceFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrmClassInInterfaceFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPrmClassInInterfaceFile.Location = new System.Drawing.Point(118, 10);
            this.checkBoxPrmClassInInterfaceFile.Name = "checkBoxPrmClassInInterfaceFile";
            this.checkBoxPrmClassInInterfaceFile.Size = new System.Drawing.Size(113, 17);
            this.checkBoxPrmClassInInterfaceFile.TabIndex = 32;
            this.checkBoxPrmClassInInterfaceFile.Text = "in Interface \'cs\' file";
            this.toolTipMain.SetToolTip(this.checkBoxPrmClassInInterfaceFile, "Bu seçenek işaretlendiğinde parametre sınıfları, Interface sınıfı ile aynı dosyay" +
        "a yazılır.");
            this.checkBoxPrmClassInInterfaceFile.UseVisualStyleBackColor = true;
            this.checkBoxPrmClassInInterfaceFile.CheckedChanged += new System.EventHandler(this.PrmClassTypeChanged);
            // 
            // lblPrm
            // 
            this.lblPrm.AutoSize = true;
            this.lblPrm.ForeColor = System.Drawing.Color.Black;
            this.lblPrm.Location = new System.Drawing.Point(3, 11);
            this.lblPrm.Name = "lblPrm";
            this.lblPrm.Size = new System.Drawing.Size(102, 13);
            this.lblPrm.TabIndex = 120;
            this.lblPrm.Text = "Generate Parameter";
            // 
            // groupBoxTemplate
            // 
            this.groupBoxTemplate.Controls.Add(this.label3);
            this.groupBoxTemplate.Controls.Add(this.checkBoxTemplateInterface);
            this.groupBoxTemplate.Controls.Add(this.checkBoxTemplateCc);
            this.groupBoxTemplate.Location = new System.Drawing.Point(6, 105);
            this.groupBoxTemplate.Name = "groupBoxTemplate";
            this.groupBoxTemplate.Size = new System.Drawing.Size(671, 30);
            this.groupBoxTemplate.TabIndex = 130;
            this.groupBoxTemplate.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "Generate Template ";
            // 
            // checkBoxTemplateInterface
            // 
            this.checkBoxTemplateInterface.AutoSize = true;
            this.checkBoxTemplateInterface.Location = new System.Drawing.Point(268, 9);
            this.checkBoxTemplateInterface.Name = "checkBoxTemplateInterface";
            this.checkBoxTemplateInterface.Size = new System.Drawing.Size(96, 17);
            this.checkBoxTemplateInterface.TabIndex = 36;
            this.checkBoxTemplateInterface.Text = "Interface Class";
            this.toolTipMain.SetToolTip(this.checkBoxTemplateInterface, "Bu seçenek işaretlendiğinde, CC sınıfı, mevcut şablondan \"partial\" olarak ayrıca " +
        "üretilir.");
            this.checkBoxTemplateInterface.UseVisualStyleBackColor = true;
            this.checkBoxTemplateInterface.CheckedChanged += new System.EventHandler(this.checkBoxInterfaceTemplate_CheckedChanged);
            // 
            // checkBoxTemplateCc
            // 
            this.checkBoxTemplateCc.AutoSize = true;
            this.checkBoxTemplateCc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxTemplateCc.Location = new System.Drawing.Point(118, 10);
            this.checkBoxTemplateCc.Name = "checkBoxTemplateCc";
            this.checkBoxTemplateCc.Size = new System.Drawing.Size(68, 17);
            this.checkBoxTemplateCc.TabIndex = 35;
            this.checkBoxTemplateCc.Text = "CC Class";
            this.toolTipMain.SetToolTip(this.checkBoxTemplateCc, "Bu seçenek işaretlendiğinde, CC sınıfı, mevcut şablondan \"partial\" olarak ayrıca " +
        "üretilir.");
            this.checkBoxTemplateCc.UseVisualStyleBackColor = true;
            // 
            // groupBoxCRUD
            // 
            this.groupBoxCRUD.Controls.Add(this.checkBoxCreateOnlySelectAsClass);
            this.groupBoxCRUD.Controls.Add(this.label5);
            this.groupBoxCRUD.Controls.Add(this.label4);
            this.groupBoxCRUD.Controls.Add(this.checkBoxAddServiceContract);
            this.groupBoxCRUD.Controls.Add(this.checkBoxCreateOnlySelect);
            this.groupBoxCRUD.Controls.Add(this.labelCRUD);
            this.groupBoxCRUD.Controls.Add(this.checkBoxAddNoLock);
            this.groupBoxCRUD.Controls.Add(this.checkBoxTypedDs);
            this.groupBoxCRUD.Controls.Add(this.checkBoxCrudCC);
            this.groupBoxCRUD.Controls.Add(this.checkBoxCrudInterface);
            this.groupBoxCRUD.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCRUD.Name = "groupBoxCRUD";
            this.groupBoxCRUD.Size = new System.Drawing.Size(671, 53);
            this.groupBoxCRUD.TabIndex = 129;
            this.groupBoxCRUD.TabStop = false;
            // 
            // checkBoxCreateOnlySelectAsClass
            // 
            this.checkBoxCreateOnlySelectAsClass.AutoSize = true;
            this.checkBoxCreateOnlySelectAsClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCreateOnlySelectAsClass.Location = new System.Drawing.Point(501, 10);
            this.checkBoxCreateOnlySelectAsClass.Name = "checkBoxCreateOnlySelectAsClass";
            this.checkBoxCreateOnlySelectAsClass.Size = new System.Drawing.Size(167, 17);
            this.checkBoxCreateOnlySelectAsClass.TabIndex = 131;
            this.checkBoxCreateOnlySelectAsClass.Text = "Create Only SelectAsClassList";
            this.toolTipMain.SetToolTip(this.checkBoxCreateOnlySelectAsClass, resources.GetString("checkBoxCreateOnlySelectAsClass.ToolTip"));
            this.checkBoxCreateOnlySelectAsClass.UseVisualStyleBackColor = true;
            this.checkBoxCreateOnlySelectAsClass.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(212, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 130;
            this.label5.Text = "................";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(212, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "................";
            // 
            // checkBoxAddServiceContract
            // 
            this.checkBoxAddServiceContract.AutoSize = true;
            this.checkBoxAddServiceContract.Checked = true;
            this.checkBoxAddServiceContract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddServiceContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAddServiceContract.Location = new System.Drawing.Point(268, 33);
            this.checkBoxAddServiceContract.Name = "checkBoxAddServiceContract";
            this.checkBoxAddServiceContract.Size = new System.Drawing.Size(134, 17);
            this.checkBoxAddServiceContract.TabIndex = 31;
            this.checkBoxAddServiceContract.Text = "Add \"ServiceContract\"";
            this.toolTipMain.SetToolTip(this.checkBoxAddServiceContract, "Üretilen Interface üzerinde bir EndPoint oluşturmak ve böylece servis erişimi sağ" +
        "lamak için \"ServiceContract\" niteliği (attribute) eklenmelidir.");
            this.checkBoxAddServiceContract.UseVisualStyleBackColor = true;
            this.checkBoxAddServiceContract.CheckedChanged += new System.EventHandler(this.checkBoxAddServiceContract_CheckedChanged);
            // 
            // checkBoxCreateOnlySelect
            // 
            this.checkBoxCreateOnlySelect.AutoSize = true;
            this.checkBoxCreateOnlySelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCreateOnlySelect.Location = new System.Drawing.Point(370, 10);
            this.checkBoxCreateOnlySelect.Name = "checkBoxCreateOnlySelect";
            this.checkBoxCreateOnlySelect.Size = new System.Drawing.Size(125, 17);
            this.checkBoxCreateOnlySelect.TabIndex = 28;
            this.checkBoxCreateOnlySelect.Text = "Create Only SELECT";
            this.toolTipMain.SetToolTip(this.checkBoxCreateOnlySelect, "Crud sınıfı içinde sadece \"select\" metotları bulunacak ise, bu seçeneği işaretley" +
        "in. \\r\\nBu durumda; sınıf içinde, ekleme, güncelleme ve silme metotları bulunmay" +
        "acaktır.");
            this.checkBoxCreateOnlySelect.UseVisualStyleBackColor = true;
            this.checkBoxCreateOnlySelect.CheckedChanged += new System.EventHandler(this.checkBoxCreateOnlySelect_CheckedChanged);
            // 
            // labelCRUD
            // 
            this.labelCRUD.AutoSize = true;
            this.labelCRUD.ForeColor = System.Drawing.Color.Black;
            this.labelCRUD.Location = new System.Drawing.Point(3, 10);
            this.labelCRUD.Name = "labelCRUD";
            this.labelCRUD.Size = new System.Drawing.Size(85, 13);
            this.labelCRUD.TabIndex = 128;
            this.labelCRUD.Text = "Generate CRUD";
            // 
            // checkBoxAddNoLock
            // 
            this.checkBoxAddNoLock.AutoSize = true;
            this.checkBoxAddNoLock.Checked = true;
            this.checkBoxAddNoLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddNoLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAddNoLock.Location = new System.Drawing.Point(268, 10);
            this.checkBoxAddNoLock.Name = "checkBoxAddNoLock";
            this.checkBoxAddNoLock.Size = new System.Drawing.Size(96, 17);
            this.checkBoxAddNoLock.TabIndex = 27;
            this.checkBoxAddNoLock.Text = "Add \"NoLock\"";
            this.toolTipMain.SetToolTip(this.checkBoxAddNoLock, "Select cümlelerine \"WITH(NOLOCK)\" eklemek için bu seçeneği işaretleyin.");
            this.checkBoxAddNoLock.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypedDs
            // 
            this.checkBoxTypedDs.AutoSize = true;
            this.checkBoxTypedDs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxTypedDs.Location = new System.Drawing.Point(501, 30);
            this.checkBoxTypedDs.Name = "checkBoxTypedDs";
            this.checkBoxTypedDs.Size = new System.Drawing.Size(150, 17);
            this.checkBoxTypedDs.TabIndex = 29;
            this.checkBoxTypedDs.Text = "Add TypedDataSet Codes";
            this.toolTipMain.SetToolTip(this.checkBoxTypedDs, "Bu seçenek işaretlendiğinde, oluşturulan CRUD sınıfına \"SelectAsTypedDataSet\" ve " +
        "\\r\\nTypedDataset\'ler için \"InsertOrUpdate\" methodu eklenir.");
            this.checkBoxTypedDs.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrudCC
            // 
            this.checkBoxCrudCC.AutoSize = true;
            this.checkBoxCrudCC.Checked = true;
            this.checkBoxCrudCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrudCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCrudCC.Location = new System.Drawing.Point(118, 10);
            this.checkBoxCrudCC.Name = "checkBoxCrudCC";
            this.checkBoxCrudCC.Size = new System.Drawing.Size(68, 17);
            this.checkBoxCrudCC.TabIndex = 26;
            this.checkBoxCrudCC.Text = "CC Class";
            this.checkBoxCrudCC.UseVisualStyleBackColor = true;
            this.checkBoxCrudCC.CheckedChanged += new System.EventHandler(this.checkBoxCrud_CheckedChanged);
            // 
            // checkBoxCrudInterface
            // 
            this.checkBoxCrudInterface.AutoSize = true;
            this.checkBoxCrudInterface.Checked = true;
            this.checkBoxCrudInterface.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrudInterface.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCrudInterface.Location = new System.Drawing.Point(118, 33);
            this.checkBoxCrudInterface.Name = "checkBoxCrudInterface";
            this.checkBoxCrudInterface.Size = new System.Drawing.Size(96, 17);
            this.checkBoxCrudInterface.TabIndex = 30;
            this.checkBoxCrudInterface.Text = "Interface Class";
            this.checkBoxCrudInterface.UseVisualStyleBackColor = true;
            this.checkBoxCrudInterface.CheckedChanged += new System.EventHandler(this.checkBoxCrudInterface_CheckedChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerate.FlatAppearance.BorderColor = System.Drawing.Color.FloralWhite;
            this.buttonGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.NavajoWhite;
            this.buttonGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AntiqueWhite;
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerate.ForeColor = System.Drawing.Color.DarkOrange;
            this.buttonGenerate.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerate.Image")));
            this.buttonGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenerate.Location = new System.Drawing.Point(445, 182);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(230, 36);
            this.buttonGenerate.TabIndex = 39;
            this.buttonGenerate.Text = "Generate Selected Classes";
            this.buttonGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonGenerateMulti
            // 
            this.buttonGenerateMulti.BackColor = System.Drawing.Color.FloralWhite;
            this.buttonGenerateMulti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerateMulti.FlatAppearance.BorderColor = System.Drawing.Color.FloralWhite;
            this.buttonGenerateMulti.FlatAppearance.BorderSize = 2;
            this.buttonGenerateMulti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.NavajoWhite;
            this.buttonGenerateMulti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AntiqueWhite;
            this.buttonGenerateMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerateMulti.ForeColor = System.Drawing.Color.DarkOrange;
            this.buttonGenerateMulti.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateMulti.Image")));
            this.buttonGenerateMulti.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenerateMulti.Location = new System.Drawing.Point(445, 182);
            this.buttonGenerateMulti.Name = "buttonGenerateMulti";
            this.buttonGenerateMulti.Size = new System.Drawing.Size(230, 36);
            this.buttonGenerateMulti.TabIndex = 117;
            this.buttonGenerateMulti.Text = "Generate Selected Classes";
            this.buttonGenerateMulti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerateMulti.UseVisualStyleBackColor = false;
            this.buttonGenerateMulti.Visible = false;
            this.buttonGenerateMulti.Click += new System.EventHandler(this.buttonGenerateMulti_Click);
            // 
            // linkLabelGenerateTrigger
            // 
            this.linkLabelGenerateTrigger.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelGenerateTrigger.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabelGenerateTrigger.Location = new System.Drawing.Point(297, 197);
            this.linkLabelGenerateTrigger.Name = "linkLabelGenerateTrigger";
            this.linkLabelGenerateTrigger.Size = new System.Drawing.Size(162, 18);
            this.linkLabelGenerateTrigger.TabIndex = 40;
            this.linkLabelGenerateTrigger.TabStop = true;
            this.linkLabelGenerateTrigger.Text = "Generate Triggers For Logging";
            this.linkLabelGenerateTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipMain.SetToolTip(this.linkLabelGenerateTrigger, "Ekleme ve güncelleme işlemlerine ait log\'lamaları bir trigger aracılığı ile yapma" +
        "k isterseniz, \\r\\nBu butona tıklayarak gerekli trigger betik (script) dosyasını " +
        "üretebilirsiniz.");
            this.linkLabelGenerateTrigger.Visible = false;
            this.linkLabelGenerateTrigger.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGenerateTrigger_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(6, 181);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 27);
            this.groupBox2.TabIndex = 138;
            this.groupBox2.TabStop = false;
            // 
            // tabPageEndPoint
            // 
            this.tabPageEndPoint.BackColor = System.Drawing.Color.Transparent;
            this.tabPageEndPoint.Controls.Add(this.radioButtonCustomBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonWsHttpBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonBasicHttpBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonNetTcpBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonNetNamedBinding);
            this.tabPageEndPoint.Controls.Add(this.buttonCreateStrings);
            this.tabPageEndPoint.Controls.Add(this.buttonCleanCacheItemWeb);
            this.tabPageEndPoint.Controls.Add(this.textBoxCacheItemWeb);
            this.tabPageEndPoint.Controls.Add(this.label1);
            this.tabPageEndPoint.Controls.Add(this.buttonCleanCacheItemServer);
            this.tabPageEndPoint.Controls.Add(this.textBoxCacheItemServer);
            this.tabPageEndPoint.Controls.Add(this.labelCacheItem);
            this.tabPageEndPoint.Controls.Add(this.buttonCleanEndPoint);
            this.tabPageEndPoint.Controls.Add(this.textBoxEndPoint);
            this.tabPageEndPoint.Controls.Add(this.labelEndPoint);
            this.tabPageEndPoint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPageEndPoint.Location = new System.Drawing.Point(4, 22);
            this.tabPageEndPoint.Name = "tabPageEndPoint";
            this.tabPageEndPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEndPoint.Size = new System.Drawing.Size(688, 229);
            this.tabPageEndPoint.TabIndex = 0;
            this.tabPageEndPoint.Text = "End-Point & CacheItem Strings";
            this.tabPageEndPoint.UseVisualStyleBackColor = true;
            // 
            // radioButtonCustomBinding
            // 
            this.radioButtonCustomBinding.BackColor = System.Drawing.Color.Beige;
            this.radioButtonCustomBinding.Checked = true;
            this.radioButtonCustomBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonCustomBinding.Location = new System.Drawing.Point(14, 108);
            this.radioButtonCustomBinding.Name = "radioButtonCustomBinding";
            this.radioButtonCustomBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonCustomBinding.TabIndex = 45;
            this.radioButtonCustomBinding.TabStop = true;
            this.radioButtonCustomBinding.Text = "Custom Binding";
            this.radioButtonCustomBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonWsHttpBinding
            // 
            this.radioButtonWsHttpBinding.BackColor = System.Drawing.Color.Beige;
            this.radioButtonWsHttpBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonWsHttpBinding.Location = new System.Drawing.Point(14, 90);
            this.radioButtonWsHttpBinding.Name = "radioButtonWsHttpBinding";
            this.radioButtonWsHttpBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonWsHttpBinding.TabIndex = 44;
            this.radioButtonWsHttpBinding.Text = "ws http";
            this.radioButtonWsHttpBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonBasicHttpBinding
            // 
            this.radioButtonBasicHttpBinding.BackColor = System.Drawing.Color.Beige;
            this.radioButtonBasicHttpBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonBasicHttpBinding.Location = new System.Drawing.Point(14, 72);
            this.radioButtonBasicHttpBinding.Name = "radioButtonBasicHttpBinding";
            this.radioButtonBasicHttpBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonBasicHttpBinding.TabIndex = 43;
            this.radioButtonBasicHttpBinding.Text = "basic http";
            this.radioButtonBasicHttpBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonNetTcpBinding
            // 
            this.radioButtonNetTcpBinding.BackColor = System.Drawing.Color.Beige;
            this.radioButtonNetTcpBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonNetTcpBinding.Location = new System.Drawing.Point(14, 54);
            this.radioButtonNetTcpBinding.Name = "radioButtonNetTcpBinding";
            this.radioButtonNetTcpBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonNetTcpBinding.TabIndex = 42;
            this.radioButtonNetTcpBinding.Text = "netTcp";
            this.radioButtonNetTcpBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonNetNamedBinding
            // 
            this.radioButtonNetNamedBinding.BackColor = System.Drawing.Color.Beige;
            this.radioButtonNetNamedBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonNetNamedBinding.Location = new System.Drawing.Point(14, 36);
            this.radioButtonNetNamedBinding.Name = "radioButtonNetNamedBinding";
            this.radioButtonNetNamedBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonNetNamedBinding.TabIndex = 41;
            this.radioButtonNetNamedBinding.Text = "netNamedPipe";
            this.radioButtonNetNamedBinding.UseVisualStyleBackColor = false;
            // 
            // buttonCreateStrings
            // 
            this.buttonCreateStrings.BackColor = System.Drawing.Color.Peru;
            this.buttonCreateStrings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateStrings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCreateStrings.ForeColor = System.Drawing.Color.White;
            this.buttonCreateStrings.Location = new System.Drawing.Point(393, 190);
            this.buttonCreateStrings.Name = "buttonCreateStrings";
            this.buttonCreateStrings.Size = new System.Drawing.Size(239, 32);
            this.buttonCreateStrings.TabIndex = 52;
            this.buttonCreateStrings.Text = "Create EndPoint and Cache Items";
            this.toolTipMain.SetToolTip(this.buttonCreateStrings, "EndPoint\'leri ve Cache Item\'ları oluştur.");
            this.buttonCreateStrings.UseVisualStyleBackColor = false;
            this.buttonCreateStrings.Click += new System.EventHandler(this.buttonCreateStrings_Click);
            // 
            // buttonCleanCacheItemWeb
            // 
            this.buttonCleanCacheItemWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCleanCacheItemWeb.Image = ((System.Drawing.Image)(resources.GetObject("buttonCleanCacheItemWeb.Image")));
            this.buttonCleanCacheItemWeb.Location = new System.Drawing.Point(644, 158);
            this.buttonCleanCacheItemWeb.Name = "buttonCleanCacheItemWeb";
            this.buttonCleanCacheItemWeb.Size = new System.Drawing.Size(25, 20);
            this.buttonCleanCacheItemWeb.TabIndex = 51;
            this.toolTipMain.SetToolTip(this.buttonCleanCacheItemWeb, "Temizle");
            this.buttonCleanCacheItemWeb.UseVisualStyleBackColor = true;
            this.buttonCleanCacheItemWeb.Click += new System.EventHandler(this.buttonCleanCacheItemWeb_Click);
            // 
            // textBoxCacheItemWeb
            // 
            this.textBoxCacheItemWeb.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.textBoxCacheItemWeb.Location = new System.Drawing.Point(130, 159);
            this.textBoxCacheItemWeb.Name = "textBoxCacheItemWeb";
            this.textBoxCacheItemWeb.ReadOnly = true;
            this.textBoxCacheItemWeb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCacheItemWeb.Size = new System.Drawing.Size(502, 20);
            this.textBoxCacheItemWeb.TabIndex = 50;
            this.textBoxCacheItemWeb.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Cache Item (Web)";
            // 
            // buttonCleanCacheItemServer
            // 
            this.buttonCleanCacheItemServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCleanCacheItemServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonCleanCacheItemServer.Image")));
            this.buttonCleanCacheItemServer.Location = new System.Drawing.Point(644, 132);
            this.buttonCleanCacheItemServer.Name = "buttonCleanCacheItemServer";
            this.buttonCleanCacheItemServer.Size = new System.Drawing.Size(25, 20);
            this.buttonCleanCacheItemServer.TabIndex = 49;
            this.toolTipMain.SetToolTip(this.buttonCleanCacheItemServer, "Temizle");
            this.buttonCleanCacheItemServer.UseVisualStyleBackColor = true;
            this.buttonCleanCacheItemServer.Click += new System.EventHandler(this.buttonCleanCacheItemServer_Click);
            // 
            // textBoxCacheItemServer
            // 
            this.textBoxCacheItemServer.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.textBoxCacheItemServer.Location = new System.Drawing.Point(130, 133);
            this.textBoxCacheItemServer.Name = "textBoxCacheItemServer";
            this.textBoxCacheItemServer.ReadOnly = true;
            this.textBoxCacheItemServer.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxCacheItemServer.Size = new System.Drawing.Size(502, 20);
            this.textBoxCacheItemServer.TabIndex = 48;
            this.textBoxCacheItemServer.WordWrap = false;
            // 
            // labelCacheItem
            // 
            this.labelCacheItem.AutoSize = true;
            this.labelCacheItem.Location = new System.Drawing.Point(15, 137);
            this.labelCacheItem.Name = "labelCacheItem";
            this.labelCacheItem.Size = new System.Drawing.Size(101, 13);
            this.labelCacheItem.TabIndex = 100;
            this.labelCacheItem.Text = "Cache Item (Server)";
            // 
            // buttonCleanEndPoint
            // 
            this.buttonCleanEndPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCleanEndPoint.Image = ((System.Drawing.Image)(resources.GetObject("buttonCleanEndPoint.Image")));
            this.buttonCleanEndPoint.Location = new System.Drawing.Point(644, 6);
            this.buttonCleanEndPoint.Name = "buttonCleanEndPoint";
            this.buttonCleanEndPoint.Size = new System.Drawing.Size(25, 20);
            this.buttonCleanEndPoint.TabIndex = 47;
            this.toolTipMain.SetToolTip(this.buttonCleanEndPoint, "Temizle");
            this.buttonCleanEndPoint.UseVisualStyleBackColor = true;
            this.buttonCleanEndPoint.Click += new System.EventHandler(this.buttonCleanEndPoint_Click);
            // 
            // textBoxEndPoint
            // 
            this.textBoxEndPoint.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEndPoint.Location = new System.Drawing.Point(130, 6);
            this.textBoxEndPoint.Multiline = true;
            this.textBoxEndPoint.Name = "textBoxEndPoint";
            this.textBoxEndPoint.ReadOnly = true;
            this.textBoxEndPoint.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEndPoint.Size = new System.Drawing.Size(502, 121);
            this.textBoxEndPoint.TabIndex = 46;
            this.textBoxEndPoint.WordWrap = false;
            // 
            // labelEndPoint
            // 
            this.labelEndPoint.AutoSize = true;
            this.labelEndPoint.Location = new System.Drawing.Point(15, 10);
            this.labelEndPoint.Name = "labelEndPoint";
            this.labelEndPoint.Size = new System.Drawing.Size(53, 13);
            this.labelEndPoint.TabIndex = 97;
            this.labelEndPoint.Text = "End Point";
            // 
            // tabPageTDG
            // 
            this.tabPageTDG.Controls.Add(this.buttonGenerateTypeDataSet);
            this.tabPageTDG.Controls.Add(this.textBoxAttributesNamespace);
            this.tabPageTDG.Controls.Add(this.labelAttributesNamespace);
            this.tabPageTDG.Controls.Add(this.textBoxDataSetSuffix);
            this.tabPageTDG.Controls.Add(this.labelDataSetSuffix);
            this.tabPageTDG.Location = new System.Drawing.Point(4, 22);
            this.tabPageTDG.Name = "tabPageTDG";
            this.tabPageTDG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTDG.Size = new System.Drawing.Size(688, 229);
            this.tabPageTDG.TabIndex = 2;
            this.tabPageTDG.Text = "Typed Dataset Generation";
            this.tabPageTDG.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateTypeDataSet
            // 
            this.buttonGenerateTypeDataSet.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGenerateTypeDataSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerateTypeDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerateTypeDataSet.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateTypeDataSet.Location = new System.Drawing.Point(465, 190);
            this.buttonGenerateTypeDataSet.Name = "buttonGenerateTypeDataSet";
            this.buttonGenerateTypeDataSet.Size = new System.Drawing.Size(200, 32);
            this.buttonGenerateTypeDataSet.TabIndex = 55;
            this.buttonGenerateTypeDataSet.Text = "Generate Typed DataSets";
            this.buttonGenerateTypeDataSet.UseVisualStyleBackColor = false;
            this.buttonGenerateTypeDataSet.Click += new System.EventHandler(this.buttonGenerateTypeDataSet_Click);
            // 
            // textBoxAttributesNamespace
            // 
            this.textBoxAttributesNamespace.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBoxAttributesNamespace.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxAttributesNamespace.Location = new System.Drawing.Point(150, 44);
            this.textBoxAttributesNamespace.Name = "textBoxAttributesNamespace";
            this.textBoxAttributesNamespace.Size = new System.Drawing.Size(240, 20);
            this.textBoxAttributesNamespace.TabIndex = 54;
            this.textBoxAttributesNamespace.Text = "Types.Attributes";
            // 
            // labelAttributesNamespace
            // 
            this.labelAttributesNamespace.AutoSize = true;
            this.labelAttributesNamespace.Location = new System.Drawing.Point(6, 47);
            this.labelAttributesNamespace.Name = "labelAttributesNamespace";
            this.labelAttributesNamespace.Size = new System.Drawing.Size(111, 13);
            this.labelAttributesNamespace.TabIndex = 90;
            this.labelAttributesNamespace.Text = "Attributes Namespace";
            // 
            // textBoxDataSetSuffix
            // 
            this.textBoxDataSetSuffix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBoxDataSetSuffix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBoxDataSetSuffix.Location = new System.Drawing.Point(150, 18);
            this.textBoxDataSetSuffix.Name = "textBoxDataSetSuffix";
            this.textBoxDataSetSuffix.Size = new System.Drawing.Size(240, 20);
            this.textBoxDataSetSuffix.TabIndex = 53;
            this.textBoxDataSetSuffix.Text = "DataSet";
            // 
            // labelDataSetSuffix
            // 
            this.labelDataSetSuffix.AutoSize = true;
            this.labelDataSetSuffix.Location = new System.Drawing.Point(6, 21);
            this.labelDataSetSuffix.Name = "labelDataSetSuffix";
            this.labelDataSetSuffix.Size = new System.Drawing.Size(75, 13);
            this.labelDataSetSuffix.TabIndex = 88;
            this.labelDataSetSuffix.Text = "DataSet Suffix";
            // 
            // tabPageECG
            // 
            this.tabPageECG.BackColor = System.Drawing.Color.Azure;
            this.tabPageECG.Controls.Add(this.groupBox4);
            this.tabPageECG.Controls.Add(this.textBoxEnumSuffix);
            this.tabPageECG.Controls.Add(this.labelEnumSuffix);
            this.tabPageECG.Controls.Add(this.textBoxEnumPrefix);
            this.tabPageECG.Controls.Add(this.labelEnumPrefix);
            this.tabPageECG.Controls.Add(this.linkLabelLoadColumns);
            this.tabPageECG.Controls.Add(this.textBoxDbScript);
            this.tabPageECG.Controls.Add(this.checkBoxUseEnumNameWithoutChange);
            this.tabPageECG.Controls.Add(this.checkBoxUseDbScript);
            this.tabPageECG.Controls.Add(this.checkBoxAddUnderscoreBetweenWords);
            this.tabPageECG.Controls.Add(this.checkBoxEnumWithDescription);
            this.tabPageECG.Controls.Add(this.comboBoxDescription);
            this.tabPageECG.Controls.Add(this.labelDescription);
            this.tabPageECG.Controls.Add(this.checkBoxCreateOnlyConstants);
            this.tabPageECG.Controls.Add(this.buttonGenerateEnumClass);
            this.tabPageECG.Controls.Add(this.groupBoxAyirac);
            this.tabPageECG.Controls.Add(this.comboBoxTextField);
            this.tabPageECG.Controls.Add(this.labelTextField);
            this.tabPageECG.Controls.Add(this.comboBoxValueField);
            this.tabPageECG.Controls.Add(this.labelValueField);
            this.tabPageECG.Location = new System.Drawing.Point(4, 22);
            this.tabPageECG.Name = "tabPageECG";
            this.tabPageECG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageECG.Size = new System.Drawing.Size(688, 229);
            this.tabPageECG.TabIndex = 3;
            this.tabPageECG.Text = "Enum Generation";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(436, 146);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(241, 3);
            this.groupBox4.TabIndex = 141;
            this.groupBox4.TabStop = false;
            // 
            // textBoxEnumSuffix
            // 
            this.textBoxEnumSuffix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxEnumSuffix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxEnumSuffix.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxEnumSuffix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEnumSuffix.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxEnumSuffix.Location = new System.Drawing.Point(599, 121);
            this.textBoxEnumSuffix.Name = "textBoxEnumSuffix";
            this.textBoxEnumSuffix.Size = new System.Drawing.Size(43, 20);
            this.textBoxEnumSuffix.TabIndex = 67;
            this.toolTipMain.SetToolTip(this.textBoxEnumSuffix, "Tanım tabloları için ön-ek kullanılacak ise (tavsiye edilir) buraya yazınız. \\r\\n" +
        "Önerilen Ön-Ek\'ler: TT_; LT_; PRM_");
            // 
            // labelEnumSuffix
            // 
            this.labelEnumSuffix.AutoSize = true;
            this.labelEnumSuffix.Location = new System.Drawing.Point(564, 124);
            this.labelEnumSuffix.Name = "labelEnumSuffix";
            this.labelEnumSuffix.Size = new System.Drawing.Size(33, 13);
            this.labelEnumSuffix.TabIndex = 140;
            this.labelEnumSuffix.Text = "Suffix";
            this.labelEnumSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEnumPrefix
            // 
            this.textBoxEnumPrefix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxEnumPrefix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxEnumPrefix.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxEnumPrefix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEnumPrefix.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textBoxEnumPrefix.Location = new System.Drawing.Point(515, 121);
            this.textBoxEnumPrefix.Name = "textBoxEnumPrefix";
            this.textBoxEnumPrefix.Size = new System.Drawing.Size(43, 20);
            this.textBoxEnumPrefix.TabIndex = 66;
            this.textBoxEnumPrefix.Text = "Enum";
            this.toolTipMain.SetToolTip(this.textBoxEnumPrefix, "Tanım tabloları için ön-ek kullanılacak ise (tavsiye edilir) buraya yazınız. \\r\\n" +
        "Önerilen Ön-Ek\'ler: TT_; LT_; PRM_");
            // 
            // labelEnumPrefix
            // 
            this.labelEnumPrefix.AutoSize = true;
            this.labelEnumPrefix.Location = new System.Drawing.Point(450, 125);
            this.labelEnumPrefix.Name = "labelEnumPrefix";
            this.labelEnumPrefix.Size = new System.Drawing.Size(63, 13);
            this.labelEnumPrefix.TabIndex = 138;
            this.labelEnumPrefix.Text = "Enum Prefix";
            this.labelEnumPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelLoadColumns
            // 
            this.linkLabelLoadColumns.AutoSize = true;
            this.linkLabelLoadColumns.Location = new System.Drawing.Point(112, 19);
            this.linkLabelLoadColumns.Name = "linkLabelLoadColumns";
            this.linkLabelLoadColumns.Size = new System.Drawing.Size(31, 13);
            this.linkLabelLoadColumns.TabIndex = 56;
            this.linkLabelLoadColumns.TabStop = true;
            this.linkLabelLoadColumns.Text = "Load";
            this.toolTipMain.SetToolTip(this.linkLabelLoadColumns, resources.GetString("linkLabelLoadColumns.ToolTip"));
            this.linkLabelLoadColumns.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLoadColumns_LinkClicked);
            // 
            // textBoxDbScript
            // 
            this.textBoxDbScript.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxDbScript.Location = new System.Drawing.Point(6, 146);
            this.textBoxDbScript.Multiline = true;
            this.textBoxDbScript.Name = "textBoxDbScript";
            this.textBoxDbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDbScript.Size = new System.Drawing.Size(416, 78);
            this.textBoxDbScript.TabIndex = 65;
            this.textBoxDbScript.Visible = false;
            // 
            // checkBoxUseEnumNameWithoutChange
            // 
            this.checkBoxUseEnumNameWithoutChange.AutoSize = true;
            this.checkBoxUseEnumNameWithoutChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUseEnumNameWithoutChange.ForeColor = System.Drawing.Color.Teal;
            this.checkBoxUseEnumNameWithoutChange.Location = new System.Drawing.Point(441, 57);
            this.checkBoxUseEnumNameWithoutChange.Name = "checkBoxUseEnumNameWithoutChange";
            this.checkBoxUseEnumNameWithoutChange.Size = new System.Drawing.Size(207, 17);
            this.checkBoxUseEnumNameWithoutChange.TabIndex = 62;
            this.checkBoxUseEnumNameWithoutChange.Text = "Use Enum Name Without Any Change";
            this.toolTipMain.SetToolTip(this.checkBoxUseEnumNameWithoutChange, "If checked, Enum Name is used without any change (same as database)");
            this.checkBoxUseEnumNameWithoutChange.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseDbScript
            // 
            this.checkBoxUseDbScript.AutoSize = true;
            this.checkBoxUseDbScript.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxUseDbScript.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUseDbScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUseDbScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUseDbScript.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBoxUseDbScript.Location = new System.Drawing.Point(7, 124);
            this.checkBoxUseDbScript.Name = "checkBoxUseDbScript";
            this.checkBoxUseDbScript.Size = new System.Drawing.Size(159, 17);
            this.checkBoxUseDbScript.TabIndex = 64;
            this.checkBoxUseDbScript.Text = "Use Custom Database Script";
            this.toolTipMain.SetToolTip(this.checkBoxUseDbScript, "Check to generate enum class by using custom SQL script");
            this.checkBoxUseDbScript.UseVisualStyleBackColor = false;
            this.checkBoxUseDbScript.CheckedChanged += new System.EventHandler(this.checkBoxUseDbScript_CheckedChanged);
            // 
            // checkBoxAddUnderscoreBetweenWords
            // 
            this.checkBoxAddUnderscoreBetweenWords.AutoSize = true;
            this.checkBoxAddUnderscoreBetweenWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAddUnderscoreBetweenWords.ForeColor = System.Drawing.Color.Chocolate;
            this.checkBoxAddUnderscoreBetweenWords.Location = new System.Drawing.Point(441, 37);
            this.checkBoxAddUnderscoreBetweenWords.Name = "checkBoxAddUnderscoreBetweenWords";
            this.checkBoxAddUnderscoreBetweenWords.Size = new System.Drawing.Size(182, 17);
            this.checkBoxAddUnderscoreBetweenWords.TabIndex = 61;
            this.checkBoxAddUnderscoreBetweenWords.Text = "Add Underscore Between Words";
            this.toolTipMain.SetToolTip(this.checkBoxAddUnderscoreBetweenWords, "If checked, Enum Name word parts will be separated with \"_\" sign. exp: \"User_Type" +
        "\"\r\nIf not checked, Enum Name word parts will be joined. Exp: \"UserType\"");
            this.checkBoxAddUnderscoreBetweenWords.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnumWithDescription
            // 
            this.checkBoxEnumWithDescription.AutoSize = true;
            this.checkBoxEnumWithDescription.Checked = true;
            this.checkBoxEnumWithDescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnumWithDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxEnumWithDescription.ForeColor = System.Drawing.Color.Sienna;
            this.checkBoxEnumWithDescription.Location = new System.Drawing.Point(441, 17);
            this.checkBoxEnumWithDescription.Name = "checkBoxEnumWithDescription";
            this.checkBoxEnumWithDescription.Size = new System.Drawing.Size(168, 17);
            this.checkBoxEnumWithDescription.TabIndex = 60;
            this.checkBoxEnumWithDescription.Text = "Create Enum With Description";
            this.toolTipMain.SetToolTip(this.checkBoxEnumWithDescription, "If checked, enum items will be generated with description ettribute.");
            this.checkBoxEnumWithDescription.UseVisualStyleBackColor = true;
            // 
            // comboBoxDescription
            // 
            this.comboBoxDescription.BackColor = System.Drawing.Color.SeaShell;
            this.comboBoxDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDescription.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxDescription.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.comboBoxDescription.ForeColor = System.Drawing.Color.OrangeRed;
            this.comboBoxDescription.FormattingEnabled = true;
            this.comboBoxDescription.Location = new System.Drawing.Point(151, 71);
            this.comboBoxDescription.Name = "comboBoxDescription";
            this.comboBoxDescription.Size = new System.Drawing.Size(271, 22);
            this.comboBoxDescription.TabIndex = 59;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(10, 79);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(115, 13);
            this.labelDescription.TabIndex = 129;
            this.labelDescription.Text = "Enum Description Field";
            this.toolTipMain.SetToolTip(this.labelDescription, "Enum Description");
            // 
            // checkBoxCreateOnlyConstants
            // 
            this.checkBoxCreateOnlyConstants.AutoSize = true;
            this.checkBoxCreateOnlyConstants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCreateOnlyConstants.ForeColor = System.Drawing.Color.RoyalBlue;
            this.checkBoxCreateOnlyConstants.Location = new System.Drawing.Point(441, 77);
            this.checkBoxCreateOnlyConstants.Name = "checkBoxCreateOnlyConstants";
            this.checkBoxCreateOnlyConstants.Size = new System.Drawing.Size(131, 17);
            this.checkBoxCreateOnlyConstants.TabIndex = 63;
            this.checkBoxCreateOnlyConstants.Text = "Create Only Constants";
            this.toolTipMain.SetToolTip(this.checkBoxCreateOnlyConstants, "If checked, enum items will be generated as constant variables only");
            this.checkBoxCreateOnlyConstants.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateEnumClass
            // 
            this.buttonGenerateEnumClass.BackColor = System.Drawing.Color.Azure;
            this.buttonGenerateEnumClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerateEnumClass.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.buttonGenerateEnumClass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Turquoise;
            this.buttonGenerateEnumClass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonGenerateEnumClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateEnumClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerateEnumClass.ForeColor = System.Drawing.Color.Teal;
            this.buttonGenerateEnumClass.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateEnumClass.Image")));
            this.buttonGenerateEnumClass.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenerateEnumClass.Location = new System.Drawing.Point(446, 182);
            this.buttonGenerateEnumClass.Name = "buttonGenerateEnumClass";
            this.buttonGenerateEnumClass.Size = new System.Drawing.Size(230, 36);
            this.buttonGenerateEnumClass.TabIndex = 68;
            this.buttonGenerateEnumClass.Text = "Generate Enum Class";
            this.buttonGenerateEnumClass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerateEnumClass.UseVisualStyleBackColor = false;
            this.buttonGenerateEnumClass.Click += new System.EventHandler(this.buttonGenerateEnumClass_Click);
            // 
            // groupBoxAyirac
            // 
            this.groupBoxAyirac.Location = new System.Drawing.Point(7, 115);
            this.groupBoxAyirac.Name = "groupBoxAyirac";
            this.groupBoxAyirac.Size = new System.Drawing.Size(670, 3);
            this.groupBoxAyirac.TabIndex = 126;
            this.groupBoxAyirac.TabStop = false;
            // 
            // comboBoxTextField
            // 
            this.comboBoxTextField.BackColor = System.Drawing.Color.LemonChiffon;
            this.comboBoxTextField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxTextField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTextField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxTextField.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.comboBoxTextField.ForeColor = System.Drawing.Color.Olive;
            this.comboBoxTextField.FormattingEnabled = true;
            this.comboBoxTextField.Location = new System.Drawing.Point(150, 15);
            this.comboBoxTextField.Name = "comboBoxTextField";
            this.comboBoxTextField.Size = new System.Drawing.Size(271, 22);
            this.comboBoxTextField.TabIndex = 57;
            // 
            // labelTextField
            // 
            this.labelTextField.AutoSize = true;
            this.labelTextField.Location = new System.Drawing.Point(10, 19);
            this.labelTextField.Name = "labelTextField";
            this.labelTextField.Size = new System.Drawing.Size(90, 13);
            this.labelTextField.TabIndex = 124;
            this.labelTextField.Text = "Enum Name Field";
            this.toolTipMain.SetToolTip(this.labelTextField, "Enum or Constant Name");
            // 
            // comboBoxValueField
            // 
            this.comboBoxValueField.BackColor = System.Drawing.Color.LightCyan;
            this.comboBoxValueField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxValueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValueField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxValueField.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.comboBoxValueField.ForeColor = System.Drawing.Color.DarkCyan;
            this.comboBoxValueField.FormattingEnabled = true;
            this.comboBoxValueField.Location = new System.Drawing.Point(151, 43);
            this.comboBoxValueField.Name = "comboBoxValueField";
            this.comboBoxValueField.Size = new System.Drawing.Size(271, 22);
            this.comboBoxValueField.TabIndex = 58;
            // 
            // labelValueField
            // 
            this.labelValueField.AutoSize = true;
            this.labelValueField.Location = new System.Drawing.Point(10, 49);
            this.labelValueField.Name = "labelValueField";
            this.labelValueField.Size = new System.Drawing.Size(89, 13);
            this.labelValueField.TabIndex = 122;
            this.labelValueField.Text = "Enum Value Field";
            this.toolTipMain.SetToolTip(this.labelValueField, "Enum or Constant Value");
            // 
            // textBoxInheritanceClassNameForCC
            // 
            this.textBoxInheritanceClassNameForCC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxInheritanceClassNameForCC.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInheritanceClassNameForCC.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInheritanceClassNameForCC.ForeColor = System.Drawing.Color.DarkMagenta;
            this.textBoxInheritanceClassNameForCC.Location = new System.Drawing.Point(516, 204);
            this.textBoxInheritanceClassNameForCC.Name = "textBoxInheritanceClassNameForCC";
            this.textBoxInheritanceClassNameForCC.Size = new System.Drawing.Size(137, 20);
            this.textBoxInheritanceClassNameForCC.TabIndex = 22;
            this.textBoxInheritanceClassNameForCC.Text = "CCGDalBase";
            this.toolTipMain.SetToolTip(this.textBoxInheritanceClassNameForCC, "BS sınıfını başka bir sınıfdan türetmek istiyorsanız, \\r\\nburaya o sınıfın adını " +
        "yazınız.");
            // 
            // labelInherit
            // 
            this.labelInherit.AutoSize = true;
            this.labelInherit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelInherit.Location = new System.Drawing.Point(499, 205);
            this.labelInherit.Name = "labelInherit";
            this.labelInherit.Size = new System.Drawing.Size(13, 17);
            this.labelInherit.TabIndex = 117;
            this.labelInherit.Text = ":";
            this.toolTipMain.SetToolTip(this.labelInherit, "Inherit");
            // 
            // toolTipMain
            // 
            this.toolTipMain.AutoPopDelay = 20000;
            this.toolTipMain.InitialDelay = 500;
            this.toolTipMain.IsBalloon = true;
            this.toolTipMain.ReshowDelay = 100;
            this.toolTipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipMain.ToolTipTitle = "Information";
            // 
            // buttonProjectPath
            // 
            this.buttonProjectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProjectPath.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.buttonProjectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProjectPath.Image = ((System.Drawing.Image)(resources.GetObject("buttonProjectPath.Image")));
            this.buttonProjectPath.Location = new System.Drawing.Point(660, 15);
            this.buttonProjectPath.Name = "buttonProjectPath";
            this.buttonProjectPath.Size = new System.Drawing.Size(25, 20);
            this.buttonProjectPath.TabIndex = 13;
            this.toolTipMain.SetToolTip(this.buttonProjectPath, "Proje dizini seç.");
            this.buttonProjectPath.UseVisualStyleBackColor = true;
            this.buttonProjectPath.Click += new System.EventHandler(this.buttonTargetPath_Click);
            // 
            // checkBoxAutoSetNamesapce
            // 
            this.checkBoxAutoSetNamesapce.AutoSize = true;
            this.checkBoxAutoSetNamesapce.BackColor = System.Drawing.Color.White;
            this.checkBoxAutoSetNamesapce.Checked = true;
            this.checkBoxAutoSetNamesapce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoSetNamesapce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAutoSetNamesapce.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxAutoSetNamesapce.Location = new System.Drawing.Point(669, 104);
            this.checkBoxAutoSetNamesapce.Name = "checkBoxAutoSetNamesapce";
            this.checkBoxAutoSetNamesapce.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAutoSetNamesapce.TabIndex = 24;
            this.toolTipMain.SetToolTip(this.checkBoxAutoSetNamesapce, "Bu seçenek işaretlendiğinde, verilen \"namespace\" adı olduğu gibi kullanılır.\r\nBu " +
        "seçenek işaretli olmadığında \"namespace\" otomatik olarak oluşturulur.");
            this.checkBoxAutoSetNamesapce.UseVisualStyleBackColor = false;
            this.checkBoxAutoSetNamesapce.CheckedChanged += new System.EventHandler(this.checkBoxAutoSetNamesapce_CheckedChanged);
            // 
            // buttonGetSchemas
            // 
            this.buttonGetSchemas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGetSchemas.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.buttonGetSchemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetSchemas.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetSchemas.Image")));
            this.buttonGetSchemas.Location = new System.Drawing.Point(660, 65);
            this.buttonGetSchemas.Name = "buttonGetSchemas";
            this.buttonGetSchemas.Size = new System.Drawing.Size(25, 20);
            this.buttonGetSchemas.TabIndex = 10;
            this.toolTipMain.SetToolTip(this.buttonGetSchemas, "Bağlanılan veritabanında tanımlı tüm şemaları yükle.");
            this.buttonGetSchemas.UseVisualStyleBackColor = true;
            this.buttonGetSchemas.Click += new System.EventHandler(this.buttonGetSchemas_Click);
            // 
            // checkBoxPkIsIdentity
            // 
            this.checkBoxPkIsIdentity.AutoSize = true;
            this.checkBoxPkIsIdentity.BackColor = System.Drawing.Color.LightCyan;
            this.checkBoxPkIsIdentity.Checked = true;
            this.checkBoxPkIsIdentity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPkIsIdentity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxPkIsIdentity.Location = new System.Drawing.Point(277, 12);
            this.checkBoxPkIsIdentity.Name = "checkBoxPkIsIdentity";
            this.checkBoxPkIsIdentity.Size = new System.Drawing.Size(85, 17);
            this.checkBoxPkIsIdentity.TabIndex = 2;
            this.checkBoxPkIsIdentity.Text = "PK is Identity";
            this.toolTipMain.SetToolTip(this.checkBoxPkIsIdentity, "Birincil anahtar (PK (Primary Key)), \"Identity\" olarak belirlenmiş ise bu seçeneğ" +
        "i işaretleyin.");
            this.checkBoxPkIsIdentity.UseVisualStyleBackColor = false;
            this.checkBoxPkIsIdentity.Visible = false;
            // 
            // textBoxLookupPrefix
            // 
            this.textBoxLookupPrefix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxLookupPrefix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxLookupPrefix.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxLookupPrefix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxLookupPrefix.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBoxLookupPrefix.Location = new System.Drawing.Point(610, 232);
            this.textBoxLookupPrefix.Name = "textBoxLookupPrefix";
            this.textBoxLookupPrefix.Size = new System.Drawing.Size(43, 20);
            this.textBoxLookupPrefix.TabIndex = 25;
            this.textBoxLookupPrefix.Text = "TT_";
            this.toolTipMain.SetToolTip(this.textBoxLookupPrefix, resources.GetString("textBoxLookupPrefix.ToolTip"));
            // 
            // rdbOracle
            // 
            this.rdbOracle.AutoSize = true;
            this.rdbOracle.BackColor = System.Drawing.Color.LightCyan;
            this.rdbOracle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbOracle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbOracle.Location = new System.Drawing.Point(210, 12);
            this.rdbOracle.Name = "rdbOracle";
            this.rdbOracle.Size = new System.Drawing.Size(67, 17);
            this.rdbOracle.TabIndex = 1;
            this.rdbOracle.Text = "ORACLE";
            this.toolTipMain.SetToolTip(this.rdbOracle, "Veritabanı tipini ORACLE yapmak için bu seçeneği işaretleyiniz.");
            this.rdbOracle.UseVisualStyleBackColor = false;
            this.rdbOracle.CheckedChanged += new System.EventHandler(this.rdbOracle_CheckedChanged);
            // 
            // rdbMsSql
            // 
            this.rdbMsSql.AutoSize = true;
            this.rdbMsSql.BackColor = System.Drawing.Color.AntiqueWhite;
            this.rdbMsSql.Checked = true;
            this.rdbMsSql.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbMsSql.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbMsSql.ForeColor = System.Drawing.Color.Black;
            this.rdbMsSql.Location = new System.Drawing.Point(136, 12);
            this.rdbMsSql.Name = "rdbMsSql";
            this.rdbMsSql.Size = new System.Drawing.Size(64, 17);
            this.rdbMsSql.TabIndex = 0;
            this.rdbMsSql.TabStop = true;
            this.rdbMsSql.Text = "MS SQL";
            this.toolTipMain.SetToolTip(this.rdbMsSql, "Veritabanı tipini MS_SQL yapmak için bu seçeneği işaretleyiniz.");
            this.rdbMsSql.UseVisualStyleBackColor = false;
            this.rdbMsSql.CheckedChanged += new System.EventHandler(this.rdbMsSql_CheckedChanged);
            // 
            // linkLabelSetNmSpsClassNames
            // 
            this.linkLabelSetNmSpsClassNames.AutoSize = true;
            this.linkLabelSetNmSpsClassNames.Location = new System.Drawing.Point(136, 235);
            this.linkLabelSetNmSpsClassNames.Name = "linkLabelSetNmSpsClassNames";
            this.linkLabelSetNmSpsClassNames.Size = new System.Drawing.Size(37, 13);
            this.linkLabelSetNmSpsClassNames.TabIndex = 23;
            this.linkLabelSetNmSpsClassNames.TabStop = true;
            this.linkLabelSetNmSpsClassNames.Text = "ReSet";
            this.toolTipMain.SetToolTip(this.linkLabelSetNmSpsClassNames, resources.GetString("linkLabelSetNmSpsClassNames.ToolTip"));
            this.linkLabelSetNmSpsClassNames.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSetNmSpsClassNames_LinkClicked);
            // 
            // checkBoxSelectMultyTables
            // 
            this.checkBoxSelectMultyTables.AutoSize = true;
            this.checkBoxSelectMultyTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSelectMultyTables.Location = new System.Drawing.Point(525, 94);
            this.checkBoxSelectMultyTables.Name = "checkBoxSelectMultyTables";
            this.checkBoxSelectMultyTables.Size = new System.Drawing.Size(95, 17);
            this.checkBoxSelectMultyTables.TabIndex = 8;
            this.checkBoxSelectMultyTables.Text = "Multi Selection";
            this.toolTipMain.SetToolTip(this.checkBoxSelectMultyTables, "Aynı anda birden fazla tabloya ait sınıf üretmek için bu seçeneği işaretleyin ve " +
        "açılan listeden tabloları seçin.");
            this.checkBoxSelectMultyTables.UseVisualStyleBackColor = true;
            this.checkBoxSelectMultyTables.CheckedChanged += new System.EventHandler(this.checkBoxSelectMultyTables_CheckedChanged);
            // 
            // buttonConnectToDb
            // 
            this.buttonConnectToDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConnectToDb.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.buttonConnectToDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnectToDb.Image = ((System.Drawing.Image)(resources.GetObject("buttonConnectToDb.Image")));
            this.buttonConnectToDb.Location = new System.Drawing.Point(660, 7);
            this.buttonConnectToDb.Name = "buttonConnectToDb";
            this.buttonConnectToDb.Size = new System.Drawing.Size(24, 24);
            this.buttonConnectToDb.TabIndex = 4;
            this.toolTipMain.SetToolTip(this.buttonConnectToDb, "Veritabanına bağlan ve Şemaları yükle.");
            this.buttonConnectToDb.UseVisualStyleBackColor = true;
            this.buttonConnectToDb.Click += new System.EventHandler(this.buttonConnectToDb_Click);
            // 
            // buttonGetTables
            // 
            this.buttonGetTables.BackColor = System.Drawing.Color.Transparent;
            this.buttonGetTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGetTables.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.buttonGetTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetTables.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetTables.Image")));
            this.buttonGetTables.Location = new System.Drawing.Point(660, 91);
            this.buttonGetTables.Name = "buttonGetTables";
            this.buttonGetTables.Size = new System.Drawing.Size(25, 20);
            this.buttonGetTables.TabIndex = 11;
            this.toolTipMain.SetToolTip(this.buttonGetTables, "Seçilen şema altındaki tüm tabloları yükle.");
            this.buttonGetTables.UseVisualStyleBackColor = false;
            this.buttonGetTables.Click += new System.EventHandler(this.buttonGetTables_Click);
            // 
            // buttonSaveConnStr
            // 
            this.buttonSaveConnStr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveConnStr.FlatAppearance.BorderColor = System.Drawing.Color.AliceBlue;
            this.buttonSaveConnStr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveConnStr.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveConnStr.Image")));
            this.buttonSaveConnStr.Location = new System.Drawing.Point(660, 35);
            this.buttonSaveConnStr.Name = "buttonSaveConnStr";
            this.buttonSaveConnStr.Size = new System.Drawing.Size(24, 24);
            this.buttonSaveConnStr.TabIndex = 5;
            this.toolTipMain.SetToolTip(this.buttonSaveConnStr, "Veritabanına bağlan ve Şemaları yükle.");
            this.buttonSaveConnStr.UseVisualStyleBackColor = true;
            this.buttonSaveConnStr.Click += new System.EventHandler(this.buttonSaveConnStr_Click);
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxClassName.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.textBoxClassName.Location = new System.Drawing.Point(136, 204);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(120, 20);
            this.textBoxClassName.TabIndex = 19;
            this.toolTipMain.SetToolTip(this.textBoxClassName, "Parameter Class Name");
            this.textBoxClassName.TextChanged += new System.EventHandler(this.textBoxClassName_TextChanged);
            // 
            // textBoxInterfaceClassName
            // 
            this.textBoxInterfaceClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxInterfaceClassName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxInterfaceClassName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInterfaceClassName.ForeColor = System.Drawing.Color.Teal;
            this.textBoxInterfaceClassName.Location = new System.Drawing.Point(255, 204);
            this.textBoxInterfaceClassName.Name = "textBoxInterfaceClassName";
            this.textBoxInterfaceClassName.ReadOnly = true;
            this.textBoxInterfaceClassName.Size = new System.Drawing.Size(120, 20);
            this.textBoxInterfaceClassName.TabIndex = 20;
            this.toolTipMain.SetToolTip(this.textBoxInterfaceClassName, "Interface Class Name");
            // 
            // textBoxCrudClassName
            // 
            this.textBoxCrudClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxCrudClassName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCrudClassName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCrudClassName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textBoxCrudClassName.Location = new System.Drawing.Point(374, 204);
            this.textBoxCrudClassName.Name = "textBoxCrudClassName";
            this.textBoxCrudClassName.ReadOnly = true;
            this.textBoxCrudClassName.Size = new System.Drawing.Size(120, 20);
            this.textBoxCrudClassName.TabIndex = 21;
            this.toolTipMain.SetToolTip(this.textBoxCrudClassName, "Crud Class Name");
            // 
            // checkBoxAutoSetClassName
            // 
            this.checkBoxAutoSetClassName.AutoSize = true;
            this.checkBoxAutoSetClassName.BackColor = System.Drawing.Color.White;
            this.checkBoxAutoSetClassName.Checked = true;
            this.checkBoxAutoSetClassName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoSetClassName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAutoSetClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxAutoSetClassName.Location = new System.Drawing.Point(119, 207);
            this.checkBoxAutoSetClassName.Name = "checkBoxAutoSetClassName";
            this.checkBoxAutoSetClassName.Size = new System.Drawing.Size(15, 14);
            this.checkBoxAutoSetClassName.TabIndex = 136;
            this.toolTipMain.SetToolTip(this.checkBoxAutoSetClassName, "Bu seçenek işaretlendiğinde, verilen \"namespace\" adı olduğu gibi kullanılır.\r\nBu " +
        "seçenek işaretli olmadığında \"namespace\" otomatik olarak oluşturulur.");
            this.checkBoxAutoSetClassName.UseVisualStyleBackColor = false;
            this.checkBoxAutoSetClassName.CheckedChanged += new System.EventHandler(this.checkBoxAutoSetClassName_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Class Names";
            // 
            // textBoxCcSubPath2
            // 
            this.textBoxCcSubPath2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCcSubPath2.Location = new System.Drawing.Point(516, 101);
            this.textBoxCcSubPath2.Name = "textBoxCcSubPath2";
            this.textBoxCcSubPath2.ReadOnly = true;
            this.textBoxCcSubPath2.Size = new System.Drawing.Size(137, 20);
            this.textBoxCcSubPath2.TabIndex = 16;
            this.textBoxCcSubPath2.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // textBoxCcSubPath1
            // 
            this.textBoxCcSubPath1.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxCcSubPath1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCcSubPath1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCcSubPath1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.textBoxCcSubPath1.Location = new System.Drawing.Point(136, 101);
            this.textBoxCcSubPath1.Name = "textBoxCcSubPath1";
            this.textBoxCcSubPath1.Size = new System.Drawing.Size(382, 20);
            this.textBoxCcSubPath1.TabIndex = 15;
            this.textBoxCcSubPath1.Text = "DAL\\CCGObjects";
            this.textBoxCcSubPath1.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // labelBsSubPath
            // 
            this.labelBsSubPath.AutoSize = true;
            this.labelBsSubPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBsSubPath.Location = new System.Drawing.Point(3, 104);
            this.labelBsSubPath.Name = "labelBsSubPath";
            this.labelBsSubPath.Size = new System.Drawing.Size(67, 13);
            this.labelBsSubPath.TabIndex = 88;
            this.labelBsSubPath.Text = "Crud Class";
            // 
            // textBoxProjectPath
            // 
            this.textBoxProjectPath.BackColor = System.Drawing.Color.White;
            this.textBoxProjectPath.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxProjectPath.ForeColor = System.Drawing.Color.Maroon;
            this.textBoxProjectPath.Location = new System.Drawing.Point(136, 15);
            this.textBoxProjectPath.Name = "textBoxProjectPath";
            this.textBoxProjectPath.Size = new System.Drawing.Size(517, 20);
            this.textBoxProjectPath.TabIndex = 12;
            this.textBoxProjectPath.Text = "C:\\dotNetProjects\\ProjectFolder";
            // 
            // labelProjectPath
            // 
            this.labelProjectPath.AutoSize = true;
            this.labelProjectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProjectPath.ForeColor = System.Drawing.Color.Maroon;
            this.labelProjectPath.Location = new System.Drawing.Point(3, 18);
            this.labelProjectPath.Name = "labelProjectPath";
            this.labelProjectPath.Size = new System.Drawing.Size(77, 13);
            this.labelProjectPath.TabIndex = 86;
            this.labelProjectPath.Text = "Project Path";
            // 
            // textBoxInterfaceSubPath1
            // 
            this.textBoxInterfaceSubPath1.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxInterfaceSubPath1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxInterfaceSubPath1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInterfaceSubPath1.ForeColor = System.Drawing.Color.Teal;
            this.textBoxInterfaceSubPath1.Location = new System.Drawing.Point(136, 50);
            this.textBoxInterfaceSubPath1.Name = "textBoxInterfaceSubPath1";
            this.textBoxInterfaceSubPath1.Size = new System.Drawing.Size(382, 20);
            this.textBoxInterfaceSubPath1.TabIndex = 13;
            this.textBoxInterfaceSubPath1.Text = "Interfaces\\CCGInterfaces";
            this.textBoxInterfaceSubPath1.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // textBoxInterfaceSubPath2
            // 
            this.textBoxInterfaceSubPath2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInterfaceSubPath2.Location = new System.Drawing.Point(516, 50);
            this.textBoxInterfaceSubPath2.Name = "textBoxInterfaceSubPath2";
            this.textBoxInterfaceSubPath2.ReadOnly = true;
            this.textBoxInterfaceSubPath2.Size = new System.Drawing.Size(137, 20);
            this.textBoxInterfaceSubPath2.TabIndex = 14;
            this.textBoxInterfaceSubPath2.TextChanged += new System.EventHandler(this.textBoxInterfaceNamespace_TextChanged);
            // 
            // LabelInterfaceSubPath
            // 
            this.LabelInterfaceSubPath.AutoSize = true;
            this.LabelInterfaceSubPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelInterfaceSubPath.Location = new System.Drawing.Point(3, 53);
            this.LabelInterfaceSubPath.Name = "LabelInterfaceSubPath";
            this.LabelInterfaceSubPath.Size = new System.Drawing.Size(58, 13);
            this.LabelInterfaceSubPath.TabIndex = 81;
            this.LabelInterfaceSubPath.Text = "Interface";
            // 
            // statusStripMain
            // 
            this.statusStripMain.AutoSize = false;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnkLabelSaveOptions,
            this.pbrMultiProc,
            this.toolStripDropDownButtonSkin,
            this.labelConnectionStatus,
            this.labelConnectedDbName});
            this.statusStripMain.Location = new System.Drawing.Point(0, 679);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(713, 26);
            this.statusStripMain.TabIndex = 121;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // lnkLabelSaveOptions
            // 
            this.lnkLabelSaveOptions.Image = ((System.Drawing.Image)(resources.GetObject("lnkLabelSaveOptions.Image")));
            this.lnkLabelSaveOptions.IsLink = true;
            this.lnkLabelSaveOptions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLabelSaveOptions.Name = "lnkLabelSaveOptions";
            this.lnkLabelSaveOptions.Size = new System.Drawing.Size(92, 21);
            this.lnkLabelSaveOptions.Text = "Save Settings";
            this.lnkLabelSaveOptions.Click += new System.EventHandler(this.lnkLabelSaveOptions_Click);
            // 
            // pbrMultiProc
            // 
            this.pbrMultiProc.Name = "pbrMultiProc";
            this.pbrMultiProc.Size = new System.Drawing.Size(150, 20);
            this.pbrMultiProc.Step = 1;
            this.pbrMultiProc.Visible = false;
            // 
            // toolStripDropDownButtonSkin
            // 
            this.toolStripDropDownButtonSkin.BackColor = System.Drawing.Color.White;
            this.toolStripDropDownButtonSkin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackSkinToolStripMenuItem,
            this.standardSkinToolStripMenuItem});
            this.toolStripDropDownButtonSkin.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButtonSkin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSkin.Name = "toolStripDropDownButtonSkin";
            this.toolStripDropDownButtonSkin.Size = new System.Drawing.Size(42, 24);
            this.toolStripDropDownButtonSkin.Text = "Skin";
            // 
            // blackSkinToolStripMenuItem
            // 
            this.blackSkinToolStripMenuItem.Name = "blackSkinToolStripMenuItem";
            this.blackSkinToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.blackSkinToolStripMenuItem.Text = "Black Skin";
            this.blackSkinToolStripMenuItem.Click += new System.EventHandler(this.blackSkinToolStripMenuItem_Click);
            // 
            // standardSkinToolStripMenuItem
            // 
            this.standardSkinToolStripMenuItem.Checked = true;
            this.standardSkinToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.standardSkinToolStripMenuItem.Name = "standardSkinToolStripMenuItem";
            this.standardSkinToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.standardSkinToolStripMenuItem.Text = "Standard Skin";
            this.standardSkinToolStripMenuItem.Click += new System.EventHandler(this.standardSkinToolStripMenuItem_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelConnectionStatus.LinkColor = System.Drawing.Color.DodgerBlue;
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(508, 21);
            this.labelConnectionStatus.Spring = true;
            this.labelConnectionStatus.Text = "Connected To";
            this.labelConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelConnectedDbName
            // 
            this.labelConnectedDbName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.labelConnectedDbName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelConnectedDbName.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelConnectedDbName.Name = "labelConnectedDbName";
            this.labelConnectedDbName.Size = new System.Drawing.Size(56, 21);
            this.labelConnectedDbName.Text = "DbName";
            this.labelConnectedDbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLookupPrefix
            // 
            this.labelLookupPrefix.AutoSize = true;
            this.labelLookupPrefix.Location = new System.Drawing.Point(460, 235);
            this.labelLookupPrefix.Name = "labelLookupPrefix";
            this.labelLookupPrefix.Size = new System.Drawing.Size(149, 13);
            this.labelLookupPrefix.TabIndex = 125;
            this.labelLookupPrefix.Text = "Lookup Tables Schema Prefix";
            this.labelLookupPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "DB Type";
            // 
            // linkLabelHideShow
            // 
            this.linkLabelHideShow.AutoSize = true;
            this.linkLabelHideShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelHideShow.Location = new System.Drawing.Point(624, 95);
            this.linkLabelHideShow.Name = "linkLabelHideShow";
            this.linkLabelHideShow.Size = new System.Drawing.Size(29, 13);
            this.linkLabelHideShow.TabIndex = 9;
            this.linkLabelHideShow.TabStop = true;
            this.linkLabelHideShow.Text = "Hide";
            this.linkLabelHideShow.Visible = false;
            this.linkLabelHideShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHideShow_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(170, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Namespace && Class Names";
            // 
            // textBoxTable
            // 
            this.textBoxTable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxTable.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxTable.ForeColor = System.Drawing.Color.DodgerBlue;
            this.textBoxTable.Location = new System.Drawing.Point(136, 92);
            this.textBoxTable.Name = "textBoxTable";
            this.textBoxTable.Size = new System.Drawing.Size(382, 20);
            this.textBoxTable.TabIndex = 7;
            this.textBoxTable.TextChanged += new System.EventHandler(this.textBoxTable_TextChanged);
            this.textBoxTable.Enter += new System.EventHandler(this.textBoxTable_Enter);
            this.textBoxTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTable_KeyDown);
            this.textBoxTable.Leave += new System.EventHandler(this.textBoxTable_Leave);
            // 
            // textBoxSchema
            // 
            this.textBoxSchema.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSchema.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSchema.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSchema.ForeColor = System.Drawing.Color.MediumBlue;
            this.textBoxSchema.Location = new System.Drawing.Point(136, 65);
            this.textBoxSchema.Name = "textBoxSchema";
            this.textBoxSchema.Size = new System.Drawing.Size(517, 20);
            this.textBoxSchema.TabIndex = 6;
            this.textBoxSchema.TextChanged += new System.EventHandler(this.textBoxSchema_TextChanged);
            this.textBoxSchema.Enter += new System.EventHandler(this.textBoxSchema_Enter);
            this.textBoxSchema.Leave += new System.EventHandler(this.textBoxSchema_Leave);
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Location = new System.Drawing.Point(3, 95);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(34, 13);
            this.labelTable.TabIndex = 89;
            this.labelTable.Text = "Table";
            this.labelTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSchema
            // 
            this.labelSchema.AutoSize = true;
            this.labelSchema.Location = new System.Drawing.Point(3, 67);
            this.labelSchema.Name = "labelSchema";
            this.labelSchema.Size = new System.Drawing.Size(46, 13);
            this.labelSchema.TabIndex = 87;
            this.labelSchema.Text = "Schema";
            this.labelSchema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxConnStr
            // 
            this.textBoxConnStr.AutoCompleteCustomSource.AddRange(new string[] {
            "Data Source=10.0.36.38;Initial Catalog=ISKUR;Integrated Security=True",
            "Data Source=10.0.36.38;Initial Catalog=ISKUR;Persist Security Info=False;Password" +
                "=pw;User ID=uid;",
            "Data Source=TRK-DEV25\\DEV2008R2;Initial Catalog=CCG_TEST;Integrated Security=True" +
                "",
            "Data Source=TRK-DEV25\\DEV2008R2;Initial Catalog=CCG_TEST;Persist Security Info=Fa" +
                "lse;Password=pw;User ID=uid;",
            "Data Source=DATASOURCE;Password=password;User id=UserID;Pooling=true;Min Pool Siz" +
                "e=50;Max Pool Size=250"});
            this.textBoxConnStr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxConnStr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxConnStr.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxConnStr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.textBoxConnStr.ForeColor = System.Drawing.Color.SaddleBrown;
            this.textBoxConnStr.Location = new System.Drawing.Point(136, 38);
            this.textBoxConnStr.Name = "textBoxConnStr";
            this.textBoxConnStr.Size = new System.Drawing.Size(517, 20);
            this.textBoxConnStr.TabIndex = 3;
            // 
            // labelConnStr
            // 
            this.labelConnStr.AutoSize = true;
            this.labelConnStr.BackColor = System.Drawing.Color.Transparent;
            this.labelConnStr.Location = new System.Drawing.Point(3, 42);
            this.labelConnStr.Name = "labelConnStr";
            this.labelConnStr.Size = new System.Drawing.Size(91, 13);
            this.labelConnStr.TabIndex = 85;
            this.labelConnStr.Text = "Connection String";
            // 
            // panelPath
            // 
            this.panelPath.BackColor = System.Drawing.Color.Snow;
            this.panelPath.Controls.Add(this.label12);
            this.panelPath.Controls.Add(this.label11);
            this.panelPath.Controls.Add(this.label10);
            this.panelPath.Controls.Add(this.textBoxTypeNamespace);
            this.panelPath.Controls.Add(this.label9);
            this.panelPath.Controls.Add(this.textBoxCrudClassNamespace);
            this.panelPath.Controls.Add(this.label8);
            this.panelPath.Controls.Add(this.textBoxInterfaceNamespace);
            this.panelPath.Controls.Add(this.checkBoxAutoSetClassName);
            this.panelPath.Controls.Add(this.checkBoxAutoSetNamesapce);
            this.panelPath.Controls.Add(this.textBoxCrudClassName);
            this.panelPath.Controls.Add(this.textBoxInterfaceClassName);
            this.panelPath.Controls.Add(this.labelSubpathT);
            this.panelPath.Controls.Add(this.labelSubpathCC);
            this.panelPath.Controls.Add(this.labelSubPathI);
            this.panelPath.Controls.Add(this.textBoxTypeSubPath2);
            this.panelPath.Controls.Add(this.textBoxTypeSubPath1);
            this.panelPath.Controls.Add(this.labelTypeSubPath);
            this.panelPath.Controls.Add(this.LabelInterfaceSubPath);
            this.panelPath.Controls.Add(this.textBoxClassName);
            this.panelPath.Controls.Add(this.textBoxProjectPath);
            this.panelPath.Controls.Add(this.label2);
            this.panelPath.Controls.Add(this.buttonProjectPath);
            this.panelPath.Controls.Add(this.textBoxCcSubPath2);
            this.panelPath.Controls.Add(this.textBoxLookupPrefix);
            this.panelPath.Controls.Add(this.labelProjectPath);
            this.panelPath.Controls.Add(this.textBoxCcSubPath1);
            this.panelPath.Controls.Add(this.labelLookupPrefix);
            this.panelPath.Controls.Add(this.labelBsSubPath);
            this.panelPath.Controls.Add(this.textBoxInterfaceSubPath2);
            this.panelPath.Controls.Add(this.textBoxInterfaceSubPath1);
            this.panelPath.Controls.Add(this.linkLabelSetNmSpsClassNames);
            this.panelPath.Controls.Add(this.labelInherit);
            this.panelPath.Controls.Add(this.textBoxInheritanceClassNameForCC);
            this.panelPath.Controls.Add(this.label6);
            this.panelPath.Controls.Add(this.groupBox3);
            this.panelPath.Controls.Add(this.groupBoxTypes);
            this.panelPath.Controls.Add(this.groupBoxCrudClass);
            this.panelPath.Controls.Add(this.groupBoxInterface);
            this.panelPath.Controls.Add(this.groupBoxProjectPath);
            this.panelPath.Controls.Add(this.groupBox1);
            this.panelPath.Location = new System.Drawing.Point(9, 142);
            this.panelPath.Name = "panelPath";
            this.panelPath.Size = new System.Drawing.Size(693, 261);
            this.panelPath.TabIndex = 129;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(611, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 27);
            this.label12.TabIndex = 144;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(611, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 27);
            this.label11.TabIndex = 143;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(69, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 142;
            this.label10.Text = "Namespace";
            // 
            // textBoxTypeNamespace
            // 
            this.textBoxTypeNamespace.BackColor = System.Drawing.Color.White;
            this.textBoxTypeNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTypeNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.textBoxTypeNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxTypeNamespace.Location = new System.Drawing.Point(136, 174);
            this.textBoxTypeNamespace.Name = "textBoxTypeNamespace";
            this.textBoxTypeNamespace.ReadOnly = true;
            this.textBoxTypeNamespace.Size = new System.Drawing.Size(517, 12);
            this.textBoxTypeNamespace.TabIndex = 141;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(68, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 140;
            this.label9.Text = "Namespace";
            // 
            // textBoxCrudClassNamespace
            // 
            this.textBoxCrudClassNamespace.BackColor = System.Drawing.Color.White;
            this.textBoxCrudClassNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCrudClassNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.textBoxCrudClassNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxCrudClassNamespace.Location = new System.Drawing.Point(136, 122);
            this.textBoxCrudClassNamespace.Name = "textBoxCrudClassNamespace";
            this.textBoxCrudClassNamespace.ReadOnly = true;
            this.textBoxCrudClassNamespace.Size = new System.Drawing.Size(517, 12);
            this.textBoxCrudClassNamespace.TabIndex = 139;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(68, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 138;
            this.label8.Text = "Namespace";
            // 
            // textBoxInterfaceNamespace
            // 
            this.textBoxInterfaceNamespace.BackColor = System.Drawing.Color.White;
            this.textBoxInterfaceNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInterfaceNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.textBoxInterfaceNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxInterfaceNamespace.Location = new System.Drawing.Point(136, 71);
            this.textBoxInterfaceNamespace.Name = "textBoxInterfaceNamespace";
            this.textBoxInterfaceNamespace.ReadOnly = true;
            this.textBoxInterfaceNamespace.Size = new System.Drawing.Size(517, 12);
            this.textBoxInterfaceNamespace.TabIndex = 137;
            // 
            // labelSubpathT
            // 
            this.labelSubpathT.AutoSize = true;
            this.labelSubpathT.Location = new System.Drawing.Point(86, 156);
            this.labelSubpathT.Name = "labelSubpathT";
            this.labelSubpathT.Size = new System.Drawing.Size(47, 13);
            this.labelSubpathT.TabIndex = 132;
            this.labelSubpathT.Text = "Subpath";
            // 
            // labelSubpathCC
            // 
            this.labelSubpathCC.AutoSize = true;
            this.labelSubpathCC.Location = new System.Drawing.Point(86, 104);
            this.labelSubpathCC.Name = "labelSubpathCC";
            this.labelSubpathCC.Size = new System.Drawing.Size(47, 13);
            this.labelSubpathCC.TabIndex = 131;
            this.labelSubpathCC.Text = "Subpath";
            // 
            // labelSubPathI
            // 
            this.labelSubPathI.AutoSize = true;
            this.labelSubPathI.Location = new System.Drawing.Point(86, 53);
            this.labelSubPathI.Name = "labelSubPathI";
            this.labelSubPathI.Size = new System.Drawing.Size(47, 13);
            this.labelSubPathI.TabIndex = 130;
            this.labelSubPathI.Text = "Subpath";
            // 
            // textBoxTypeSubPath2
            // 
            this.textBoxTypeSubPath2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxTypeSubPath2.Location = new System.Drawing.Point(516, 153);
            this.textBoxTypeSubPath2.Name = "textBoxTypeSubPath2";
            this.textBoxTypeSubPath2.ReadOnly = true;
            this.textBoxTypeSubPath2.Size = new System.Drawing.Size(137, 20);
            this.textBoxTypeSubPath2.TabIndex = 18;
            this.textBoxTypeSubPath2.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // textBoxTypeSubPath1
            // 
            this.textBoxTypeSubPath1.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxTypeSubPath1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTypeSubPath1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxTypeSubPath1.ForeColor = System.Drawing.Color.ForestGreen;
            this.textBoxTypeSubPath1.Location = new System.Drawing.Point(136, 153);
            this.textBoxTypeSubPath1.Name = "textBoxTypeSubPath1";
            this.textBoxTypeSubPath1.Size = new System.Drawing.Size(382, 20);
            this.textBoxTypeSubPath1.TabIndex = 17;
            this.textBoxTypeSubPath1.Text = "Types\\DataSets|Enumerations";
            this.textBoxTypeSubPath1.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // labelTypeSubPath
            // 
            this.labelTypeSubPath.AutoSize = true;
            this.labelTypeSubPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTypeSubPath.Location = new System.Drawing.Point(3, 156);
            this.labelTypeSubPath.Name = "labelTypeSubPath";
            this.labelTypeSubPath.Size = new System.Drawing.Size(41, 13);
            this.labelTypeSubPath.TabIndex = 128;
            this.labelTypeSubPath.Text = "Types";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Location = new System.Drawing.Point(649, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(28, 115);
            this.groupBox3.TabIndex = 135;
            this.groupBox3.TabStop = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.ForeColor = System.Drawing.Color.Silver;
            this.label13.Location = new System.Drawing.Point(3, 46);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "__";
            // 
            // groupBoxTypes
            // 
            this.groupBoxTypes.Location = new System.Drawing.Point(2, 147);
            this.groupBoxTypes.Name = "groupBoxTypes";
            this.groupBoxTypes.Size = new System.Drawing.Size(236, 27);
            this.groupBoxTypes.TabIndex = 133;
            this.groupBoxTypes.TabStop = false;
            // 
            // groupBoxCrudClass
            // 
            this.groupBoxCrudClass.Location = new System.Drawing.Point(2, 95);
            this.groupBoxCrudClass.Name = "groupBoxCrudClass";
            this.groupBoxCrudClass.Size = new System.Drawing.Size(243, 27);
            this.groupBoxCrudClass.TabIndex = 146;
            this.groupBoxCrudClass.TabStop = false;
            // 
            // groupBoxInterface
            // 
            this.groupBoxInterface.Location = new System.Drawing.Point(2, 44);
            this.groupBoxInterface.Name = "groupBoxInterface";
            this.groupBoxInterface.Size = new System.Drawing.Size(243, 27);
            this.groupBoxInterface.TabIndex = 147;
            this.groupBoxInterface.TabStop = false;
            // 
            // groupBoxProjectPath
            // 
            this.groupBoxProjectPath.Location = new System.Drawing.Point(2, 9);
            this.groupBoxProjectPath.Name = "groupBoxProjectPath";
            this.groupBoxProjectPath.Size = new System.Drawing.Size(243, 27);
            this.groupBoxProjectPath.TabIndex = 148;
            this.groupBoxProjectPath.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(2, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 27);
            this.groupBox1.TabIndex = 149;
            this.groupBox1.TabStop = false;
            // 
            // panelDb
            // 
            this.panelDb.BackColor = System.Drawing.Color.AliceBlue;
            this.panelDb.Controls.Add(this.btnTest);
            this.panelDb.Controls.Add(this.buttonSaveConnStr);
            this.panelDb.Controls.Add(this.pictureBoxConnectionOk);
            this.panelDb.Controls.Add(this.pictureBoxNoConnection);
            this.panelDb.Controls.Add(this.buttonGetSchemas);
            this.panelDb.Controls.Add(this.labelConnStr);
            this.panelDb.Controls.Add(this.checkBoxPkIsIdentity);
            this.panelDb.Controls.Add(this.textBoxConnStr);
            this.panelDb.Controls.Add(this.labelSchema);
            this.panelDb.Controls.Add(this.labelTable);
            this.panelDb.Controls.Add(this.buttonGetTables);
            this.panelDb.Controls.Add(this.buttonConnectToDb);
            this.panelDb.Controls.Add(this.rdbOracle);
            this.panelDb.Controls.Add(this.textBoxSchema);
            this.panelDb.Controls.Add(this.rdbMsSql);
            this.panelDb.Controls.Add(this.textBoxTable);
            this.panelDb.Controls.Add(this.label7);
            this.panelDb.Controls.Add(this.checkBoxSelectMultyTables);
            this.panelDb.Controls.Add(this.linkLabelHideShow);
            this.panelDb.Controls.Add(this.groupBoxTable);
            this.panelDb.Controls.Add(this.groupBoxSchema);
            this.panelDb.Controls.Add(this.groupBoxConStr);
            this.panelDb.Controls.Add(this.groupBoxDbType);
            this.panelDb.Location = new System.Drawing.Point(9, 6);
            this.panelDb.Name = "panelDb";
            this.panelDb.Size = new System.Drawing.Size(693, 136);
            this.panelDb.TabIndex = 130;
            // 
            // btnTest
            // 
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.Location = new System.Drawing.Point(56, 99);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 133;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pictureBoxConnectionOk
            // 
            this.pictureBoxConnectionOk.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxConnectionOk.Image")));
            this.pictureBoxConnectionOk.InitialImage = null;
            this.pictureBoxConnectionOk.Location = new System.Drawing.Point(638, 11);
            this.pictureBoxConnectionOk.Name = "pictureBoxConnectionOk";
            this.pictureBoxConnectionOk.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxConnectionOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxConnectionOk.TabIndex = 131;
            this.pictureBoxConnectionOk.TabStop = false;
            this.pictureBoxConnectionOk.Visible = false;
            // 
            // pictureBoxNoConnection
            // 
            this.pictureBoxNoConnection.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNoConnection.Image")));
            this.pictureBoxNoConnection.InitialImage = null;
            this.pictureBoxNoConnection.Location = new System.Drawing.Point(638, 12);
            this.pictureBoxNoConnection.Name = "pictureBoxNoConnection";
            this.pictureBoxNoConnection.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNoConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxNoConnection.TabIndex = 130;
            this.pictureBoxNoConnection.TabStop = false;
            this.pictureBoxNoConnection.Visible = false;
            // 
            // groupBoxTable
            // 
            this.groupBoxTable.Location = new System.Drawing.Point(2, 86);
            this.groupBoxTable.Name = "groupBoxTable";
            this.groupBoxTable.Size = new System.Drawing.Size(243, 27);
            this.groupBoxTable.TabIndex = 146;
            this.groupBoxTable.TabStop = false;
            // 
            // groupBoxSchema
            // 
            this.groupBoxSchema.Location = new System.Drawing.Point(2, 59);
            this.groupBoxSchema.Name = "groupBoxSchema";
            this.groupBoxSchema.Size = new System.Drawing.Size(243, 27);
            this.groupBoxSchema.TabIndex = 147;
            this.groupBoxSchema.TabStop = false;
            // 
            // groupBoxConStr
            // 
            this.groupBoxConStr.Location = new System.Drawing.Point(2, 32);
            this.groupBoxConStr.Name = "groupBoxConStr";
            this.groupBoxConStr.Size = new System.Drawing.Size(243, 27);
            this.groupBoxConStr.TabIndex = 148;
            this.groupBoxConStr.TabStop = false;
            // 
            // groupBoxDbType
            // 
            this.groupBoxDbType.Location = new System.Drawing.Point(2, 4);
            this.groupBoxDbType.Name = "groupBoxDbType";
            this.groupBoxDbType.Size = new System.Drawing.Size(652, 27);
            this.groupBoxDbType.TabIndex = 149;
            this.groupBoxDbType.TabStop = false;
            // 
            // timerReadConnStr
            // 
            this.timerReadConnStr.Interval = 5000;
            // 
            // panelTables
            // 
            this.panelTables.BackColor = System.Drawing.Color.White;
            this.panelTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTables.Controls.Add(this.listBoxTables);
            this.panelTables.Location = new System.Drawing.Point(145, 138);
            this.panelTables.Name = "panelTables";
            this.panelTables.Size = new System.Drawing.Size(383, 23);
            this.panelTables.TabIndex = 135;
            this.panelTables.Visible = false;
            // 
            // listBoxTables
            // 
            this.listBoxTables.BackColor = System.Drawing.Color.White;
            this.listBoxTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.Location = new System.Drawing.Point(-2, 1);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTables.Size = new System.Drawing.Size(192, 82);
            this.listBoxTables.TabIndex = 131;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(713, 705);
            this.Controls.Add(this.panelTables);
            this.Controls.Add(this.panelPath);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.tabControlGeneration);
            this.Controls.Add(this.panelDb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crud Class Generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlGeneration.ResumeLayout(false);
            this.tabPageCCG.ResumeLayout(false);
            this.tabPageCCG.PerformLayout();
            this.groupBoxLogTable.ResumeLayout(false);
            this.groupBoxLogTable.PerformLayout();
            this.groupBoxInheritPrmClassFrom.ResumeLayout(false);
            this.groupBoxInheritPrmClassFrom.PerformLayout();
            this.groupBoxPrm.ResumeLayout(false);
            this.groupBoxPrm.PerformLayout();
            this.groupBoxTemplate.ResumeLayout(false);
            this.groupBoxTemplate.PerformLayout();
            this.groupBoxCRUD.ResumeLayout(false);
            this.groupBoxCRUD.PerformLayout();
            this.tabPageEndPoint.ResumeLayout(false);
            this.tabPageEndPoint.PerformLayout();
            this.tabPageTDG.ResumeLayout(false);
            this.tabPageTDG.PerformLayout();
            this.tabPageECG.ResumeLayout(false);
            this.tabPageECG.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.panelPath.ResumeLayout(false);
            this.panelPath.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panelDb.ResumeLayout(false);
            this.panelDb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoConnection)).EndInit();
            this.panelTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region InitializeComponent_Black

        private void InitializeComponent_Black()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tabControlGeneration = new System.Windows.Forms.TabControl();
            this.tabPageCCG = new System.Windows.Forms.TabPage();
            this.textBoxFullTableNameForLog = new System.Windows.Forms.TextBox();
            this.labelLogTable = new System.Windows.Forms.Label();
            this.textBoxInheritanceClassNameForPrm = new System.Windows.Forms.TextBox();
            this.textBoxConnectionStringName = new System.Windows.Forms.TextBox();
            this.labelPrmInheritPrmClassFrom = new System.Windows.Forms.Label();
            this.groupBoxPrm = new System.Windows.Forms.GroupBox();
            this.checkBoxPrmClassSeparate = new System.Windows.Forms.CheckBox();
            this.checkBoxPrmClassInCCFile = new System.Windows.Forms.CheckBox();
            this.checkBoxPrmClassInInterfaceFile = new System.Windows.Forms.CheckBox();
            this.lblPrm = new System.Windows.Forms.Label();
            this.groupBoxTemplate = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxTemplateInterface = new System.Windows.Forms.CheckBox();
            this.checkBoxTemplateCc = new System.Windows.Forms.CheckBox();
            this.labelConnStrName = new System.Windows.Forms.Label();
            this.groupBoxCRUD = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxAddServiceContract = new System.Windows.Forms.CheckBox();
            this.checkBoxCreateOnlySelect = new System.Windows.Forms.CheckBox();
            this.labelCRUD = new System.Windows.Forms.Label();
            this.checkBoxAddNoLock = new System.Windows.Forms.CheckBox();
            this.checkBoxTypedDs = new System.Windows.Forms.CheckBox();
            this.checkBoxCrudCC = new System.Windows.Forms.CheckBox();
            this.checkBoxCrudInterface = new System.Windows.Forms.CheckBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonGenerateMulti = new System.Windows.Forms.Button();
            this.linkLabelGenerateTrigger = new System.Windows.Forms.LinkLabel();
            this.tabPageEndPoint = new System.Windows.Forms.TabPage();
            this.radioButtonCustomBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonWsHttpBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonBasicHttpBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonNetTcpBinding = new System.Windows.Forms.RadioButton();
            this.radioButtonNetNamedBinding = new System.Windows.Forms.RadioButton();
            this.buttonCreateStrings = new System.Windows.Forms.Button();
            this.buttonCleanCacheItemWeb = new System.Windows.Forms.Button();
            this.textBoxCacheItemWeb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCleanCacheItemServer = new System.Windows.Forms.Button();
            this.textBoxCacheItemServer = new System.Windows.Forms.TextBox();
            this.labelCacheItem = new System.Windows.Forms.Label();
            this.buttonCleanEndPoint = new System.Windows.Forms.Button();
            this.textBoxEndPoint = new System.Windows.Forms.TextBox();
            this.labelEndPoint = new System.Windows.Forms.Label();
            this.tabPageTDG = new System.Windows.Forms.TabPage();
            this.buttonGenerateTypeDataSet = new System.Windows.Forms.Button();
            this.textBoxAttributesNamespace = new System.Windows.Forms.TextBox();
            this.labelAttributesNamespace = new System.Windows.Forms.Label();
            this.textBoxDataSetSuffix = new System.Windows.Forms.TextBox();
            this.labelDataSetSuffix = new System.Windows.Forms.Label();
            this.tabPageECG = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBoxEnumSuffix = new System.Windows.Forms.TextBox();
            this.labelEnumSuffix = new System.Windows.Forms.Label();
            this.textBoxEnumPrefix = new System.Windows.Forms.TextBox();
            this.labelEnumPrefix = new System.Windows.Forms.Label();
            this.linkLabelLoadColumns = new System.Windows.Forms.LinkLabel();
            this.textBoxDbScript = new System.Windows.Forms.TextBox();
            this.checkBoxUseEnumNameWithoutChange = new System.Windows.Forms.CheckBox();
            this.checkBoxUseDbScript = new System.Windows.Forms.CheckBox();
            this.checkBoxAddUnderscoreBetweenWords = new System.Windows.Forms.CheckBox();
            this.checkBoxEnumWithDescription = new System.Windows.Forms.CheckBox();
            this.comboBoxDescription = new System.Windows.Forms.ComboBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.checkBoxCreateOnlyConstants = new System.Windows.Forms.CheckBox();
            this.buttonGenerateEnumClass = new System.Windows.Forms.Button();
            this.groupBoxAyirac = new System.Windows.Forms.GroupBox();
            this.comboBoxTextField = new System.Windows.Forms.ComboBox();
            this.labelTextField = new System.Windows.Forms.Label();
            this.comboBoxValueField = new System.Windows.Forms.ComboBox();
            this.labelValueField = new System.Windows.Forms.Label();
            this.textBoxInheritanceClassNameForCC = new System.Windows.Forms.TextBox();
            this.labelInherit = new System.Windows.Forms.Label();
            this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
            this.buttonProjectPath = new System.Windows.Forms.Button();
            this.checkBoxAutoSetNamesapce = new System.Windows.Forms.CheckBox();
            this.buttonGetSchemas = new System.Windows.Forms.Button();
            this.checkBoxPkIsIdentity = new System.Windows.Forms.CheckBox();
            this.textBoxLookupPrefix = new System.Windows.Forms.TextBox();
            this.rdbOracle = new System.Windows.Forms.RadioButton();
            this.rdbMsSql = new System.Windows.Forms.RadioButton();
            this.linkLabelSetNmSpsClassNames = new System.Windows.Forms.LinkLabel();
            this.checkBoxSelectMultyTables = new System.Windows.Forms.CheckBox();
            this.buttonConnectToDb = new System.Windows.Forms.Button();
            this.buttonGetTables = new System.Windows.Forms.Button();
            this.buttonSaveConnStr = new System.Windows.Forms.Button();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
            this.textBoxInterfaceClassName = new System.Windows.Forms.TextBox();
            this.textBoxCrudClassName = new System.Windows.Forms.TextBox();
            this.checkBoxAutoSetClassName = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCcSubPath2 = new System.Windows.Forms.TextBox();
            this.textBoxCcSubPath1 = new System.Windows.Forms.TextBox();
            this.labelBsSubPath = new System.Windows.Forms.Label();
            this.textBoxProjectPath = new System.Windows.Forms.TextBox();
            this.labelProjectPath = new System.Windows.Forms.Label();
            this.textBoxInterfaceSubPath1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxInterfaceSubPath2 = new System.Windows.Forms.TextBox();
            this.LabelInterfaceSubPath = new System.Windows.Forms.Label();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lnkLabelSaveOptions = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbrMultiProc = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripDropDownButtonSkin = new System.Windows.Forms.ToolStripDropDownButton();
            this.blackSkinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardSkinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelConnectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelConnectedDbName = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelLookupPrefix = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLabelHideShow = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxTable = new System.Windows.Forms.TextBox();
            this.textBoxSchema = new System.Windows.Forms.TextBox();
            this.labelTable = new System.Windows.Forms.Label();
            this.labelSchema = new System.Windows.Forms.Label();
            this.textBoxConnStr = new System.Windows.Forms.TextBox();
            this.labelConnStr = new System.Windows.Forms.Label();
            this.panelPath = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxTypeNamespace = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxCrudClassNamespace = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxInterfaceNamespace = new System.Windows.Forms.TextBox();
            this.labelSubpathT = new System.Windows.Forms.Label();
            this.labelSubpathCC = new System.Windows.Forms.Label();
            this.labelSubPathI = new System.Windows.Forms.Label();
            this.textBoxTypeSubPath2 = new System.Windows.Forms.TextBox();
            this.textBoxTypeSubPath1 = new System.Windows.Forms.TextBox();
            this.labelTypeSubPath = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panelDb = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.pictureBoxConnectionOk = new System.Windows.Forms.PictureBox();
            this.pictureBoxNoConnection = new System.Windows.Forms.PictureBox();
            this.timerReadConnStr = new System.Windows.Forms.Timer(this.components);
            this.panelTables = new System.Windows.Forms.Panel();
            this.listBoxTables = new System.Windows.Forms.ListBox();
            this.toolStripStatusLabelSkin = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControlGeneration.SuspendLayout();
            this.tabPageCCG.SuspendLayout();
            this.groupBoxPrm.SuspendLayout();
            this.groupBoxTemplate.SuspendLayout();
            this.groupBoxCRUD.SuspendLayout();
            this.tabPageEndPoint.SuspendLayout();
            this.tabPageTDG.SuspendLayout();
            this.tabPageECG.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.panelPath.SuspendLayout();
            this.panelDb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoConnection)).BeginInit();
            this.panelTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGeneration
            // 
            this.tabControlGeneration.Controls.Add(this.tabPageCCG);
            this.tabControlGeneration.Controls.Add(this.tabPageEndPoint);
            this.tabControlGeneration.Controls.Add(this.tabPageTDG);
            this.tabControlGeneration.Controls.Add(this.tabPageECG);
            this.tabControlGeneration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tabControlGeneration.Location = new System.Drawing.Point(6, 419);
            this.tabControlGeneration.Multiline = true;
            this.tabControlGeneration.Name = "tabControlGeneration";
            this.tabControlGeneration.SelectedIndex = 0;
            this.tabControlGeneration.Size = new System.Drawing.Size(696, 255);
            this.tabControlGeneration.TabIndex = 56;
            // 
            // tabPageCCG
            // 
            this.tabPageCCG.BackColor = System.Drawing.Color.Black;
            this.tabPageCCG.Controls.Add(this.textBoxFullTableNameForLog);
            this.tabPageCCG.Controls.Add(this.labelLogTable);
            this.tabPageCCG.Controls.Add(this.textBoxInheritanceClassNameForPrm);
            this.tabPageCCG.Controls.Add(this.textBoxConnectionStringName);
            this.tabPageCCG.Controls.Add(this.labelPrmInheritPrmClassFrom);
            this.tabPageCCG.Controls.Add(this.groupBoxPrm);
            this.tabPageCCG.Controls.Add(this.groupBoxTemplate);
            this.tabPageCCG.Controls.Add(this.labelConnStrName);
            this.tabPageCCG.Controls.Add(this.groupBoxCRUD);
            this.tabPageCCG.Controls.Add(this.buttonGenerate);
            this.tabPageCCG.Controls.Add(this.buttonGenerateMulti);
            this.tabPageCCG.Controls.Add(this.linkLabelGenerateTrigger);
            this.tabPageCCG.ForeColor = System.Drawing.Color.White;
            this.tabPageCCG.Location = new System.Drawing.Point(4, 22);
            this.tabPageCCG.Name = "tabPageCCG";
            this.tabPageCCG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCCG.Size = new System.Drawing.Size(688, 229);
            this.tabPageCCG.TabIndex = 4;
            this.tabPageCCG.Text = "Crud Class Settings";
            // 
            // textBoxFullTableNameForLog
            // 
            this.textBoxFullTableNameForLog.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxFullTableNameForLog.BackColor = System.Drawing.Color.Black;
            this.textBoxFullTableNameForLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFullTableNameForLog.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxFullTableNameForLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxFullTableNameForLog.ForeColor = System.Drawing.Color.Cyan;
            this.textBoxFullTableNameForLog.Location = new System.Drawing.Point(378, 153);
            this.textBoxFullTableNameForLog.Name = "textBoxFullTableNameForLog";
            this.textBoxFullTableNameForLog.Size = new System.Drawing.Size(302, 20);
            this.textBoxFullTableNameForLog.TabIndex = 136;
            this.textBoxFullTableNameForLog.Text = "LOG_TABLE";
            this.toolTipMain.SetToolTip(this.textBoxFullTableNameForLog, "Varsayılan log tablosu yerine başka bir tablo kullanılacak ise, \\r\\nbu alana o ta" +
        "blonun tam adı \"VeritabanıAdı.ŞemaAdı.TabloAdı\" şeklinde yazılır.");
            // 
            // labelLogTable
            // 
            this.labelLogTable.AutoSize = true;
            this.labelLogTable.ForeColor = System.Drawing.Color.White;
            this.labelLogTable.Location = new System.Drawing.Point(308, 157);
            this.labelLogTable.Name = "labelLogTable";
            this.labelLogTable.Size = new System.Drawing.Size(83, 13);
            this.labelLogTable.TabIndex = 137;
            this.labelLogTable.Text = "LOG Table .......";
            // 
            // textBoxInheritanceClassNameForPrm
            // 
            this.textBoxInheritanceClassNameForPrm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxInheritanceClassNameForPrm.BackColor = System.Drawing.Color.Black;
            this.textBoxInheritanceClassNameForPrm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInheritanceClassNameForPrm.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInheritanceClassNameForPrm.ForeColor = System.Drawing.Color.SpringGreen;
            this.textBoxInheritanceClassNameForPrm.Location = new System.Drawing.Point(134, 150);
            this.textBoxInheritanceClassNameForPrm.Name = "textBoxInheritanceClassNameForPrm";
            this.textBoxInheritanceClassNameForPrm.Size = new System.Drawing.Size(161, 20);
            this.textBoxInheritanceClassNameForPrm.TabIndex = 38;
            this.textBoxInheritanceClassNameForPrm.Text = "PRMORTAKBASE";
            this.toolTipMain.SetToolTip(this.textBoxInheritanceClassNameForPrm, "Parametre sınıfı başka bir sınıftan türetilecek ise, \\r\\ntüretileceği sınıfın adı" +
        " buraya yazılır.");
            // 
            // textBoxConnectionStringName
            // 
            this.textBoxConnectionStringName.BackColor = System.Drawing.Color.Black;
            this.textBoxConnectionStringName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxConnectionStringName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxConnectionStringName.ForeColor = System.Drawing.Color.LemonChiffon;
            this.textBoxConnectionStringName.Location = new System.Drawing.Point(134, 190);
            this.textBoxConnectionStringName.Name = "textBoxConnectionStringName";
            this.textBoxConnectionStringName.Size = new System.Drawing.Size(162, 20);
            this.textBoxConnectionStringName.TabIndex = 134;
            this.textBoxConnectionStringName.Text = "ConnStrSql";
            // 
            // labelPrmInheritPrmClassFrom
            // 
            this.labelPrmInheritPrmClassFrom.AutoSize = true;
            this.labelPrmInheritPrmClassFrom.ForeColor = System.Drawing.Color.White;
            this.labelPrmInheritPrmClassFrom.Location = new System.Drawing.Point(7, 157);
            this.labelPrmInheritPrmClassFrom.Name = "labelPrmInheritPrmClassFrom";
            this.labelPrmInheritPrmClassFrom.Size = new System.Drawing.Size(129, 13);
            this.labelPrmInheritPrmClassFrom.TabIndex = 127;
            this.labelPrmInheritPrmClassFrom.Text = "Inherit Prm Class From .....";
            // 
            // groupBoxPrm
            // 
            this.groupBoxPrm.Controls.Add(this.checkBoxPrmClassSeparate);
            this.groupBoxPrm.Controls.Add(this.checkBoxPrmClassInCCFile);
            this.groupBoxPrm.Controls.Add(this.checkBoxPrmClassInInterfaceFile);
            this.groupBoxPrm.Controls.Add(this.lblPrm);
            this.groupBoxPrm.Location = new System.Drawing.Point(6, 67);
            this.groupBoxPrm.Name = "groupBoxPrm";
            this.groupBoxPrm.Size = new System.Drawing.Size(671, 30);
            this.groupBoxPrm.TabIndex = 131;
            this.groupBoxPrm.TabStop = false;
            // 
            // checkBoxPrmClassSeparate
            // 
            this.checkBoxPrmClassSeparate.AutoSize = true;
            this.checkBoxPrmClassSeparate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPrmClassSeparate.ForeColor = System.Drawing.Color.White;
            this.checkBoxPrmClassSeparate.Location = new System.Drawing.Point(370, 10);
            this.checkBoxPrmClassSeparate.Name = "checkBoxPrmClassSeparate";
            this.checkBoxPrmClassSeparate.Size = new System.Drawing.Size(130, 17);
            this.checkBoxPrmClassSeparate.TabIndex = 34;
            this.checkBoxPrmClassSeparate.Text = "As a Separate \'cs\' File";
            this.toolTipMain.SetToolTip(this.checkBoxPrmClassSeparate, "Parametre sınıfını, CRUD BS sınıfı ile aynı \'cs\' dosyasına yazmak için bu seçeneğ" +
        "i işaretleyin.");
            this.checkBoxPrmClassSeparate.UseVisualStyleBackColor = true;
            this.checkBoxPrmClassSeparate.CheckedChanged += new System.EventHandler(this.PrmClassTypeChanged);
            // 
            // checkBoxPrmClassInCCFile
            // 
            this.checkBoxPrmClassInCCFile.AutoSize = true;
            this.checkBoxPrmClassInCCFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPrmClassInCCFile.ForeColor = System.Drawing.Color.White;
            this.checkBoxPrmClassInCCFile.Location = new System.Drawing.Point(268, 10);
            this.checkBoxPrmClassInCCFile.Name = "checkBoxPrmClassInCCFile";
            this.checkBoxPrmClassInCCFile.Size = new System.Drawing.Size(85, 17);
            this.checkBoxPrmClassInCCFile.TabIndex = 33;
            this.checkBoxPrmClassInCCFile.Text = "in CC \'cs\' file";
            this.toolTipMain.SetToolTip(this.checkBoxPrmClassInCCFile, "Parametre sınıfını, CRUD CC sınıfı ile aynı \'cs\' dosyasına yazmak için bu seçeneğ" +
        "i işaretleyin.");
            this.checkBoxPrmClassInCCFile.UseVisualStyleBackColor = true;
            this.checkBoxPrmClassInCCFile.CheckedChanged += new System.EventHandler(this.PrmClassTypeChanged);
            // 
            // checkBoxPrmClassInInterfaceFile
            // 
            this.checkBoxPrmClassInInterfaceFile.AutoSize = true;
            this.checkBoxPrmClassInInterfaceFile.Checked = true;
            this.checkBoxPrmClassInInterfaceFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPrmClassInInterfaceFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPrmClassInInterfaceFile.ForeColor = System.Drawing.Color.White;
            this.checkBoxPrmClassInInterfaceFile.Location = new System.Drawing.Point(129, 10);
            this.checkBoxPrmClassInInterfaceFile.Name = "checkBoxPrmClassInInterfaceFile";
            this.checkBoxPrmClassInInterfaceFile.Size = new System.Drawing.Size(113, 17);
            this.checkBoxPrmClassInInterfaceFile.TabIndex = 32;
            this.checkBoxPrmClassInInterfaceFile.Text = "in Interface \'cs\' file";
            this.toolTipMain.SetToolTip(this.checkBoxPrmClassInInterfaceFile, "Bu seçenek işaretlendiğinde parametre sınıfları, Interface sınıfı ile aynı dosyay" +
        "a yazılır.");
            this.checkBoxPrmClassInInterfaceFile.UseVisualStyleBackColor = true;
            this.checkBoxPrmClassInInterfaceFile.CheckedChanged += new System.EventHandler(this.PrmClassTypeChanged);
            // 
            // lblPrm
            // 
            this.lblPrm.AutoSize = true;
            this.lblPrm.ForeColor = System.Drawing.Color.White;
            this.lblPrm.Location = new System.Drawing.Point(6, 11);
            this.lblPrm.Name = "lblPrm";
            this.lblPrm.Size = new System.Drawing.Size(102, 13);
            this.lblPrm.TabIndex = 120;
            this.lblPrm.Text = "Generate Parameter";
            // 
            // groupBoxTemplate
            // 
            this.groupBoxTemplate.Controls.Add(this.label3);
            this.groupBoxTemplate.Controls.Add(this.checkBoxTemplateInterface);
            this.groupBoxTemplate.Controls.Add(this.checkBoxTemplateCc);
            this.groupBoxTemplate.Location = new System.Drawing.Point(6, 105);
            this.groupBoxTemplate.Name = "groupBoxTemplate";
            this.groupBoxTemplate.Size = new System.Drawing.Size(671, 30);
            this.groupBoxTemplate.TabIndex = 130;
            this.groupBoxTemplate.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 129;
            this.label3.Text = "Generate Template ";
            // 
            // checkBoxTemplateInterface
            // 
            this.checkBoxTemplateInterface.AutoSize = true;
            this.checkBoxTemplateInterface.ForeColor = System.Drawing.Color.White;
            this.checkBoxTemplateInterface.Location = new System.Drawing.Point(268, 9);
            this.checkBoxTemplateInterface.Name = "checkBoxTemplateInterface";
            this.checkBoxTemplateInterface.Size = new System.Drawing.Size(96, 17);
            this.checkBoxTemplateInterface.TabIndex = 36;
            this.checkBoxTemplateInterface.Text = "Interface Class";
            this.toolTipMain.SetToolTip(this.checkBoxTemplateInterface, "Bu seçenek işaretlendiğinde, CC sınıfı, mevcut şablondan \"partial\" olarak ayrıca " +
        "üretilir.");
            this.checkBoxTemplateInterface.UseVisualStyleBackColor = true;
            this.checkBoxTemplateInterface.CheckedChanged += new System.EventHandler(this.checkBoxInterfaceTemplate_CheckedChanged);
            // 
            // checkBoxTemplateCc
            // 
            this.checkBoxTemplateCc.AutoSize = true;
            this.checkBoxTemplateCc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxTemplateCc.ForeColor = System.Drawing.Color.White;
            this.checkBoxTemplateCc.Location = new System.Drawing.Point(129, 9);
            this.checkBoxTemplateCc.Name = "checkBoxTemplateCc";
            this.checkBoxTemplateCc.Size = new System.Drawing.Size(68, 17);
            this.checkBoxTemplateCc.TabIndex = 35;
            this.checkBoxTemplateCc.Text = "CC Class";
            this.toolTipMain.SetToolTip(this.checkBoxTemplateCc, "Bu seçenek işaretlendiğinde, CC sınıfı, mevcut şablondan \"partial\" olarak ayrıca " +
        "üretilir.");
            this.checkBoxTemplateCc.UseVisualStyleBackColor = true;
            // 
            // labelConnStrName
            // 
            this.labelConnStrName.AutoSize = true;
            this.labelConnStrName.BackColor = System.Drawing.Color.Transparent;
            this.labelConnStrName.Location = new System.Drawing.Point(7, 194);
            this.labelConnStrName.Name = "labelConnStrName";
            this.labelConnStrName.Size = new System.Drawing.Size(134, 13);
            this.labelConnStrName.TabIndex = 135;
            this.labelConnStrName.Text = "Connection String Name ...";
            // 
            // groupBoxCRUD
            // 
            this.groupBoxCRUD.Controls.Add(this.label5);
            this.groupBoxCRUD.Controls.Add(this.label4);
            this.groupBoxCRUD.Controls.Add(this.checkBoxAddServiceContract);
            this.groupBoxCRUD.Controls.Add(this.checkBoxCreateOnlySelect);
            this.groupBoxCRUD.Controls.Add(this.labelCRUD);
            this.groupBoxCRUD.Controls.Add(this.checkBoxAddNoLock);
            this.groupBoxCRUD.Controls.Add(this.checkBoxTypedDs);
            this.groupBoxCRUD.Controls.Add(this.checkBoxCrudCC);
            this.groupBoxCRUD.Controls.Add(this.checkBoxCrudInterface);
            this.groupBoxCRUD.Location = new System.Drawing.Point(6, 6);
            this.groupBoxCRUD.Name = "groupBoxCRUD";
            this.groupBoxCRUD.Size = new System.Drawing.Size(671, 53);
            this.groupBoxCRUD.TabIndex = 129;
            this.groupBoxCRUD.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(212, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 130;
            this.label5.Text = "................";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(212, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 129;
            this.label4.Text = "................";
            // 
            // checkBoxAddServiceContract
            // 
            this.checkBoxAddServiceContract.AutoSize = true;
            this.checkBoxAddServiceContract.Checked = true;
            this.checkBoxAddServiceContract.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddServiceContract.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAddServiceContract.ForeColor = System.Drawing.Color.White;
            this.checkBoxAddServiceContract.Location = new System.Drawing.Point(268, 33);
            this.checkBoxAddServiceContract.Name = "checkBoxAddServiceContract";
            this.checkBoxAddServiceContract.Size = new System.Drawing.Size(134, 17);
            this.checkBoxAddServiceContract.TabIndex = 31;
            this.checkBoxAddServiceContract.Text = "Add \"ServiceContract\"";
            this.toolTipMain.SetToolTip(this.checkBoxAddServiceContract, "Üretilen Interface üzerinde bir EndPoint oluşturmak ve böylece servis erişimi sağ" +
        "lamak için \"ServiceContract\" niteliği (attribute) eklenmelidir.");
            this.checkBoxAddServiceContract.UseVisualStyleBackColor = true;
            this.checkBoxAddServiceContract.CheckedChanged += new System.EventHandler(this.checkBoxAddServiceContract_CheckedChanged);
            // 
            // checkBoxCreateOnlySelect
            // 
            this.checkBoxCreateOnlySelect.AutoSize = true;
            this.checkBoxCreateOnlySelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCreateOnlySelect.ForeColor = System.Drawing.Color.White;
            this.checkBoxCreateOnlySelect.Location = new System.Drawing.Point(370, 10);
            this.checkBoxCreateOnlySelect.Name = "checkBoxCreateOnlySelect";
            this.checkBoxCreateOnlySelect.Size = new System.Drawing.Size(125, 17);
            this.checkBoxCreateOnlySelect.TabIndex = 28;
            this.checkBoxCreateOnlySelect.Text = "Create Only SELECT";
            this.toolTipMain.SetToolTip(this.checkBoxCreateOnlySelect, "Crud sınıfı içinde sadece \"select\" metotları bulunacak ise, bu seçeneği işaretley" +
        "in. \\r\\nBu durumda; sınıf içinde, ekleme, güncelleme ve silme metotları bulunmay" +
        "acaktır.");
            this.checkBoxCreateOnlySelect.UseVisualStyleBackColor = true;
            // 
            // labelCRUD
            // 
            this.labelCRUD.AutoSize = true;
            this.labelCRUD.ForeColor = System.Drawing.Color.White;
            this.labelCRUD.Location = new System.Drawing.Point(6, 10);
            this.labelCRUD.Name = "labelCRUD";
            this.labelCRUD.Size = new System.Drawing.Size(85, 13);
            this.labelCRUD.TabIndex = 128;
            this.labelCRUD.Text = "Generate CRUD";
            // 
            // checkBoxAddNoLock
            // 
            this.checkBoxAddNoLock.AutoSize = true;
            this.checkBoxAddNoLock.Checked = true;
            this.checkBoxAddNoLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAddNoLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAddNoLock.ForeColor = System.Drawing.Color.White;
            this.checkBoxAddNoLock.Location = new System.Drawing.Point(268, 10);
            this.checkBoxAddNoLock.Name = "checkBoxAddNoLock";
            this.checkBoxAddNoLock.Size = new System.Drawing.Size(96, 17);
            this.checkBoxAddNoLock.TabIndex = 27;
            this.checkBoxAddNoLock.Text = "Add \"NoLock\"";
            this.toolTipMain.SetToolTip(this.checkBoxAddNoLock, "Select cümlelerine \"WITH(NOLOCK)\" eklemek için bu seçeneği işaretleyin.");
            this.checkBoxAddNoLock.UseVisualStyleBackColor = true;
            // 
            // checkBoxTypedDs
            // 
            this.checkBoxTypedDs.AutoSize = true;
            this.checkBoxTypedDs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxTypedDs.ForeColor = System.Drawing.Color.White;
            this.checkBoxTypedDs.Location = new System.Drawing.Point(501, 10);
            this.checkBoxTypedDs.Name = "checkBoxTypedDs";
            this.checkBoxTypedDs.Size = new System.Drawing.Size(150, 17);
            this.checkBoxTypedDs.TabIndex = 29;
            this.checkBoxTypedDs.Text = "Add TypedDataSet Codes";
            this.toolTipMain.SetToolTip(this.checkBoxTypedDs, "Bu seçenek işaretlendiğinde, oluşturulan CRUD sınıfına \"SelectAsTypedDataSet\" ve " +
        "\\r\\nTypedDataset\'ler için \"InsertOrUpdate\" methodu eklenir.");
            this.checkBoxTypedDs.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrudCC
            // 
            this.checkBoxCrudCC.AutoSize = true;
            this.checkBoxCrudCC.Checked = true;
            this.checkBoxCrudCC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrudCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCrudCC.ForeColor = System.Drawing.Color.White;
            this.checkBoxCrudCC.Location = new System.Drawing.Point(129, 9);
            this.checkBoxCrudCC.Name = "checkBoxCrudCC";
            this.checkBoxCrudCC.Size = new System.Drawing.Size(68, 17);
            this.checkBoxCrudCC.TabIndex = 26;
            this.checkBoxCrudCC.Text = "CC Class";
            this.checkBoxCrudCC.UseVisualStyleBackColor = true;
            this.checkBoxCrudCC.CheckedChanged += new System.EventHandler(this.checkBoxCrud_CheckedChanged);
            // 
            // checkBoxCrudInterface
            // 
            this.checkBoxCrudInterface.AutoSize = true;
            this.checkBoxCrudInterface.Checked = true;
            this.checkBoxCrudInterface.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrudInterface.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCrudInterface.ForeColor = System.Drawing.Color.White;
            this.checkBoxCrudInterface.Location = new System.Drawing.Point(129, 33);
            this.checkBoxCrudInterface.Name = "checkBoxCrudInterface";
            this.checkBoxCrudInterface.Size = new System.Drawing.Size(96, 17);
            this.checkBoxCrudInterface.TabIndex = 30;
            this.checkBoxCrudInterface.Text = "Interface Class";
            this.checkBoxCrudInterface.UseVisualStyleBackColor = true;
            this.checkBoxCrudInterface.CheckedChanged += new System.EventHandler(this.checkBoxCrudInterface_CheckedChanged);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.BackColor = System.Drawing.Color.Black;
            this.buttonGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonGenerate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.buttonGenerate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.buttonGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerate.ForeColor = System.Drawing.Color.Lime;
            this.buttonGenerate.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerate.Image")));
            this.buttonGenerate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenerate.Location = new System.Drawing.Point(450, 184);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(230, 32);
            this.buttonGenerate.TabIndex = 39;
            this.buttonGenerate.Text = "Generate Selected Classes";
            this.buttonGenerate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerate.UseVisualStyleBackColor = false;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonGenerateMulti
            // 
            this.buttonGenerateMulti.BackColor = System.Drawing.Color.Black;
            this.buttonGenerateMulti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerateMulti.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonGenerateMulti.FlatAppearance.BorderSize = 2;
            this.buttonGenerateMulti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.buttonGenerateMulti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.buttonGenerateMulti.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateMulti.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerateMulti.ForeColor = System.Drawing.Color.Lime;
            this.buttonGenerateMulti.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateMulti.Image")));
            this.buttonGenerateMulti.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenerateMulti.Location = new System.Drawing.Point(450, 185);
            this.buttonGenerateMulti.Name = "buttonGenerateMulti";
            this.buttonGenerateMulti.Size = new System.Drawing.Size(230, 32);
            this.buttonGenerateMulti.TabIndex = 117;
            this.buttonGenerateMulti.Text = "Generate Selected Classes";
            this.buttonGenerateMulti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGenerateMulti.UseVisualStyleBackColor = false;
            this.buttonGenerateMulti.Visible = false;
            this.buttonGenerateMulti.Click += new System.EventHandler(this.buttonGenerateMulti_Click);
            // 
            // linkLabelGenerateTrigger
            // 
            this.linkLabelGenerateTrigger.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelGenerateTrigger.LinkColor = System.Drawing.Color.RoyalBlue;
            this.linkLabelGenerateTrigger.Location = new System.Drawing.Point(310, 198);
            this.linkLabelGenerateTrigger.Name = "linkLabelGenerateTrigger";
            this.linkLabelGenerateTrigger.Size = new System.Drawing.Size(98, 24);
            this.linkLabelGenerateTrigger.TabIndex = 40;
            this.linkLabelGenerateTrigger.TabStop = true;
            this.linkLabelGenerateTrigger.Text = "Generate Triggers For Logging";
            this.linkLabelGenerateTrigger.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTipMain.SetToolTip(this.linkLabelGenerateTrigger, "Ekleme ve güncelleme işlemlerine ait log\'lamaları bir trigger aracılığı ile yapma" +
        "k isterseniz, \\r\\nBu butona tıklayarak gerekli trigger betik (script) dosyasını " +
        "üretebilirsiniz.");
            this.linkLabelGenerateTrigger.Visible = false;
            this.linkLabelGenerateTrigger.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGenerateTrigger_LinkClicked);
            // 
            // tabPageEndPoint
            // 
            this.tabPageEndPoint.BackColor = System.Drawing.Color.Black;
            this.tabPageEndPoint.Controls.Add(this.radioButtonCustomBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonWsHttpBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonBasicHttpBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonNetTcpBinding);
            this.tabPageEndPoint.Controls.Add(this.radioButtonNetNamedBinding);
            this.tabPageEndPoint.Controls.Add(this.buttonCreateStrings);
            this.tabPageEndPoint.Controls.Add(this.buttonCleanCacheItemWeb);
            this.tabPageEndPoint.Controls.Add(this.textBoxCacheItemWeb);
            this.tabPageEndPoint.Controls.Add(this.label1);
            this.tabPageEndPoint.Controls.Add(this.buttonCleanCacheItemServer);
            this.tabPageEndPoint.Controls.Add(this.textBoxCacheItemServer);
            this.tabPageEndPoint.Controls.Add(this.labelCacheItem);
            this.tabPageEndPoint.Controls.Add(this.buttonCleanEndPoint);
            this.tabPageEndPoint.Controls.Add(this.textBoxEndPoint);
            this.tabPageEndPoint.Controls.Add(this.labelEndPoint);
            this.tabPageEndPoint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tabPageEndPoint.Location = new System.Drawing.Point(4, 22);
            this.tabPageEndPoint.Name = "tabPageEndPoint";
            this.tabPageEndPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEndPoint.Size = new System.Drawing.Size(688, 229);
            this.tabPageEndPoint.TabIndex = 0;
            this.tabPageEndPoint.Text = "End-Point & CacheItem Strings";
            // 
            // radioButtonCustomBinding
            // 
            this.radioButtonCustomBinding.BackColor = System.Drawing.Color.Black;
            this.radioButtonCustomBinding.Checked = true;
            this.radioButtonCustomBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonCustomBinding.Location = new System.Drawing.Point(14, 108);
            this.radioButtonCustomBinding.Name = "radioButtonCustomBinding";
            this.radioButtonCustomBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonCustomBinding.TabIndex = 45;
            this.radioButtonCustomBinding.TabStop = true;
            this.radioButtonCustomBinding.Text = "Custom Binding";
            this.radioButtonCustomBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonWsHttpBinding
            // 
            this.radioButtonWsHttpBinding.BackColor = System.Drawing.Color.Black;
            this.radioButtonWsHttpBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonWsHttpBinding.Location = new System.Drawing.Point(14, 90);
            this.radioButtonWsHttpBinding.Name = "radioButtonWsHttpBinding";
            this.radioButtonWsHttpBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonWsHttpBinding.TabIndex = 44;
            this.radioButtonWsHttpBinding.Text = "ws http";
            this.radioButtonWsHttpBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonBasicHttpBinding
            // 
            this.radioButtonBasicHttpBinding.BackColor = System.Drawing.Color.Black;
            this.radioButtonBasicHttpBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonBasicHttpBinding.Location = new System.Drawing.Point(14, 72);
            this.radioButtonBasicHttpBinding.Name = "radioButtonBasicHttpBinding";
            this.radioButtonBasicHttpBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonBasicHttpBinding.TabIndex = 43;
            this.radioButtonBasicHttpBinding.Text = "basic http";
            this.radioButtonBasicHttpBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonNetTcpBinding
            // 
            this.radioButtonNetTcpBinding.BackColor = System.Drawing.Color.Black;
            this.radioButtonNetTcpBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonNetTcpBinding.Location = new System.Drawing.Point(14, 54);
            this.radioButtonNetTcpBinding.Name = "radioButtonNetTcpBinding";
            this.radioButtonNetTcpBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonNetTcpBinding.TabIndex = 42;
            this.radioButtonNetTcpBinding.Text = "netTcp";
            this.radioButtonNetTcpBinding.UseVisualStyleBackColor = false;
            // 
            // radioButtonNetNamedBinding
            // 
            this.radioButtonNetNamedBinding.BackColor = System.Drawing.Color.Black;
            this.radioButtonNetNamedBinding.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonNetNamedBinding.Location = new System.Drawing.Point(14, 36);
            this.radioButtonNetNamedBinding.Name = "radioButtonNetNamedBinding";
            this.radioButtonNetNamedBinding.Size = new System.Drawing.Size(100, 17);
            this.radioButtonNetNamedBinding.TabIndex = 41;
            this.radioButtonNetNamedBinding.Text = "netNamedPipe";
            this.radioButtonNetNamedBinding.UseVisualStyleBackColor = false;
            // 
            // buttonCreateStrings
            // 
            this.buttonCreateStrings.BackColor = System.Drawing.Color.Peru;
            this.buttonCreateStrings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCreateStrings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonCreateStrings.ForeColor = System.Drawing.Color.White;
            this.buttonCreateStrings.Location = new System.Drawing.Point(393, 190);
            this.buttonCreateStrings.Name = "buttonCreateStrings";
            this.buttonCreateStrings.Size = new System.Drawing.Size(239, 32);
            this.buttonCreateStrings.TabIndex = 52;
            this.buttonCreateStrings.Text = "Create EndPoint and Cache Items";
            this.toolTipMain.SetToolTip(this.buttonCreateStrings, "EndPoint\'leri ve Cache Item\'ları oluştur.");
            this.buttonCreateStrings.UseVisualStyleBackColor = false;
            this.buttonCreateStrings.Click += new System.EventHandler(this.buttonCreateStrings_Click);
            // 
            // buttonCleanCacheItemWeb
            // 
            this.buttonCleanCacheItemWeb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCleanCacheItemWeb.Image = ((System.Drawing.Image)(resources.GetObject("buttonCleanCacheItemWeb.Image")));
            this.buttonCleanCacheItemWeb.Location = new System.Drawing.Point(644, 158);
            this.buttonCleanCacheItemWeb.Name = "buttonCleanCacheItemWeb";
            this.buttonCleanCacheItemWeb.Size = new System.Drawing.Size(25, 20);
            this.buttonCleanCacheItemWeb.TabIndex = 51;
            this.toolTipMain.SetToolTip(this.buttonCleanCacheItemWeb, "Temizle");
            this.buttonCleanCacheItemWeb.UseVisualStyleBackColor = true;
            this.buttonCleanCacheItemWeb.Click += new System.EventHandler(this.buttonCleanCacheItemWeb_Click);
            // 
            // textBoxCacheItemWeb
            // 
            this.textBoxCacheItemWeb.BackColor = System.Drawing.Color.Black;
            this.textBoxCacheItemWeb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCacheItemWeb.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.textBoxCacheItemWeb.Location = new System.Drawing.Point(130, 159);
            this.textBoxCacheItemWeb.Name = "textBoxCacheItemWeb";
            this.textBoxCacheItemWeb.ReadOnly = true;
            this.textBoxCacheItemWeb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCacheItemWeb.Size = new System.Drawing.Size(502, 20);
            this.textBoxCacheItemWeb.TabIndex = 50;
            this.textBoxCacheItemWeb.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Cache Item (Web)";
            // 
            // buttonCleanCacheItemServer
            // 
            this.buttonCleanCacheItemServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCleanCacheItemServer.Image = ((System.Drawing.Image)(resources.GetObject("buttonCleanCacheItemServer.Image")));
            this.buttonCleanCacheItemServer.Location = new System.Drawing.Point(644, 132);
            this.buttonCleanCacheItemServer.Name = "buttonCleanCacheItemServer";
            this.buttonCleanCacheItemServer.Size = new System.Drawing.Size(25, 20);
            this.buttonCleanCacheItemServer.TabIndex = 49;
            this.toolTipMain.SetToolTip(this.buttonCleanCacheItemServer, "Temizle");
            this.buttonCleanCacheItemServer.UseVisualStyleBackColor = true;
            this.buttonCleanCacheItemServer.Click += new System.EventHandler(this.buttonCleanCacheItemServer_Click);
            // 
            // textBoxCacheItemServer
            // 
            this.textBoxCacheItemServer.BackColor = System.Drawing.Color.Black;
            this.textBoxCacheItemServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCacheItemServer.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.textBoxCacheItemServer.Location = new System.Drawing.Point(130, 133);
            this.textBoxCacheItemServer.Name = "textBoxCacheItemServer";
            this.textBoxCacheItemServer.ReadOnly = true;
            this.textBoxCacheItemServer.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxCacheItemServer.Size = new System.Drawing.Size(502, 20);
            this.textBoxCacheItemServer.TabIndex = 48;
            this.textBoxCacheItemServer.WordWrap = false;
            // 
            // labelCacheItem
            // 
            this.labelCacheItem.AutoSize = true;
            this.labelCacheItem.Location = new System.Drawing.Point(15, 137);
            this.labelCacheItem.Name = "labelCacheItem";
            this.labelCacheItem.Size = new System.Drawing.Size(101, 13);
            this.labelCacheItem.TabIndex = 100;
            this.labelCacheItem.Text = "Cache Item (Server)";
            // 
            // buttonCleanEndPoint
            // 
            this.buttonCleanEndPoint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCleanEndPoint.Image = ((System.Drawing.Image)(resources.GetObject("buttonCleanEndPoint.Image")));
            this.buttonCleanEndPoint.Location = new System.Drawing.Point(644, 6);
            this.buttonCleanEndPoint.Name = "buttonCleanEndPoint";
            this.buttonCleanEndPoint.Size = new System.Drawing.Size(25, 20);
            this.buttonCleanEndPoint.TabIndex = 47;
            this.toolTipMain.SetToolTip(this.buttonCleanEndPoint, "Temizle");
            this.buttonCleanEndPoint.UseVisualStyleBackColor = true;
            this.buttonCleanEndPoint.Click += new System.EventHandler(this.buttonCleanEndPoint_Click);
            // 
            // textBoxEndPoint
            // 
            this.textBoxEndPoint.BackColor = System.Drawing.Color.Black;
            this.textBoxEndPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEndPoint.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEndPoint.Location = new System.Drawing.Point(130, 6);
            this.textBoxEndPoint.Multiline = true;
            this.textBoxEndPoint.Name = "textBoxEndPoint";
            this.textBoxEndPoint.ReadOnly = true;
            this.textBoxEndPoint.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEndPoint.Size = new System.Drawing.Size(502, 121);
            this.textBoxEndPoint.TabIndex = 46;
            this.textBoxEndPoint.WordWrap = false;
            // 
            // labelEndPoint
            // 
            this.labelEndPoint.AutoSize = true;
            this.labelEndPoint.Location = new System.Drawing.Point(15, 10);
            this.labelEndPoint.Name = "labelEndPoint";
            this.labelEndPoint.Size = new System.Drawing.Size(53, 13);
            this.labelEndPoint.TabIndex = 97;
            this.labelEndPoint.Text = "End Point";
            // 
            // tabPageTDG
            // 
            this.tabPageTDG.BackColor = System.Drawing.Color.Black;
            this.tabPageTDG.Controls.Add(this.buttonGenerateTypeDataSet);
            this.tabPageTDG.Controls.Add(this.textBoxAttributesNamespace);
            this.tabPageTDG.Controls.Add(this.labelAttributesNamespace);
            this.tabPageTDG.Controls.Add(this.textBoxDataSetSuffix);
            this.tabPageTDG.Controls.Add(this.labelDataSetSuffix);
            this.tabPageTDG.Location = new System.Drawing.Point(4, 22);
            this.tabPageTDG.Name = "tabPageTDG";
            this.tabPageTDG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTDG.Size = new System.Drawing.Size(688, 229);
            this.tabPageTDG.TabIndex = 2;
            this.tabPageTDG.Text = "Typed Dataset Generation";
            // 
            // buttonGenerateTypeDataSet
            // 
            this.buttonGenerateTypeDataSet.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonGenerateTypeDataSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerateTypeDataSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerateTypeDataSet.ForeColor = System.Drawing.Color.White;
            this.buttonGenerateTypeDataSet.Location = new System.Drawing.Point(465, 190);
            this.buttonGenerateTypeDataSet.Name = "buttonGenerateTypeDataSet";
            this.buttonGenerateTypeDataSet.Size = new System.Drawing.Size(200, 32);
            this.buttonGenerateTypeDataSet.TabIndex = 55;
            this.buttonGenerateTypeDataSet.Text = "Generate Typed DataSets";
            this.buttonGenerateTypeDataSet.UseVisualStyleBackColor = false;
            this.buttonGenerateTypeDataSet.Click += new System.EventHandler(this.buttonGenerateTypeDataSet_Click);
            // 
            // textBoxAttributesNamespace
            // 
            this.textBoxAttributesNamespace.BackColor = System.Drawing.Color.Black;
            this.textBoxAttributesNamespace.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBoxAttributesNamespace.ForeColor = System.Drawing.Color.SteelBlue;
            this.textBoxAttributesNamespace.Location = new System.Drawing.Point(150, 44);
            this.textBoxAttributesNamespace.Name = "textBoxAttributesNamespace";
            this.textBoxAttributesNamespace.Size = new System.Drawing.Size(240, 20);
            this.textBoxAttributesNamespace.TabIndex = 54;
            this.textBoxAttributesNamespace.Text = "Types.Attributes";
            // 
            // labelAttributesNamespace
            // 
            this.labelAttributesNamespace.AutoSize = true;
            this.labelAttributesNamespace.Location = new System.Drawing.Point(6, 47);
            this.labelAttributesNamespace.Name = "labelAttributesNamespace";
            this.labelAttributesNamespace.Size = new System.Drawing.Size(111, 13);
            this.labelAttributesNamespace.TabIndex = 90;
            this.labelAttributesNamespace.Text = "Attributes Namespace";
            // 
            // textBoxDataSetSuffix
            // 
            this.textBoxDataSetSuffix.BackColor = System.Drawing.Color.Black;
            this.textBoxDataSetSuffix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold);
            this.textBoxDataSetSuffix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.textBoxDataSetSuffix.Location = new System.Drawing.Point(150, 18);
            this.textBoxDataSetSuffix.Name = "textBoxDataSetSuffix";
            this.textBoxDataSetSuffix.Size = new System.Drawing.Size(240, 20);
            this.textBoxDataSetSuffix.TabIndex = 53;
            this.textBoxDataSetSuffix.Text = "DataSet";
            // 
            // labelDataSetSuffix
            // 
            this.labelDataSetSuffix.AutoSize = true;
            this.labelDataSetSuffix.Location = new System.Drawing.Point(6, 21);
            this.labelDataSetSuffix.Name = "labelDataSetSuffix";
            this.labelDataSetSuffix.Size = new System.Drawing.Size(75, 13);
            this.labelDataSetSuffix.TabIndex = 88;
            this.labelDataSetSuffix.Text = "DataSet Suffix";
            // 
            // tabPageECG
            // 
            this.tabPageECG.BackColor = System.Drawing.Color.Black;
            this.tabPageECG.Controls.Add(this.groupBox5);
            this.tabPageECG.Controls.Add(this.textBoxEnumSuffix);
            this.tabPageECG.Controls.Add(this.labelEnumSuffix);
            this.tabPageECG.Controls.Add(this.textBoxEnumPrefix);
            this.tabPageECG.Controls.Add(this.labelEnumPrefix);
            this.tabPageECG.Controls.Add(this.linkLabelLoadColumns);
            this.tabPageECG.Controls.Add(this.textBoxDbScript);
            this.tabPageECG.Controls.Add(this.checkBoxUseEnumNameWithoutChange);
            this.tabPageECG.Controls.Add(this.checkBoxUseDbScript);
            this.tabPageECG.Controls.Add(this.checkBoxAddUnderscoreBetweenWords);
            this.tabPageECG.Controls.Add(this.checkBoxEnumWithDescription);
            this.tabPageECG.Controls.Add(this.comboBoxDescription);
            this.tabPageECG.Controls.Add(this.labelDescription);
            this.tabPageECG.Controls.Add(this.checkBoxCreateOnlyConstants);
            this.tabPageECG.Controls.Add(this.buttonGenerateEnumClass);
            this.tabPageECG.Controls.Add(this.groupBoxAyirac);
            this.tabPageECG.Controls.Add(this.comboBoxTextField);
            this.tabPageECG.Controls.Add(this.labelTextField);
            this.tabPageECG.Controls.Add(this.comboBoxValueField);
            this.tabPageECG.Controls.Add(this.labelValueField);
            this.tabPageECG.Location = new System.Drawing.Point(4, 22);
            this.tabPageECG.Name = "tabPageECG";
            this.tabPageECG.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageECG.Size = new System.Drawing.Size(688, 229);
            this.tabPageECG.TabIndex = 3;
            this.tabPageECG.Text = "Enum Generation";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(431, 144);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 3);
            this.groupBox5.TabIndex = 141;
            this.groupBox5.TabStop = false;
            // 
            // textBoxEnumSuffix
            // 
            this.textBoxEnumSuffix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxEnumSuffix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxEnumSuffix.BackColor = System.Drawing.Color.Black;
            this.textBoxEnumSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEnumSuffix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEnumSuffix.ForeColor = System.Drawing.Color.Lime;
            this.textBoxEnumSuffix.Location = new System.Drawing.Point(609, 116);
            this.textBoxEnumSuffix.Name = "textBoxEnumSuffix";
            this.textBoxEnumSuffix.Size = new System.Drawing.Size(43, 20);
            this.textBoxEnumSuffix.TabIndex = 67;
            this.toolTipMain.SetToolTip(this.textBoxEnumSuffix, "Tanım tabloları için ön-ek kullanılacak ise (tavsiye edilir) buraya yazınız. \\r\\n" +
        "Önerilen Ön-Ek\'ler: TT_; LT_; PRM_");
            // 
            // labelEnumSuffix
            // 
            this.labelEnumSuffix.AutoSize = true;
            this.labelEnumSuffix.Location = new System.Drawing.Point(573, 119);
            this.labelEnumSuffix.Name = "labelEnumSuffix";
            this.labelEnumSuffix.Size = new System.Drawing.Size(33, 13);
            this.labelEnumSuffix.TabIndex = 140;
            this.labelEnumSuffix.Text = "Suffix";
            this.labelEnumSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxEnumPrefix
            // 
            this.textBoxEnumPrefix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxEnumPrefix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxEnumPrefix.BackColor = System.Drawing.Color.Black;
            this.textBoxEnumPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxEnumPrefix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxEnumPrefix.ForeColor = System.Drawing.Color.Aqua;
            this.textBoxEnumPrefix.Location = new System.Drawing.Point(524, 116);
            this.textBoxEnumPrefix.Name = "textBoxEnumPrefix";
            this.textBoxEnumPrefix.Size = new System.Drawing.Size(43, 20);
            this.textBoxEnumPrefix.TabIndex = 66;
            this.textBoxEnumPrefix.Text = "Enum";
            this.toolTipMain.SetToolTip(this.textBoxEnumPrefix, "Tanım tabloları için ön-ek kullanılacak ise (tavsiye edilir) buraya yazınız. \\r\\n" +
        "Önerilen Ön-Ek\'ler: TT_; LT_; PRM_");
            // 
            // labelEnumPrefix
            // 
            this.labelEnumPrefix.AutoSize = true;
            this.labelEnumPrefix.Location = new System.Drawing.Point(460, 119);
            this.labelEnumPrefix.Name = "labelEnumPrefix";
            this.labelEnumPrefix.Size = new System.Drawing.Size(63, 13);
            this.labelEnumPrefix.TabIndex = 138;
            this.labelEnumPrefix.Text = "Enum Prefix";
            this.labelEnumPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelLoadColumns
            // 
            this.linkLabelLoadColumns.AutoSize = true;
            this.linkLabelLoadColumns.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.linkLabelLoadColumns.Location = new System.Drawing.Point(112, 19);
            this.linkLabelLoadColumns.Name = "linkLabelLoadColumns";
            this.linkLabelLoadColumns.Size = new System.Drawing.Size(31, 13);
            this.linkLabelLoadColumns.TabIndex = 56;
            this.linkLabelLoadColumns.TabStop = true;
            this.linkLabelLoadColumns.Text = "Load";
            this.toolTipMain.SetToolTip(this.linkLabelLoadColumns, resources.GetString("linkLabelLoadColumns.ToolTip"));
            this.linkLabelLoadColumns.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLoadColumns_LinkClicked);
            // 
            // textBoxDbScript
            // 
            this.textBoxDbScript.BackColor = System.Drawing.Color.Black;
            this.textBoxDbScript.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDbScript.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxDbScript.ForeColor = System.Drawing.Color.Lime;
            this.textBoxDbScript.Location = new System.Drawing.Point(6, 146);
            this.textBoxDbScript.Multiline = true;
            this.textBoxDbScript.Name = "textBoxDbScript";
            this.textBoxDbScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDbScript.Size = new System.Drawing.Size(416, 78);
            this.textBoxDbScript.TabIndex = 65;
            this.textBoxDbScript.Visible = false;
            // 
            // checkBoxUseEnumNameWithoutChange
            // 
            this.checkBoxUseEnumNameWithoutChange.AutoSize = true;
            this.checkBoxUseEnumNameWithoutChange.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUseEnumNameWithoutChange.ForeColor = System.Drawing.Color.Aquamarine;
            this.checkBoxUseEnumNameWithoutChange.Location = new System.Drawing.Point(441, 57);
            this.checkBoxUseEnumNameWithoutChange.Name = "checkBoxUseEnumNameWithoutChange";
            this.checkBoxUseEnumNameWithoutChange.Size = new System.Drawing.Size(207, 17);
            this.checkBoxUseEnumNameWithoutChange.TabIndex = 62;
            this.checkBoxUseEnumNameWithoutChange.Text = "Use Enum Name Without Any Change";
            this.toolTipMain.SetToolTip(this.checkBoxUseEnumNameWithoutChange, "If checked, Enum Name is used without any change (same as database)");
            this.checkBoxUseEnumNameWithoutChange.UseVisualStyleBackColor = true;
            // 
            // checkBoxUseDbScript
            // 
            this.checkBoxUseDbScript.AutoSize = true;
            this.checkBoxUseDbScript.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxUseDbScript.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxUseDbScript.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxUseDbScript.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxUseDbScript.ForeColor = System.Drawing.Color.Lime;
            this.checkBoxUseDbScript.Location = new System.Drawing.Point(7, 124);
            this.checkBoxUseDbScript.Name = "checkBoxUseDbScript";
            this.checkBoxUseDbScript.Size = new System.Drawing.Size(159, 17);
            this.checkBoxUseDbScript.TabIndex = 64;
            this.checkBoxUseDbScript.Text = "Use Custom Database Script";
            this.toolTipMain.SetToolTip(this.checkBoxUseDbScript, "Check to generate enum class by using custom SQL script");
            this.checkBoxUseDbScript.UseVisualStyleBackColor = false;
            this.checkBoxUseDbScript.CheckedChanged += new System.EventHandler(this.checkBoxUseDbScript_CheckedChanged);
            // 
            // checkBoxAddUnderscoreBetweenWords
            // 
            this.checkBoxAddUnderscoreBetweenWords.AutoSize = true;
            this.checkBoxAddUnderscoreBetweenWords.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAddUnderscoreBetweenWords.ForeColor = System.Drawing.Color.Gold;
            this.checkBoxAddUnderscoreBetweenWords.Location = new System.Drawing.Point(441, 37);
            this.checkBoxAddUnderscoreBetweenWords.Name = "checkBoxAddUnderscoreBetweenWords";
            this.checkBoxAddUnderscoreBetweenWords.Size = new System.Drawing.Size(182, 17);
            this.checkBoxAddUnderscoreBetweenWords.TabIndex = 61;
            this.checkBoxAddUnderscoreBetweenWords.Text = "Add Underscore Between Words";
            this.toolTipMain.SetToolTip(this.checkBoxAddUnderscoreBetweenWords, "If checked, Enum Name word parts will be separated with \"_\" sign. exp: \"User_Type" +
        "\"\r\nIf not checked, Enum Name word parts will be joined. Exp: \"UserType\"");
            this.checkBoxAddUnderscoreBetweenWords.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnumWithDescription
            // 
            this.checkBoxEnumWithDescription.AutoSize = true;
            this.checkBoxEnumWithDescription.Checked = true;
            this.checkBoxEnumWithDescription.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnumWithDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxEnumWithDescription.ForeColor = System.Drawing.Color.LightSalmon;
            this.checkBoxEnumWithDescription.Location = new System.Drawing.Point(441, 17);
            this.checkBoxEnumWithDescription.Name = "checkBoxEnumWithDescription";
            this.checkBoxEnumWithDescription.Size = new System.Drawing.Size(168, 17);
            this.checkBoxEnumWithDescription.TabIndex = 60;
            this.checkBoxEnumWithDescription.Text = "Create Enum With Description";
            this.toolTipMain.SetToolTip(this.checkBoxEnumWithDescription, "If checked, enum items will be generated with description ettribute.");
            this.checkBoxEnumWithDescription.UseVisualStyleBackColor = true;
            // 
            // comboBoxDescription
            // 
            this.comboBoxDescription.BackColor = System.Drawing.Color.Black;
            this.comboBoxDescription.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDescription.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxDescription.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.comboBoxDescription.ForeColor = System.Drawing.Color.LightSalmon;
            this.comboBoxDescription.FormattingEnabled = true;
            this.comboBoxDescription.Location = new System.Drawing.Point(151, 71);
            this.comboBoxDescription.Name = "comboBoxDescription";
            this.comboBoxDescription.Size = new System.Drawing.Size(271, 22);
            this.comboBoxDescription.TabIndex = 59;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(10, 79);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(115, 13);
            this.labelDescription.TabIndex = 129;
            this.labelDescription.Text = "Enum Description Field";
            this.toolTipMain.SetToolTip(this.labelDescription, "Enum Description");
            // 
            // checkBoxCreateOnlyConstants
            // 
            this.checkBoxCreateOnlyConstants.AutoSize = true;
            this.checkBoxCreateOnlyConstants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxCreateOnlyConstants.ForeColor = System.Drawing.Color.LightBlue;
            this.checkBoxCreateOnlyConstants.Location = new System.Drawing.Point(441, 77);
            this.checkBoxCreateOnlyConstants.Name = "checkBoxCreateOnlyConstants";
            this.checkBoxCreateOnlyConstants.Size = new System.Drawing.Size(131, 17);
            this.checkBoxCreateOnlyConstants.TabIndex = 63;
            this.checkBoxCreateOnlyConstants.Text = "Create Only Constants";
            this.toolTipMain.SetToolTip(this.checkBoxCreateOnlyConstants, "If checked, enum items will be generated as constant variables only");
            this.checkBoxCreateOnlyConstants.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateEnumClass
            // 
            this.buttonGenerateEnumClass.BackColor = System.Drawing.Color.Black;
            this.buttonGenerateEnumClass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGenerateEnumClass.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonGenerateEnumClass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonGenerateEnumClass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonGenerateEnumClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGenerateEnumClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonGenerateEnumClass.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonGenerateEnumClass.Image = ((System.Drawing.Image)(resources.GetObject("buttonGenerateEnumClass.Image")));
            this.buttonGenerateEnumClass.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGenerateEnumClass.Location = new System.Drawing.Point(450, 184);
            this.buttonGenerateEnumClass.Name = "buttonGenerateEnumClass";
            this.buttonGenerateEnumClass.Size = new System.Drawing.Size(230, 32);
            this.buttonGenerateEnumClass.TabIndex = 68;
            this.buttonGenerateEnumClass.Text = "Generate Enum Class";
            this.buttonGenerateEnumClass.UseVisualStyleBackColor = false;
            this.buttonGenerateEnumClass.Click += new System.EventHandler(this.buttonGenerateEnumClass_Click);
            // 
            // groupBoxAyirac
            // 
            this.groupBoxAyirac.Location = new System.Drawing.Point(7, 103);
            this.groupBoxAyirac.Name = "groupBoxAyirac";
            this.groupBoxAyirac.Size = new System.Drawing.Size(670, 3);
            this.groupBoxAyirac.TabIndex = 126;
            this.groupBoxAyirac.TabStop = false;
            // 
            // comboBoxTextField
            // 
            this.comboBoxTextField.BackColor = System.Drawing.Color.Black;
            this.comboBoxTextField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxTextField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTextField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxTextField.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.comboBoxTextField.ForeColor = System.Drawing.Color.Yellow;
            this.comboBoxTextField.FormattingEnabled = true;
            this.comboBoxTextField.Location = new System.Drawing.Point(150, 15);
            this.comboBoxTextField.Name = "comboBoxTextField";
            this.comboBoxTextField.Size = new System.Drawing.Size(271, 22);
            this.comboBoxTextField.TabIndex = 57;
            // 
            // labelTextField
            // 
            this.labelTextField.AutoSize = true;
            this.labelTextField.Location = new System.Drawing.Point(10, 19);
            this.labelTextField.Name = "labelTextField";
            this.labelTextField.Size = new System.Drawing.Size(90, 13);
            this.labelTextField.TabIndex = 124;
            this.labelTextField.Text = "Enum Name Field";
            this.toolTipMain.SetToolTip(this.labelTextField, "Enum or Constant Name");
            // 
            // comboBoxValueField
            // 
            this.comboBoxValueField.BackColor = System.Drawing.Color.Black;
            this.comboBoxValueField.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxValueField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxValueField.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxValueField.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.comboBoxValueField.ForeColor = System.Drawing.Color.Lime;
            this.comboBoxValueField.FormattingEnabled = true;
            this.comboBoxValueField.Location = new System.Drawing.Point(151, 43);
            this.comboBoxValueField.Name = "comboBoxValueField";
            this.comboBoxValueField.Size = new System.Drawing.Size(271, 22);
            this.comboBoxValueField.TabIndex = 58;
            // 
            // labelValueField
            // 
            this.labelValueField.AutoSize = true;
            this.labelValueField.Location = new System.Drawing.Point(10, 49);
            this.labelValueField.Name = "labelValueField";
            this.labelValueField.Size = new System.Drawing.Size(89, 13);
            this.labelValueField.TabIndex = 122;
            this.labelValueField.Text = "Enum Value Field";
            this.toolTipMain.SetToolTip(this.labelValueField, "Enum or Constant Value");
            // 
            // textBoxInheritanceClassNameForCC
            // 
            this.textBoxInheritanceClassNameForCC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxInheritanceClassNameForCC.BackColor = System.Drawing.Color.Black;
            this.textBoxInheritanceClassNameForCC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInheritanceClassNameForCC.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInheritanceClassNameForCC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.textBoxInheritanceClassNameForCC.Location = new System.Drawing.Point(516, 204);
            this.textBoxInheritanceClassNameForCC.Name = "textBoxInheritanceClassNameForCC";
            this.textBoxInheritanceClassNameForCC.Size = new System.Drawing.Size(137, 20);
            this.textBoxInheritanceClassNameForCC.TabIndex = 22;
            this.textBoxInheritanceClassNameForCC.Text = "CCGDalBase";
            this.toolTipMain.SetToolTip(this.textBoxInheritanceClassNameForCC, "BS sınıfını başka bir sınıfdan türetmek istiyorsanız, \\r\\nburaya o sınıfın adını " +
        "yazınız.");
            // 
            // labelInherit
            // 
            this.labelInherit.AutoSize = true;
            this.labelInherit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelInherit.Location = new System.Drawing.Point(499, 205);
            this.labelInherit.Name = "labelInherit";
            this.labelInherit.Size = new System.Drawing.Size(13, 17);
            this.labelInherit.TabIndex = 117;
            this.labelInherit.Text = ":";
            this.toolTipMain.SetToolTip(this.labelInherit, "Inherit");
            // 
            // toolTipMain
            // 
            this.toolTipMain.AutoPopDelay = 20000;
            this.toolTipMain.InitialDelay = 500;
            this.toolTipMain.IsBalloon = true;
            this.toolTipMain.ReshowDelay = 100;
            this.toolTipMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipMain.ToolTipTitle = "Information";
            // 
            // buttonProjectPath
            // 
            this.buttonProjectPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProjectPath.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonProjectPath.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.buttonProjectPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonProjectPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonProjectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProjectPath.Image = ((System.Drawing.Image)(resources.GetObject("buttonProjectPath.Image")));
            this.buttonProjectPath.Location = new System.Drawing.Point(660, 14);
            this.buttonProjectPath.Name = "buttonProjectPath";
            this.buttonProjectPath.Size = new System.Drawing.Size(25, 20);
            this.buttonProjectPath.TabIndex = 13;
            this.toolTipMain.SetToolTip(this.buttonProjectPath, "Proje dizini seç.");
            this.buttonProjectPath.UseVisualStyleBackColor = true;
            this.buttonProjectPath.Click += new System.EventHandler(this.buttonTargetPath_Click);
            // 
            // checkBoxAutoSetNamesapce
            // 
            this.checkBoxAutoSetNamesapce.AutoSize = true;
            this.checkBoxAutoSetNamesapce.BackColor = System.Drawing.Color.Black;
            this.checkBoxAutoSetNamesapce.Checked = true;
            this.checkBoxAutoSetNamesapce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoSetNamesapce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAutoSetNamesapce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAutoSetNamesapce.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxAutoSetNamesapce.ForeColor = System.Drawing.Color.White;
            this.checkBoxAutoSetNamesapce.Location = new System.Drawing.Point(669, 101);
            this.checkBoxAutoSetNamesapce.Name = "checkBoxAutoSetNamesapce";
            this.checkBoxAutoSetNamesapce.Size = new System.Drawing.Size(12, 11);
            this.checkBoxAutoSetNamesapce.TabIndex = 24;
            this.toolTipMain.SetToolTip(this.checkBoxAutoSetNamesapce, "Bu seçenek işaretlendiğinde, verilen \"namespace\" adı olduğu gibi kullanılır.\r\nBu " +
        "seçenek işaretli olmadığında \"namespace\" otomatik olarak oluşturulur.");
            this.checkBoxAutoSetNamesapce.UseVisualStyleBackColor = false;
            this.checkBoxAutoSetNamesapce.CheckedChanged += new System.EventHandler(this.checkBoxAutoSetNamesapce_CheckedChanged);
            // 
            // buttonGetSchemas
            // 
            this.buttonGetSchemas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGetSchemas.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonGetSchemas.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.buttonGetSchemas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonGetSchemas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonGetSchemas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetSchemas.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetSchemas.Image")));
            this.buttonGetSchemas.Location = new System.Drawing.Point(660, 69);
            this.buttonGetSchemas.Name = "buttonGetSchemas";
            this.buttonGetSchemas.Size = new System.Drawing.Size(25, 20);
            this.buttonGetSchemas.TabIndex = 10;
            this.toolTipMain.SetToolTip(this.buttonGetSchemas, "Bağlanılan veritabanında tanımlı tüm şemaları yükle.");
            this.buttonGetSchemas.UseVisualStyleBackColor = true;
            this.buttonGetSchemas.Click += new System.EventHandler(this.buttonGetSchemas_Click);
            // 
            // checkBoxPkIsIdentity
            // 
            this.checkBoxPkIsIdentity.AutoSize = true;
            this.checkBoxPkIsIdentity.BackColor = System.Drawing.Color.Black;
            this.checkBoxPkIsIdentity.Checked = true;
            this.checkBoxPkIsIdentity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPkIsIdentity.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkBoxPkIsIdentity.ForeColor = System.Drawing.Color.LightCyan;
            this.checkBoxPkIsIdentity.Location = new System.Drawing.Point(277, 12);
            this.checkBoxPkIsIdentity.Name = "checkBoxPkIsIdentity";
            this.checkBoxPkIsIdentity.Size = new System.Drawing.Size(85, 17);
            this.checkBoxPkIsIdentity.TabIndex = 2;
            this.checkBoxPkIsIdentity.Text = "PK is Identity";
            this.toolTipMain.SetToolTip(this.checkBoxPkIsIdentity, "Birincil anahtar (PK (Primary Key)), \"Identity\" olarak belirlenmiş ise bu seçeneğ" +
        "i işaretleyin.");
            this.checkBoxPkIsIdentity.UseVisualStyleBackColor = false;
            this.checkBoxPkIsIdentity.Visible = false;
            // 
            // textBoxLookupPrefix
            // 
            this.textBoxLookupPrefix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxLookupPrefix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxLookupPrefix.BackColor = System.Drawing.Color.Black;
            this.textBoxLookupPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLookupPrefix.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxLookupPrefix.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.textBoxLookupPrefix.Location = new System.Drawing.Point(610, 232);
            this.textBoxLookupPrefix.Name = "textBoxLookupPrefix";
            this.textBoxLookupPrefix.Size = new System.Drawing.Size(43, 20);
            this.textBoxLookupPrefix.TabIndex = 25;
            this.textBoxLookupPrefix.Text = "TT_";
            this.toolTipMain.SetToolTip(this.textBoxLookupPrefix, resources.GetString("textBoxLookupPrefix.ToolTip"));
            // 
            // rdbOracle
            // 
            this.rdbOracle.AutoSize = true;
            this.rdbOracle.BackColor = System.Drawing.Color.Black;
            this.rdbOracle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbOracle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbOracle.ForeColor = System.Drawing.Color.LightCyan;
            this.rdbOracle.Location = new System.Drawing.Point(210, 12);
            this.rdbOracle.Name = "rdbOracle";
            this.rdbOracle.Size = new System.Drawing.Size(67, 17);
            this.rdbOracle.TabIndex = 1;
            this.rdbOracle.Text = "ORACLE";
            this.toolTipMain.SetToolTip(this.rdbOracle, "Veritabanı tipini ORACLE yapmak için bu seçeneği işaretleyiniz.");
            this.rdbOracle.UseVisualStyleBackColor = false;
            this.rdbOracle.CheckedChanged += new System.EventHandler(this.rdbOracle_CheckedChanged);
            // 
            // rdbMsSql
            // 
            this.rdbMsSql.AutoSize = true;
            this.rdbMsSql.BackColor = System.Drawing.Color.Black;
            this.rdbMsSql.Checked = true;
            this.rdbMsSql.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdbMsSql.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rdbMsSql.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.rdbMsSql.Location = new System.Drawing.Point(136, 12);
            this.rdbMsSql.Name = "rdbMsSql";
            this.rdbMsSql.Size = new System.Drawing.Size(64, 17);
            this.rdbMsSql.TabIndex = 0;
            this.rdbMsSql.TabStop = true;
            this.rdbMsSql.Text = "MS SQL";
            this.toolTipMain.SetToolTip(this.rdbMsSql, "Veritabanı tipini MS_SQL yapmak için bu seçeneği işaretleyiniz.");
            this.rdbMsSql.UseVisualStyleBackColor = false;
            this.rdbMsSql.CheckedChanged += new System.EventHandler(this.rdbMsSql_CheckedChanged);
            // 
            // linkLabelSetNmSpsClassNames
            // 
            this.linkLabelSetNmSpsClassNames.AutoSize = true;
            this.linkLabelSetNmSpsClassNames.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.linkLabelSetNmSpsClassNames.Location = new System.Drawing.Point(136, 235);
            this.linkLabelSetNmSpsClassNames.Name = "linkLabelSetNmSpsClassNames";
            this.linkLabelSetNmSpsClassNames.Size = new System.Drawing.Size(37, 13);
            this.linkLabelSetNmSpsClassNames.TabIndex = 23;
            this.linkLabelSetNmSpsClassNames.TabStop = true;
            this.linkLabelSetNmSpsClassNames.Text = "ReSet";
            this.toolTipMain.SetToolTip(this.linkLabelSetNmSpsClassNames, resources.GetString("linkLabelSetNmSpsClassNames.ToolTip"));
            this.linkLabelSetNmSpsClassNames.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSetNmSpsClassNames_LinkClicked);
            // 
            // checkBoxSelectMultyTables
            // 
            this.checkBoxSelectMultyTables.AutoSize = true;
            this.checkBoxSelectMultyTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxSelectMultyTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxSelectMultyTables.Location = new System.Drawing.Point(525, 102);
            this.checkBoxSelectMultyTables.Name = "checkBoxSelectMultyTables";
            this.checkBoxSelectMultyTables.Size = new System.Drawing.Size(92, 17);
            this.checkBoxSelectMultyTables.TabIndex = 8;
            this.checkBoxSelectMultyTables.Text = "Multi Selection";
            this.toolTipMain.SetToolTip(this.checkBoxSelectMultyTables, "Aynı anda birden fazla tabloya ait sınıf üretmek için bu seçeneği işaretleyin ve " +
        "açılan listeden tabloları seçin.");
            this.checkBoxSelectMultyTables.UseVisualStyleBackColor = true;
            this.checkBoxSelectMultyTables.CheckedChanged += new System.EventHandler(this.checkBoxSelectMultyTables_CheckedChanged);
            // 
            // buttonConnectToDb
            // 
            this.buttonConnectToDb.BackColor = System.Drawing.Color.Transparent;
            this.buttonConnectToDb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConnectToDb.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonConnectToDb.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonConnectToDb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonConnectToDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnectToDb.Image = ((System.Drawing.Image)(resources.GetObject("buttonConnectToDb.Image")));
            this.buttonConnectToDb.Location = new System.Drawing.Point(661, 7);
            this.buttonConnectToDb.Name = "buttonConnectToDb";
            this.buttonConnectToDb.Size = new System.Drawing.Size(24, 24);
            this.buttonConnectToDb.TabIndex = 4;
            this.toolTipMain.SetToolTip(this.buttonConnectToDb, "Veritabanına bağlan ve Şemaları yükle.");
            this.buttonConnectToDb.UseVisualStyleBackColor = false;
            this.buttonConnectToDb.Click += new System.EventHandler(this.buttonConnectToDb_Click);
            // 
            // buttonGetTables
            // 
            this.buttonGetTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGetTables.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonGetTables.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.buttonGetTables.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonGetTables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonGetTables.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGetTables.Image = ((System.Drawing.Image)(resources.GetObject("buttonGetTables.Image")));
            this.buttonGetTables.Location = new System.Drawing.Point(660, 99);
            this.buttonGetTables.Name = "buttonGetTables";
            this.buttonGetTables.Size = new System.Drawing.Size(25, 20);
            this.buttonGetTables.TabIndex = 11;
            this.toolTipMain.SetToolTip(this.buttonGetTables, "Seçilen şema altındaki tüm tabloları yükle.");
            this.buttonGetTables.UseVisualStyleBackColor = true;
            this.buttonGetTables.Click += new System.EventHandler(this.buttonGetTables_Click);
            // 
            // buttonSaveConnStr
            // 
            this.buttonSaveConnStr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSaveConnStr.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonSaveConnStr.FlatAppearance.CheckedBackColor = System.Drawing.Color.Black;
            this.buttonSaveConnStr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.buttonSaveConnStr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.buttonSaveConnStr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveConnStr.Image = ((System.Drawing.Image)(resources.GetObject("buttonSaveConnStr.Image")));
            this.buttonSaveConnStr.Location = new System.Drawing.Point(660, 37);
            this.buttonSaveConnStr.Name = "buttonSaveConnStr";
            this.buttonSaveConnStr.Size = new System.Drawing.Size(24, 24);
            this.buttonSaveConnStr.TabIndex = 5;
            this.toolTipMain.SetToolTip(this.buttonSaveConnStr, "Veritabanına bağlan ve Şemaları yükle.");
            this.buttonSaveConnStr.UseVisualStyleBackColor = true;
            this.buttonSaveConnStr.Click += new System.EventHandler(this.buttonSaveConnStr_Click);
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.BackColor = System.Drawing.Color.Black;
            this.textBoxClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxClassName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxClassName.Location = new System.Drawing.Point(136, 204);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(120, 20);
            this.textBoxClassName.TabIndex = 19;
            this.toolTipMain.SetToolTip(this.textBoxClassName, "Parameter Class Name");
            this.textBoxClassName.TextChanged += new System.EventHandler(this.textBoxClassName_TextChanged);
            // 
            // textBoxInterfaceClassName
            // 
            this.textBoxInterfaceClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxInterfaceClassName.BackColor = System.Drawing.Color.Black;
            this.textBoxInterfaceClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInterfaceClassName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInterfaceClassName.ForeColor = System.Drawing.Color.SpringGreen;
            this.textBoxInterfaceClassName.Location = new System.Drawing.Point(255, 204);
            this.textBoxInterfaceClassName.Name = "textBoxInterfaceClassName";
            this.textBoxInterfaceClassName.ReadOnly = true;
            this.textBoxInterfaceClassName.Size = new System.Drawing.Size(120, 20);
            this.textBoxInterfaceClassName.TabIndex = 20;
            this.toolTipMain.SetToolTip(this.textBoxInterfaceClassName, "Interface Class Name");
            // 
            // textBoxCrudClassName
            // 
            this.textBoxCrudClassName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxCrudClassName.BackColor = System.Drawing.Color.Black;
            this.textBoxCrudClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCrudClassName.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCrudClassName.ForeColor = System.Drawing.Color.Cyan;
            this.textBoxCrudClassName.Location = new System.Drawing.Point(374, 204);
            this.textBoxCrudClassName.Name = "textBoxCrudClassName";
            this.textBoxCrudClassName.ReadOnly = true;
            this.textBoxCrudClassName.Size = new System.Drawing.Size(120, 20);
            this.textBoxCrudClassName.TabIndex = 21;
            this.toolTipMain.SetToolTip(this.textBoxCrudClassName, "Crud Class Name");
            // 
            // checkBoxAutoSetClassName
            // 
            this.checkBoxAutoSetClassName.AutoSize = true;
            this.checkBoxAutoSetClassName.BackColor = System.Drawing.Color.Black;
            this.checkBoxAutoSetClassName.Checked = true;
            this.checkBoxAutoSetClassName.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAutoSetClassName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAutoSetClassName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxAutoSetClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBoxAutoSetClassName.Location = new System.Drawing.Point(119, 208);
            this.checkBoxAutoSetClassName.Name = "checkBoxAutoSetClassName";
            this.checkBoxAutoSetClassName.Size = new System.Drawing.Size(12, 11);
            this.checkBoxAutoSetClassName.TabIndex = 136;
            this.toolTipMain.SetToolTip(this.checkBoxAutoSetClassName, "Bu seçenek işaretlendiğinde, verilen \"namespace\" adı olduğu gibi kullanılır.\r\nBu " +
        "seçenek işaretli olmadığında \"namespace\" otomatik olarak oluşturulur.");
            this.checkBoxAutoSetClassName.UseVisualStyleBackColor = false;
            this.checkBoxAutoSetClassName.CheckedChanged += new System.EventHandler(this.checkBoxAutoSetClassName_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 91;
            this.label2.Text = "Class Names ................";
            // 
            // textBoxCcSubPath2
            // 
            this.textBoxCcSubPath2.BackColor = System.Drawing.Color.DimGray;
            this.textBoxCcSubPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCcSubPath2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCcSubPath2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxCcSubPath2.Location = new System.Drawing.Point(516, 101);
            this.textBoxCcSubPath2.Name = "textBoxCcSubPath2";
            this.textBoxCcSubPath2.ReadOnly = true;
            this.textBoxCcSubPath2.Size = new System.Drawing.Size(137, 20);
            this.textBoxCcSubPath2.TabIndex = 16;
            this.textBoxCcSubPath2.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // textBoxCcSubPath1
            // 
            this.textBoxCcSubPath1.BackColor = System.Drawing.Color.Black;
            this.textBoxCcSubPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCcSubPath1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCcSubPath1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxCcSubPath1.ForeColor = System.Drawing.Color.Cyan;
            this.textBoxCcSubPath1.Location = new System.Drawing.Point(136, 101);
            this.textBoxCcSubPath1.Name = "textBoxCcSubPath1";
            this.textBoxCcSubPath1.Size = new System.Drawing.Size(382, 20);
            this.textBoxCcSubPath1.TabIndex = 15;
            this.textBoxCcSubPath1.Text = "DAL\\CCGObjects";
            this.textBoxCcSubPath1.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // labelBsSubPath
            // 
            this.labelBsSubPath.AutoSize = true;
            this.labelBsSubPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBsSubPath.Location = new System.Drawing.Point(3, 104);
            this.labelBsSubPath.Name = "labelBsSubPath";
            this.labelBsSubPath.Size = new System.Drawing.Size(131, 13);
            this.labelBsSubPath.TabIndex = 88;
            this.labelBsSubPath.Text = "Crud Class ...............";
            // 
            // textBoxProjectPath
            // 
            this.textBoxProjectPath.BackColor = System.Drawing.Color.Black;
            this.textBoxProjectPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProjectPath.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxProjectPath.ForeColor = System.Drawing.Color.Yellow;
            this.textBoxProjectPath.Location = new System.Drawing.Point(136, 14);
            this.textBoxProjectPath.Name = "textBoxProjectPath";
            this.textBoxProjectPath.Size = new System.Drawing.Size(517, 20);
            this.textBoxProjectPath.TabIndex = 12;
            this.textBoxProjectPath.Text = "C:\\dotNetProjects\\ProjectFolder";
            // 
            // labelProjectPath
            // 
            this.labelProjectPath.AutoSize = true;
            this.labelProjectPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProjectPath.ForeColor = System.Drawing.Color.Yellow;
            this.labelProjectPath.Location = new System.Drawing.Point(3, 17);
            this.labelProjectPath.Name = "labelProjectPath";
            this.labelProjectPath.Size = new System.Drawing.Size(177, 13);
            this.labelProjectPath.TabIndex = 86;
            this.labelProjectPath.Text = "Project Path ........................";
            // 
            // textBoxInterfaceSubPath1
            // 
            this.textBoxInterfaceSubPath1.BackColor = System.Drawing.Color.Black;
            this.textBoxInterfaceSubPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInterfaceSubPath1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxInterfaceSubPath1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInterfaceSubPath1.ForeColor = System.Drawing.Color.SpringGreen;
            this.textBoxInterfaceSubPath1.Location = new System.Drawing.Point(136, 50);
            this.textBoxInterfaceSubPath1.Name = "textBoxInterfaceSubPath1";
            this.textBoxInterfaceSubPath1.Size = new System.Drawing.Size(382, 20);
            this.textBoxInterfaceSubPath1.TabIndex = 13;
            this.textBoxInterfaceSubPath1.Text = "Interfaces\\CCGInterfaces";
            this.textBoxInterfaceSubPath1.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // textBoxInterfaceSubPath2
            // 
            this.textBoxInterfaceSubPath2.BackColor = System.Drawing.Color.DimGray;
            this.textBoxInterfaceSubPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxInterfaceSubPath2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxInterfaceSubPath2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxInterfaceSubPath2.Location = new System.Drawing.Point(516, 50);
            this.textBoxInterfaceSubPath2.Name = "textBoxInterfaceSubPath2";
            this.textBoxInterfaceSubPath2.ReadOnly = true;
            this.textBoxInterfaceSubPath2.Size = new System.Drawing.Size(137, 20);
            this.textBoxInterfaceSubPath2.TabIndex = 14;
            this.textBoxInterfaceSubPath2.TextChanged += new System.EventHandler(this.textBoxInterfaceNamespace_TextChanged);
            // 
            // LabelInterfaceSubPath
            // 
            this.LabelInterfaceSubPath.AutoSize = true;
            this.LabelInterfaceSubPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelInterfaceSubPath.Location = new System.Drawing.Point(3, 53);
            this.LabelInterfaceSubPath.Name = "LabelInterfaceSubPath";
            this.LabelInterfaceSubPath.Size = new System.Drawing.Size(126, 13);
            this.LabelInterfaceSubPath.TabIndex = 81;
            this.LabelInterfaceSubPath.Text = "Interface ................";
            // 
            // statusStripMain
            // 
            this.statusStripMain.AutoSize = false;
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnkLabelSaveOptions,
            this.pbrMultiProc,
            this.toolStripStatusLabelSkin,
            this.toolStripDropDownButtonSkin,
            this.labelConnectionStatus,
            this.labelConnectedDbName});
            this.statusStripMain.Location = new System.Drawing.Point(0, 680);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(713, 26);
            this.statusStripMain.TabIndex = 121;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // lnkLabelSaveOptions
            // 
            this.lnkLabelSaveOptions.Image = ((System.Drawing.Image)(resources.GetObject("lnkLabelSaveOptions.Image")));
            this.lnkLabelSaveOptions.IsLink = true;
            this.lnkLabelSaveOptions.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLabelSaveOptions.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lnkLabelSaveOptions.Name = "lnkLabelSaveOptions";
            this.lnkLabelSaveOptions.Size = new System.Drawing.Size(92, 21);
            this.lnkLabelSaveOptions.Text = "Save Settings";
            this.lnkLabelSaveOptions.Click += new System.EventHandler(this.lnkLabelSaveOptions_Click);
            // 
            // pbrMultiProc
            // 
            this.pbrMultiProc.Name = "pbrMultiProc";
            this.pbrMultiProc.Size = new System.Drawing.Size(150, 20);
            this.pbrMultiProc.Step = 1;
            this.pbrMultiProc.Visible = false;
            // 
            // toolStripDropDownButtonSkin
            // 
            this.toolStripDropDownButtonSkin.BackColor = System.Drawing.Color.Black;
            this.toolStripDropDownButtonSkin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripDropDownButtonSkin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripDropDownButtonSkin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackSkinToolStripMenuItem,
            this.standardSkinToolStripMenuItem});
            this.toolStripDropDownButtonSkin.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButtonSkin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSkin.Name = "toolStripDropDownButtonSkin";
            this.toolStripDropDownButtonSkin.Size = new System.Drawing.Size(13, 24);
            this.toolStripDropDownButtonSkin.Text = "Skin";
            this.toolStripDropDownButtonSkin.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // blackSkinToolStripMenuItem
            // 
            this.blackSkinToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.blackSkinToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.blackSkinToolStripMenuItem.Name = "blackSkinToolStripMenuItem";
            this.blackSkinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.blackSkinToolStripMenuItem.Text = "Black Skin";
            this.blackSkinToolStripMenuItem.Click += new System.EventHandler(this.blackSkinToolStripMenuItem_Click);
            // 
            // standardSkinToolStripMenuItem
            // 
            this.standardSkinToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.standardSkinToolStripMenuItem.Checked = true;
            this.standardSkinToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.standardSkinToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.standardSkinToolStripMenuItem.Name = "standardSkinToolStripMenuItem";
            this.standardSkinToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.standardSkinToolStripMenuItem.Text = "Standart Skin";
            this.standardSkinToolStripMenuItem.Click += new System.EventHandler(this.standardSkinToolStripMenuItem_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.ActiveLinkColor = System.Drawing.Color.DodgerBlue;
            this.labelConnectionStatus.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelConnectionStatus.LinkColor = System.Drawing.Color.DodgerBlue;
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(307, 21);
            this.labelConnectionStatus.Spring = true;
            this.labelConnectionStatus.Text = "Connected To";
            this.labelConnectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelConnectionStatus.VisitedLinkColor = System.Drawing.Color.DodgerBlue;
            // 
            // labelConnectedDbName
            // 
            this.labelConnectedDbName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.labelConnectedDbName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelConnectedDbName.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelConnectedDbName.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.labelConnectedDbName.Name = "labelConnectedDbName";
            this.labelConnectedDbName.Size = new System.Drawing.Size(56, 21);
            this.labelConnectedDbName.Text = "DbName";
            this.labelConnectedDbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLookupPrefix
            // 
            this.labelLookupPrefix.AutoSize = true;
            this.labelLookupPrefix.Location = new System.Drawing.Point(460, 235);
            this.labelLookupPrefix.Name = "labelLookupPrefix";
            this.labelLookupPrefix.Size = new System.Drawing.Size(149, 13);
            this.labelLookupPrefix.TabIndex = 125;
            this.labelLookupPrefix.Text = "Lookup Tables Schema Prefix";
            this.labelLookupPrefix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(3, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 120;
            this.label7.Text = "DB Type .........................";
            // 
            // linkLabelHideShow
            // 
            this.linkLabelHideShow.AutoSize = true;
            this.linkLabelHideShow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkLabelHideShow.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.linkLabelHideShow.Location = new System.Drawing.Point(624, 103);
            this.linkLabelHideShow.Name = "linkLabelHideShow";
            this.linkLabelHideShow.Size = new System.Drawing.Size(29, 13);
            this.linkLabelHideShow.TabIndex = 9;
            this.linkLabelHideShow.TabStop = true;
            this.linkLabelHideShow.Text = "Hide";
            this.linkLabelHideShow.Visible = false;
            this.linkLabelHideShow.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHideShow_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(170, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Namespace && Class Names";
            // 
            // textBoxTable
            // 
            this.textBoxTable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxTable.BackColor = System.Drawing.Color.Black;
            this.textBoxTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTable.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxTable.ForeColor = System.Drawing.Color.Gold;
            this.textBoxTable.Location = new System.Drawing.Point(136, 100);
            this.textBoxTable.Name = "textBoxTable";
            this.textBoxTable.Size = new System.Drawing.Size(382, 20);
            this.textBoxTable.TabIndex = 7;
            this.textBoxTable.TextChanged += new System.EventHandler(this.textBoxTable_TextChanged);
            this.textBoxTable.Enter += new System.EventHandler(this.textBoxTable_Enter);
            this.textBoxTable.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTable_KeyDown);
            this.textBoxTable.Leave += new System.EventHandler(this.textBoxTable_Leave);
            // 
            // textBoxSchema
            // 
            this.textBoxSchema.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBoxSchema.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxSchema.BackColor = System.Drawing.Color.Black;
            this.textBoxSchema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSchema.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxSchema.ForeColor = System.Drawing.Color.Gold;
            this.textBoxSchema.Location = new System.Drawing.Point(136, 69);
            this.textBoxSchema.Name = "textBoxSchema";
            this.textBoxSchema.Size = new System.Drawing.Size(517, 20);
            this.textBoxSchema.TabIndex = 6;
            this.textBoxSchema.TextChanged += new System.EventHandler(this.textBoxSchema_TextChanged);
            this.textBoxSchema.Enter += new System.EventHandler(this.textBoxSchema_Enter);
            this.textBoxSchema.Leave += new System.EventHandler(this.textBoxSchema_Leave);
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Location = new System.Drawing.Point(3, 103);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(151, 13);
            this.labelTable.TabIndex = 89;
            this.labelTable.Text = "Table ......................................";
            this.labelTable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelSchema
            // 
            this.labelSchema.AutoSize = true;
            this.labelSchema.Location = new System.Drawing.Point(3, 71);
            this.labelSchema.Name = "labelSchema";
            this.labelSchema.Size = new System.Drawing.Size(142, 13);
            this.labelSchema.TabIndex = 87;
            this.labelSchema.Text = "Schema ...............................";
            this.labelSchema.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxConnStr
            // 
            this.textBoxConnStr.AutoCompleteCustomSource.AddRange(new string[] {
            "Data Source=10.0.36.38;Initial Catalog=ISKUR;Integrated Security=True",
            "Data Source=10.0.36.38;Initial Catalog=ISKUR;Persist Security Info=False;Password" +
                "=pw;User ID=uid;",
            "Data Source=TRK-DEV25\\DEV2008R2;Initial Catalog=CCG_TEST;Integrated Security=True" +
                "",
            "Data Source=TRK-DEV25\\DEV2008R2;Initial Catalog=CCG_TEST;Persist Security Info=Fa" +
                "lse;Password=pw;User ID=uid;",
            "Data Source=DATASOURCE;Password=password;User id=UserID;Pooling=true;Min Pool Siz" +
                "e=50;Max Pool Size=250"});
            this.textBoxConnStr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxConnStr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxConnStr.BackColor = System.Drawing.Color.Black;
            this.textBoxConnStr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxConnStr.Font = new System.Drawing.Font("Courier New", 8.25F);
            this.textBoxConnStr.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBoxConnStr.Location = new System.Drawing.Point(136, 40);
            this.textBoxConnStr.Name = "textBoxConnStr";
            this.textBoxConnStr.Size = new System.Drawing.Size(517, 20);
            this.textBoxConnStr.TabIndex = 3;
            // 
            // labelConnStr
            // 
            this.labelConnStr.AutoSize = true;
            this.labelConnStr.BackColor = System.Drawing.Color.Transparent;
            this.labelConnStr.Location = new System.Drawing.Point(3, 44);
            this.labelConnStr.Name = "labelConnStr";
            this.labelConnStr.Size = new System.Drawing.Size(136, 13);
            this.labelConnStr.TabIndex = 85;
            this.labelConnStr.Text = "Connection String ..............";
            // 
            // panelPath
            // 
            this.panelPath.BackColor = System.Drawing.Color.Black;
            this.panelPath.Controls.Add(this.textBoxInterfaceSubPath1);
            this.panelPath.Controls.Add(this.label12);
            this.panelPath.Controls.Add(this.label11);
            this.panelPath.Controls.Add(this.label10);
            this.panelPath.Controls.Add(this.textBoxTypeNamespace);
            this.panelPath.Controls.Add(this.label9);
            this.panelPath.Controls.Add(this.textBoxCrudClassNamespace);
            this.panelPath.Controls.Add(this.label8);
            this.panelPath.Controls.Add(this.textBoxInterfaceNamespace);
            this.panelPath.Controls.Add(this.checkBoxAutoSetClassName);
            this.panelPath.Controls.Add(this.checkBoxAutoSetNamesapce);
            this.panelPath.Controls.Add(this.textBoxCrudClassName);
            this.panelPath.Controls.Add(this.textBoxInterfaceClassName);
            this.panelPath.Controls.Add(this.labelSubpathT);
            this.panelPath.Controls.Add(this.labelSubpathCC);
            this.panelPath.Controls.Add(this.labelSubPathI);
            this.panelPath.Controls.Add(this.textBoxTypeSubPath2);
            this.panelPath.Controls.Add(this.textBoxTypeSubPath1);
            this.panelPath.Controls.Add(this.labelTypeSubPath);
            this.panelPath.Controls.Add(this.LabelInterfaceSubPath);
            this.panelPath.Controls.Add(this.textBoxClassName);
            this.panelPath.Controls.Add(this.textBoxProjectPath);
            this.panelPath.Controls.Add(this.label2);
            this.panelPath.Controls.Add(this.buttonProjectPath);
            this.panelPath.Controls.Add(this.textBoxCcSubPath2);
            this.panelPath.Controls.Add(this.textBoxLookupPrefix);
            this.panelPath.Controls.Add(this.labelProjectPath);
            this.panelPath.Controls.Add(this.textBoxCcSubPath1);
            this.panelPath.Controls.Add(this.labelLookupPrefix);
            this.panelPath.Controls.Add(this.labelBsSubPath);
            this.panelPath.Controls.Add(this.textBoxInterfaceSubPath2);
            this.panelPath.Controls.Add(this.linkLabelSetNmSpsClassNames);
            this.panelPath.Controls.Add(this.labelInherit);
            this.panelPath.Controls.Add(this.textBoxInheritanceClassNameForCC);
            this.panelPath.Controls.Add(this.label6);
            this.panelPath.Controls.Add(this.groupBox3);
            this.panelPath.Location = new System.Drawing.Point(9, 142);
            this.panelPath.Name = "panelPath";
            this.panelPath.Size = new System.Drawing.Size(693, 261);
            this.panelPath.TabIndex = 129;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(611, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 27);
            this.label12.TabIndex = 144;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(611, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 27);
            this.label11.TabIndex = 143;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(69, 174);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 142;
            this.label10.Text = "Namespace";
            // 
            // textBoxTypeNamespace
            // 
            this.textBoxTypeNamespace.BackColor = System.Drawing.Color.Black;
            this.textBoxTypeNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTypeNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.textBoxTypeNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxTypeNamespace.Location = new System.Drawing.Point(136, 174);
            this.textBoxTypeNamespace.Name = "textBoxTypeNamespace";
            this.textBoxTypeNamespace.ReadOnly = true;
            this.textBoxTypeNamespace.Size = new System.Drawing.Size(517, 12);
            this.textBoxTypeNamespace.TabIndex = 141;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(68, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 140;
            this.label9.Text = "Namespace";
            // 
            // textBoxCrudClassNamespace
            // 
            this.textBoxCrudClassNamespace.BackColor = System.Drawing.Color.Black;
            this.textBoxCrudClassNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxCrudClassNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.textBoxCrudClassNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxCrudClassNamespace.Location = new System.Drawing.Point(136, 122);
            this.textBoxCrudClassNamespace.Name = "textBoxCrudClassNamespace";
            this.textBoxCrudClassNamespace.ReadOnly = true;
            this.textBoxCrudClassNamespace.Size = new System.Drawing.Size(517, 12);
            this.textBoxCrudClassNamespace.TabIndex = 139;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(68, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 138;
            this.label8.Text = "Namespace";
            // 
            // textBoxInterfaceNamespace
            // 
            this.textBoxInterfaceNamespace.BackColor = System.Drawing.Color.Black;
            this.textBoxInterfaceNamespace.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxInterfaceNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F);
            this.textBoxInterfaceNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.textBoxInterfaceNamespace.Location = new System.Drawing.Point(136, 71);
            this.textBoxInterfaceNamespace.Name = "textBoxInterfaceNamespace";
            this.textBoxInterfaceNamespace.ReadOnly = true;
            this.textBoxInterfaceNamespace.Size = new System.Drawing.Size(517, 12);
            this.textBoxInterfaceNamespace.TabIndex = 137;
            // 
            // labelSubpathT
            // 
            this.labelSubpathT.AutoSize = true;
            this.labelSubpathT.Location = new System.Drawing.Point(86, 156);
            this.labelSubpathT.Name = "labelSubpathT";
            this.labelSubpathT.Size = new System.Drawing.Size(47, 13);
            this.labelSubpathT.TabIndex = 132;
            this.labelSubpathT.Text = "Subpath";
            // 
            // labelSubpathCC
            // 
            this.labelSubpathCC.AutoSize = true;
            this.labelSubpathCC.Location = new System.Drawing.Point(86, 104);
            this.labelSubpathCC.Name = "labelSubpathCC";
            this.labelSubpathCC.Size = new System.Drawing.Size(47, 13);
            this.labelSubpathCC.TabIndex = 131;
            this.labelSubpathCC.Text = "Subpath";
            // 
            // labelSubPathI
            // 
            this.labelSubPathI.AutoSize = true;
            this.labelSubPathI.Location = new System.Drawing.Point(86, 53);
            this.labelSubPathI.Name = "labelSubPathI";
            this.labelSubPathI.Size = new System.Drawing.Size(47, 13);
            this.labelSubPathI.TabIndex = 130;
            this.labelSubPathI.Text = "Subpath";
            // 
            // textBoxTypeSubPath2
            // 
            this.textBoxTypeSubPath2.BackColor = System.Drawing.Color.DimGray;
            this.textBoxTypeSubPath2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTypeSubPath2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxTypeSubPath2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTypeSubPath2.Location = new System.Drawing.Point(516, 153);
            this.textBoxTypeSubPath2.Name = "textBoxTypeSubPath2";
            this.textBoxTypeSubPath2.ReadOnly = true;
            this.textBoxTypeSubPath2.Size = new System.Drawing.Size(137, 20);
            this.textBoxTypeSubPath2.TabIndex = 18;
            this.textBoxTypeSubPath2.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // textBoxTypeSubPath1
            // 
            this.textBoxTypeSubPath1.BackColor = System.Drawing.Color.Black;
            this.textBoxTypeSubPath1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTypeSubPath1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxTypeSubPath1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxTypeSubPath1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.textBoxTypeSubPath1.Location = new System.Drawing.Point(136, 153);
            this.textBoxTypeSubPath1.Name = "textBoxTypeSubPath1";
            this.textBoxTypeSubPath1.Size = new System.Drawing.Size(382, 20);
            this.textBoxTypeSubPath1.TabIndex = 17;
            this.textBoxTypeSubPath1.Text = "Types\\DataSets|Enumerations";
            this.textBoxTypeSubPath1.TextChanged += new System.EventHandler(this.SubPath1_TextChanged);
            // 
            // labelTypeSubPath
            // 
            this.labelTypeSubPath.AutoSize = true;
            this.labelTypeSubPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTypeSubPath.Location = new System.Drawing.Point(3, 156);
            this.labelTypeSubPath.Name = "labelTypeSubPath";
            this.labelTypeSubPath.Size = new System.Drawing.Size(101, 13);
            this.labelTypeSubPath.TabIndex = 128;
            this.labelTypeSubPath.Text = "Types ..............";
            // 
            // groupBox3
            // 
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(649, 53);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(28, 115);
            this.groupBox3.TabIndex = 135;
            this.groupBox3.TabStop = false;
            // 
            // panelDb
            // 
            this.panelDb.BackColor = System.Drawing.Color.Black;
            this.panelDb.Controls.Add(this.textBoxConnStr);
            this.panelDb.Controls.Add(this.textBoxSchema);
            this.panelDb.Controls.Add(this.textBoxTable);
            this.panelDb.Controls.Add(this.btnTest);
            this.panelDb.Controls.Add(this.buttonSaveConnStr);
            this.panelDb.Controls.Add(this.pictureBoxConnectionOk);
            this.panelDb.Controls.Add(this.pictureBoxNoConnection);
            this.panelDb.Controls.Add(this.buttonGetSchemas);
            this.panelDb.Controls.Add(this.labelConnStr);
            this.panelDb.Controls.Add(this.checkBoxPkIsIdentity);
            this.panelDb.Controls.Add(this.labelSchema);
            this.panelDb.Controls.Add(this.labelTable);
            this.panelDb.Controls.Add(this.buttonGetTables);
            this.panelDb.Controls.Add(this.buttonConnectToDb);
            this.panelDb.Controls.Add(this.rdbOracle);
            this.panelDb.Controls.Add(this.rdbMsSql);
            this.panelDb.Controls.Add(this.label7);
            this.panelDb.Controls.Add(this.checkBoxSelectMultyTables);
            this.panelDb.Controls.Add(this.linkLabelHideShow);
            this.panelDb.Location = new System.Drawing.Point(9, 6);
            this.panelDb.Name = "panelDb";
            this.panelDb.Size = new System.Drawing.Size(693, 136);
            this.panelDb.TabIndex = 130;
            // 
            // btnTest
            // 
            this.btnTest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTest.Location = new System.Drawing.Point(56, 99);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 133;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // pictureBoxConnectionOk
            // 
            this.pictureBoxConnectionOk.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxConnectionOk.Image")));
            this.pictureBoxConnectionOk.InitialImage = null;
            this.pictureBoxConnectionOk.Location = new System.Drawing.Point(638, 11);
            this.pictureBoxConnectionOk.Name = "pictureBoxConnectionOk";
            this.pictureBoxConnectionOk.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxConnectionOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxConnectionOk.TabIndex = 131;
            this.pictureBoxConnectionOk.TabStop = false;
            this.pictureBoxConnectionOk.Visible = false;
            // 
            // pictureBoxNoConnection
            // 
            this.pictureBoxNoConnection.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNoConnection.Image")));
            this.pictureBoxNoConnection.InitialImage = null;
            this.pictureBoxNoConnection.Location = new System.Drawing.Point(638, 12);
            this.pictureBoxNoConnection.Name = "pictureBoxNoConnection";
            this.pictureBoxNoConnection.Size = new System.Drawing.Size(16, 16);
            this.pictureBoxNoConnection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxNoConnection.TabIndex = 130;
            this.pictureBoxNoConnection.TabStop = false;
            this.pictureBoxNoConnection.Visible = false;
            // 
            // timerReadConnStr
            // 
            this.timerReadConnStr.Interval = 5000;
            // 
            // panelTables
            // 
            this.panelTables.BackColor = System.Drawing.Color.White;
            this.panelTables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTables.Controls.Add(this.listBoxTables);
            this.panelTables.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.panelTables.Location = new System.Drawing.Point(145, 138);
            this.panelTables.Name = "panelTables";
            this.panelTables.Size = new System.Drawing.Size(383, 23);
            this.panelTables.TabIndex = 135;
            this.panelTables.Visible = false;
            // 
            // listBoxTables
            // 
            this.listBoxTables.BackColor = System.Drawing.Color.Black;
            this.listBoxTables.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBoxTables.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.listBoxTables.FormattingEnabled = true;
            this.listBoxTables.Location = new System.Drawing.Point(-2, 1);
            this.listBoxTables.Name = "listBoxTables";
            this.listBoxTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTables.Size = new System.Drawing.Size(192, 82);
            this.listBoxTables.TabIndex = 131;
            // 
            // toolStripStatusLabelSkin
            // 
            this.toolStripStatusLabelSkin.Name = "toolStripStatusLabelSkin";
            this.toolStripStatusLabelSkin.Size = new System.Drawing.Size(47, 21);
            this.toolStripStatusLabelSkin.Text = "   Skin   ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(713, 706);
            this.Controls.Add(this.panelTables);
            this.Controls.Add(this.panelPath);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.tabControlGeneration);
            this.Controls.Add(this.panelDb);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crud Class Generator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControlGeneration.ResumeLayout(false);
            this.tabPageCCG.ResumeLayout(false);
            this.tabPageCCG.PerformLayout();
            this.groupBoxPrm.ResumeLayout(false);
            this.groupBoxPrm.PerformLayout();
            this.groupBoxTemplate.ResumeLayout(false);
            this.groupBoxTemplate.PerformLayout();
            this.groupBoxCRUD.ResumeLayout(false);
            this.groupBoxCRUD.PerformLayout();
            this.tabPageEndPoint.ResumeLayout(false);
            this.tabPageEndPoint.PerformLayout();
            this.tabPageTDG.ResumeLayout(false);
            this.tabPageTDG.PerformLayout();
            this.tabPageECG.ResumeLayout(false);
            this.tabPageECG.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.panelPath.ResumeLayout(false);
            this.panelPath.PerformLayout();
            this.panelDb.ResumeLayout(false);
            this.panelDb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNoConnection)).EndInit();
            this.panelTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region Controls
        
        private System.Windows.Forms.TabControl tabControlGeneration;
        private System.Windows.Forms.TabPage tabPageEndPoint;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonCreateStrings;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.Button buttonCleanCacheItemWeb;
        internal System.Windows.Forms.TextBox textBoxCacheItemWeb;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCleanCacheItemServer;
        internal System.Windows.Forms.TextBox textBoxCacheItemServer;
        internal System.Windows.Forms.Label labelCacheItem;
        private System.Windows.Forms.Button buttonCleanEndPoint;
        internal System.Windows.Forms.TextBox textBoxEndPoint;
        internal System.Windows.Forms.Label labelEndPoint;
        private System.Windows.Forms.Button buttonProjectPath;
        internal System.Windows.Forms.TextBox textBoxClassName;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox textBoxCcSubPath2;
        internal System.Windows.Forms.TextBox textBoxCcSubPath1;
        internal System.Windows.Forms.Label labelBsSubPath;
        internal System.Windows.Forms.TextBox textBoxProjectPath;
        internal System.Windows.Forms.Label labelProjectPath;
        internal System.Windows.Forms.TextBox textBoxInterfaceSubPath1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        internal System.Windows.Forms.TextBox textBoxInterfaceSubPath2;
        internal System.Windows.Forms.Label LabelInterfaceSubPath;
        private System.Windows.Forms.CheckBox checkBoxTemplateCc;
        private System.Windows.Forms.CheckBox checkBoxCrudCC;
        private System.Windows.Forms.CheckBox checkBoxTypedDs;
        private System.Windows.Forms.CheckBox checkBoxCreateOnlySelect;
        private System.Windows.Forms.CheckBox checkBoxAddNoLock;
        private System.Windows.Forms.CheckBox checkBoxAddServiceContract;
        private System.Windows.Forms.Button buttonGenerateMulti;
        private System.Windows.Forms.LinkLabel linkLabelGenerateTrigger;
        private System.Windows.Forms.CheckBox checkBoxAutoSetNamesapce;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripProgressBar pbrMultiProc;
        private System.Windows.Forms.RadioButton radioButtonNetNamedBinding;
        private System.Windows.Forms.RadioButton radioButtonNetTcpBinding;
        private System.Windows.Forms.RadioButton radioButtonBasicHttpBinding;
        private System.Windows.Forms.RadioButton radioButtonWsHttpBinding;
        private System.Windows.Forms.RadioButton radioButtonCustomBinding;
        internal System.Windows.Forms.TextBox textBoxInheritanceClassNameForCC;
        private System.Windows.Forms.Label labelInherit;
        internal System.Windows.Forms.TextBox textBoxInheritanceClassNameForPrm;
        internal System.Windows.Forms.Label labelPrmInheritPrmClassFrom;
        private System.Windows.Forms.TabPage tabPageTDG;
        private System.Windows.Forms.TabPage tabPageECG;
        private System.Windows.Forms.TabPage tabPageCCG;
        private System.Windows.Forms.Button buttonGetSchemas;
        private System.Windows.Forms.CheckBox checkBoxPkIsIdentity;
        internal System.Windows.Forms.TextBox textBoxLookupPrefix;
        private System.Windows.Forms.Label labelLookupPrefix;
        private System.Windows.Forms.RadioButton rdbOracle;
        private System.Windows.Forms.RadioButton rdbMsSql;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel linkLabelHideShow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkLabelSetNmSpsClassNames;
        private System.Windows.Forms.CheckBox checkBoxSelectMultyTables;
        internal System.Windows.Forms.TextBox textBoxTable;
        internal System.Windows.Forms.TextBox textBoxSchema;
        private System.Windows.Forms.Button buttonConnectToDb;
        private System.Windows.Forms.Button buttonGetTables;
        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Label labelSchema;
        private System.Windows.Forms.TextBox textBoxConnStr;
        private System.Windows.Forms.Label labelConnStr;
        private System.Windows.Forms.Panel panelPath;
        private System.Windows.Forms.Panel panelDb;
        private System.Windows.Forms.ToolStripStatusLabel labelConnectionStatus;
        private System.Windows.Forms.ToolStripStatusLabel labelConnectedDbName;
        private System.Windows.Forms.PictureBox pictureBoxConnectionOk;
        private System.Windows.Forms.PictureBox pictureBoxNoConnection;
        private System.Windows.Forms.ToolStripStatusLabel lnkLabelSaveOptions;
        private System.Windows.Forms.Button buttonSaveConnStr;
        internal System.Windows.Forms.TextBox textBoxTypeSubPath2;
        internal System.Windows.Forms.TextBox textBoxTypeSubPath1;
        internal System.Windows.Forms.Label labelTypeSubPath;
        private System.Windows.Forms.Button buttonGenerateTypeDataSet;
        internal System.Windows.Forms.TextBox textBoxAttributesNamespace;
        internal System.Windows.Forms.Label labelAttributesNamespace;
        internal System.Windows.Forms.TextBox textBoxDataSetSuffix;
        internal System.Windows.Forms.Label labelDataSetSuffix;
        private System.Windows.Forms.Timer timerReadConnStr;
        private System.Windows.Forms.CheckBox checkBoxUseEnumNameWithoutChange;
        private System.Windows.Forms.CheckBox checkBoxUseDbScript;
        private System.Windows.Forms.CheckBox checkBoxAddUnderscoreBetweenWords;
        private System.Windows.Forms.CheckBox checkBoxEnumWithDescription;
        private System.Windows.Forms.ComboBox comboBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.CheckBox checkBoxCreateOnlyConstants;
        private System.Windows.Forms.Button buttonGenerateEnumClass;
        private System.Windows.Forms.GroupBox groupBoxAyirac;
        private System.Windows.Forms.ComboBox comboBoxTextField;
        private System.Windows.Forms.Label labelTextField;
        private System.Windows.Forms.ComboBox comboBoxValueField;
        private System.Windows.Forms.Label labelValueField;
        private System.Windows.Forms.TextBox textBoxDbScript;
        private System.Windows.Forms.LinkLabel linkLabelLoadColumns;
        internal System.Windows.Forms.TextBox textBoxEnumSuffix;
        private System.Windows.Forms.Label labelEnumSuffix;
        internal System.Windows.Forms.TextBox textBoxEnumPrefix;
        private System.Windows.Forms.Label labelEnumPrefix;
        private System.Windows.Forms.Label lblPrm;
        private System.Windows.Forms.CheckBox checkBoxCrudInterface;
        private System.Windows.Forms.CheckBox checkBoxTemplateInterface;
        private System.Windows.Forms.GroupBox groupBoxPrm;
        private System.Windows.Forms.GroupBox groupBoxTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxCRUD;
        private System.Windows.Forms.Label labelCRUD;
        private System.Windows.Forms.GroupBox groupBoxInheritPrmClassFrom;
        private System.Windows.Forms.CheckBox checkBoxPrmClassInInterfaceFile;
        private System.Windows.Forms.CheckBox checkBoxPrmClassSeparate;
        private System.Windows.Forms.CheckBox checkBoxPrmClassInCCFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTest;
        internal System.Windows.Forms.Label labelSubpathT;
        internal System.Windows.Forms.Label labelSubpathCC;
        internal System.Windows.Forms.Label labelSubPathI;
        internal System.Windows.Forms.TextBox textBoxCrudClassName;
        internal System.Windows.Forms.TextBox textBoxInterfaceClassName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxAutoSetClassName;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox textBoxInterfaceNamespace;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.TextBox textBoxTypeNamespace;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.TextBox textBoxCrudClassNamespace;
        private System.Windows.Forms.Panel panelTables;
        internal System.Windows.Forms.ListBox listBoxTables;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBoxTypes;
        private System.Windows.Forms.GroupBox groupBoxCrudClass;
        private System.Windows.Forms.GroupBox groupBoxInterface;
        private System.Windows.Forms.GroupBox groupBoxProjectPath;
        private System.Windows.Forms.GroupBox groupBoxTable;
        private System.Windows.Forms.GroupBox groupBoxSchema;
        private System.Windows.Forms.GroupBox groupBoxConStr;
        private System.Windows.Forms.GroupBox groupBoxDbType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelConnStrName;
        internal System.Windows.Forms.TextBox textBoxConnectionStringName;
        private System.Windows.Forms.GroupBox groupBoxLogTable;
        internal System.Windows.Forms.Label labelLogTable;
        internal System.Windows.Forms.TextBox textBoxFullTableNameForLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSkin;
        private System.Windows.Forms.ToolStripMenuItem blackSkinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardSkinToolStripMenuItem;

        #endregion
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSkin;
        private System.Windows.Forms.CheckBox checkBoxCreateOnlySelectAsClass;
        private System.Windows.Forms.RadioButton radioButtonUseCCPath;
        private System.Windows.Forms.RadioButton radioButtonUseInterfacePath;
    }
}

