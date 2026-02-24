using System.Collections;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Ayush", Height = 160.5f, AttendancePercentage = 95.0f },
            new Student { Id = 2, Name = "Tanishqa", Height = null, AttendancePercentage = 85.0f },
            new Student { Id = 3, Name = "Vipul", Height = 170.2f, AttendancePercentage = 60.0f },
            new Student { Id = 4, Name = "Pratish", Height = null, AttendancePercentage = 80.0f },
            new Student { Id = 5, Name = "Palak", Height = 165.0f, AttendancePercentage = 65.6f }
        };

        int count = 0;
        ArrayList studentArrayList = new ArrayList(students);

        foreach (Student student in studentArrayList)
        {
            string heightInfo = "";
            if (student.Height.HasValue)
            {
                heightInfo = (student.Height.Value).ToString("F1") + " cm";
            }
            else
            {
                heightInfo = "Height Not Available";
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < student.Name.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sb.Append(student.Name[i]);
                }
            }

            if (student.AttendancePercentage > 75.5)
            {
                Console.WriteLine("Id: " + student.Id + ", Name: " + sb.ToString() + ", Height: " + heightInfo + ", Attendance: " + student.AttendancePercentage + "%");
                count++;
            }
            else
            {
                Console.WriteLine("Id: " + student.Id + ", Name: " + sb.ToString() + ", Height: " + heightInfo);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Total students whose attendance were displayed: " +count);
    }
}