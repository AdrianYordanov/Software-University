using System;
using System.Text;

abstract class Harvester : AbstractEntity
{
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get
        {
            return this.oreOutput;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(OreOutput)}");
            }

            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get
        {
            return this.energyRequirement;
        }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"{nameof(EnergyRequirement)}"); ;
            }

            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var name = this.GetType().ToString();
        var index = name.IndexOf("Harvester");
        name = name.Substring(0, index);

        sb.AppendLine($"{name} Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.Append($"Energy Requirement: {this.EnergyRequirement}");
        return sb.ToString();
    }
}