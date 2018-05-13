public class Engine
{
    private int? displacement;

    public Engine(string model, int power)
    {
        this.Model = model;
        this.Power = power;
        this.displacement = null;
        this.Efficiency = null;
    }

    public Engine(string model, int power, int displacement)
        : this(model, power)
    {
        this.displacement = displacement;
    }

    public Engine(string model, int power, string efficiency)
        : this(model, power)
    {
        this.Efficiency = efficiency;
    }

    public Engine(string model, int power, int displacement, string efficiency)
        : this(model, power)
    {
        this.displacement = displacement;
        this.Efficiency = efficiency;
    }

    public int Power { get; }

    public string Model { get; }

    private string Efficiency { get; }

    public override string ToString()
    {
        var result = string.Empty;
        var displacementValue = this.displacement == null ? "n/a" : this.displacement.ToString();
        var efficiencyValue = this.Efficiency ?? "n/a";
        result += $"  {this.Model}:\n";
        result += $"    Power: {this.Power}\n";
        result += $"    Displacement: {displacementValue}\n";
        result += $"    Efficiency: {efficiencyValue}";
        return result;
    }
}