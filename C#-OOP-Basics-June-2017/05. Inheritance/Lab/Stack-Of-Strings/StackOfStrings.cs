﻿using System.Collections.Generic;
using System.Linq;

class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string element)
        this.data.Add(element);
    }

    public string Pop()
    {
        var element = this.data.Last();
        this.data.Remove(element);
        return element;
    }
    {
        return this.data.Last();
    }
    {
        return this.data.Count == 0;
    }