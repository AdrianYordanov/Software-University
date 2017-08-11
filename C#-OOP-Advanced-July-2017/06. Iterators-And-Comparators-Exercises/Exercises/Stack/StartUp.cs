using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var input = string.Empty;
        var myStack = new CustomStack<int>();
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(
                    new[]
                    {
                        ' ',
                        ','
                    },
                    StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var command = tokens[0];
            var numbers = tokens.Skip(1).Select(int.Parse).ToArray();
            try
            {
                switch (command)
                {
                    case "Push":
                        foreach (var num in numbers)
                        {
                            myStack.Push(num);
                        }

                        break;
                    case "Pop":
                        myStack.Pop();
                        break;
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        if (myStack.Any())
        {
            for (var i = 0; i < 2; i++)
            {
                Console.WriteLine(string.Join(Environment.NewLine, myStack));
            }
        }
    }
}