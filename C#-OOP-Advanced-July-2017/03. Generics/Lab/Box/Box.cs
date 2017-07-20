using System.Collections.Generic;
using System.Linq;

public class Box<T>
{
    private readonly List<T> collection;

    public Box()
    {
        this.collection = new List<T>();
    }

    public int Count => this.collection.Count;

    public void Add(T element)
    {
        this.collection.Add(element);
    }

    public T Remove()
    {
        var element = this.collection.LastOrDefault();
        this.collection.RemoveAt(this.collection.Count - 1);
        return element;
    }
}