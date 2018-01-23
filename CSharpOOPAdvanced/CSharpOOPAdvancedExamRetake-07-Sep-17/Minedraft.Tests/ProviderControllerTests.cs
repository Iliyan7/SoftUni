using NUnit.Framework;

[TestFixture]
public class ProviderControllerTests
{
    private IEnergyRepository energyRepository;
    private IProviderController providerController;

    [SetUp]
    public void TestInit()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(this.energyRepository);
    }

    [Test]
    public void Test1()
    {
        Assert.GreaterOrEqual(this.providerController.TotalEnergyProduced, 0);
    }

    [Test]
    public void Test2()
    {
    }

    [Test]
    public void Test3()
    {
    }

    [Test]
    public void Test4()
    {
    }
}
