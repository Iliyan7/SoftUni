using System.Collections.Generic;
using System.Linq;
using System.Text;

public class InspectCommand : Command
{
    public InspectCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var id = int.Parse(this.Arguments[0]);

        var provider = this.HarvesterController.Entities.FirstOrDefault(p => p.ID == id);
        var harvester = this.ProviderController.Entities.FirstOrDefault(p => p.ID == id);

        var sb = new StringBuilder();

        if (provider != null)
        {
            sb.AppendLine(provider.GetType().Name);
            sb.Append(string.Format(Constants.EntityFound, provider.Durability));
        }
        else if (harvester != null)
        {
            sb.AppendLine(harvester.GetType().Name);
            sb.Append(string.Format(Constants.EntityFound, harvester.Durability));
        }
        else
        {
            sb.Append(string.Format(Constants.NoEntityFound, id));
        }

        return sb.ToString(); 
    }
}
