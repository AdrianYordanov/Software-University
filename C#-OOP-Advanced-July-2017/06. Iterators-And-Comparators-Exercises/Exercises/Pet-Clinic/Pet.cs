public class Pet
{
    private string name;
    private int age;
    private string kind;

    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
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

    public string Kind
    {
        get => this.kind;
        private set => this.kind = value;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}