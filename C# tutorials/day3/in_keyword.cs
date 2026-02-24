

class Display
{
    public static void Print(in int x)
    {
        Console.WriteLine(x);
    }

    public static void Show(in int number)
    {
        Console.WriteLine(number);

        // number = number + 10;   // Not allowed
    }
}