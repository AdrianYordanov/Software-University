using System;

class EnglishNameOfTheLastDigit
{
    static void Main()
    {
        long numberInput = long.Parse(Console.ReadLine());
        string result = LastDigitNameOfNumber(numberInput);
        Console.WriteLine(result);
    }

    private static string LastDigitNameOfNumber(long number)
    {
        int lastDigit = (int)(number % 10);
        int lastDigitPositive = Math.Abs(lastDigit);

        switch (lastDigitPositive)
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eigth";
            case 9: return "nine";
            default: return "Never return message.";
        }
    }
}