using System;
using System.Text;

abstract class Provider : AbstractEntity
{
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get
        {
            return this.energyOutput;
        }
        protected set
        {
            if (value <= 0 || value >= 10000)
            {
                throw new ArgumentException($"{nameof(EnergyOutput)}");
            }

            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        var name = this.GetType().ToString();
        name = name.Substring(0, name.IndexOf("Provider"));

        sb.AppendLine($"{name} Provider - {this.Id}");
        sb.Append($"Energy Output: {this.EnergyOutput}");
        return sb.ToString();
    }
}