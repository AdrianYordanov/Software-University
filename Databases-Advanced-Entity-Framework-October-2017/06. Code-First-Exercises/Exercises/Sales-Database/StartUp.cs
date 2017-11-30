namespace P03_SalesDatabase
{
    using System;
    using System.Linq;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            Seed();
        }

        private static void Seed()
        {
            using (var db = new SalesContext())
            {
                db.Database.EnsureDeleted();
                db.Database.Migrate();
                var sales = new[]
                {
                    new Sale(new DateTime(2007, 6, 5)),
                    new Sale(new DateTime(2012, 12, 25)),
                    new Sale(new DateTime(2005, 4, 13)),
                    new Sale(new DateTime(2011, 8, 22)),
                    new Sale(new DateTime(2016, 1, 11)),
                    new Sale(new DateTime(2001, 3, 18))
                }.ToList();
                var products = new[]
                {
                    new Product("iPhone", 12, 870, "apple phone se", sales),
                    new Product("Samsung Galaxy S5", 10, 560, "the brand new samsung smartphone", sales),
                    new Product("Audi A3", 200, 20000, "Audi A3 2014, full packet", sales)
                }.ToList();
                var customers = new[]
                {
                    new Customer("Adrian", "email@gmail.com", "435hju54656gwfg", sales),
                    new Customer("Pesho", "emai@live.com", "fdj34gowe54hrjgui34", sales),
                    new Customer("Gosho", "email@abv.com", "weirug343456hnvbldjg2", sales),
                    new Customer("Tisho", "email@private.com", "bvkldjh535giwehrt345", sales)
                }.ToList();
                var stores = new[]
                {
                    new Store("emag", sales),
                    new Store("telenor", sales),
                    new Store("vivacom")
                }.ToList();
                db.Sales.AddRange(sales);
                db.Products.AddRange(products);
                db.Customers.AddRange(customers);
                db.Stores.AddRange(stores);
                db.SaveChanges();
            }
        }
    }
}