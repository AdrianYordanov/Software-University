public class Pokemon
{
    public Pokemon(string name, string type)
    {
        this.Name = name;
        this.Type = type;
    }

    private string Name { get; }

    private string Type { get; }

    public override string ToString()
    {
        return $"{this.Name} {this.Type}";
    }
}