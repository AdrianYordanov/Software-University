using System;
using System.Collections.Generic;

public class WeaponFactory : IWeaponFactory
{
    public IWeapon Create(IList<string> tokens)
    {
        var weaponType = tokens[1];
        var rarity = tokens[0];
        var name = tokens[2];
        IWeapon weapon = null;
        switch (weaponType)
        {
            case "Axe":
                weapon = new Axe(weaponType, rarity, name);
                break;
            case "Knife":
                weapon = new Knife(weaponType, rarity, name);
                break;
            case "Sword":
                weapon = new Sword(weaponType, rarity, name);
                break;
            default:
                throw new ArgumentException($"Invalid weapon type!");
        }

        return weapon;
    }
}