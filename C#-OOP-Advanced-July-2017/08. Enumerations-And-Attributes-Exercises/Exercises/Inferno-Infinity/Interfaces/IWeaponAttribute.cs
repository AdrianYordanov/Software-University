using System.Collections.Generic;

public interface IWeaponAttribute
{
    string Author
    {
        get;
    }

    string Description
    {
        get;
    }

    IList<string> Reviewers
    {
        get;
    }

    int Revision
    {
        get;
    }

    string PrintInfo(string field);
}