﻿using System;
using System.Linq;

public class SquaresInMatrix
{
    private static void Main()
    {
        var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var matrix = new char[tokens[0], tokens[1]];
        var result = 0;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            var charTokens = Console.ReadLine().Split(' ');
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = char.Parse(charTokens[j]);
            }
        }

        for (var row = 0; row < (matrix.GetLength(0) - 1); row++)
        {
            for (var col = 0; col < (matrix.GetLength(1) - 1); col++)
            {
                var character = matrix[row, col];
                if (matrix[row, col + 1] == character
                    && matrix[row + 1, col] == character
                    && matrix[row + 1, col + 1] == character)
                {
                    result++;
                }
            }
        }

        Console.WriteLine(result);
    }
}