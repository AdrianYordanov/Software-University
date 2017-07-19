// ReSharper disable once CheckNamespace

public class Citizen : IPerson, IIdentifiable, IBirthable
{
    private int age;
    private string birthdate;
    private string id;
    private string name;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    // ReSharper disable once ConvertToAutoProperty
    public string Birthdate
    {
        get => this.birthdate;
        private set => this.birthdate = value;
    }

    // ReSharper disable once ConvertToAutoProperty
    public string Id
    {
        get => this.id;
        private set => this.id = value;
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