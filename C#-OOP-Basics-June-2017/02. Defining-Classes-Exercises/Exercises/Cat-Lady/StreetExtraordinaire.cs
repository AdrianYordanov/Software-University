class StreetExtraordinaire : Cat
{
    private int meowingLoudness;

    public StreetExtraordinaire(string name, int loudness) : base(name)
    {
        this.MeowingLoudness = loudness;
    }

    public int MeowingLoudness
    {
        get { return this.meowingLoudness; }
        private set { this.meowingLoudness = value; }
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {base.Name} {this.meowingLoudness}";
    }
}