using System;

class StartUp
{
    static void Main()
    {
        var gandalf = new Gandalf();
        var foodTokens = Console.ReadLine().Split(' ');

        foreach (var food in foodTokens)
        {
            gandalf.TakeFood(food.ToLower());
        }

        Console.WriteLine(gandalf);
    }
}