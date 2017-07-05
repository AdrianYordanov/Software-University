using System;

public class Dough
{
    private const int MinWeight = 1;
    private const int MaxWeight = 200;
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public string FlourType
    {
        get
        {
            return this.flourType;
        }
        set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.flourType = value;
        }
    }

    public string BakingTechnique
    {
        get
        {
            return this.bakingTechnique;
        }
        set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            this.bakingTechnique = value;
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
                throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
            }
            this.weight = value;
        }
    }

    public double GetCalories()
    {
        return 2 * this.Weight * this.GetFlourModifier() * this.GetBakingModifier();
    }

    private double GetFlourModifier()
    {
        return this.FlourType.ToLower() == "white" ? 1.5 : 1;
    }

    private double GetBakingModifier()
    {
        switch (BakingTechnique.ToLower())
        {
            case "crispy": return 0.9;
            case "homemade": return 1.0;
            default: return 1.1;
        }
    }
}