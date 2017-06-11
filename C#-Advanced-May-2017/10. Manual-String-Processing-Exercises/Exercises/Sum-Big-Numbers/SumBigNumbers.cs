using System;

class SumBigNumbers
{
    static void Main()
    {
        var firstNumber = Console.ReadLine().TrimStart(new Char[] { '0' });
        var secondNumber = Console.ReadLine().TrimStart(new Char[] { '0' });
        var result = string.Empty;
        var remainder = 0;

        for (int firstNumberIndex = firstNumber.Length - 1, secondNumberIndex = secondNumber.Length - 1;
            firstNumberIndex >= 0 || secondNumberIndex >= 0 || remainder > 0;
            firstNumberIndex--, secondNumberIndex--)
        {
            var firstNumberDigit = firstNumberIndex >= 0 ? int.Parse(firstNumber[firstNumberIndex].ToString()) : 0;
            var secondNumberDigit = secondNumberIndex >= 0 ? int.Parse(secondNumber[secondNumberIndex].ToString()) : 0;
            var addDigit = firstNumberDigit + secondNumberDigit + remainder;

            if (addDigit > 9)
            {
                remainder = addDigit / 10;
                addDigit = addDigit % 10;
            }
            else
            {
                remainder = 0;
            }

            result = addDigit + result;
        }

        Console.WriteLine(result);
    }
}