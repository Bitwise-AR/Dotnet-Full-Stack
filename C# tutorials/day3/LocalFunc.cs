class Local
{
    public static void Process()
    {
        string status = "Processing...";

        void PrintMsg()
        {
            Console.WriteLine(status);
        }

        PrintMsg();
    }

    public static void Calculator()
    {
        int Add(int a, int b)
        {
            return a + b;
        }

        int Multiply(int a, int b)
        {
            return a * b;
        }

        Console.WriteLine(Add(2, 3));
        Console.WriteLine(Multiply(2, 3));
    }

    public static void Example()
    {
        int Square(int x)
        {
            return x * x;
        }
        Func<int, int> squareLambda = x => x * x;

        Console.WriteLine("Square of 4 is: " + Square(4));
        Console.WriteLine("Square of 4 using lambda is: " + squareLambda(4));
    }
}
