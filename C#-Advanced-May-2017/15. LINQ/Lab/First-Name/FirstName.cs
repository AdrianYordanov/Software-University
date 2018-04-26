using System;
using System.Linq;

public class FirstName
{
    private static void Main()
    {
        var names = Console.ReadLine().Split(' ').ToList();
        var letters = Console.ReadLine().Split(' ').Select(x => char.ToUpper(char.Parse(x))).ToArray();
        var result = names.Where(name => Array.IndexOf(letters, char.ToUpper(name[0])) >= 0)
            .OrderBy(x => x)
            .FirstOrDefault();
        Console.WriteLine(result ?? "No match");
    }
}