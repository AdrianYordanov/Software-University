using System;

class ReverseCharacters
{
    static void Main()
    {
        char ch1 = char.Parse(Console.ReadLine());
        char ch2 = char.Parse(Console.ReadLine());
        char ch3 = char.Parse(Console.ReadLine());

        string result = string.Empty + ch3 + ch2 + ch1;
        Console.WriteLine(result);
    }
}