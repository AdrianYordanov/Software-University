using System;

public class Box : IComparable<Box>
{
    public Box(string variable)
    {
        this.Variable = variable;
    }

    public string Variable { get; set; }

    public int CompareTo(Box other)
    {
        return string.Compare(this.Variable, other.Variable, StringComparison.Ordinal);
    }

    public override string ToString()
    {
        return $"{this.Variable.GetType().FullName}: {this.Variable}";
    }
}