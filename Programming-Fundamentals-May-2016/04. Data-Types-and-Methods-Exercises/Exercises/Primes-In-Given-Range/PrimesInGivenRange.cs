using System;
using System.Collections.Generic;

class PrimesInGivenRange
{
    static void Main()
    {
        int start = int.Parse(Console.ReadLine());
        int end = int.Parse(Console.ReadLine());

        var list = FindPrimesInGivenRange(start, end);
        PrintList(list);
    }

    private static List<int> FindPrimesInGivenRange(int start, int end)
    {
        List<int> primeList = new List<int>();

        for (int i = start; i <= end; i++)
        {
            if(IsPrime(i))
            {
                primeList.Add(i);
            }
        }

        return primeList;
    }

    private static bool IsPrime(long number)
    {
        if (number < 2) return false;
        if (number % 2 == 0) return (number == 2);
        long root = (long)Math.Sqrt((double)number);
        for (long i = 3; i <= root; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    private static void PrintList(List<int> list)
    {
        var array = list.ToArray();
        Console.WriteLine(string.Join(", ", array));
    }
}