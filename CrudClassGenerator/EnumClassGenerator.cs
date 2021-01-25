
using System;
using System.Data;
using System.Windows.Forms;

namespace CrudClassGenerator
{
    partial class FormMain
    {
        private void checkBoxUseDbScript_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDbScript.Visible = checkBoxUseDbScript.Checked;
        }

        private void linkLabelLoadColumns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoadTableColumns();
        }

        private void buttonGenerateEnumClass_Click(object sender, EventArgs e)
        {
            GenerateEnum();
        }

        private void LoadTableColumns()
        {
            if (tabControlGeneration.SelectedTab != tabPageECG) return;

            DataTable oDt1 = Dac.GetTableColumns(SchemaName, TableName);

            DataTable oDt2 = new DataTable();
            DataTable oDt3 = new DataTable();

            oDt2 = oDt1.Copy();
            oDt3 = oDt1.Copy();

            if (oDt1.Rows.Count > 1)
            {
                comboBoxValueField.DataSource = oDt1;
                comboBoxValueField.DisplayMember = "ColumnName";
                comboBoxValueField.ValueMember = "ColumnId";
                comboBoxValueField.SelectedIndex = 0;

                comboBoxTextField.DataSource = oDt2;
                comboBoxTextField.DisplayMember = "ColumnName";
                comboBoxTextField.ValueMember = "ColumnId";
                comboBoxTextField.SelectedIndex = 1;

                comboBoxDescription.DataSource = oDt3;
                comboBoxDescription.DisplayMember = "ColumnName";
                comboBoxDescription.ValueMember = "ColumnId";
                int selIdx = 1;
                if (oDt3.Rows.Count > 2) selIdx = 2;
                comboBoxDescription.SelectedIndex = selIdx;
            }
            else
                MessageBox.Show(Message.TableIsEmpty, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void GenerateEnum()
        {
            if (!CheckNecessaryFieldsIsFilled()) return;
            if (!ValidateInputsForECG()) return;

            string enumNameField = comboBoxTextField.Text;
            string enumValueField = comboBoxValueField.Text;
            string enumDescriptionField = comboBoxDescription.Text;

            string code = GenerateCode(EnumNameSpace, EnumClassName, enumNameField, enumValueField, enumDescriptionField);
            if (code == string.Empty) return;

            bool written = WriteFile(code, EnumPath, EnumFullPath);

            if (!checkBoxSelectMultyTables.Checked && written) Message.MsgCreationSucceeded(EnumClassName);
        }

        private bool ValidateInputsForECG()
        {
            string errMsg = string.Empty;

            if (checkBoxSelectMultyTables.Checked)
            {
                MessageBox.Show(Message.MultyTableSelectionForbidden, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (comboBoxTextField.Text == string.Empty || comboBoxValueField.Text == string.Empty)
            {
                MessageBox.Show(Message.NoEnumNamaOrValue, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (checkBoxEnumWithDescription.Checked && comboBoxDescription.Text == string.Empty)
            {
                MessageBox.Show(Message.NoEnumDescription, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return true;
        }

        private string GenerateCode(string pNameSpace, string pClassName, string pEnumNameField, string pEnumValueField, string pEnumDescriptionField)
        {
            string sql = string.Format(@"SELECT * FROM {0}", TableFullName);
            if (checkBoxUseDbScript.Checked) sql = textBoxDbScript.Text;

            DataTable oDt = Dac.GetRecords(sql);

            if (oDt.Rows.Count < 1)
            {
                MessageBox.Show(Message.NoRecordsInTable, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }

            string enumList = string.Empty;
            string propertyList = string.Empty;
            string clmnTypeName = GetColumnTypeName(pEnumValueField);
            if (clmnTypeName == string.Empty)
            {
                MessageBox.Show(Message.NoColumnTypeName, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }

            string type = DataTypes.GetCSharpDataType(DatabaseType, clmnTypeName);

            if (!checkBoxCreateOnlyConstants.Checked)
            {
                foreach (DataRow row in oDt.Rows)
                {
                    string itemName = CreateEnumName(row[pEnumNameField].ToString());
                    string itemvalue = row[pEnumValueField].ToString();
                    string itemDesc = row[pEnumDescriptionField].ToString();

                    if (clmnTypeName.IndexOf("int") == -1)
                    {
                        MessageBox.Show(Message.ColumnTypeShouldBeNumeric, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return string.Empty;
                    }
                    if (checkBoxEnumWithDescription.Checked)
                        enumList = string.Join("", enumList, string.Format("[Description('{0}')] \r\n ||{1} = {2} , \r\n", itemDesc, itemName, itemvalue), (char)9, (char)9);
                    else
                        enumList = string.Join("", enumList, string.Format("{0} = {1} , \r\n", itemName, itemvalue), (char)9, (char)9);

                    propertyList = string.Join("", propertyList, string.Format("public const {0} {1} = {2};", type, itemName, itemvalue), "\r\n", (char)9, (char)9);
                }

                enumList = enumList.Substring(0, enumList.Length - 5);  //5: next comma + \r + \n + double (char)9  (,rntt)
                propertyList = string.Join("", "||", propertyList);
            }
            else
            {
                foreach (DataRow row in oDt.Rows)
                {
                    string name = CreateEnumName(row[pEnumNameField].ToString());
                    string value = row[pEnumValueField].ToString();

                    if (type == "string")
                        value = string.Join("", (char)34, value, (char)34);

                    enumList = string.Join("", enumList, "public const ", type, " ", name, " = ", value, ";", "\r\n", (char)9, (char)9);
                }
            }

            return PrepareCodeByTemplate(pNameSpace, pClassName, pEnumNameField, propertyList, enumList);
        }

        private string PrepareCodeByTemplate(string pNameSpace, string pClassName, string pEnumName, string pPropertyList, string pEnumList)
        {
            string enumName = string.Join("", textBoxEnumPrefix.Text, pEnumName, textBoxEnumSuffix.Text);
            string contStructName = string.Format("Const{0}", pClassName.Replace(".cs", ""));

            string usings = @"
                using System.ComponentModel;
                ".Replace("  ", "");

            string code = string.Empty;

            if (!checkBoxCreateOnlyConstants.Checked)
            {
                code = string.Format(@"{6}
                {5}

                namespace {0}
                [[
                    |public enum {1}
                    |[[
                        ||{4}
                    |]]
                    
                    |public struct {2}
                    |[[
                        {3}
                    |]]
                ]]
                ", pNameSpace, enumName, contStructName, pPropertyList, pEnumList, usings, GetECGGeneratorComment());
            }
            else
            {
                code = string.Format(@"{4}
                {3}

                namespace {0}
                [[
                    |public struct {1}
                    |[[
                        ||{2}
                    |]]
                ]]
                ", pNameSpace, contStructName, pEnumList, usings, GetECGGeneratorComment());
            }

            code = code.Replace("  ", "").Replace("|", "\t").Replace("[[", "{").Replace("]]", "}").Replace("'", ((char)34).ToString());
            return code;
        }

        private string CreateEnumName(string s)
        {
            if (checkBoxUseEnumNameWithoutChange.Checked) return s;

            s = s.Replace("(", "").Replace(")", "").Replace("/", "").Replace("-", " ").Replace("  ", "");
            s = s.Replace("Ç", "C").Replace("Ğ", "G").Replace("İ", "I").Replace("Ö", "O").Replace("Ş", "S").Replace("Ü", "U");
            s = s.ToLower(System.Globalization.CultureInfo.CurrentCulture);
            s = s.Replace("ç", "c").Replace("ğ", "g").Replace("ı", "i").Replace("ö", "o").Replace("ş", "s").Replace("ü", "u");
            s = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s);
            s = s.Replace("İ", "I");
            s = s.Trim();
            if (checkBoxAddUnderscoreBetweenWords.Checked)
                s = s.Replace(" ", "_");
            else
                s = s.Replace(" ", "");

            s = s.Replace(".", string.Empty);
            return s;
        }

        private string GetECGGeneratorComment()
        {
            string version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string comment = @"
                /* [GENERATOR COMMENT] {0}
                    
                 * This code was generated by 'ECG (Enum Class Generator)' Copyright © 2010
                 * Generation Time: {1} 
                 * Runtime Version: {2}
                 * 
                 * Settings:
                 *      ||Use Enum Name Without Any Change = {3}
                 *      ||Separate EnumName To Word Parts = {4}
                 *      ||Create Enum With Description = {5}
                 *      ||Create Fields As Constant Variables Only = {6}
                 *      ||Enum Prefix = {7}
                 *      ||Enum Suffix = {8}
                 *      ||{9}
                 * Table: {10}
                 *
                 * WARNING: Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
                */
            ";

            int rhl = 106;    //maximum region header length
            string regionHeaderChar = new string('~', rhl - 17);

            string sqlScript = string.Empty;

            if (checkBoxUseDbScript.Checked)
                sqlScript = string.Format("Use SQL Script = {0} -- Sql = {1} \r\n",
                    checkBoxUseDbScript.Checked.ToString(),
                    textBoxDbScript.Text.Replace("\r\n", " "));

            string enumPrefix = textBoxEnumPrefix.Text != string.Empty ? textBoxEnumPrefix.Text : "''";
            string enumSuffix = textBoxEnumSuffix.Text != string.Empty ? textBoxEnumSuffix.Text : "''";

            comment = string.Format(comment
                    , regionHeaderChar
                    , DateTime.Now
                    , version
                    , checkBoxUseEnumNameWithoutChange.Checked.ToString()
                    , checkBoxAddUnderscoreBetweenWords.Checked.ToString()
                    , checkBoxEnumWithDescription.Checked.ToString()
                    , checkBoxCreateOnlyConstants.Checked.ToString()
                    , enumPrefix
                    , enumSuffix
                    , sqlScript
                    , TableFullName
                    );

            comment = comment.Replace("  ", "").Replace("|", "\t").Replace("'", ((char)34).ToString());

            return comment;
        }
    }
}
