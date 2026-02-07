using System;

class ResourceHandler : IDisposable
{
    public ResourceHandler()
    {
        // Acquire resource
        Console.WriteLine("Resource acquired.");
    }

    public void Dispose()
    {
        // Release resource
        Console.WriteLine("Resource released.");
    }
}