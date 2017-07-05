class Siamese : Cat
{
    private int earSize;

    public Siamese(string name, int size) : base(name)
    {
        this.EarSize = size;
    }

    public int EarSize
    {
        get { return this.earSize; }
        private set { this.earSize = value; }
    }

    public override string ToString()
    {
        return $"Siamese {base.Name} {this.EarSize}";
    }
}