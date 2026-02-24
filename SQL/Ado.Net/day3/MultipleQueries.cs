using System;
using System.Data;
using Microsoft.Data.SqlClient;

class MultipleQueries
{
    public void ExecuteQueries()
    {
        string connectionString =
            "Server=localhost\\SQLEXPRESS;Database=demo;Trusted_Connection=True;TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand countCmd = new SqlCommand(
                "SELECT COUNT(StudentId) FROM Hostel WHERE StudentId IS NOT NULL",
                connection
            );

            int hostelStudents = (int)countCmd.ExecuteScalar();
            Console.WriteLine($"Total hostel students: {hostelStudents}");


            if (hostelStudents > 5)
            {
                SqlCommand deleteCmd = new SqlCommand(
                    "DELETE FROM Hostel WHERE RoomNo = @RoomNo",
                    connection
                );

                deleteCmd.Parameters.Add("@RoomNo", SqlDbType.Int).Value = 19;

                int rowsDeleted = deleteCmd.ExecuteNonQuery();
                Console.WriteLine($"{rowsDeleted} record(s) deleted");
            }
            else
            {
                SqlCommand selectCmd = new SqlCommand(
                    "SELECT Id, RoomNo, StudentId FROM Hostel",
                    connection
                );

                using (SqlDataReader reader = selectCmd.ExecuteReader())
                {
                    Console.WriteLine("Id\tRoomNo\tStudentId");
                    while (reader.Read())
                    {
                        Console.WriteLine(
                            $"{reader["Id"]}\t{reader["RoomNo"]}\t{reader["StudentId"]}"
                        );
                    }
                }
            }
        }
    }
}
