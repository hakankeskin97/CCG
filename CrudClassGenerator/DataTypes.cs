
using System.Data;
namespace CrudClassGenerator
{
    public class DataTypes
    {
        public struct SqlDataTypes
        {
            public const string dbChar = "char";
            public const string dbNChar = "nchar";
            public const string dbVarChar = "varchar";
            public const string dbNVarChar = "nvarchar";
            public const string dbTimestamp = "timestamp";

            public const string dbBinary = "binary";
            public const string dbVarbinary = "varbinary";
            public const string dbUniqueidentifier = "uniqueidentifier";
            public const string dbXml = "xml";

            public const string dbBit = "bit";
            public const string dbTinyint = "tinyint";
            public const string dbSmallint = "smallint";
            public const string dbInt = "int";
            public const string dbBigint = "bigint";
            public const string dbReal = "real";
            public const string dbFloat = "float";
            public const string dbMoney = "money";
            public const string dbDecimal = "decimal";
            public const string dbNumeric = "numeric";

            public const string dbDate = "date";
            public const string dbDateTime = "datetime";
            public const string dbDateTime2 = "datetime2";
            public const string dbSmallDateTime = "smalldatetime";
            public const string dbTime = "time";

            //Default Type
            public const string dbObject = "object";
        }

        public struct OracleDataTypes
        {
            public const string dbChar = "CHAR";
            public const string dbNChar = "NCHAR";
            public const string dbVarChar = "VARCHAR";
            public const string dbNVarChar = "NVARCHAR";
            public const string dbVarChar2 = "VARCHAR2";
            public const string dbNVarChar2 = "NVARCHAR2";

            public const string dbRowId = "ROWID";
            public const string dbUrowId = "UROWID";
            public const string dbLong = "LONG";

            public const string dbBFile = "BFILE";
            public const string dbBlob = "BLOB";
            public const string dbClob = "CLOB";
            public const string dbNClob = "NCLOB";
            public const string dbRaw = "RAW";
            public const string dbLongRaw = "LONG RAW";
            public const string dbBinaryDouble = "BINARY_DOUBLE";
            public const string dbBinaryFloat = "BINARY_FLOAT";
            public const string dbUriType = "URITYPE";

            public const string dbCharVarying = "CHAR VARYING";
            public const string dbNCharVarying = "NCHAR VARYING";
            public const string dbNationalChar = "NATIONAL CHAR";
            public const string dbNationalCharVarying = "NATIONAL CHAR VARYING";
            public const string dbNationalCharacter = "NATIONAL CHARACTER";
            public const string dbNationalCharacterVarying = "NATIONAL CHARACTER VARYING";

            public const string dbInt = "INT";
            public const string dbInteger = "INTEGER";
            public const string dbSmallint = "SMALLINT";
            public const string dbReal = "REAL";
            public const string dbFloat = "FLOAT";
            public const string dbDecimal = "DECIMAL";
            public const string dbNumber = "NUMBER";

            public const string dbDoublePrecision = "DOUBLE PRECISION";

            public const string dbDate = "DATE";
            public const string dbTimestamp = "TIMESTAMP";
            public const string dbInterval = "INTERVAL";

            //Default Type
            public const string dbObject = "object";
        }

        public struct CSharpDataTypes
        {
            public const string csByteArr = "byte[]";
            public const string csGuid = "Guid";
            public const string csDateTime = "DateTime";
            public const string csDouble = "double";
            public const string csString = "string";
            public const string csBool = "bool";
            public const string csLong = "long";
            public const string csShort = "short";
            public const string csByte = "byte";
            public const string csDecimal = "decimal";
            public const string csFloat = "float";
            public const string csInt = "int";
        }

        public static string GetCSharpDataType(DatabaseTypes pDatabaseType, string pTypeName)
        {
            if (pDatabaseType == DatabaseTypes.MS_SQL)
            {
                return GetCSharpDataTypeFromSql(pTypeName);
            }
            else if (pDatabaseType == DatabaseTypes.ORACLE)
            {
                return GetCSharpDataTypeFromOracle(pTypeName);
            }
            else
                return GetCSharpDataTypeFromSql(pTypeName);
        }

