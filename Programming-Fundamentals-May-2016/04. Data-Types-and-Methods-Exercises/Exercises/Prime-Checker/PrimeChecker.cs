using System;

class PrimeChecker
{
    static void Main()
    {
        long number = long.Parse(Console.ReadLine());
        Console.WriteLine(IsPrime(number));
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
}