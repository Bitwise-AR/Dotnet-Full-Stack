using System;

abstract class EmployeeRecord
{
    public string EmployeeName { get; set; } = string.Empty;
    public double[] WeeklyHours { get; set; } = new double[4];
    public abstract double GetMonthlyPay();
}

class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }
    public double MonthlyBonus { get; set; }
    public override double GetMonthlyPay()
    {
        double totalHours = 0;
        foreach (var hours in WeeklyHours)
        {
            totalHours += hours;
        }
        return (totalHours * HourlyRate) + MonthlyBonus;
    }
}

class ContractEmployee : EmployeeRecord
{
    public double HourlyRate { get; set; }
    public override double GetMonthlyPay()
    {
        double totalHours = 0;
        foreach (var hours in WeeklyHours)
        {
            totalHours += hours;
        }
        return totalHours * HourlyRate;
    }
}