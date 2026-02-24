public delegate bool IsEligibleforScholarship(Student std);

public class Student
{
    public int RollNo { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
    public char SportsGrade { get; set; }

    public static string GetEligibileStudents(List<Student> studentsList, IsEligibleforScholarship isEligible)
    {
        
    }
}
