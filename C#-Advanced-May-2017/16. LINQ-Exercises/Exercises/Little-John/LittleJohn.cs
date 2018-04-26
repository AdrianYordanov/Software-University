using System;

public class LittleJohn
{
    private static int GetCountOfString(string stringToCheckIn, string stringToLookFor)
    {
        var count = 0;
        var index = stringToCheckIn.IndexOf(stringToLookFor, StringComparison.Ordinal);
        while (index >= 0)
        {
            count++;
            index = stringToCheckIn.IndexOf(stringToLookFor, index + stringToLookFor.Length, StringComparison.Ordinal);
        }

        return count;
    }

    private static void Main()
    {
        var largeArrow = ">>>----->>";
        var mediumArrow = ">>----->";
        var smallArrow = ">----->";
        var input = string.Empty;
        for (var i = 0; i < 4; i++)
        {
            input += " " + Console.ReadLine();
        }

        var countLarge = GetCountOfString(input, largeArrow);
        input = input.Replace(largeArrow, " ");
        var countMedium = GetCountOfString(input, mediumArrow);
        input = input.Replace(mediumArrow, " ");
        var countSmall = GetCountOfString(input, smallArrow);
        var numberDec = countSmall.ToString() + countMedium + countLarge;
        var numberBin = Convert.ToString(Convert.ToInt64(numberDec, 10), 2);
        numberBin = numberBin + ReverseString(numberBin);
        var result = Convert.ToString(Convert.ToInt64(numberBin, 2), 10);
        Console.WriteLine(result);
    }

    private static string ReverseString(string inputString)
    {
        var outputString = string.Empty;
        foreach (var character in inputString)
        {
            outputString = character + outputString;
        }

        return outputString;
    }
}