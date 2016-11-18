using System;
using System.Collections.Generic;
using System.Linq;

class HourglassSum
{
    static void Main()
    {
        var size = 6;
        var matrix = new int[size, size];

        for (int row = 0; row < size; row++)
        {
            var lineToknes = Console.ReadLine().Split(' ');

            for (int column = 0; column < size; column++)
            {
                matrix[row, column] = int.Parse(lineToknes[column]);
            }
        }

        var bestSum = 0;

        for (int row = 0; row < size - 2; row++)
        {
            for (int column = 0; column < size - 2; column++)
            {
                var currentHourglassSum = 0;

                for (int hourglassColumn = column; hourglassColumn < column + 3; hourglassColumn++)
                {
                    currentHourglassSum += matrix[row, hourglassColumn] + matrix[row + 2, hourglassColumn];
                }

                // Summing the middle element.
                currentHourglassSum += matrix[row + 1, column + 1];

                if (bestSum < currentHourglassSum)
                {
                    bestSum = currentHourglassSum;
                }
            }
        }

        Console.WriteLine(bestSum);
    }
}