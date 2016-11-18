using System;
using System.Collections.Generic;
using System.Linq;

class Tour
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var distanceMatrix = new int[n, n];

        for (int row = 0; row < n; row++)
        {
            var lineTokens = Console.ReadLine().Split(' ');

            for (int column = 0; column < n; column++)
            {
                distanceMatrix[row, column] = int.Parse(lineTokens[column]);
            }
        }

        var route = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();
        var totalSum = 0;

        for (int i = 0; i < route.Length; i++)
        {
            var currentTownIndex = route[i];
            var previousTownIndex = 0;

            if (i > 0)
            {
                previousTownIndex = route[i - 1];
            }

            totalSum += distanceMatrix[currentTownIndex, previousTownIndex];
        }

        Console.WriteLine(totalSum);
    }
}