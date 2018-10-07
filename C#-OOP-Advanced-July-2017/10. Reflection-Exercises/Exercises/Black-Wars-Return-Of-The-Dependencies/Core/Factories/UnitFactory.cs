namespace Black_Wars_Return_Of_The_Dependencies.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var unitClass = Type.GetType($"Black_Wars_Return_Of_The_Dependencies.Models.Units.{unitType}");
            return (IUnit) Activator.CreateInstance(unitClass);
        }
    }
}