public class Employee
{
    public Employee(string name, decimal salary, string position, string department, string email = "n/a", int age = -1)
    {
        this.Name = name;
        this.Salary = salary;
        this.Position = position;
        this.Department = department;
        this.Email = email;
        this.Age = age;
    }

    public Employee(string name, decimal salary, string position, string department, int age)
        : this(name, salary, position, department, "n/a", age)
    {
    }

    public decimal Salary { get; }

    public string Department { get; }

    private string Name { get; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    private string Position { get; }

    private string Email { get; }

    private int Age { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Salary:F2} {this.Email} {this.Age}";
    }
}