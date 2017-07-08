using System;

abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;

    public Vehicle(double fuelQuantity, double fuelConsumption)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
    }

    public double FuelQuantity
    {
        get
        {
            return this.fuelQuantity;
        }
        protected set
        {
            if (value < 0)
            {
                throw new InvalidOperationException($"{this.GetType()} needs refueling");
            }

            this.fuelQuantity = value;
        }
    }

    public double FuelConsumption
    {
        get
        {
            return this.fuelConsumption;
        }
        protected set
        {
            this.fuelConsumption = value;
        }
    }

    public void Drive(double distance)
    {
        var liters = distance * this.FuelConsumption;
        this.FuelQuantity -= liters;
    }

    public abstract void Refuel(double liters);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}