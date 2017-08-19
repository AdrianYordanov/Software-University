using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class InfoAttribute : Attribute
{
    private readonly List<string> reviewers;
    private string author;
    private int revision;
    private string description;

    public InfoAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.reviewers = new List<string>(reviewers);
    }

    public string Author
    {
        get => this.author;
        private set => this.author = value;
    }

    public int Revision
    {
        get => this.revision;
        private set => this.revision = value;
    }

    public string Description
    {
        get => this.description;
        private set => this.description = value;
    }

    public IReadOnlyCollection<string> Reviewers => this.reviewers.AsReadOnly();

    public void PrintInfo(string field)
    {
        switch (field)
        {
            case "Author":
                Console.WriteLine($"Author: {this.Author}");
                break;
            case "Revision":
                Console.WriteLine($"Revision: {this.Revision}");
                break;
            case "Description":
                Console.WriteLine($"Class description: {this.Description}");
                break;
            case "Reviewers":
                Console.WriteLine($"Reviewers: {string.Join(", ", this.Reviewers)}");
                break;
        }
    }
}