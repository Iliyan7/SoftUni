using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    class Program
    {
        public static void Main()
        {
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split();

                var model = args[0];
                var fuelAmount = double.Parse(args[1]);
                var fuelConsumptionFor1km = double.Parse(args[2]);

                cars.Add(new Car(model, fuelAmount, fuelConsumptionFor1km));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var args = command
                    .Split();

                var model = args[1];
                var amountOfKm = double.Parse(args[2]);

                var car = cars.Find(c => c.Model.Equals(model));
                if(!car.Move(amountOfKm))
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1:F2} {2}", car.Model, car.FuelAmount, car.DistanceTraveled);
            }
        }
    }
}
