using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticalInterview.Singleton
{
    public sealed class DatabaseConnectionSingleton
    {
        // Private constructor to prevent external instantiation
        private DatabaseConnectionSingleton()
        {
            Console.WriteLine("Database Connection Initialized.");
        }

        // Singleton instance and lock object for thread safety
        private static DatabaseConnectionSingleton instance;
        private static readonly object lockObject = new object();


        // Public static property to access the singleton instance
        public static DatabaseConnectionSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new DatabaseConnectionSingleton();
                        }
                    }
                }
                return instance;
            }
        }


        // Example method to simulate database query execution
        public void ExecuteQuery(string query)
        {
            Console.WriteLine($"Executing Query: {query}");
        }

    }
}
