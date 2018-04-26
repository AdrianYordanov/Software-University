using System;
using System.Collections.Generic;

public class FindEvensOrOdds
{
    private static Predicate<int> CreateFunction(string paramater)
    {
        if (paramater == "even")
        {
            return number => number % 2 == 0;
        }

        if (paramater == "odd")
        {
            return number => number % 2 != 0;
        }

        throw new Exception("Invalid parameter.");
    }

    private static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        var left = int.Parse(input[0]);
        var right = int.Parse(input[1]);
        var parameter = Console.ReadLine();
        var numbers = new List<int>();
        var checkFunc = CreateFunction(parameter);
        for (var i = left; i <= right; i++)
        {
            if (checkFunc(i))
            {
                numbers.Add(i);
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}