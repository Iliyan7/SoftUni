namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override bool Drive(double distance)
        {
            var neededFuel = fuelConsumption * distance + 1.6 * distance;

            if (neededFuel <= fuelQuantity)
            {
                fuelQuantity -= neededFuel;
                return true;
            }

            return false;
        }

        public override void Refuel(double liters)
        {
            this.fuelQuantity += liters * 0.95;
        }

        public override string ToString()
        {
            return $"Truck: {this.fuelQuantity:F2}";
        }
    }
}
