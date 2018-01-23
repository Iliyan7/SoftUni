using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace CSharpOOPBasicsExam_16_July_2017
//{
public class DraftManager
{
    private const string defaultMode = "Full";

    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private string mode;
    private double totalEnergyStored;
    private double totalMinedOre;
    private double summedEnergyOutput;
    private double summedOreOutput;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
        this.mode = defaultMode;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            var id = arguments[1];

            var harvesterFactory = new HarvesterFactory();
            Harvester harvester = harvesterFactory.Get(arguments);
            harvesters.Add(id, harvester);

            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        try
        {
            var type = arguments[0];
            var id = arguments[1];

            var providerFactory = new ProviderFactory();
            Provider provider = providerFactory.Get(arguments);
            providers.Add(id, provider);

            return $"Successfully registered {type} Provider - {id}";
        }
        catch (ArgumentException ae)
        {
            return ae.Message;
        }
    }

    public string Day()
    {
        var sb = new StringBuilder();
        sb.AppendLine("A day has passed.");

        this.ProduceAndConsumeEnergy();

        sb.AppendLine($"Energy Provided: {this.summedEnergyOutput}");
        sb.Append($"Plumbus Ore Mined: {this.summedOreOutput}");

        this.summedEnergyOutput = this.summedOreOutput = 0;

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

        if (this.harvesters.ContainsKey(id))
        {
            return this.harvesters[id]
                .ToString();
        }

        if (this.providers.ContainsKey(id))
        {
            return this.providers[id]
                .ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
        sb.Append($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString();
    }

    private void ProduceAndConsumeEnergy()
    {
        switch (mode)
        {
            case "Full":
                {
                    var producedEnergy = providers
                        .Sum(p => p.Value.EnergyOutput);

                    this.summedEnergyOutput = producedEnergy;
                    this.totalEnergyStored += producedEnergy;

                    var consumedEnergy = harvesters
                        .Sum(h => h.Value.EnergyRequirement);

                    if (consumedEnergy <= this.totalEnergyStored)
                    {
                        this.totalEnergyStored -= consumedEnergy;

                        var oreMined = harvesters
                            .Sum(h => h.Value.OreOutput);

                        this.summedOreOutput = oreMined;
                        this.totalMinedOre += oreMined;
                    }
                    break;
                }

            case "Half":
                {
                    var producedEnergy = providers
                        .Sum(p => p.Value.EnergyOutput);

                    this.summedEnergyOutput = producedEnergy;
                    this.totalEnergyStored += producedEnergy;

                    var consumedEnergy = harvesters
                        .Sum(h => h.Value.EnergyRequirement) * 0.6;

                    if (consumedEnergy <= this.totalEnergyStored)
                    {
                        this.totalEnergyStored -= consumedEnergy;

                        var oreMined = harvesters
                            .Sum(h => h.Value.OreOutput) * 0.5;

                        this.summedOreOutput = oreMined;
                        this.totalMinedOre += oreMined;
                    }
                    break;
                }
            case "Energy":
                {
                    var producedEnergy = providers
                        .Sum(p => p.Value.EnergyOutput);

                    this.summedEnergyOutput = producedEnergy;
                    this.totalEnergyStored += producedEnergy;

                    break;
                }
        }
    }
}
//}
