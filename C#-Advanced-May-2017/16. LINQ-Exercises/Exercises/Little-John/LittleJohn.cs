using System;

class LittleJohn
{
    static void Main()
    {
        var largeArrow = ">>>----->>";
        var mediumArrow = ">>----->";
        var smallArrow = ">----->";
        var input = string.Empty;

        for (int i = 0; i < 4; i++)
        {
            input += " " + Console.ReadLine();
        }

        var countLarge = GetCountOfString(input, largeArrow);
        input = input.Replace(largeArrow, " ");

        var countMedium = GetCountOfString(input, mediumArrow);
        input = input.Replace(mediumArrow, " ");

        var countSmall = GetCountOfString(input, smallArrow);
        input = input.Replace(smallArrow, " ");

        var numberDec = countSmall.ToString() + countMedium.ToString() + countLarge.ToString();

        var numberBin = Convert.ToString(Convert.ToInt64(numberDec, 10), 2);

        numberBin = numberBin + ReverseString(numberBin);
        var result = Convert.ToString(Convert.ToInt64(numberBin, 2), 10);

        Console.WriteLine(result);
    }

    public static int GetCountOfString(string stringToCheckIn, string stringToLookFor)
    {
        var count = 0;
        var index = stringToCheckIn.IndexOf(stringToLookFor);

        while (index >= 0)
        {
            count++;
            index = stringToCheckIn.IndexOf(stringToLookFor, index + stringToLookFor.Length);
        }

        return count;
    }

    public static string ReverseString(string inputString)
    {
        var outputString = string.Empty;

        for (int i = 0; i < inputString.Length; i++)
        {
            outputString = inputString[i] + outputString;
        }

        return outputString;
    }
}