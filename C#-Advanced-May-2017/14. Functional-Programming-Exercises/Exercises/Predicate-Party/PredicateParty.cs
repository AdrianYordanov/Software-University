using System;
using System.Linq;

public class PredicateParty
{
    private static void Main()
    {
        var names = Console.ReadLine().Split(' ').ToList();
        string line;
        while ((line = Console.ReadLine()) != "Party!")
        {
            var tokens = line.Split(' ');
            var command = tokens[0];
            var criteria = tokens[1];
            var parameter = tokens[2];
            Predicate<string> startsWith = str => str.StartsWith(parameter);
            Predicate<string> endsWith = str => str.EndsWith(parameter);
            Predicate<string> lengthIs = str => str.Length == int.Parse(parameter);
            if (command == "Double")
            {
                switch (criteria)
                {
                    case "StartsWith":
                        {
                            for (var i = 0; i < names.Count; i++)
                            {
                                if (startsWith(names[i]))
                                {
                                    names.Insert(i, names[i++]);
                                }
                            }

                            break;
                        }

                    case "EndsWith":
                        {
                            for (var i = 0; i < names.Count; i++)
                            {
                                if (endsWith(names[i]))
                                {
                                    names.Insert(i, names[i++]);
                                }
                            }

                            break;
                        }

                    case "Length":
                        {
                            for (var i = 0; i < names.Count; i++)
                            {
                                if (lengthIs(names[i]))
                                {
                                    names.Insert(i, names[i++]);
                                }
                            }

                            break;
                        }
                }
            }
            else if (command == "Remove")
            {
                switch (criteria)
                {
                    case "StartsWith":
                        names.RemoveAll(startsWith);
                        break;
                    case "EndsWith":
                        names.RemoveAll(endsWith);
                        break;
                    case "Length":
                        names.RemoveAll(lengthIs);
                        break;
                }
            }
        }

        Console.WriteLine(
            names.Count == 0 ? "Nobody is going to the party!" : $"{string.Join(", ", names)} are going to the party!");
    }
}