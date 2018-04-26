using System;
using System.Collections.Generic;
using System.Linq;

public class Crossfire
{
    private static void Main()
    {
        var matrixTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var rowsCount = int.Parse(matrixTokens[0]);
        var colsCount = int.Parse(matrixTokens[1]);
        var matrix = new List<List<int>>();
        for (int i = 0, counter = 1; i < rowsCount; i++)
        {
            matrix.Add(new List<int>());
            for (var j = 0; j < colsCount; j++, counter++)
            {
                matrix[i].Add(counter);
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "Nuke it from orbit")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var row = int.Parse(tokens[0]);
            var col = int.Parse(tokens[1]);
            var radius = int.Parse(tokens[2]);
            for (var currentRow = row - radius; currentRow <= (row + radius); currentRow++)
            {
                if (currentRow < 0
                    || currentRow > (matrix.Count - 1))
                {
                    continue;
                }

                if (col < 0
                    || col > (matrix[currentRow].Count - 1))
                {
                    continue;
                }

                matrix[currentRow][col] = 0;
            }

            for (var currentCol = col - radius; currentCol <= (col + radius); currentCol++)
            {
                if (row < 0
                    || row > (matrix.Count - 1))
                {
                    continue;
                }

                if (currentCol < 0
                    || currentCol > (matrix[row].Count - 1))
                {
                    continue;
                }

                matrix[row][currentCol] = 0;
            }

            for (var i = 0; i < matrix.Count; i++)
            {
                matrix[i] = matrix[i].Where(x => x > 0).ToList();
                if (matrix[i].Count == 0)
                {
                    matrix.RemoveAt(i);
                    --i;
                }
            }
        }

        foreach (var element in matrix)
        {
            Console.WriteLine(string.Join(" ", element));
        }
    }
}