using System.Collections.Generic;

public class Book
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
}