using System;
using System.Linq;

public class MatrixOfPalindromes
{
    private static void Main()
    {
        var tokens = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var matrix = new string[tokens[0], tokens[1]];
        var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        for (var rowLetter = 0; rowLetter < matrix.GetLength(0); rowLetter++)
        {
            for (int colLetter = rowLetter, colIndex = 0; colIndex < matrix.GetLength(1); colLetter++, colIndex++)
            {
                matrix[rowLetter, colIndex] = $"{alphabet[rowLetter]}{alphabet[colLetter]}{alphabet[rowLetter]}";
            }
        }

        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            for (var j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }
    }
}