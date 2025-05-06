using Microsoft.Extensions.Configuration;
using System.IO;

namespace CodeGenServer
{
    public static class ConfigSettings
    {
        public static string connectionString { get; }
        static ConfigSettings()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);
            connectionString = configurationBuilder.Build().GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
