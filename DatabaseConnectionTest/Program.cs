using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Replace these placeholders with your actual SQL Server details
        string connectionString = "Data Source=10.100.80.67;Initial Catalog=minubaas;User ID=minunimi;Password=test;";

        // SQL query to insert a record into the 'YourTableName' table
        string insertQuery = "INSERT INTO Camera (Time, Camera, Priority) VALUES (@Value1, @Value2, @Value3)";

        // Sample data for the new record
        string value1 = "1234";
        string value2 = "Test3";
        string value3 = "1";

        // Create a SqlConnection object and open the connection
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Create a SqlCommand object with the insert query and connection
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                // Add parameters to the query to prevent SQL injection
                command.Parameters.AddWithValue("@Value1", value1);
                command.Parameters.AddWithValue("@Value2", value2);
                command.Parameters.AddWithValue("@Value3", value3);

                try
                {
                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the query was successful
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Record inserted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No records inserted.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        Console.ReadLine(); // Pause to see the output
    }
}
