class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        // Query syntax
        var evenNumbers = from n in numbers where n % 2 == 0 select n;

        Console.WriteLine("Query Syntax output");
        foreach (var n in evenNumbers)
        {
            Console.Write(n + " ");
        }

        Console.WriteLine("\nMethod Syntax output");

        evenNumbers = numbers.Where(n => n % 2 == 0);

        foreach (var n in evenNumbers)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();

        // Find the max number
        int maxNumber = numbers.Max();
        Console.WriteLine($"Max number: {maxNumber}");

        List<int> numbers = new List<int> { 10, 25, 30, 45, 60 };
        var result = numbers.Where(n => n > 30);
        Console.WriteLine("Numbers greater than 30:");
        foreach (var n in result)
        {
            Console.WriteLine(n);
        }

    }
}