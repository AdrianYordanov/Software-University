using System;
using System.Collections.Generic;
using System.Linq;

public class RotateMatrix
{
    static void Main()
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());

        var matrix = new List<List<string>>();

        for (int i = 0; i < rows; i++)
        {
            var lineAsList = Console.ReadLine()
                .Split(' ')
                .ToList();

            var exactlyLength = lineAsList.Take(cols);
            matrix.Add(exactlyLength.ToList());
        }

        matrix.Reverse();

        for (int currentCols = 0; currentCols < cols; currentCols++)
        {
            for (int currentRow = 0; currentRow < rows; currentRow++)
            {
                Console.Write("{0} ", matrix[currentRow][currentCols]);
            }

            Console.WriteLine();
        }
    }
}