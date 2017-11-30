namespace P03_SalesDatabase.Data.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product(string name, decimal quantity, decimal price, string description)
        {
            this.Name = name;
            this.Quantity = quantity;
            this.Price = price;
            this.Description = description;
            this.Sales = new List<Sale>();
        }

        public Product(string name, int quantity, decimal price, string description, ICollection<Sale> sales)
            : this(name, quantity, price, description)
        {
            this.Sales = sales;
        }

        public int ProductId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public decimal Quantity
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public ICollection<Sale> Sales
        {
            get;
            set;
        }
    }
}