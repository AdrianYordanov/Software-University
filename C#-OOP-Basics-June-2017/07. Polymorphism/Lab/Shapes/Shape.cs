abstract class Shape
{
    abstract public double CalculatePerimeter();

    abstract public double CalculateArea();

    virtual public string Draw()
    {
        return "Drawing ";
    }
}