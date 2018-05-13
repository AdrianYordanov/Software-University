public class Rectangle
{
    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.Id = id;
        this.TopLeftX = x;
        this.TopLeftY = y;
        this.BottomRightX = this.TopLeftX + width;
        this.BottomRightY = this.TopLeftY - height;
    }

    public string Id { get; }

    private double TopLeftX { get; }

    private double TopLeftY { get; }

    private double BottomRightY { get; }

    private double BottomRightX { get; }

    public bool IsIntersect(Rectangle checkRectangle)
    {
        if (this.TopLeftX > checkRectangle.BottomRightX
            || checkRectangle.TopLeftX > this.BottomRightX)
        {
            return false;
        }

        if (this.TopLeftY < checkRectangle.BottomRightY
            || checkRectangle.TopLeftY < this.BottomRightY)
        {
            return false;
        }

        return true;
    }
}