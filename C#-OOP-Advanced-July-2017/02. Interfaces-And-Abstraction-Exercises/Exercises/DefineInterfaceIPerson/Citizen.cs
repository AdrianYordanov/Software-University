// ReSharper disable once CheckNamespace
public class Citizen : IPerson
{
    private string name;
    private int age;

    public Citizen(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    // ReSharper disable once ConvertToAutoProperty
    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    // ReSharper disable once ConvertToAutoProperty
    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }
}