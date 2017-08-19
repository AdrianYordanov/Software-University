﻿public class Knife : Weapon
{
    public Knife(string weaponType, string rarity, string name)
        : base(weaponType, rarity, name)
    {
        this.MinDamage = 3;
        this.MaxDamage = 4;
        this.Sockets = new IBaseGem[2];
        this.AddRarityBonuses();
    }
}