        private static string GetCSharpDataTypeFromSql(string pTypeName)
        {
            string csType = string.Empty;

            switch (pTypeName)
            {
                case SqlDataTypes.dbBit: csType = CSharpDataTypes.csBool; break;
                case SqlDataTypes.dbTinyint: csType = CSharpDataTypes.csByte; break;
                case SqlDataTypes.dbSmallint: csType = CSharpDataTypes.csShort; break;
                case SqlDataTypes.dbInt: csType = CSharpDataTypes.csInt; break;
                case SqlDataTypes.dbBigint: csType = CSharpDataTypes.csLong; break;
                case SqlDataTypes.dbMoney: csType = CSharpDataTypes.csDecimal; break;
                case SqlDataTypes.dbReal: csType = CSharpDataTypes.csDouble; break;
                case SqlDataTypes.dbFloat: csType = CSharpDataTypes.csDouble; break;
                case SqlDataTypes.dbDecimal: csType = CSharpDataTypes.csDecimal; break;
                case SqlDataTypes.dbNumeric: csType = CSharpDataTypes.csDecimal; break;

                case SqlDataTypes.dbUniqueidentifier: csType = CSharpDataTypes.csGuid; break;
                case SqlDataTypes.dbTimestamp: csType = CSharpDataTypes.csInt; break;
                case SqlDataTypes.dbVarbinary: csType = CSharpDataTypes.csByteArr; break;
                case SqlDataTypes.dbBinary: csType = CSharpDataTypes.csByteArr; break;
                case SqlDataTypes.dbXml: csType = CSharpDataTypes.csString; break;

                case SqlDataTypes.dbChar: csType = CSharpDataTypes.csString; break;
                case SqlDataTypes.dbVarChar: csType = CSharpDataTypes.csString; break;
                case SqlDataTypes.dbNVarChar: csType = CSharpDataTypes.csString; break;

                case SqlDataTypes.dbDate: csType = CSharpDataTypes.csDateTime; break;
                case SqlDataTypes.dbDateTime: csType = CSharpDataTypes.csDateTime; break;
                case SqlDataTypes.dbSmallDateTime: csType = CSharpDataTypes.csDateTime; break;
                case SqlDataTypes.dbTime: csType = CSharpDataTypes.csDateTime; break;

                default: csType = SqlDataTypes.dbObject; break;
            }

            return csType;
        }

        private static string GetCSharpDataTypeFromOracle(string pTypeName)
        {
            string csType = string.Empty;

            switch (pTypeName)
            {
                case OracleDataTypes.dbChar: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNChar: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbVarChar: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNVarChar: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbVarChar2: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNVarChar2: csType = CSharpDataTypes.csString; break;

                case OracleDataTypes.dbRowId: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbUrowId: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbLong: csType = CSharpDataTypes.csString; break;

                case OracleDataTypes.dbBFile: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbBlob: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbClob: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbNClob: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbRaw: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbLongRaw: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbBinaryDouble: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbBinaryFloat: csType = CSharpDataTypes.csByteArr; break;
                case OracleDataTypes.dbUriType: csType = CSharpDataTypes.csByteArr; break;

                case OracleDataTypes.dbCharVarying: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNCharVarying: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNationalChar: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNationalCharVarying: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNationalCharacter: csType = CSharpDataTypes.csString; break;
                case OracleDataTypes.dbNationalCharacterVarying: csType = CSharpDataTypes.csString; break;

                case OracleDataTypes.dbInt: csType = CSharpDataTypes.csInt; break;
                case OracleDataTypes.dbInteger: csType = CSharpDataTypes.csInt; break;
                case OracleDataTypes.dbSmallint: csType = CSharpDataTypes.csShort; break;
                case OracleDataTypes.dbReal: csType = CSharpDataTypes.csDecimal; break;
                case OracleDataTypes.dbFloat: csType = CSharpDataTypes.csDecimal; break;
                case OracleDataTypes.dbDecimal: csType = CSharpDataTypes.csDecimal; break;
                case OracleDataTypes.dbNumber: csType = CSharpDataTypes.csInt; break;

                case OracleDataTypes.dbDoublePrecision: csType = CSharpDataTypes.csDecimal; break;

                case OracleDataTypes.dbDate: csType = CSharpDataTypes.csDateTime; break;
                case OracleDataTypes.dbTimestamp: csType = CSharpDataTypes.csDateTime; break;
                case OracleDataTypes.dbInterval: csType = CSharpDataTypes.csDateTime; break;

                default: csType = SqlDataTypes.dbObject; break;
            }

            return csType;
        }

        public static string GetSystemDataType(string pTypeName)
        {
            string cType = string.Empty;

            switch (pTypeName)
            {
                case CSharpDataTypes.csByte: cType = DbType.Byte.ToString(); break;
                case CSharpDataTypes.csShort: cType = DbType.Int16.ToString(); break;
                case CSharpDataTypes.csInt: cType = DbType.Int32.ToString(); break;
                case CSharpDataTypes.csLong: cType = DbType.Int64.ToString(); break;
                case CSharpDataTypes.csDouble: cType = DbType.Double.ToString(); break;
                case CSharpDataTypes.csDecimal: cType = DbType.Decimal.ToString(); break;
                case CSharpDataTypes.csString: cType = DbType.String.ToString(); break;
                case CSharpDataTypes.csBool: cType = DbType.Boolean.ToString(); break;
                case CSharpDataTypes.csDateTime: cType = DbType.DateTime.ToString(); break;
            }

            return cType;
        }

