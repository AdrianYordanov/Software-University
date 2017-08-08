using System.Collections.Generic;

public static class Swapper
{
    public static void Swap<T>(IList<T> collection, int firstIndex, int secondIndex)
    {
        var firstIndexElement = collection[firstIndex];
        collection[firstIndex] = collection[secondIndex];
        collection[secondIndex] = firstIndexElement;
    }
}