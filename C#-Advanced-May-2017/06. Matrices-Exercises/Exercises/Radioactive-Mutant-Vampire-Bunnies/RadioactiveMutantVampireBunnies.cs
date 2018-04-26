using System;
using System.Collections.Generic;

public class RadioactiveMutantVampireBunnies
{
    private static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var n = int.Parse(tokens[0]);
        var matrix = new char[n][];
        var playerRow = -1;
        var playerCol = -1;
        for (var row = 0; row < n; row++)
        {
            var line = Console.ReadLine().ToCharArray();
            matrix[row] = line;
            if (playerCol == -1)
            {
                var playerIndex = Array.IndexOf(line, 'P');
                if (playerIndex >= 0)
                {
                    playerRow = row;
                    playerCol = playerIndex;
                }
            }
        }

        var isWinner = false;
        var previousPlayerRow = 0;
        var previousPlayerCol = 0;
        var commands = Console.ReadLine();
        foreach (var command in commands)
        {
            previousPlayerRow = playerRow;
            previousPlayerCol = playerCol;
            switch (command)
            {
                case 'U':
                    playerRow--;
                    break;
                case 'D':
                    playerRow++;
                    break;
                case 'L':
                    playerCol--;
                    break;
                case 'R':
                    playerCol++;
                    break;
            }

            matrix[previousPlayerRow][previousPlayerCol] = '.';

            // Spreading.
            var bunniesRows = new List<int>();
            var bunniesCols = new List<int>();
            for (var row = 0; row < matrix.Length; row++)
            {
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        bunniesRows.Add(row);
                        bunniesCols.Add(col);
                    }
                }
            }

            for (var i = 0; i < bunniesRows.Count; ++i)
            {
                var row = bunniesRows[i];
                var col = bunniesCols[i];
                if (row > 0)
                {
                    matrix[row - 1][col] = 'B';
                }

                if (row < (matrix.Length - 1))
                {
                    matrix[row + 1][col] = 'B';
                }

                if (col > 0)
                {
                    matrix[row][col - 1] = 'B';
                }

                if (col < (matrix[row].Length - 1))
                {
                    matrix[row][col + 1] = 'B';
                }
            }

            // Checking
            if (playerRow < 0
                || playerRow > (matrix.Length - 1)
                || playerCol < 0
                || playerCol > (matrix[0].Length - 1))
            {
                isWinner = true;
                break;
            }

            if (matrix[playerRow][playerCol] == '.')
            {
                matrix[playerRow][playerCol] = 'P';
            }
            else
            {
                break;
            }
        }

        foreach (var row in matrix)
        {
            Console.WriteLine(string.Join(string.Empty, row));
        }

        Console.WriteLine(
            isWinner ? $"won: {previousPlayerRow} {previousPlayerCol}" : $"dead: {playerRow} {playerCol}");
    }
}