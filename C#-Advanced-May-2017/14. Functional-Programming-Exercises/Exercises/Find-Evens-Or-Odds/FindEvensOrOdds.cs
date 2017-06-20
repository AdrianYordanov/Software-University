using System;
using System.Collections.Generic;

class FindEvensOrOdds
{
    static void Main()
    {
        var input = Console.ReadLine().Split(' ');
        var left = int.Parse(input[0]);
        var right = int.Parse(input[1]);
        var parameter = Console.ReadLine();
        var numbers = new List<int>();
        var checkFunc = CreateFunction(parameter);

        for (int i = left; i <= right; i++)
        {
            if (checkFunc(i))
            {
                numbers.Add(i);
            }
        }

        Console.WriteLine(string.Join(" ", numbers));
    }

    private static Predicate<int> CreateFunction(string paramater)
    {
        if (paramater == "even")
        {
            return number => number % 2 == 0;
        }
        else if (paramater == "odd")
        {
            return number => number % 2 != 0;
        }
        else
        {
            throw new Exception("Invalid parameter.");
        }
    }
}