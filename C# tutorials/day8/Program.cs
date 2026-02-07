using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        //int a = 10;
        //int b = 0;

        //try
        //{
        //    int result = a / b;
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Error occurred: " + e.Message);
        //}

        // FileStream file = null;
        // try
        // {
        //     file = new FileStream("data.txt", FileMode.Open);
        //     // Perform file operations
        //     int data = file.ReadByte();
        //     Console.WriteLine(data);
        //     string content = File.ReadAllText("data.txt");
        //     Console.WriteLine(content);
        // }
        // catch (FileNotFoundException ex)
        // {
        //     Console.WriteLine("File not found: " + ex.Message);
        // }
        // finally
        // {
        //     if (file != null)
        //     {
        //         file.Close(); // Ensures file is always closed
        //         Console.WriteLine("File stream closed in finally block.");
        //     }
        // }


        try
        {
            try
            {
                string data = File.ReadAllText("transactions.txt");
                Console.WriteLine(data);
            }
            catch (IOException ioEx)
            {
                throw new ApplicationException(
                    "Unable to load transaction data",
                    ioEx
                );
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Message: " + ex.Message);
            Console.WriteLine("Root Cause: " + ex.InnerException.Message);
        }
    }
}