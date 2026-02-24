public class InputHelper
{
    public int ReadAge(string input)
    {
        if (!int.TryParse(input, out int age))
        {
            throw new ArgumentException("Invalid age input");
        }
        return age;
    }
}