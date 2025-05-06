using System;
using System.Data;
using System.Globalization;
using System.Text;
using CodeGenServer.Helpers.CodeHelpers;

namespace CodeGenServer
{
    public class EntityCodeHelper : ICodeHelper
    {
        public string GetCode(string tableName, ORM ORMType, DataTable dtTables, DataTable dtColumns)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.Append(GetORMUsingClause(ORMType));

            sb.AppendLine();
            sb.AppendLine("namespace CodeGenServer");
            sb.AppendLine("{");
            if (!ORMType.Equals(ORM.None))
                sb.AppendLine("\t[Table(\"" + tableName + "\")]");
            sb.AppendLine("\tpublic class " + tableName);
            sb.AppendLine("\t{");
            sb.AppendLine();
            appendProperty(ref sb, dtColumns, ORMType);
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private void appendProperty(ref StringBuilder sb, DataTable dtColumns, ORM ORMType)
        {
            //TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            foreach (DataRow dr in dtColumns.Rows)
            {
                string dataType = getDataType(dr["type"].ToString());
                string colName = dr["name"].ToString();
                if (ORMType.Equals(ORM.EntityFramework))
                    sb.AppendLine("\t\t[Column(\"" + colName + "\")]");
                sb.AppendLine("\t\tpublic " + dataType + " " + colName + " { get; set; }");
                sb.AppendLine();
            }
        }


        private string getDataType(string dataType)
        {
            string retType = String.Empty;
            dataType = dataType.ToLower();
            switch (dataType)
            {
                case "number":
                    retType = "decimal";
                    break;
                case "integer":
                case "int identity":
                    retType = "int";
                    break;
                case "text":
                case "varchar":
                case "varchar2":
                case "nvarchar":
                    retType = "String";
                    break;
                case "date":
                case "datetime":
                    retType = "DateTime";
                    break;
                default:
                    retType = "String";
                    break;
            }
            return retType;
        }


        private string GetORMUsingClause(ORM ORMType)
        {
            StringBuilder sb = new StringBuilder();
            switch (ORMType)
            {
                case ORM.EntityFramework:
                    sb.AppendLine("using System.DataAnnotations.ComponentModel;");
                    sb.AppendLine("using System.DataAnnotations.ComponentModel.Schema;");
                    break;
                    case ORM.Dapper:
                      sb.AppendLine("using Dapper;");
                    break;
            }
            return sb.ToString();
        }
    }
  
}