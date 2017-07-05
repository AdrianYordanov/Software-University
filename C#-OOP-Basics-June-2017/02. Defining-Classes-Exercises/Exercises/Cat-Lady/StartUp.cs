using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var cats = new List<Cat>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "Siamese":
                    Siamese newSiam = new Siamese(tokens[1], int.Parse(tokens[2]));
                    cats.Add(newSiam);
                    break;

                case "Cymric":
                    Cymric newCym = new Cymric(tokens[1], double.Parse(tokens[2]));
                    cats.Add(newCym);
                    break;

                case "StreetExtraordinaire":
                    StreetExtraordinaire newExtra = new StreetExtraordinaire(tokens[1], int.Parse(tokens[2]));
                    cats.Add(newExtra);
                    break;
            }
        }

        var targetCatName = Console.ReadLine();
        var targetCat = cats.FirstOrDefault(x => x.Name == targetCatName);
        Console.WriteLine(targetCat);
    }
}