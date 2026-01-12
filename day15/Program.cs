
class Program
{
    static void Main(string[] args)
    {
        // List<Employee> employees = new List<Employee>
        // {
        //     new Employee { Name = "Amit", Salary = 50000 },
        //     new Employee { Name = "Ravi", Salary = 70000 },
        //     new Employee { Name = "Neha", Salary = 60000 }
        // };
        // var sortedBySalary = employees.OrderBy(e => e.Salary);
        // var sortedByName = employees.OrderBy(e => e.Name);

        List<int> numbers = new List<int> { 28, 63, 49, 56, 20 };
        int first = numbers.First();
        Console.WriteLine(first);
        int result = numbers.First(n => n > 40);
        Console.WriteLine(result);
        int last = numbers.Last();
        Console.WriteLine(last);
        int res = numbers.Last(n => n < 30);
        Console.WriteLine(res);
    }
}