using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class DraftManager
{
    private double totalEnergy;
    private double totalOreMined;
    private string mode;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        this.totalEnergy = 0;
        this.totalOreMined = 0;
        this.mode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        try
        {
            if (type == "Sonic")
            {
                var sonicFactor = int.Parse(arguments[4]);
                this.harvesters.Add(HarvesterFactory.CreateHarvester(id, oreOutput, energyRequirement, sonicFactor));
            }
            else
            {
                this.harvesters.Add(HarvesterFactory.CreateHarvester(type, id, oreOutput, energyRequirement));
            }
        }
        catch (ArgumentException ae)
        {
            return $"Harvester is not registered, because of it's {ae.Message}";
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        try
        {
            this.providers.Add(ProviderFactory.CreateProvider(type, id, energyOutput));
        }
        catch (ArgumentException ae)
        {
            return $"Provider is not registered, because of it's {ae.Message}";
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        var energyRequirement = this.harvesters.Sum(harvester => harvester.EnergyRequirement);
        var energyProvided = this.providers.Sum(provider => provider.EnergyOutput);

        if (this.mode == "Half")
        {
            energyRequirement *= 0.6;
        }
        else if (this.mode == "Energy")
        {
            energyRequirement = 0;
        }

        this.totalEnergy += energyProvided;
        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {energyProvided}");
        sb.Append($"Plumbus Ore Mined: ");

        if (energyRequirement > this.totalEnergy)
        {
            sb.Append("0");
        }
        else
        {
            var oreMined = this.harvesters.Sum(harvester => harvester.OreOutput);

            if (this.mode == "Half")
            {
                oreMined /= 2;
            }
            else if (this.mode == "Energy")
            {
                oreMined = 0;
            }

            this.totalOreMined += oreMined;
            this.totalEnergy -= energyRequirement;
            sb.Append(oreMined);
        }

        return sb.ToString();
    }

    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0];
        return $"Successfully changed working mode to {this.mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];

        if (this.harvesters.Any(harverster => harverster.Id == id))
        {
            return this.harvesters.First(harvester => harvester.Id == id).ToString();
        }

        if (this.providers.Any(provider => provider.Id == id))
        {
            return this.providers.First(provider => provider.Id == id).ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalEnergy}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalOreMined}");
        return sb.ToString();
    }
}