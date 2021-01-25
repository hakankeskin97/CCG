using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Oracle.DataAccess.Client;

namespace CrudClassGenerator
{
    public enum DatabaseTypes
    {
        MS_SQL = 0,
        ORACLE = 1
    }

    public struct DatabaseTypeName
    {
        public const string MS_SQL = "MS_SQL";
        public const string ORACLE = "ORACLE";
    }

    public enum JoinTypes
    {
        JoinWithLookupTables,
        JoinWithDetailTables,
        JoinAll
    }

    public interface IDataAccess
    {
        void GetConnection(string pConnectionString);
        DbDataAdapter GetDataAdapter(string pDbCommandText);
        DataTable GetRecords(string pDbCommandText);
        string DataBaseName();
        string DataSourceName();
        DataTable LoadSchemas();
        DataTable GetTables(string pSchemaName);
        DataTable GetColumnsProperties(string pSchemaName, string pTableName);
        DataTable PrimaryKeyColumnName(string pSchemaName, string pTableName);
        DataTable GetJoinString(ref string pSelectPart, ref string pJoinPart, JoinTypes pJoinTypes, string pSchemaName, string pTableName, string pLookupTablePrefix);
        DataTable GetTableColumns(string pSchemaName, string pTableName);
    }

    public class SqlDataAccess : IDataAccess
    {
        private SqlConnection Conn;

        public void GetConnection(string pConnectionString)
        {
            if (Conn != null) { if (Conn.State == ConnectionState.Open) Conn.Close(); }
            Conn = new SqlConnection(pConnectionString);
            Conn.Open();
        }

        public DbDataAdapter GetDataAdapter(string pDbCommandText)
        {
            return new SqlDataAdapter(pDbCommandText, Conn);
        }

