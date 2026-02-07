using System;
using System.Collections.Generic;

public class Student
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Course { get; set; }
    public int Marks { get; set; }
}

public class StudentUtility
{
    public Dictionary<string, string> GetStudentDetails(string id)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();

        foreach (var entry in Program.studentDetails.Values)
        {
            if (entry.Id == id)
            {
                result.Add(entry.Id, entry.Name + "_" + entry.Course);
                break;
            }
        }

        return result;
    }

    public Dictionary<string, Student> UpdateStudentMarks(string id, int marks)
    {
        Dictionary<string, Student> result = new Dictionary<string, Student>();

        foreach (var entry in Program.studentDetails.Values)
        {
            if (entry.Id == id)
            {
                entry.Marks = marks;
                result.Add(entry.Id, entry);
                break;
            }
        }

        return result;
    }
}

public class Program
{
    public static Dictionary<int, Student> studentDetails;

    public static void Main()
    {
        studentDetails = new Dictionary<int, Student>();

        studentDetails.Add(1, new Student { Id = "ST01", Name = "Ayush", Course = "DataScience", Marks = 85 });
        studentDetails.Add(2, new Student { Id = "ST02", Name = "Aman", Course = "Java", Marks = 78 });
        studentDetails.Add(3, new Student { Id = "ST03", Name = "Ankush", Course = "DotNet", Marks = 90 });

        StudentUtility utility = new StudentUtility();
        bool run = true;

        while (run)
        {
            Console.WriteLine("1. Get Student Details");
            Console.WriteLine("2. Update Marks");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter student id");
                    string id = Console.ReadLine();

                    var details = utility.GetStudentDetails(id);

                    if (details.Count == 0)
                    {
                        Console.WriteLine("Student id not found");
                    }
                    else
                    {
                        foreach (var item in details)
                        {
                            Console.WriteLine(item.Key + "   " + item.Value);
                        }
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter student id");
                    string updateId = Console.ReadLine();

                    Console.WriteLine("Enter marks");
                    int marks = int.Parse(Console.ReadLine());

                    var updated = utility.UpdateStudentMarks(updateId, marks);

                    if (updated.Count == 0)
                    {
                        Console.WriteLine("Student id not found");
                    }
                    else
                    {
                        foreach (var item in updated)
                        {
                            Console.WriteLine(item.Key + "   " + item.Value.Marks);
                        }
                    }
                    break;

                case 3:
                    Console.WriteLine("Exiting the program...");
                    run = false;
                    break;
            }
        }
    }
}
