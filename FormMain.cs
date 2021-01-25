using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DtCs = CrudClassGenerator.DataTypes.CSharpDataTypes;

namespace CrudClassGenerator
{
    public partial class FormMain : Form
    {
        #region [VARIABLES] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private const string NewLine = "\r\n";
        private const string NewDblLine = "\r\n\r\n";
        private const string Tab = "\t";
        private const string TabX2 = "\t\t";

        private const string ConnStrPathFileNameSql = @"\DefConnStrSql.txt";
        private const string ConnStrPathFileNameOracle = @"\DefConnStrOracle.txt";

        private const string UserIDFieldName = "IUUserID";
        private const string ProcessTimeFieldName = "IUDate";

        private const int MinSchemaSrchChr = 1;

        private struct Settings
        {
            public const string ConnStringName = "ConnStringName";
            public const string ConnString = "ConnString";
            public const string ProjectPath = "ProjectPath";
            public const string DatabaseType = "DbType";
            public const string InheritanceClassNameForBS = "InheritanceClassNameForBS";
            public const string InheritanceClassNameForPrm = "InheritanceClassNameForPrm";
            public const string LogTableName = "LogTableNamePath";
            public const string LookupTablePrefixName = "LookupTablePrefix";
            public const string InterfaceNameSpace1 = "InterfaceNameSpace1";
            public const string BsNameSpace1 = "BsNameSpace1";
            public const string TypeNameSapce1 = "TypeNameSapce1";

            public const string ChkBoxCrudBS = "ChkBoxCrudBS";
            public const string ChkBoxCrudInterface = "ChkBoxCrudInterface";
            public const string ChkBoxPrmInBSFile = "ChkBoxPrmInBSFile";
            public const string ChkBoxPrmInInterfaceFile = "ChkBoxPrmInInterfaceFile";
            public const string ChkBoxPrmSeparate = "ChkBoxPrmSeparate";
            public const string ChkBoxTemplateBS = "ChkBoxTemplateBS";
            public const string ChkBoxTemplateInterface = "ChkBoxTemplateInterface";
            public const string ChkBoxTypedDs = "ChkBoxTypedDs";
            public const string ChkBoxCreateOnlySelect = "ChkBoxCreateOnlySelect";
            public const string ChkBoxAddNoLock = "ChkBoxAddNoLock";
            public const string ChkBoxAddServiceContract = "ChkBoxAddServiceContract";

            public const string RdBtnEndPointType = "RdBtnEndPointType";

            public const string DataSetSuffix = "DataSetSuffix";
            public const string AttributesNamespace = "AttributesNamespace";
            public const string ChkBoxUseEnumNameWithoutChange = "ChkBoxUseEnumNameWithoutChange";
            public const string ChkBoxSeparateEnumName = "ChkBoxSeparateEnumName";
            public const string ChkBoxWithDescription = "ChkBoxWithDescription";
            public const string ChkBoxCreateConstantsOnly = "ChkBoxCreateConstantsOnly";
            public const string EnumPrefix = "EnumPrefix";
            public const string EnumSuffix = "EnumSuffix";
            public const string TabControlGeneration = "TabControlGeneration";

            public const string FormSkin = "FormSkin";

            public struct DataTbl
            {
                public const string TableName = "CCGSettings";
                public const string ClmnKey = "Key";
                public const string ClmnValue = "Value";
            }
        }

        private bool HasIdentity = false;
        private string IdentityColumnName = string.Empty;
        private string IdentityColumnCsDataTypeName = string.Empty;
        private string IdentityColumnDbDataTypeName = string.Empty;
        private string PrimaryKeyName = string.Empty;
        private DataTable DTColumnsInfo = new DataTable();

        private IDataAccess Dac = null;

        private WorkingModes WorkMode = WorkingModes.ClassLibrary;

        #endregion

        #region [PROPERTIES] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string ProjectPath
        {
            get { return textBoxProjectPath.Text.Trim('\\'); }
        }

        //*** Sub Paths
        private string InterfaceSubPath1
        {
            get { return textBoxInterfaceSubPath1.Text.SetAsSubPath1(); }
        }
        private string CcSubPath1
        {
            get { return textBoxCcSubPath1.Text.SetAsSubPath1(); }
        }
        private string DsSubPath1
        {
            get { return textBoxTypeSubPath1.Text.SetAsSubPath1().Replace("|Enumerations", ""); }
        }
        private string EnumSubPath1
        {
            get { return textBoxTypeSubPath1.Text.SetAsSubPath1().Replace("DataSets|", ""); }
        }

        private string InterfaceSubPath2
        {
            get { return textBoxInterfaceSubPath2.Text.SetAsSubPath2(); }
        }
        private string CcSubPath2
        {
            get { return textBoxCcSubPath2.Text.SetAsSubPath2(); }
        }
        private string DsSubPath2
        {
            get { return textBoxTypeSubPath2.Text.SetAsSubPath2(); }
        }
        private string EnumSubPath2
        {
            get { return textBoxTypeSubPath2.Text.SetAsSubPath2(); }
        }
        //***
        private string BusinessObjects
        {
            get { return CcSubPath1.ToNamespace(); }
        }
        private string ServiceContracts
        {
            get { return InterfaceSubPath1.ToNamespace(); }
        }

        private string AppConfigPath
        {
            get { return string.Format("\\{0}\\app.config", CcSubPath1.GetPartOfStringArray('\\', 1)); }
        }

        private string ConnStrPathFileName
        {
            get { return rdbMsSql.Checked ? ConnStrPathFileNameSql : ConnStrPathFileNameOracle; }
        }
        private string ConnStr
        {
            get { return textBoxConnStr.Text; }
        }

        private DatabaseTypes DatabaseType
        {
            get { return rdbMsSql.Checked ? DatabaseTypes.MS_SQL : DatabaseTypes.ORACLE; }
        }
        private string DataBaseName
        {
            get { return Dac.DataBaseName(); }
        }
        private string DataSourceName
        {
            get { return Dac.DataSourceName(); }
        }
        private string SchemaName
        {
            get { return textBoxSchema.Text; }
            set { textBoxSchema.Text = value; }
        }
        private string TableName
        {
            get { return textBoxTable.Text; }
            set { textBoxTable.Text = value; }
        }
        private string TableFullName
        {
            get
            {
                string fullTblName = string.Empty;

                if (DatabaseType == DatabaseTypes.MS_SQL)
                {
                    fullTblName = string.Format("{0}.{1}.{2}", DataBaseName, SchemaName, TableName);
                }
                else if (DatabaseType == DatabaseTypes.ORACLE)
                {
                    fullTblName = string.Format("{0}.{1}", SchemaName, TableName);
                }

                return fullTblName;
            }
        }
        private string ConnectionStringName
        {
            get { return textBoxConnectionStringName.Text; }
            set { textBoxConnectionStringName.Text = value; }
        }

