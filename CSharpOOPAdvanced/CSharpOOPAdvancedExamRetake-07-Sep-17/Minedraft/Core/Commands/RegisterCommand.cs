using System.Collections.Generic;

public class RegisterCommand : Command
{

    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var type = this.Arguments[0];
        this.Arguments.RemoveAt(0);

        if(type == "Harvester")
        {
            return this.HarvesterController.Register(this.Arguments);
        }
        else
        {
            return this.ProviderController.Register(this.Arguments);
        }
    }
}

