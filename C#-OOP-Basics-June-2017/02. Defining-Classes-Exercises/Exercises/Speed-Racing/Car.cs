class Car
{
    private string model;
    private double fuelAmount;
    private double cosumptionPerKilometer;
    private int distanceTravelled;

    public Car(string model, double fuelAmount, double consumptionPerKilometer)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.cosumptionPerKilometer = consumptionPerKilometer;
        this.distanceTravelled = 0;
    }

    public bool CanTravelDistance(int distance)
    {
        var consumptionForTheTraveling = distance * this.cosumptionPerKilometer;

        if (consumptionForTheTraveling <= this.fuelAmount)
        {
            this.fuelAmount -= consumptionForTheTraveling;
            this.distanceTravelled += distance;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.model} {this.fuelAmount:F2} {this.distanceTravelled}";
    }
}