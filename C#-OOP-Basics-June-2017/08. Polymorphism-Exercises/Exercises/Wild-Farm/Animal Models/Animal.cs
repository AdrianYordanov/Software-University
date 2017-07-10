abstract class Animal
{
    private string animalName;
    private string animalType;
    private double animalWeight;
    private int foodEaten;

    public Animal(string animalName, string animalType, double animalWeight)
    {
        this.AnimalName = animalName;
        this.AnimalType = animalType;
        this.AnimalWeight = animalWeight;
        this.FoodEaten = 0;
    }

    public int FoodEaten
    {
        get
        {
            return this.foodEaten;
        }
        protected set
        {
            this.foodEaten = value;
        }
    }

    public double AnimalWeight
    {
        get
        {
            return this.animalWeight;
        }
        protected set
        {
            this.animalWeight = value;
        }
    }

    public string AnimalType
    {
        get
        {
            return this.animalType;
        }
        protected set
        {
            this.animalType = value;
        }
    }

    public string AnimalName
    {
        get
        {
            return this.animalName;
        }
        protected set
        {
            this.animalName = value;
        }
    }

    public abstract string MakeSound();

    public abstract void Eat(Food food);
}