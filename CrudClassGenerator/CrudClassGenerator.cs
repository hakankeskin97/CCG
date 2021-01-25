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
			using Types.CustomTypes;
			using System.ServiceModel;

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
			if (IsFileExist(PrmClassFullPath, PrmClassName)) return;

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
				", InterfaceNameSpace, prmCode, infoCode, GetCCGGeneratorComment(), inheritanceClassName);
			code = code.Replace("[[", "{").Replace("]]", "}");
			//code = code.Replace(ClassName + "Prm", ClassName);
			#endregion

			bool written = WriteFile(code, InterfacePath, PrmClassFullPath);

			if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(PrmClassName);
		}

		private string GeneratePrmCode()
		{
			string tblName = string.Format("public string TabloAdi = '{0}';", TableFullName).Replace("'", ((char)34).ToString());
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
				property += string.Format("{2} public {0} {1} [[ get [[ return m{1}; ]] set [[ m{1} = value; ]] ]] {3}", csType, clmnName, clmnTypeComment, NewLine);

				if (IsDate(dbType))
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

			string code = string.Format("public const string Database = '{0}';", DatabaseType == DatabaseTypes.MS_SQL ? DataBaseName : DataSourceName);
			code += NewLine + string.Format("public const string TableName = '{0}';", TableFullName);

			if (!checkBoxCreateOnlySelect.Checked)
			{
				if (HasIdentity)
				{
					code += NewLine + "private int IdentityPrmIndex = 0;";
					code += NewLine + string.Format("public string IdentityPrmName = '@:ID_{0}';", TableName);
					code += NewLine + string.Format("public const string IdentityName = '@:ID_{0}';", TableName);
				}
			}

			code = NewLine + code.Replace("'", ((char)34).ToString());
			AddRegion(ref code, "PARAMETERS");

			if (checkBoxCreateOnlySelect.Checked)
			{
				code += NewLine + CodeForSelect();
			}
			else
			{
				code += NewLine + CodeForSave();
				code += NewLine + CodeForInsert();
				code += NewLine + CodeForUpdate();
				code += NewLine + CodeForDelete();
				code += NewLine + CodeForSelect();
				code += NewLine + CodeForGetSqlCommandObject();
				code += NewLine + CodeForIUDValuesForLog();
			}
			string dsUsing = string.Empty;
			if (checkBoxTypedDs.Checked)
			{
				code += NewDblLine + CodeForSelectAsTypedDataSet();
				string dsNs = textBoxInterfaceSubPath2.Text;
				dsUsing = NewLine + string.Format("using Types.DataSets.{0}; \r\n using DataService;", dsNs);
			}

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

			namespace {5}
			[[
				{6} partial class {7} {8} {9} {10}
				[[
					public static {7} Instance [[ get [[ return new {7}();]]]]
					{11}
				]]
				{12}
				{13}
			]]";

			code = string.Format(block,
								 GetCCGGeneratorComment(),
								 GetUsingStatementForDbProvider(),
								 usingDataService,
								 interfaceNameSpace,
								 dsUsing,
								 CCNameSpace,
								 ProtectionLevel,
								 CCClassName,
								 inheritanceSymbol,
								 inheritanceClassName,
								 interfaceName,
								 code,
								 prmCode,
								 infoCode
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

			pPrmCode = string.Format(@"
					[Serializable]
					public partial class {0}{5}
					[[
						{1}
					]]
					
					[Serializable]
					public partial class {0}DbComparisonOperators
					[[                        
						{2}
					]]

					[Serializable]
					public partial class {0}DbConjunctionOperators
					[[
						{3}
					]]

					[Serializable]
					public partial class {0}SetNull
					[[
						{4}
					]]
					", ClassName
					 , GeneratePrmCode()
					 , GenerateDbComparisonOperatorsClass()
					 , GenerateSqlConjuctionOperatorsClass()
					 , GenerateSetNullClass()
					 , inheritanceClassName
					 );

			AddRegion(ref pPrmCode, "PARAMETER CLASSES");

			string fieldName = string.Empty;
			string maxLength = string.Empty;
			GenerateInfoCode(ref fieldName, ref maxLength);
			pInfoCode = string.Format(@"
					[Serializable]
					public class {0}Info
					[[
						public struct FieldName
						[[
							{1}
						]]

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
				[OperationContract(Name = ^^{1}SelectAsTypedDataSet1^^)]
				[FaultContract(typeof(CCustomException))]
				{1}DataSet SelectAsTypedDataSet({0} pPrm);

				[OperationContract(Name = ^^{1}SelectAsTypedDataSet2^^)]
				[FaultContract(typeof(CCustomException))]
				{1}DataSet SelectAsTypedDataSet({0} pPrm, JoinTypes pJoinType);

				[OperationContract(Name = ^^{1}SelectAsTypedDataSet3^^)]
				[FaultContract(typeof(CCustomException))]
				{1}DataSet SelectAsTypedDataSet({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN);

				[OperationContract(Name = ^^{1}InsertOrUpdate1^^)]
				[FaultContract(typeof(CCustomException))]
				void InsertOrUpdate({1}DataSet pTypedDataSet);

				[OperationContract(Name = ^^{1}InsertOrUpdate2^^)]
				[FaultContract(typeof(CCustomException))]
				void InsertOrUpdate({1}DataSet pTypedDataSet, bool pIsTransactional);

				[OperationContract(Name = ^^{1}InsertOrUpdate3^^)]
				[FaultContract(typeof(CCustomException))]
				void InsertOrUpdate({1}DataSet pTypedDataSet, bool pIsTransactional, bool pWriteLog);

				[OperationContract(Name = ^^{1}InsertOrUpdate4^^)]
				[FaultContract(typeof(CCustomException))]
				void InsertOrUpdate({1}DataSet pTypedDataSet, bool pAcceptChangesDuringUpdate, bool pContinueUpdateOnError, bool pWriteLog);
				", ClassName, IClassName);

			return dsCode;
		}

		private string GetInterfaceIUDCodes()
		{
			string insertReturnType = "void"; if (HasIdentity) insertReturnType = IdentityColumnCsDataTypeName;

			string iud = string.Format(@"
				{2}
				[OperationContract(Name = ^^{3}Save1^^)]
				[FaultContract(typeof(CCustomException))]
				{1} Save({0} pPrm, {0} pPrmForWhereClause);
				
				{2}
				[OperationContract(Name = ^^{3}Save2^^)]
				[FaultContract(typeof(CCustomException))]
				void Save(List<{0}> pPrm, List<{0}> pPrmForWhereClause);

				[OperationContract(Name = ^^{3}Insert1^^)]
				[FaultContract(typeof(CCustomException))]
				{1} Insert({0} pPrm);

				[OperationContract(Name = ^^{3}Insert2^^)]
				[FaultContract(typeof(CCustomException))]
				void Insert(List<{0}> pPrms, bool pTransactional);

				[OperationContract(Name = ^^{3}Update1^^)]
				[FaultContract(typeof(CCustomException))]
				void Update({0} pPrm);

				[OperationContract(Name = ^^{3}Update2^^)]
				[FaultContract(typeof(CCustomException))]
				void Update(List<{0}> pPrms, bool pTransactional);

				[OperationContract(Name = ^^{3}Update3^^)]
				[FaultContract(typeof(CCustomException))]
				void Update({0} pPrm, {0} pPrmForWhere);

				/// <summary>
				/// This method is used to batch update.
				/// Since second parameters are used to find existancy of first parametes data, parameters orders must be the same
				/// </summary>
				/// <param name='pPrm'>For update data</param>
				/// <param name='pPrmForWhereClause'>For where clause to check existincy of data</param>
				[OperationContract(Name = ^^{3}Update4^^)]
				[FaultContract(typeof(CCustomException))]
				void Update(List<{0}> pPrms, List<{0}> pPrmForWhere, bool pTransactional);

				[OperationContract(Name = ^^{3}Delete1^^)]
				[FaultContract(typeof(CCustomException))]
				void Delete({0} pPrm);

				[OperationContract(Name = ^^{3}Delete2^^)]
				[FaultContract(typeof(CCustomException))]
				void Delete(List<{0}> pPrms, bool pTransactional);"
				, ClassName, insertReturnType, CommandSave, IClassName).Replace("'", ((char)34).ToString()) + NewLine;

			return iud;
		}

		private string GetInterfaceSelectCode()
		{
			string select = string.Format(@"
						[OperationContract(Name = ^^{1}Select1^^)]
						[FaultContract(typeof(CCustomException))]
						DataTable Select({0} pPrm);

						[OperationContract(Name = ^^{1}Select2^^)]
						[FaultContract(typeof(CCustomException))]
						DataTable Select({0} pPrm, JoinTypes pJoinType);

						[OperationContract(Name = ^^{1}Select3^^)]
						[FaultContract(typeof(CCustomException))]
						DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN);

						[OperationContract(Name = ^^{1}Select4^^)]
						[FaultContract(typeof(CCustomException))]
						DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex);

						[OperationContract(Name = ^^{1}AggregateFunction^^)]
						[FaultContract(typeof(CCustomException))]
						object SelectAggregateFunction({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName);

						[OperationContract()]
						[FaultContract(typeof(CCustomException))]
						{0} SelectAs{0}({0} pPrm);

						[OperationContract()]
						[FaultContract(typeof(CCustomException))]
						List<{0}> SelectAs{0}List({0} pPrm);
					", ClassName, IClassName);

			return select;
		}

		private string AdditionalPropertiesForPrmClass()
		{
			string s1 = string.Empty;

			if (!checkBoxCreateOnlySelect.Checked)
			{
				s1 = @"
						private string mUserID = string.Empty;
						private bool mWriteLog;
						private string mWhereClause = string.Empty;

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
						";
			}
			string s2 = @"
						private [[0]]DbConjunctionOperators mConjunctionOperator = new [[0]]DbConjunctionOperators();
						private [[0]]DbComparisonOperators mComparisonOperator = new [[0]]DbComparisonOperators();
						private [[0]]SetNull mSetNull = new [[0]]SetNull();

						public [[0]]DbConjunctionOperators ConjunctionOperator { get { return mConjunctionOperator; } set { mConjunctionOperator = value; } }
						public [[0]]DbComparisonOperators ComparisonOperator { get { return mComparisonOperator; } set { mComparisonOperator = value; } }
						public [[0]]SetNull SetNull { get { return mSetNull; } set { mSetNull = value; } }
						";

			string s = s1 + s2;
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

				CCGDataObject.Instance(Database).ExecuteNonQueryStatement(cmd);
				
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

			public SqlCommand GetSaveCommand({0} pPrm, {0} pPrmForWhereClause, bool pUpdateIfExist = true)
			[[
				return GetSaveCommand(pPrm, pPrmForWhereClause, 0, pUpdateIfExist);
			]]

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
			public {0} Insert({1} pPrm)
			[[
				SqlCommand cmd = GetInsertCommand(pPrm);
				if (pPrm.WriteLog) cmd.AddTransaction();

				{2}

				CCGDataObject.Instance(Database).ExecuteNonQueryStatement(cmd);
				
				{3}
			]]

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
			public void Update({0} pPrm)
			[[
				SqlCommand cmd = GetCommandObject(pPrm, CrudTypes.Update);
				if (pPrm.WriteLog) cmd.AddTransaction();
				CCGDataObject.Instance(Database).ExecuteNonQueryStatement(cmd);
			]]

			public void Update(List<{0}> pPrms, bool pTransactional)
			[[
				List<SqlCommand> cmds = GetCommandObject(pPrms, CrudTypes.Update);
				CCGBatchProcess.Instance(Database).Proceed(cmds.ConvertAll(t => [[ return (DbCommand)t; ]]), pTransactional);
			]]

			public void Update({0} pPrm, {0} pPrmForWhere)
			[[
				SqlCommand cmd = GetUpdateCommand(pPrm, pPrmForWhere);
				if (pPrm.WriteLog) cmd.AddTransaction();
				CCGDataObject.Instance(Database).ExecuteNonQueryStatement(cmd);
			]]
			/// <summary>
			/// This method is used to batch update.
			/// Since second parameters are used to find existancy of first parametes data, parameters orders must be the same
			/// </summary>
			/// <param name='pPrm'>For update data</param>
			/// <param name='pPrmForWhereClause'>For where clause to check existincy of data</param>
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
			public void Delete({0} pPrm)
			[[
				SqlCommand cmd = GetCommandObject(pPrm, CrudTypes.Delete);
				if (pPrm.WriteLog) cmd.AddTransaction();
				CCGDataObject.Instance(Database).ExecuteNonQueryStatement(cmd);
			]]

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
			string code = CodeForSelectAsDataTable();
			code += NewLine + CodeForSelectAggregateFunction();
			code += NewLine + CodeForSelectAsClass();
			code += NewLine + CodeForSelectAsClassList();
			code += NewLine + CodeForSelectCommand();
			code += NewLine + CodeForWhereClause();
			code += NewLine + CodeForAddParameters();
			code += NewLine + CodeForJoinString();
			AddRegion(ref code, "SELECT");
			code = code.Replace("'", ((char)34).ToString()).Replace("^", "'");
			return code;
		}

		private string CodeForSelectAsDataTable()
		{
			string code = string.Format(@"            
			public DataTable Select({0} pPrm)
			[[
				return Select(pPrm, JoinTypes.NotJoin, string.Empty, false, 0, 0, 0);
			]]

			public DataTable Select({0} pPrm, JoinTypes pJoinType)
			[[
				return Select(pPrm, pJoinType, string.Empty, false, 0, 0, 0);
			]]

			public DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN)
			[[
				return Select(pPrm, pJoinType, pSortExpression, pDesc, pTopN, 0, 0);
			]]

			public DataTable Select({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex)
			[[
				SqlCommand cmd = GetSelectCommand(pPrm, pJoinType, pSortExpression, pDesc, pTopN, pPageSize, pPageIndex);

				DataTable oDt = new DataTable();
				CCGDataObject.Instance(Database).GetRecords(oDt, cmd);
				return oDt;
			]]", ClassName);

			code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
			return code;
		}

		private string CodeForSelectAggregateFunction()
		{
			string code = string.Format(@"
			public object SelectAggregateFunction({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName)
			[[
				SqlCommand cmd = GetAggregateFunctionCommand(pPrm, pFunctionType, pColumnName);
				return CCGDataObject.Instance(Database).ExecuteScalarStatement(cmd);
			]]

			public SqlCommand GetAggregateFunctionCommand({0} pPrm, SqlAggregateFunctions pFunctionType, string pColumnName, JoinTypes pJoinType = JoinTypes.NotJoin)
			[[
				SqlCommand cmd = GetSelectCommand(pPrm, pJoinType, string.Empty, false, 0);
				string aggr = string.Format('[[0]]([[1]])', pFunctionType.ToString(), pColumnName);

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

			foreach (DataRow rw in DTColumnsInfo.Rows)
			{
				string clmName = rw[Fields.ColumnName].ToString();
				string dbType = rw[Fields.SysTypeName].ToString();
				string csType = GetCsType(dbType);
				bool nullable = rw[Fields.IsNullable].ToBool();
				if (csType != DtCs.csString && csType != DtCs.csByteArr && nullable) csType += "?";

				if (nullable)
					classPrm += string.Format("prm.{0} = rw['{0}'] is DBNull ? null : ({1})rw['{0}'];", clmName, csType) + NewLine;
				else
					classPrm += string.Format("prm.{0} = ({1})rw['{0}'];", clmName, csType) + NewLine;
			}

			string code = string.Format(@"
			public List<{0}> SelectAs{0}List({0} pPrm)
			[[
				DataTable oDt = Select(pPrm, JoinTypes.NotJoin, string.Empty, false, 0);
				return SelectAs{0}List(oDt);
			]]

			public List<{0}> SelectAs{0}List({0} pPrm, string pSortExpression, bool pDesc, int pTopN)
			[[
				DataTable oDt = Select(pPrm, JoinTypes.NotJoin, pSortExpression, pDesc, pTopN);
				return SelectAs{0}List(oDt);
			]]

			public List<{0}> SelectAs{0}List({0} pPrm, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex)
			[[
				DataTable oDt = Select(pPrm, JoinTypes.NotJoin, pSortExpression, pDesc, pTopN, pPageSize, pPageIndex);
				return SelectAs{0}List(oDt);
			]]                        

			public List<{0}> SelectAs{0}List(SqlCommand pCmd)
			[[
				DataTable oDt = new DataTable();
				CCGDataObject.Instance(Database).GetRecords(oDt, pCmd);
				return SelectAs{0}List(oDt);
			]]

			public List<{0}> SelectAs{0}List(DataTable pDt)
			[[
				{0} prm;
				List<{0}> prms = new List<{0}>();

				foreach (DataRow rw in pDt.Rows)
				[[
					prm = new {0}();
					{1}
					prms.Add(prm);
				]]
				return prms;
			]]", ClassName, classPrm);

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
							, pPrm.{0}2.HasValue ? 'MT.{0} BETWEEN @:{0} AND @:{0}2' : string.Format('MT.{0} [[0]] [[1]]'
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

				if (!string.IsNullOrEmpty(pPrm.WhereClause)) return pPrm.WhereClause;

				StringBuilder whereString = new StringBuilder();

				{1}
				string where = whereString.ToString().Trim();
				if (where.Length > 0)
				[[
					if (where.Substring(0, 3) == 'OR ') where = where.Substring(3);
					else if (where.Substring(0, 4) == 'AND ') where = where.Substring(4);
				]]
				else where = '1=1';

				return where;
			]]";

			code = string.Format(code, ClassName, where.ToString());
			code = code.Replace("[[", "{").Replace("]]", "}");
			return code;
		}

		private string CodeForSelectCommand()
		{
			string code = string.Format(@"
			public SqlCommand GetSelectCommand({0} pPrm, JoinTypes pJoinType)
			[[
				return GetSelectCommand(pPrm, pJoinType, string.Empty, false, 0, 0, 0);
			]]

			public SqlCommand GetSelectCommand({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN)
			[[
				return GetSelectCommand(pPrm, pJoinType, pSortExpression, pDesc, pTopN, 0, 0);
			]]

			public SqlCommand GetSelectCommand({0} pPrm, JoinTypes pJoinType, string pSortExpression, bool pDesc, int pTopN, int pPageSize, int pPageIndex)
			[[
				string topN = string.Empty;
                string sortExp = string.Empty;
                string order = string.Empty;

                if (pTopN > 0)
                    topN = string.Format('TOP [[0]]', pTopN);

                if (!string.IsNullOrWhiteSpace(pSortExpression))
                [[
                    sortExp = string.Format('ORDER BY [[0]]', pSortExpression);
                    order = pDesc ? order = 'DESC' : 'ASC';
                ]]

				string selectPart = string.Empty;
				string joinPart = string.Empty;
				GetJoinString(ref selectPart, ref joinPart, pJoinType);

				string whereString = WhereClause(pPrm);

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
			]]", ClassName, PrepareTopNForSelect(), PrepareSelectForSelect());

			code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
			return code;
		}

		private string CodeForJoinString()
		{
			string selectPartJoinWithLookupTables = string.Empty;
			string joinPartJoinWithLookupTables = string.Empty;

			string selectPartJoinWithDetailTables = string.Empty;
			string joinPartJoinWithDetailTables = string.Empty;

			string selectPartJoinAll = string.Empty;
			string joinPartJoinAll = string.Empty;

			GetJoinString(ref selectPartJoinWithLookupTables, ref joinPartJoinWithLookupTables, JoinTypes.JoinWithLookupTables);
			GetJoinString(ref selectPartJoinWithDetailTables, ref joinPartJoinWithDetailTables, JoinTypes.JoinWithDetailTables);
			GetJoinString(ref selectPartJoinAll, ref joinPartJoinAll, JoinTypes.JoinAll);

			string code = string.Format(@"
			private void GetJoinString(ref string pSelectPart, ref string pJoinPart, JoinTypes pJoinType)
			[[
				pSelectPart = '';
				pJoinPart = @'';
                JoinTypes joinWith;
                string joinMethod;
                Set_JoinWith_And_JoinMethod(pJoinType, out joinWith, out joinMethod);

				switch (joinWith)
				[[
					case JoinTypes.NotJoin:break;
					case JoinTypes.JoinWithLookupTables:
						pSelectPart = '{0}';
						pJoinPart= @'{1}';
						break;
					case JoinTypes.JoinWithDetailTables:
						pSelectPart = '{2}';
						pJoinPart= @'{3}';
						break;
					case JoinTypes.JoinAll:
						pSelectPart = '{4}';
						pJoinPart= @'{5}';
						break;
				]]

                pJoinPart = string.Format(pJoinPart, joinMethod);
			]]

            {6}
            "
                , selectPartJoinWithLookupTables
                , joinPartJoinWithLookupTables
                , selectPartJoinWithDetailTables
                , joinPartJoinWithDetailTables
                , selectPartJoinAll
                , joinPartJoinAll
                , CodeForSettingJoinStringParameters()
                );

			code = code.Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
			return code;
		}

        private string CodeForSettingJoinStringParameters()
        {
            string code = @"
            private void Set_JoinWith_And_JoinMethod(JoinTypes pJoinType, out JoinTypes joinWith, out string joinMethod)
            [[
                joinWith = JoinTypes.NotJoin;
                joinMethod = string.Empty;

                switch (pJoinType)
                [[
                    case JoinTypes.NotJoin:
                        break;
                    case JoinTypes.JoinWithLookupTables:
                        joinWith = JoinTypes.JoinWithLookupTables;
                        joinMethod = JoinMethods.INNER_JOIN;
                        break;
                    case JoinTypes.JoinWithDetailTables:
                        joinWith = JoinTypes.JoinWithDetailTables;
                        joinMethod = JoinMethods.INNER_JOIN;
                        break;
                    case JoinTypes.JoinAll:
                        joinWith = JoinTypes.JoinAll;
                        joinMethod = JoinMethods.INNER_JOIN;
                        break;

                    case JoinTypes.LeftJoinWithLookupTables:
                        joinWith = JoinTypes.JoinWithLookupTables;
                        joinMethod = JoinMethods.LEFT_OUTER_JOIN;
                        break;
                    case JoinTypes.LeftJoinWithDetailTables:
                        joinWith = JoinTypes.JoinWithDetailTables;
                        joinMethod = JoinMethods.LEFT_OUTER_JOIN;
                        break;
                    case JoinTypes.LeftJoinAll:
                        joinWith = JoinTypes.JoinAll;
                        joinMethod = JoinMethods.LEFT_OUTER_JOIN;
                        break;

                    case JoinTypes.RightJoinWithLookupTables:
                        joinWith = JoinTypes.JoinWithLookupTables;
                        joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
                        break;
                    case JoinTypes.RightJoinWithDetailTables:
                        joinWith = JoinTypes.JoinWithDetailTables;
                        joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
                        break;
                    case JoinTypes.RightJoinAll:
                        joinWith = JoinTypes.JoinAll;
                        joinMethod = JoinMethods.RIGHT_OUTER_JOIN;
                        break;

                    case JoinTypes.FullJoinWithLookupTables:
                        joinWith = JoinTypes.JoinWithLookupTables;
                        joinMethod = JoinMethods.FULL_OUTER_JOIN;
                        break;
                    case JoinTypes.FullJoinWithDetailTables:
                        joinWith = JoinTypes.JoinWithDetailTables;
                        joinMethod = JoinMethods.FULL_OUTER_JOIN;
                        break;
                    case JoinTypes.FullJoinAll:
                        joinWith = JoinTypes.JoinAll;
                        joinMethod = JoinMethods.FULL_OUTER_JOIN;
                        break;

                    default:
                        joinWith = JoinTypes.NotJoin;
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

			public List<SqlCommand> GetCommandObject(List<{0}> pPrm, CrudTypes pCrudType)
			[[
				List<SqlCommand> cmds = new List<SqlCommand>();

				GetCommandObject(pPrm, cmds, pCrudType);
				return cmds;
			]]

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
			string code = CodeForInsertValuesForLog() + NewLine +
						  CodeForUpdateValuesForLog() + NewLine +
						  CodeForDeleteValuesForLog();
			AddRegion(ref code, "PRIVATE METHODS");
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
			/// <summary>
			/// Used to concatenate each non-null parameter with its value, and get them as comma separated value.
			/// e.g.: Prm1 = Vaslue1, Prm2 = Value2, ...
			/// </summary>
			public string GetParametersAndValuesAsCsv({0} pPrm)
			[[
				return InsertValuesForLog(pPrm);
			]]

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
			values = values.TrimStart('+').Replace("^","'");
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
				if (pPageSize > 0)
				[[
					sql = string.Format(@'
						;WITH CCGPagingCTE AS (
	
							SELECT [[0]] ROW_NUMBER() OVER(ORDER BY [[1]] [[2]]) AS RwID, MT.*
							FROM [[3]] AS MT WITH(NOLOCK)
							WHERE [[4]] 
							[[5]] [[2]]
						)
						SELECT *
						FROM CCGPagingCTE AS MT
							[[6]]
						WHERE RwID BETWEEN ((@pPageIndex * @pPageSize) + 1) and ((@pPageIndex * @pPageSize) + @pPageSize)
						', topN, pSortExpression, order, TableName, whereString, sortExp, joinPart);
				]]
				else
				[[
					sql = string.Format(@'
						SELECT [[0]] MT.* [[1]] 
						FROM [[2]] AS MT WITH(NOLOCK) 
							 [[3]] 
						WHERE [[4]]
						[[5]] [[6]]
						', topN, selectPart, TableName, joinPart, whereString, sortExp, order);
				]]
				";  
				//select = "string sql = string.Format(@'SELECT [[0]] MT.* [[1]] FROM [[2]] AS MT {0}[[3]] WHERE [[4]] [[5]] [[6]]', topN, selectPart, TableName, joinPart, whereString, sortExp, order);";
			}
			else if (DatabaseType == DatabaseTypes.ORACLE)
			{
				select = @"
				if (pPageSize > 0)
				[[
					sql = string.Format(@'
						WITH CCGPagingCTE AS (
	
							SELECT ROW_NUMBER() OVER(ORDER BY [[0]] [[1]]) AS RwID, MT.*
							FROM [[2]] AS MT WITH(NOLOCK)
							WHERE [[3]] [[4]]
							[[5]] [[2]]
						)
						SELECT *
						FROM CCGPagingCTE AS MT
							[[6]]
						WHERE RwID BETWEEN ((@pPageIndex * @pPageSize) + 1) and ((@pPageIndex * @pPageSize) + @pPageSize)
						', pSortExpression, order, TableName, whereString, topN, sortExp, joinPart);
				]]
				else
				[[
					sql = string.Format(@'
						SELECT MT.* [[0]] 
						FROM [[1]] AS MT WITH(NOLOCK) 
							 [[2]] 
						WHERE [[3]] [[4]]
						[[5]] [[6]]
						', selectPart, TableName, joinPart, whereString, topN, sortExp, order);
				]]
				";  
				//select = "string sql = string.Format(@'SELECT MT.* [[0]] FROM [[1]] AS MT {0}[[2]] WHERE [[3]] [[4]] [[5]] [[6]]', selectPart, TableName, joinPart, whereString, topN, sortExp, order);";
			}

			select = string.Format(select, noLock);
			return select;
		}

		private string PrepareTopNForSelect()
		{
			string topN = string.Empty;

			if (DatabaseType == DatabaseTypes.MS_SQL)
			{
				topN = "topN = string.Format('TOP [[0]]', pTopN)";
			}
			else if (DatabaseType == DatabaseTypes.ORACLE)
			{
				topN = "topN = string.Format(' AND ROWNUM <= [[0]]', pTopN)";
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
				pCode = pCode.Replace("@:", ":").Replace("+","||");
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

		private void GetJoinString(ref string pSelectPart, ref string pJoinPart, JoinTypes pJoinTypes)
		{
			DataTable oDt = Dac.GetJoinString(ref pSelectPart, ref pJoinPart, pJoinTypes, SchemaName, TableName, LookupTablePrefix);

			if (oDt.Rows.Count > 0)
			{
				foreach (DataRow rw in oDt.Rows)
				{
					pSelectPart += "," + rw["SelectPart"];
                    pJoinPart += rw["JoinPart"].ToString().Replace("[[", "{").Replace("]]", "}") + NewLine + new string(((char)9), 6);
				}
			}
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
