using System;
using System.Collections.Generic;

public class Commando : SpecialisedSoldier, ICommando
{
    private readonly IList<IMission> missions;

    public Commando(string id, string firstName, string lastName, double salary, string corps)
        : base(id, firstName, lastName, salary, corps)
    {
        this.missions = new List<IMission>();
    }

    public IList<IMission> Missions => this.missions;

    public override string ToString()
    {
        var result = base.ToString() + Environment.NewLine + "Missions:";
        if (this.Missions.Count > 0)
        {
            result += Environment.NewLine + string.Join(Environment.NewLine, this.Missions);
        }

        return result;
    }
}