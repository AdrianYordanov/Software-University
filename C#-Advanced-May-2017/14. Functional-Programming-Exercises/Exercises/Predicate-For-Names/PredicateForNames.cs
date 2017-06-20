using System;
using System.Linq;

class PredicateForNames
{
    static void Main()
    {
        var length = int.Parse(Console.ReadLine());
        var names = Console.ReadLine()
            .Split(' ')
            .ToList();

        Predicate<string> checkName = (name) =>
        {
            return name.Length <= length;
        };

        var result = names.Where(name => checkName(name));
        Console.WriteLine(string.Join(Environment.NewLine, result));
    }
}