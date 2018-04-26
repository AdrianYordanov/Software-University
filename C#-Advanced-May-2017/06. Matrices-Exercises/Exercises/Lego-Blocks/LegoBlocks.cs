using System;
using System.Linq;

public class LegoBlocks
{
    private static void Main()
    {
        var rows = int.Parse(Console.ReadLine());
        var arrayFirst = new int[rows][];
        var arraySecond = new int[rows][];
        for (var i = 0; i < arrayFirst.Length; i++)
        {
            arrayFirst[i] = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        for (var i = 0; i < arraySecond.Length; i++)
        {
            arraySecond[i] = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }

        var isRectangle = true;
        var firstLineLength = arrayFirst[0].Length + arraySecond[0].Length;
        for (var i = 0; i < rows; i++)
        {
            if (arrayFirst[i].Length + arraySecond[i].Length != firstLineLength)
            {
                isRectangle = false;
                break;
            }
        }

        if (isRectangle)
        {
            var reverse = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                reverse[i] = arraySecond[i].Reverse().ToArray();
                var resultArray = new int[arrayFirst[i].Length + reverse[i].Length];
                arrayFirst[i].CopyTo(resultArray, 0);
                reverse[i].CopyTo(resultArray, arrayFirst[i].Length);
                arrayFirst[i] = resultArray;
            }

            for (var i = 0; i < rows; i++)
            {
                Console.WriteLine("[" + string.Join(", ", arrayFirst[i]) + "]");
            }
        }
        else
        {
            var sumCells = 0;
            for (var i = 0; i < rows; i++)
            {
                sumCells += arrayFirst[i].Length + arraySecond[i].Length;
            }

            Console.WriteLine($"The total number of cells is: {sumCells}");
        }
    }
}