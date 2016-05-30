using System;
using System.Numerics;

class Factorial
{
    static void Main()
    {
        short n = short.Parse(Console.ReadLine());
        BigInteger factorial = 1;

        for (int i = 1; i <= n; i++)
        {
            factorial = BigInteger.Multiply(factorial, i);
        }

        Console.WriteLine(factorial);
    }
}