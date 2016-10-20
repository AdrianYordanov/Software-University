using System;

class NumbersInReversedOrder
{
    static void Main()
    {
        double inputNumber = double.Parse(Console.ReadLine());
        PrintReversedNumber(inputNumber);
    }

    private static void PrintReversedNumber(double number)
    {
        char[] charArray = number
            .ToString()
            .ToCharArray();
        Array.Reverse(charArray);
        string reversedNumber = new string(charArray);
        Console.WriteLine(reversedNumber);
    }
}