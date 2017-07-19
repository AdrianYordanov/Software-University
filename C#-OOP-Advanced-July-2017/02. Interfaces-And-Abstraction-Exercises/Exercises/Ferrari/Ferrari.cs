﻿public class Ferrari : ICar
{
    private string driver;
    private string model;

    public Ferrari(string driver, string model = "488-Spider")
    {
        this.Driver = driver;
        this.Model = model;
    }

    public string Driver
    {
        get => this.driver;
        private set => this.driver = value;
    }

    public string Model
    {
        get => this.model;
        private set => this.model = value;
    }

    public string Brake()
    {
        return "Brakes!";
    }

    public string Gas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.Brake()}/{this.Gas()}/{this.Driver}";
    }
}
