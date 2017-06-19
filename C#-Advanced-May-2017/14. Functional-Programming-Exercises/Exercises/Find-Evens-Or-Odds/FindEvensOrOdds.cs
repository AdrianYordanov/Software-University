using System;
using System.Collections.Generic;
using System.Linq;

class FindEvensOrOdds
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        var left = int.Parse(input[0]);
        var right = int.Parse(input[1]);
        var parameter = Console.ReadLine();

        Console.WriteLine(string.Join(" ", CreateFunction(parameter)(left, right)));
    }

    private static Func<int, int, int[]> CreateFunction(string paramater)
    {
        return (left, right) =>
        {
            var list = new List<int>();

            for (int counter = left; counter <= right; counter++)
            {
                list.Add(counter);
            }

            switch (paramater)
            {
                case "odd": return list.Where(number => number % 2 != 0).ToArray();
                case "even": return list.Where(number => number % 2 == 0).ToArray();
                default: throw new Exception("Wrong paramater");
            }
        };
    }
}