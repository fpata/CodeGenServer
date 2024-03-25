using CodeGenServer.Helpers.CodeHelpers;

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


        public static ICodeHelper GetCodeHelper(string code, ORM orm)
        {
            ICodeHelper codeHelper = null;
            switch (code)
            {
                case "CSharpEntity":
                    if (orm == ORM.EFFluentMap)
                        codeHelper = new EFMappingCodeHelper();
                    else
                        codeHelper = new EntityCodeHelper();
                    break;
                case "CSharpDAL":
                    codeHelper = new DALCodeHelper();
                    break;
                case "CSharpDBContext":
                    codeHelper = new DBContextHelper();
                    break;
                case "TypeScript":
                    codeHelper = new TypScriptCodeHelper();
                    break;
                case "HTML":
                    switch (orm)
                    {
                        case ORM.None:
                            codeHelper = new PlainHtmlCodeHelper();
                            break;
                        case ORM.BootStrap:
                            codeHelper = new BootStrapHtmlCodeHelper();
                            break;
                        case ORM.Material:
                            codeHelper = new MaterialHtmlCodeHelper();
                            break;
                    }
                    break;
            }
            return codeHelper;

        }
    }

    public enum DBType
    {
        Sqlite,
        Oracle,
        MySQL,
        SqlServer
    }
}
