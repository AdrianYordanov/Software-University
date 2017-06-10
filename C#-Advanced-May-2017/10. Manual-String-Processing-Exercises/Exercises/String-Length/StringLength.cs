using System;

class StringLength
{
    static void Main()
    {
        var input = Console.ReadLine();
        var length = input.Length <= 20 ? input.Length : 20;
        input = input.Substring(0, length);
        Console.WriteLine(input.PadRight(20, '*'));
    }
}