        public static string GetDefaultDbDataTypeForIdentityColumn(DatabaseTypes pDatabaseType)
        {
            if (pDatabaseType == DatabaseTypes.MS_SQL)
            {
                return SqlDataTypes.dbInt;
            }
            else if (pDatabaseType == DatabaseTypes.ORACLE)
            {
                return OracleDataTypes.dbNumber;
            }
            else
                return SqlDataTypes.dbInt;
        }

        public static bool IsDbDataTypeTimestamp(DatabaseTypes pDatabaseType, string pDbDataType)
        {
            if (pDatabaseType == DatabaseTypes.MS_SQL)
            {
                return pDbDataType == SqlDataTypes.dbTimestamp;
            }
            else if (pDatabaseType == DatabaseTypes.ORACLE)
            {
                return pDbDataType == OracleDataTypes.dbTimestamp;
            }
            else
                return false;
        }

        public static bool IsDbDataTypeUnsuitableForWhereClause(DatabaseTypes pDatabaseType, string pDbDataType)
        {
            if (pDatabaseType == DatabaseTypes.MS_SQL)
            {
                if (pDbDataType == SqlDataTypes.dbTimestamp ||
                    pDbDataType == SqlDataTypes.dbBinary ||
                    pDbDataType == SqlDataTypes.dbVarbinary ||
                    pDbDataType == SqlDataTypes.dbXml)
                    return true;
            }
            else if (pDatabaseType == DatabaseTypes.ORACLE)
            {
                if (pDbDataType == OracleDataTypes.dbTimestamp ||
                    pDbDataType == OracleDataTypes.dbBFile ||
                    pDbDataType == OracleDataTypes.dbBinaryDouble ||
                    pDbDataType == OracleDataTypes.dbBinaryFloat ||
                    pDbDataType == OracleDataTypes.dbBlob ||
                    pDbDataType == OracleDataTypes.dbClob ||
                    pDbDataType == OracleDataTypes.dbNClob ||
                    pDbDataType == OracleDataTypes.dbRaw ||
                    pDbDataType == OracleDataTypes.dbLongRaw ||
                    pDbDataType == OracleDataTypes.dbUriType
                    )
                    return true;
            }

            return false;
        }

        public static bool IsDbDataTypeNumeric(DatabaseTypes pDatabaseType, string pDbDataType)
        {
            if (pDatabaseType == DatabaseTypes.MS_SQL)
            {
                if (pDbDataType == SqlDataTypes.dbBigint ||
                    pDbDataType == SqlDataTypes.dbDecimal ||
                    pDbDataType == SqlDataTypes.dbFloat ||
                    pDbDataType == SqlDataTypes.dbInt ||
                    pDbDataType == SqlDataTypes.dbMoney ||
                    pDbDataType == SqlDataTypes.dbNumeric ||
                    pDbDataType == SqlDataTypes.dbReal ||
                    pDbDataType == SqlDataTypes.dbSmallint ||
                    pDbDataType == SqlDataTypes.dbTinyint ||
                    pDbDataType == SqlDataTypes.dbBit
                    )
                    return true;
            }
            else if (pDatabaseType == DatabaseTypes.ORACLE)
            {
                if (pDbDataType == OracleDataTypes.dbDecimal ||
                    pDbDataType == OracleDataTypes.dbFloat ||
                    pDbDataType == OracleDataTypes.dbInt ||
                    pDbDataType == OracleDataTypes.dbInteger ||
                    pDbDataType == OracleDataTypes.dbNumber ||
                    pDbDataType == OracleDataTypes.dbReal ||
                    pDbDataType == OracleDataTypes.dbSmallint
                    )
                    return true;
            }

            return false;
        }

        public static bool IsDbDataTypeDate(DatabaseTypes pDatabaseType, string pDbDataType)
        {
            if (pDatabaseType == DatabaseTypes.MS_SQL)
            {
                if (pDbDataType == SqlDataTypes.dbDate ||
                    pDbDataType == SqlDataTypes.dbDateTime ||
                    pDbDataType == SqlDataTypes.dbDateTime2 ||
                    pDbDataType == SqlDataTypes.dbSmallDateTime ||
                    pDbDataType == SqlDataTypes.dbTime
                    )
                    return true;
            }
            else if (pDatabaseType == DatabaseTypes.ORACLE)
            {
                if (pDbDataType == OracleDataTypes.dbDate ||
                    pDbDataType == OracleDataTypes.dbInterval
                    )
                    return true;
            }

            return false;
        }
    }
}
