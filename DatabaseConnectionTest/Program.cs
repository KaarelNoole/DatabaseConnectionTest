using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=10.100.80.67;Initial Catalog=minubaas;User ID=minunimi;Password=test;";

        string insertQuery = "INSERT INTO Camera (Time, Camera, Priority) VALUES (@Value1, @Value2, @Value3)";

        string value1 = "1234";
        string value2 = "Test3";
        string value3 = "1";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Value1", value1);
                command.Parameters.AddWithValue("@Value2", value2);
                command.Parameters.AddWithValue("@Value3", value3);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();

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

        Console.ReadLine();
    }
}
