/*
 * Steps:
 * Ensure only one instance of the connection object is created.
 * Provide global access to the instance.
 * Ensure the connection is thread-safe (if needed).
 */
using ADODotNet;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        RunDBConnection();
    }

    private static void RunDBConnection()
    {
        // Example connection string (replace with your own values)
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        // Get the singleton instance of DatabaseConnection
        SingletonDatabaseConnection dbConnection = SingletonDatabaseConnection.GetInstance(connectionString);

        // Open the database connection
        dbConnection.OpenConnection();
        Console.WriteLine("Connection opened successfully!");

        // Example SQL query
        string query = "SELECT * FROM YourTableName";

        // Execute the query and read the results
        using (SqlCommand command = new SqlCommand(query, dbConnection.GetConnection()))
        {
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Assuming the table has columns: Id (int), Name (string)
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    Console.WriteLine($"Id: {id}, Name: {name}");
                }
            }
        }

        // Close the database connection
        dbConnection.CloseConnection();
        Console.WriteLine("Connection closed.");
    }
}