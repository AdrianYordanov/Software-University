class Truck : Vehicle
{
    public Truck(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
        this.FuelConsumption += 1.6;
    }

    public override void Refuel(double liters)
    {
        this.FuelQuantity += liters * 0.95;
    }
}