using System.Collections.Generic;

//namespace CSharpOOPBasicsExam_16_July_2017.Factories
//{
public class ProviderFactory
{
    public Provider Get(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                return null;
        }
    }
}
//}
