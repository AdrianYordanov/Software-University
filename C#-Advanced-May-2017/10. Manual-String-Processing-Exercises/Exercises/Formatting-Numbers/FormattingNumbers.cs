using System;

class FormattingNumbers
{
    static void Main()
    {
        var tokens = Console.ReadLine()
            .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var firstNumber = int.Parse(tokens[0]);
        var secondNumber = double.Parse(tokens[1]);
        var thirdNumber = double.Parse(tokens[2]);

        var binary = Convert.ToString(firstNumber, 2).PadLeft(10, '0');

        Console.WriteLine(string.Format("|{0,-10:X}|{1}|{2,10:F2}|{3,-10:F3}|",
            firstNumber,
            binary.Substring(0, 10),
            secondNumber,
            thirdNumber));
    }
}