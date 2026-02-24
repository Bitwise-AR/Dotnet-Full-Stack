class Program
{
    public static void Main(string[] args)
    {
        Functions functions = new Functions();
        bool running = true;

        while (running)
        {
            Console.WriteLine("1. Register Employee");
            Console.WriteLine("2. Show Overtime Summary");
            Console.WriteLine("3. Calculate Average Monthly Pay");
            Console.WriteLine("4. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice:\n");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    Console.Write("Select Employee Type (1-Full Time, 2-Contract):\n");
                    int empType = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("Enter Employee Name:\n");
                    string name = Console.ReadLine();
                    Console.WriteLine();
                    Console.Write("Enter Hourly Rate:\n");
                    double hourlyRate = double.Parse(Console.ReadLine());

                    if (empType == 1)
                    {
                        Console.WriteLine();
                        Console.Write("Enter Monthly Bonus:\n");
                        double monthlyBonus = double.Parse(Console.ReadLine());
                        Console.WriteLine();
                        Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                        double[] weeklyHours = new double[4];
                        for (int i = 0; i < 4; i++)
                        {
                            weeklyHours[i] = double.Parse(Console.ReadLine());
                        }
                        FullTimeEmployee fte = new FullTimeEmployee
                        {
                            EmployeeName = name,
                            WeeklyHours = weeklyHours,
                            HourlyRate = hourlyRate,
                            MonthlyBonus = monthlyBonus
                        };
                        functions.RegisterEmployee(fte);
                    }
                    else if (empType == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Enter weekly hours (Week 1 to 4):");
                        double[] weeklyHours = new double[4];
                        for (int i = 0; i < 4; i++)
                        {
                            weeklyHours[i] = double.Parse(Console.ReadLine());
                        }
                        ContractEmployee ce = new ContractEmployee
                        {
                            EmployeeName = name,
                            WeeklyHours = weeklyHours,
                            HourlyRate = hourlyRate
                        };
                        functions.RegisterEmployee(ce);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Employee registered successfully");
                    break;

                case 2:
                    Console.Write("Enter hours threshold: ");
                    double threshold = double.Parse(Console.ReadLine());
                    var overtimeCounts = functions.GetOvertimeWeekCounts(Functions.PayrollBoard, threshold);
                    if (overtimeCounts.Count == 0)
                    {
                        Console.WriteLine("No overtime recorded this month");
                    }
                    else
                    {
                        foreach (var entry in overtimeCounts)
                        {
                            Console.WriteLine($"{entry.Key} - {entry.Value}");
                        }
                    }
                    break;

                case 3:
                    double averagePay = functions.CalculateAverageMonthlyPay();
                    Console.WriteLine($"Overall average monthly pay: {averagePay}");
                    break;
                case 4:
                    Console.WriteLine("Logging off — Payroll processed successfully!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}