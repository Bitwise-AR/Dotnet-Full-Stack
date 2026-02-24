using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

class Datatable
{
    string connectionString = "Server=localhost\\SQLEXPRESS;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;";
    public void execute()
    {
        DataTable dt = new DataTable("Student");
        DataSet ds = new DataSet();

        dt.Columns.Add("Id", typeof(int));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Department", typeof(string));

        dt.Rows.Add(1, "Mahima", "IT");
        dt.Rows.Add(2, "Marimuthu", "MCA");
        dt.Rows.Add(2, "Ritik", "ECE");

        Console.WriteLine("\nStudent Details");
        foreach (DataRow row in dt.Rows)
        {
            Console.WriteLine($"{row["Id"]} - {row["Name"]} - {row["Department"]}");
        }

        ds.Tables.Add(dt);
        Console.WriteLine(ds.Tables.Count);
        Console.ReadLine();
    }

}
