using System;

class LettersChangeNumbers
{
    static void Main()
    {
        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        var input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var result = 0.0d;

        foreach (var expression in input)
        {
            var firstLetter = expression[0];
            var secondLetter = expression[expression.Length - 1];
            var number = double.Parse(expression.Substring(1, expression.Length - 2));

            number = char.IsUpper(firstLetter) ? number /= Array.IndexOf(alpha, firstLetter) + 1 : number *= Array.IndexOf(alpha, char.ToUpper(firstLetter)) + 1;
            number = char.IsUpper(secondLetter) ? number -= Array.IndexOf(alpha, secondLetter) + 1 : number += Array.IndexOf(alpha, char.ToUpper(secondLetter)) + 1;

            result += number;
        }

        Console.WriteLine(string.Format("{0:F2}", result));
    }
}