using System;
using System.Linq;

class KnightsOfHonor
{
    static void Main()
    {
        Action<string> print = (inputString) =>
        {
            var result = inputString.Split(' ')
            .Select(x => x = $"Sir {x}");
            Console.WriteLine(string.Join(Environment.NewLine, result));
        };

        print(Console.ReadLine());
    }
}
