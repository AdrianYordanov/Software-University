using System;
using System.Linq;

public class TriFunction
{
    private static void Main()
    {
        Func<string, int, bool> isCorrectName = (name, checkLength) =>
        {
            var sum = 0;
            foreach (var character in name)
            {
                sum += character;
            }

            return sum >= checkLength;
        };
        Func<Func<string, int, bool>, string, int, string> getName = (condtionFunc, namesAsString, checkLength) =>
        {
            return namesAsString.Split(' ').FirstOrDefault(name => condtionFunc(name, checkLength));
        };
        var length = int.Parse(Console.ReadLine());
        Console.WriteLine(getName(isCorrectName, Console.ReadLine(), length));
    }
}