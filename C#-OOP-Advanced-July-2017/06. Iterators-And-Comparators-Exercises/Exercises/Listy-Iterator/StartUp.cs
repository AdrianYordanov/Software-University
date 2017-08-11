using System;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var input = string.Empty;
        ListyIterator<string> listly = null;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(
                    new[]
                    {
                        ' '
                    },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var command = tokens[0];
            try
            {
                switch (command)
                {
                    case "Create":
                        listly = new ListyIterator<string>(tokens.Skip(1));
                        break;
                    case "Move":
                        Console.WriteLine(listly.Move());
                        break;
                    case "Print":
                        listly.Print();
                        break;
                    case "HasNext":
                        Console.WriteLine(listly.HasNext());
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}