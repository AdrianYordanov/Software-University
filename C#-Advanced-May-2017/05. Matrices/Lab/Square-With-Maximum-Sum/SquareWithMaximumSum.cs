using System;

class SquareWithMaximumSum
{
    static void Main()
    {
        var parameters = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        var rowsCount = int.Parse(parameters[0]);
        var colsCount = int.Parse(parameters[1]);
        var matrix = new int[rowsCount, colsCount];
        var bestSum = int.MinValue;
        var bestMatrix = new int[2, 2];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = int.Parse(tokens[j]);
            }
        }

        for (int i = 0; i < matrix.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < matrix.GetLength(1) - 1; j++)
            {
                var subMatrixSum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];

                if (subMatrixSum > bestSum)
                {
                    bestSum = subMatrixSum;
                    bestMatrix[0, 0] = matrix[i, j];
                    bestMatrix[0, 1] = matrix[i, j + 1];
                    bestMatrix[1, 0] = matrix[i + 1, j];
                    bestMatrix[1, 1] = matrix[i + 1, j + 1];
                };
            }
        }

        for (int i = 0; i < bestMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < bestMatrix.GetLength(1); j++)
            {
                Console.Write(bestMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine(bestSum);
    }
}