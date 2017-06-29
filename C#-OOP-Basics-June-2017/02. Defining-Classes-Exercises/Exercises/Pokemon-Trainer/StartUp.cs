using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var input = string.Empty;
        var trainers = new Dictionary<string, Trainer>();

        while ((input = Console.ReadLine()) != "Tournament")
        {
            var tokens = input.Split(' ');
            var trainerName = tokens[0];
            var pokemonName = tokens[1];
            var pokemonElement = tokens[2];
            var pokemonHealth = int.Parse(tokens[3]);
            var createdPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

            if (!trainers.ContainsKey(trainerName))
            {
                trainers.Add(trainerName, new Trainer(trainerName));
            }

            trainers[trainerName].AddPokemon(createdPokemon);
        }

        while ((input = Console.ReadLine()) != "End")
        {
            foreach (var trainer in trainers.Values)
            {
                trainer.TryToAddBadge(input);
            }
        }

        var result = trainers.Values
            .OrderByDescending(trainer => trainer.Badges);

        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}