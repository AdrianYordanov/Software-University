

using System.Linq;
using Database_First.Data;
using Database_First.Data.Models;

public class AddingNewAddressAndUpdatingEmployee
{
    public void Run()
    {
        using (var db = new SoftUniContext())
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };
            var employee = db.Employees.SingleOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;
            db.SaveChanges();
        }
    }
}