class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double topLeftX;
    private double topLeftY;
    private double bottomRightY;
    private double bottomRightX;

    public Rectangle(string id, double width, double height, double x, double y)
    {
        this.id = id;
        this.width = width;
        this.height = height;
        this.topLeftX = x;
        this.topLeftY = y;
        this.bottomRightX = this.topLeftX + this.width;
        this.bottomRightY = this.topLeftY - this.height;
    }

    public string ID
    {
        get
        {
            return this.id;
        }
    }

    public bool IsIntersect(Rectangle checkRectangle)
    {
        if (this.topLeftX > checkRectangle.bottomRightX || checkRectangle.topLeftX > this.bottomRightX)
        {
            return false;
        }

        if (this.topLeftY < checkRectangle.bottomRightY || checkRectangle.topLeftY < this.bottomRightY)
        {
            return false;
        }

        return true;
    }
}