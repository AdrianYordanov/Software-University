public class Siamese : Cat
{
    public Siamese(string name, int earSize)
        : base(name)
    {
        this.EarSize = earSize;
    }

    private int EarSize { get; }

    public override string ToString()
    {
        return $"Siamese {this.Name} {this.EarSize}";
    }
}