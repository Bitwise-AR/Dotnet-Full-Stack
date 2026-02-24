class Calculator
{
    public static void Divide(int a, int b, out int quotient, out int remainder)
    {
        quotient = a / b;
        remainder = a % b;
    }
}

class Student
{
    public static void GetResult(int marks, out string grade)
    {
        if (marks >= 60)
            grade = "Pass";
        else
            grade = "Fail";
    }
}