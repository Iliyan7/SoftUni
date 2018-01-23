using NUnit.Framework;
using System;

[TestFixture]
public class MissionControllerTests
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;

    [SetUp]
    public void TestInit()
    {
        army = new Army();
        wareHouse = new WareHouse();
        missionController = new MissionController(army, wareHouse);
    }

    [Test]
    public void Test1()
    {
        // Arange

        // Act

        // Assert
        Assert.GreaterOrEqual(missionController.FailedMissionCounter, 0);
    }

    [Test]
    public void Test2()
    {
        // Arange
        

        // Act

        // Assert
    }

    [Test]
    public void Test3()
    {
        // Arange
        IMission easy = new Easy(100);
        IMission medium = new Medium(100);
        IMission hard = new Hard(100);

        // Act
        this.missionController.Missions.Enqueue(easy);
        this.missionController.Missions.Enqueue(medium);
        this.missionController.Missions.Enqueue(hard);
        var result = this.missionController.PerformMission(hard);

        // Assert
        var missionDeclinedMessage = string.Format(OutputMessages.MissionDeclined + Environment.NewLine, easy.Name);
        result = result.Substring(0, missionDeclinedMessage.Length);
        Assert.AreEqual(missionDeclinedMessage, result);
    }

    [Test]
    public void Test4()
    {
        // Arange
        IMission mission = new Easy(100);

        // Act
        this.army.AddSoldier(new Ranker("Ivan", 21, 100, 100));
        this.wareHouse.AddAmmunitions("Gun", 10);
        this.wareHouse.AddAmmunitions("AutomaticMachine", 10);
        this.wareHouse.AddAmmunitions("Helmet", 10);
        var result = this.missionController.PerformMission(mission);

        // Assert
        Assert.AreEqual(string.Format(OutputMessages.MissionSuccessful + Environment.NewLine, mission.Name), result);
    }
}