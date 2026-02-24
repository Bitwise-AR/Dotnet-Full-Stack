//Question 1: Student Attendance Analyzer

//A college stores attendance data entered by a staff member as a single line:

//101:Present,102:Absent,103:Present,104:,105:Present, ABC:Present,106:Absent

//Requirements

//Write a C# program that:

//Reads the input string.

//Parses each entry safely.

//Stores valid student attendance in a Dictionary<int, bool?>

//Key → Student ID

//Value →

//true = Present

//false = Absent

//null = Missing attendance

//Ignore invalid IDs (like ABC).

//If attendance value is missing (example: 104:), store it as null.

//Use StringBuilder to generate the output report.

//Output Format
//Attendance Report
//-----------------
//101 -> Present
//102 -> Absent
//103 -> Present
//104 -> Not Marked
//105 -> Present
//106 -> Absent

//Total Present: X
//Total Absent: X
//Not Marked: X

class Program
{
    static void Main(string[] args)
    {
        string input = Console.ReadLine();
        var splittedEntries = input.Replace(" ", "").Split(',');

        foreach (var entry in splittedEntries)
        {
            splittedEntries = splittedEntries.Where(e => int.TryParse(e.Split(':')[0], out _)).ToArray();
        }
        
        Dictionary<int, bool?> data = new Dictionary<int, bool?>();
        foreach (var entry in splittedEntries)
        {
            var parts = entry.Split(':');
            int studentId = int.Parse(parts[0]);
            bool? status = null;
            if (parts.Length > 1)
            {
                if (parts[1].Equals("Present"))
                {
                    status = true;
                }
                else if (parts[1].Equals("Absent"))
                {
                    status = false;
                }
            }
            data[studentId] = status;
        }


        Console.WriteLine("Attendance Report");
        Console.WriteLine("-----------------");
        foreach (var d in data)
        {
            string status = d.Value == true ? "Present" : d.Value == false ? "Absent" : "Not Marked";
            Console.WriteLine($"{d.Key} -> {status}");
        }

        int totalPresent = data.Values.Count(v => v == true);
        int totalAbsent = data.Values.Count(v => v == false);
        int notMarked = data.Values.Count(v => v == null);

        Console.WriteLine($"\nTotal Present: {totalPresent}");
        Console.WriteLine($"Total Absent: {totalAbsent}");
        Console.WriteLine($"Not Marked: {notMarked}");
    }
}