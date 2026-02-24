class Program
{
    public static void Main()
    {
        // Instantiate the generic class with an integer type
        Box<int> intBox = new Box<int>(10);
        Console.WriteLine($"Integer box content: {intBox.GetContent()}"); // Output: 10

        // Instantiate the generic class with a string type
        Box<string> stringBox = new Box<string>("Hello Generics");
        Console.WriteLine($"String box content: {stringBox.GetContent()}"); // Output: Hello Generics
    }
}