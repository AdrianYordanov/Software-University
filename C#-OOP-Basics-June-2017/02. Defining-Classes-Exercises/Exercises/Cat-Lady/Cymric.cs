public class Cymric : Cat
{
    public Cymric(string name, double furLength)
        : base(name)
    {
        this.FurLength = furLength;
    }

    private double FurLength { get; }

    public override string ToString()
    {
        return $"Cymric {this.Name} {this.FurLength:f2}";
    }
}