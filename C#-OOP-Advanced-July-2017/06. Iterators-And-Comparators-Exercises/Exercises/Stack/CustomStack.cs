using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomStack<T> : IEnumerable<T>
{
    private readonly IList<T> collection;

    public CustomStack()
    {
        this.collection = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (var i = this.collection.Count - 1; i >= 0; i--)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Push(T item)
    {
        this.collection.Add(item);
    }

    public T Pop()
    {
        if (this.collection.Count <= 0)
        {
            throw new InvalidOperationException("No elements");
        }

        var last = this.collection.Last();
        this.collection.Remove(last);
        return last;
    }
}