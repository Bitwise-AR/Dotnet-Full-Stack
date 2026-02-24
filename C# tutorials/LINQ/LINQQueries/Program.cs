class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 10, 15, 20, 25, 30, 10, 20 };

        // 1. Where
        Console.WriteLine("1. Where ( > 20):");
        var filtered = numbers.Where(n => n > 20);
        Print(filtered);

        // 2. Select
        Console.WriteLine("\n2. Select ( Square ):");
        var squares = numbers.Select(n => n * n);
        Print(squares);

        // 3. OrderBy
        Console.WriteLine("\n3. OrderBy:");
        var ordered = numbers.OrderBy(n => n);
        Print(ordered);

        // 4. OrderByDescending
        Console.WriteLine("\n4. OrderByDescending:");
        var orderedDesc = numbers.OrderByDescending(n => n);
        Print(orderedDesc);

        // 5. Take
        Console.WriteLine("\n5. Take ( first 3 ):");
        Print(numbers.Take(3));

        // 6. Skip
        Console.WriteLine("\n6. Skip ( first 2 ):");
        Print(numbers.Skip(2));

        // 7. Count
        Console.Write("\n7. Count: ");
        Console.WriteLine(numbers.Count());

        // 8. Sum
        Console.Write("\n8. Sum: ");
        Console.WriteLine(numbers.Sum());

        // 9. Max
        Console.Write("\n9. Max: ");
        Console.WriteLine(numbers.Max());

        // 10. Min
        Console.Write("\n10. Min: ");
        Console.WriteLine(numbers.Min());

        // 11. Average
        Console.Write("\n11. Average: ");
        Console.WriteLine(numbers.Average());

        // 12. FirstOrDefault
        Console.Write("\n12. FirstOrDefault ( > 50 ): ");
        Console.WriteLine(numbers.FirstOrDefault(n => n > 50));

        // 13. Any
        Console.Write("\n13. Any ( > 25 ): ");
        Console.WriteLine(numbers.Any(n => n > 25));

        // 14. Distinct
        Console.WriteLine("\n14. Distinct:");
        Print(numbers.Distinct());
    }

    static void Print(IEnumerable<int> collection)
    {
        foreach (var item in collection)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}