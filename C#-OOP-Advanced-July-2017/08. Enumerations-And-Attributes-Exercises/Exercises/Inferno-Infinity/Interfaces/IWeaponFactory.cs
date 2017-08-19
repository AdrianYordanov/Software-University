using System.Collections.Generic;

public interface IWeaponFactory
{
    IWeapon Create(IList<string> tokens);
}