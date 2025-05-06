using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeGenServer.Helpers.DBHelpers;

namespace CodeGenServer.DBHelpers
{
    public class SQLServerHelper : IDBHelper
    {
        private string connectionString;

        public SQLServerHelper(string connectStr)
        {
            this.connectionString = connectStr;
            base.dbConnection = new  SqlConnection(this.connectionString);
        }
        public override DataTable GetColumns(string tableName)
        {
            DataTable dtTables = base.ExecuteQuery(" select COLUMN_NAME as name, DATA_TYPE as type, CHARACTER_MAXIMUM_LENGTH as length,  IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = '" + tableName + "'",
            new SqlDataAdapter());
            return dtTables;
        }

        public override DataTable GetData(string tableName)
        {
            DataTable dtTables = base.ExecuteQuery("SELECT * FROM " + tableName + " LIMIT 10",
            new SqlDataAdapter());
            return dtTables;
        }

        public override DataTable GetTableNames()
        {
            DataTable dtTables = base.ExecuteQuery("SELECT TABLE_NAME as name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'",
            new SqlDataAdapter());
            return dtTables;
        }

        public override DataTable GetTables()
        {
            DataTable dtTables = base.ExecuteQuery("SELECT * FROM INFORMATION_SCHEMA.TABLES ",
            new SqlDataAdapter());
            return dtTables;
        }
    }
}
