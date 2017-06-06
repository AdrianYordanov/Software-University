using System;
using System.Text;

class ConcatenateStrings
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            sb.Append(string.Concat(input, " "));
        }

        Console.WriteLine(sb);
    }
}