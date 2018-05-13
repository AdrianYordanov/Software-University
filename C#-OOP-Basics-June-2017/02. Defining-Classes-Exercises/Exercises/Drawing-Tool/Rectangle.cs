public class Rectangle : Figure
{
    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    private int Width { get; }

    private int Height { get; }

    public override string Draw()
    {
        var firstLastLine = $"|{new string('-', this.Width)}|";
        var result = firstLastLine + "\n";
        for (var i = 0; i < (this.Height - 2); i++)
        {
            result += $"|{new string(' ', this.Width)}|\n";
        }

        result += firstLastLine;
        return result;
    }
}