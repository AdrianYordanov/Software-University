using System;

class MultiplyBigNumbers
{
    static void Main()
    {
        var firstNumber = Console.ReadLine().TrimStart(new Char[] { '0' });
        var secondNumber = int.Parse(Console.ReadLine());
        var result = string.Empty;
        var remainder = 0;

        for (int firstNumberIndex = firstNumber.Length - 1; firstNumberIndex >= 0 || remainder > 0; firstNumberIndex--)
        {
            var firstNumberDigit = firstNumberIndex >= 0 ? int.Parse(firstNumber[firstNumberIndex].ToString()) : 0;
            var addDigit = (firstNumberDigit * secondNumber) + remainder;

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

        result = result.TrimStart(new char[] { '0' });
        result = result.Length == 0 ? "0" : result;
        Console.WriteLine(result);
    }
}