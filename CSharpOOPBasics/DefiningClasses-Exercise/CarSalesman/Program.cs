using System;
using System.Collections.Generic;

namespace CarSalesman
{
    public class Program
    {
        public static void Main()
        {
            var engines = new List<Engine>();
            var cars = new List<Car>();

            var n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var engineInfo = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);
                var displacement = -1;
                var efficiency = "n/a";

                if (engineInfo.Length > 2)
                {
                    try
                    {
                        displacement = int.Parse(engineInfo[2]);
                    }
                    catch (Exception)
                    {
                        efficiency = engineInfo[2];
                    }
                }

                if(engineInfo.Length > 3)
                {
                    efficiency = engineInfo[3];
                }

                engines.Add(new Engine(model, power, displacement, efficiency));
            }

            var m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                var carInfo = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var model = carInfo[0];
                var engineModel = carInfo[1];
                var weight = -1;
                var color = "n/a";

                if (carInfo.Length > 2)
                {
                    try
                    {
                        weight = int.Parse(carInfo[2]);
                    }
                    catch (Exception)
                    {
                        color = carInfo[2];
                    }
                }

                if (carInfo.Length > 3)
                {
                    color = carInfo[3];
                }

                var engine = engines.Find(x => x.Model.Equals(engineModel));

                cars.Add(new Car(model, engine, weight, color));
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
