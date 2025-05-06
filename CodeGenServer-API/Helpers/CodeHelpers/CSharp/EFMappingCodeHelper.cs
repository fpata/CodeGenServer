using System;
using System.Data;
using System.Globalization;
using System.Text;
using CodeGenServer.Helpers.CodeHelpers;

namespace CodeGenServer
{
    public class EFMappingCodeHelper : ICodeHelper
    {
        public string GetCode(string tableName, ORM ormType, DataTable? dtTables = null, DataTable? dtColumns = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("namespace CodeGenServer");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic class " + tableName + ": IEntityTypeConfiguration<" + tableName + ">");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\tpublic void Configure(EntityTypeBuilder<"+tableName+"> builder)");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tbuilder.HasKey(k => k.Id");
            foreach (DataRow dr in dtColumns.Rows)
            {
                 sb.AppendLine("\t\t\tbuilder.Property(t => t."+dr["Name"]+").HasColumnName(\""+dr["Name"]+"\");");
            }
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}