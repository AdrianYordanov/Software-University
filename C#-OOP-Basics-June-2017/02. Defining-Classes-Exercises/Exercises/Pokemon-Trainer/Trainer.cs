using System.Collections.Generic;
using System.Linq;

public class Trainer
{
    public Trainer(string name)
    {
        this.Name = name;
        this.Pokemons = new List<Pokemon>();
        this.Badges = 0;
    }

    public int Badges { get; private set; }

    private string Name { get; }

    private List<Pokemon> Pokemons { get; set; }

    public void AddPokemon(Pokemon pokemon)
    {
        this.Pokemons.Add(pokemon);
    }

    public void TryToAddBadge(string element)
    {
        var countWithElement = this.Pokemons.Count(pokemon => pokemon.Element == element);
        if (countWithElement > 0)
        {
            this.Badges++;
        }
        else
        {
            this.Pokemons.ForEach(pokemon => pokemon.Health -= 10);
            this.Pokemons = this.Pokemons.Where(pokemon => pokemon.Health > 0).ToList();
        }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Badges} {this.Pokemons.Count}";
    }
}