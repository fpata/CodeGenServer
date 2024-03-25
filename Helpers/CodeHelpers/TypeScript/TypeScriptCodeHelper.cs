using System;
using System.Data;
using System.Globalization;
using System.Text;
using CodeGenServer.Helpers.CodeHelpers;

namespace CodeGenServer
{
    public class TypScriptCodeHelper : ICodeHelper
    {
        public string GetCode(string tableName, ORM ORMType ,DataTable dtTables, DataTable dtColumns)
        {

            StringBuilder sb = new StringBuilder();
            sb.Append("export class " + tableName);
            sb.AppendLine(" {");
            appendProperty(ref sb, dtColumns);
            sb.AppendLine("}");
            return sb.ToString();
        }

        private void appendProperty(ref StringBuilder sb, DataTable dtColumns)
        {
            foreach (DataRow dr in dtColumns.Rows)
            {
                string dataType = getDataType(dr["type"].ToString());
                string colName = dr["name"]?.ToString();
                sb.AppendLine("\t" + getColName(colName)   + ": " + dataType + ";");
                sb.AppendLine();
            }
        }

        private string getColName(string colName)
        {
            if(!String.IsNullOrWhiteSpace(colName))
            {
              colName =  Char.ToLowerInvariant(colName[0]) + colName.Substring(1);
            }
            return colName;
        }

        private string getDataType(string dataType)
        {
            string retType = String.Empty;
            dataType = dataType.ToLower();
            switch (dataType)
            {
                case "number":
                case "integer":
                    retType = "number";
                    break;
                case "text":
                case "varchar":
                case "varchar2":
                case "date":
                case "datetime":
                    retType = "string";
                    break;
                default:
                    retType = "string";
                    break;
            }
            return retType;
        }
    }
}