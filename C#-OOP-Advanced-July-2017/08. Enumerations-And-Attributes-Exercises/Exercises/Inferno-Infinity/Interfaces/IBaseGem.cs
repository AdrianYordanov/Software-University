public interface IBaseGem
{
    int AgilityBonus
    {
        get;
    }

    Clarity Clarity
    {
        get;
    }

    int StrengthBonus
    {
        get;
    }

    int VitalityBonus
    {
        get;
    }

    void AddClarityBonuses();

    DmgBoost CalculateDamageBoost();
}