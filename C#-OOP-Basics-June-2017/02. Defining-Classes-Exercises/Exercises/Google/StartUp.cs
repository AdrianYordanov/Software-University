using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        var input = string.Empty;
        var data = new Dictionary<string, Person>();

        while ((input = Console.ReadLine()) != "End")
        {
            var tokens = input.Split(' ');
            var name = tokens[0];
            var objectType = tokens[1];

            if (!data.ContainsKey(name))
            {
                data.Add(name, new Person(name));
            }

            switch (objectType)
            {
                case "company":
                    data[name].Company = new Company(tokens[2], tokens[3], decimal.Parse(tokens[4]));
                    break;
                case "pokemon":
                    data[name].Pokemons.Add(new Pokemon(tokens[2], tokens[3]));
                    break;
                case "parents":
                    data[name].Parents.Add(new Parent(tokens[2], tokens[3]));
                    break;
                case "children":
                    data[name].Children.Add(new Child(tokens[2], tokens[3]));
                    break;
                case "car":
                    data[name].Car = new Car(tokens[2], int.Parse(tokens[3]));
                    break;
            }
        }

        input = Console.ReadLine();
        Console.WriteLine(data[input]);
    }
}