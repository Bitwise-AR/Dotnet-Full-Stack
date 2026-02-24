using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    public static void Main(string[] args)
    {
        Task t = new Task();
        t.ExecuteFirst();
        t.ExecuteSecond();
        t.ExecuteThird();
        t.ExecuteFourth();
        t.ExecuteFifth();
    }
}