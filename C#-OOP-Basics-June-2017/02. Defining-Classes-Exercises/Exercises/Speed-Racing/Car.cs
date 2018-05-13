public class Car
{
    public Car(string model, double fuelAmount, double consumptionPerKilometer)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.CosumptionPerKilometer = consumptionPerKilometer;
        this.DistanceTravelled = 0;
    }

    private string Model { get; }

    private double CosumptionPerKilometer { get; }

    private double FuelAmount { get; set; }

    private int DistanceTravelled { get; set; }

    public bool CanTravelDistance(int distance)
    {
        var consumptionForTheTraveling = distance * this.CosumptionPerKilometer;
        if (consumptionForTheTraveling <= this.FuelAmount)
        {
            this.FuelAmount -= consumptionForTheTraveling;
            this.DistanceTravelled += distance;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.Model} {this.FuelAmount:F2} {this.DistanceTravelled}";
    }
}