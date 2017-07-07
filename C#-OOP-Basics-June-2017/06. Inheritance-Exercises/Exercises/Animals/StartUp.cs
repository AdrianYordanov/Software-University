using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        var animals = new List<Animal>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "Beast!")
        {
            try
            {
                var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var gender = tokens[2];
                var age = 0;

                if (!int.TryParse(tokens[1], out age))
                {
                    throw new ArgumentException("Invalid input!");
                }

                switch (input)
                {
                    case "Cat":
                        animals.Add(new Cat(name, age, gender));
                        break;

                    case "Tomcat":
                        animals.Add(new Tomcat(name, age));
                        break;

                    case "Kitten":
                        animals.Add(new Kitten(name, age));
                        break;

                    case "Frog":
                        animals.Add(new Frog(name, age, gender));
                        break;

                    case "Dog":
                        animals.Add(new Dog(name, age, gender));
                        break;

                    default:
                        throw new ArgumentException("Invalid input!");
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        foreach (var animal in animals)
        {
            Console.WriteLine(animal);
        }
    }
}