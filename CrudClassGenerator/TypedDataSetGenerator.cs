using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CrudClassGenerator
{
    partial class FormMain
    {
        private void buttonGenerateTypeDataSet_Click(object sender, EventArgs e)
        {
            if (!ValidateInputsForTDG()) return;

            if (!checkBoxSelectMultyTables.Checked)
                GenerateDatSetForOnlyOneTable();
            else
                GenerateDatSetForMoreThenOneTable();
        }

        private bool ValidateInputsForTDG()
        {
            string errMsg = string.Empty;


            if (textBoxProjectPath.Text == string.Empty) errMsg = Message.MandatoryProjectPath;
            if (textBoxSchema.Text == string.Empty)
            {
                errMsg = Message.MandatorySchemaAndTable;
            }

            if (!checkBoxSelectMultyTables.Checked)
            {
                if (textBoxTypeSubPath2.Text == string.Empty) errMsg = Message.MandatoryTypeNamespace;

                if (textBoxTable.Text == string.Empty)
                {
                    errMsg = Message.MandatorySchemaAndTable;
                }
            }
            else
            {
                if (!listBoxTables.ExistSelectedItem())
                {
                    errMsg = Message.NoTableSelected;
                }
            }

            if (errMsg != string.Empty)
            {
                MessageBox.Show(errMsg, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void GenerateDatSetForOnlyOneTable()
        {
            if (IsFileExist(DSFullPath, DSClassName)) return;
            if (!SetIdentityColumnName()) return;
            string sql = string.Join("", "SELECT * FROM ", TableFullName);
            
            bool written = Generate(sql);

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(DSClassName);
        }

        private void GenerateDatSetForMoreThenOneTable()
        {
            if (!GetApprovalForMultyGeneration()) return;

            string sql = string.Empty;

            SetProgressBar(listBoxTables.SelectedItems.Count);
            SetNameSpaces();

            foreach (DataRowView item in listBoxTables.SelectedItems)
            {
                RunProgressBar();

                TableName = item.Row["TableName"].ToString();
                if (SetIdentityColumnName())
                {
                    sql = string.Join("", "SELECT * FROM ", TableFullName);

                    if (!Generate(sql))
                    {
                        CloseProgressBar();
                        return;
                    }
                }
            }

            CloseProgressBar();
            MessageBox.Show(Message.ProcessOk, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool GetApprovalForMultyGeneration()
        {
            DialogResult result = MessageBox.Show(Message.TDSGenerationApprovalMsg, this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.No ? false : true;
        }

        private bool SetIdentityColumnName()
        {
            GetColumns();
            PrimaryKeyColumnName();
            if (TableValidation()) return true; else return false;
        }

        private bool Generate(string pCommandText)
        {
            DataSet ds = new DataSet();

            Dac.GetDataAdapter(pCommandText).FillSchema(ds, SchemaType.Mapped, TableName);

            string generatedCode = GenerateDataSet(ds, DSNameSpace, TableName, SchemaName, DataBaseName);
            string code = string.Join("", GetTDSGeneratorComment(), generatedCode);
            return WriteFile(code, DSPath, DSFullPath);
        }

        #region [TYPEDDATASET GENERATION] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private string GenerateDataSet(DataSet pDs, string pNamespace, string pTableName, string pSchemaName, string pDatabaseName)
        {
            Microsoft.CSharp.CSharpCodeProvider cp = new Microsoft.CSharp.CSharpCodeProvider();
            CodeNamespace cns = new CodeNamespace(pNamespace);

            //get autoincrement column if available
            string sAutoIncColName = IdentityColumnName;

            //set autoincrement seed and step to -1
            if (!String.IsNullOrEmpty(sAutoIncColName) && checkBoxPkIsIdentity.Checked)
            {
                pDs.Tables[0].Columns[sAutoIncColName].AutoIncrement = true;
                pDs.Tables[0].Columns[sAutoIncColName].AutoIncrementStep = -1;
                pDs.Tables[0].Columns[sAutoIncColName].AutoIncrementSeed = -1;
            }

            using (StringWriter schemaWr = new StringWriter())
            {
                pDs.WriteXmlSchema(schemaWr);
                System.Data.Design.TypedDataSetGenerator.Generate(schemaWr.ToString(), new CodeCompileUnit(), cns, cp, System.Data.Design.TypedDataSetGenerator.GenerateOption.LinqOverTypedDatasets);
            }

            string name = cns.Types[0].Name;

            //Change DataSet type name
            name = pDs.Tables[0].TableName + textBoxDataSetSuffix.Text;
            cns.Types[0].Name = name;

            CodeMemberMethod oClone = (CodeMemberMethod)FindMember("Clone", cns.Types[0].Members);
            CodeCastExpression exp =
              new CodeCastExpression(name,
               new CodeMethodInvokeExpression(
                new CodeMethodReferenceExpression(
                 new CodeBaseReferenceExpression(), "Clone"),
                  new CodePrimitiveExpression[] { }));

            CodeVariableDeclarationStatement cvds = new CodeVariableDeclarationStatement(name, "cln", exp);
            oClone.Statements[0] = cvds;

            foreach (CodeAttributeDeclaration cad in cns.Types[0].CustomAttributes)
                if (cad.Name == "System.ComponentModel.ToolboxItem")
                {
                    ((CodePrimitiveExpression)cad.Arguments[0].Value).Value = false;
                    break;
                }

            // Find DataTable. 
            // Add Attributes. 

            CodeTypeDeclaration oDataTable = (CodeTypeDeclaration)FindMember(pTableName + "DataTable", cns.Types[0].Members);

            AddTableSchemaMember(oDataTable, pSchemaName);
            AddDatabaseMember(oDataTable, pDatabaseName);
            AddFullTableNameMember(oDataTable, TableFullName);
            AddFullTableNameAttribute(oDataTable, TableFullName);

            // Add HasAutoIcrementColumn and AutoIncrementColumnName properties...
            AddAutoIncrementColNameMember(oDataTable, sAutoIncColName);
            if (sAutoIncColName == string.Empty)
                AddHasAutoIncrementMember(oDataTable, false);
            else
                AddHasAutoIncrementMember(oDataTable, true);

            AddAutoIncrementColumnNameAttribute(oDataTable, sAutoIncColName);

            //Change dataset name in Initvars method.
            CodeMemberMethod oInitClass = (CodeMemberMethod)FindMember("InitClass", cns.Types[0].Members);

            ((CodeAssignStatement)oInitClass.Statements[0]).Right = new CodePrimitiveExpression(name);

            //Change dataset type in GetTypedDataSetSchema method.
            CodeMemberMethod oGetTypedDataSetSchema = (CodeMemberMethod)FindMember("GetTypedDataSetSchema", cns.Types[0].Members);
            CodeObjectCreateExpression exp2 = new CodeObjectCreateExpression(name, new CodePrimitiveExpression[] { });
            CodeVariableDeclarationStatement cvds2 = new CodeVariableDeclarationStatement(name, "ds", exp2);
            oGetTypedDataSetSchema.Statements[0] = cvds2;

            //Change type in GetTypedTableSchema of table.
            oGetTypedDataSetSchema = (CodeMemberMethod)FindMember("GetTypedTableSchema", ((CodeTypeDeclaration)FindMember(pDs.Tables[0].TableName + "DataTable", cns.Types[0].Members)).Members);
            exp2 = new CodeObjectCreateExpression(name, new CodePrimitiveExpression[] { });
            cvds2 = new CodeVariableDeclarationStatement(name, "ds", exp2);
            oGetTypedDataSetSchema.Statements[2] = cvds2;

            StringBuilder sb = new StringBuilder();
            TextWriter tw = new StringWriter(sb);
            CodeGeneratorOptions cgo = new CodeGeneratorOptions();
            cp.GenerateCodeFromNamespace(cns, tw, cgo);
            return sb.ToString();
        }

        private CodeTypeMember FindMember(string pMemberName, IList pSrc)
        {
            foreach (CodeTypeMember cdtyp in pSrc)
            {
                if (cdtyp.Name == pMemberName)
                    return cdtyp;
            }
            return null;
        }

        private void AddTableSchemaMember(CodeTypeDeclaration cd, string pSchemaName)
        {
            CodeMemberField tableSchemaName = new CodeMemberField("System.String", "TableSchemaName");
            tableSchemaName.InitExpression = new CodePrimitiveExpression(pSchemaName);
            tableSchemaName.Attributes = MemberAttributes.Const | MemberAttributes.Public;
            tableSchemaName.Comments.Add(AddComment());
            cd.Members.Add(tableSchemaName);
        }

        private void AddDatabaseMember(CodeTypeDeclaration cd, string pDatabaseName)
        {
            CodeMemberField databaseName = new CodeMemberField("System.String", "DbName");
            databaseName.InitExpression = new CodePrimitiveExpression(pDatabaseName);
            databaseName.Attributes = MemberAttributes.Const | MemberAttributes.Public;
            databaseName.Comments.Add(AddComment());
            cd.Members.Add(databaseName);
        }

        private void AddFullTableNameMember(CodeTypeDeclaration cd, string pFullTableName)
        {
            CodeMemberField tableFullName = new CodeMemberField("System.String", "TableFullName");
            tableFullName.InitExpression = new CodePrimitiveExpression(pFullTableName);
            tableFullName.Attributes = MemberAttributes.Const | MemberAttributes.Public;
            tableFullName.Comments.Add(AddComment());
            cd.Members.Add(tableFullName);
        }

        private void AddFullTableNameAttribute(CodeTypeDeclaration cd, string pFullTableName)
        {
            CodeAttributeArgument[] arguments = new CodeAttributeArgument[] { new CodeAttributeArgument(new CodePrimitiveExpression(pFullTableName)) };
            CodeAttributeDeclaration codeAttrDecl = new CodeAttributeDeclaration(textBoxAttributesNamespace.Text + ".FullTableName", arguments);
            cd.CustomAttributes.Add(codeAttrDecl);
        }

        private CodeCommentStatement AddComment()
        {
            CodeComment comm = new CodeComment("This custom member was added by TypedDataSetGenerator tool.", false);
            CodeCommentStatement cst = new CodeCommentStatement(comm);
            return cst;
        }

        private void AddAutoIncrementColNameMember(CodeTypeDeclaration cd, string pColName)
        {
            CodeMemberField autoIncColName = new CodeMemberField("System.String", "AutoIncrementColumnName");
            autoIncColName.InitExpression = new CodePrimitiveExpression(pColName);
            autoIncColName.Attributes = MemberAttributes.Const | MemberAttributes.Public;
            autoIncColName.Comments.Add(AddComment());
            cd.Members.Add(autoIncColName);
        }

        private void AddHasAutoIncrementMember(CodeTypeDeclaration cd, bool pHasCol)
        {
            CodeMemberField hasAutoIncCol = new CodeMemberField("System.Boolean", "HasAutoIncrementColumn");
            hasAutoIncCol.InitExpression = new CodePrimitiveExpression(pHasCol);
            hasAutoIncCol.Attributes = MemberAttributes.Const | MemberAttributes.Public;
            hasAutoIncCol.Comments.Add(AddComment());
            cd.Members.Add(hasAutoIncCol);
        }

        private void AddAutoIncrementColumnNameAttribute(CodeTypeDeclaration cd, string pColumnName)
        {
            CodeAttributeArgument[] arguments = new CodeAttributeArgument[] { new CodeAttributeArgument(new CodePrimitiveExpression(pColumnName)) };
            CodeAttributeDeclaration codeAttrDecl = new CodeAttributeDeclaration(textBoxAttributesNamespace.Text + ".AutoIncColName", arguments);
            cd.CustomAttributes.Add(codeAttrDecl);
        }

        private string GetTDSGeneratorComment()
        {
            string version = GetVersion();

            string comment = @"
               /* [GENERATOR COMMENT] {0}
                *
                * This code was generated by 'TDG (Typed DataSet Generator)' Copyright © 2010
                *
                * Generation Time: {1} 
                * Runtime Version: {2}
                * 
                * Settings:
                *      ||DataSet Suffix = {3}
                *      ||Attributes Namespace = {4}

                * WARNING: Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
               */


            ";

            int rhl = 106;    //maximum region header length
            string regionHeaderChar = new string('~', rhl - 17);

            comment = string.Format(comment,
                regionHeaderChar,
                DateTime.Now,
                version,
                textBoxDataSetSuffix.Text,
                textBoxAttributesNamespace.Text);

            comment = comment.Replace("  ", "").Replace("|", "\t").Replace("'", ((char)34).ToString());

            return comment;
        }

        #endregion

    }
}
