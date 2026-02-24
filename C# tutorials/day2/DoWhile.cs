using System;
class DoWhile
{
    public static void func()
    {
        int count=1;
        do
        {
            Console.WriteLine($"Current Count:{count}");
            count++;
        }
        while(count<=5);
    }
}