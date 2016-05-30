using System;

class VowelOrDigit
{
    static void Main()
    {
        char character = char.Parse(Console.ReadLine());
        bool isVowel = "aeiouAEIOU".IndexOf(character) >= 0;
        bool isDigit = char.IsDigit(character);

        if (isVowel)
        {
            Console.WriteLine("vowel");
        }
        else
        {
            if (isDigit)
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}