using System.Data;
using System.Data.Common;

namespace CodeGenServer.Helpers.DBHelpers
{
    public abstract class IDBHelper
    {
        protected DbConnection? dbConnection;
        protected DbCommand? dbCommand;
        public virtual bool TestConnection()
        {
            bool isSuccess = true;
            try
            {
                dbConnection?.Open();
                dbConnection?.Close();
            }
            catch (Exception ex)
            {
                isSuccess = false;
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
            return isSuccess;
        }

        protected virtual DataTable ExecuteQuery(string query, DbDataAdapter dataAdapter)
        {
            DataSet ds = new DataSet();
            try
            {
                dbCommand = dbConnection.CreateCommand();
                dbCommand.CommandText = query;
                dbCommand.Connection = dbConnection;
                dataAdapter.FillError += DataAdapter_FillError;
                dataAdapter.SelectCommand = dbCommand;
                dataAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.ToString());
            }
            finally
            {
                if (dbConnection.State != ConnectionState.Closed)
                    dbConnection.Close();
            }
            return ds.Tables[0];
        }

        private void DataAdapter_FillError(object sender, FillErrorEventArgs e)
        {
            throw new NotImplementedException();
        }

        public abstract DataTable GetTables();
        public abstract DataTable GetTableNames();
        public abstract DataTable GetColumns(string tableName);
        public abstract DataTable GetData(string tableName);
    }
}
