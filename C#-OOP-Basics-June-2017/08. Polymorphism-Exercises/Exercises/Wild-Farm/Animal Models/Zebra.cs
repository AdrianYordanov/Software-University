class Zebra : Mammal
{
    public Zebra(string animalName, string animalType, double animalWeight, string livingRegion)
        : base(animalName, animalType, animalWeight, livingRegion)
    { }

    public override string MakeSound()
    {
        return "Zs";
    }
}