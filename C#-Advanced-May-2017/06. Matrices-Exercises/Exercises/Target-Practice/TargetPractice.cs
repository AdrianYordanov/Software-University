using System;

class TargetPractice
{
    static void Main()
    {
        var firstTokens = Console.ReadLine().Split(' ');
        var line = Console.ReadLine();
        var secondTokens = Console.ReadLine().Split(' ');
        var rowsCount = int.Parse(firstTokens[0]);
        var colsCount = int.Parse(firstTokens[1]);
        var bombRow = int.Parse(secondTokens[0]);
        var bombCol = int.Parse(secondTokens[1]);
        var radius = int.Parse(secondTokens[2]);
        var matrix = new char[rowsCount, colsCount];


        // Define matrix.
        for (int i = rowsCount - 1, stringIndex = 0, counter = 0; i >= 0; i--, ++counter)
        {
            if (counter % 2 == 0)
            {
                for (int j = colsCount - 1; j >= 0; j--, stringIndex++)
                {
                    if (stringIndex >= line.Length)
                    {
                        stringIndex = 0;
                    }

                    matrix[i, j] = line[stringIndex];
                }
            }
            else
            {
                for (int j = 0; j < colsCount; j++, stringIndex++)
                {
                    if (stringIndex >= line.Length)
                    {
                        stringIndex = 0;
                    }

                    matrix[i, j] = line[stringIndex];
                }
            }
        }

        // Shot on the matrix.
        for (int row = 0; row < rowsCount; row++)
        {
            for (int col = 0; col < colsCount; col++)
            {
                if (ShouldBeShooted(row, col, bombRow, bombCol, radius))
                {
                    matrix[row, col] = ' ';
                }
            }
        }

        // All characters falling down.
        for (int col = 0; col < colsCount; col++)
        {
            for (int row = 0; row < rowsCount - 1; row++)
            {
                if (matrix[row + 1, col] == ' ')
                {
                    matrix[row + 1, col] = matrix[row, col];
                    matrix[row, col] = ' ';
                }
                else
                {
                    for (row += 2; row < rowsCount; row++)
                    {
                        if (matrix[row, col] == ' ')
                        {
                            matrix[row, col] = matrix[row - 1, col];
                            matrix[row - 1, col] = ' ';
                            row = -1;
                            break;
                        }
                    }
                }
            }
        }

        // Printing matrix
        for (int i = 0; i < rowsCount; i++)
        {
            for (int j = 0; j < colsCount; j++)
            {
                Console.Write($"{matrix[i, j]}");
            }

            Console.WriteLine();
        }
    }

    private static bool ShouldBeShooted(int x, int y, int impactRow, int impactCol, int impactRadius)
    {
        var distance = Math.Sqrt((x - impactRow) * (x - impactRow) + (y - impactCol) * (y - impactCol));
        return distance <= impactRadius;
    }
}