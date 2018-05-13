public class Car
{
    public Car(string model, Engine engine)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = null;
        this.Color = null;
    }

    public Car(string model, Engine engine, int weight)
        : this(model, engine)
    {
        this.Weight = weight;
    }

    public Car(string model, Engine engine, string color)
        : this(model, engine)
    {
        this.Color = color;
    }

    public Car(string model, Engine engine, int weight, string color)
        : this(model, engine)
    {
        this.Weight = weight;
        this.Color = color;
    }

    private string Model { get; }

    private Engine Engine { get; }

    private string Color { get; }

    private int? Weight { get; }

    public override string ToString()
    {
        var result = string.Empty;
        var weightValue = this.Weight == null ? "n/a" : this.Weight.ToString();
        var colorValue = this.Color ?? "n/a";
        result += $"{this.Model}:\n";
        result += $"{this.Engine}\n";
        result += $"  Weight: {weightValue}\n";
        result += $"  Color: {colorValue}";
        return result;
    }
}