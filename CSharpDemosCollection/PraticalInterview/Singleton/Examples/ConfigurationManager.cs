using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalInterview.Singleton.Examples
{
    //Scenario: Application settings (e.g., database connection strings, API keys, file paths) need to be consistent and accessible globally.
    internal sealed class ConfigurationManager
    {
        private ConfigurationManager()
        {
            // Simulate loading from a config file
            DatabaseConnectionString = "Server=myServer;Database=myDB;User Id=myUser;Password=myPassword;";
            ApiKey = "12345-ABCDE";
        }

        public string DatabaseConnectionString { get; private set; }
        public string ApiKey { get; private set; }


        private static readonly Lazy<ConfigurationManager> _instance =
        new Lazy<ConfigurationManager>(() => new ConfigurationManager());


        public static ConfigurationManager Instance => _instance.Value;
    }

    //var config = ConfigurationManager.Instance;
    //Console.WriteLine(config.DatabaseConnectionString);
}

/*
 * Why Singleton Works Here:
Consistency: Same configuration is accessible across the application.
Thread-Safe: Lazy<T> ensures thread safety.
Resource Efficiency: Configuration is loaded once.

 */