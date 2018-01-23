using System.Collections.Generic;

public abstract class Command : ICommand
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    protected Command(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
    {
        this.Arguments = arguments;
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public IHarvesterController HarvesterController => this.harvesterController;
    public IProviderController ProviderController => this.providerController;

    public IList<string> Arguments { get; }

    public abstract string Execute();
}

