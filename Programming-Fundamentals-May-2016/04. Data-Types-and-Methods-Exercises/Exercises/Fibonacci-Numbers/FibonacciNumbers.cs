using System;

class FibonacciNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int previousFibNumber = 1;
        int fibNumberBeforePrevious = 1;
        int result = 1;

        for(int i = 2; i <= n; ++i)
        {
            result = previousFibNumber + fibNumberBeforePrevious;
            fibNumberBeforePrevious = previousFibNumber;
            previousFibNumber = result;
        }

        Console.WriteLine(result);
    }
}