using System;

abstract class Vehicle
{
    private double fuelQuantity;
    private double fuelConsumption;
    private double tankCapacity;

    public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumption = fuelConsumption;
        this.TankCapacity = tankCapacity;
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

    public double TankCapacity
    {
        get
        {
            return this.tankCapacity;
        }
        protected set
        {
            this.tankCapacity = value;
        }
    }

    public void Drive(double distance)
    {
        var liters = distance * this.FuelConsumption;
        this.FuelQuantity -= liters;
    }

    public virtual void Refuel(double liters)
    {
        if (liters <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}