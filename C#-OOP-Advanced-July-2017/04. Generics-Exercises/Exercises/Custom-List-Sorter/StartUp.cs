using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var list = new CustomList<string>();
        var inputLine = string.Empty;
        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var command = tokens[0];
            tokens.Remove(tokens.First());
            switch (command)
            {
                case "Add":
                    list.Add(tokens[0]);
                    break;

                case "Remove":
                    list.Remove(int.Parse(tokens[0]));
                    break;

                case "Contains":
                    Console.WriteLine(list.Contains(tokens[0]));
                    break;

                case "Swap":
                    list.Swap(int.Parse(tokens[0]), int.Parse(tokens[1]));
                    break;

                case "Greater":
                    Console.WriteLine(list.CountGreaterThan(tokens[0]));
                    break;

                case "Max":
                    Console.WriteLine(list.Max());
                    break;

                case "Min":
                    Console.WriteLine(list.Min());
                    break;

                case "Print":
                    foreach (var item in list)
                    {
                        Console.WriteLine(item);
                    }

                    break;

                case "Sort":
                    Sorter.Sort(list);
                    break;
            }
        }
    }
}