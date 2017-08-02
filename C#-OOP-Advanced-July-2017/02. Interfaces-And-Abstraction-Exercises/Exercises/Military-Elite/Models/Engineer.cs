using System;
using System.Collections.Generic;

public class Engineer : SpecialisedSoldier, IEngineer
{
    private readonly IList<IRepair> repairs;

    public Engineer(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<IRepair>();
    }

    public IList<IRepair> Repairs => this.repairs;

    public override string ToString()
    {
        var result = base.ToString() + Environment.NewLine + "Repairs:";
        if (this.Repairs.Count > 0)
        {
            result += Environment.NewLine + string.Join(Environment.NewLine, this.Repairs);
        }

        return result;
    }
}