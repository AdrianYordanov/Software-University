using System;

public class StartUp
{
    public static void Main()
    {
        var linkedList = new MyLinkedList<int>();
        var n = int.Parse(Console.ReadLine());
        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(
                    new[]
                    {
                        ' '
                    },
                    StringSplitOptions.RemoveEmptyEntries);
            if (tokens[0] == "Add")
            {
                linkedList.Add(int.Parse(tokens[1]));
            }
            else if (tokens[0] == "Remove")
            {
                var number = int.Parse(tokens[1]);
                var removeIndex = linkedList.FirstIndexOf(number);
                if (removeIndex > -1)
                {
                    linkedList.Remove(linkedList.FirstIndexOf(number));
                }
            }
        }

        Console.WriteLine(linkedList.Count);
        Console.WriteLine(string.Join(" ", linkedList));
    }
}