public class Car
{
    public Car(string model, int speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    private string Model { get; }

    private int Speed { get; }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}