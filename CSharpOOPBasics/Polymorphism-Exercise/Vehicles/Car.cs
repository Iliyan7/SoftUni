namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override bool Drive(double distance)
        {
            var neededFuel = fuelConsumption * distance + 0.9 * distance;

            if (neededFuel <= fuelQuantity)
            {
                fuelQuantity -= neededFuel;
                return true;
            }

            return false;
        }

        public override void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"Car: {this.fuelQuantity:F2}";
        }
    }
}
