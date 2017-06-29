using System.Collections.Generic;
using System.Linq;

class Trainer
{
    private string name;
    private int badges;
    private List<Pokemon> pokemons;

    public Trainer(string name)
    {
        this.name = name;
        this.badges = 0;
        this.pokemons = new List<Pokemon>();
    }

    public int Badges
    {
        get
        {
            return this.badges;
        }
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void TryToAddBadge(string element)
    {
        var countWithElement = this.pokemons
            .Where(pokemon => pokemon.Element == element)
            .Count();

        if (countWithElement > 0)
        {
            this.badges++;
        }
        else
        {
            this.pokemons.ForEach(pokemon => pokemon.Health -= 10);
            this.pokemons = this.pokemons
                .Where(pokemon => pokemon.Health > 0)
                .ToList();
        }
    }

    public override string ToString()
    {
        return $"{this.name} {this.Badges} {this.pokemons.Count}";
    }
}