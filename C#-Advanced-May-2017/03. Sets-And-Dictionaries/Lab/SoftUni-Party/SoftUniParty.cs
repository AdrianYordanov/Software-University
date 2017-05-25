using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SoftUniParty
{
    static void Main()
    {
        var input = string.Empty;
        var guestes = new SortedSet<string>();

        while ((input = Console.ReadLine()) != "PARTY")
        {
            guestes.Add(input);
        }


        while ((input = Console.ReadLine()) != "END")
        {
            if (guestes.Contains(input))
            {
                // The person is going.
                guestes.Remove(input);
            }
        }

        Console.WriteLine(guestes.Count);

        foreach (var personNumber in guestes)
        {
            Console.WriteLine(personNumber);
        }
    }
}
