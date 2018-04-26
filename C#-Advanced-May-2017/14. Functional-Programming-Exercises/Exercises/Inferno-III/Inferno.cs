using System;
using System.Collections.Generic;
using System.Linq;

public class Inferno
{
    private static readonly Func<string, int, int[], List<int>> GetExcludedIndices =
        (chosenFilter, wantedSum, numbers) =>
            {
                var excluded = new List<int>();
                for (var i = 0; i < numbers.Length; i++)
                {
                    var sum = 0;
                    var current = numbers[i];
                    var leftNeighbour = i == 0 ? 0 : numbers[i - 1];
                    var rightNeighbour = i == numbers.Length - 1 ? 0 : numbers[i + 1];
                    switch (chosenFilter)
                    {
                        case "Sum Left":
                            sum = leftNeighbour + current;
                            break;
                        case "Sum Right":
                            sum = rightNeighbour + current;
                            break;
                        case "Sum Left Right":
                            sum = leftNeighbour + rightNeighbour + current;
                            break;
                    }

                    if (sum == wantedSum)
                    {
                        excluded.Add(i);
                    }
                }

                return excluded;
            };

    private static void Main()
    {
        var originalNumbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var history = new Dictionary<string, List<int>>();
        string line;
        while ((line = Console.ReadLine()) != "Forge")
        {
            var tokens = line.Split(';');
            var command = tokens[0];
            var filter = tokens[1];
            var parameter = int.Parse(tokens[2]);
            if (command == "Exclude")
            {
                var excludedForThisCommand = GetExcludedIndices(filter, parameter, originalNumbers);
                history.Add($"{filter}:{parameter}", excludedForThisCommand);
            }
            else
            {
                var previousFilter = $"{filter}:{parameter}";
                if (history.ContainsKey(previousFilter))
                {
                    history.Remove(previousFilter);
                }
            }
        }

        var excludedIndices = new List<int>();
        foreach (var indices in history.Values)
        {
            excludedIndices.AddRange(indices);
        }

        var result = originalNumbers.ToList()
            .Where((number, index) => !excludedIndices.Distinct().Contains(index))
            .ToList();
        Console.WriteLine(string.Join(" ", result));
    }
}