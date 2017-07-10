class Cat : Feline
{
    private string breed;

    public Cat(string animalName, string animalType, double animalWeight, string livingRegion, string catBreed)
        : base(animalName, animalType, animalWeight, livingRegion)
    {
        this.Breed = catBreed;
    }

    public string Breed
    {
        get
        {
            return this.breed;
        }
        private set
        {
            this.breed = value;
        }
    }

    public override string MakeSound()
    {
        return "Meowwww";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
    }
}