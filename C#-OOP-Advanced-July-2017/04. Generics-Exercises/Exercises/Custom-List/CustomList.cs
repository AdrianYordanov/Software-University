using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
{
    private IList<T> data;

    public CustomList()
    {
        this.data = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.data.GetEnumerator();
    }

    public void Add(T element)
    {
        this.data.Add(element);
    }

    public T Remove(int index)
    {
        var item = this.data[index];

        this.data.Remove(item);

        return item;
    }

    public bool Contains(T element)
    {
        return this.data.Any(e => e.CompareTo(element) == 0);
    }

    public void Swap(int index1, int index2)
    {
        var temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }

    public int CountGreaterThan(T element)
    {
        return this.data.Count(e => e.CompareTo(element) > 0);
    }

    public T Max()
    {
        return this.data.Max();
    }

    public T Min()
    {
        return this.data.Min();
    }

    public void Sort()
    {
        this.data = this.data.OrderBy(i => i).ToList();
    }
}