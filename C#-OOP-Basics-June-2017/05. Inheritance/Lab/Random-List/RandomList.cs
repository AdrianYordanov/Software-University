using System;
using System.Collections;

class RandomList : ArrayList
{
    public string RandomString()
    {
        var rand = new Random();
        var index = rand.Next(this.Count);
        var returnValue = this[index];
        this.RemoveAt(index);
        return returnValue.ToString();
    }
}