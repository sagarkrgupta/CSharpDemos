using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalInterview.Singleton.Examples
{
    //Scenario: A logging service must ensure all logs are written to the same file or console without race conditions.
    internal sealed class Logger
    {
        private Logger() { }

        private readonly string logFilePath = "app.log";

        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());



        public static Logger Instance => _instance.Value;

        public void Log(string message)
        {
            using (var writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
   // // Usage Example
    //Logger.Instance.Log("Application started");
    //Logger.Instance.Log("An error occurred");
}
/*
 * Why Singleton Works Here:
Global Access: Easy to log from anywhere in the application.
Thread-Safe: Lazy<T> ensures only one instance writes to the log file.
Consistency: All logs are stored in the same location.
 */
//======================================

/*
 * Best Practices for Singleton in These Scenarios
Avoid Static Classes: Singletons are better for dependency injection and testing.
Ensure Thread Safety: Use Lazy<T> for modern C# code.
Dependency Injection (DI): Register Singleton services in DI containers for better scalability:

Copy code
services.AddSingleton<ConfigurationManager>();
services.AddSingleton<Logger>();
 */


