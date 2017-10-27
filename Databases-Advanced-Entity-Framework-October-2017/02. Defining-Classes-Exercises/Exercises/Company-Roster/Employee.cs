public class Employee
{
    private readonly string name;
    private readonly string department;
    private readonly string email;
    private readonly int age;
    // ReSharper disable once NotAccessedField.Local
    private string position;
    private decimal salary;

    public Employee(string name, decimal salary, string position, string department, string email, int age)
    {
        this.name = name;
        this.Salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
        : this(name, salary, position, department, email, -1)
    {
    }

    public Employee(string name, decimal salary, string position, string department, int age)
        : this(name, salary, position, department, "n/a", age)
    {
    }

    public Employee(string name, decimal salary, string position, string department)
        : this(name, salary, position, department, "n/a", -1)
    {
    }

    public decimal Salary
    {
        get => this.salary;
        private set => this.salary = value;
    }

    public string Department => this.department;

    public override string ToString()
    {
        return $"{this.name} {this.Salary:F2} {this.email} {this.age}";
    }
}