using System;
using System.Collections.Generic;
using System.Linq;

class SquaresInMatrix
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split();
        var rowSize = int.Parse(tokens[0]);
        var columnSize = int.Parse(tokens[1]);
        var matrix = new char[rowSize, columnSize];

        for (int row = 0; row < rowSize; row++)
        {
            var lineToknes = Console.ReadLine().Split(' ');

            for (int column = 0; column < columnSize; column++)
            {
                matrix[row, column] = char.Parse(lineToknes[column]);
            }
        }

        var counter = 0;

        for (int row = 0; row < rowSize - 1; row++)
        {
            for (int column = 0; column < columnSize - 1; column++)
            {
                if (matrix[row, column] == matrix[row, column + 1] &&
                    matrix[row, column] == matrix[row + 1, column] &&
                    matrix[row + 1, column] == matrix[row + 1, column + 1])
                {
                    ++counter;
                }
            }
        }

        Console.WriteLine(counter);
    }
}