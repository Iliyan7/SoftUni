public class SolarProvider : Provider
{
    private const int DurabilityMultiplier = 500;

    public SolarProvider(int id, double energyOutput)
    : base(id, energyOutput)
    {
        this.Durability *= DurabilityMultiplier;
    }
}
