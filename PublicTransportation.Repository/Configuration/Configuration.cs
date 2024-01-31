using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace PublicTransportation.Infra.Configuration
{
    public class Configuration
    {
        public static AppConfiguration config { get; set; }
    }

    public class DatabaseConfig
    {
        public string ConnectionString { get; set; }
    }

    public class AppConfiguration
    {
        public DatabaseConfig databaseConfig { get; set; }

        public static DatabaseConfig GetDatabaseConfig()
        {
            return LoadJson()?.databaseConfig;
        }

        private static AppConfiguration LoadJson()
        {
            if(Configuration.config == null)
            {
                string file;

                file = "appsettings.json";


                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    
                var configPath = Path.Combine(path, file);

                if(!File.Exists(configPath))
                    configPath = Path.Combine("..", "PublicTransportation.Api", file);

                var reader = new JsonTextReader(new StringReader(File.ReadAllText(configPath)));

                var serializer = new JsonSerializer();
                var configuration = serializer.Deserialize<AppConfiguration>(reader);

                if (configuration == null)
                    throw new ArgumentException("Error on load appsettings.json");

                Configuration.config = configuration;
            }

            return Configuration.config;
        }
    }
}
