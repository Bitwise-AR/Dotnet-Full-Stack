using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

class Dataset
{
    public void implement()
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;";

        DataSet ds = new DataSet();
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Connection Successful");

            using (SqlCommand command = new SqlCommand("sp_GetStudents", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(ds, "Students");
            }
        }

        Console.WriteLine("\nStudent Details");

    }
}
