class Program
{
    public static void main()
    {
        using (ResourceHandler handler = new ResourceHandler())
        {
            // Use the resource
            Console.WriteLine("Using resource...");
        } // Dispose() is called automatically here

        Console.WriteLine("End of Program.");
    }
}