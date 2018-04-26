using System;

public class PascalTriangle
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var triangle = new long[n][];
        for (var i = 0; i < triangle.Length; i++)
        {
            triangle[i] = new long[i + 1];
            triangle[i][0] = triangle[i][i] = 1;
            for (var j = 1; j < (triangle[i].Length - 1); j++)
            {
                triangle[i][j] = triangle[i - 1][j - 1] + triangle[i - 1][j];
            }
        }

        foreach (var subArray in triangle)
        {
            Console.WriteLine(string.Join(" ", subArray));
        }
    }
}