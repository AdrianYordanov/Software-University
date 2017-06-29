﻿class Car
{
    public Car(string model, int speed)
    {
        this.Model = model;
        this.Speed = speed;
    }

    public string Model { get; set; }

    public int Speed { get; set; }

    public override string ToString()
    {
        return $"{this.Model} {this.Speed}";
    }
}