class Rectangle : Figure
{
    private int width;
    private int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public override string Draw()
    {
        var firstLastLine = $"|{new string('-', this.width)}|";
        var result = firstLastLine + "\n";

        for (int i = 0; i < this.height - 2; i++)
        {
            result += $"|{new string(' ', this.width)}|\n";
        }

        result += firstLastLine;
        return result;
    }
}