using System;
using System.Linq;

public class PredicateForNames
{
    private static void Main()
    {
        var length = int.Parse(Console.ReadLine());
        var names = Console.ReadLine().Split(' ').ToList();
        Predicate<string> checkName = name => name.Length <= length;
        var result = names.Where(name => checkName(name));
        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}