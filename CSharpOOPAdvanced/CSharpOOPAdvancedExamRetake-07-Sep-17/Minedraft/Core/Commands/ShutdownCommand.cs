using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();

        sb.AppendLine(Constants.SystemShutdown);
        sb.AppendLine(string.Format(Constants.TotalEnergyProduced, this.ProviderController.TotalEnergyProduced));
        sb.AppendLine(string.Format(Constants.TotalOreProduced, this.HarvesterController.OreProduced));

        return sb.ToString();
    }
}

