using System;

static class ProviderFactory
{
    public static Provider CreateProvider(string type, string id, double energyOutput)
    {
        switch (type)
        {
            case "Solar": return new SolarProvider(id, energyOutput);
            case "Pressure": return new PressureProvider(id, energyOutput);
            default: throw new InvalidOperationException("Invalid Hammer type.");
        }
    }
}