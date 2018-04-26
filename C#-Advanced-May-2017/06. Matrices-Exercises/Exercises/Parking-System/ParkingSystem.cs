using System;
using System.Collections.Generic;

public class ParkingSystem
{
    private static bool IsFreeSpot(Dictionary<int, HashSet<int>> parking, int row, int col)
    {
        if (parking.ContainsKey(row))
        {
            if (parking[row].Contains(col))
            {
                return false;
            }
        }
        else
        {
            parking.Add(row, new HashSet<int>());
        }

        return true;
    }

    private static void Main()
    {
        var mainTokens = Console.ReadLine().Split(' ');
        var colsCount = int.Parse(mainTokens[1]);
        var parking = new Dictionary<int, HashSet<int>>();
        string input;
        while ((input = Console.ReadLine()) != "stop")
        {
            var spotCol = 0;
            var tokens = input.Split(' ');
            var enterRow = int.Parse(tokens[0]);
            var initialRow = int.Parse(tokens[1]);
            var initialCol = int.Parse(tokens[2]);
            for (int colToLeft = initialCol, colToRight = initialCol;
                 colToLeft > 0 || colToRight < colsCount;
                 colToLeft--, colToRight++)
            {
                if (colToLeft > 0
                    && IsFreeSpot(parking, initialRow, colToLeft))
                {
                    spotCol = colToLeft;
                    break;
                }

                if (colToRight < colsCount
                    && IsFreeSpot(parking, initialRow, colToRight))
                {
                    spotCol = colToRight;
                    break;
                }
            }

            if (spotCol != 0)
            {
                parking[initialRow].Add(spotCol);
                Console.WriteLine(Math.Abs(enterRow - initialRow) + spotCol + 1);
            }
            else
            {
                Console.WriteLine($"Row {initialRow} full");
            }
        }
    }
}