namespace Black_Wars_New_Factory.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var unitClass = Type.GetType($"Black_Wars_New_Factory.Models.Units.{unitType}");
            return (IUnit) Activator.CreateInstance(unitClass);
        }
    }
}