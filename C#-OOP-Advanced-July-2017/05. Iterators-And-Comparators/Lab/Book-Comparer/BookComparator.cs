using System;
using System.Collections.Generic;

public class BookComparator : IComparer<Book>
{
    public int Compare(Book first, Book second)
    {
        var result = string.Compare(first.Title, second.Title, StringComparison.CurrentCulture);
        if (result == 0)
        {
            result = second.Year.CompareTo(first.Year);
        }

        return result;
    }
}