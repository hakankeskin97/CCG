using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DtCs = CrudClassGenerator.DataTypes.CSharpDataTypes;

namespace CrudClassGenerator
{
    partial class FormMain
    {
        #region [GENERATION METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #region [BS & INTERFACE CLASSES GENERATION CODES] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void GenerateMulti()
        {
            if (!IsSchemaAndTableSelected()) return;

            DialogResult result = MessageBox.Show(Message.MultiGenerationMsg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            int selItemCount = listBoxTables.SelectedItems.Count;
            if (selItemCount == 0)
            {
                MessageBox.Show(Message.NoTableSelected, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SetProgressBar(selItemCount);
            SetNameSpaces();
            string msg = Message.ProcessOk;

            foreach (DataRowView item in listBoxTables.SelectedItems)
            {
                RunProgressBar();

                TableName = item.Row["TableName"].ToString();

                SetClassName();

                if (!Generate())
                    msg = Message.ProcessOkBut;
            }
            TableName = string.Empty;
            CloseProgressBar();
            MessageBox.Show(msg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool Generate()
        {
            if (!checkBoxCrudCC.Checked && !checkBoxCrudInterface.Checked && !checkBoxPrmClassSeparate.Checked && !checkBoxTemplateCc.Checked && !checkBoxTemplateInterface.Checked)
            {
                MessageBox.Show(Message.ChooseOne, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            PrimaryKeyName = string.Empty;
            if (!GeneralValidation()) return false;
            HasIdentity = false;
            DTColumnsInfo = new DataTable();

            if (WorkMode == WorkingModes.WCF)
                if (!CheckIfEndPointAlreadyExist()) return false;

            if (checkBoxTemplateInterface.Checked) CreateInterfaceClass();
            if (checkBoxTemplateCc.Checked) CreateBsClass();

            if (checkBoxPrmClassSeparate.Checked || checkBoxCrudCC.Checked) { if (!ValidateForPrmAndCrudClasses()) return false; }
            if (checkBoxPrmClassSeparate.Checked) GeneratePrmClass();
            if (checkBoxCrudCC.Checked || checkBoxCrudInterface.Checked) CreateCrudClasses();

            if (WorkMode == WorkingModes.WCF)
            {
                CreateEndPointString();
                CreateCacheItemStrings();
            }

            return true;
        }

        private void CreateInterfaceClass()
        {
            if (IsFileExist(InterfaceFullPath, IClassFullName)) return;

            #region "Code"

            string code = string.Format(@"
				namespace {0}
				[[
					[ServiceContract()]
					public {2} interface I{1}
					[[
						//[OperationContract()]
						//[FaultContract(typeof(CCustomException))]
						//To Do
					]]
				]]
				", InterfaceNameSpace, ClassName, Partial);

            code = code.Replace("[[", "{").Replace("]]", "}").Replace(new string(' ', 12), "");

            #endregion

            bool written = WriteFile(code, InterfacePath, InterfaceFullPath);

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(IClassFullName);
        }

        private void CreateBsClass()
        {
            if (IsFileExist(CCFullPath, ClassName + "BS")) return;

            #region "Code"

            string inheritanceClassName = textBoxInheritanceClassNameForCC.Text != string.Empty ? textBoxInheritanceClassNameForCC.Text.TrimEnd(',') : string.Empty;
            string interfaceName = checkBoxCrudInterface.Checked ? string.Format("I{0}", ClassName) : string.Empty;
            string interfaceNameSpace = checkBoxCrudInterface.Checked ? string.Format("using {0};", InterfaceNameSpace) : string.Empty;
            string inheritanceSymbol = inheritanceClassName != string.Empty || interfaceName != string.Empty ? ":" : string.Empty;
            if (inheritanceClassName != string.Empty && interfaceName != string.Empty) inheritanceClassName = string.Format("{0},", inheritanceClassName);

            string usings = @"
				using System;
				using System.Collections.Generic;
				using System.Data;
				using System.ServiceModel;
				using Types.Attributes;
				{0}
				using DataService.CrudClassGenerator;
				{1}
				";

            usings = string.Format(usings, GetUsingStatementForDbProvider(), interfaceNameSpace);
            usings = usings.Replace("  ", "");

            string code = @"{0}
				namespace {1}
				[[
					[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
					[DefaultDatabase('{2}')]
					internal {3} class {4} {5} {6} {7}
					[[
						//To Do
					]]
				]]
			";


            code = string.Format(code,
                                 usings,
                                 CCNameSpace,
                                 DataBaseName,
                                 Partial,
                                 CCClassName,
                                 inheritanceSymbol,
                                 inheritanceClassName,
                                 interfaceName
                                 );

            code = code.Replace(new string(' ', 16), "").Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());

            #endregion

            bool written = WriteFile(code, CCPath, CCFullPath);

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(CCClassFullName);
        }

        private void CreateEndPointString()
        {
            textBoxEndPoint.Text = string.Empty;

            string endPoint = string.Format(
                @"<service behaviorConfiguration='DefaultBehavior' name='{0}.{1}'>
					|<endpoint address='{2}' 
							||||||binding='{3}' 
							||||||bindingConfiguration='{4}' 
							||||||contract='{5}.I{1}' >
					|</endpoint>
				  </service>", CCNameSpace, CCClassName
                             , EndPoint_address, EndPoint_binding, EndPoint_bindingConfiguration
                             , InterfaceNameSpace).Replace("\t", "").Replace("  ", "").Replace("|", "\t");

            textBoxEndPoint.Text = endPoint.Replace("'", ((char)34).ToString());
        }

        private void CreateCacheItemStrings()
        {
            textBoxCacheItemServer.Text = string.Empty;
            textBoxCacheItemWeb.Text = string.Empty;

            string itemName = ClassName + "Cached";

            string server = string.Format(@"<CacheItem CacheItemName='{0}' Interfacename='{1}.I{2}, Contracts' MethodName='{0}' MinutesToExpire='0' />", itemName, InterfaceNameSpace, ClassName);
            string web = string.Format(@"<CacheItem CacheItemName='{0}' MinutesToExpire='0' />", itemName);

            textBoxCacheItemServer.Text = server.Replace("'", ((char)34).ToString());
            textBoxCacheItemWeb.Text = web.Replace("'", ((char)34).ToString());
        }

        private void GeneratePrmClass()
        {
            string nameSpace = string.Empty;
            string targetPath = string.Empty;
            string targetFullPath = string.Empty;

            if (radioButtonUseInterfacePath.Checked)
            {
                if (IsFileExist(PrmClassFullPathGenerated, PrmClassNameGenerated)) return;
                nameSpace = InterfaceNameSpace;
                targetPath = PrmClassPath;
                targetFullPath = PrmClassFullPathGenerated;
            }
            else
            {
                if (IsFileExist(PrmClassFullPathGeneratedCC, PrmClassNameGenerated)) return;
                nameSpace = CCNameSpace;
                targetPath = PrmClassPathCC;
                targetFullPath = PrmClassFullPathGeneratedCC;
            }
                
            string prmCode = string.Empty;
            string infoCode = string.Empty;
            string code = string.Empty;

            GetParameterCodes(ref prmCode, ref infoCode);
            string inheritanceClassName = textBoxInheritanceClassNameForPrm.Text != string.Empty ? string.Format(":{0}", textBoxInheritanceClassNameForPrm.Text.TrimEnd(',')) : string.Empty;

            #region "Code"
            code = string.Format(@"{3}
				using System; 

				namespace {0}{4}
				[[
					{1}
					{2}
				]]
				", nameSpace, prmCode, infoCode, GetCCGGeneratorComment(), inheritanceClassName);
            code = code.Replace("[[", "{").Replace("]]", "}");
            //code = code.Replace(ClassName + "Prm", ClassName);
            #endregion

            bool written = WriteFile(code, targetPath, targetFullPath);

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(PrmClassName);
        }

        private string GeneratePrmCode()
        {
            string tblName = string.Format("public string TableName = '{0}';", TableFullName).Replace("'", ((char)34).ToString());
            string prvtMmbr = string.Empty;
            string property = string.Empty;
            string code = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string dbType = rw[Fields.SysTypeName].ToString();
                string csType = GetCsType(dbType);

                if (csType != DtCs.csString && csType != DtCs.csByteArr)
                    csType = csType + "?";   //if csType is not string set it nullable. Note: string csType is already nullable

                string clmnName = rw[Fields.ColumnName].ToString();

                string clmnTypeComment = AddComment(GetColumnTypesAsComment(rw));
                if (clmnTypeComment != string.Empty)
                    clmnTypeComment += NewLine;

                prvtMmbr += string.Format("private {0} m{1};", csType, clmnName) + NewLine;
                if (csType == DtCs.csString)
                    property += string.Format("{2} public {0} {1} [[ get [[ return m{1}; ]] set [[ m{1} = RmvInjChrKwrds(value); ]] ]] {3}", csType, clmnName, clmnTypeComment, NewLine);
                else
                    property += string.Format("{2} public {0} {1} [[ get [[ return m{1}; ]] set [[ m{1} = value; ]] ]] {3}", csType, clmnName, clmnTypeComment, NewLine);

                if (IsDate(dbType) && !checkBoxCreateOnlySelectAsClass.Checked)
                {
                    prvtMmbr += string.Format("private {0} m{1}2;", csType, clmnName) + NewLine;
                    property += string.Format("public {0} {1}2 [[ get [[ return m{1}2; ]] set [[ m{1}2 = value; ]] ]]", csType, clmnName) + NewLine;
                }
            }
            code = string.Join("", tblName, NewDblLine, prvtMmbr, NewLine, property, AdditionalPropertiesForPrmClass());
            return code;
        }

        private void GenerateInfoCode(ref string fieldName, ref string maxLength)
        {
            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmnName = rw[Fields.ColumnName].ToString();

                fieldName += string.Format("public const string {0} = '{0}';", clmnName) + NewLine;

                string dbType = rw[Fields.SysTypeName].ToString();
                string csType = GetCsType(dbType);
                if (csType == DtCs.csString)
                {
                    string len = rw[Fields.MaxLength].ToString();
                    maxLength += string.Format("public const int {0} = {1};", clmnName, len) + NewLine;
                }
            }

            fieldName = fieldName.Replace("'", ((char)34).ToString());
        }

        private string GenerateDbComparisonOperatorsClass()
        {
            string additional = @"private DbComparisonOperators mGeneralComparisonOperator = DbComparisonOperators.Equal;
						/// <summary>
						/// Used to compare 'where' condition statements. Default operator is 'Equal. Exp: Key1 = 5'
						/// </summary>
						public DbComparisonOperators GeneralComparisonOperator { get { return mGeneralComparisonOperator; } set { mGeneralComparisonOperator = value; } }";

            string prvtMmbr = string.Empty;
            string property = string.Empty;
            string code = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string dbType = rw[Fields.SysTypeName].ToString();
                string csType = GetCsType(dbType);

                if (csType != DtCs.csByteArr && csType != Fields.dbObject)
                {
                    string clmnName = rw[Fields.ColumnName].ToString();
                    if (IsUnsuitable(dbType)) continue;

                    prvtMmbr += string.Format("private DbComparisonOperators m{0};", clmnName) + NewLine;

                    property += string.Format("public DbComparisonOperators {0} [[ get [[ return m{0} == 0 ? mGeneralComparisonOperator : m{0}; ]] set [[ m{0} = value; ]] ]]", clmnName) + NewLine;
                }
            }

            code = additional + NewDblLine + prvtMmbr + NewLine + property;
            return code;
        }

        private string GenerateSqlConjuctionOperatorsClass()
        {
            string additional = @"private DbConjunctionOperators mGeneralConjunctionOperator = DbConjunctionOperators.AND;
						/// <summary>
						/// Used to conjuct 'where' condition statements. Default operator is 'AND. Exp: Key1 = 5 AND Key2 = 8'
						/// </summary>
						public DbConjunctionOperators GeneralConjunctionOperator { get { return mGeneralConjunctionOperator; } set { mGeneralConjunctionOperator = value; } }";

            string prvtMmbr = string.Empty;
            string property = string.Empty;
            string code = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmnName = rw[Fields.ColumnName].ToString();
                string dbType = rw[Fields.SysTypeName].ToString();
                if (IsUnsuitable(dbType)) continue;

                prvtMmbr += string.Format("private DbConjunctionOperators m{0};", clmnName) + NewLine;

                property += string.Format("public DbConjunctionOperators {0} [[ get [[ return m{0} == 0 ? mGeneralConjunctionOperator : m{0}; ]] set [[ m{0} = value; ]] ]]", clmnName) + NewLine;
            }

            code = additional + NewDblLine + prvtMmbr + NewLine + property;
            return code;
        }

        private string GenerateSetNullClass()
        {
            string prvtMmbr = string.Empty;
            string property = string.Empty;
            string code = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmnName = rw[Fields.ColumnName].ToString();
                string dbType = rw[Fields.SysTypeName].ToString();
                if (IsTimestamp(dbType)) continue;

                bool nullable = rw[Fields.IsNullable].ToBool();
                if (!nullable) continue;

                prvtMmbr += string.Format("private bool m{0};", clmnName) + NewLine;

                property += string.Format("public bool {0} [[ get [[ return m{0}; ]] set [[ m{0} = value; ]] ]]", clmnName) + NewLine;
            }

            code = prvtMmbr + NewLine + property;
            return code;
        }

        private string GenerateJoinStringClass()
        {
            string code = @"
							private string mSelectPart;
							private string mJoinPart;

							public string SelectPart { get { return mSelectPart; } set { mSelectPart = value; } }
							public string JoinPart { get { return mJoinPart; } set { mJoinPart = value; } }
						   ";

            return code;
        }

        private string GenerateJoinStringAdditionalClass()
        {
            string code = @"
							private string mSelectPart;
							private string mJoinPart;

							public string SelectPart { get { return mSelectPart; } set { mSelectPart = value; } }
							public string JoinPart { get { return mJoinPart; } set { mJoinPart = value; } }
						   ";

            return code;
        }

        private string GenerateRelatedTableListEnum()
        {
            DataTable oDt = Dac.GetJoinString(SchemaName, TableName, LookupTablePrefix);

            GenerateColumnsForSelectPart(oDt);

            string enumList = string.Empty;

            if (oDt.Rows.Count > 0)
            {
                string enumNameField = "JoinList";
                string enumValueField = "TableRelationType";

                foreach (DataRow row in oDt.Rows)
                {
                    string itemName = row[enumNameField].ToString();
                    string itemvalue = row[enumValueField].ToString();
                    string itemDesc = row["JoinPart"].ToString() + "|," + row["SelectPart"].ToString();

                    enumList = string.Join("", enumList, string.Format("[Description('{0}')] \r\n\t\t{1} = {2} , \r\n\r\n", itemDesc, itemName, itemvalue), (char)9, (char)9);

                }

                enumList = enumList.Substring(0, enumList.Length - 5).Replace("'", ((char)34).ToString()).Replace("[[", "{").Replace("]]", "}");
            }

            return enumList;
        }

        #endregion

        #region [CRUD BS & INTERFASE CLASSES GENERATION CODES] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void CreateCrudClasses()
        {
            if (!TableValidation()) return;

            if (!checkBoxSelectMultyTables.Checked)
            {
                SetProgressBar(2, 1);
            }

            if (checkBoxCrudInterface.Checked) GenerateCrudInterface();

            if (!checkBoxSelectMultyTables.Checked) pbrMultiProc.Value = 2;

            if (checkBoxCrudCC.Checked) GenerateCrudBs();

            if (!checkBoxSelectMultyTables.Checked) CloseProgressBar();
        }

        private void GenerateCrudInterface()
        {
            if (IsFileExist(InterfaceFullPathGenerated, IClassFullNameGenerated)) return;

            #region "Code"

            string prmCode = string.Empty;
            string infoCode = string.Empty;
            string dsUsing = string.Empty;
            string dsCodes = string.Empty;
            string iud = string.Empty;

            if (checkBoxPrmClassInInterfaceFile.Checked) GetParameterCodes(ref prmCode, ref infoCode);

            if (checkBoxTypedDs.Checked)
            {
                dsCodes = NewLine + GetInterfaceDataSetCodes();

                string dsNs = textBoxInterfaceSubPath2.Text;
                dsUsing = string.Format("using Types.DataSets.{0};", dsNs) + NewLine;
            }

            if (!checkBoxCreateOnlySelect.Checked) iud = GetInterfaceIUDCodes();

            string serviceContract = string.Empty;   //End point oluşturabilmek için kullanılan atrribute. Standart Interface oluşturulmayacak, sadece generated Interface kullanılacak ise bu attribute eklenmelidir
            if (checkBoxAddServiceContract.Checked) serviceContract = "[ServiceContract()]";

            string select = GetInterfaceSelectCode();
            string headerComment = GetCCGGeneratorComment();

            string interfaceCode = @"
					{0}
					public partial interface I{1}
					[[
						{2}
						{3}
						{4}
					]]
					";

            interfaceCode = string.Format(interfaceCode, serviceContract, ClassName, iud, select, dsCodes);
            AddRegion(ref interfaceCode, "INTERFACE");

            string code = string.Format(@"{0}
				using System;
				using System.Collections.Generic;
				using System.Data;
				using System.ServiceModel;
				using Types.CustomTypes;
				{1}
				namespace {2}
				[[  {3}
					{4}
					{5}
				]]",
                   headerComment,
                   dsUsing,
                   InterfaceNameSpace,
                   interfaceCode,
                   prmCode,
                   infoCode
                   );

            code = code.Replace("[[", "{").Replace("]]", "}").Replace(new string(' ', 16), "").Replace("^^", ((char)34).ToString());
            //code = code.Replace(ClassName + "Prm", ClassName);

            #endregion

            bool written = WriteFile(code, InterfacePath, InterfaceFullPathGenerated.ToString());

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(IClassFullNameGenerated);
        }

        private void GenerateCrudBs()
        {
            if (IsFileExist(CCFullPathGenerated, CCClassFullNameGenerated)) return;

            // To set and change connection, database name (Initial Catalog) should be changed in sql server 
            // and schema (Data Source) should be changed in Oracle.

            string prmCode = string.Empty;
            string infoCode = string.Empty;
            if (checkBoxPrmClassInCCFile.Checked) GetParameterCodes(ref prmCode, ref infoCode);

            string code = string.Format(@"
					private static string database;
					/// <summary>
					/// Default Database name to be acted on. 
					/// If this parameter is not given, default database is used. 
					/// Default database name is written in config file as the name of 'DefaultDBName'
					/// </summary>
					public static string Database  [[get [[ return string.IsNullOrWhiteSpace(database) ? 'DefaultDBName'.ReadAppSetting<string>('{0}') : database; ]] set [[ database = value; ]] ]]", DatabaseType == DatabaseTypes.MS_SQL ? DataBaseName : DataSourceName);

            code = string.Join("", code, NewDblLine, string.Format(@"
					/// <summary>
					/// Full table name. This parameter can be changed by giving full name like this [DataBaseName].[SchemaName].[TableName]
					/// </summary>
					public static string TableName [[ get [[ return string.Format('[[0]].{0}.{1}', Database); ]] ]]", SchemaName, TableName));

            code = string.Join("", code, NewDblLine, string.Format("public const string PrimaryKeyName = '{0}';", PrimaryKeyName));

            //code = string.Join("", code, NewLine, string.Format("public const string ConnectionStringName = '{0}';", ConnectionStringName));
            code = string.Join("", code, NewDblLine, string.Format(@"private static string connectionStringName;
										  public static string ConnectionStringName  [[get [[ return string.IsNullOrWhiteSpace(connectionStringName) ? 'DefaultConnStrName'.ReadAppSetting<string>('{0}') : connectionStringName; ]] set [[ connectionStringName = value; ]] ]]", ConnectionStringName));

            code = string.Join("", code, NewDblLine, "private int mCommandTimeout = 0;");

            if (!checkBoxCreateOnlySelect.Checked)
            {
                if (HasIdentity)
                {
                    code = string.Join("", code, NewLine, string.Format("public const string IdentityName = '@:ID_{0}';", TableName));
                    code = string.Join("", code, NewLine, string.Format("public string IdentityPrmName = '@:ID_{0}';", TableName));
                    code = string.Join("", code, NewLine, "private int IdentityPrmIndex = 0;");
                }
            }

            code = string.Join("", NewLine, code.Replace("'", ((char)34).ToString()));
            AddRegion(ref code, "PARAMETERS");

            string constructors =
                string.Format(@"
								public {0}() [[ ]]
								public {0}(int pCommandTimeout) [[ mCommandTimeout = pCommandTimeout; ]]
                                public {0}(string pDatabaseName) [[ database = pDatabaseName; ]]
                                public {0}(int pCommandTimeout, string pDatabaseName) [[ mCommandTimeout = pCommandTimeout; database = pDatabaseName; ]]
                               ", CCClassName);

            AddRegion(ref constructors, "CONSTRUCTORS");
            code = string.Join("", code, NewLine, constructors);

            if (checkBoxCreateOnlySelect.Checked)
            {
                code = string.Join("", code, NewLine, CodeForSelect());
            }
            else
            {
                code = string.Join("", code, NewLine, CodeForSave(),
                                             NewLine, CodeForInsert(),
                                             NewLine, CodeForUpdate(),
                                             NewLine, CodeForDelete(),
                                             NewLine, CodeForSelect(),
                                             NewLine, CodeForGetSqlCommandObject(),
                                             NewLine, CodeForIUDValuesForLog(),
                                             NewLine, CodeForHelperMethods());
            }
            string dsUsing = string.Empty;
            if (checkBoxTypedDs.Checked)
            {
                code = string.Join("", code, NewDblLine, CodeForSelectAsTypedDataSet());
                string dsNs = textBoxInterfaceSubPath2.Text;
                dsUsing = NewLine + string.Format("using Types.DataSets.{0}; \r\n using DataService;", dsNs);
            }

            string usingSystemComponent = checkBoxCrudCC.Checked ? "using System.ComponentModel;" : string.Empty;

            string inheritanceClassName = textBoxInheritanceClassNameForCC.Text != string.Empty ? textBoxInheritanceClassNameForCC.Text.TrimEnd(',') : string.Empty;
            string interfaceName = checkBoxCrudInterface.Checked ? string.Format("I{0}", ClassName) : string.Empty;
            string interfaceNameSpace = checkBoxCrudInterface.Checked ? string.Format("using {0};", InterfaceNameSpace) : string.Empty;
            string inheritanceSymbol = inheritanceClassName != string.Empty || interfaceName != string.Empty ? ":" : string.Empty;
            if (inheritanceClassName != string.Empty && interfaceName != string.Empty) inheritanceClassName = string.Format("{0},", inheritanceClassName);

            string usingDataService = WorkMode == WorkingModes.WCF ? "using DataService.CrudClassGenerator;" : "using CCGDataService;";

            string block = @"{0}
			using System;
			using System.Collections.Generic;
			using System.Data;
			using System.Data.Common;
			using System.Text;
			{1}
			{2}
			{3}
			{4}
			{5}
			namespace {6}
			[[
				{7} partial class {8} {9} {10} {11}
				[[
					/// <summary>
					/// Used to create an instance from this class
					/// </summary>
					public static {8} Instance() [[ return new {8}(); ]]

					/// <summary>
					/// Used to create an instance from this class 
					/// </summary>
					/// <param name='pCommandTimeout'>The time in seconds to wait for the command to execute</param>
					public static {8} Instance(int pCommandTimeout) [[ return new {8}(pCommandTimeout); ]]

					/// <summary>
					/// Used to create an instance from this class
					/// </summary>
					/// <param name='pDatabaseName'>Default Database name to be acted on. If this parameter is not given, default database is used. Default database name is written in config file as the name of 'DefaultDBName'</param>
					public static {8} Instance(string pDatabaseName) [[ return new {8}(pDatabaseName); ]]

					/// <summary>
					/// Used to create an instance from this class
					/// </summary>
					/// <param name='pCommandTimeout'>The time in seconds to wait for the command to execute</param>
					/// <param name='pDatabaseName'>Default Database name to be acted on. If this parameter is not given, default database is used. Default database name is written in config file as the name of 'DefaultDBName'</param>
					public static {8} Instance(int pCommandTimeout, string pDatabaseName) [[ return new {8}(pCommandTimeout, pDatabaseName); ]]

					{12}
				]]
				{13}
				{14}
			]]";

            code = string.Format(block,
                                 GetCCGGeneratorComment(),          //0
                                 GetUsingStatementForDbProvider(),  //1
                                 usingDataService,                  //2
                                 interfaceNameSpace,                //3
                                 usingSystemComponent,              //4
                                 dsUsing,                           //5
                                 CCNameSpace,                       //6
                                 ProtectionLevel,                   //7
                                 CCClassName,                       //8
                                 inheritanceSymbol,                 //9
                                 inheritanceClassName,              //10
                                 interfaceName,                     //11
                                 code,                              //12
                                 prmCode,                           //13
                                 infoCode                           //14
                                 );

            code = code.Replace("[[", "{").Replace("]]", "}");
            //code = code.Replace(ClassName + "Prm", ClassName);
            code = AdditionalReplacesDependonDbType(code);

            bool written = WriteFile(code, CCPath, CCFullPathGenerated);

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(CCClassFullNameGenerated);
        }

        private void GetParameterCodes(ref string pPrmCode, ref string pInfoCode)
        {
            string inheritanceClassName = textBoxInheritanceClassNameForPrm.Text != string.Empty ? string.Format(":{0}", textBoxInheritanceClassNameForPrm.Text.TrimEnd(',')) : string.Empty;

            string additional = string.Empty;

            if (checkBoxCrudCC.Checked)
            {
                //Additional Classes and Enums

                additional = string.Format(@"
					/// <summary>
					/// Helper class which is used to set database comparison operator between parameter and its value
					/// </summary>
					[Serializable]
					public partial class {0}DbComparisonOperators
					[[                        
						{1}
					]]

					/// <summary>
					/// Helper class which is used to set conjunction operator between where clause parameters
					/// </summary>
					[Serializable]
					public partial class {0}DbConjunctionOperators
					[[
						{2}
					]]

					/// <summary>
					/// Helper class which is used to set an item value as null
					/// </summary>
					[Serializable]
					public partial class {0}SetNull
					[[
						{3}
					]]

					/// <summary>
					/// Helper class which is used to set externally 'select' and 'join' parts of a query 
					/// </summary>
					[Serializable]
					public partial class {0}JoinString
					[[
						{4}
					]]

					/// <summary>
					/// Helper class which is used to add 'select' and 'join' parts into a query
					/// </summary>
					[Serializable]
					public partial class {0}JoinStringAdditional
					[[
						{5}
					]]

					/// <summary>
					/// Enumaration which is used to set 'select' and 'join' parts of a query 
					/// </summary>
					public enum Enum{0}RelatedTableList
					[[
						{6}
					]]
					", ClassName
                     , GenerateDbComparisonOperatorsClass()
                     , GenerateSqlConjuctionOperatorsClass()
                     , GenerateSetNullClass()
                     , GenerateJoinStringClass()
                     , GenerateJoinStringAdditionalClass()
                     , GenerateRelatedTableListEnum()
                     );
            }

            if (checkBoxCreateOnlySelectAsClass.Checked)
                additional = string.Empty;

            pPrmCode = string.Format(@"
					/// <summary>
					/// Parameter class which is generated from table
					/// </summary>
					[Serializable]
					public partial class {0}{1}
					[[
						/// <summary>
						/// Used to create an instance from this class
						/// </summary>
						public static {0} Instance() [[ return new {0}(); ]]

						/// <summary>
						/// Used to create an instance from this class
						/// </summary>
						/// <param name='pRemoveInjectionCharactersAndKeywords'>If this paramater set as 'true', string values will be checked for injection caharcters and for some KeyWords. Default value is 'true'.</param>
						/// <returns></returns>
						public static {0} Instance(bool pRemoveInjectionCharactersAndKeywords) [[ return new {0}(pRemoveInjectionCharactersAndKeywords); ]]

						private bool mRmvInjChrKwrds = false;

						public {0}() [[]]
						public {0}(bool pRemoveInjectionCharactersAndKeywords) [[ mRmvInjChrKwrds = pRemoveInjectionCharactersAndKeywords; ]]

						private string RmvInjChrKwrds(string pValue) [[ return mRmvInjChrKwrds ? pValue.RemoveInjectionCharacters() : pValue; ]]

						{2}
					]]
					{3}
					", ClassName
                     , inheritanceClassName
                     , GeneratePrmCode()
                     , additional);

            AddRegion(ref pPrmCode, "PARAMETER CLASSES");

            //if (checkBoxCreateOnlySelectAsClass.Checked)
            //{ 
            //    pInfoCode = string.Empty;
            //    return;
            //}

            string fieldName = string.Empty;
            string maxLength = string.Empty;
            GenerateInfoCode(ref fieldName, ref maxLength);
            pInfoCode = string.Format(@"
					/// <summary>
					/// Information class which is used to get some information of table
					/// </summary>
					[Serializable]
					public class {0}Info
					[[
						/// <summary>
						/// Information class which is used to get column (field) names of table
						/// </summary>
						public struct FieldName
						[[
							{1}
						]]

						/// <summary>
						/// Information class which is used to get maximum length of columns (fields)
						/// </summary>
						public struct FieldMaxLength
						[[
							{2}
						]]
					]]", ClassName, fieldName, maxLength);

            AddRegion(ref pInfoCode, "INFO CLASSES");
        }

        private string GetInterfaceDataSetCodes()
        {
            string dsCode = string.Format(@"
				{1}DataSet SelectAsTypedDataSet({0} pPrm);

				{1}DataSet SelectAsTypedDataSet({0} pPrm, JoinTypes pJoinType);

				{1}DataSet SelectAsTypedDataSet({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN);

				void InsertOrUpdate({1}DataSet pTypedDataSet);

				void InsertOrUpdate({1}DataSet pTypedDataSet, bool pIsTransactional);

				void InsertOrUpdate({1}DataSet pTypedDataSet, bool pIsTransactional, bool pWriteLog);

				void InsertOrUpdate({1}DataSet pTypedDataSet, bool pAcceptChangesDuringUpdate, bool pContinueUpdateOnError, bool pWriteLog);
				", ClassName, IClassName);

            return dsCode;
        }

        private string GetInterfaceIUDCodes()
        {
            string insertReturnType = "void"; if (HasIdentity) insertReturnType = IdentityColumnCsDataTypeName;

            string iud = string.Format(@"
				{2}
				{1} Save({0} pPrm, {0} pPrmForWhereClause);
				
				{2}
				void Save(List<{0}> pPrm, List<{0}> pPrmForWhereClause);

				{1} Insert({0} pPrm);

				void Insert(List<{0}> pPrms, bool pTransactional);

				void Update({0} pPrm);

				void Update(List<{0}> pPrms, bool pTransactional);

				void Update({0} pPrm, {0} pPrmForWhere);

				/// <summary>
				/// This method is used to batch update.
				/// Since second parameters are used to find existancy of first parametes data, parameters orders must be the same
				/// </summary>
				/// <param name='pPrm'>For update data</param>
				/// <param name='pPrmForWhereClause'>For where clause to check existincy of data</param>
				void Update(List<{0}> pPrms, List<{0}> pPrmForWhere, bool pTransactional);

				void Delete({0} pPrm);

				void Delete(List<{0}> pPrms, bool pTransactional);"
                , ClassName, insertReturnType, CommandSave, IClassName).Replace("'", ((char)34).ToString()) + NewLine;

            return iud;
        }

        private string GetInterfaceSelectCode()
        {
            string select = string.Format(@"
						DataTable Select({0} pPrm);

						DataTable Select({0} pPrm, JoinTypes pJoinType);

						DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN);

						DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex);

						object SelectAggregateFunction({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName);

						{0} SelectAs{0}({0} pPrm);

						List<{0}> SelectAs{0}List({0} pPrm);
					", ClassName, IClassName);

            return select;
        }

        private string AdditionalPropertiesForPrmClass()
        {
            if (checkBoxCreateOnlySelectAsClass.Checked)
                return string.Empty;

            string s = string.Empty;
            if (checkBoxCrudCC.Checked)
            {
                s = @"
						//Additional Members and Properties

						private string mUserID = string.Empty;
						private bool mWriteLog;
						private string mWhereClause = string.Empty;
						private string mWhereClauseAdditional = string.Empty;
						private bool mAllowDublicateRecords;

						private [[0]]JoinString mJoinString = new [[0]]JoinString();
						private [[0]]JoinStringAdditional mJoinStringAdditional = new [[0]]JoinStringAdditional();
						private [[0]]DbConjunctionOperators mConjunctionOperator = new [[0]]DbConjunctionOperators();
						private [[0]]DbComparisonOperators mComparisonOperator = new [[0]]DbComparisonOperators();
						private [[0]]SetNull mSetNull = new [[0]]SetNull();
						private Dictionary<Enum[[0]]RelatedTableList, EnumJoinMethods> mTableListToJoinCustom = new Dictionary<Enum[[0]]RelatedTableList, EnumJoinMethods>();

						/// <summary>
						/// Used for logging process. It can be [User Key], [User Name] etc.
						/// </summary>
						public string UserID { get { return mUserID; } set { mUserID = value.Split(^@^).GetValue(0).ToString(); } }

						/// <summary>
						/// Used to determine whether or not to be logged. If you set this parameter to true, the process will be active
						/// </summary>
						public bool WriteLog { get { return mWriteLog; } set { mWriteLog = value; } }

						/// <summary>
						/// Used to set 'where' clause of sql query as manually. If you set this parameter, without considering the value of other parameters, this parameter will be used only.
						/// </summary>
						public string WhereClause { get { return mWhereClause; } set { mWhereClause = value; } }

						/// <summary>
						/// Used to add extra 'where' clause to existing where clause as manually. 
						/// </summary>
						public string WhereClauseAdditional { get { return mWhereClauseAdditional; } set { mWhereClauseAdditional = value; } }

						/// <summary>
						/// When a main table and a detail table with one-to-N relationship between them are combined, records will be dublicated.
						/// Sometimes this is a desirable situation but usually such records are made unique and used to filter by columns of detail table.
						/// If you need to get all records of Main-Detail table relation, you should set this parameter as true.
						/// </summary>
						public bool AllowDublicateRecords { get { return mAllowDublicateRecords; } set { mAllowDublicateRecords = value; } }

						/// <summary>
						/// Used to set 'join' string of sql query as manually. If you set this parameter, without considering the value of other parameters, this parameter will be used only.
						/// This parameter has two value which are called as <SelectPart> and <JoinPart>. SelectPart is optional. If you want to get at least one column of joined table,
						/// you should add name or allias of that table to SelectPart with column name or star. 
						/// 
						/// e.g. 
						/// SELECT MT.*, T1.Age 
						/// FROM PERSONE MT 
						///     inner Join PERSON_DETAIL PD ON PD.ID = MT.ID
						///     
						/// In this example; <T1.Age> is select part and <inner Join PERSON_DETAIL PD ON PD.ID = MT.ID> is join part
						/// </summary>
						public [[0]]JoinString JoinString { get { return mJoinString; } set { mJoinString = value; } }

						/// <summary>
						/// Used to add extra 'join' string to existing join string as manually. 
						/// This parameter has two value which are called as <SelectPart> and <JoinPart>. SelectPart is optional. If you want to get at least one column of added joined table,
						/// you should add name or allias of that table to SelectPart with column name or star. 
						/// 
						/// e.g. 
						/// SELECT MT.*, T1.Age, LT.* 
						/// FROM PERSONE MT 
						///     inner Join PERSON_DETAIL PD ON PD.ID = MT.ID 
						///     inner join LT_PERSON_TYPE PT ON PT.TypeID = MT.TypeID
						///     
						/// In this example; <LT.*> is additional select part and <inner join LT_PERSON_TYPE PT ON PT.TypeID = MT.TypeID> is added join part
						/// </summary>
						public [[0]]JoinStringAdditional JoinStringAdditional { get { return mJoinStringAdditional; } set { mJoinStringAdditional = value; } }

						/// <summary>
						/// Used to set conjuction operator between parameters. Default one is <AND> operator.
						/// </summary>
						public [[0]]DbConjunctionOperators ConjunctionOperator { get { return mConjunctionOperator; } set { mConjunctionOperator = value; } }

						/// <summary>
						/// Used to set comparison operator between parameter and value. Default one is '=' operator.
						/// </summary>
						public [[0]]DbComparisonOperators ComparisonOperator { get { return mComparisonOperator; } set { mComparisonOperator = value; } }

						/// <summary>
						/// Used to set a parameter to NULL. So you can set a table column value to null.
						/// </summary>
						public [[0]]SetNull SetNull { get { return mSetNull; } set { mSetNull = value; } }

						/// <summary>
						/// Used to set 'JoinPart' as custom
						/// </summary>
						public Dictionary<Enum[[0]]RelatedTableList, EnumJoinMethods> TableListToJoinCustom { get { return mTableListToJoinCustom; } set { mTableListToJoinCustom = value; } }

					";
            }

            s = s.Replace("[[0]]", ClassName);
            s = s.Replace("^", "'");
            return NewLine + s;
        }

        #region [CRUD BS PARTS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #region [SAVE  ] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #region [CommandSave]
        private const string CommandSave = @"/// <summary>
			/// This method updates existing data and inserts nonexistant data in transection.
			/// Note: Since second parameters are used to find existancy of first parametes data, parameters orders must be the same
			/// To insert only if data nonexist, set UpdateDataIfExistInSaveMethods variable as false
			/// </summary>
			/// <param name='pPrm'>For update or insert data</param>
			/// <param name='pPrmForWhereClause'>For where clause to check existincy of data</param>";
        #endregion

        private string CodeForSave()
        {
            string insertReturnType = "void";
            string additionalCodeForIdetity1 = string.Empty;
            string additionalCodeForIdetity2 = string.Empty;
            string additionalCodeForIdetity3 = string.Empty;
            string additionalCodeForIdetity4 = string.Empty;

            if (HasIdentity)
            {
                insertReturnType = IdentityColumnCsDataTypeName;

                PrepareGettingIdentityClauses(ref additionalCodeForIdetity1, ref additionalCodeForIdetity2, ref additionalCodeForIdetity3, ref additionalCodeForIdetity4, insertReturnType);

            }

            #region [Code Block]

            string codeBlock = @"
			{1}
			public {6} Save({0} pPrm, {0} pPrmForWhereClause, bool pUpdateIfExist = true)
			[[
				SqlCommand cmd = GetSaveCommand(pPrm, pPrmForWhereClause, pUpdateIfExist);
				if (pPrm.WriteLog) cmd.AddTransaction();
				{2}
				CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteNonQueryStatement(cmd);
				{3}
			]]

			{1}
			public void Save(List<{0}> pPrms, List<{0}> pPrmForWhereClause, bool pUpdateIfExist = true)
			[[
				List<SqlCommand> cmds = GetSaveCommand(pPrms, pPrmForWhereClause, pUpdateIfExist);
				{4}
				CCGBatchProcess.Instance(false).Proceed(cmds.ConvertAll(t => [[ return (DbCommand)t; ]]), true);
				{5}
			]]

			/// <summary>
			/// Used to get Command object for saving process.
			/// </summary>
			/// <param name='pPrm'>Parameter for update or insert data</param>
			/// <param name='pPrmForWhereClause'>Parameter for where clause to check existincy of data</param>
			/// <param name='pUpdateIfExist'>If this parameter set as true, command object prepared to update existing data.
			/// In other cases, the command object does not update the current data.</param>
			/// <returns></returns>
			public SqlCommand GetSaveCommand({0} pPrm, {0} pPrmForWhereClause, bool pUpdateIfExist = true)
			[[
				return GetSaveCommand(pPrm, pPrmForWhereClause, 0, pUpdateIfExist);
			]]

			/// <summary>
			/// Used to get Command object list for saving process.
			/// </summary>
			/// <param name='pPrm'>Parameter list for update or insert data</param>
			/// <param name='pPrmForWhereClause'>Parameter list for where clause to check existincy of data</param>
			/// <param name='pUpdateIfExist'>If this parameter set as true, command object prepared to update existing data.
			/// In other cases, the command object does not update the current data.</param>
			/// <returns></returns>
			public List<SqlCommand> GetSaveCommand(List<{0}> pPrm, List<{0}> pPrmForWhereClause, bool pUpdateIfExist = true)
			[[
				List<SqlCommand> cmds = new List<SqlCommand>();
				SqlCommand cmd;

				int i = 1;
				for (int j = 0; j < pPrm.Count; j++)
				[[
					cmd = GetSaveCommand(pPrm[j], pPrmForWhereClause[j], i, pUpdateIfExist);
					cmds.Add(cmd);
					i += 3;
				]]
				return cmds;
			]]

			private SqlCommand GetSaveCommand({0} pPrm, {0} pPrmForWhereClause, int counter, bool pUpdateIfExist = true)
			[[
				if (pUpdateIfExist)
					return GetInsertOrUpdateCommand(pPrm, pPrmForWhereClause, counter);
				else
					return GetInsertIfNotExistCommand(pPrm, pPrmForWhereClause, counter);
			]]

			private SqlCommand GetInsertOrUpdateCommand({0} pPrm, {0} pPrmForWhereClause, int counter)
			[[
				{7}
			]]

			private SqlCommand GetInsertIfNotExistCommand({0} pPrm, {0} pPrmForWhereClause, int counter)
			[[
				{8}
			]]";

            #endregion

            string code = string.Format(codeBlock,
                                ClassName,
                                CommandSave,
                                additionalCodeForIdetity1,
                                additionalCodeForIdetity2,
                                additionalCodeForIdetity3,
                                additionalCodeForIdetity4,
                                insertReturnType,
                                PrepareSaveQueryPartForSave(),
                                PrepareSaveQueryPartForSave2());

            AddRegion(ref code, "SAVE");

            code = code.Replace("[[", "{")
                       .Replace("]]", "}")
                       .Replace("'", ((char)34).ToString())
                       .Replace("^", "'");
            return code;
        }

        #endregion

        #region [INSERT] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string CodeForInsert()
        {
            string insertReturnType = "void";
            string additionalCodeForIdetity1 = string.Empty;
            string additionalCodeForIdetity2 = string.Empty;
            string additionalCodeForIdetity3 = string.Empty;
            string additionalCodeForIdetity4 = string.Empty;

            if (HasIdentity)
            {
                insertReturnType = IdentityColumnCsDataTypeName;

                PrepareGettingIdentityClauses(ref additionalCodeForIdetity1, ref additionalCodeForIdetity2, ref additionalCodeForIdetity3, ref additionalCodeForIdetity4, insertReturnType);
            }

            string code = string.Format(@"
			/// <summary>
			/// Used to insert parameters to database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include parameters to be inserted</param>
			/// <returns></returns>
			public {0} Insert({1} pPrm)
			[[
				SqlCommand cmd = GetInsertCommand(pPrm);
				if (pPrm.WriteLog) cmd.AddTransaction();

				{2}

				CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteNonQueryStatement(cmd);
				
				{3}
			]]

			/// <summary>
			/// Used to insert parameter lists to database
			/// </summary>
			/// <param name='pPrms'>Parameter object list which include parameters to be inserted</param>
			/// <param name='pTransactional'>If this parameter set as true then insert process is made in a sql transaction</param>
			public void Insert(List<{1}> pPrms, bool pTransactional)
			[[
				List<SqlCommand> cmds = GetCommandObject(pPrms, CrudTypes.Insert);
				{4}
				CCGBatchProcess.Instance(Database).Proceed(cmds.ConvertAll(t => [[ return (DbCommand)t; ]]), pTransactional);
				{5}
			]]"
                , insertReturnType
                , ClassName
                , additionalCodeForIdetity1
                , additionalCodeForIdetity2
                , additionalCodeForIdetity3
                , additionalCodeForIdetity4);

            code = code + NewLine + CodeForInsertCommand();
            AddRegion(ref code, "INSERT");
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString()).Replace("^", "'");
            return code;
        }

        private string CodeForInsertCommand()
        {
            string identity = "string identity = string.Empty;";
            string identityIdx = string.Empty;
            string identityPrmName = string.Empty;

            if (HasIdentity)
            {
                identityIdx = @"IdentityPrmName = string.Join('', IdentityName, IdentityPrmIndex.ToString());
								IdentityPrmIndex++;";

                identity = PrepareIdentityPartForInsert();

                identityPrmName = "IdentityPrmName";
            }

            string insert = PrepareInsertPartForInsert();

            string columns = string.Empty;
            string parameters = string.Empty;
            string command = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string dbType = rw[Fields.SysTypeName].ToString();

                if (rw[Fields.IsIdentity].ToBool() || rw[Fields.IsComputed].ToBool() || IsTimestamp(dbType)) continue;

                string clmName = rw[Fields.ColumnName].ToString();
                columns += string.Format("if (pPrm.{0} != null) sb.Append(',{0}');", clmName) + NewLine;
                parameters += string.Format("if (pPrm.{0} != null) sb.Append(',@:{0}');", clmName) + NewLine;

                command += string.Format("if (pPrm.{0} != null) cmd.Parameters.AddWithValue('@:{0}', pPrm.{0});", clmName) + NewLine;
            }

            string code = @"
			private SqlCommand GetInsertCommand({0} pPrm)
			[[
				{8}

				{7}
				{1}
				string columns = GenerateInsertColumnList(pPrm);
				string parameters = GenerateInsertParameterList(pPrm);

				{9}

				if (pPrm.WriteLog)
				[[
					sql = string.Join('', sql, ccgLog.GetLogTableInsertQuery({6}));
				]]

				SqlCommand cmd = new SqlCommand(sql);
				AddInsertParameters(pPrm, cmd);
				
				if (pPrm.WriteLog) ccgLog.AddLogCommand(cmd, pPrm.UserID, TableName, pPrm.{5}.ToString(), CrudTypes.Insert, InsertValuesForLog(pPrm));
				return cmd;
			]]

			private string GenerateInsertColumnList({0} pPrm)
			[[
				StringBuilder sb = new StringBuilder();

				{2}
				return sb.ToString().TrimStart(^,^);
			]]

			private string GenerateInsertParameterList({0} pPrm)
			[[
				StringBuilder sb = new StringBuilder();

				{3}
				return sb.ToString().TrimStart(^,^);
			]]

			private void AddInsertParameters({0} pPrm, SqlCommand cmd)
			[[
				{4}
			]]";

            code = string.Format(code,
                                ClassName,
                                identity,
                                columns,
                                parameters,
                                command,
                                PrimaryKeyName,
                                identityPrmName,
                                identityIdx,
                                PrepareCCGLogInstance(),
                                insert
                                );

            return code;
        }

        #endregion

        #region [UPDATE] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string CodeForUpdate()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to update parameters by primary key in database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include parameters to be updated</param>
			public void Update({0} pPrm)
			[[
				SqlCommand cmd = GetCommandObject(pPrm, CrudTypes.Update);
				if (pPrm.WriteLog) cmd.AddTransaction();
				CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteNonQueryStatement(cmd);
			]]

			/// <summary>
			/// Used to update parameters by primary key in database
			/// </summary>
			/// <param name='pPrms'>Parameter object list which include parameters to be updated</param>
			/// <param name='pTransactional'>If this parameter set as true then update process is made in a sql transaction</param>
			public void Update(List<{0}> pPrms, bool pTransactional)
			[[
				List<SqlCommand> cmds = GetCommandObject(pPrms, CrudTypes.Update);
				CCGBatchProcess.Instance(Database).Proceed(cmds.ConvertAll(t => [[ return (DbCommand)t; ]]), pTransactional);
			]]

			/// <summary>
			/// Used to update parameters by 'where' condition in database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include parameters to be updated</param>
			/// <param name='pPrmForWhere'>Where clause parameter object, which include parameters to be checked data existancy</param>
			public void Update({0} pPrm, {0} pPrmForWhere)
			[[
				SqlCommand cmd = GetUpdateCommand(pPrm, pPrmForWhere);
				if (pPrm.WriteLog) cmd.AddTransaction();
				CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteNonQueryStatement(cmd);
			]]

			/// <summary>
			/// Used to update parameter lists by 'where' condition in database
			/// </summary>
			/// <param name='pPrms'>Parameter object list which include parameters to be updated</param>
			/// <param name='pPrmForWhere'>Where clause parameter object list, which include parameters to be checked data existancy</param>
			/// <param name='pTransactional'>If this parameter set as true then update process is made in a sql transaction</param>
			public void Update(List<{0}> pPrms, List<{0}> pPrmForWhere, bool pTransactional)
			[[
				SqlCommand cmd;
				List<SqlCommand> cmds = new List<SqlCommand>();

				for (int i = 0; i < pPrms.Count; i++)
				[[
					cmd = GetUpdateCommand(pPrms[i], pPrmForWhere[i]);
					cmds.Add(cmd);
				]]

				CCGBatchProcess.Instance(Database).Proceed(cmds.ConvertAll(t => [[ return (DbCommand)t; ]]), pTransactional);
			]]", ClassName);

            code = code + NewLine + CodeForUpdateCommand();
            AddRegion(ref code, "UPDATE");
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString()).Replace("^", "'");
            return code;
        }

        private string CodeForUpdateCommand()
        {
            string setString = string.Empty;
            string rowVerColumnName = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                if (rw[Fields.IsComputed].ToBool() || rw[Fields.IsIdentity].ToBool()) continue;
                string clmName = rw[Fields.ColumnName].ToString();
                string dbType = rw[Fields.SysTypeName].ToString();

                if (IsTimestamp(dbType)) { rowVerColumnName = clmName; continue; }

                bool nullable = rw[Fields.IsNullable].ToBool();
                string nullableString = nullable ? string.Format("|| pPrm.SetNull.{0}", clmName) : string.Empty;

                setString += string.Format("if (pPrm.{0} != null {1}) sb.Append(',{0} = @:{0}');", clmName, nullableString) + NewLine;
            }

            string rowVersionControlString = string.Empty;
            string rowVersionWhereString = "cmd.CommandText = cmd.CommandText.Replace('WHERE 1=1', string.Format('WHERE [[0]] ', cmd2.CommandText));";

            if (rowVerColumnName != string.Empty)
            {
                //This code block is used if there is a timestamp type field.
                //Tis type is used to check inconsistency state in SQL Server.
                //This property will be prepared for Oracle later

                rowVersionControlString = "sql = string.Format(sql + '; IF @@ROWCOUNT = 0 BEGIN ROLLBACK RAISERROR({0},17,1) RETURN END', Constants.RowVersionErrMsg);" + NewLine;
                rowVersionWhereString = @"
					string rowVersion = string.Empty;
					if (pPrmForWhere.Row_Version != null)
					{
						rowVersion = 'AND (Row_Version=@:Row_Version)';
						cmd.Parameters.AddWithValue('@:Row_Version', pPrmForWhere.Row_Version);
					}
					cmd.CommandText = cmd.CommandText.Replace('WHERE 1=1', string.Format('WHERE (1=1 [[0]]) [[1]] ', cmd2.CommandText, rowVersion));";
            }

            string code = @"
			private SqlCommand GetUpdateCommand({0} pPrm)
			[[
				{0} prm = new {0}();
				prm.{4} = pPrm.{4};
				return GetUpdateCommand(pPrm, prm);
			]]

			/// <summary>
			/// Used to get Command object for updating process.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include parameters to be updated</param>
			/// <param name='pPrmForWhere'>Where clause parameter object, which include parameters to be checked data existancy</param>
			/// <returns></returns>
			public SqlCommand GetUpdateCommand({0} pPrm, {0} pPrmForWhere)
			[[
				{5}

				string whereString = WhereClause(pPrmForWhere).Replace('MT.',string.Empty);
				string updateString = string.Empty;
				StringBuilder sb = new StringBuilder();

				{1}
				if (sb.ToString().Length > 0) updateString = sb.ToString().TrimStart(^,^);

				string sql = string.Format(@'UPDATE [[0]] SET [[1]] WHERE 1=1 ', TableName, updateString);
				{3}
				if (pPrm.WriteLog)
				[[
					sql = string.Format(@' 
					{6}
					',UpdateValuesForLog(pPrm), TableName, sql, ccgLog.GetLogTableInsertQuery());
				]]

				SqlCommand cmd = new SqlCommand(sql);
				AddParameters(pPrm, cmd);
				cmd.ChangeParameterNames('S');

				SqlCommand cmd2 = new SqlCommand(whereString);
				AddParameters(pPrmForWhere, cmd2);
				cmd2.ChangeParameterNames('W');

				{2}

				SqlParameter[] sqlPrmArr = new SqlParameter[cmd2.Parameters.Count];
				cmd2.Parameters.CopyTo(sqlPrmArr, 0);
				cmd2.Parameters.Clear();

				cmd.Parameters.AddRange(sqlPrmArr);

				if (pPrm.WriteLog) 
				[[
					{7}

					ccgLog.AddLogCommand(cmd, pPrm.UserID, TableName, string.Empty, CrudTypes.Update, string.Empty);
				]]
				
				return cmd;
			]]";

            code = string.Format(code,
                                ClassName,
                                setString,
                                rowVersionWhereString,
                                rowVersionControlString,
                                PrimaryKeyName,
                                PrepareCCGLogInstance(),
                                PrepareAddingLogPartForUpdate(),
                                PrepareUDLogParameters()
                                );
            return code;
        }

        #endregion

        #region [DELETE] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string CodeForDelete()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to delete data by given parameters in database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include deletition parameters</param>
			public void Delete({0} pPrm)
			[[
				SqlCommand cmd = GetCommandObject(pPrm, CrudTypes.Delete);
				if (pPrm.WriteLog) cmd.AddTransaction();
				CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteNonQueryStatement(cmd);
			]]

			/// <summary>
			/// Used to delete data by given parameter list in database
			/// </summary>
			/// <param name='pPrms'>Parameter object list which include deletition parameters</param>
			/// <param name='pTransactional'>If this parameter set as true then delete process is made in a sql transaction</param>
			public void Delete(List<{0}> pPrms, bool pTransactional)
			[[
				List<SqlCommand> cmds = GetCommandObject(pPrms, CrudTypes.Delete);
				CCGBatchProcess.Instance(Database).Proceed(cmds.ConvertAll(t => [[ return (DbCommand)t; ]]), pTransactional);
			]]", ClassName);

            code = code + NewLine + CodeForDeleteCommand();
            AddRegion(ref code, "DELETE");
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString()).Replace("^", "'");
            return code;
        }

        private string CodeForDeleteCommand()
        {
            string code = @"
			private SqlCommand GetDeleteCommand({0} pPrm)
			[[
				{1}

				string whereString = WhereClause(pPrm).Replace('MT.', string.Empty);
				string sql = string.Format(@'DELETE FROM [[0]] WHERE [[1]]', TableName, whereString);
				if (pPrm.WriteLog)
				[[
					sql = string.Format(@' 
					{2}
					', DeleteValuesForLog(), TableName, whereString, sql, ccgLog.GetLogTableInsertQuery());
				]]

				SqlCommand cmd = new SqlCommand(sql);
				AddParameters(pPrm, cmd);

				if (pPrm.WriteLog)
				[[
					{3}

					if (pPrm.WriteLog) ccgLog.AddLogCommand(cmd, pPrm.UserID, TableName, string.Empty, CrudTypes.Delete, string.Empty);
				]]

				return cmd;
			]]";

            code = string.Format(code,
                                ClassName,
                                PrepareCCGLogInstance(),
                                PrepareAddingLogPartForDelete(),
                                PrepareUDLogParameters()
                                );
            return code;
        }

        #endregion

        #region [SELECT] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string CodeForSelect()
        {
            string code = string.Empty;

            if (checkBoxCreateOnlySelectAsClass.Checked)
            {
                code = CodeForSelectAsClassList();
            }
            else
            {
                code = CodeForSelectAsDataTable();
                code += NewLine + CodeForSelectAggregateFunction();
                code += NewLine + CodeForSelectAsClass();
                code += NewLine + CodeForSelectAsClassList();
                code += NewLine + CodeForSelectCommand();
                code += NewLine + CodeForWhereClause();
                code += NewLine + CodeForAddParameters();
                code += NewLine + CodeForJoinString();
            }

            AddRegion(ref code, "SELECT");
            code = code.Replace("'", ((char)34).ToString()).Replace("^", "'");
            return code;
        }

        private string CodeForSelectAsDataTable()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to select data from database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <returns></returns>
			public DataTable Select({0} pPrm)
			[[
				return Select(pPrm, JoinTypes.NotJoin, string.Empty, false, 0, 0, 0);
			]]

			/// <summary>
			/// Used to select data from database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables.</param>
			/// <returns></returns>
			public DataTable Select({0} pPrm, JoinTypes pJoinType)
			[[
				return Select(pPrm, pJoinType, string.Empty, false, 0, 0, 0);
			]]

			/// <summary>
			/// Used to select data from database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables.</param>
			/// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
			/// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
			/// <param name='pTopN'>Specifies count of maksimum records which will be taken from database.</param>
			/// <returns></returns>
			public DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN)
			[[
				return Select(pPrm, pJoinType, pSortExpression, pDesc, pTopN, 0, 0);
			]]

			/// <summary>
			/// Used to select data from database
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables.</param>
			/// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
			/// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
			/// <param name='pTopN'>Specifies count of maksimum records which will be taken from database.</param>
			/// <param name='pPageSize'>Specifies page size for database paging</param>
			/// <param name='pPageIndex'>Specifies page index for database paging</param>
			/// <returns></returns>
			public DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex)
			[[
				SqlCommand cmd = GetSelectCommand(pPrm, pJoinType, pSortExpression, pDesc, pTopN, pPageSize, pPageIndex);

				DataTable oDt = new DataTable();
				CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).GetRecords(oDt, cmd);
				return oDt;
			]]

            /// <summary>
            /// Used to select data from database
            /// </summary>
            /// <param name='pPrm'>Parameter object which include where clause parameters</param>
            /// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
            /// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
            public DataTable Select({0} pPrm, string pSortExpression, bool pDesc)
            [[
                return Select(pPrm, JoinTypes.NotJoin, pSortExpression, pDesc, 0, 0, 0);
            ]]

            /// <summary>
            /// Used to select data from database
            /// </summary>
            /// <param name='pPrm'>Parameter object which include where clause parameters</param>
            /// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
            /// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
            /// <param name='pTopN'>Specifies count of maksimum records which will be taken from database.</param>
            public DataTable Select({0} pPrm, string pSortExpression, bool pDesc, int pTopN)
            [[
                return Select(pPrm, JoinTypes.NotJoin, pSortExpression, pDesc, pTopN, 0, 0);
            ]]
            ", ClassName);

            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CodeForSelectAggregateFunction()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to execute a Scalar sql statement by using aggregate functions. e.g: Count, Sum, ... etc.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pFunctionType'>Specifies the aggregate function type</param>
			/// <param name='pColumnName'>Specifies the column name which will be used as parameter to used aggregate function</param>
			/// <returns></returns>
			public object SelectAggregateFunction({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName)
			[[
				SqlCommand cmd = GetAggregateFunctionCommand(pPrm, pFunctionType, pColumnName);
				return CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteScalarStatement(cmd);
			]]

			/// <summary>
			/// Used to execute a Scalar sql statement by using aggregate functions. e.g: Count, Sum, ... etc.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pFunctionType'>Specifies the aggregate function type</param>
			/// <param name='pColumnName'>Specifies the column name which will be used as parameter to used aggregate function</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables. Default value is 'NotJoin'</param>
			/// <returns></returns>
			public object SelectAggregateFunction({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName, JoinTypes pJoinType)
			[[
				SqlCommand cmd = GetAggregateFunctionCommand(pPrm, pFunctionType, pColumnName, pJoinType);
				return CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteScalarStatement(cmd);
			]]

			/// <summary>
			/// Used to execute a Scalar sql statement by using aggregate functions. e.g: Count, Sum, ... etc.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pFunctionType'>Specifies the aggregate function type</param>
			/// <param name='pColumnName'>Specifies the column name which will be used as parameter to used aggregate function</param>
			/// <param name='pUseDistinct'>If this parameter set as true then distinct value of column is taken, before aggregate function. e.g.: COUNT(DISTINCT(ColumName))
			/// Default value is 'false'. Note: To use this property, column name should be set.</param>
			/// <returns></returns>
			public object SelectAggregateFunction({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName, bool pUseDistinct)
			[[
				SqlCommand cmd = GetAggregateFunctionCommand(pPrm, pFunctionType, pColumnName, JoinTypes.NotJoin, pUseDistinct);
				return CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteScalarStatement(cmd);
			]]

			/// <summary>
			/// Used to execute a Scalar sql statement by using aggregate functions. e.g: Count, Sum, ... etc.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pFunctionType'>Specifies the aggregate function type</param>
			/// <param name='pColumnName'>Specifies the column name which will be used as parameter to used aggregate function</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables. Default value is 'NotJoin'</param>
			/// <param name='pUseDistinct'>If this parameter set as true then distinct value of column is taken, before aggregate function. e.g.: COUNT(DISTINCT(ColumName))
			/// Default value is 'false'. Note: To use this property, column name should be set.</param>
			/// <returns></returns>
			public object SelectAggregateFunction({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName, JoinTypes pJoinType, bool pUseDistinct)
			[[
				SqlCommand cmd = GetAggregateFunctionCommand(pPrm, pFunctionType, pColumnName, pJoinType, pUseDistinct);
				return CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).ExecuteScalarStatement(cmd);
			]]

			/// <summary>
			/// Used to get command object which is used to execute a Scalar sql statement by using aggregate functions. e.g: Count, Sum, ... etc.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pFunctionType'>Specifies the aggregate function type</param>
			/// <param name='pColumnName'>Specifies the column name which will be used as parameter to used aggregate function</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables.</param>
			/// <returns></returns>
			public SqlCommand GetAggregateFunctionCommand({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName, JoinTypes pJoinType = JoinTypes.NotJoin, bool pUseDistinct = false)
			[[
				SqlCommand cmd = GetSelectCommand(pPrm, pJoinType, string.Empty, false, 0, -1, 0);
				
				string tableAlias = pColumnName == '*' || pColumnName.IsInteger() ? string.Empty : 'MT.';

				string aggr = string.Format('[[0]]([[1]][[2]])', pFunctionType.ToString(), tableAlias, pColumnName);

				if (pUseDistinct)
					aggr = string.Format('[[0]](DISTINCT([[1]][[2]]))', pFunctionType.ToString(), tableAlias, pColumnName);

				if (pJoinType != JoinTypes.NotJoin)
					cmd.RemoveJoinedTableColumsFromSelectString();

				cmd.CommandText = cmd.CommandText.Replace('MT.*', aggr);
				return cmd;
			]]", ClassName);

            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CodeForSelectAsClass()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to select data from the database type of table class
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <returns></returns>
			public {0} SelectAs{0}({0} pPrm)
			[[
				List<{0}> prms = SelectAs{0}List(pPrm);
				if (prms.Count > 0) return prms[0]; else return null;
			]]", ClassName);

            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CodeForSelectAsClassList()
        {
            string classPrm = string.Empty;
            string additionForIdentitiColumn = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmName = rw[Fields.ColumnName].ToString();
                string dbType = rw[Fields.SysTypeName].ToString();
                string csType = GetCsType(dbType);
                bool nullable = rw[Fields.IsNullable].ToBool();
                bool identity = rw[Fields.IsIdentity].ToBool();

                if (csType != DtCs.csString && csType != DtCs.csByteArr && nullable) csType += "?";

                if (identity)
                {
                    additionForIdentitiColumn = string.Format(
                    @"if (!pDt.Columns.Contains('{0}'))
                        [[
                            pDt.AddRowNumber('{0}');
                        ]]", clmName);
                }

                if (nullable)
                    classPrm += string.Format("prm.{0} = rw['{0}'] is DBNull ? null : ({1})rw['{0}'];", clmName, csType) + NewLine;
                else
                    classPrm += string.Format("prm.{0} = ({1})rw['{0}'];", clmName, csType) + NewLine;
            }

            string code1 = (@"
			/// <summary>
			/// Used to select data from the database type of table class list
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <returns></returns>
			public List<{0}> SelectAs{0}List({0} pPrm)
			[[
				DataTable oDt = Select(pPrm, JoinTypes.NotJoin, string.Empty, false, 0);
				return SelectAs{0}List(oDt);
			]]

			/// <summary>
			/// Used to select data from the database type of table class list
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
			/// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
			/// <param name='pTopN'>Specifies count of maksimum records which will be taken from database.</param>
			/// <returns></returns>
			public List<{0}> SelectAs{0}List({0} pPrm, string pSortExpression, bool pDesc, int pTopN)
			[[
				DataTable oDt = Select(pPrm, JoinTypes.NotJoin, pSortExpression, pDesc, pTopN);
				return SelectAs{0}List(oDt);
			]]

			/// <summary>
			/// Used to select data from the database type of table class list
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
			/// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
			/// <param name='pTopN'>Specifies count of maksimum records which will be taken from database.</param>
			/// <param name='pPageSize'>Specifies page size for database paging</param>
			/// <param name='pPageIndex'>Specifies page index for database paging</param>
			/// <returns></returns>
			public List<{0}> SelectAs{0}List({0} pPrm, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex)
			[[
				DataTable oDt = Select(pPrm, JoinTypes.NotJoin, pSortExpression, pDesc, pTopN, pPageSize, pPageIndex);
				return SelectAs{0}List(oDt);
			]]                        
            ");

            if (checkBoxCreateOnlySelectAsClass.Checked)
                code1 = string.Empty;

            string code2 = (@"
			/// <summary>
			/// Used to select data by using command object from the database type of table class list
			/// </summary>
			/// <param name='pCmd'>Specifies the Command object</param>
			/// <returns></returns>
			public List<{0}> SelectAs{0}List(SqlCommand pCmd)
			[[
				DataTable oDt = new DataTable();
				CCGDataObject.Instance(Database, ConnectionStringName, mCommandTimeout).GetRecords(oDt, pCmd);
				return SelectAs{0}List(oDt);
			]]

			/// <summary>
			/// Used to convert from DataTable object to table class list. Note: This DataTable should only contains entity of this generated class
			/// </summary>
			/// <param name='pDt'>DataTable object which will be converted</param>
			/// <returns></returns>
			public List<{0}> SelectAs{0}List(DataTable pDt)
			[[
				{0} prm;
				List<{0}> prms = new List<{0}>();

                {2}

				foreach (DataRow rw in pDt.Rows)
				[[
					prm = new {0}();
					{1}
					prms.Add(prm);
				]]
				return prms;
			]]");

            string code = string.Join("\r\n", code1, code2);
            code = string.Format(code, ClassName, classPrm, additionForIdentitiColumn);
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CodeForWhereClause()
        {
            StringBuilder where = new StringBuilder();
            string prm = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmName = rw[Fields.ColumnName].ToString();
                string dbType = rw[Fields.SysTypeName].ToString();
                string csType = GetCsType(dbType);

                if (IsUnsuitable(dbType)) continue;

                bool nullable = rw[Fields.IsNullable].ToBool();
                string nullableString = nullable ? string.Format("|| pPrm.ComparisonOperator.{0}.ToSqlOperator().Contains('NULL')", clmName) : string.Empty;

                if (csType == DtCs.csDateTime)
                    prm = string.Format(@"
							if (pPrm.{0} != null {1}) whereString.Append(string.Format(' [[0]] [[1]]'
							, pPrm.ConjunctionOperator.{0}.ToString()
							, pPrm.{0}2.HasValue ? '(MT.{0} BETWEEN @:{0} AND @:{0}2)' : string.Format('MT.{0} [[0]] [[1]]'
							, pPrm.ComparisonOperator.{0}.ToSqlOperator()
							, pPrm.ComparisonOperator.{0}.ToSqlOperator().Contains('NULL') ? string.Empty : '@:{0}'
							)));", clmName, nullableString);
                else if (csType == DtCs.csString)
                    prm = string.Format(@"
							if (pPrm.{0} != null {1}) whereString.Append(string.Format(' [[0]] MT.{0} [[1]] [[2]]'
							, pPrm.ConjunctionOperator.{0}.ToString()
							, pPrm.ComparisonOperator.{0}.ToSqlOperator()
							, pPrm.ComparisonOperator.{0}.ToSqlOperator().Contains('LIKE') ? '@:{0} {2} ^%^' : 
							  pPrm.ComparisonOperator.{0}.ToSqlOperator().Contains('NULL') ? string.Empty :'@:{0}'
							));", clmName, nullableString, GetStringConcatenationOperator());
                else
                    prm = string.Format(@"
							if (pPrm.{0} != null {1}) whereString.Append(string.Format(' [[0]] MT.{0} [[1]] [[2]]'
							, pPrm.ConjunctionOperator.{0}.ToString()
							, pPrm.ComparisonOperator.{0}.ToSqlOperator()
							, pPrm.ComparisonOperator.{0}.ToSqlOperator().Contains('NULL') ? string.Empty : '@:{0}'
							));", clmName, nullableString);

                where.Append(prm.ToString().Replace(Tab, string.Empty).Replace(NewLine, string.Empty) + NewLine);
            }

            string code = @"
			private string WhereClause({0} pPrm)
			[[
				if (pPrm == null) return string.Empty;

				if (!string.IsNullOrEmpty(pPrm.WhereClause)) 
					return pPrm.WhereClause;

				StringBuilder whereString = new StringBuilder();

				{1}
				string where = whereString.ToString().Trim();
				if (where.Length > 0)
				[[
					if (where.Substring(0, 3) == 'OR ') where = where.Substring(3);
					else if (where.Substring(0, 4) == 'AND ') where = where.Substring(4);
				]]
				else where = '1=1';

				if (!string.IsNullOrWhiteSpace(pPrm.WhereClause))
					where = string.Format('[[0]] [[1]]', where, pPrm.WhereClause);

				return where;
			]]
			{2}
			";

            code = string.Format(code, ClassName, where.ToString(), CodeForAdditionalWhereClause());
            code = code.Replace("[[", "{").Replace("]]", "}");
            return code;
        }

        private string CodeForAdditionalWhereClause()
        {
            string code = @"
				private static string SetWhereClauseAdditionalParameter([[0]] pPrm)
				{
					string whereClauseAdditional = string.Empty;
					if (!string.IsNullOrWhiteSpace(pPrm.WhereClauseAdditional))
					{
						if (pPrm.WhereClauseAdditional.Contains('WHERE'))
							pPrm.WhereClauseAdditional = pPrm.WhereClauseAdditional.Replace('WHERE', string.Empty);

						pPrm.WhereClauseAdditional = pPrm.WhereClauseAdditional.Trim();
						if (pPrm.WhereClauseAdditional.Substring(0, 3) == 'OR ')
							pPrm.WhereClauseAdditional = pPrm.WhereClauseAdditional.Substring(3);
						else if (pPrm.WhereClauseAdditional.Substring(0, 4) == 'AND ')
							pPrm.WhereClauseAdditional = pPrm.WhereClauseAdditional.Substring(4);

						whereClauseAdditional = string.Format('WHERE {0}', pPrm.WhereClauseAdditional);
					}
					return whereClauseAdditional;
				}";

            code = code.Replace("[[0]]", ClassName);

            return code;
        }

        private string CodeForSelectCommand()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to get Command object for selecting process.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables.</param>
			/// <returns></returns>
			public SqlCommand GetSelectCommand({0} pPrm, JoinTypes pJoinType)
			[[
				return GetSelectCommand(pPrm, pJoinType, string.Empty, false, 0, 0, 0);
			]]

			/// <summary>
			/// Used to get Command object for selecting process.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables.</param>
			/// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
			/// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
			/// <param name='pTopN'>Specifies count of maksimum records which will be taken from database.</param>
			/// <returns></returns>
			public SqlCommand GetSelectCommand({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN)
			[[
				return GetSelectCommand(pPrm, pJoinType, pSortExpression, pDesc, pTopN, 0, 0);
			]]

			/// <summary>
			/// Used to get Command object for selecting process.
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pJoinType'>Specifies the join type of main table and other related tables.</param>
			/// <param name='pSortExpression'>Specifies necessary sorting expression for sorting selected data</param>
			/// <param name='pDesc'>Specifies sorting direction. If it is set as true, sorting direction will be descending. Otherwise sorting direction will be ascending.</param>
			/// <param name='pTopN'>Specifies count of maksimum records which will be taken from database.</param>
			/// <param name='pPageSize'>Specifies page size for database paging</param>
			/// <param name='pPageIndex'>Specifies page index for database paging</param>
			/// <returns></returns>
			public SqlCommand GetSelectCommand({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex)
			[[
				string topN = pTopN > 0 ? {1} : string.Empty;
				string sortExp = string.IsNullOrWhiteSpace(pSortExpression) ? PrimaryKeyName : pSortExpression;
				string order = pDesc ? order = 'DESC' : 'ASC';

				string selectPart = string.Empty;
				string joinPart = string.Empty;
				GetJoinString(pPrm, ref selectPart, ref joinPart, pJoinType);

				string whereClause = WhereClause(pPrm);
				string whereClauseAdditional = pPrm.WhereClauseAdditional;
				string whereClausePID = pPrm.AllowDublicateRecords ? string.Empty : 'WHERE PID = 1';
				string whereClausePaging = pPageSize > 0 ? 'WHERE RwID BETWEEN ((@pPageIndex * @pPageSize) + 1) AND ((@pPageIndex * @pPageSize) + @pPageSize)' : string.Empty;

				bool calledForAggregateFunction = pPageSize == -1 ? true : false;
				if (!calledForAggregateFunction)
					whereClauseAdditional = SetWhereClauseAdditionalParameter(pPrm);

				string sql = string.Empty;
				{2}

				SqlCommand cmd = new SqlCommand(sql);
				if (pPrm == null) return cmd;
				AddParameters(pPrm, cmd);

				if (pPageSize > 0)
				[[
					cmd.Parameters.AddWithValue('@pPageIndex', pPageIndex);
					cmd.Parameters.AddWithValue('@pPageSize', pPageSize);
				]]

				return cmd;
			]]
			", ClassName, PrepareTopNForSelect(), PrepareSelectForSelect());

            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CodeForSortExpression()
        {
            string code = @"
				private void GetSortExpression(ref string pSortExpression, bool pDesc, ref string sortExp, ref string order)
				{
					string[] sortParts = pSortExpression.Split(^,^);
					string sortExpression = string.Empty;
					if (sortParts.Length > 1)
					{
						for (int i = 0; i < sortParts.Length; i++)
						{
							sortExpression = string.Format('[[0]],MT.', sortExpression, sortParts[i]);
						}
						pSortExpression = sortExpression.TrimStart(^,^);
					}
					else
					{
						pSortExpression = string.Format('MT.[[0]]', pSortExpression);
					}

					sortExp = string.Format('ORDER BY [[0]]', pSortExpression);
					order = pDesc ? order = 'DESC' : 'ASC';
				}
			";

            return code;
        }

        private string CodeForJoinString()
        {
            string code = string.Format(@"
			private void GetJoinString({0} pPrm, ref string pSelectPart, ref string pJoinPart, JoinTypes pJoinType)
			[[
				pSelectPart = string.Empty;
				pJoinPart = string.Empty;

				if (!string.IsNullOrEmpty(pPrm.JoinString.SelectPart))
					pSelectPart = string.Format('\r\n[[0]][[1]]', new string(((char)9), 7), pPrm.JoinString.SelectPart);

				if (!string.IsNullOrEmpty(pPrm.JoinString.JoinPart))
				[[
					pJoinPart = string.Format('\r\n[[0]][[1]]', new string(((char)9), 7), pPrm.JoinString.JoinPart);
					return;
				]]

				JoinTypes joinMode;
				string joinMethod;

				SetJoinModeAndJoinMethod(pJoinType, out joinMode, out joinMethod);

				if (joinMode == JoinTypes.NotJoin)
				[[
					return;
				]]
				else if (joinMode == JoinTypes.CustomJoinWithSelectedTables)
				[[
					foreach (KeyValuePair<Enum{0}RelatedTableList, EnumJoinMethods> item in pPrm.TableListToJoinCustom)
					[[
						pSelectPart = string.Format('[[0]]\r\n[[1]][[2]]', pSelectPart, new string(((char)9), 7), item.Key.GetEnumDescription().RSplit(^|^));
						pJoinPart = string.Format('[[0]]\r\n[[1]][[2]]', pJoinPart, new string(((char)9), 7), string.Format(item.Key.GetEnumDescription().LSplit(^|^), item.Value.GetEnumDescription()));
					]]
				]]
				else
				[[
					string tblRlnType = string.Empty;
					bool addTableToJoinString = false;

					foreach (Enum{0}RelatedTableList item in Enum.GetValues(typeof(Enum{0}RelatedTableList)))
					[[
						addTableToJoinString = false;
						tblRlnType = item.GetEnumValue().SubstringExt(0, 1);

						switch (joinMode)
						[[
							case JoinTypes.JoinWithLookupTables:
								if (tblRlnType == TableRelationTypes.LookupTable)
									addTableToJoinString = true;
								break;

							case JoinTypes.JoinWithRelatedTables:
								if (tblRlnType == TableRelationTypes.RelatedTable)
									addTableToJoinString = true;
								break;

							case JoinTypes.JoinWithDetailTables:
								if (tblRlnType == TableRelationTypes.DetailTable)
									addTableToJoinString = true;
								break;

							case JoinTypes.JoinWithLookupAndRelatedTables:
								if (tblRlnType == TableRelationTypes.LookupTable || tblRlnType == TableRelationTypes.RelatedTable)
									addTableToJoinString = true;
								break;

							case JoinTypes.JoinWithLookupAndDetailTables:
								if (tblRlnType == TableRelationTypes.LookupTable || tblRlnType == TableRelationTypes.DetailTable)
									addTableToJoinString = true;
								break;

							case JoinTypes.JoinWithRelatedAndDetailTables:
								if (tblRlnType == TableRelationTypes.RelatedTable || tblRlnType == TableRelationTypes.DetailTable)
									addTableToJoinString = true;
								break;

							case JoinTypes.JoinAll:
								//No Condition
								addTableToJoinString = true;
								break;
						]]

						if (addTableToJoinString)
						[[
							pSelectPart = string.Format('[[0]]\r\n[[1]][[2]]', pSelectPart, new string(((char)9), 7), item.GetEnumDescription().RSplit(^|^));
							pJoinPart = string.Format('[[0]]\r\n[[1]][[2]]', pJoinPart, new string(((char)9), 7), string.Format(item.GetEnumDescription().LSplit(^|^), joinMethod));
						]]
					]]
				]]

				if (!string.IsNullOrEmpty(pPrm.JoinStringAdditional.SelectPart))
					pSelectPart = string.Format('[[0]]\r\n,[[1]][[2]]', pSelectPart, new string(((char)9), 7), pPrm.JoinStringAdditional.SelectPart);

				if (!string.IsNullOrEmpty(pPrm.JoinStringAdditional.JoinPart))
					pJoinPart = string.Format('[[0]]\r\n[[1]][[2]]', pJoinPart, new string(((char)9), 7), pPrm.JoinStringAdditional.JoinPart);

			]]
			{1}
			", ClassName
             , CodeForSettingJoinStringParameters()
            );

            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private void GenerateColumnsForSelectPart(DataTable oDt)
        {
            oDt.Columns.Add("SelectPart", typeof(String));

            DataTable oDtMainTableColumnList = Dac.GetTableColumns(SchemaName, TableName);
            oDtMainTableColumnList.Columns.Remove("ColumnId");

            DataTable oDtJoinTableColumnList = new DataTable();
            foreach (DataRow rw in oDt.Rows)
            {
                oDtJoinTableColumnList = Dac.GetTableColumns(rw["SchemaName"].ToString(), rw["TableName"].ToString());
                string selectPart = string.Empty;

                foreach (DataRow rwJTCL in oDtJoinTableColumnList.Rows)
                {
                    string filterExpression = string.Format("ColumnName = '{0}'", rwJTCL["ColumnName"].ToString());
                    string columnName = string.Empty;
                    int existingCount = oDtMainTableColumnList.Select(filterExpression).Length;

                    if (existingCount > 0)
                    {
                        columnName = string.Format("{0}.{1} AS {1}{2}", rw["SelectPartAlias"].ToString(), rwJTCL["ColumnName"].ToString(), existingCount.ToString());
                    }
                    else
                    {
                        columnName = string.Format("{0}.{1}", rw["SelectPartAlias"].ToString(), rwJTCL["ColumnName"].ToString());
                    }
                    selectPart = string.Format("{0},{1}", selectPart, columnName);

                    DataRow oDrJTCL = oDtMainTableColumnList.NewRow();
                    oDrJTCL["ColumnName"] = rwJTCL["ColumnName"].ToString();
                    oDtMainTableColumnList.Rows.Add(oDrJTCL);
                    oDtMainTableColumnList.AcceptChanges();
                }
                selectPart = selectPart.TrimStart(',');
                rw["SelectPart"] = selectPart;
                oDt.AcceptChanges();
                rw.SetModified();
            }
        }

        private string CodeForSettingJoinStringParameters()
        {
            string code = @"
			private void SetJoinModeAndJoinMethod(JoinTypes pJoinType, out JoinTypes joinMode, out string joinMethod)
			[[
				joinMode = JoinTypes.NotJoin;
				joinMethod = string.Empty;

				switch (pJoinType)
				{
					//INNER JOIN
					case JoinTypes.JoinWithLookupTables:
						joinMode = JoinTypes.JoinWithLookupTables;
						joinMethod = JoinMethods.INNER_JOIN;
						break;

					case JoinTypes.JoinWithRelatedTables:
						joinMode = JoinTypes.JoinWithRelatedTables;
						joinMethod = JoinMethods.INNER_JOIN;
						break;

					case JoinTypes.JoinWithDetailTables:
						joinMode = JoinTypes.JoinWithDetailTables;
						joinMethod = JoinMethods.INNER_JOIN;
						break;

					case JoinTypes.JoinWithLookupAndRelatedTables:
						joinMode = JoinTypes.JoinWithLookupAndRelatedTables;
						joinMethod = JoinMethods.INNER_JOIN;
						break;

					case JoinTypes.JoinWithLookupAndDetailTables:
						joinMode = JoinTypes.JoinWithLookupAndDetailTables;
						joinMethod = JoinMethods.INNER_JOIN;
						break;

					case JoinTypes.JoinWithRelatedAndDetailTables:
						joinMode = JoinTypes.JoinWithRelatedAndDetailTables;
						joinMethod = JoinMethods.INNER_JOIN;
						break;

					case JoinTypes.JoinAll:
						joinMode = JoinTypes.JoinAll;
						joinMethod = JoinMethods.INNER_JOIN;
						break;

					//LEFT OUTER JOIN
					case JoinTypes.LeftJoinWithLookupTables:
						joinMode = JoinTypes.JoinWithLookupTables;
						joinMethod = JoinMethods.LEFT_OUTER_JOIN;
						break;

					case JoinTypes.LeftJoinWithRelatedTables:
						joinMode = JoinTypes.JoinWithRelatedTables;
						joinMethod = JoinMethods.LEFT_OUTER_JOIN;
						break;

					case JoinTypes.LeftJoinWithDetailTables:
						joinMode = JoinTypes.JoinWithDetailTables;
						joinMethod = JoinMethods.LEFT_OUTER_JOIN;
						break;

					case JoinTypes.LeftJoinWithLookupAndRelatedTables:
						joinMode = JoinTypes.JoinWithLookupAndRelatedTables;
						joinMethod = JoinMethods.LEFT_OUTER_JOIN;
						break;

					case JoinTypes.LeftJoinWithLookupAndDetailTables:
						joinMode = JoinTypes.JoinWithLookupAndDetailTables;
						joinMethod = JoinMethods.LEFT_OUTER_JOIN;
						break;

					case JoinTypes.LeftJoinWithRelatedAndDetailTables:
						joinMode = JoinTypes.JoinWithRelatedAndDetailTables;
						joinMethod = JoinMethods.LEFT_OUTER_JOIN;
						break;

					case JoinTypes.LeftJoinAll:
						joinMode = JoinTypes.JoinAll;
						joinMethod = JoinMethods.LEFT_OUTER_JOIN;
						break;

					//RIGHT OUTER JOIN
					case JoinTypes.RightJoinWithLookupTables:
						joinMode = JoinTypes.JoinWithLookupTables;
						joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
						break;

					case JoinTypes.RightJoinWithRelatedTables:
						joinMode = JoinTypes.JoinWithRelatedTables;
						joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
						break;

					case JoinTypes.RightJoinWithDetailTables:
						joinMode = JoinTypes.JoinWithDetailTables;
						joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
						break;

					case JoinTypes.RightJoinWithLookupAndRelatedTables:
						joinMode = JoinTypes.JoinWithLookupAndRelatedTables;
						joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
						break;

					case JoinTypes.RightJoinWithLookupAndDetailTables:
						joinMode = JoinTypes.JoinWithLookupAndDetailTables;
						joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
						break;

					case JoinTypes.RightJoinWithRelatedAndDetailTables:
						joinMode = JoinTypes.JoinWithRelatedAndDetailTables;
						joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
						break;

					case JoinTypes.RightJoinAll:
						joinMode = JoinTypes.JoinAll;
						joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
						break;

					//FULL OUTER JOIN
					case JoinTypes.FullJoinWithLookupTables:
						joinMode = JoinTypes.JoinWithLookupTables;
						joinMethod = JoinMethods.FULL_OUTER_JOIN;
						break;

					case JoinTypes.FullJoinWithRelatedTables:
						joinMode = JoinTypes.JoinWithRelatedTables;
						joinMethod = JoinMethods.FULL_OUTER_JOIN;
						break;

					case JoinTypes.FullJoinWithDetailTables:
						joinMode = JoinTypes.JoinWithDetailTables;
						joinMethod = JoinMethods.FULL_OUTER_JOIN;
						break;

					case JoinTypes.FullJoinWithLookupAndRelatedTables:
						joinMode = JoinTypes.JoinWithLookupAndRelatedTables;
						joinMethod = JoinMethods.FULL_OUTER_JOIN;
						break;

					case JoinTypes.FullJoinWithLookupAndDetailTables:
						joinMode = JoinTypes.JoinWithLookupAndDetailTables;
						joinMethod = JoinMethods.FULL_OUTER_JOIN;
						break;

					case JoinTypes.FullJoinWithRelatedAndDetailTables:
						joinMode = JoinTypes.JoinWithRelatedAndDetailTables;
						joinMethod = JoinMethods.FULL_OUTER_JOIN;
						break;

					case JoinTypes.FullJoinAll:
						joinMode = JoinTypes.JoinAll;
						joinMethod = JoinMethods.FULL_OUTER_JOIN;
						break;

					case JoinTypes.CustomJoinWithSelectedTables:
						joinMode = JoinTypes.CustomJoinWithSelectedTables;
						break;

					//NOT JOIN
					default:
						joinMode = JoinTypes.NotJoin;
						break;
				]]
			]]";

            return code;
        }

        private string CodeForAddParameters()
        {
            string command = string.Empty;
            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmName = rw[Fields.ColumnName].ToString();
                string dbType = rw[Fields.SysTypeName].ToString();

                if (IsTimestamp(dbType)) continue;

                string csType = GetCsType(dbType);

                bool nullable = rw[Fields.IsNullable].ToBool();
                string nullableString = nullable
                    ? string.Format("else if (pPrm.SetNull.{0}) pCmd.Parameters.AddWithValue('@:{0}', DBNull.Value);", clmName)
                    : string.Empty;

                command += string.Format("if (pPrm.{0} != null) pCmd.Parameters.AddWithValue('@:{0}', pPrm.{0}); {1}", clmName, nullableString) + NewLine;

                if (IsDate(dbType))
                    command += string.Format("if (pPrm.{0}2 != null) pCmd.Parameters.AddWithValue('@:{0}2', pPrm.{0}2);", clmName) + NewLine;
            }

            string code = @"
				private void AddParameters({0} pPrm, SqlCommand pCmd)
				[[
					{1}
				]]";

            code = string.Format(code, ClassName, command);
            return code;
        }

        #endregion

        #region [LOG   ] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string CodeForGetSqlCommandObject()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to get Command object depending on crud type. e.g: Insert, Update, Delete or Select
			/// </summary>
			/// <param name='pPrm'>Parameter object which include where clause parameters</param>
			/// <param name='pCrudType'>Crud type enum</param>
			/// <returns></returns>
			public SqlCommand GetCommandObject({0} pPrm, CrudTypes pCrudType)
			[[
				switch (pCrudType)
				[[
					case CrudTypes.Insert: return GetInsertCommand(pPrm);
					case CrudTypes.Update: return GetUpdateCommand(pPrm);
					case CrudTypes.Delete: return GetDeleteCommand(pPrm);
					case CrudTypes.Select: return GetSelectCommand(pPrm, JoinTypes.NotJoin, string.Empty, false, 0);
				]]
				return null;
			]]

			/// <summary>
			/// Used to get Command object list depending on crud type. e.g: Insert, Update, Delete or Select
			/// </summary>
			/// <param name='pPrm'>Parameter object list which include where clause parameters</param>
			/// <param name='pCrudType'>Crud type enum</param>
			/// <returns></returns>
			public List<SqlCommand> GetCommandObject(List<{0}> pPrm, CrudTypes pCrudType)
			[[
				List<SqlCommand> cmds = new List<SqlCommand>();

				GetCommandObject(pPrm, cmds, pCrudType);
				return cmds;
			]]

			/// <summary>
			/// Used to get Command object list depending on crud type. e.g: Insert, Update, Delete or Select
			/// </summary>
			/// <param name='pPrm'>Parameter object list which include where clause parameters</param>
			/// <param name='pCmds'>Referenced command object list</param>
			/// <param name='pCrudType'>Crud type enum</param>
			public void GetCommandObject(List<{0}> pPrm, List<SqlCommand> pCmds, CrudTypes pCrudType)
			[[
				SqlCommand cmd;

				foreach ({0} prm in pPrm)
				[[
					cmd = GetCommandObject(prm, pCrudType);
					pCmds.Add(cmd);
				]]
			]]
			", ClassName);

            AddRegion(ref code, "PUBLIC METHODS");
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CodeForIUDValuesForLog()
        {
            string code = string.Join("", CodeForInsertValuesForLog(), NewLine,
                                          CodeForUpdateValuesForLog(), NewLine,
                                          CodeForDeleteValuesForLog());

            AddRegion(ref code, "LOG METHODS");
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString()).Replace("^", "'");
            return code;
        }

        private string CodeForInsertValuesForLog()
        {
            string values = string.Empty;
            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string dbType = rw[Fields.SysTypeName].ToString();
                if (IsUnsuitable(dbType)) continue;

                string clmName = rw[Fields.ColumnName].ToString();
                if (clmName == PrimaryKeyName) continue;

                values += string.Format("if (pPrm.{0} != null) sb.Append(string.Format(',{0} = [[0]]', pPrm.{0}.ToString()));", clmName) + NewLine;
            }

            string code = string.Format(@"
			private string InsertValuesForLog({0} pPrm)
			[[
				StringBuilder sb = new StringBuilder();
				string s = string.Empty;

				{1}
				if (sb.ToString().Length > 0) s = sb.ToString().TrimStart(^,^);
				return s;
			]]", ClassName, values);

            return code;
        }

        private string CodeForUpdateValuesForLog()
        {
            string code = string.Format(@"
			private string UpdateValuesForLog({0} pPrm)
			[[
				StringBuilder sb = new StringBuilder();
				string s = string.Empty;

				{1}
				{2}
				return s;
			]]", ClassName, UpdateValuesForLog(), PrepareReturnStringForLogValues());

            return code;
        }

        private string UpdateValuesForLog()
        {
            string values = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmName = string.Empty;
                string clmnValue = GetColumnValue(rw, ref clmName);
                if (clmnValue == string.Empty) continue;

                values += string.Format("if (pPrm.{0} != null) sb.Append('{2}^,{0} = ^{2} {1}');",
                                        clmName, clmnValue, GetStringConcatenationOperator()) + NewLine;
            }

            return values;
        }

        private string CodeForDeleteValuesForLog()
        {
            string code = string.Format(@"
			private string DeleteValuesForLog()
			[[
				StringBuilder sb = new StringBuilder();
				string s = string.Empty;

				{0}
				{1}
				return s;
			]]", DeleteValuesForLog(), PrepareReturnStringForLogValues());

            return code;
        }

        private string DeleteValuesForLog()
        {
            string values = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmName = string.Empty;
                string clmnValue = GetColumnValue(rw, ref clmName);
                if (clmnValue == string.Empty) continue;

                values += string.Format("sb.Append('{2}^,{0} = ^{2} {1}');",
                                        clmName, clmnValue, GetStringConcatenationOperator()) + NewLine;
            }
            return values;
        }

        private string CodeForHelperMethods()
        {
            string code = string.Format(@"
			/// <summary>
			/// Used to concatenate each non-null parameter with its value, and get them as comma separated value.
			/// e.g.: Prm1 = Vaslue1, Prm2 = Value2, ...
			/// </summary>
			public string GetParametersAndValuesAsCsv({0} pPrm)
			[[
				return InsertValuesForLog(pPrm);
			]]

			/// <summary>
			/// Used to create a CCGDataObject instance
			/// </summary>
			/// <param name='pCommandTimeout'>The time in seconds to wait for the command to execute</param>
			public static CCGDataObject InstanceForCommandExecution(int pCommandTimeout) 
			[[ 
				return new CCGDataObject(Database, ConnectionStringName, pCommandTimeout); 
			]]

			", ClassName);

            AddRegion(ref code, "HELPER METHODS");
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString()).Replace("^", "'");

            return code;
        }

        #endregion

        private string CodeForSelectAsTypedDataSet()
        {
            string code = string.Format(@"
			public {1}DataSet SelectAsTypedDataSet({0} pPrm)
			[[
				return SelectAsTypedDataSet(pPrm, JoinTypes.NotJoin, string.Empty, false, 0);
			]]

			public {1}DataSet SelectAsTypedDataSet({0} pPrm, JoinTypes pJoinType)
			[[
				return SelectAsTypedDataSet(pPrm, pJoinType, string.Empty, false, 0);
			]]

			public {1}DataSet SelectAsTypedDataSet({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN)
			[[
				SqlCommand cmd = GetSelectCommand(pPrm, pJoinType, pSortExpression, pDesc, pTopN);

				IDataObject dto = null;
				dto = GetDataObject();
				{1}DataSet oDs = new {1}DataSet();
				dto.GetRecords(oDs.{1}, cmd, true);
				return oDs;
			]]", ClassName, TableName);

            code = code + NewLine + CodeForInsertOrUpdate();
            AddRegion(ref code, "TYPED DATASET INSERT-UPDATE-SELECT");
            code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CodeForInsertOrUpdate()
        {
            string code = string.Format(@"
			public void InsertOrUpdate({0}DataSet pTypedDataSet)
			[[
				InsertOrUpdate(pTypedDataSet, false, false);
			]]

			public void InsertOrUpdate({0}DataSet pTypedDataSet, bool pIsTransactional)
			[[
				InsertOrUpdate(pTypedDataSet, pIsTransactional, false);
			]]
			
			public void InsertOrUpdate({0}DataSet pTypedDataSet, bool pIsTransactional, bool pWriteLog)
			[[
				IDataObject dto = null;
				try
				[[
					dto = GetDataObject(pIsTransactional);
					dto.Update(pTypedDataSet.{0}, pWriteLog);

					if (IsRoot) dto.CommitTransaction();
				]]
				catch (Exception ex)
				[[
					if (IsRoot && dto != null) dto.RollbackTransaction();
					throw (ex);
				]]
			]]

			public void InsertOrUpdate({0}DataSet pTypedDataSet, bool pAcceptChangesDuringUpdate, bool pContinueUpdateOnError, bool pWriteLog)
			[[
				IDataObject dto = null;
				dto = GetDataObject();
				dto.Update(pTypedDataSet.{0}, pAcceptChangesDuringUpdate, pContinueUpdateOnError, pWriteLog);
			]]", TableName);

            return code;
        }

        #endregion

        #endregion

        #endregion

        #region [GENERATING TRIGGER SCRIPTS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void linkLabelGenerateTrigger_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(Message.TriggersWouldBeCreated, this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Cancel) return;

            if (checkBoxSelectMultyTables.Checked)
            {
                int selItemCount = listBoxTables.SelectedItems.Count;
                if (selItemCount == 0)
                {
                    MessageBox.Show(Message.NoTableSelected, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SetProgressBar(selItemCount);

                foreach (DataRowView item in listBoxTables.SelectedItems)
                {
                    RunProgressBar();

                    TableName = item.Row["TableName"].ToString();
                    PrimaryKeyColumnName();
                    CodeForTrigger();
                }
                TableName = string.Empty;
                CloseProgressBar();
            }
            else
            {
                PrimaryKeyColumnName();
                CodeForTrigger();
            }
            MessageBox.Show(Message.ProcessOk, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(TriggerPath);
        }

        private void CodeForTrigger()
        {
            //TO DO
            //This part was written for SQL Server. Later, oracle version will be added.

            if (IsFileExist(TriggerPath, TriggerName)) return;

            string version = GetVersion();
            string userIDFieldName = UserIDFieldName == string.Empty ? "''" : UserIDFieldName;
            string processTimeFieldName = "GETDATE()";

            string logTable = string.Format("{0}.LOG.CRUD_LOG", DataBaseName);
            if (textBoxFullTableNameForLog.Text != string.Empty) logTable = textBoxFullTableNameForLog.Text;

            GetColumns();

            #region [code]
            string code = @"
				USE [{11}]
				GO
				IF OBJECT_ID ('[{8}].[{9}]','TR') IS NOT NULL DROP TRIGGER [{8}].[{9}]; 
				GO

				SET ANSI_NULLS ON
				GO
				SET QUOTED_IDENTIFIER ON
				GO
				-- =========================================================
				-- Author:		CCG (CRUD Class Generator)
				-- Create date: {0}
				-- Runtime Version: {1}
				-- Description:	Log Insert and Update process on table
				-- =========================================================

				CREATE TRIGGER [{8}].[{9}] 
					ON {2}
					AFTER INSERT,UPDATE
				AS 
				BEGIN
					
					SET NOCOUNT ON;
					
					DECLARE @:pUserID VARCHAR(MAX);
					DECLARE @:pTableName VARCHAR(MAX) = '{2}';
					DECLARE @:pCrudType CHAR(1) = 'U';
					DECLARE @:pPKValue VARCHAR(MAX);
					DECLARE @:pCrudValues VARCHAR(MAX);
					
					SELECT @:pUserID = {3} FROM INSERTED

					SELECT
						 @:pPKValue = CAST({5} AS VARCHAR(MAX))
						,@:pCrudValues = {6}
					FROM DELETED	
					
					IF @:pCrudValues IS NULL 
						BEGIN
							SET @:pCrudType = 'I'
						
							SELECT 
								 @:pPKValue = CAST({5} AS VARCHAR(MAX))
								,@:pCrudValues = {7}
							FROM INSERTED
						END

					IF @:pPKValue IS NOT NULL
					BEGIN                			
						INSERT INTO {10}
									(CrudUserID, CrudTableName, CrudType, CrudDate, PKValue, CrudValues)
							VALUES(@pUserID,@pTableName,@pCrudType,GETDATE(),@pPKValue,@pCrudValues)
					END
				END
				GO
				";
            #endregion

            code = string.Format(code,
                                DateTime.Now,
                                version,
                                TableFullName,
                                userIDFieldName,
                                processTimeFieldName,
                                PrimaryKeyName,
                                TriggerValuesForLog(CrudTypes.Update),
                                TriggerValuesForLog(CrudTypes.Insert),
                                SchemaName,
                                TriggerName,
                                logTable,
                                DataBaseName
                                );

            code = MakeCompatibleForSelectedDb(code);

            bool written = WriteFile(code, TriggerPath, FullTriggerPath);

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(TriggerName);
        }

        private enum CrudTypes
        {
            Insert,
            Update,
            Delete,
            Select
        }
        private string TriggerValuesForLog(CrudTypes pType)
        {
            string values = string.Empty;
            int i = 0;
            string tab = string.Empty;

            foreach (DataRow rw in DTColumnsInfo.Rows)
            {
                string clmName = string.Empty;
                string clmnValue = GetColumnValue(rw, ref clmName);
                if (clmnValue == string.Empty) continue;

                if (i > 0) tab = new string((char)9, 11);

                if (pType == CrudTypes.Update)
                {
                    values += string.Format(tab + "+ CASE WHEN UPDATE({0}) THEN '{0}=' + {1} + ',' ELSE '' END", clmName, clmnValue) + NewLine; i++;
                }
                else if (pType == CrudTypes.Insert)
                {
                    values += string.Format(tab + "+'{0}=' + {1} + ','", clmName, clmnValue) + NewLine; i++;
                }

            }
            values = values.TrimStart('+').Replace("^", "'");
            return values;
        }

        #endregion

        #region[DATABASE TYPE DEPENDENT CODES] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string GetColumnValue(DataRow rw, ref string clmName)
        {
            string dbType = rw[Fields.SysTypeName].ToString();

            if (IsUnsuitable(dbType)) return string.Empty;
            if (rw[Fields.IsComputed].ToBool()) return string.Empty;

            clmName = rw[Fields.ColumnName].ToString();
            if (clmName == PrimaryKeyName) return string.Empty;

            bool nullable = rw[Fields.IsNullable].ToBool();
            bool numeric = IsNumeric(dbType);
            bool date = IsDate(dbType);

            string clmnValue = string.Format("{0}", clmName);

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                if (numeric) clmnValue = string.Format("CAST({0} AS VARCHAR(36))", clmnValue);
                if (date) clmnValue = string.Format("CONVERT(VARCHAR(36),{0},104)", clmnValue);
                if (nullable) clmnValue = string.Format("ISNULL({0},^^)", clmnValue);
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                if (numeric) clmnValue = string.Format("CAST({0} AS VARCHAR2(36))", clmnValue);
                if (date) clmnValue = string.Format("TO_CHAR({0},'DD.MM.YYYY')", clmnValue);
                if (nullable) clmnValue = string.Format("NVL({0},^^)", clmnValue);
            }
            return clmnValue;
        }

        private string PrepareSelectForSelect()
        {
            string select = string.Empty;
            string noLock = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                if (checkBoxAddNoLock.Checked) noLock = "WITH(NOLOCK) ";

                select = @"
				if (calledForAggregateFunction)
				[[
					sql = string.Format(@'
							SELECT MT.*
							FROM [[0]] AS MT WITH(NOLOCK) 
								 [[1]] 
							WHERE [[2]]
								[[3]]
							', TableName, joinPart, whereClause, whereClauseAdditional);
				]]
				else
				[[
					sql = string.Format(@'
								;WITH CCGMainCTE AS (
	
								SELECT [[0]] MT.*
								FROM [[1]] AS MT WITH(NOLOCK) 
								WHERE [[2]] 
							),
							CCGJoinCTE AS (
								SELECT MT.*
									[[3]]

								FROM CCGMainCTE AS MT
									[[4]] 
							),
							CCGJoinFilterCTE AS (
								SELECT ROW_NUMBER() OVER (PARTITION BY [[5]] ORDER BY [[6]] [[7]]) PID, *
								FROM CCGJoinCTE
								[[8]]
							),
							CCGPagingCTE AS (
								SELECT ROW_NUMBER() OVER(ORDER BY [[6]] [[7]]) AS RwID, *
								FROM CCGJoinFilterCTE
								[[9]]
							)
							SELECT *
							FROM CCGPagingCTE
							[[10]]
						', topN, TableName, whereClause, selectPart, joinPart, PrimaryKeyName, sortExp, order, whereClauseAdditional, whereClausePID, whereClausePaging);
				]]
				";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                select = @"
				if (calledForAggregateFunction)
				[[
					sql = string.Format(@'
							SELECT MT.*
							FROM [[0]] AS MT WITH(NOLOCK) 
								 [[1]] 
							WHERE [[2]]
								[[3]]
							', TableName, joinPart, whereClause, whereClauseAdditional);
				]]
				else
				[[
					sql = string.Format(@'
								;WITH CCGMainCTE AS (
	
								SELECT MT.
								FROM [[1]] AS MT WITH(NOLOCK) 
								WHERE [[2]] [[0]]
							),
							CCGJoinCTE AS (
								SELECT MT.*
									[[3]]

								FROM CCGMainCTE AS MT
									[[4]] 
							),
							CCGJoinFilterCTE AS (
								SELECT ROW_NUMBER() OVER (PARTITION BY [[5]] ORDER BY [[6]] [[7]]) PID, *
								FROM CCGJoinCTE
								[[8]]
							),
							CCGPagingCTE AS (
								SELECT ROW_NUMBER() OVER(ORDER BY [[6]] [[7]]) AS RwID, *
								FROM CCGJoinFilterCTE
								[[9]]
							)
							SELECT *
							FROM CCGPagingCTE
							[[10]]
						', topN, TableName, whereClause, selectPart, joinPart, PrimaryKeyName, sortExp, order, whereClauseAdditional, whereClausePID, whereClausePaging);

					
				]]
				";
                /* Eski Oracle sorgusu
                 * sql = string.Format(@'
                        SELECT MT.* [[0]] 
                        FROM [[1]] AS MT {0} 
                             [[2]] 
                        WHERE [[3]] [[4]]
                        [[5]] [[6]]
                        ', selectPart, TableName, joinPart, whereString, topN, sortExp, order);
                 */
            }

            select = string.Format(select, noLock);
            return select;
        }

        private string PrepareTopNForSelect()
        {
            string topN = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                topN = "string.Format('TOP [[0]]', pTopN.ToString())";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                topN = "string.Format(' AND ROWNUM <= [[0]]', pTopN.ToString())";
            }

            return topN;
        }

        private string PrepareAddingLogPartForUpdate()
        {
            string code = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                code = @"SELECT  @pPKValue = ISNULL(@pPKValue + ^,^ , ^^) + CAST({0} AS VARCHAR(36)), 
								@pCrudValues = ISNULL(@pCrudValues + ^ | ^ , ^^) + [[0]]
						 FROM [[1]] WHERE 1=1 

						 [[2]] 
						 [[3]]
						";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                code = @"SELECT CAST({0} AS VARCHAR2(36)) INTO :pPKValue FROM [[1]] WHERE 1=1;
						 SELECT [[0]] INTO :pCrudValues FROM [[1]] WHERE 1=1;                        

						 [[2]];
						 [[3]];
						";
            }

            code = string.Format(code, PrimaryKeyName);
            return code;
        }

        private string PrepareUDLogParameters()
        {
            string code = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                code = @"cmd.Parameters.AddWithValue('@pPKValue', DBNull.Value);
						 cmd.Parameters.AddWithValue('@pCrudValues', DBNull.Value);
						";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                code = @"cmd.Parameters.Add(':pPKVALUE', OracleDbType.Varchar2, 36, DBNull.Value, ParameterDirection.Output);
						 cmd.Parameters.Add(':pCRUDVALUES', OracleDbType.Varchar2, 4000, DBNull.Value, ParameterDirection.Output);
						";
            }

            code = string.Format(code, PrimaryKeyName);
            return code;
        }

        private string PrepareInsertPartForInsert()
        {
            string insert = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                insert = @"string sql = string.Format(@'INSERT INTO [[0]] ([[1]]) VALUES([[2]]) [[3]]', TableName, columns, parameters, identity);";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                insert = @"string sql = string.Format(@'BEGIN INSERT INTO [[0]] ([[1]]) VALUES([[2]]) [[3]] END;',  TableName, columns, parameters, identity);";
            }

            return insert;
        }

        private string PrepareIdentityPartForInsert()
        {
            string identity = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                identity = "string identity = string.Format('DECLARE [0] {0}; SET [0] = SCOPE_IDENTITY()', IdentityPrmName);";
                identity = string.Format(identity, IdentityColumnDbDataTypeName);
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                identity = @"
					string identity = string.Format('RETURNING {0} INTO [0];', IdentityPrmName);
					";

                identity = string.Format(identity, IdentityColumnName);
            }

            identity = identity.Replace("[", "{").Replace("]", "}") + NewLine;
            return identity;
        }

        private bool CheckColumnIsIdentity(DataRow pRow)
        {
            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                return pRow[Fields.IsIdentity].ToBool();
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                string clmnName = pRow[Fields.ColumnName].ToString();
                return clmnName == PrimaryKeyName && checkBoxPkIsIdentity.Checked;
            }
            else
            {
                return false;
            }
        }

        private void PrepareGettingIdentityClauses(ref string pIdentity1, ref string pIdentity2, ref string pIdentity3, ref string pIdentity4, string pInsertReturnType)
        {
            string convertType = GetSystemDataType(pInsertReturnType);

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                #region [Identity 1] ------------------

                pIdentity1 = @"SqlParameter newKey = (SqlParameter)cmd.GetIdentityValue(IdentityPrmName);
							   newKey.DbType = DbType.{0};";
                pIdentity1 = string.Format(pIdentity1, convertType);

                #endregion

                #region [Identity 2] ------------------

                pIdentity2 = @"pPrm.{0} = newKey.Value != DBNull.Value ? Convert.To{2}(newKey.Value.ToString()) : default({1});
							   return pPrm.{0} ?? default({1});";
                pIdentity2 = string.Format(pIdentity2, IdentityColumnName, pInsertReturnType, convertType);

                #endregion

                #region [Identity 3] ------------------

                pIdentity3 = @"List<SqlParameter> newKeys = new List<SqlParameter>();
								for (int i = 0; i < cmds.Count; i++)
								[[
									SqlParameter newKey = (SqlParameter)cmds[i].GetIdentityValue(IdentityName + i.ToString());
									newKey.DbType = DbType.{0};
									newKeys.Add(newKey);
								]]";
                pIdentity3 = NewLine + string.Format(pIdentity3, convertType) + NewLine;

                #endregion

                #region [Identity 4] ------------------

                pIdentity4 = @"for (int i = 0; i < newKeys.Count; i++)
								[[
									pPrms[i].{0} = newKeys[i].Value != DBNull.Value ? Convert.To{2}(newKeys[i].Value.ToString()) : default({1});
								]]";
                pIdentity4 = NewLine + string.Format(pIdentity4, IdentityColumnName, pInsertReturnType, convertType);

                #endregion

            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                #region [Identity 1] ------------------

                pIdentity1 = @"OracleParameter newKey = cmd.Parameters.Add(IdentityPrmName, OracleDbType.Int32, ParameterDirection.Output);";
                pIdentity1 = string.Format(pIdentity1, TableName);

                #endregion

                #region [Identity 2] ------------------

                pIdentity2 = @"if (!string.IsNullOrEmpty(newKey.Value.ToString()) && newKey.Value.ToString() != 'null')
									pPrm.{0} = newKey.Value != DBNull.Value ? Convert.To{2}(newKey.Value.ToString()) : default({1});
							   return pPrm.{0} ?? default({1});";
                pIdentity2 = string.Format(pIdentity2, IdentityColumnName, pInsertReturnType, convertType);

                #endregion

                #region [Identity 3] ------------------

                pIdentity3 = @"List<SqlParameter> newKeys = new List<SqlParameter>();
											  for (int i = 0; i < cmds.Count; i++)
											  [[
												  OracleParameter newKey = cmds[i].Parameters.Add(string.Join('', IdentityPrmName, i.ToString()), OracleDbType.Int32, ParameterDirection.Output);
												  newKeys.Add(newKey);
											  ]]";
                pIdentity3 = NewLine + string.Format(pIdentity3, TableName) + NewLine;

                #endregion

                #region [Identity 4] ------------------

                pIdentity4 = @"for (int i = 0; i < newKeys.Count; i++)
								[[
									if (!string.IsNullOrEmpty(newKeys[i].Value.ToString()) && newKeys[i].Value.ToString() != 'null')
										pPrms[i].{0} = newKeys[i].Value != DBNull.Value ? Convert.To{2}(newKeys[i].Value.ToString()) : default({1});
								]]";
                pIdentity4 = NewLine + string.Format(pIdentity4, IdentityColumnName, pInsertReturnType, convertType);

                #endregion
            }


        }

        private string PrepareAddingLogPartForDelete()
        {
            string code = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                code = @"SELECT  @pPKValue = ISNULL(@pPKValue + ^,^ , ^^) + CAST({0} AS VARCHAR(36)), 
								@pCrudValues = ISNULL(@pCrudValues + ^ | ^ , ^^) + [[0]]
						 FROM [[1]] WHERE [[2]]

						 IF @pPKValue IS NOT NULL AND @pCrudValues IS NOT NULL 
							BEGIN 
								[[3]]
								[[4]]
							END    
						";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                code = @"SELECT CAST({0} AS VARCHAR2(36)) INTO :pPKValue FROM [[1]] WHERE [[2]];
						 SELECT [[0]] INTO :pCrudValues FROM [[1]] WHERE [[2]];

						 IF (:pPKValue IS NOT NULL AND :pCrudValues IS NOT NULL) THEN
							[[3]];
							[[4]];
						 END IF;
						";
            }

            code = string.Format(code, PrimaryKeyName);
            return code;
        }

        private string AdditionalReplacesDependonDbType(string pCode)
        {
            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                pCode = pCode.ReplaceWholeWord("@:", "@");
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                pCode = pCode.ReplaceWholeWord("@:", ":")
                    .ReplaceWholeWord("SqlCommand", "OracleCommand")
                    .ReplaceWholeWord("SqlParameter", "OracleParameter")
                    .ReplaceWholeWord("Parameters.AddWithValue", "Parameters.Add")
                    .ReplaceWholeWord("pPKValue", "pPKVALUE")
                    .ReplaceWholeWord("pCrudValues", "pCRUDVALUES")
                    .Replace(" AS MT ", " MT ")
                    ;
            }

            return pCode;
        }

        private string GetUsingStatementForDbProvider()
        {
            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                return "using System.Data.SqlClient;";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                return "using Oracle.DataAccess.Client;";
            }
            else
            {
                return string.Empty;
            }
        }

        private string MakeCompatibleForSelectedDb(string pCode)
        {
            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                pCode = pCode.Replace("@:", "@");
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                pCode = pCode.Replace("@:", ":").Replace("+", "||");
            }

            return pCode;
        }

        private string PrepareSaveQueryPartForSave()
        {
            string code = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                code = @"string sql = @'
						[[0]]
						IF @@ROWCOUNT = 0
							BEGIN
								[[1]]
							END
						';

						int i = 1;
						if (counter > 0) i = counter;
						SqlCommand cmd = new SqlCommand();

						SqlCommand cmdUpdate = (SqlCommand)GetUpdateCommand(pPrm, pPrmForWhereClause).ChangeParameterNames(i + 1);
						SqlCommand cmdInsert = (SqlCommand)GetCommandObject(pPrm, CrudTypes.Insert).ChangeParameterNames(i + 2);

						cmd.CommandText = string.Format(sql, cmdUpdate.CommandText, cmdInsert.CommandText);
						cmd.MergeCommandPrms(cmdUpdate);
						cmd.MergeCommandPrms(cmdInsert);

						return cmd;
						";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                code = @"string sql = @'
						BEGIN
							[[0]];
							IF (:CNT > 0) THEN
								[[1]];
							ELSE
								[[2]]
							END IF;
						END;';

						int i = 1;
						if (counter > 0) i = counter;
						OracleCommand cmd = new OracleCommand();

						OracleCommand cmdCount = (OracleCommand)GetAggregateFunctionCommand(pPrmForWhereClause, SqlAggregateFunctions.COUNT, '*').ChangeParameterNames(i);
						OracleCommand cmdUpdate = (OracleCommand)GetUpdateCommand(pPrm, pPrmForWhereClause).ChangeParameterNames(i + 1);
						OracleCommand cmdInsert = (OracleCommand)GetCommandObject(pPrm, CrudTypes.Insert).ChangeParameterNames(i + 2);

						cmdCount.CommandText = cmdCount.CommandText.Replace('FROM','INTO :CNT FROM');
						cmdCount.Parameters.Add(':CNT', OracleDbType.Int32, ParameterDirection.Input);

						cmd.CommandText = string.Format(sql, cmdCount.CommandText, cmdUpdate.CommandText, cmdInsert.CommandText);
						cmd.MergeCommandPrms(cmdCount);
						cmd.MergeCommandPrms(cmdUpdate);
						cmd.MergeCommandPrms(cmdInsert);

						return cmd;
						";

                code = string.Format(code, TableFullName);
            }

            return code;
        }

        private string PrepareSaveQueryPartForSave2()
        {
            string code = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                code = @"string sql = @'
						IF ([[0]]) = 0
							BEGIN
								[[1]]
							END';

						int i = 1;
						if (counter > 0) i = counter;
						SqlCommand cmd = new SqlCommand();

						SqlCommand cmdCount = (SqlCommand)GetAggregateFunctionCommand(pPrmForWhereClause, SqlAggregateFunctions.COUNT, '*').ChangeParameterNames(i);
						SqlCommand cmdInsert = (SqlCommand)GetCommandObject(pPrm, CrudTypes.Insert).ChangeParameterNames(i + 1);

						cmd.CommandText = string.Format(sql, cmdCount.CommandText, cmdInsert.CommandText);
						cmd.MergeCommandPrms(cmdCount);
						cmd.MergeCommandPrms(cmdInsert);

						return cmd;
						";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                code = @"string sql = @'
						BEGIN
							[[0]];
							EXCEPTION WHEN DUP_VAL_ON_INDEX THEN
							ROLLBACK;
						END;';

						int i = 1;
						if (counter > 0) i = counter;
						SqlCommand cmd = new SqlCommand();

						SqlCommand cmdInsert = (SqlCommand)GetCommandObject(pPrm, CrudTypes.Insert).ChangeParameterNames(i + 1);

						cmd.CommandText = string.Format(sql, cmdInsert.CommandText);
						cmd.MergeCommandPrms(cmdInsert);

						return cmd;
						";
            }

            return code;
        }

        private string GetStringConcatenationOperator()
        {
            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                return "+";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                return "||";
            }

            return "+";
        }

        private string PrepareReturnStringForLogValues()
        {
            string s = string.Empty;

            if (DatabaseType == DatabaseTypes.MS_SQL)
            {
                s = @"s = string.Format('^[[0]]', sb.ToString().TrimStart(^+^).TrimStart(^\^^).TrimStart(^,^));";
            }
            else if (DatabaseType == DatabaseTypes.ORACLE)
            {
                s = @"s = string.Format('^[[0]]', sb.ToString().TrimStart(^|^).TrimStart(^\^^).TrimStart(^,^));";
            }

            return s;
        }

        #endregion

        #region [HELPER METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private bool CheckIfEndPointAlreadyExist()
        {
            if (checkBoxSelectMultyTables.Checked) return true;

            if (File.Exists(FullAppConfigPath))
            {
                TextReader tr = new StreamReader(FullAppConfigPath, Encoding.Default);
                string appConfig = tr.ReadToEnd();
                tr.Close();

                string msg = string.Empty;
                if (appConfig.IndexOf(EndPoint_address) > -1) msg = EndPoint_address;
                msg = string.Format("[{0}]\r\n", msg);

                if (msg.Length > 6)
                {
                    msg = Message.MsgGeneral(msg, Message.AlreadyExistInAppConfig);
                    DialogResult result = MessageBox.Show(msg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.No) return false;
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(Message.NoAppConfigFile, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return false;
            }
            return true;
        }

        private bool GeneralValidation()
        {
            string errMsg = string.Empty;

            if (textBoxProjectPath.Text == string.Empty) errMsg = Message.MandatoryProjectPath;
            if (textBoxClassName.Text == string.Empty) errMsg = Message.MandatoryClassName;
            if (textBoxCcSubPath2.Text == string.Empty) errMsg = Message.MandatoryBSNamespace;
            if (textBoxInterfaceSubPath2.Text == string.Empty) errMsg = Message.MandatoryInterfaceNamespace;

            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool ValidateForPrmAndCrudClasses()
        {
            if (!CheckNecessaryFieldsIsFilled()) return false;

            GetColumns();
            if (!TableValidation()) return false;
            if (checkBoxCrudCC.Checked)
            {
                PrimaryKeyColumnName();
                if (PrimaryKeyName == string.Empty)
                {
                    MessageBox.Show(Message.NoPKField, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private string GetCCGGeneratorComment()
        {
            string version = GetVersion();
            string comment = @"
				/* [GENERATOR COMMENT] {0}
				 *  
				 * This code was generated by 'CCG (CRUD Class Generator)' Copyright © 2010
				 *
				 * Generation Time: {1} 
				 * Runtime Version: {2}
				 * 
				 * Settings:
				 *      ||Add 'NoLock' = {3}
				 *      ||Create Only SELECT = {4}
				 *      ||Parameter class generated {5}
				 *      {6}
				 *      {7}
				 *
				 * WARNING: Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
				 * If you need to change or add any code, recommended that you create a new partial class with the same namespace.
				*/
			";

            int rhl = 106;    //maximum region header length
            string regionHeaderChar = new string('~', rhl - 17);

            string serviceContract = string.Format("||Add 'ServiceContract' = {0}", checkBoxCrudInterface.Checked ? checkBoxAddServiceContract.Checked.ToString() : "False");
            serviceContract = WorkMode == WorkingModes.WCF ? serviceContract : string.Empty; ;

            string typedDs = string.Format("||Add TypedDataSet Codes = {0}", checkBoxTypedDs.Checked.ToString());
            typedDs = WorkMode == WorkingModes.WCF ? typedDs : string.Empty;

            comment = string.Format(comment,
                regionHeaderChar,
                DateTime.Now,
                version,
                checkBoxAddNoLock.Checked.ToString(),
                checkBoxCreateOnlySelect.Checked.ToString(),
                GetPrmClassGenerationFile(),
                serviceContract,
                typedDs
                );

            comment = comment.Replace("  ", "").Replace("|", "\t").Replace("'", ((char)34).ToString());

            return comment;
        }

        private string PrepareCCGLogInstance()
        {
            string fullTableName = string.Empty;
            if (textBoxFullTableNameForLog.Text != string.Empty)
                fullTableName = string.Format("'{0}'", textBoxFullTableNameForLog.Text);
            string code = string.Format("CCGLog ccgLog = new CCGLog({0});", fullTableName);
            return code;
        }

        private string GetPrmClassGenerationFile()
        {
            if (checkBoxPrmClassInInterfaceFile.Checked) return checkBoxPrmClassInInterfaceFile.Text;
            if (checkBoxPrmClassInCCFile.Checked) return checkBoxPrmClassInCCFile.Text;
            if (checkBoxPrmClassSeparate.Checked) return checkBoxPrmClassSeparate.Text;
            return string.Empty;
        }

        #endregion

    }
}
