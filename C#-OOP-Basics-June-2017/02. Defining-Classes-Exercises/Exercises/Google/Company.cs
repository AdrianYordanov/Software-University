public class Company
{
    public Company(string name, string department, decimal salary)
    {
        this.Name = name;
        this.Department = department;
        this.Salary = salary;
    }

    private string Name { get; }

    private string Department { get; }

    private decimal Salary { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Department} {this.Salary:F2}";
    }
}