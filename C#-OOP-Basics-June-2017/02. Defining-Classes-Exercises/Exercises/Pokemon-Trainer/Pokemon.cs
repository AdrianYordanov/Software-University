public class Pokemon
{
    public Pokemon(string name, string element, int health)
    {
        this.Name = name;
        this.Element = element;
        this.Health = health;
    }

    public string Element { get; }

    public int Health { get; set; }

    // ReSharper disable once UnusedAutoPropertyAccessor.Local
    private string Name { get; }
}