using System;

abstract class Mammal : Animal
{
    private string livingRegion;

    public Mammal(string animalName, string animalType, double animalWeight, string livingRegion) 
        : base(animalName, animalType, animalWeight)
    {
        this.LivingRegion = livingRegion;
    }

    public string LivingRegion
    {
        get
        {
            return this.livingRegion;
        }
        protected set
        {
            this.livingRegion = value;
        }
    }

    public override void Eat(Food food)
    {
        string animalType = this.GetType().Name;
        string foodType = food.GetType().Name;

        if ((animalType == "Zebra" || animalType == "Mouse") && foodType != "Vegetable")
        {
            throw new InvalidOperationException($"{animalType}s are not eating that type of food!");
        }

        if (animalType == "Tiger" && foodType != "Meat")
        {
            throw new InvalidOperationException($"{animalType}s are not eating that type of food!");
        }

        this.FoodEaten += food.Quantity;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}