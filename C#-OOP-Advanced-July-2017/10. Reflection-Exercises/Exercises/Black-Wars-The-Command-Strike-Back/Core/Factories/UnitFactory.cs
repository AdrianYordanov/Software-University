namespace Black_Wars_The_Command_Strike_Back.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var unitClass = Type.GetType($"Black_Wars_The_Command_Strike_Back.Models.Units.{unitType}");
            return (IUnit) Activator.CreateInstance(unitClass);
        }
    }
}