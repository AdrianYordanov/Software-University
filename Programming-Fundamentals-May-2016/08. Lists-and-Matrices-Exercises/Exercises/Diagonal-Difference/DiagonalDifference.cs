using System;
using System.Collections.Generic;
using System.Linq;

class DiagonalDifference
{
    static void Main()
    {
        var size = int.Parse(Console.ReadLine());
        var matrix = new int[size, size];

        for (int row = 0; row < size; row++)
        {
            var lineToknes = Console.ReadLine().Split(' ');

            for (int column = 0; column < size; column++)
            {
                matrix[row, column] = int.Parse(lineToknes[column]);
            }
        }

        var primaryDiagonalSum = 0;
        var secondaryDiagonalSum = 0;

        for (int i = 0; i < size; i++)
        {
            primaryDiagonalSum += matrix[i, i];
            secondaryDiagonalSum += matrix[i, size - i - 1];
        }

        Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
    }
}