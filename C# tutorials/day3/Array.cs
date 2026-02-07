class Array
{
    public static void traverse()
    {
        int[] numbers = { 1, 2, 3, 4 };
        Console.Write("Array elements are: ");
        foreach (int n in numbers)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
    }

    public static void letters()
    {
        string name = "Ayush Raj";
        foreach (char letter in name)
        {
            Console.WriteLine(letter);
        }
    }
}