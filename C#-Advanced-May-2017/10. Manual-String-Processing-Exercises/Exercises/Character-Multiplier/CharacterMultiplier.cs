using System;

class CharacterMultiplier
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var firstString = tokens[0];
        var secondString = tokens[1];
        var result = 0;

        for (int i = 0; i < firstString.Length || i < secondString.Length; i++)
        {
            if (i < firstString.Length && i < secondString.Length)
            {
                result += MultiplyCharacters(firstString[i], secondString[i]);
            }
            else if (i < firstString.Length)
            {
                result += firstString[i];
            }
            else
            {
                result += secondString[i];
            }
        }

        Console.WriteLine(result);
    }

    static int MultiplyCharacters(char first, char second)
    {
        return first * second;
    }
}