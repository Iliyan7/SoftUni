using System.Collections.Generic;

//namespace CSharpOOPBasicsExam_16_July_2017.Factories
//{
public class HarvesterFactory
{
    public Harvester Get(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(id, oreOutput, energyRequirement, int.Parse(arguments[4]));
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            default:
                return null;
        }
    }
}
//}