        public DataTable GetRecords(string pDbCommandText)
        {
            SqlCommand cmd = new SqlCommand(pDbCommandText, Conn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public string DataBaseName()
        {
            return Conn.Database;
        }

        public string DataSourceName()
        {
            return Conn.DataSource;
        }

        public DataTable LoadSchemas()
        {
            string sql = @"SELECT 
                                S.name AS SchemaName,
                                S.schema_id AS SchemaId 
                           FROM 
                                sys.schemas AS S 
                           ORDER BY 
                                S.name";

            SqlCommand cmd = new SqlCommand(sql, Conn);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetTables(string pSchemaName)
        {
            if (pSchemaName == string.Empty) return new DataTable();

            string sql = @"SELECT  
                                T.name AS TableName,
                                T.object_id AS TableId
                            FROM 
                                sys.schemas AS S 
                                INNER JOIN  
                                sys.tables AS T ON S.schema_id=T.schema_id
                            WHERE 
                                S.name = @pSchemaName
                            ORDER BY 
                                S.name, 
                                T.name
                            ";

            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@pSchemaName", pSchemaName);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetColumnsProperties(string pSchemaName, string pTableName)
        {
            string sql = @" SELECT	
                                C.[name] AS ColumnName,
                                C.is_identity AS ISIDENTITY,
                                C.is_computed AS IsComputed,
                                C.is_nullable AS IsNullable,
                                C.max_length AS MaxLength,
                                T.name AS SysTypeName

                            FROM			
                                SYS.OBJECTS AS O 
                                INNER JOIN  
                                SYS.SCHEMAS AS S ON S.schema_id = O.schema_id
                                INNER JOIN  
                                SYS.COLUMNS AS C ON C.object_id = O.object_id
                                INNER JOIN  
                                SYS.TYPES	AS T ON T.system_type_id = C.system_type_id 

                            WHERE 
                                S.name = @pSchemaName AND 
                                O.name = @pTableName AND
                                T.name <> 'sysname'
                            ORDER BY 
                                C.column_id
                          ";

            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@pSchemaName", pSchemaName);
            cmd.Parameters.AddWithValue("@pTableName", pTableName);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable PrimaryKeyColumnName(string pSchemaName, string pTableName)
        {
            string sql = @"
                            SELECT 	
                                C.COLUMN_NAME

                            FROM 	
                                INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS PK  
                                INNER JOIN 
                                INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS C ON (C.CONSTRAINT_SCHEMA = PK.TABLE_SCHEMA 
                                        AND C.TABLE_NAME = PK.TABLE_NAME 
                                        AND C.CONSTRAINT_NAME = PK.CONSTRAINT_NAME)
                                    
                            WHERE 	
                                PK.TABLE_SCHEMA = @pSchemaName AND	
                                PK.TABLE_NAME = @pTableName AND
                                PK.CONSTRAINT_TYPE = 'PRIMARY KEY'";

            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@pSchemaName", pSchemaName);
            cmd.Parameters.AddWithValue("@pTableName", pTableName);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetJoinString(ref string pSelectPart, ref string pJoinPart, JoinTypes pJoinTypes, string pSchemaName, string pTableName, string pLookupTablePrefix)
        {
            string schemaCondition = string.Empty;
            switch (pJoinTypes)
            {
                case JoinTypes.JoinWithLookupTables: schemaCondition = string.Join("", " AND TC.TABLE_SCHEMA LIKE '", pLookupTablePrefix, "%'"); break;
                case JoinTypes.JoinWithDetailTables: schemaCondition = string.Join("", " AND TC.TABLE_SCHEMA NOT LIKE '", pLookupTablePrefix, "%'"); break;
                case JoinTypes.JoinAll: break;
            }

            string sql = @"
            WITH RELATION AS
            (
                SELECT   
                    ROW_NUMBER() OVER (ORDER BY TC.TABLE_NAME ASC) AS RowNo,
                    TC.TABLE_CATALOG + '.' + TC.TABLE_SCHEMA + '.' + TC.TABLE_NAME AS PKTableName,
                    CCU2.COLUMN_NAME AS PKColumnName,
                    CCU.COLUMN_NAME AS FKColumnName
                        
                FROM	
                    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE AS CCU
                    INNER JOIN 
                    INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS AS RC ON CCU.CONSTRAINT_SCHEMA = RC.CONSTRAINT_SCHEMA 
                            AND CCU.CONSTRAINT_NAME = RC.CONSTRAINT_NAME
                    INNER JOIN 
                    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE CCU2 ON CCU2.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA 
                            AND CCU2.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME 
                    INNER JOIN
                    INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC ON TC.CONSTRAINT_SCHEMA = RC.UNIQUE_CONSTRAINT_SCHEMA 
                            AND TC.CONSTRAINT_NAME = RC.UNIQUE_CONSTRAINT_NAME

                WHERE 
                    CCU.TABLE_SCHEMA = @pSchemaName AND 
                    CCU.TABLE_NAME = @pTableName {0}
            )
            SELECT	 
                'T' + CAST(RowNo AS VARCHAR(30)) + '.*' AS SelectPart,
                '[[0]] ' + PKTableName + ' AS T' + CAST(RowNo AS VARCHAR(30)) + ' ON T' + CAST(RowNo AS VARCHAR(30)) + '.' + PKColumnName + ' = ' + ' MT.' + FKColumnName AS JoinPart
            FROM 
                RELATION
            ";

            sql = string.Format(sql, schemaCondition);

            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@pSchemaName", pSchemaName);
            cmd.Parameters.AddWithValue("@pTableName", pTableName);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetTableColumns(string pSchemaName, string pTableName)
        {
            if (pSchemaName == string.Empty) return new DataTable();

            string sql = @"
                        SELECT	
                            C.name AS ColumnName,
                            C.column_id AS ColumnId
                        FROM			
                            SYS.OBJECTS AS O 
                            INNER JOIN  
                            SYS.SCHEMAS AS S ON S.schema_id = O.schema_id
                            INNER JOIN  
                            SYS.COLUMNS AS C ON C.object_id = O.object_id
                            INNER JOIN  
                            SYS.TYPES	AS T ON T.system_type_id = C.system_type_id 
                        WHERE 
                            S.name = @pSchemaName AND 
                            O.name = @pTableName
                        ORDER BY 
                            C.column_id
                            ";

            SqlCommand cmd = new SqlCommand(sql, Conn);
            cmd.Parameters.AddWithValue("@pSchemaName", pSchemaName);
            cmd.Parameters.AddWithValue("@pTableName", pTableName);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }
    }

    /*
     * To use CCG with Oracle:
     * 
     * 1. Setup "Oracle Data Provider for .Net"
     * 2. Reference "Oracle.DataAccess.dll"
     * 3. Reference "CCGDataService" which was builded with "Oracle.DataAccess.dll"
     * 4. Uncomment fallowing commented lines and delete "return null;" lines.
     * 
    */

    public class OracleDataAccess : IDataAccess
    {
        private OracleConnection Conn;

        public void GetConnection(string pConnectionString)
        {
            if (Conn != null) { if (Conn.State == ConnectionState.Open) Conn.Close(); }
            Conn = new OracleConnection(pConnectionString);
            Conn.Open();
        }

        public DbDataAdapter GetDataAdapter(string pDbCommandText)
        {
            return new OracleDataAdapter(pDbCommandText, Conn);
        }

        public DataTable GetRecords(string pDbCommandText)
        {
            OracleCommand cmd = new OracleCommand(pDbCommandText, Conn);
            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public string DataBaseName()
        {
            return Conn.DatabaseName;
        }

        public string DataSourceName()
        {
            return Conn.DataSource;
        }

        public DataTable LoadSchemas()
        {
            string sql = @"
                            SELECT 
                                USERNAME AS SchemaName,
                                USER_ID AS SchemaId
                            FROM 
                                SYS.ALL_USERS
                            ORDER BY 
                                USERNAME";

            OracleCommand cmd = new OracleCommand(sql, Conn);
            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetTables(string pSchemaName)
        {
            if (pSchemaName == string.Empty) return new DataTable();

            string sql = @"
                            SELECT 
                                TABLE_NAME AS TableName
                            FROM 
                                SYS.ALL_TABLES 
                            WHERE  
                                OWNER = :pSchemaName 
                            ORDER BY 
                                TABLE_NAME
                            ";

            OracleCommand cmd = new OracleCommand(sql, Conn);

            cmd.Parameters.Add(":pSchemaName", pSchemaName);

            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetColumnsProperties(string pSchemaName, string pTableName)
        {
            string sql = @" 
                            SELECT
                                COLUMN_NAME AS ColumnName,
                                0 AS ISIDENTITY,
                                0 AS IsComputed,
                                    CASE NULLABLE
                                        WHEN 'Y' THEN 1
                                        WHEN 'N' THEN 0
                                    END 
                                AS IsNullable,
                                DATA_LENGTH AS MaxLength,
                                DATA_TYPE AS SysTypeName

                            FROM 
                                SYS.ALL_TAB_COLUMNS

                            WHERE 
                                OWNER = :pTabloName AND
                                TABLE_NAME = :pSchemaName 
                            ORDER BY 
                                COLUMN_ID 
                          ";

            OracleCommand cmd = new OracleCommand(sql, Conn);

            cmd.Parameters.Add(":pSchemaName", pSchemaName);
            cmd.Parameters.Add(":pTabloName", pTableName);

            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable PrimaryKeyColumnName(string pSchemaName, string pTableName)
        {
            string sql = @"
                            SELECT
                               clm.COLUMN_NAME

                            FROM
                                ALL_CONS_COLUMNS clm
                                INNER JOIN
                                ALL_CONSTRAINTS cs ON cs.OWNER = clm.OWNER AND cs.CONSTRAINT_NAME = clm.CONSTRAINT_NAME
    
                            WHERE 
                                clm.OWNER = :pSchemaName AND
                                clm.TABLE_NAME = :pTabloName AND
                                cs.CONSTRAINT_TYPE = 'P' AND
                                ROWNUM <= 1
                            ";

            OracleCommand cmd = new OracleCommand(sql, Conn);

            cmd.Parameters.Add(":pSchemaName", pSchemaName);
            cmd.Parameters.Add(":pTabloName", pTableName);

            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetJoinString(ref string pSelectPart, ref string pJoinPart, JoinTypes pJoinTypes, string pSchemaName, string pTableName, string pLookupTablePrefix)
        {
            string schemaCondition = string.Empty;
            switch (pJoinTypes)
            {
                case JoinTypes.JoinWithLookupTables: schemaCondition = string.Join("", " AND clm.table_name LIKE '", pLookupTablePrefix, "%'"); break;
                case JoinTypes.JoinWithDetailTables: schemaCondition = string.Join("", " AND clm.table_name NOT LIKE '", pLookupTablePrefix, "%'"); break;
                case JoinTypes.JoinAll: break;
            }

            string sql = @"
                WITH RELATION AS
                    (
                    SELECT
                        row_number() OVER (ORDER BY clm.table_name ASC) AS RowNo,
                        cspk.owner || '.' || cspk.table_name AS PKTableName,
                        clm2.column_name AS PKColumnName,
                        clm.column_name AS FKColumnName

                    FROM
                        all_cons_columns clm
                        INNER JOIN
                        all_constraints cs ON cs.owner = clm.owner AND cs.constraint_name = clm.constraint_name
                        INNER JOIN
                        all_constraints cspk ON cspk.owner = cs.r_owner AND cspk.constraint_name = cs.r_constraint_name
                        INNER JOIN
                        all_cons_columns clm2 ON clm2.constraint_name = cspk.constraint_name AND clm2.owner = cspk.owner
    
                    WHERE 
                        clm.owner = :pSchemaName AND
                        clm.Table_Name = :pTabloName AND
                        cs.constraint_type = 'R' {0}
                    )
                    SELECT     
                        'T' || CAST(RowNo AS VARCHAR(30)) || '.*' AS SelectPart,
                        'INNER JOIN ' || PKTableName || ' T' || CAST(RowNo AS VARCHAR(30)) || ' ON T' || CAST(RowNo AS VARCHAR(30)) || '.' || PKColumnName || ' = ' || ' MT.' || FKColumnName AS JoinPart
                    FROM 
                        RELATION
            ";

            sql = string.Format(sql, schemaCondition);

            OracleCommand cmd = new OracleCommand(sql, Conn);

            cmd.Parameters.Add(":pSchemaName", pSchemaName);
            cmd.Parameters.Add(":pTabloName", pTableName);

            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }

        public DataTable GetTableColumns(string pSchemaName, string pTableName)
        {
            if (pSchemaName == string.Empty) return new DataTable();

            string sql = @"
                        SELECT	
                            C.name AS ColumnName,
                            C.column_id AS ColumnId
                        FROM			
                            SYS.OBJECTS AS O 
                            INNER JOIN  
                            SYS.SCHEMAS AS S ON S.schema_id = O.schema_id
                            INNER JOIN  
                            SYS.COLUMNS AS C ON C.object_id = O.object_id
                            INNER JOIN  
                            SYS.TYPES	AS T ON T.system_type_id = C.system_type_id 
                        WHERE 
                            S.name = @pSchemaName AND 
                            O.name = @pTableName
                        ORDER BY 
                            C.column_id
                            ";

            OracleCommand cmd = new OracleCommand(sql, Conn);
            cmd.Parameters.Add(":pSchemaName", pSchemaName);
            cmd.Parameters.Add(":pTableName", pTableName);

            OracleDataReader dr = cmd.ExecuteReader(CommandBehavior.Default);
            DataTable oDt = new DataTable();
            oDt.Load(dr);
            return oDt;
        }
    }

}
