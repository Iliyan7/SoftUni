using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments, harvesterController, providerController)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();

        sb.AppendLine(this.ProviderController.Produce());
        sb.Append(this.HarvesterController.Produce());

        return sb.ToString();
    }
}
