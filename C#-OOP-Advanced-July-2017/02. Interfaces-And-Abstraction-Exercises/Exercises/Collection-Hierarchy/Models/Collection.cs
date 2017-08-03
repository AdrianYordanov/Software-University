using System.Collections.Generic;

public abstract class Collection
{
    protected readonly IList<string> List;

    protected Collection()
    {
        this.List = new List<string>();
    }

    public override string ToString()
    {
        return string.Join(" ", this.List);
    }
}