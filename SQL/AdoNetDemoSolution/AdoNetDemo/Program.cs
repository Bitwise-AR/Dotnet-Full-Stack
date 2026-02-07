using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;";

        string query = "SELECT Id, Name FROM CollegeMaster";

        try
        {
            using SqlConnection conn = new SqlConnection(connectionString);
            using SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            Console.WriteLine("Connection successful");

            using SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Id"]} {reader["Name"]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
