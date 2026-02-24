class Recursion
{
    public static int Factorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * Factorial(n - 1);
    }

    public static int Fibonacci(int n)
    {
        if (n <= 1)
            return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

    public static int Sum(int n)
    {
        if (n == 0)
            return 0;
        return n + Sum(n - 1);
    }

    public static int Power(int baseNum, int exp)
    {
        if (exp == 0)
            return 1;
        return baseNum * Power(baseNum, exp - 1);
    }

}