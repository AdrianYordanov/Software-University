using System;
using System.Linq;

class PredicateParty
{
    static void Main()
    {
        var names = Console.ReadLine().Split(' ').ToList();
        var line = string.Empty;

        while ((line = Console.ReadLine()) != "Party!")
        {
            var tokens = line.Split(' ');
            var command = tokens[0];
            var criteria = tokens[1];
            var parameter = tokens[2];

            Predicate<string> startsWith = str => str.StartsWith(parameter);
            Predicate<string> endsWith = str => str.EndsWith(parameter);
            Predicate<string> legthIs = str => str.Length == int.Parse(parameter);

            if (command == "Double")
            {
                switch (criteria)
                {
                    case "StartsWith":
                        {
                            for (int i = 0; i < names.Count; i++)
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
                            for (int i = 0; i < names.Count; i++)
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
                            for (int i = 0; i < names.Count; i++)
                            {
                                if (legthIs(names[i]))
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
                    case "StartsWith": names.RemoveAll(startsWith); break;
                    case "EndsWith": names.RemoveAll(endsWith); break;
                    case "Length": names.RemoveAll(legthIs); break;
                }
            }
        }

        if (names.Count == 0)
        {
            Console.WriteLine("Nobody is going to the party!");
        }
        else
        {
            Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
        }
    }
}