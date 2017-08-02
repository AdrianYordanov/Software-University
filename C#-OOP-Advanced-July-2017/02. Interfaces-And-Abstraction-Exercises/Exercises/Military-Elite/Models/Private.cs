public class Private : Soldier, IPrivate
{
    private double salary;

    public Private(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName)
    {
        this.Salary = salary;
    }

    public double Salary
    {
        get => this.salary;
        private set => this.salary = value;
    }

    public override string ToString()
    {
        return base.ToString() + $" Salary: {this.Salary:F2}";
    }
}