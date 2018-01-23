using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        public static void Main()
        {
            var cars = new Dictionary<string, Car>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                var model = args[0];
                var fuelAmount = double.Parse(args[1]);
                var fuelConsumptionFor1km = double.Parse(args[2]);

                cars.Add(model, new Car(fuelAmount, fuelConsumptionFor1km));
            }

            var command = String.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandArgs = command
                    .Split(' ');

                var model = commandArgs[1];
                var amountOfKm = int.Parse(commandArgs[2]);

                cars[model].Drive(amountOfKm);
            }

            foreach (var car in cars)
            {
                Console.WriteLine("{0} {1:F2} {2}", car.Key, car.Value.Fuel, car.Value.DistanceTraveled);
            }
        }
    }
}
