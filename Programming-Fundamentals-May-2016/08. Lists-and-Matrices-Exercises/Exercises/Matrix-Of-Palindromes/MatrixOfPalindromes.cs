using System;
using System.Collections.Generic;
using System.Linq;

class MatrixOfPalindromes
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(' ');
        var rows = int.Parse(tokens[0]);
        var cols = int.Parse(tokens[1]);
        var matrx = new string[rows, cols];

        char charRow = 'a';
        for (int currentRow = 0; currentRow < rows; currentRow++, ++charRow)
        {
            char charCol = charRow;
            for (int currentCol = 0; currentCol < cols; currentCol++, ++charCol)
            {
                matrx[currentRow, currentCol] = string.Format("{0}{1}{0}", charRow, charCol);
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrx[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}