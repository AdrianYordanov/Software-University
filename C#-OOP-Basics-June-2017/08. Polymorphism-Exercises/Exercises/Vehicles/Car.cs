﻿class Car : Vehicle
{
    public Car(double fuelQuantity, double fuelConsumption)
        : base(fuelQuantity, fuelConsumption)
    {
        this.FuelConsumption += 0.9;
    }

    public override void Refuel(double liters)
    {
        this.FuelQuantity += liters;
    }
}