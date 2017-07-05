using System;

public class Topping
{
    private const int MinWeight = 1;
    private const int MaxWeight = 50;
    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public string Type
    {
        get
        {
            return this.type;
        }
        set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }

            this.type = value;
        }
    }

    public double Weight
    {
        get
        {
            return this.weight;
        }
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [{MinWeight}..{MaxWeight}].");
            }
            this.weight = value;
        }
    }

    public double GetCalories()
    {
        return 2 * this.Weight * this.GetTypeModifier();
    }

    private double GetTypeModifier()
    {
        switch (this.Type.ToLower())
        {
            case "veggies": return 0.8;
            case "sauce": return 0.9;
            case "cheese": return 1.1;
            default: return 1.2;
        }
    }
}