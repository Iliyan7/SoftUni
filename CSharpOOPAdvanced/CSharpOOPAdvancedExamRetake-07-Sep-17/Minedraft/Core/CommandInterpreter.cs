using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string CommandSuffix = "Command";

    private readonly IEnergyRepository energyRepository;

    public CommandInterpreter()
    {
        this.energyRepository = new EnergyRepository();
        this.HarvesterController = new HarvesterController(this.energyRepository);
        this.ProviderController = new ProviderController(this.energyRepository);
    }

    public IHarvesterController HarvesterController { get; }

    public IProviderController ProviderController { get; }

    public string ProcessCommand(IList<string> args)
    {
        string commandType = args[0];
        args.RemoveAt(0);

        string commandFullName = commandType + CommandSuffix;

        try
        {
            Type type = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name == commandFullName);

            var instance = (ICommand)Activator.CreateInstance(type, args, this.HarvesterController, this.ProviderController);

            return instance.Execute();
        }
        catch (TargetInvocationException tie)
        {
            throw tie.InnerException;
        }
    }
}

