public class Citizen : IIdentifiable, IName, IAge, IBirthdate
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

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }

    public string Birthdate
    {
        get => this.birthdate;
        private set => this.birthdate = value;
    }

    public string Id
    {
        get => this.id;
        private set => this.id = value;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }
}