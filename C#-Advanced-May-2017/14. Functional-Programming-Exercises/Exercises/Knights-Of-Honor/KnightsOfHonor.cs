using System;
using System.Linq;

public class KnightsOfHonor
{
    private static void Main()
    {
        Action<string> print = inputString =>
            {
                var result = inputString.Split(' ').Select(x => $"Sir {x}");
                Console.WriteLine(string.Join(Environment.NewLine, result));
            };
        print(Console.ReadLine());
    }
}