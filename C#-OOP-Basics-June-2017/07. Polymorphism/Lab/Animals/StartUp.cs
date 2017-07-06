using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        var animals = new List<Animal>();
        animals.Add(new Cat("Pesho", "Whiskas"));
        animals.Add(new Dog("Gosho", "Meat"));

        foreach (var animal in animals)
        {
            Console.WriteLine(animal.ExplainMyself());
        }
    }
}