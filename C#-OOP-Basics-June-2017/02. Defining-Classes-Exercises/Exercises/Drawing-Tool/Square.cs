public class Square : Figure
{
    public Square(int side)
    {
        this.Side = side;
    }

    private int Side { get; }

    public override string Draw()
    {
        var firstLastLine = $"|{new string('-', this.Side)}|";
        var result = firstLastLine + "\n";
        for (var i = 0; i < (this.Side - 2); i++)
        {
            result += $"|{new string(' ', this.Side)}|\n";
        }

        result += firstLastLine;
        return result;
    }
}