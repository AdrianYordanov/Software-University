using System;
using System.Collections.Generic;
using System.Linq;

public class LeutenantGeneral : Private, ILeutenantGeneral
{
    private readonly IList<string> privates;

    public LeutenantGeneral(string id, string firstName, string lastName, double salary)
        : base(id, firstName, lastName, salary)
    {
        this.privates = new List<string>();
    }

    public IList<string> Privates => this.privates;

    public override string ToString()
    {
        var queryPrivates = this.Privates.Select(DataContainer.GetSoldierById);
        var result = base.ToString() + Environment.NewLine + "Privates:";
        if (this.Privates.Count > 0)
        {
            result += Environment.NewLine + string.Join(Environment.NewLine, queryPrivates);
        }

        return result;
    }
}