using System;

class TrifonQuest
{
    static void Main()
    {
        long health = long.Parse(Console.ReadLine());
        var matrixTokens = Console.ReadLine().Split(' ');
        int rowsLength = int.Parse(matrixTokens[0]);
        int colsLength = int.Parse(matrixTokens[1]);

        int turns = 0;
        bool isAlive = true;

        var matrix = GetMatrix(rowsLength, colsLength);

        for (int column = 0; column < colsLength; column++)
        {
            if (column % 2 == 0)
            {
                for (int row = 0; row < rowsLength; row++)
                {
                    char currentCharacter = matrix[row, column];
                    switch (currentCharacter)
                    {
                        case 'F': health -= turns / 2; break;
                        case 'H': health += turns / 3; break;
                        case 'T': turns += 2; break;
                    }

                    if (health <= 0)
                    {
                        isAlive = false;
                        Console.WriteLine("Died at: [{0}, {1}]", row, column);
                        return;
                    }

                    ++turns;
                }
            }
            else
            {
                for (int row = rowsLength - 1; row >= 0; row--)
                {
                    char currentCharacter = matrix[row, column];
                    switch (currentCharacter)
                    {
                        case 'F': health -= turns / 2; break;
                        case 'H': health += turns / 3; break;
                        case 'T': turns += 2; break;
                    }

                    if (health <= 0)
                    {
                        isAlive = false;
                        Console.WriteLine("Died at: [{0}, {1}]", row, column);
                        return;
                    }

                    ++turns;
                }
            }
        }

        if (isAlive)
        {
            Console.WriteLine("Quest completed!");
            Console.WriteLine("Health: {0}", health);
            Console.WriteLine("Turns: {0}", turns);
        }
    }

    private static char[,] GetMatrix(int rows, int cols)
    {
        char[,] matrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string line = Console.ReadLine().Substring(0, cols);

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = line[j];
            }
        }

        return matrix;
    }
}