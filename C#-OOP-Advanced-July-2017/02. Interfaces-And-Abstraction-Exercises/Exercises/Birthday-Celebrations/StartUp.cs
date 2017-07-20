using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var data = new List<IName>();
        var input = string.Empty;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(' ');
            var type = tokens[0];
            var name = tokens[1];
            switch (type)
            {
                case "Robot":
                    data.Add(new Robot(name, tokens[2]));
                    break;
                case "Pet":
                    data.Add(new Pet(name, tokens[2]));
                    break;
                case "Citizen":
                    data.Add(new Citizen(name, int.Parse(tokens[2]), tokens[3], tokens[4]));
                    break;
            }
        }

        input = Console.ReadLine();
        var wantedIdentifiables = data
            .OfType<IBirthdate>()
            .Where(x => x.Birthdate.EndsWith(input))
            .Select(x => x.Birthdate);
        Console.WriteLine(string.Join(Environment.NewLine, wantedIdentifiables));
    }
}