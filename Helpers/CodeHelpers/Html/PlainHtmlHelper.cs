using System;
using System.Data;
using System.Globalization;
using System.Text;
using CodeGenServer.Helpers.CodeHelpers;

namespace CodeGenServer
{
    public class PlainHtmlCodeHelper : ICodeHelper
    {
        public string GetCode(string tableName, ORM ORMType, DataTable dtTables, DataTable dtColumns)
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }

    }
}