namespace Vehicles
{
    public abstract class Vehicle
    {
        protected double fuelQuantity;
        protected double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public abstract bool Drive(double distance);
        public abstract void Refuel(double liters);
    }
}
