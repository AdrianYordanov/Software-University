using System;

class ExactSumOfRealNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        decimal exactSum = 0m;

        for (int i = 0; i < n; i++)
        {
            decimal currentNumber = decimal.Parse(Console.ReadLine());
            exactSum += currentNumber;
        }

        Console.WriteLine(exactSum);
    }
}