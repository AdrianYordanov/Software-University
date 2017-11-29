namespace Database_First.Exercises
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class AddressesByTown
    {
        public void Run()
        {
            using (var db = new SoftUniContext())
            {
                var adresses = db.Addresses.Include(a => a.Town)
                    .OrderByDescending(a => a.Employees.Count)
                    .ThenBy(a => a.Town.Name)
                    .ThenBy(a => a.AddressText)
                    .Select(
                        a => new
                        {
                            a.AddressText,
                            Town = a.Town.Name,
                            EmployeeCount = a.Employees.Count
                        })
                    .Take(10);
                foreach (var adress in adresses)
                {
                    Console.WriteLine($"{adress.AddressText}, {adress.Town} - {adress.EmployeeCount} employees");
                }
            }
        }
    }
}