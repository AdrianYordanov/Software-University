using System;

class StartUp
{
    static void Main()
    {
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(' ');

            try
            {
                switch (tokens[0])
                {
                    case "Dough":
                        var dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));
                        Console.WriteLine($"{dough.GetCalories():f2}");
                        break;
                    case "Topping":
                        var topping = new Topping(tokens[1], double.Parse(tokens[2]));
                        Console.WriteLine($"{topping.GetCalories():f2}");
                        break;
                    case "Pizza":
                        MakePizza(tokens);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }

    public static void MakePizza(string[] inParams)
    {
        var numberToppings = int.Parse(inParams[2]);
        var pizza = new Pizza(inParams[1], numberToppings);

        var doughInfo = Console.ReadLine().Split(' ');
        var dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
        pizza.Dough = dough;

        for (var i = 0; i < numberToppings; i++)
        {
            var toppingTokens = Console.ReadLine().Split(' ');
            var topping = new Topping(toppingTokens[1], double.Parse(toppingTokens[2]));
            pizza.AddTopping(topping);
        }

        Console.WriteLine($"{pizza.Name} - {pizza.GetCalories():f2} Calories.");
    }
}