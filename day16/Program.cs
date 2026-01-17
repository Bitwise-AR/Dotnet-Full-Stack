using System;
using System.Threading;
using System.Diagnostics;

class Program
{
    static void DoWork()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(500); // Simulate work
        }
    }

    static void Main()
    {
        // Process currentProcess = Process.GetCurrentProcess();
        // Console.WriteLine("Current Process ID: " + currentProcess.Id);
        // Console.WriteLine("Process Name: " + currentProcess.ProcessName);

        Process.Start("notepad.exe");

        // Create a new thread
        Thread worker = new Thread(DoWork);

        // Start the thread
        worker.Start();

        Console.WriteLine("Main thread continues...");

        // Optional: Wait for worker thread to finish
        worker.Join();
        Console.WriteLine("Main thread finished");
    }
}