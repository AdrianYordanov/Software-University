using System;
using System.Collections.Generic;
using System.Linq;

class BuildAMatrixOfLetters
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int cols = int.Parse(Console.ReadLine());

        char[,] matrix = new char[rows, cols];
        char currentLetter = 'A';

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++, ++currentLetter)
            {
                if (currentLetter > 'Z')
                {
                    currentLetter = 'A';
                }

                matrix[i, j] = currentLetter;
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }

            Console.WriteLine();
        }
    }
}