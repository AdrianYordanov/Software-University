﻿namespace Black_Wars_Return_Of_The_Dependencies.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}