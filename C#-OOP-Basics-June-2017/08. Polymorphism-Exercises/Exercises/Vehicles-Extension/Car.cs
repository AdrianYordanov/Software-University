using System;

class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
        this.FuelConsumption += 0.9;
    }

    public override void Refuel(double liters)
    {
        base.Refuel(liters);

        if (liters > this.TankCapacity - this.FuelQuantity)
        {
            throw new ArgumentException("Cannot fit fuel in tank");
        }

        this.FuelQuantity += liters;
    }
}