using System;

static class HarvesterFactory
{
    public static Harvester CreateHarvester(string type, string id, double oreOuput, double energyRequirement)
    {
        switch (type)
        {
            case "Hammer": return new HammerHarvester(id, oreOuput, energyRequirement);
            default: throw new InvalidOperationException("Invalid Hammer type.");
        }
    }

    public static SonicHarvester CreateHarvester(string id, double oreOuput, double energyRequirement, int sonicFactor)
    {
        return new SonicHarvester(id, oreOuput, energyRequirement, sonicFactor);
    }
}