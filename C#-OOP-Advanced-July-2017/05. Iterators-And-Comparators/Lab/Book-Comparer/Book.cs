using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    private string title;
    private int year;
    private IReadOnlyList<string> authors;

    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public string Title
    {
        get => this.title;
        set => this.title = value;
    }

    public int Year
    {
        get => this.year;
        set => this.year = value;
    }

    public IReadOnlyList<string> Authors
    {
        get => this.authors;
        set => this.authors = value;
    }

    public int CompareTo(Book other)
    {
        var result = this.Year.CompareTo(other.Year);
        if (result == 0)
        {
            result = string.Compare(this.Title, other.Title, StringComparison.Ordinal);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}";
    }
}