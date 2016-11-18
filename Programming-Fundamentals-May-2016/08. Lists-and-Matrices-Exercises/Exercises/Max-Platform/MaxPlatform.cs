using System;
using System.Collections.Generic;
using System.Linq;

class MaxPlatform
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split();
        var rowSize = int.Parse(tokens[0]);
        var columnSize = int.Parse(tokens[1]);
        var matrix = new int[rowSize, columnSize];

        for (int row = 0; row < rowSize; row++)
        {
            var lineToknes = Console.ReadLine().Split(' ');

            for (int column = 0; column < columnSize; column++)
            {
                matrix[row, column] = int.Parse(lineToknes[column]);
            }
        }

        var bestSum = 0;

        for (int row = 0; row < rowSize - 2; row++)
        {
            for (int column = 0; column < columnSize - 2; column++)
            {
                var nestedMatrixSum = 0;

                for (int nestedMatrixRow = row; nestedMatrixRow < row + 3; nestedMatrixRow++)
                {
                    for (int nestedMatrixColumn = column; nestedMatrixColumn < column + 3; nestedMatrixColumn++)
                    {
                        nestedMatrixSum += matrix[nestedMatrixRow, nestedMatrixColumn];
                    }
                }

                if(bestSum < nestedMatrixSum)
                {
                    bestSum = nestedMatrixSum;
                }
            }
        }

        Console.WriteLine(bestSum);
    }
}