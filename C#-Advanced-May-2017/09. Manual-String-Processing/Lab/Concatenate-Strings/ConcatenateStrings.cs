using System;
using System.Text;

public class ConcatenateStrings
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sb = new StringBuilder();
        for (var i = 0; i < n; i++)
        {
            var input = Console.ReadLine();
            sb.Append(string.Concat(input, " "));
        }

        Console.WriteLine(sb);
    }
}