public class Rebel : IName, IAge, IBuyer
{
    private int age;
    private string name;
    private string group;
    private int food;

    public Rebel(string name, int age, string group)
    {
        this.Name = name;
        this.Age = age;
        this.Group = group;
        this.Food = 0;
    }

    public string Group
    {
        get => this.group;
        private set => this.group = value;
    }

    public int Age
    {
        get => this.age;
        private set => this.age = value;
    }

    public int Food
    {
        get => this.food;
        private set => this.food = value;
    }

    public string Name
    {
        get => this.name;
        private set => this.name = value;
    }

    public void BuyFood()
    {
        this.Food += 5;
    }
}