        private string ClassName
        {
            get { return textBoxClassName.Text; }
            set { textBoxClassName.Text = value; }
        }

        private string CCNameSpace
        {
            get { return string.Format("{0}{1}", CcSubPath1.ToNamespace(), CcSubPath2 != string.Empty ? "." + CcSubPath2.ToNamespace() : string.Empty); }
        }
        private string CCClassName
        {
            get { return string.Format("{0}CC", ClassName); }
        }
        private string CCClassNameGenerated
        {
            get { return string.Format("{0}.generated", CCClassName); }
        }
        private string CCClassFullName
        {
            get { return string.Format("{0}.cs", CCClassName); }
        }
        private string CCClassFullNameGenerated
        {
            get { return string.Format("{0}.cs", CCClassNameGenerated); }
        }
        private string CCPath
        {
            get { return string.Join("", ProjectPath, CcSubPath1, CcSubPath2); }
        }
        private string CCFullPath
        {
            get { return string.Join(@"\", CCPath, CCClassFullName); }
        }
        private string CCFullPathGenerated
        {
            get { return string.Join(@"\", CCPath, CCClassFullNameGenerated); }
        }

        private string DSNameSpace
        {
            get { return string.Format("{0}{1}", DsSubPath1.ToNamespace(), DsSubPath2 != string.Empty ? "." + DsSubPath2 : string.Empty); }
        }
        private string DSClassName
        {
            get { return string.Format("{0}{1}.cs", TableName, textBoxDataSetSuffix.Text); }
        }
        private string DSPath
        {
            get { return string.Join("", ProjectPath, DsSubPath1, DsSubPath2); }
        }
        private string DSFullPath
        {
            get { return string.Join(@"\", DSPath, DSClassName); }
        }

        private string EnumNameSpace
        {
            get { return string.Join(".", EnumSubPath1.ToNamespace(), EnumSubPath2.ToNamespace()); }
        }
        private string EnumClassName
        {
            get { return string.Format("{0}.cs", ClassName); }
        }
        private string EnumPath
        {
            get { return string.Join("", ProjectPath, EnumSubPath1, EnumSubPath2); }
        }
        private string EnumFullPath
        {
            get { return string.Join(@"\", EnumPath, EnumClassName); }
        }

        private string InterfaceNameSpace
        {
            get { return string.Format("{0}{1}", InterfaceSubPath1.ToNamespace(), InterfaceSubPath2 != string.Empty ? "." + InterfaceSubPath2.ToNamespace() : string.Empty); }
        }
        private string IClassName
        {
            get { return string.Format("I{0}", ClassName); }
        }
        private string IClassNameGenerated
        {
            get { return string.Format("{0}.generated", IClassName); }
        }
        private string IClassFullName
        {
            get { return string.Format("{0}.cs", IClassName); }
        }
        private string IClassFullNameGenerated
        {
            get { return string.Format("{0}.cs", IClassNameGenerated); }
        }
        private string InterfacePath
        {
            get { return string.Join("", ProjectPath, InterfaceSubPath1, InterfaceSubPath2); }
        }
        private string InterfaceFullPath
        {
            get { return string.Join(@"\", InterfacePath, IClassFullName); }
        }
        private string InterfaceFullPathGenerated
        {
            get { return string.Join(@"\", InterfacePath, IClassFullNameGenerated); }
        }

        private string PrmClassName
        {
            //get { return string.Format("{0}Prm.cs", ClassName); } //Tur: parametre sınıfına suffix eklenmek istenirse, özellik bu şekilde kullanılabilir. Eng: if desired to add suffix to Parameter class name, property can be used in this way. Hakan Keskin "23 May 2013"
            get { return string.Format("{0}.cs", ClassName); }
        }
        private string PrmClassFullPath
        {
            get { return string.Join(@"\", InterfacePath, PrmClassName); }
        }

        private string StartupPath
        {
            get { return Application.StartupPath; }
        }

        private string Partial
        {
            get { return checkBoxCrudCC.Checked ? "partial" : string.Empty; }
        }

        private string ProtectionLevel
        {
            get { return WorkMode == WorkingModes.WCF ? "internal" : "public"; }
        }

        private string FullAppConfigPath
        {
            get { return string.Join("", ProjectPath, AppConfigPath); }
        }

        private string LookupTablePrefix
        {
            get { return textBoxLookupPrefix.Text; }
        }

        private string EndPoint_name
        {
            get { return string.Join(".", BusinessObjects, CcSubPath2.ToNamespace(), string.Join("", ClassName, "BS")); }
        }
        private string EndPoint_contract
        {
            get { return string.Join(".", ServiceContracts, InterfaceSubPath2.ToNamespace(), string.Join("", "I", ClassName)); }
        }
        private string EndPoint_address
        {
            get
            {
                string adress = string.Empty;
                if (radioButtonNetNamedBinding.Checked) adress = "net.pipe";
                else if (radioButtonNetTcpBinding.Checked) adress = "net.tcp";
                else if (radioButtonBasicHttpBinding.Checked) adress = "http";
                else if (radioButtonWsHttpBinding.Checked) adress = "http";
                else if (radioButtonCustomBinding.Checked) adress = "net.tcp";
                return string.Format("{0}://localhost/WcfServices/I{1}", adress, ClassName);
            }
        }
        private string EndPoint_binding
        {
            get
            {
                string binding = string.Empty;
                if (radioButtonNetNamedBinding.Checked) binding = "netNamedPipeBinding";
                else if (radioButtonNetTcpBinding.Checked) binding = "netTcpBinding";
                else if (radioButtonBasicHttpBinding.Checked) binding = "basicHttpBinding";
                else if (radioButtonWsHttpBinding.Checked) binding = "wsHttpBinding";
                else if (radioButtonCustomBinding.Checked) binding = "customBinding";
                return binding;
            }
        }
        private string EndPoint_bindingConfiguration
        {
            get
            {
                string bConfiguration = string.Empty;
                if (radioButtonNetNamedBinding.Checked) bConfiguration = "DefaultNamedPipeBinding";
                else if (radioButtonNetTcpBinding.Checked) bConfiguration = "DefaultTcpBinding";
                else if (radioButtonBasicHttpBinding.Checked) bConfiguration = "DefaultHttpBinding";
                else if (radioButtonWsHttpBinding.Checked) bConfiguration = "DefaultHttpBinding";
                else if (radioButtonCustomBinding.Checked) bConfiguration = "WcfCustomBinding";
                return bConfiguration;
            }
        }

        private string TriggerPath
        {
            get { return string.Join("", ProjectPath, @"\TriggerScripts\", SchemaName); }
        }
        private string TriggerName
        {
            get { return string.Join("", "utgLog", TableName); }
        }
        private string FullTriggerPath
        {
            get { return string.Format(@"{0}\{1}.sql", TriggerPath, TriggerName); }
        }

        private string SelectedSchema { get; set; }

        private string TableSearchCriteria { get; set; }

        private bool AllTablesLoaded { get; set; }

        private const int mMinTableSrchChr = 3;
        private const int mMinTableSrchChr2 = 1;
        private string MinTableSrchChr { get { return AllTablesLoaded ? mMinTableSrchChr2.ToString() : mMinTableSrchChr.ToString(); } }

        public string FrmSkinMode
        {
            get
            {
                string skinMode = ConfigurationManager.AppSettings["SkinMode"];
                if (skinMode == SkinMode.Standard)
                    return SkinMode.Standard;
                else if (skinMode == SkinMode.Black)
                    return SkinMode.Black;
                else
                    return SkinMode.Standard;
            }
        }

        #endregion

        //===============================================================================================================

        #region [PAGE EVENTS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public FormMain()
        {
            if (FrmSkinMode == SkinMode.Standard)
                InitializeComponent();
            else if (FrmSkinMode == SkinMode.Black)
                InitializeComponent_Black();
            else
                InitializeComponent();

            this.Text = string.Join(" - Version: ", this.Text, GetVersion());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            GetRegionalSettings();
            ReadAndSetSettings();
            ReadAndSetSettings();
            ReadSkinType();
            SetWorkingType();
            SetTooltips();

            OpenConnectionAndLoadSchemas();
        }

        private void ReadSkinType()
        {
            string skinMode = ConfigurationManager.AppSettings["SkinMode"];

            if (FrmSkinMode == SkinMode.Standard)
            {
                standardSkinToolStripMenuItem.Checked = true;
                blackSkinToolStripMenuItem.Checked = false;
            }
            else if (FrmSkinMode == SkinMode.Black)
            {
                standardSkinToolStripMenuItem.Checked = false;
                blackSkinToolStripMenuItem.Checked = true;
            }
            else
            {
                standardSkinToolStripMenuItem.Checked = true;
                blackSkinToolStripMenuItem.Checked = false;
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ShowValueOfSomeProperties();
        }
        private void ShowValueOfSomeProperties()
        {
            string s = string.Format(@"
                ProjectPath: {0}
                InterfaceSubPath1: {1}
                BsSubPath1: {2}
                DsSubPath1: {3}
                EnumSubPath1: {4}
                InterfaceSubPath2: {5}
                BsSubPath2: {6}
                DsSubPath2: {7}
                EnumSubPath2: {8}
                BusinessObjects: {9}
                ServiceContracts: {10}
                AppConfigPath: {11}
                BSNameSpace: {12}
                BSPath: {13}
                DSNameSpace: {14}
                DSPath: {15}
                EnumNameSpace: {16}
                EnumPath: {17}
                InterfaceNameSpace: {18}
                InterfacePath: {19}
                ",
                 ProjectPath + Environment.NewLine,
                 InterfaceSubPath1 + Environment.NewLine,
                 CcSubPath1 + Environment.NewLine,
                 DsSubPath1 + Environment.NewLine,
                 EnumSubPath1 + Environment.NewLine,
                 InterfaceSubPath2 + Environment.NewLine,
                 CcSubPath2 + Environment.NewLine,
                 DsSubPath2 + Environment.NewLine,
                 EnumSubPath2 + Environment.NewLine,
                 BusinessObjects + Environment.NewLine,
                 ServiceContracts + Environment.NewLine,
                 AppConfigPath + Environment.NewLine,
                 CCNameSpace + Environment.NewLine,
                 CCPath + Environment.NewLine,
                 DSNameSpace + Environment.NewLine,
                 DSPath + Environment.NewLine,
                 EnumNameSpace + Environment.NewLine,
                 EnumPath + Environment.NewLine,
                 InterfaceNameSpace + Environment.NewLine,
                 InterfacePath
                 );

            s = s.Replace(" ", "").Replace("  ", "");//.Replace("|",new string(' ',20) );
            //MessageBox.Show(s);

            string fileName = "Properties.txt";
            WriteFile(s, StartupPath, StartupPath + fileName);
            System.Diagnostics.Process.Start(StartupPath + fileName);

        }

        #endregion

        #region [CONTROL EVENTS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void rdbMsSql_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMsSql.Checked)
            {
                checkBoxPkIsIdentity.Visible = false;
                textBoxConnStr.Text = string.Empty;
                textBoxConnectionStringName.Text = string.Empty;
                textBoxConnectionStringName.ForeColor = Color.Chocolate;
                GetConnStr();
                if (textBoxConnectionStringName.Text == string.Empty)
                    textBoxConnectionStringName.Text = "ConnStrSql";
            }
        }

        private void rdbOracle_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbOracle.Checked)
            {
                checkBoxPkIsIdentity.Visible = true;
                textBoxConnStr.Text = string.Empty;
                textBoxConnectionStringName.Text = string.Empty;
                textBoxConnectionStringName.ForeColor = Color.DarkGreen;
                GetConnStr();
                if (textBoxConnectionStringName.Text == string.Empty)
                    textBoxConnectionStringName.Text = "ConnStrOracle";
            }
        }

        private void buttonSaveConnStr_Click(object sender, EventArgs e)
        {
            if (textBoxConnStr.Text == string.Empty)
            {
                MessageBox.Show(Message.MandatoryConStr, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string fullPath = string.Join("", StartupPath, ConnStrPathFileName);
            TextWriter tw = new StreamWriter(fullPath, false, Encoding.Default);
            string CnnStrAndName = string.Join("|", textBoxConnStr.Text, textBoxConnectionStringName.Text);
            tw.WriteLine(CnnStrAndName);
            tw.Close();
            MessageBox.Show(Message.DefConnStrSaved, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonGenerateMulti_Click(object sender, EventArgs e)
        {
            GenerateMulti();
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            if (!IsSchemaAndTableSelected()) return;
            Generate();
        }

        private void lnkLabelSaveOptions_Click(object sender, EventArgs e)
        {
            WriteSettings();
        }

        private void buttonCreateStrings_Click(object sender, EventArgs e)
        {
            if (!GeneralValidation()) return;

            CreateEndPointString();
            CreateCacheItemStrings();
        }

        private void buttonConnectToDb_Click(object sender, EventArgs e)
        {
            if (OpenConnectionAndLoadSchemas())
                MessageBox.Show(Message.DbConnOk, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonGetSchemas_Click(object sender, EventArgs e)
        {
            LoadSchemas();
            MessageBox.Show(Message.SchemasLoaded, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonGetTables_Click(object sender, EventArgs e)
        {
            LoadTables();
        }

        private void checkBoxSelectMultyTables_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxSelectMultyTables.Checked)
            {
                linkLabelHideShow.Text = string.Empty;
                panelTables.Visible = false;
                return;
            }

            if (!IsSchemaSelected())
            {
                checkBoxSelectMultyTables.Checked = false;
                return;
            }

            listBoxTables.DataSource = null;
            listBoxTables.Items.Clear();
            if (checkBoxSelectMultyTables.Checked)
            {
                string filter = TableName.SubstringExt(0, 1) == "-" ? string.Empty : TableName;
                DataRow[] oDrw = GetTables().Select(string.Format("TableName LIKE '{0}%'", filter));
                if (oDrw.Length == 0) return;
                DataTable oDt = oDrw.CopyToDataTable();

                if (oDt.Rows.Count > 0)
                {
                    listBoxTables.DisplayMember = "TableName";
                    listBoxTables.ValueMember = "TableId";
                    listBoxTables.DataSource = oDt;
                    listBoxTables.Refresh();
                }
                else
                {
                    checkBoxSelectMultyTables.Checked = false;
                    MessageBox.Show(Message.NoTableForThisSchema, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            ListVisibility();
        }

        private bool IsSchemaSelected()
        {
            if (SchemaName == string.Empty || SchemaName.SubstringExt(0, 1) == "-")
            {
                MessageBox.Show(Message.NoSchemaSelected, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsTableSelected()
        {
            if (TableName == string.Empty || TableName.SubstringExt(0, 1) == "-")
            {
                MessageBox.Show(Message.NoTableSelected, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool IsSchemaAndTableSelected()
        {
            if (!IsSchemaSelected()) return false;
            if (!checkBoxSelectMultyTables.Checked && !IsTableSelected()) return false;
            return true;
        }

        private void buttonTargetPath_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBoxProjectPath.Text = folderBrowserDialog1.SelectedPath;
        }

        private void textBoxInterfaceNamespace_TextChanged(object sender, EventArgs e)
        {
            textBoxCcSubPath2.Text = textBoxInterfaceSubPath2.Text;
            textBoxTypeSubPath2.Text = textBoxInterfaceSubPath2.Text;

            ShowNamespaces();
        }

        private void SubPath1_TextChanged(object sender, EventArgs e)
        {
            ShowNamespaces();
        }

        private void ShowNamespaces()
        {
            textBoxInterfaceNamespace.Text = InterfaceNameSpace;
            textBoxCrudClassNamespace.Text = CCNameSpace;
            textBoxTypeNamespace.Text = DSNameSpace;

            this.toolTipMain.SetToolTip(textBoxInterfaceNamespace, InterfaceNameSpace);
            this.toolTipMain.SetToolTip(textBoxCrudClassNamespace, CCNameSpace);
            this.toolTipMain.SetToolTip(textBoxTypeNamespace, DSNameSpace);

            //string interfaceNameSpace = string.Format("Interface Namespace:\r\n{0}", InterfaceNameSpace);
            //string ccNameSpace = string.Format("Crud Class Namespace:\r\n{0}", CCNameSpace);
            //string typeNameSpace = string.Format("Enum/Dataset Namespace:\r\n{0}", DSNameSpace);

            //this.toolTipMain.SetToolTip(textBoxInterfaceSubPath1, interfaceNameSpace);
            //this.toolTipMain.SetToolTip(textBoxCcSubPath1, ccNameSpace);
            //this.toolTipMain.SetToolTip(textBoxTypeSubPath1, typeNameSpace);

            //this.toolTipMain.SetToolTip(textBoxInterfaceSubPath2, interfaceNameSpace);
            //this.toolTipMain.SetToolTip(textBoxCcSubPath2, ccNameSpace);
            //this.toolTipMain.SetToolTip(textBoxTypeSubPath2, typeNameSpace);
        }

        private void buttonCleanEndPoint_Click(object sender, EventArgs e)
        {
            textBoxEndPoint.Text = string.Empty;
        }

        private void buttonCleanCacheItemServer_Click(object sender, EventArgs e)
        {
            textBoxCacheItemServer.Text = string.Empty;
        }

        private void buttonCleanCacheItemWeb_Click(object sender, EventArgs e)
        {
            textBoxCacheItemWeb.Text = string.Empty;
        }

        private void textBoxSchema_Leave(object sender, EventArgs e)
        {
            if (textBoxSchema.Text == string.Empty)
            {
                if (!checkBoxSelectMultyTables.Checked)
                {
                    //MessageBox.Show(Message.MandatorySchemaAndTable, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxSchema.SetTextBoxLeaveMod(string.Format(Message.SearchChrCount, MinSchemaSrchChr));
                }
            }
            else
            {
                if (SelectedSchema != SchemaName) textBoxTable.AutoCompleteCustomSource.Clear();
            }
        }

        private void textBoxSchema_Enter(object sender, EventArgs e)
        {
            textBoxSchema.SetTextBoxEnterMod();
        }

        private void textBoxTable_Leave(object sender, EventArgs e)
        {
            if (textBoxTable.Text == string.Empty)
            {
                if (!checkBoxSelectMultyTables.Checked)
                {
                    //MessageBox.Show(Message.MandatorySchemaAndTable, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    if (textBoxSchema.Text == string.Empty || textBoxSchema.Text.SubstringExt(0, 1) == "-")
                    {
                        textBoxTable.ShowInfoMessageOnTextBox(Message.SelectSchemaFirst);
                    }
                    else
                    {
                        textBoxTable.SetTextBoxLeaveMod(string.Format(Message.SearchChrCount, MinTableSrchChr));
                    }
                }
            }
        }

        private void textBoxTable_Enter(object sender, EventArgs e)
        {
            textBoxTable.SetTextBoxEnterMod();
        }

        private void checkBoxCrud_CheckedChanged(object sender, EventArgs e)
        {
            bool b = checkBoxCrudCC.Checked;
            groupBoxLogTable.Visible = b;
            groupBoxInheritPrmClassFrom.Visible = b;

            checkBoxAddNoLock.Visible = b;
            checkBoxCreateOnlySelect.Visible = b;
            //checkBoxTypedDs.Visible = b;

            if (!b) checkBoxPrmClassInCCFile.Checked = b;
        }

        private void checkBoxCrudInterface_CheckedChanged(object sender, EventArgs e)
        {
            bool b = checkBoxCrudInterface.Checked;
            checkBoxAddServiceContract.Visible = b;
            if (!b) checkBoxPrmClassInInterfaceFile.Checked = b;
        }

        private void linkLabelSetNmSpsClassNames_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SetNameSpaces() && SetClassName())
                MessageBox.Show(Message.ResetOk, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show(Message.MandatorySchemaAndTable, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool SetNameSpaces()
        {
            if (!SchemaName.IsEmpty() && checkBoxAutoSetNamesapce.Checked)
            {
                textBoxInterfaceSubPath2.Text = ProperCase(SchemaName);
                textBoxCcSubPath2.Text = textBoxInterfaceSubPath2.Text;
                textBoxTypeSubPath2.Text = textBoxInterfaceSubPath2.Text;
                return true;
            }
            return false;
        }

        private void textBoxSchema_TextChanged(object sender, EventArgs e)
        {
            SetNameSpaces();
        }

        private void textBoxTable_TextChanged(object sender, EventArgs e)
        {
            SetClassName();
            LoadTablesViaSearchCriteria();
        }

        private void textBoxTable_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadTableColumns();
            }
        }

        private void checkBoxAddServiceContract_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAddServiceContract.Checked)
            {
                checkBoxTemplateInterface.Checked = false;
            }
        }

        private void checkBoxInterfaceTemplate_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTemplateInterface.Checked)
            {
                checkBoxAddServiceContract.Checked = false;
            }
            else
            {
                checkBoxAddServiceContract.Checked = true;
            }
        }

        private void linkLabelHideShow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelHideShow.Text == "Hide")
            {
                linkLabelHideShow.Text = "Show";
                panelTables.Visible = false;
            }
            else
            {
                linkLabelHideShow.Text = "Hide";
                panelTables.Visible = true;

            }
        }

        private void PrmClassTypeChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;

            if (chk.Checked)
            {
                if (sender != checkBoxPrmClassInInterfaceFile) checkBoxPrmClassInInterfaceFile.Checked = false; else checkBoxCrudInterface.Checked = true;
                if (sender != checkBoxPrmClassInCCFile) checkBoxPrmClassInCCFile.Checked = false; else checkBoxCrudCC.Checked = true;
                if (sender != checkBoxPrmClassSeparate) checkBoxPrmClassSeparate.Checked = false;
            }
        }

        private void textBoxClassName_TextChanged(object sender, EventArgs e)
        {
            textBoxInterfaceClassName.Text = IClassName;
            textBoxCrudClassName.Text = CCClassName;
        }

        private void checkBoxAutoSetNamesapce_CheckedChanged(object sender, EventArgs e)
        {
            bool readOnly = false;
            Color color = Color.White;

            if (checkBoxAutoSetNamesapce.Checked)
            {
                readOnly = true;
                color = Color.WhiteSmoke;
                SetNameSpaces();
            }

            textBoxInterfaceSubPath2.ReadOnly = readOnly;
            textBoxCcSubPath2.ReadOnly = readOnly;
            textBoxTypeSubPath2.ReadOnly = readOnly;

            textBoxInterfaceSubPath2.BackColor = color;
            textBoxCcSubPath2.BackColor = color;
            textBoxTypeSubPath2.BackColor = color;
        }

        private void checkBoxAutoSetClassName_CheckedChanged(object sender, EventArgs e)
        {
            SetClassName();
        }

        private bool SetClassName()
        {
            if (TableName.IsEmpty())
            {
                textBoxClassName.Text = string.Empty;
                return false;
            }
            else
            {
                textBoxClassName.Text = checkBoxAutoSetClassName.Checked ? ProperCase(TableName) : TableName;
                return true;
            }
        }

        #endregion

        #region [PROGRESSBAR] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetProgressBar(int pMaxValue)
        {
            SetProgressBar(pMaxValue, 0);
        }
        private void SetProgressBar(int pMaxValue, int pValue)
        {
            pbrMultiProc.Visible = true;
            pbrMultiProc.Maximum = pMaxValue;
            pbrMultiProc.Value = pValue;
        }
        private void RunProgressBar()
        {
            if (pbrMultiProc.Value < pbrMultiProc.Maximum) pbrMultiProc.Value += 1;
        }
        private void CloseProgressBar()
        {
            pbrMultiProc.Value = 0;
            pbrMultiProc.Visible = false;
        }

        #endregion

        #region [GET, SET and LOAD METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void GetConnStr()
        {
            string fullPath = string.Join("", StartupPath, ConnStrPathFileName);
            if (File.Exists(fullPath))
            {
                TextReader tr = new StreamReader(fullPath, Encoding.Default);
                string cnnStrAndName = tr.ReadLine();
                textBoxConnStr.Text = cnnStrAndName.Split('|').GetValue(0).ToString();
                textBoxConnectionStringName.Text = cnnStrAndName.Split('|').GetValue(1).ToString();
                tr.Close();
            }
        }

        private void GetDataAccessObject()
        {
            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                SqlDataAccess sqldac = new SqlDataAccess();
                Dac = (IDataAccess)sqldac;
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                OracleDataAccess oracledac = new OracleDataAccess();
                Dac = (IDataAccess)oracledac;
            }
        }

        private void GetRegionalSettings()
        {
            string regName = RegionInfo.CurrentRegion.Name;
            Language.LangTr = regName == "TR" ? true : false;
        }

        private bool OpenConnectionAndLoadSchemas()
        {
            textBoxSchema.AutoCompleteCustomSource.Clear();
            textBoxTable.AutoCompleteCustomSource.Clear();

            if (textBoxConnStr.Text == string.Empty) GetConnStr();
            if (textBoxConnStr.Text == string.Empty)
            {
                MessageBox.Show(Message.NoDbConnString, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DbConnFailed();
                return false;
            }

            GetDataAccessObject();

            try
            {
                Dac.GetConnection(ConnStr);
                DbConnSuccessful();
                return true;
            }
            catch (Exception exc)
            {
                DbConnFailed();
                throw exc; ;
            }
        }

        private void DbConnSuccessful()
        {
            LoadSchemas();
            labelConnectionStatus.ForeColor = Color.DodgerBlue;
            labelConnectionStatus.Text = "Connected To";
            labelConnectedDbName.Text = DatabaseType == DatabaseTypes.MS_SQL ? string.Join(" / ", DataSourceName, DataBaseName) : string.Join(" / ", DataBaseName, DataSourceName);
            labelConnectedDbName.Visible = true;
            pictureBoxConnectionOk.Visible = true;
            pictureBoxNoConnection.Visible = false;
        }

        private void DbConnFailed()
        {
            labelConnectionStatus.ForeColor = Color.IndianRed;
            labelConnectionStatus.Text = "DataBase Connection Failed !";
            labelConnectedDbName.Text = string.Empty;
            pictureBoxConnectionOk.Visible = false;
            pictureBoxNoConnection.Visible = true;
        }

        private void LoadSchemas()
        {
            DataTable oDt = Dac.LoadSchemas();
            textBoxSchema.AutoCompleteCustomSource.Clear();

            SetProgressBar(oDt.Rows.Count);
            textBoxSchema.Visible = false;

            foreach (DataRow rw in oDt.Rows)
            {
                textBoxSchema.AutoCompleteCustomSource.Add(rw["SchemaName"].ToString());

                RunProgressBar();
            }

            CloseProgressBar();

            textBoxSchema.Visible = true;
            textBoxSchema.SetTextBoxLeaveMod(string.Format(Message.SearchChrCount, "1"));
            textBoxTable.ShowInfoMessageOnTextBox(Message.SelectSchemaFirst);
            textBoxSchema.Focus();
        }

        private void LoadTables()
        {
            if (textBoxSchema.Text.SubstringExt(0, 1) == "-")
            {
                MessageBox.Show(Message.MandatorySchemaAndTable, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable oDt = GetTables();

            textBoxTable.Visible = false;

            textBoxTable.AutoCompleteCustomSource.Clear();
            AddTableListToAutoCompleteCustomSource(oDt);
            AllTablesLoaded = true;

            MessageBox.Show(Message.TablesLoaded, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            textBoxTable.SetTextBoxLeaveMod(string.Format(Message.SearchChrCount, MinTableSrchChr), true);
            textBoxTable.Enabled = true;
            textBoxTable.Visible = true;
        }

        private void LoadTablesViaSearchCriteria()
        {
            if (textBoxTable.Text.Length < 3 || textBoxTable.Text.SubstringExt(0, 1) == "-") return;

            string search = string.Format("TableName LIKE '{0}%'", textBoxTable.Text.ToUpper(CultureInfo.CreateSpecificCulture("En")));
            if (SelectedSchema == SchemaName && search == TableSearchCriteria) return;
            TableSearchCriteria = search;

            DataRow[] oDrw = GetTables().Select(search);
            if (oDrw.Length == 0) return;
            DataTable oDt = oDrw.CopyToDataTable();

            AddTableListToAutoCompleteCustomSource(oDt);
            AllTablesLoaded = false;

            textBoxTable.Enabled = true;
        }

        private void AddTableListToAutoCompleteCustomSource(DataTable pDt)
        {
            textBoxTable.AutoCompleteCustomSource.Clear();
            SetProgressBar(pDt.Rows.Count);

            foreach (DataRow rw in pDt.Rows)
            {
                textBoxTable.AutoCompleteCustomSource.Add(rw["TableName"].ToString());

                RunProgressBar();
            }

            CloseProgressBar();
        }

        private DataTable GetTables()
        {
            SelectedSchema = SchemaName;
            return Dac.GetTables(SchemaName);
        }

        private void ListVisibility()
        {
            if (checkBoxSelectMultyTables.Checked)
            {
                listBoxTables.Width = textBoxTable.Width;
                listBoxTables.Height = 180;
                listBoxTables.BackColor = DatabaseType == DatabaseTypes.MS_SQL ? rdbMsSql.BackColor : rdbOracle.BackColor;
                panelTables.Visible = true;
                panelTables.Width = listBoxTables.Width;
                panelTables.Height = listBoxTables.Height;
                panelTables.Location = new Point(146, 119);
                linkLabelHideShow.Visible = true;
                linkLabelHideShow.Text = "Hide";
                buttonGenerateMulti.Visible = true;
                buttonGenerate.Visible = false;
            }
            else
            {
                panelTables.Visible = false;
                linkLabelHideShow.Visible = false;
                buttonGenerateMulti.Visible = false;
                buttonGenerate.Visible = true;
            }
        }

        #endregion

        #region [SETTINGS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void ReadAndSetSettings()
        {
            string fullPath = string.Join("", StartupPath, "\\", Settings.DataTbl.TableName, ".xml");
            if (!File.Exists(fullPath)) return;

            DataTable oDt = CreateDatatableForSettings();
            oDt.ReadXml(fullPath);

            string key = string.Empty;
            string value = string.Empty;

            foreach (DataRow oDrw in oDt.Rows)
            {
                key = oDrw[Settings.DataTbl.ClmnKey].ToString();
                value = oDrw[Settings.DataTbl.ClmnValue].ToString();

                switch (key)
                {
                    case Settings.DatabaseType:
                        if (value == DatabaseTypeName.MS_SQL)
                            rdbMsSql.Checked = true;
                        else rdbOracle.Checked = true;
                        break;

                    case Settings.ConnStringName:
                        textBoxConnectionStringName.Text = value;
                        break;

                    case Settings.ConnString:
                        textBoxConnStr.Text = value;
                        break;

                    case Settings.InheritanceClassNameForBS:
                        textBoxInheritanceClassNameForCC.Text = value;
                        break;

                    case Settings.ProjectPath:
                        textBoxProjectPath.Text = value;
                        break;

                    case Settings.LookupTablePrefixName:
                        textBoxLookupPrefix.Text = value;
                        break;

                    case Settings.InheritanceClassNameForPrm:
                        textBoxInheritanceClassNameForPrm.Text = value;
                        break;

                    case Settings.LogTableName:
                        textBoxFullTableNameForLog.Text = value;
                        break;

                    case Settings.ChkBoxCrudBS:
                        checkBoxCrudCC.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxCrudInterface:
                        checkBoxCrudInterface.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxPrmInBSFile:
                        checkBoxPrmClassInCCFile.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxPrmInInterfaceFile:
                        checkBoxPrmClassInInterfaceFile.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxPrmSeparate:
                        checkBoxPrmClassSeparate.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxTemplateBS:
                        checkBoxTemplateCc.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxTemplateInterface:
                        checkBoxTemplateInterface.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxTypedDs:
                        checkBoxTypedDs.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxCreateOnlySelect:
                        checkBoxCreateOnlySelect.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxAddNoLock:
                        checkBoxAddNoLock.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxAddServiceContract:
                        checkBoxAddServiceContract.Checked = value.ToBool();
                        break;

                    case Settings.RdBtnEndPointType:
                        SetEndPointType(value.ToInt());
                        break;

                    case Settings.DataSetSuffix:
                        textBoxDataSetSuffix.Text = value;
                        break;

                    case Settings.AttributesNamespace:
                        textBoxAttributesNamespace.Text = value;
                        break;

                    case Settings.ChkBoxUseEnumNameWithoutChange:
                        checkBoxUseEnumNameWithoutChange.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxSeparateEnumName:
                        checkBoxAddUnderscoreBetweenWords.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxWithDescription:
                        checkBoxEnumWithDescription.Checked = value.ToBool();
                        break;

                    case Settings.ChkBoxCreateConstantsOnly:
                        checkBoxCreateOnlyConstants.Checked = value.ToBool();
                        break;

                    case Settings.EnumPrefix:
                        textBoxEnumPrefix.Text = value;
                        break;

                    case Settings.EnumSuffix:
                        textBoxEnumSuffix.Text = value;
                        break;

                    case Settings.TabControlGeneration:
                        tabControlGeneration.SelectedIndex = value.ToInt();
                        break;

                    case Settings.InterfaceNameSpace1:
                        textBoxInterfaceSubPath1.Text = value;
                        break;

                    case Settings.BsNameSpace1:
                        textBoxCcSubPath1.Text = value;
                        break;

                    case Settings.TypeNameSapce1:
                        textBoxTypeSubPath1.Text = value;
                        break;

                    default:
                        break;
                }
            }
        }

        private void WriteSettings()
        {
            string clmnKey = Settings.DataTbl.ClmnKey;
            string clmnValue = Settings.DataTbl.ClmnValue;

            DataTable oDt = CreateDatatableForSettings();
            DataRow oDr = null;

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.DatabaseType;
            oDr[clmnValue] = rdbMsSql.Checked ? DatabaseTypeName.MS_SQL : DatabaseTypeName.ORACLE;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ConnStringName;
            oDr[clmnValue] = textBoxConnectionStringName.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ConnString;
            oDr[clmnValue] = textBoxConnStr.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.InheritanceClassNameForBS;
            oDr[clmnValue] = textBoxInheritanceClassNameForCC.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ProjectPath;
            oDr[clmnValue] = textBoxProjectPath.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.LookupTablePrefixName;
            oDr[clmnValue] = textBoxLookupPrefix.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.LogTableName;
            oDr[clmnValue] = textBoxFullTableNameForLog.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.InheritanceClassNameForPrm;
            oDr[clmnValue] = textBoxInheritanceClassNameForPrm.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxCrudBS;
            oDr[clmnValue] = checkBoxCrudCC.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxCrudInterface;
            oDr[clmnValue] = checkBoxCrudInterface.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxPrmInBSFile;
            oDr[clmnValue] = checkBoxPrmClassInCCFile.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxPrmInInterfaceFile;
            oDr[clmnValue] = checkBoxPrmClassInInterfaceFile.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxPrmSeparate;
            oDr[clmnValue] = checkBoxPrmClassSeparate.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxTemplateBS;
            oDr[clmnValue] = checkBoxTemplateCc.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxTemplateInterface;
            oDr[clmnValue] = checkBoxTemplateInterface.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxTypedDs;
            oDr[clmnValue] = checkBoxTypedDs.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxCreateOnlySelect;
            oDr[clmnValue] = checkBoxCreateOnlySelect.Checked ? 1 : 0; ;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxAddNoLock;
            oDr[clmnValue] = checkBoxAddNoLock.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxAddServiceContract;
            oDr[clmnValue] = checkBoxAddServiceContract.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.RdBtnEndPointType;
            oDr[clmnValue] = GetEndPointType();
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.DataSetSuffix;
            oDr[clmnValue] = textBoxDataSetSuffix.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.AttributesNamespace;
            oDr[clmnValue] = textBoxAttributesNamespace.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxUseEnumNameWithoutChange;
            oDr[clmnValue] = checkBoxUseEnumNameWithoutChange.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxSeparateEnumName;
            oDr[clmnValue] = checkBoxAddUnderscoreBetweenWords.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxWithDescription;
            oDr[clmnValue] = checkBoxEnumWithDescription.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.ChkBoxCreateConstantsOnly;
            oDr[clmnValue] = checkBoxCreateOnlyConstants.Checked ? 1 : 0;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.EnumPrefix;
            oDr[clmnValue] = textBoxEnumPrefix.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.EnumSuffix;
            oDr[clmnValue] = textBoxEnumSuffix.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.TabControlGeneration;
            oDr[clmnValue] = tabControlGeneration.SelectedIndex.ToString();
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.InterfaceNameSpace1;
            oDr[clmnValue] = textBoxInterfaceSubPath1.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.BsNameSpace1;
            oDr[clmnValue] = textBoxCcSubPath1.Text;
            oDt.Rows.Add(oDr);

            oDr = oDt.NewRow();
            oDr[clmnKey] = Settings.TypeNameSapce1;
            oDr[clmnValue] = textBoxTypeSubPath1.Text;
            oDt.Rows.Add(oDr);

            string fullPath = string.Join("", StartupPath, "\\", Settings.DataTbl.TableName, ".xml");

            oDt.WriteXml(fullPath);

            MessageBox.Show(Message.SettingsSaved, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private DataTable CreateDatatableForSettings()
        {
            DataTable oDt = new DataTable(Settings.DataTbl.TableName);
            oDt.Columns.Add(Settings.DataTbl.ClmnKey);
            oDt.Columns.Add(Settings.DataTbl.ClmnValue);

            return oDt;
        }

        private int GetEndPointType()
        {
            int i = 0;
            if (radioButtonNetNamedBinding.Checked) i = 1;
            if (radioButtonNetTcpBinding.Checked) i = 2;
            if (radioButtonBasicHttpBinding.Checked) i = 3;
            if (radioButtonWsHttpBinding.Checked) i = 4;
            if (radioButtonCustomBinding.Checked) i = 5;

            return i;
        }

        private void SetEndPointType(int pTypeId)
        {
            switch (pTypeId)
            {
                case 1: radioButtonNetNamedBinding.Checked = true; break;
                case 2: radioButtonNetTcpBinding.Checked = true; break;
                case 3: radioButtonBasicHttpBinding.Checked = true; break;
                case 4: radioButtonWsHttpBinding.Checked = true; break;
                case 5: radioButtonCustomBinding.Checked = true; break;
                default: radioButtonCustomBinding.Checked = true;
                    break;
            }
        }

        private void SetWorkingType()
        {
            object workingMode = ConfigurationManager.AppSettings["WorkingMode"];
            if (workingMode != null) WorkMode = workingMode.ToString().ToEnum<WorkingModes>();

            if (WorkMode == WorkingModes.ClassLibrary)
            {
                //textBoxInterfaceSubPath1.Text = "Interfaces\\CCGInterfaces";
                //textBoxCcSubPath1.Text = "DAL\\CCGObjects";
                //textBoxTypeSubPath1.Text = "Types\\Enumerations";

                textBoxInheritanceClassNameForCC.Text = string.Empty;

                checkBoxTypedDs.Checked = false;
                checkBoxTypedDs.Visible = false;

                checkBoxCrudInterface.Checked = false;

                checkBoxAddServiceContract.Checked = false;
                checkBoxAddServiceContract.Visible = false;

                checkBoxPrmClassInInterfaceFile.Checked = false;

                checkBoxPrmClassInCCFile.Checked = true;

                checkBoxTemplateCc.Checked = false;
                checkBoxTemplateInterface.Checked = false;
                groupBoxTemplate.Visible = false;

                tabControlGeneration.TabPages.RemoveAt(1);
                tabControlGeneration.TabPages.RemoveAt(1);
            }
        }

        #endregion

        #region [HELPER METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void GetColumns()
        {
            DTColumnsInfo = Dac.GetColumnsProperties(SchemaName, TableName);
        }

        private void PrimaryKeyColumnName()
        {
            DataTable oDt = Dac.PrimaryKeyColumnName(SchemaName, TableName);

            if (oDt.Rows.Count > 0)
                PrimaryKeyName = oDt.Rows[0]["COLUMN_NAME"].ToString();
            else
                PrimaryKeyName = string.Empty;
        }

        /// <summary>
        /// Used to convert Database type to C# type
        /// </summary>
        private string GetCsType(string pTypeName)
        {
            return DataTypes.GetCSharpDataType(DatabaseType, pTypeName);
        }

        /// <summary>
        /// Used to convert C# data type to System.Data.DbType
        /// </summary>
        private string GetSystemDataType(string pTypeName)
        {
            return DataTypes.GetSystemDataType(pTypeName);
        }

        private bool IsTimestamp(string pDbDataType)
        {
            return DataTypes.IsDbDataTypeTimestamp(DatabaseType, pDbDataType);
        }

        private bool IsUnsuitable(string pDbDataType)
        {
            return DataTypes.IsDbDataTypeUnsuitableForWhereClause(DatabaseType, pDbDataType);
        }

        private bool IsNumeric(string pDbDataType)
        {
            return DataTypes.IsDbDataTypeNumeric(DatabaseType, pDbDataType);
        }

        private bool IsDate(string pDbDataType)
        {
            return DataTypes.IsDbDataTypeDate(DatabaseType, pDbDataType);
        }

        private string ProperCase(string s)
        {
            s = s.Replace("_", " ");
            s = s.ToLower(System.Globalization.CultureInfo.CurrentCulture);
            s = s.Replace("ı", "i");
            s = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
            s = s.Replace("İ", "I");
            s = s.Replace(" ", "");
            return s;
        }

        private string GetVersion()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        private void AddRegion(ref string pCode, string pRegionHeader)
        {
            int rhl = 106;    //maximum region header length
            int chrCount = rhl - pRegionHeader.Length;
            pCode = NewLine + "#region [" + pRegionHeader + "]" + new string('~', chrCount) + NewLine + pCode + NewDblLine + "#endregion";
        }

        private string AddComment(string pComment)
        {
            if (pComment == string.Empty) return pComment;
            string s = string.Format(@"
                /// <summary>
                /// {0}
                /// </summary>", pComment);

            return s;
        }

        private string GetColumnTypesAsComment(DataRow pRow)
        {
            string s = string.Empty;
            string clmnName = pRow[Fields.ColumnName].ToString();

            if (clmnName == PrimaryKeyName)
                s = string.Join("", s, "PrimaryKey");
            if (CheckColumnIsIdentity(pRow))
                s = string.Join("", s, ",Identity");
            if (pRow[Fields.IsComputed].ToBool())
                s = string.Join("", s, ",Computed");
            if (pRow[Fields.IsNullable].ToBool())
                s = string.Join("", s, ",Nullable");

            s = s.TrimStart(',');
            return s;
        }

        private bool IsFileExist(string pFilePath, string pClassName)
        {
            if (checkBoxSelectMultyTables.Checked) return false;

            if (File.Exists(pFilePath))
            {
                string msg = string.Format(Message.AskForOverwrite, pClassName);
                DialogResult r = MessageBox.Show(msg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (r == DialogResult.No) return true;
            }
            return false;
        }

        private bool WriteFile(string pCode, string pTargetPath, string pTargetFullPath)
        {
            if (!Directory.Exists(pTargetPath)) Directory.CreateDirectory(pTargetPath);
            TextWriter tw = null;

            try
            {
                tw = new StreamWriter(pTargetFullPath, false, Encoding.Default);
                tw.WriteLine(pCode);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                string msg = string.Format(Message.UnauthorizedAccessException, pTargetFullPath);
                MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (tw != null) tw.Close();
            }
        }

        private string GetColumnTypeName(string pColumnName)
        {
            string filter = string.Format("{0} = '{1}'", Fields.ColumnName, pColumnName);
            string sort = string.Empty;
            int topN = 1;

            GetColumns();
            DataTable oDt = DTColumnsInfo.FilterDataTable(filter, sort, topN);

            if (oDt.Rows.Count > 0)
                return oDt.Rows[0][Fields.SysTypeName].ToString();
            else
                return string.Empty;
        }

        private bool TableValidation()
        {
            if (DTColumnsInfo.Rows.Count > 0)
            {
                CheckTableHasIdentityColum();
                return true;
            }
            else
            {
                string msg = Message.MsgGeneral(TableFullName, Message.NoAnyResult);
                MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool CheckNecessaryFieldsIsFilled()
        {
            string errMsg = string.Empty;
            if (TableName == string.Empty || TableName.SubstringExt(0, 1) == "-") errMsg = Message.ChooseTable;
            if (SchemaName == string.Empty || SchemaName.SubstringExt(0, 1) == "-") errMsg = Message.ChooseSchema;
            if (ConnStr == string.Empty) errMsg = Message.MandatoryConStr;

            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void CheckTableHasIdentityColum()
        {
            IdentityColumnCsDataTypeName = DtCs.csInt;
            IdentityColumnDbDataTypeName = DataTypes.GetDefaultDbDataTypeForIdentityColumn(DatabaseType);

            HasIdentity = false;
            IdentityColumnName = string.Empty;
            IdentityColumnDbDataTypeName = string.Empty;
            IdentityColumnCsDataTypeName = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                if (CheckColumnIsIdentity(rw))
                {
                    HasIdentity = true;
                    IdentityColumnName = Convert.ToString(rw[Fields.ColumnName]);
                    IdentityColumnDbDataTypeName = Convert.ToString(rw[Fields.SysTypeName]);
                    IdentityColumnCsDataTypeName = GetCsType(IdentityColumnDbDataTypeName);
                    break;
                }
            }
        }

        #endregion

        private void blackSkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            standardSkinToolStripMenuItem.Checked = false;
            blackSkinToolStripMenuItem.Checked = true;

            SetSkinType("Black");
            RestartApp();
        }

        private void standardSkinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            standardSkinToolStripMenuItem.Checked = true;
            blackSkinToolStripMenuItem.Checked = false;

            SetSkinType("Standard");
            RestartApp();
        }

        private void SetSkinType(string pSkinType)
        {
            string appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string productName = Application.ProductName;
            string configFile = System.IO.Path.Combine(appPath, string.Format("{0}.exe.config", productName));

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFile;
            System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            config.AppSettings.Settings["SkinMode"].Value = pSkinType;
            config.Save();
        }

        private void RestartApp()
        {
            System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
            this.Close(); //to turn off current app
        }

        private void checkBoxCreateOnlySelect_CheckedChanged(object sender, EventArgs e)
        {
            checkBoxCreateOnlySelectAsClass.Visible = checkBoxCreateOnlySelect.Checked;
            if (!checkBoxCreateOnlySelect.Checked)
                checkBoxCreateOnlySelectAsClass.Checked = false;
        }

    }
}
