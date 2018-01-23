using System;

namespace SpeedRacing
{
    public class Car
    {
        private double fuel;
        private double fuelConsumptionFor1km;
        private int distanceTraveled;

        public Car(double fuel, double fuelConsumptionFor1km)
        {
            this.fuel = fuel;
            this.fuelConsumptionFor1km = fuelConsumptionFor1km;
            this.distanceTraveled = 0;
        }

        public double Fuel
        {
            get { return this.fuel; }
        }

        public int DistanceTraveled
        {
            get { return this.distanceTraveled; }
        }

        public void Drive(int amountOfKm)
        {
            var fuelSpent = amountOfKm * this.fuelConsumptionFor1km;

            if (fuelSpent <= this.fuel)
            {
                fuel -= fuelSpent;
                distanceTraveled += amountOfKm;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
