using System;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        int[][] arrayFirst = new int[rows][];
        int[][] arraySecond = new int[rows][];
        for (int i = 0; i < arrayFirst.Length; i++)
        {
            arrayFirst[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }
        for (int i = 0; i < arraySecond.Length; i++)
        {
            arraySecond[i] = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
        }

        bool isRectangle = true;
        var firstLineLength = arrayFirst[0].Length + arraySecond[0].Length;

        for (int i = 0; i < rows; i++)
        {
            if (arrayFirst[i].Length + arraySecond[i].Length != firstLineLength)
            {
                isRectangle = false;
                break;
            }
        }

        if (isRectangle)
        {
            int[][] reverse = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                reverse[i] = arraySecond[i].Reverse().ToArray();
                var resultArray = new int[arrayFirst[i].Length + reverse[i].Length];
                arrayFirst[i].CopyTo(resultArray, 0);
                reverse[i].CopyTo(resultArray, arrayFirst[i].Length);
                arrayFirst[i] = resultArray;
            }

            for (int i = 0; i < rows; i++)
            {
                Console.WriteLine("[" + string.Join(", ", arrayFirst[i]) + "]");
            }
        }
        else
        {
            int sumCells = 0;

            for (int i = 0; i < rows; i++)
            {
                sumCells += arrayFirst[i].Length + arraySecond[i].Length;
            }

            Console.WriteLine($"The total number of cells is: {sumCells}");
        }
    }
}