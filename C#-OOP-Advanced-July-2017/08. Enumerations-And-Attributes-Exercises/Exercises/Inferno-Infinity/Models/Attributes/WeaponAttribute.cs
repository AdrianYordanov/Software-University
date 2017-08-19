using System;
using System.Collections.Generic;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class WeaponAttribute : Attribute, IWeaponAttribute
{
    private readonly List<string> reviewers;
    private string author;
    private int revision;
    private string description;

    public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
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

    public IList<string> Reviewers => this.reviewers.AsReadOnly();

    public string PrintInfo(string field)
    {
        switch (field)
        {
            case "Author":
                return $"Author: {this.Author}";
            case "Revision":
                return $"Revision: {this.Revision}";
            case "Description":
                return $"Class description: {this.Description}";
            case "Reviewers":
                return $"Reviewers: {string.Join(", ", this.Reviewers)}";
            default:
                throw new ArgumentException($"Invalid attribute field: {field}");
        }
    }
}