namespace Softuni_Database.Tasks
{
    using System;
    using System.Globalization;
    using System.Linq;

    class FindEmployeesInPeriod
    {
        public static void Execute()
        {
            var context = new SoftuniContext();
            var employees = context.Employees.ToList();
            var filteredEmployees = employees
                .Where(e => e.Projects
                    .Any(p => (p.StartDate.Year >= 2001 && p.EndDate.HasValue) &&
                        (p.EndDate.Value.Year >= 2001 && p.EndDate.Value.Year <= 2003)))
                .Take(30);

            foreach (var e in filteredEmployees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");

                foreach (var p in e.Projects)
                {
                    Console.Write($"--{p.Name} {p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} ");
                    Console.WriteLine(p.EndDate != null ? p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : string.Empty);
                }
            }
        }
    }
}
