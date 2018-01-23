using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var val = double.Parse(this.Arguments[0]);

        return this.ProviderController.Repair(val);
    }
}

