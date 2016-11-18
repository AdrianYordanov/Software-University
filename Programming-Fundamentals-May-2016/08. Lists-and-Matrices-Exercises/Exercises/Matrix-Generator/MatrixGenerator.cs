using System;
using System.Collections.Generic;
using System.Linq;

class MatrixGenerator
{
    static void Main()
    {
        var inputTokens = Console.ReadLine().Split(' ');
        var type = char.Parse(inputTokens[0]);
        var rows = int.Parse(inputTokens[1]);
        var columns = int.Parse(inputTokens[2]);
        var matrix = new int[rows, columns];

        switch (type)
        {
            case 'A': TypeA(matrix, rows, columns); break;
            case 'B': TypeB(matrix, rows, columns); break;
            case 'C': TypeC(matrix, rows, columns); break;
            case 'D': TypeD(matrix, rows, columns); break;
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }

    static void TypeA(int[,] matrix, int rows, int columns)
    {
        for (int columnIterator = 0, counter = 1; columnIterator < columns; columnIterator++)
        {
            for (int rowIterator = 0; rowIterator < rows; rowIterator++, ++counter)
            {
                matrix[rowIterator, columnIterator] = counter;
            }
        }
    }

    static void TypeB(int[,] matrix, int rows, int columns)
    {
        for (int columnIterator = 0, counter = 1; columnIterator < columns; columnIterator++)
        {
            if(columnIterator % 2 == 0)
            {
                for (int rowIterator = 0; rowIterator < rows; rowIterator++, ++counter)
                {
                    matrix[rowIterator, columnIterator] = counter;
                }
            }
            else
            {
                for (int rowIterator = rows - 1; rowIterator >= 0; rowIterator--, ++counter)
                {
                    matrix[rowIterator, columnIterator] = counter;
                }
            }
        }
    }

    static void TypeC(int[,] matrix, int rows, int columns)
    {
        var counter = 1;

        for (int rowIterator = rows - 1; rowIterator >= 0; rowIterator--)
        {
            for (int diagonalRow = rowIterator, diagonalColumn = 0;
                diagonalRow < rows; diagonalRow++, diagonalColumn++, ++counter)
            {
                matrix[diagonalRow, diagonalColumn] = counter;
            }
        }

        for (int columnIterator = 1; columnIterator < columns; columnIterator++)
        {
            for (int diagonalRow = 0, diagonalColumn = columnIterator;
                diagonalColumn < columns; diagonalRow++, diagonalColumn++, ++counter)
            {
                matrix[diagonalRow, diagonalColumn] = counter;
            }
        }
    }

    static void TypeD(int[,] matrix, int rows, int columnns)
    {
        var borderDifference = 0;

        for (int counter = 1; counter <= rows * columnns; borderDifference++)
        {
            for (int rowIterator = borderDifference; 
                rowIterator < rows - borderDifference; rowIterator++, counter++)
            {
                matrix[rowIterator, borderDifference] = counter;
            }

            for (int columnIterator = borderDifference + 1;
                columnIterator < columnns - borderDifference; columnIterator++, counter++)
            {
                matrix[rows - borderDifference - 1, columnIterator] = counter;
            }


            for (int rowIterator = rows - borderDifference - 2;
                rowIterator >= borderDifference; rowIterator--, counter++)
            {
                matrix[rowIterator, columnns - borderDifference - 1] = counter;
            }


            for (int columnIterator = columnns - borderDifference - 2;
                columnIterator >= borderDifference + 1; columnIterator--, counter++)
            {
                matrix[borderDifference, columnIterator] = counter;
            }
        }
    }
}