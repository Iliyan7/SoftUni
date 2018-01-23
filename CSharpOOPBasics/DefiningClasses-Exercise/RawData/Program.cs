using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class Program
    {
        public static void Main()
        {
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                var model = args[0];
                var engineSpeed = int.Parse(args[1]);
                var enginePower = int.Parse(args[2]);
                var cargoWeight = int.Parse(args[3]);
                var cargoType = args[4];
                var tire1Pressure = double.Parse(args[5]);
                var tire1Age = int.Parse(args[6]);
                var tire2Pressure = double.Parse(args[7]);
                var tire2Age = int.Parse(args[8]);
                var tire3Pressure = double.Parse(args[9]);
                var tire3Age = int.Parse(args[10]);
                var tire4Pressure = double.Parse(args[11]);
                var tire4Age = int.Parse(args[12]);

                cars.Add(new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tire1Pressure, tire1Age, tire2Pressure, tire2Age, tire3Pressure, tire3Age, tire4Pressure, tire4Age));
            }

            var command = Console.ReadLine();

            cars = cars
                .Where(x => x.CargoType.Equals(command))
                .ToList();

            if(command.Equals("fragile"))
            {
                cars = cars
                    .Where(x => x.IsTirePressureUnder1)
                    .ToList();
            }
            else
            {
                cars = cars
                    .Where(x => x.EnginePower > 250)
                    .ToList();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }

        }
    }
}
