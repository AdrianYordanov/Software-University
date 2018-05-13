public class StreetExtraordinaire : Cat
{
    public StreetExtraordinaire(string name, int loudness)
        : base(name)
    {
        this.MeowingLoudness = loudness;
    }

    private int MeowingLoudness { get; }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.MeowingLoudness}";
    }
}