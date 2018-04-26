using System;
using System.Collections.Generic;

public class Palindromes
{
    private static void Main()
    {
        var words = Console.ReadLine().Split(new[] { ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
        var palindromes = new SortedSet<string>();
        foreach (var word in words)
        {
            var toArray = word.ToCharArray();
            Array.Reverse(toArray);
            var reversed = new string(toArray);
            if (word.Equals(reversed))
            {
                palindromes.Add(word);
            }
        }

        Console.WriteLine($"[{string.Join(", ", palindromes)}]");
    }
}