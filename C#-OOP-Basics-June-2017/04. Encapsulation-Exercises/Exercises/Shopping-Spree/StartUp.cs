using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var people = new List<Person>();
        var prodcuts = new List<Product>();

        try
        {
            var peopleTokens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var productsTokens = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in peopleTokens)
            {
                var name = token.Split('=')[0];
                var money = decimal.Parse(token.Split('=')[1]);
                people.Add(new Person(name, money));
            }

            foreach (var token in productsTokens)
            {
                var name = token.Split('=')[0];
                var cost = decimal.Parse(token.Split('=')[1]);
                prodcuts.Add(new Product(name, cost));
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                var commandTokens = input.Split(' ');
                var person = people.FirstOrDefault(p => p.Name == commandTokens[0]);
                var product = prodcuts.FirstOrDefault(p => p.Name == commandTokens[1]);
                Console.WriteLine(person.TryMakeOrder(product));
            }

            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}