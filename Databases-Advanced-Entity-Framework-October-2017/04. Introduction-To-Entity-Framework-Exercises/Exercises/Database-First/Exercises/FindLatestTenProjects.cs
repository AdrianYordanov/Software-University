using System;
using System.Globalization;
using System.Linq;
using Database_First.Data;

public class FindLatestTenProjects
{
    public void Run()
    {
        using (var db = new SoftUniContext())
        {
            db.Projects.OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList()
                .ForEach(
                    p => Console.WriteLine(
                        $"{p.Name}{Environment.NewLine}{p.Description}{Environment.NewLine}{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}"));
        }
    }
}