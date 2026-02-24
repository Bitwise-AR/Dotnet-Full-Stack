using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqInnerJoinDemo
{
   class Program
   {
       static void Main(string[] args)
       {
           // Students collection
           List<Student> students = new List<Student>
           {
               new Student { StudentId = 1, StudentName = "Ravi" },
               new Student { StudentId = 2, StudentName = "Anu" },
               new Student { StudentId = 3, StudentName = "Kumar" }
           };

           // Courses collection
           List<Course> courses = new List<Course>
           {
               new Course { StudentId = 1, CourseName = "C#" },
               new Course { StudentId = 1, CourseName = "SQL" },
               new Course { StudentId = 2, CourseName = ".NET" }
           };

           // INNER JOIN using LINQ (Query Syntax)
           var result =
               from s in students
               join c in courses
                   on s.StudentId equals c.StudentId
               select new
               {
                   StudentName = s.StudentName,
                   CourseName = c.CourseName
               };

           // Print result
           Console.WriteLine("\nINNER JOIN RESULT:");

           foreach (var item in result)
           {
               Console.WriteLine($"{item.StudentName} - {item.CourseName}");
           }
       }
   }

   // Student class
   class Student
   {
       public int StudentId { get; set; }
       public string StudentName { get; set; }
   }

   // Course class
   class Course
   {
       public int StudentId { get; set; }
       public string CourseName { get; set; }
   }
}
