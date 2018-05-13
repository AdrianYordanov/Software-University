public class Parent
{
    public Parent(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    private string Name { get; }

    private string Birthdate { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Birthdate}";
    }
}