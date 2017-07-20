using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var data = new List<IIdentifiable>();
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(' ');
            if (tokens.Length == 2)
            {
                data.Add(new Robot(tokens[0], tokens[1]));
            }
            else if (tokens.Length == 3)
            {
                data.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
            }
        }

        input = Console.ReadLine();
        var wantedIdentifiables = data
            .Where(x => x.Id.EndsWith(input))
            .Select(x => x.Id);
        Console.WriteLine(string.Join(Environment.NewLine, wantedIdentifiables));
    }
}