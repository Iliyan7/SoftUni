using System;

public abstract class Provider : IProvider
{
    private const int InitialDurability = 1000;
    private const int LoseDurability = 100;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public int ID { get; }

    public double EnergyOutput { get; protected set; }

    public virtual double Durability
    {
        get { return this.durability; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= LoseDurability;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }
}