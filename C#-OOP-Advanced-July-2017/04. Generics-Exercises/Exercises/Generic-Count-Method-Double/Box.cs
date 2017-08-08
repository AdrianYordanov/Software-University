using System;

public class Box : IComparable<Box>
{
    public Box(double variable)
    {
        this.Variable = variable;
    }

    public double Variable { get; set; }

    public int CompareTo(Box other)
    {
        return this.Variable.CompareTo(other.Variable);
    }

    public override string ToString()
    {
        return $"{this.Variable.GetType().FullName}: {this.Variable}";
    }
}