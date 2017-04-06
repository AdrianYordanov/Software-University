namespace Softuni_Database.Tasks
{
    using System;
    using System.Linq;

    class AdressesByTownName
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var adresses = context.Addresses;
            var orderedAdresses = adresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .Take(10)
                .ToList();

            orderedAdresses.ForEach(a => Console.WriteLine($"{a.AddressText}, {a.Town.Name} - {a.Employees.Count} employees"));
        }
    }
}
