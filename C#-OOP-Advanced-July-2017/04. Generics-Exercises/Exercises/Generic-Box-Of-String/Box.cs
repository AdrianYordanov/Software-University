public class Box
{
    public Box(string variable)
    {
        this.Variable = variable;
    }

    public string Variable { get; set; }

    public override string ToString()
    {
        return $"{this.Variable.GetType().FullName}: {this.Variable}";
    }
}