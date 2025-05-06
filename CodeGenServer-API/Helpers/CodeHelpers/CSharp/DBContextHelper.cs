using System;
using System.Data;
using System.Globalization;
using System.Text;
using CodeGenServer.Helpers.CodeHelpers;

namespace CodeGenServer
{
    public class DBContextHelper : ICodeHelper
    {
        public string GetCode(string tableName, ORM ormType, DataTable? dtTables = null, DataTable? dtColumns = null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine("namespace CodeGenServer.DataAccess");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic class DBGenDbContext:DbContext");
            sb.AppendLine("\t{");
            sb.AppendLine();

            foreach (DataRow dr in dtTables.Rows)
            {
                sb.Append("\t\tinternal DbSet<");
                sb.Append(dr["Table_Name"]);
                sb.Append("> ");
                sb.Append(dr["Table_Name"]);
                sb.Append("s { get; set; }");
                sb.AppendLine();
            }

            sb.AppendLine("\t\tprotected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\toptionsBuilder.UseSqlite(connectStr);");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");


            sb.AppendLine("\t\tprotected override void OnModelCreating(ModelBuilder modelBuilder)");
            sb.AppendLine("\t\t{");
            foreach (DataRow dr in dtTables.Rows)
            {
                sb.AppendLine("\t\t\tmodelBuilder.ApplyConfiguration(new " + dr["Table_Name"] + "Configuration());");
            }
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}