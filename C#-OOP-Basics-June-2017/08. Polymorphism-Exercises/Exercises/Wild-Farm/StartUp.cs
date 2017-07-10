using System;

class StartUp
{
    static void Main()
    {
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            var animalInformation = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var foodInformation = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Animal currentAnimal = null;
            Food currentFood = null;

            var animalType = animalInformation[0];
            var animalName = animalInformation[1];
            var animalWeight = double.Parse(animalInformation[2]);
            var animalRegion = animalInformation[3];
            var animalBreed = string.Empty;

            if (animalType == "Cat")
            {
                animalBreed = animalInformation[4];
                currentAnimal = new Cat(animalName, animalType, animalWeight, animalRegion, animalBreed);
            }
            else
            {
                switch (animalType)
                {
                    case "Tiger":
                        currentAnimal = new Tiger(animalName, animalType, animalWeight, animalRegion);
                        break;
                    case "Zebra":
                        currentAnimal = new Zebra(animalName, animalType, animalWeight, animalRegion);
                        break;
                    case "Mouse":
                        currentAnimal = new Mouse(animalName, animalType, animalWeight, animalRegion);
                        break;
                }
            }

            var foodType = foodInformation[0];
            var foodAmount = int.Parse(foodInformation[1]);

            if (foodType == "Vegetable")
            {
                currentFood = new Vegetable(foodAmount);
            }
            else if (foodType == "Meat")
            {
                currentFood = new Meat(foodAmount);
            }

            Console.WriteLine(currentAnimal.MakeSound());

            try
            {
                currentAnimal.Eat(currentFood);
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }

            Console.WriteLine(currentAnimal);
        }
    }
}