
namespace CrudClassGenerator
{
    public struct Fields
    {
        public const string SysTypeName = "SysTypeName";
        public const string IsComputed = "IsComputed";
        public const string ColumnName = "ColumnName";
        public const string IsNullable = "IsNullable";
        public const string IsIdentity = "ISIDENTITY";
        public const string MaxLength = "MaxLength";

        public const string dbObject = "object";
        public const string dbChar = "char";
    }

    public enum WorkingModes
    {
        ClassLibrary,
        WCF
    }
}
