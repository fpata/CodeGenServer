using System;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CodeGenServer.Helpers.DBHelpers;
using CodeGenServer.Helpers.CodeHelpers;

namespace CodeGenServer
{
    [Route("api/[Controller]/[Action]")]
    public class SchemaController : Controller
    {
       
        [HttpGet]
        public string GetTables(SchemaInputModel schemaInputModel)
        { 
            IDBHelper dbhelper = DBFactory.GetDBInstance(schemaInputModel.connectStr, schemaInputModel.dbType);
            DataTable dtTables = dbhelper.GetTables();
            return DataTableToJSONString(dtTables);
        }

        [HttpGet]
        public string GetColumns(SchemaInputModel schemaInputModel)
        {
           
            IDBHelper dbhelper = DBFactory.GetDBInstance(schemaInputModel.connectStr, schemaInputModel.dbType);
            DataTable dtColumns = dbhelper.GetColumns(schemaInputModel.tableName);
            return DataTableToJSONString(dtColumns);
        }

        [HttpGet]
        public string GetCode(SchemaInputModel schemaInputModel)
        {
            String code = String.Empty;
         
            IDBHelper dbhelper = DBFactory.GetDBInstance(schemaInputModel.connectStr, schemaInputModel.dbType);
            ICodeHelper codeHelper = DBFactory.GetCodeHelper(schemaInputModel.codeType);
            DataTable? dtTables = null;
            DataTable? dtColumns = null;
            if (schemaInputModel.codeType == CodeType.CSharpDBContext)
                  dtTables = dbhelper.GetTables();
            if (schemaInputModel.codeType.ToString().StartsWith("CSharp") || schemaInputModel.codeType == CodeType.TypeScript)
                 dtColumns = dbhelper.GetColumns(schemaInputModel.tableName);
             code = codeHelper.GetCode(schemaInputModel.tableName, ORM.None, dtTables, dtColumns);
            return code;
        }

        [HttpGet]
        public String CreateFiles(SchemaInputModel schemaInputModel)
        {
           
            string fileExtn = schemaInputModel.codeType.ToString().StartsWith("C")? ".cs" : ".ts";
            IDBHelper dbhelper = DBFactory.GetDBInstance(schemaInputModel.connectStr, schemaInputModel.dbType);
            ICodeHelper codeHelper = DBFactory.GetCodeHelper(schemaInputModel.codeType);
            DataTable? dtTables = dbhelper.GetTables();
            FileHelper fileHelper = new FileHelper();
            String? tableName = String.Empty;
            DataTable? dtColumns = null;
            foreach (DataRow dr in dtTables.Rows)
            {
                tableName = dr["Name"]?.ToString();
                dtColumns = dbhelper.GetColumns(tableName);
                String code = codeHelper.GetCode(tableName, ORM.None, dtTables, dtColumns);
                fileHelper.WriteFile(tableName + fileExtn, code);
            }
            return "Process Complete";
        }
       
        private string DataTableToJSONString(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            JSONString = JSONString.Replace(@"\", "");
            return JSONString.ToString();
        }
    }

    public class SchemaInputModel
    {
        public string connectStr = String.Empty;
        public string tableName = String.Empty;
        public CodeType codeType = CodeType.TypeScript;
        public string orm = string.Empty;
        public DBType dbType = DBType.SqlServer;
    }
    public enum ORM
    {
        None,
        EntityFramework,
        Dapper,
        EFFluentMap,
        BootStrap,
        Material
    }

    public enum DBType
    {
        Sqlite,
        Oracle,
        MySQL,
        SqlServer
    }

    public enum CodeType
    {
        CSharpEntity,
        CSharpDAL,
        CSharpDBContext,
        CSharpEFMapping,
        TypeScript,
        HTML,
        HTMLBootStrap,
        HTMLMaterial
    }
    
}