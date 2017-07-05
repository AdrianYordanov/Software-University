using System;
using System.Linq;
using System.Collections.Generic;

class Pizza
{
    private const int MaxNumberOfToppings = 10;
    private string name;
    private Dough dough;
    private List<Topping> toppings;
    private int numberOfToppings;


    public Pizza(string name, int numberOfToppings)
    {
        this.Name = name;
        this.NumberOfToppings = numberOfToppings;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (value.Length < 1 || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = value;
        }
    }

    public Dough Dough
    {
        set
        {
            this.dough = value;
        }
    }

    public int NumberOfToppings
    {
        get
        {
            return this.numberOfToppings;
        }
        set
        {
            if (value < 0 || value > MaxNumberOfToppings)
            {
                throw new ArgumentException($"Number of toppings should be in range [0..{MaxNumberOfToppings}].");
            }

            this.numberOfToppings = value;
        }
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
    }

    public double GetCalories()
    {
        return (this.dough.GetCalories() + this.toppings.Sum(t => t.GetCalories()));
    }
}