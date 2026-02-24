class Program
{
    static void Main()
    {
        List<string> names = new List<string> { "Mari", "Shiva", "Arjun", "Daniel" };

        Console.WriteLine(names.Count());
        
        var namesFour = names.Where(name => name.Length > 4);
        foreach (var name in namesFour)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();

        var namesStartingWithA = names.Where(name => name.StartsWith("A"));
        foreach (var name in namesStartingWithA)
        {
            Console.Write(name);
        }
        Console.WriteLine();

        var firstTwoChars = names.Select(name => name.Substring(0, 2));
        foreach (var name in firstTwoChars)
        {
            Console.Write(name + " ");
        }
        Console.WriteLine();
    }
}