using System;
using System.Collections.Generic;
using System.Linq;

class LongestIncreasingSubsequence
{
    static void Main()
    {
        var numbers = Console
            .ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToList();

        var lengths = new int[numbers.Count];
        var previous = new int[numbers.Count];

        for (int i = 0; i < numbers.Count; i++)
        {
            lengths[i] = 1;
            previous[i] = -1;
            var bestLength = -1;
            var bestLengthIndex = -1;

            for (int iteratorToLeftmost = i - 1; iteratorToLeftmost >= 0; iteratorToLeftmost--)
            {
                if (numbers.ElementAt(iteratorToLeftmost) < numbers.ElementAt(i) &&
                    bestLength <= lengths[iteratorToLeftmost])
                {
                    bestLength = lengths[iteratorToLeftmost];
                    bestLengthIndex = iteratorToLeftmost;
                }
            }

            if (bestLength > -1)
            {
                lengths[i] += bestLength;
                previous[i] = bestLengthIndex;
            }
        }

        var result = new List<int>();
        var biggestLengthIndex = lengths
            .ToList()
            .IndexOf(lengths.Max());

        for (var i = biggestLengthIndex; i != -1; i = previous[i])
        {
            result.Add(numbers.ElementAt(i));
        }

        result.Reverse();
        Console.WriteLine(string.Join(" ", result));
    }
}