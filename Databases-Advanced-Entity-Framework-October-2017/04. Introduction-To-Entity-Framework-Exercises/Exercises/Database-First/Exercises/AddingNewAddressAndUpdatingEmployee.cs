namespace P02_DatabaseFirst.Exercises
{
    using System.Linq;
    using Data;
    using Data.Models;

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
}