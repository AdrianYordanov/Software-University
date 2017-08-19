public class DmgBoost : IDmgBoost
{
    private int minDamageBoost;
    private int maxDamageBoost;

    public DmgBoost(int minDmgBoost, int maxDamageBoost)
    {
        this.MinDamageBoost = minDmgBoost;
        this.MaxDamageBoost = maxDamageBoost;
    }

    public int MinDamageBoost
    {
        get => this.minDamageBoost;
        private set => this.minDamageBoost = value;
    }

    public int MaxDamageBoost
    {
        get => this.maxDamageBoost;
        private set => this.maxDamageBoost = value;
    }
}