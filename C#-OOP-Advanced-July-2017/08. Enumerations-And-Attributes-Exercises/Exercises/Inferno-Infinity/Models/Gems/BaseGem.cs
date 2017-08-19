using System;

public abstract class BaseGem : IBaseGem
{
    private int agilityBonus;
    private Clarity clarity;
    private int strengthBonus;
    private int vitalityBonus;

    protected BaseGem(string clarity)
    {
        this.Clarity = (Clarity)Enum.Parse(typeof(Clarity), clarity);
    }

    public int AgilityBonus
    {
        get => this.agilityBonus;
        protected set => this.agilityBonus = value;
    }

    public Clarity Clarity
    {
        get => this.clarity;
        protected set => this.clarity = value;
    }

    public int StrengthBonus
    {
        get => this.strengthBonus;
        protected set => this.strengthBonus = value;
    }

    public int VitalityBonus
    {
        get => this.vitalityBonus;
        protected set => this.vitalityBonus = value;
    }

    public void AddClarityBonuses()
    {
        this.StrengthBonus += (int)this.Clarity;
        this.AgilityBonus += (int)this.Clarity;
        this.VitalityBonus += (int)this.Clarity;
    }

    public DmgBoost CalculateDamageBoost()
    {
        var minDmgBoost = 0;
        var maxDmgBoost = 0;
        minDmgBoost = this.StrengthBonus * 2;
        maxDmgBoost = this.StrengthBonus * 3;
        minDmgBoost += this.AgilityBonus * 1;
        maxDmgBoost += this.AgilityBonus * 4;
        return new DmgBoost(minDmgBoost, maxDmgBoost);
    }
}