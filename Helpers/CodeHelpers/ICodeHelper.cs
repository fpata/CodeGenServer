using CodeGenServer;
using System.Data;

namespace CodeGenServer.Helpers.CodeHelpers
{
    public interface ICodeHelper
    {
        String GetCode(String tableName, ORM ormType, DataTable? dtTables = null, DataTable? dtColumns = null);
    }
}