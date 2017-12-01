namespace P02_DatabaseFirst.Exercises
{
    using System;
    using System.Linq;
    using Data;

    public class DeleteProjectById
    {
        public void Run()
        {
            using (var db = new SoftUniContext())
            {
                var relatiosWithProject = db.EmployeesProjects.Where(ep => ep.ProjectId == 2);
                db.EmployeesProjects.RemoveRange(relatiosWithProject);
                var project = db.Projects.SingleOrDefault(p => p.ProjectId == 2);
                db.Projects.Remove(project);
                db.SaveChanges();
                db.Projects.Take(10)
                    .Select(e => e.Name)
                    .ToList()
                    .ForEach(Console.WriteLine);
            }
        }
    }
}