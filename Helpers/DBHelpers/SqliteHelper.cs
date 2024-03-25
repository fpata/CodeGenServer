using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using System.Data.SQLite;
using CodeGenServer.Helpers.DBHelpers;

namespace CodeGenServer.DBHelpers
{
    public class SQLiteHelper:IDBHelper
    {
        private string connectionString;
      

        public SQLiteHelper(string connectStr)
        {
            this.connectionString = connectStr;
            base.dbConnection = new SQLiteConnection(this.connectionString);
           
        }


        public override DataTable GetTables()
        {
            DataTable dtTables = base.ExecuteQuery("SELECT  rootpage, name, tbl_name,type FROM SQLite_master where type = 'table' order by rootpage"
            , new SQLiteDataAdapter());
            return dtTables;
        }


        public override DataTable GetTableNames()
        {

            DataTable dtTables = base.ExecuteQuery("SELECT Name FROM SQLite_master where type = 'table'",
            new SQLiteDataAdapter() );
            return dtTables;
        }

        public override DataTable GetColumns(string tableName)
        {
            DataTable dtTables = base.ExecuteQuery("PRAGMA table_info('"+tableName+"')",new SQLiteDataAdapter());
            return dtTables;
        }

        public override DataTable GetData(string tableName)
        {
            DataTable dtTables = base.ExecuteQuery("Select * from " + tableName + " LIMIT 10", new SQLiteDataAdapter());
            return dtTables;
        }

    }
}
