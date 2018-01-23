using System;
using System.Collections.Generic;
using System.Linq;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private List<IHarvester> harvesters;
    private IEnergyRepository energyRepository;
    private IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository)
    {
        this.mode = "Full";
        this.harvesters = new List<IHarvester>();
        this.energyRepository = energyRepository;
        this.factory = new HarvesterFactory();
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => this.harvesters;

    public string Register(IList<string> args)
    {
        var harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);
        return string.Format(Constants.SuccessfullRegistration,
            harvester.GetType().Name);
    }
    public string Produce()
    {
        double multiplier;

        switch(this.mode)
        {
            case "Energy": multiplier = 20.0; break;
            case "Half": multiplier = 50.0; break;
            default: multiplier = 100.0;  break;
        }

        multiplier /= 100.0;

        double totalEnergyRequirment = this.harvesters.Sum(h => h.EnergyRequirement * multiplier);

        double oreProduced = 0;

        if (this.energyRepository.TakeEnergy(totalEnergyRequirment))
        {
            oreProduced = this.harvesters.Sum(h => h.Produce() * multiplier);
            this.OreProduced += oreProduced;
        }

        return string.Format(Constants.OreOutputToday, oreProduced);
    }

    public string ChangeMode(string mode)
    {
        this.mode = mode;
        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in this.harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChanged, mode);
    }
}

