public class Sword : Weapon
{
    public Sword(string weaponType, string rarity, string name)
        : base(weaponType, rarity, name)
    {
        this.MinDamage = 4;
        this.MaxDamage = 6;
        this.Sockets = new IBaseGem[3];
        this.AddRarityBonuses();
    }
}