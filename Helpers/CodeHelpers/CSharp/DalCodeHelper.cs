using System;
using System.Data;
using System.Globalization;
using System.Text;
using CodeGenServer.Helpers.CodeHelpers;

namespace CodeGenServer
{
    public class DALCodeHelper : ICodeHelper
    {
        public string GetCode(string tableName, ORM ormType, DataTable dtTables, DataTable dtColumns)
        {
        
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using Microsoft.EntityFrameworkCore;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine();
            sb.AppendLine("namespace CodeGenServer.DataAccess");
            sb.AppendLine("{");
            sb.AppendLine("\tpublic class " + tableName + "DAL");
            sb.AppendLine("\t{");

            sb.AppendLine();
            sb.AppendLine("\t\tprivate readonly DBGenDbContext DBGenContext;");
            sb.AppendLine();

//GetAll
            sb.AppendLine("\t\tpublic List<" + tableName + "> GetAll" + tableName + "s()");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\treturn DBGenContext." + tableName + "s.ToList();");
            sb.AppendLine("\t\t}");
            sb.AppendLine();

//GetById
            sb.AppendLine("\t\tpublic " + tableName + " Get" + tableName + "(int Id)");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\treturn DBGenContext." + tableName + "s.First(t => t.Id == Id).ToList();");
            sb.AppendLine("\t\t}");
            sb.AppendLine();

//Update
            sb.AppendLine("\t\tpublic void Update" + tableName + "(" + tableName +" "+ tableName.ToLower() +")");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tDBGenContext." + tableName + "s.Update("+tableName.ToLower()+");");
            sb.AppendLine("\t\t\tDBGenContext.SaveChanges();");
            sb.AppendLine("\t\t}");
            sb.AppendLine();

//Add
            sb.AppendLine("\t\tpublic void Add" + tableName + "(" + tableName +" "+ tableName.ToLower() +")");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tDBGenContext." + tableName + "s.Add("+tableName.ToLower()+");");
            sb.AppendLine("\t\t\tDBGenContext.SaveChanges();");
            sb.AppendLine("\t\t}");
            sb.AppendLine();

     
//Delete
            sb.AppendLine("\t\tpublic void Delete" + tableName + "(int Id)");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t\tvar tempObj = new "+tableName+"{Id = Id};");
            sb.AppendLine("\t\t\tDBGenContext."+tableName+"s.Attach(tempObj);");
            sb.AppendLine("\t\t\tDBGenContext.SaveChanges();");
            sb.AppendLine("\t\t}");
            sb.AppendLine();

            sb.AppendLine("\t}");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}