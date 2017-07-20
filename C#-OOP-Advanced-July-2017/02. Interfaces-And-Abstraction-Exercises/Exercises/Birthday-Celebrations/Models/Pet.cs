public class Pet : IName, IBirthdate
{
    private string birthdate;
    private string name;

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Birthdate
    {
        get => this.birthdate;
        private set => this.birthdate = value;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }
}