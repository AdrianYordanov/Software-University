class Square : Figure
{
    private int side;

    public Square(int side)
    {
        this.side = side;
    }

    public override string Draw()
    {
        var firstLastLine = $"|{new string('-', this.side)}|";
        var result = firstLastLine + "\n";

        for (int i = 0; i < this.side - 2; i++)
        {
            result += $"|{new string(' ', this.side)}|\n";
        }

        result += firstLastLine;
        return result;
    }
}