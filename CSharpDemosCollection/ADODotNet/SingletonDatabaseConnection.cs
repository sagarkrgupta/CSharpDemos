using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace ADODotNet
{
    internal class SingletonDatabaseConnection
    {
        // The static instance of the class, which is shared across the entire application
        private static SingletonDatabaseConnection _instance = null;

        // A lock object for ensuring thread safety
        private static readonly object _lock = new object();

        // The SqlConnection object which represents the database connection
        private SqlConnection _connection;

        // Private constructor to prevent external instantiation
        private SingletonDatabaseConnection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        // Public static method to get the instance of DatabaseConnection
        public static SingletonDatabaseConnection GetInstance(string connectionString)
        {
            lock (_lock)
            {
                // If the instance is null, create a new instance
                if (_instance == null)
                {
                    _instance = new SingletonDatabaseConnection(connectionString);
                }
            }
            return _instance;
        }

        // Method to get the SqlConnection object
        public SqlConnection GetConnection()
        {
            return _connection;
        }

        // Method to open the connection (if not already open)
        public void OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
        }
        // Method to close the connection (if it is open)
        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

    }
}
