using System;

class SumMatrixElements
{
    static void Main()
    {
        var parameters = Console.ReadLine()
            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        var sum = 0;
        var rowsCount = int.Parse(parameters[0]);
        var colsCount = int.Parse(parameters[1]);
        var matrix = new int[rowsCount, colsCount];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            var tokens = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = int.Parse(tokens[j]);
            }
        }

        foreach (var number in matrix)
        {
            sum += number;
        }

        Console.WriteLine(rowsCount);
        Console.WriteLine(colsCount);
        Console.WriteLine(sum);
    }
}
