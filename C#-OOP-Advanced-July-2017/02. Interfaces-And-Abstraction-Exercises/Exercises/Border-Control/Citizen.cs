public class Citizen : IIdentifiable, ICitizen
{
    private int age;
    private string id;
    private string name;

    public Citizen(string name, int age, string id)
    {
        this.Name = name;
        this.Age = age;
        this.Id = id;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }

    public string Id
    {
        get => this.id;
        private set => this.id = value;
    }
}