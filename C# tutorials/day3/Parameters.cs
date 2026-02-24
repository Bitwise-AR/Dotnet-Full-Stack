class Parameters
{
    public static int Add(int a, int b)
    {
       return  (a + b);
    }
    public static int Add(int a, int b, int c)
    {
        return (a + b + c);
    }
    public static double Add(double a, double b)
    {
        return (a + b);
    }

    public static void Person(string name, int age, string city, char gender = 'M')
    {
        Console.WriteLine("Name: " + name + ", Age: " + age + ", Gender: " + gender + ", City: " + city);
    }
}