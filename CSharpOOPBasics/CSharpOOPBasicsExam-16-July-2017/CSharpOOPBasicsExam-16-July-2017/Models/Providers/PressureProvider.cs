using System.Text;

//namespace CSharpOOPBasicsExam_16_July_2017
//{
class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput)
        : base(id, energyOutput)
    {
        this.EnergyOutput *= 1.0 + (50 / 100.0); 
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Pressure Provider - {this.Id}");
        sb.Append($"Energy Output: {this.EnergyOutput}");

        return sb.ToString();
    }
}
//}
