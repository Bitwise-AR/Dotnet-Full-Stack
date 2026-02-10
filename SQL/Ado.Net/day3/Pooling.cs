using Microsoft.Data.SqlClient;
using System;
using System.Diagnostics;

class Pooling
{
    public void TestPooling(bool poolingEnabled)
    {
        string cs =
            "Server=localhost\\SQLEXPRESS;" +
            "Database=demo;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;" +
            $"Pooling={poolingEnabled};";

        Stopwatch sw = Stopwatch.StartNew();

        for (int i = 0; i < 100; i++)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                using SqlCommand cmd =
                    new SqlCommand("SELECT COUNT(*) FROM CollegeMaster", conn);
                cmd.ExecuteScalar();
            }
        }

        sw.Stop();
        if (poolingEnabled == true)
        {
            Console.WriteLine($"After Pooling = {sw.ElapsedMilliseconds} ms");
        }
        else
        {
            Console.WriteLine($"Before Pooling = {sw.ElapsedMilliseconds} ms");
        }
    }
}
