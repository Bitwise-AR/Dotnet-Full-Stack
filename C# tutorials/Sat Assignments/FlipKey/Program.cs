using System;

class Program
{
    public static string CleanseAndInvert(string input)
    {
        // Rule 1: null or length check
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return string.Empty;

        // Rule 2: only alphabets allowed
        foreach (char c in input)
        {
            if (!char.IsLetter(c))
                return string.Empty;
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        string filtered = "";
        foreach (char c in input)
        {
            if ((int)c % 2 != 0)
                filtered += c;
        }

        // Reverse the string
        char[] arr = filtered.ToCharArray();
        Array.Reverse(arr);

        // Uppercase characters at even index
        for (int i = 0; i < arr.Length; i++)
        {
            if (i % 2 == 0)
                arr[i] = char.ToUpper(arr[i]);
        }

        return new string(arr);
    }

    static void Main()
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();

        string result = CleanseAndInvert(input);

        if (string.IsNullOrEmpty(result))
            Console.WriteLine("Invalid Input");
        else
            Console.WriteLine("The generated key is - " + result);
    }
}
