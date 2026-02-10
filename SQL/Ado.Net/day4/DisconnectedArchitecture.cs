using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

class DisconnectedArchitecture
{
    string connectionString = "Server=localhost\\SQLEXPRESS;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;";
    public void execute()
    {
        DataSet ds = new DataSet();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("sp_GetStudents", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            // Fill
            da.Fill(ds, "Students");

            DataTable dt = ds.Tables["Students"];

            // CREATE
            DataRow newRow = dt.NewRow();
            newRow["Name"] = "Arun";
            newRow["Department"] = "IT";
            dt.Rows.Add(newRow);

            // UPDATE
            dt.Rows[0]["Department"] = "CSE";

            // DELETE
            if (dt.Rows.Count > 1)
                dt.Rows[1].Delete();

            // 🔑 UPDATE MUST BE HERE
            da.Update(dt);
        }

        Console.WriteLine("CRUD operations completed successfully");
    }

}
