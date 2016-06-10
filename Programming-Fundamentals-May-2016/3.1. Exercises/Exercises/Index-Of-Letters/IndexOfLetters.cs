using System;
using System.Linq;

class IndexOfLetters
{
    static void Main()
    {
        var alphabeticArray = CreateAlphabeticArray();
        var inputString = Console.ReadLine();

        for (int i = 0; i < inputString.Length; i++)
        {
            var index = Array.IndexOf(alphabeticArray, inputString[i]);

            if(index >= 0)
            {
                Console.WriteLine("{0} -> {1}", inputString[i], index);
            }
        }
    }

    static char[] CreateAlphabeticArray()
    {
        var array = new char[(122 - 97) + 1];
        byte index = 0;

        for (char word = 'a'; word <= 122; word++, index++)
		{
            array[index] = word;
        }

        return array;
    }
}