using System;
using System.Collections;
using System.Collections.Generic;

public class MyLinkedList<T> : IEnumerable<T>
    where T : IComparable
{
    private LinkedListNode<T> head;
    private int count;

    public MyLinkedList()
    {
        this.Head = null;
        this.Count = 0;
    }

    public LinkedListNode<T> Head
    {
        get => this.head;
        private set => this.head = value;
    }

    public int Count
    {
        get => this.count;
        private set => this.count = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var currentNode = this.Head;
        while (currentNode != null)
        {
            yield return currentNode.Value;

            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public void Add(T item)
    {
        if (this.Count == 0)
        {
            this.Head = new LinkedListNode<T>(item);
        }
        else
        {
            var lastNode = this.GetElementAtIndex(this.Count - 1);
            lastNode.Next = new LinkedListNode<T>(item);
        }

        this.Count++;
    }

    public T Remove(int index)
    {
        var removeValue = default(T);
        if (index == 0)
        {
            removeValue = this.Head.Value;
            this.Head = this.Head.Next;
        }
        else
        {
            var prevNode = this.GetElementAtIndex(index - 1);
            var currentNode = this.GetElementAtIndex(index);
            prevNode.Next = currentNode.Next;
            removeValue = currentNode.Value;
        }

        this.Count--;
        return removeValue;
    }

    public int FirstIndexOf(T element)
    {
        var firstIndex = this.IndexOf(element, true);
        return firstIndex;
    }

    public int LastIndexOf(T element)
    {
        var lastIndex = this.IndexOf(element, false);
        return lastIndex;
    }

    private int IndexOf(T element, bool isFirstFoundIndexNeeded)
    {
        var foundIndex = -1;
        var currentNode = this.Head;
        for (var index = 0; index < this.Count; index++)
        {
            if (currentNode.Value.Equals(element))
            {
                foundIndex = index;
                if (isFirstFoundIndexNeeded)
                {
                    return foundIndex;
                }
            }

            currentNode = currentNode.Next;
        }

        return foundIndex;
    }

    private LinkedListNode<T> GetElementAtIndex(int index)
    {
        var currentElement = this.Head;
        for (var i = 0; i < index; i++)
        {
            currentElement = currentElement.Next;
        }

        return currentElement;
    }
}