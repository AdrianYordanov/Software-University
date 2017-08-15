using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private readonly List<CoffeeType> coffeesSold;
    private int insertedCoins;

    public CoffeeMachine()
    {
        this.insertedCoins = 0;
        this.coffeesSold = new List<CoffeeType>();
    }

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeesSold.AsReadOnly();

    public void BuyCoffee(string size, string type)
    {
        var coffeePrice = (int)Enum.Parse(typeof(CoffeePrice), size);
        if (this.insertedCoins < coffeePrice)
        {
            return;
        }

        this.insertedCoins = 0;
        this.coffeesSold.Add((CoffeeType)Enum.Parse(typeof(CoffeeType), type));
    }

    public void InsertCoin(string coin)
    {
        this.insertedCoins += (int)Enum.Parse(typeof(Coin), coin);
    }
}