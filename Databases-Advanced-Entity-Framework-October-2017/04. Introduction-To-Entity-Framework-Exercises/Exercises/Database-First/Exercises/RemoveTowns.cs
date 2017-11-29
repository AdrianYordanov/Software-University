namespace Database_First.Exercises
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class RemoveTowns
    {
        public void Run()
        {
            Console.Write("Town name: ");
            var townName = Console.ReadLine();
            using (var db = new SoftUniContext())
            {
                var addresses = db.Addresses.Where(a => a.Town.Name == townName);
                addresses.Include(a => a.Employees)
                    .ToList()
                    .ForEach(
                        a => a.Employees.ToList()
                            .ForEach(e => e.AddressId = null));
                var addressesCount = addresses.Count();
                db.Addresses.RemoveRange(addresses);
                var town = db.Towns.SingleOrDefault(t => t.Name == townName);
                db.Towns.Remove(town);
                db.SaveChanges();
                Console.WriteLine($"{addressesCount} in {townName} was deleted");
            }
        }
    }
}