namespace SpeedRacing
{
    internal class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionFor1km;
        private double distanceTraveled;

        public Car(string model, double fuelAmount, double fuelConsumptionFor1km)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumptionFor1km = fuelConsumptionFor1km;
            this.distanceTraveled = 0;
        }

        public string Model => this.model;

        public double FuelAmount => this.fuelAmount;

        public double DistanceTraveled => this.distanceTraveled;

        public bool Move(double amountOfKm)
        {
            var neededFuel = amountOfKm * this.fuelConsumptionFor1km;

            if (neededFuel <= this.fuelAmount)
            {
                this.fuelAmount -= neededFuel;
                this.distanceTraveled += amountOfKm;

                return true;
            }

            return false;
        }
    }
}