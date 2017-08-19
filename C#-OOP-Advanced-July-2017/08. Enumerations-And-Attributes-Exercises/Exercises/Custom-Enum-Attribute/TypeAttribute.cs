using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum)]
public class TypeAttribute : Attribute
{
    private string type;
    private string category;
    private string description;

    public TypeAttribute(string type, string category, string description)
    {
        this.Type = type;
        this.Category = category;
        this.Description = description;
    }

    public string Type
    {
        get => this.type;
        set => this.type = value;
    }

    public string Category
    {
        get => this.category;
        set => this.category = value;
    }

    public string Description
    {
        get => this.description;
        set => this.description = value;
    }
}