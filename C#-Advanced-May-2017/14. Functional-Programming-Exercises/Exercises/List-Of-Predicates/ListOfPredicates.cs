using System;
using System.Linq;

public class ListOfPredicates
{
    private static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var sequence = Console.ReadLine().Split(' ');
        var predicates = sequence.Select(number => (Predicate<int>)(x => x % int.Parse(number) == 0)).ToArray();
        for (var candidateNumber = 1; candidateNumber <= n; candidateNumber++)
        {
            var isDivisible = true;
            foreach (var predicate in predicates)
            {
                if (!predicate(candidateNumber))
                {
                    isDivisible = false;
                    break;
                }
            }

            if (isDivisible)
            {
                Console.Write($"{candidateNumber} ");
            }
        }
    }
}