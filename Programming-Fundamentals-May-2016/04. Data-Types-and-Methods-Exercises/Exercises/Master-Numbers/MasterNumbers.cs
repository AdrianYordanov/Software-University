using System;
using System.Collections.Generic;

class MasterNumbers
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        for (int i = 1; i <= number; i++)
        {
            if(IsPalindrome(i) && (SumOfDigits(i) % 7 == 0) && ContainsEvenDigits(i))
            {
                Console.WriteLine(i);
            }
        }
    }

    private static bool IsPalindrome(int number)
    {
        string numberToString = number.ToString();

        for (int i = 0, j = numberToString.Length - 1; i < numberToString.Length; i++,--j)
        {
            if(!numberToString[i].Equals(numberToString[j]))
            {
                return false;
            }
        }

        return true;
    }

    private static byte SumOfDigits(int number)
    {
        byte sum = 0;

        while (number > 0)
        {
            sum += (byte)(number % 10);
            number /= 10;
        }

        return sum;
    }

    private static bool ContainsEvenDigits(int number)
    {
        while (number > 0)
        {
            int digit = number % 10;

            if (digit % 2 == 0)
            {
                return true;
            }

            number /= 10;
        }

        return false;
    }
}