using System;

class Bus : Vehicle
{
    public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        : base(fuelQuantity, fuelConsumption, tankCapacity)
    {
        this.FuelConsumption += 1.4;
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

    public void DriveEmpty(double distance)
    {
        this.FuelConsumption -= 1.4;
        this.Drive(distance);
        this.FuelConsumption += 1.4;
    }
}