using System.Collections.Generic;

public class Person
{
    public Person(string name)
    {
        this.Name = name;
        this.Company = null;
        this.Car = null;
        this.Parents = new List<Parent>();
        this.Children = new List<Child>();
        this.Pokemons = new List<Pokemon>();
    }

    public string Name { get; }

    public Company Company { private get; set; }

    public Car Car { private get; set; }

    public List<Parent> Parents { get; }

    public List<Child> Children { get; }

    public List<Pokemon> Pokemons { get; }

    public override string ToString()
    {
        var result = string.Empty;
        result += $"{this.Name}\n";
        result += $"Company:\n";
        result += this.Company == null ? string.Empty : this.Company + "\n";
        result += $"Car:\n";
        result += this.Car == null ? string.Empty : this.Car + "\n";
        result += $"Pokemon:\n";
        result += this.Pokemons.Count == 0 ? string.Empty : string.Join("\n", this.Pokemons) + "\n";
        result += $"Parents:\n";
        result += this.Parents.Count == 0 ? string.Empty : string.Join("\n", this.Parents) + "\n";
        result += $"Children:";
        result += this.Children.Count == 0 ? string.Empty : "\n" + string.Join("\n", this.Children);
        return result;
    }
}