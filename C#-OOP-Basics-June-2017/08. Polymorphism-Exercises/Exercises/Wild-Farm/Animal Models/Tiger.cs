class Tiger : Feline
{
    public Tiger(string animalName, string animalType, double animalWeight, string livingRegion)
        : base(animalName, animalType, animalWeight, livingRegion)
    { }

    public override string MakeSound()
    {
        return "ROAAR!!!";
    }
}