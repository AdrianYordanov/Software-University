using System;
using System.Text;
using System.Text.RegularExpressions;

public class ReplaceTagA
{
    private static void Main()
    {
        var html = new StringBuilder();
        var regex = new Regex(@"<a(\s+.*)>(.*)<\/a>");
        string input;
        while ((input = Console.ReadLine()) != "end")
        {
            html.AppendLine(input);
        }

        var result = regex.Replace(html.ToString(), "[URL$1]$2[/URL]");
        Console.WriteLine(result);
    }
}