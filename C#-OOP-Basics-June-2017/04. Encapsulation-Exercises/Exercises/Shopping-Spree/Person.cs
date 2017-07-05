using System;
using System.Collections.Generic;
using System.Linq;

class Person
{
    private string name;
    private decimal money;
    private List<Product> bag;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bag = new List<Product>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get
        {
            return this.money;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            this.money = value;
        }
    }

    public string TryMakeOrder(Product product)
    {
        if (this.Money < product.Cost)
        {
            return $"{this.Name} can't afford {product.Name}";
        }

        this.Money -= product.Cost;
        this.bag.Add(product);
        return $"{this.Name} bought {product.Name}";
    }

    public override string ToString()
    {
        if (this.bag.Count == 0)
        {
            return $"{this.Name} - Nothing bought";
        }

        return $"{this.Name} - {string.Join(", ", this.bag.Select(p => p.Name))}";
    }
}