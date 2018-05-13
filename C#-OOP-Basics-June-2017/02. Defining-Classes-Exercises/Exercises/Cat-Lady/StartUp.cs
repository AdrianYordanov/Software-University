using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static void Main()
    {
        var cats = new List<Cat>();
        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (tokens[0])
            {
                case "Siamese":
                    var newSiam = new Siamese(tokens[1], int.Parse(tokens[2]));
                    cats.Add(newSiam);
                    break;
                case "Cymric":
                    var newCym = new Cymric(tokens[1], double.Parse(tokens[2]));
                    cats.Add(newCym);
                    break;
                case "StreetExtraordinaire":
                    var newExtra = new StreetExtraordinaire(tokens[1], int.Parse(tokens[2]));
                    cats.Add(newExtra);
                    break;
            }
        }

        var targetCatName = Console.ReadLine();
        var targetCat = cats.FirstOrDefault(x => x.Name == targetCatName);
        Console.WriteLine(targetCat);
    }
}