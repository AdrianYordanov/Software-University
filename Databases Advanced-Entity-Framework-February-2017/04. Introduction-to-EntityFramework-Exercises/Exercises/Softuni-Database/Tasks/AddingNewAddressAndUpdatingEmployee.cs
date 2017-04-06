namespace Softuni_Database.Tasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Softuni_Database.Models;

    class AddingNewAddressAndUpdatingEmployee
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var newAdress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };
            context.Addresses.Add(newAdress);
            context.SaveChanges();
            var employees = context.Employees;
            employees
                .Where(e => e.LastName == "Nakov")
                .ToList()
                .ForEach(e => e.Address = newAdress);
            context.SaveChanges();
            var adresses = employees
                .OrderByDescending(e => e.AddressID)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();
            adresses.ForEach(a => Console.WriteLine(a));
        }
    }
}
