using System;
using System.Data;
using Microsoft.Data.SqlClient;

string connectionString =
"Server=localhost\\SQLEXPRESS;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;";

using SqlConnection conn = new SqlConnection(connectionString);

try
{
    conn.Open();
    Console.WriteLine("Connection successful");

    using (SqlCommand cmd = new SqlCommand("SP_GetStudentDetails", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            Console.WriteLine("\nReading Data from Stored procedure...");
            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} {reader[1]}");
            }
        }
    }
}
catch (SqlException ex)
{
    Console.WriteLine("Error: " + ex.Message);
}
