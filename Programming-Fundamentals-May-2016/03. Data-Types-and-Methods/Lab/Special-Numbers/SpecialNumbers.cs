using System;

class SpecialNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1; i <= n; i++)
        {
            bool isSpecial = SpecialNumbersCheck(i);
            Console.WriteLine("{0} -> {1}", i, isSpecial);
        }
    }

    private static bool SpecialNumbersCheck(int number)
    {
        int result = SumOfDigits(number);

        if (result == 5 || result == 7 || result == 11)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private static int SumOfDigits(int number)
    {
        int result = 0;

        while (number > 0)
        {
            result += number % 10;
            number /= 10;
        }

        return result;
    }
}