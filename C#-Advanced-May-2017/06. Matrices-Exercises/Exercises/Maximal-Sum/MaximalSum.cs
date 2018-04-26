using System;
using System.Linq;

public class MaximalSum
{
    private static void Main()
    {
        var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var matrix = new int[tokens[0], tokens[1]];
        var maxSum = int.MinValue;
        var maxSumRow = 0;
        var maxSumCol = 0;
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            var intTokens = Console.ReadLine().Split(' ');
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = int.Parse(intTokens[j]);
            }
        }

        for (var row = 0; row < (matrix.GetLength(0) - 2); row++)
        {
            for (var col = 0; col < (matrix.GetLength(1) - 2); col++)
            {
                var nestedMatrixSum = 0;
                for (var nestedRow = row; nestedRow < (row + 3); nestedRow++)
                {
                    for (var nestedCol = col; nestedCol < (col + 3); nestedCol++)
                    {
                        nestedMatrixSum += matrix[nestedRow, nestedCol];
                    }
                }

                if (nestedMatrixSum > maxSum)
                {
                    maxSumRow = row;
                    maxSumCol = col;
                    maxSum = nestedMatrixSum;
                }
            }
        }

        Console.WriteLine($"Sum = {maxSum}");
        for (var i = maxSumRow; i < (maxSumRow + 3); i++)
        {
            for (var j = maxSumCol; j < (maxSumCol + 3); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}