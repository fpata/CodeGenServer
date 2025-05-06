using CodeGenServer.Helpers.CodeHelpers;
using CodeGenServer;

namespace CodeGenServer.Helpers.DBHelpers
{
    public class DBFactory
    {
        public static IDBHelper GetDBInstance(string connectStr, DBType dbType)
        {
            IDBHelper dbHelper = null;
            switch (dbType)
            {
                case DBType.Sqlite:
                    dbHelper = new CodeGenServer.DBHelpers.SQLiteHelper(connectStr);
                    break;
                case DBType.SqlServer:
                    dbHelper = new CodeGenServer.DBHelpers.SQLServerHelper(connectStr);
                    break;
            }
            return dbHelper;

        }


        public static ICodeHelper GetCodeHelper(CodeType codeType)
        {
            ICodeHelper codeHelper = null;
            switch (codeType)
            {
                case CodeType.CSharpEntity:
                        codeHelper = new EntityCodeHelper();
                    break;
                case CodeType.CSharpEFMapping:
                    codeHelper = new EFMappingCodeHelper();
                    break;  
                case CodeType.CSharpDAL:
                    codeHelper = new DALCodeHelper();
                    break;
                case CodeType.CSharpDBContext:
                    codeHelper = new DBContextHelper();
                    break;
                case CodeType.TypeScript:
                    codeHelper = new TypScriptCodeHelper();
                    break;
                case CodeType.HTML:
                    codeHelper = new PlainHtmlCodeHelper();
                    break;
                case CodeType.HTMLBootStrap:
                    codeHelper = new BootStrapHtmlCodeHelper();
                    break;
                case CodeType.HTMLMaterial:
                    codeHelper = new MaterialHtmlCodeHelper();
                    break;
                    default:
                    codeHelper = new EntityCodeHelper();
                    break;
            }
            return codeHelper;
        }
    }

  
}
