using System.Text;

//namespace CSharpOOPBasicsExam_16_July_2017
//{
public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput *= 1.0 + (200 / 100.0);
        this.EnergyRequirement *= 1.0 + (100 / 100.0);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Hammer Harvester - {this.Id}");
        sb.AppendLine($"Ore Output: {this.OreOutput}");
        sb.Append($"Energy Requirement: {this.EnergyRequirement}");

        return sb.ToString();
    }
}
//}
