class Mouse : Mammal
{
    public Mouse(string animalName, string animalType, double animalWeight, string livingRegion)
        : base(animalName, animalType, animalWeight, livingRegion)
    { }

    public override string MakeSound()
    {
        return "SQUEEEAAAK!";
    }
}