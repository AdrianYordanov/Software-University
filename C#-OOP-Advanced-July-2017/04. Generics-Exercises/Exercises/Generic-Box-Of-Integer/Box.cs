public class Box
{
    public Box(int variable)
    {
        this.Variable = variable;
    }

    public int Variable { get; set; }

    public override string ToString()
    {
        return $"{this.Variable.GetType().FullName}: {this.Variable}";
    }
}