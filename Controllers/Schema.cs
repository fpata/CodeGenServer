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
        private string connectStr = String.Empty;
        private string tableName = String.Empty;
        private string codeType = String.Empty;
        private string orm = string.Empty;

        [HttpGet]
        public string GetTables([FromQuery]string strData)
        { 
            SetObjectData(strData);
            IDBHelper dbhelper = DBFactory.GetDBInstance(this.connectStr, DBType.Sqlite);
            DataTable dtTables = dbhelper.GetTables();
            return DataTableToJSONString(dtTables);
        }

        [HttpGet]
        public string GetColumns([FromQuery] string strData)
        {
            SetObjectData(strData);
            IDBHelper dbhelper = DBFactory.GetDBInstance(this.connectStr, DBType.Sqlite);
            DataTable dtColumns = dbhelper.GetColumns(this.tableName);
            return DataTableToJSONString(dtColumns);
        }

        [HttpGet]
        public string GetCode([FromQuery] string strData)
        {
            String code = String.Empty;
            SetObjectData(strData);
            IDBHelper dbhelper = DBFactory.GetDBInstance(this.connectStr, DBType.Sqlite);
            ICodeHelper codeHelper = DBFactory.GetCodeHelper(this.codeType,ORM.None);
            DataTable? dtTables = null;
            DataTable? dtColumns = null;
            if (this.codeType.Equals("CSharpDBContext", StringComparison.InvariantCultureIgnoreCase))
                  dtTables = dbhelper.GetTables();
            if (this.codeType.Equals("CSharpEntity", StringComparison.InvariantCultureIgnoreCase)
            || this.codeType.Equals("TypeScript", StringComparison.InvariantCultureIgnoreCase))
                 dtColumns = dbhelper.GetColumns(this.tableName);
             code = codeHelper.GetCode(this.tableName, ORM.None, dtTables, dtColumns);
            return code;
        }

        [HttpGet]
        public String CreateFiles([FromQuery] string strData)
        {
            SetObjectData(strData);
            string fileExtn = this.codeType.StartsWith('C') ? ".cs" : ".ts";
            IDBHelper dbhelper = DBFactory.GetDBInstance(this.connectStr, DBType.Sqlite);
            ICodeHelper codeHelper = DBFactory.GetCodeHelper(this.codeType, ORM.None);
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

        private void SetObjectData([FromQuery] string strData)
        {
            JObject objectData = JObject.Parse(strData);
            this.connectStr = objectData["connectStr"] == null ? String.Empty : (String)objectData["connectStr"];
            this.tableName = objectData["tableName"] == null ? String.Empty : (String)objectData["tableName"];
            this.codeType = objectData["codeType"] == null ? String.Empty : (String)objectData["codeType"];
            var ormval = objectData["ORM"] == null ? "None" : (String)objectData["ORM"];
            var orm = Enum.Parse<ORM>(ormval, true);
        }
    }

    
}