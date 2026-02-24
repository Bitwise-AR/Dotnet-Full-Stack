class Functions
{
    public static List<EmployeeRecord> PayrollBoard = new List<EmployeeRecord>();

    public void RegisterEmployee(EmployeeRecord record)
    {
        PayrollBoard.Add(record);
    }

    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> records, double hoursThreshold)
    {
        Dictionary<string, int> overtimeCounts = new Dictionary<string, int>();

        foreach (var record in records)
        {
            int count = 0;
            foreach (var hours in record.WeeklyHours)
            {
                if (hours >= hoursThreshold)
                {
                    count++;
                }
            }
            if (count > 0)
            {
                overtimeCounts[record.EmployeeName] = count;
            }
        }

        return overtimeCounts;
    }

    public double CalculateAverageMonthlyPay()
    {
        if (PayrollBoard.Count == 0) return 0;

        double totalPay = 0;
        foreach (var record in PayrollBoard)
        {
            totalPay += record.GetMonthlyPay();
        }
        return totalPay / PayrollBoard.Count;
    }
}