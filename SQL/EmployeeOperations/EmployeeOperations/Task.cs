using System;
using System.Data;
using Microsoft.Data.SqlClient;

public class Task
{
    private const string connectionString =
        "Server=localhost\\SQLEXPRESS;Database=MVC_With_ADO;Trusted_Connection=True;TrustServerCertificate=True;";

    private SqlConnection GetConnection()
    {
        return new SqlConnection(connectionString);
    }

    private void ExecuteReaderProcedure(string procedureName, Action<SqlCommand> parameterize = null)
    {
        using SqlConnection conn = GetConnection();
        using SqlCommand cmd = new SqlCommand(procedureName, conn);

        conn.Open();
        cmd.CommandType = CommandType.StoredProcedure;

        parameterize?.Invoke(cmd);

        using SqlDataReader reader = cmd.ExecuteReader();
        PrintReaderData(reader);
    }

    private int ExecuteOutputProcedure(string procedureName, string department)
    {
        using SqlConnection conn = GetConnection();
        using SqlCommand cmd = new SqlCommand(procedureName, conn);

        conn.Open();
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Department", department);
        cmd.Parameters.Add("@TotalEmployees", SqlDbType.Int).Direction = ParameterDirection.Output;

        cmd.ExecuteNonQuery();

        return (int)cmd.Parameters["@TotalEmployees"].Value;
    }

    private void PrintReaderData(SqlDataReader reader)
    {
        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write($"{reader.GetName(i)}: {reader[i]}");
                if (i < reader.FieldCount - 1)
                    Console.Write(", ");
            }
            Console.WriteLine();
        }
    }

    // ---- EXECUTIONS ----

    public void ExecuteFirst()
    {
        Console.WriteLine("\nEmployees in IT Department:");
        ExecuteReaderProcedure("sp_GetEmployeesByDepartment",
            cmd => cmd.Parameters.AddWithValue("@Department", "IT"));
    }

    public void ExecuteSecond()
    {
        int total = ExecuteOutputProcedure("sp_GetDepartmentEmployeeCount", "IT");
        Console.WriteLine($"\nTotal Employees in IT Department: {total}");
    }

    public void ExecuteThird()
    {
        Console.WriteLine("\nOrder Details:");
        ExecuteReaderProcedure("sp_GetEmployeeOrders");
    }

    public void ExecuteFourth()
    {
        Console.WriteLine("\nDuplicate Employees:");
        ExecuteReaderProcedure("sp_GetDuplicateEmployees");
    }

    public void ExecuteFifth()
    {
        Console.Write("\nEnter Department Name: ");
        string deptName = Console.ReadLine();

        Console.WriteLine($"\nEmployees in {deptName} Department:");
        ExecuteReaderProcedure("sp_GetEmployeesByDepartment",
            cmd => cmd.Parameters.AddWithValue("@Department", deptName));

        int total = ExecuteOutputProcedure("sp_GetDepartmentEmployeeCount", deptName);
        Console.WriteLine($"\nTotal Employees in {deptName} Department: {total}");

        Console.WriteLine("\nEmployee Order Report:");
        ExecuteReaderProcedure("sp_GetEmployeeOrders");

        Console.WriteLine("\nDuplicate Employees:");
        ExecuteReaderProcedure("sp_GetDuplicateEmployees");
    }
}