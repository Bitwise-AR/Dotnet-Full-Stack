using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

class Functions
{
    public void func(int num)
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            Console.WriteLine("Connection successful");

            string query = "SELECT dbo.FnSquare(@num)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@num", 6);
                int square = Convert.ToInt32(cmd.ExecuteScalar());
                Console.WriteLine($"Bonus Amount = {square}");
            }
        }
    }
}

