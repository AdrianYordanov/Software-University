using System;

class MaxMethod
{
    static void Main()
    {
        int first = int.Parse(Console.ReadLine());
        int second = int.Parse(Console.ReadLine());
        int third = int.Parse(Console.ReadLine());

        int bigger = GetMax(first, second);
        int biggest = GetMax(bigger, third);

        Console.WriteLine(biggest);
    }

    private static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}