using System;

class RecursiveFibonacci
{
    private static ulong[] lookupArray;

    static void Main()
    {
        lookupArray = new ulong[50];
        lookupArray[0] = 1;
        lookupArray[1] = 1;

        var n = ulong.Parse(Console.ReadLine());
        var result = getFibonacci(n);

        Console.WriteLine(result);
    }

    public static ulong getFibonacci(ulong n)
    {
        if (n <= 2)
        {
            return 1;
        }

        if (lookupArray[n - 1] != 0)
        {
            return lookupArray[n - 1];
        }

        lookupArray[n - 1] = getFibonacci(n - 1) + getFibonacci(n - 2);
        return lookupArray[n - 1];
    }
}