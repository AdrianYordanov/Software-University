using System;
using System.Text;

class Worker : Human
{
    private const int WorkingDays = 5;
    private decimal weekSalary;
    private decimal workingHours;

    public Worker(string firstName, string lastName, decimal weekSalary, decimal workingHours)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkingHours = workingHours;
    }

    public decimal WeekSalary
    {
        get
        {
            return this.weekSalary;
        }
        private set
        {
            if (value <= 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }

            this.weekSalary = value;
        }
    }

    public decimal WorkingHours
    {
        get
        {
            return this.workingHours;
        }
        private set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }

            this.workingHours = value;
        }
    }

    public decimal SalaryPerHour
    {
        get
        {
            return (this.WeekSalary / WorkingDays) / this.WorkingHours;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append(base.ToString());
        sb.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        sb.AppendLine($"Hours per day: {this.WorkingHours:f2}");
        sb.Append($"Salary per hour: {this.SalaryPerHour:f2}");
        return sb.ToString();
    }
}