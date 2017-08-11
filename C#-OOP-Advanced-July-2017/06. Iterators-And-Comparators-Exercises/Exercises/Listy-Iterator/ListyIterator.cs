using System;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T>
{
    private readonly IList<T> collection;
    private int index;

    public ListyIterator(IEnumerable<T> items)
    {
        this.index = 0;
        this.collection = new List<T>(items);
    }

    public IEnumerable<T> Collection => this.collection.AsEnumerable();

    public bool HasNext()
    {
        return this.index + 1 < this.collection.Count;
    }

    public bool Move()
    {
        if (!this.HasNext())
        {
            return false;
        }

        this.index++;
        return true;
    }

    public void Print()
    {
        if (this.collection.Any())
        {
            Console.WriteLine(this.collection[this.index]);
        }
        else
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }
}