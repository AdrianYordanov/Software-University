using System;

public class ParseTags
{
    private static void Main()
    {
        var openCase = "<upcase>";
        var closeCase = "</upcase>";
        var input = Console.ReadLine();
        var openIndex = input.IndexOf(openCase, StringComparison.Ordinal);
        while (openIndex != -1)
        {
            var closeIndex = input.IndexOf(closeCase, StringComparison.Ordinal);
            if (closeIndex == -1)
            {
                break;
            }

            var changeCase = input.Substring(openIndex, (closeIndex - openIndex) + closeCase.Length);
            var upperCase = changeCase.Replace(openCase, string.Empty).Replace(closeCase, string.Empty).ToUpper();
            input = input.Replace(changeCase, upperCase);
            openIndex = input.IndexOf(openCase, StringComparison.Ordinal);
        }

        Console.WriteLine(input);
    }
}