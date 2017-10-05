using System;
using System.Collections.Generic;
using System.Linq;

public class PopulationCounter
{
    public static void Main()
    {
        var input = string.Empty;
        var countries = new Dictionary<string, Dictionary<string, long>>();
        while ((input = Console.ReadLine()) != "report")
        {
            var tokens = input.Split('|');
            var city = tokens[0];
            var country = tokens[1];
            var cityPopulation = long.Parse(tokens[2]);
            if (countries.ContainsKey(country))
            {
                countries[country]
                    .Add(city, cityPopulation);
            }
            else
            {
                var cities = new Dictionary<string, long>
                {
                    {
                        city, cityPopulation
                    }
                };
                countries.Add(country, cities);
            }
        }

        var orderedCountries = countries.OrderByDescending(pair => pair.Value.Values.Sum())
            .ToDictionary(x => x.Key, x => x.Value);
        foreach (var pair in orderedCountries)
        {
            var country = pair.Key;
            var cities = pair.Value;
            var orderedCities = cities.OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"{country} (total population: {orderedCities.Values.Sum()})");
            foreach (var nestedPair in orderedCities)
            {
                var city = nestedPair.Key;
                var cityPopulation = nestedPair.Value;
                Console.WriteLine($"=>{city}: {cityPopulation}");
            }
        }
    }
}