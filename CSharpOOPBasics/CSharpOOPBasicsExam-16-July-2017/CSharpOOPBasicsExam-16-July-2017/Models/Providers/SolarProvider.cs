using System.Text;

//namespace CSharpOOPBasicsExam_16_July_2017
//{
class SolarProvider : Provider
{
    public SolarProvider(string id, double energyOutput)
        : base(id, energyOutput)

    {
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Solar Provider - {this.Id}");
        sb.Append($"Energy Output: {this.EnergyOutput}");

        return sb.ToString();
    }
}
//}
