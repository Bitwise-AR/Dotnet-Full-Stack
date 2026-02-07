using System;
using System.Text;

class StringOperations
{
    public static void Run()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Hello");
        sb.Append(" ");
        sb.Append("World");
        Console.WriteLine(sb.ToString());

        StringBuilder sb1 = new StringBuilder("Hello");
        StringBuilder sb2 = new StringBuilder("Hello");
        Console.WriteLine(sb1.Equals(sb2));
        Console.WriteLine(object.ReferenceEquals(sb1, sb2));

        StringBuilder sb3 = sb2;
        Console.WriteLine(sb3.Equals(sb2));
        Console.WriteLine(object.ReferenceEquals(sb3, sb2));

        Console.WriteLine(sb1 == sb2);

        String str1 = "Hello";
        String str2 = "Hello";
        Console.WriteLine(str1 == str2);
        Console.WriteLine(str1.Equals(str2));
    }
}