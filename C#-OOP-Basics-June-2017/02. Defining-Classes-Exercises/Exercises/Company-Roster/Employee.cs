class Employee
{
    public string name;
    public decimal salary;
    public string position;
    public string department;
    public string email;
    public int age;

    public Employee(string name, decimal salary, string position, string department, string email, int age)
    {
        this.name = name;
        this.salary = salary;
        this.position = position;
        this.department = department;
        this.email = email;
        this.age = age;
    }

    public Employee(string name, decimal salary, string position, string department, string email)
        : this(name, salary, position, department, email, -1)
    { }

    public Employee(string name, decimal salary, string position, string department, int age)
        : this(name, salary, position, department, "n/a", age)
    { }

    public Employee(string name, decimal salary, string position, string department)
       : this(name, salary, position, department, "n/a", -1)
    { }

    public override string ToString()
    {
        return $"{this.name} {this.salary:F2} {this.email} {this.age}";
    }
}
