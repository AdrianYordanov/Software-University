using System;

public class RecursiveFibonacci
{
    private static ulong[] lookupArray;

    public static ulong GetFibonacci(ulong n)
    {
        if (n <= 2)
        {
            return 1;
        }

        if (lookupArray[n - 1] != 0)
        {
            return lookupArray[n - 1];
        }

        lookupArray[n - 1] = GetFibonacci(n - 1) + GetFibonacci(n - 2);
        return lookupArray[n - 1];
    }

    public static void Main()
    {
        lookupArray = new ulong[50];
        lookupArray[0] = 1;
        lookupArray[1] = 1;
        var n = ulong.Parse(Console.ReadLine());
        var result = GetFibonacci(n);
        Console.WriteLine(result);
    }
}