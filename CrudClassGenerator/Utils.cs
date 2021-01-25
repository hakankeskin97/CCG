using System;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CrudClassGenerator
{
    public static class Utils
    {
        /// <summary>
        /// Used for replacing by word. 
        /// e.g.: "someone can say me".Replace("me", "123"); = so123one can say 123
        ///       "someone can say me".ReplaceWholeWord("me", "123"); = someone can say 123
        /// </summary>
        /// <param name="pInput"></param>
        /// <param name="pOldValue"></param>
        /// <param name="pNewValue"></param>
        /// <returns></returns>
        public static string ReplaceWholeWord(this string pInput, string pOldValue, string pNewValue)
        {
            string oldValue = string.Format(@"\b{0}\b", pOldValue);
            if (!Regex.IsMatch(pInput, oldValue))
                oldValue = string.Format(@"{0}\b", pOldValue);

            string s = Regex.Replace(pInput, oldValue, pNewValue);
            return s;
        }

        /// <summary>
        /// New type of "string.Substring" method and used to prevent exception
        /// when "length" value is longer then remain part of text length.
        /// e.g.: value = "something", startIndex = 3 and length = 8
        /// In this case, if standat string.Substring method is used, an exception will be occure.
        /// But, if this method is used, "ething" will be returned.
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pStartIndex"></param>
        /// <param name="pLength"></param>
        /// <returns></returns>
        public static string SubstringExt(this string pValue, int pStartIndex, int pLength)
        {
            if (pValue.Substring(pStartIndex).Length > pLength)
            {
                return pValue.Substring(pStartIndex, pLength);
            }
            else if (pStartIndex == 0)
            {
                return pValue;
            }
            else
            {
                return pValue.Substring(pStartIndex);
            }
        }

        public static void SetTextBoxLeaveMod(this TextBox pTxtBox, string pText, bool pForce = false)
        {
            if (pTxtBox.Text.SubstringExt(0, 1) != "-" || pForce)
            {
                pTxtBox.Text = pText;
                pTxtBox.ForeColor = Color.Gray;
            }
        }

        public static void SetTextBoxEnterMod(this TextBox pTxtBox)
        {
            if (pTxtBox.Text.SubstringExt(0, 1) == "-")
            {
                pTxtBox.Text = string.Empty;
                pTxtBox.ForeColor = Color.Black;
            }
        }

        public static void ShowInfoMessageOnTextBox(this TextBox pTxtBox, string pMessage)
        {
            pTxtBox.Text = pMessage;
            pTxtBox.ForeColor = Color.Gray;
        }

        public static bool IsEmpty(this TextBox pTxtBox)
        {
            return (pTxtBox.Text == string.Empty || pTxtBox.Text.SubstringExt(0, 1) == "-");
        }

        public static bool IsEmpty(this string pText)
        {
            return (pText == string.Empty || pText.SubstringExt(0, 1) == "-");
        }

        public static bool ToBool(this object pValue)
        {
            if (pValue == null) return false;
            if (pValue.ToString().ToLower() == "true") return true;
            if (pValue.ToString().ToLower() == "false") return false;
            if (!pValue.IsInteger()) return false;
            return Convert.ToBoolean(Convert.ToInt32(pValue));
        }

        public static int ToInt(this string pValue)
        {
            return Convert.ToInt32(pValue);
        }

        public static bool IsInteger(this object pValue)
        {
            if (pValue == null || pValue is DateTime) return false;
            if (pValue is Int16 || pValue is Int32 || pValue is Int64) return true;

            try
            {
                if (pValue is string)
                    Int64.Parse(pValue as string);
                else
                    Int64.Parse(pValue.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool ExistSelectedItem(this ListBox pListBox)
        {
            return pListBox.SelectedItems.Count > 0;
        }

        public static DataTable FilterDataTable(this DataTable pDt, string pFilterExpression, string pSortExpression = "", int pTopN = 0)
        {
            lock (pDt)
            {
                DataView dv = new DataView(pDt, pFilterExpression, pSortExpression, DataViewRowState.CurrentRows);
                DataTable oDt = dv.ToTable();

                if (pTopN > 0)
                {
                    if (oDt.Rows.Count > pTopN)
                        return oDt.GetTopN(pTopN);
                    else
                        return oDt;
                }

                return oDt;
            }
        }

        private static DataTable GetTopN(this DataTable pOdt, int pTopN)
        {
            if (pOdt.Rows.Count < 1 || pTopN == 0 || pTopN >= pOdt.Rows.Count) return pOdt;

            DataTable yeniDt = pOdt.Clone();
            for (int i = 0; i < pTopN; i++)
            {
                yeniDt.ImportRow(pOdt.Rows[i]);
            }

            return yeniDt;
        }

        public static T ToEnum<T>(this string pEnumName)
        {
            if (Enum.IsDefined(typeof(T), pEnumName))
                return (T)Enum.Parse(typeof(T), pEnumName);
            else
                return default(T);
        }

        public static string RemoveLastCharacter(this string pValue, string pChr)
        {
            if (pValue.SubstringExt(pValue.Length - 1, 1) == pChr)
                return pValue.SubstringExt(0, pValue.Length - 1);
            else
                return pValue;
        }

        public static string GetPartOfStringArray(this string pValue,char pDelimeter,int pPartIndex)
        {
            string[] part = pValue.Split(pDelimeter);
            if (pPartIndex + 1 > part.Length) return string.Empty;
            return part[pPartIndex];
        }

        public static string ToNamespace(this string pValue)
        {
            if (string.IsNullOrEmpty(pValue)) return string.Empty;
            return pValue.Trim('\\').Replace("\\", ".");
        }

        public static string SetAsSubPath1(this string pValue)
        {
            if (string.IsNullOrEmpty(pValue)) return string.Empty;
            return string.Format("\\{0}\\", pValue.Trim('\\')); 
        }

        public static string SetAsSubPath2(this string pValue)
        {
            if (string.IsNullOrEmpty(pValue)) return string.Empty;
            return pValue.Trim('\\');
        }
    }
}
