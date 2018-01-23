using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    class Program
    {
        public static void Main()
        {
            var carInfo = Console.ReadLine()
                .Split(' ');

            var truckInfo = Console.ReadLine()
               .Split(' ');

            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine()
                    .Split(' ');

                if (command[0].Equals("Drive"))
                {
                    var dist = double.Parse(command[2]);

                    if (command[1].Equals("Car"))
                    {
                        if (car.Drive(dist))
                        {
                            Console.WriteLine("Car travelled {0} km", dist);
                        }
                        else
                        {
                            Console.WriteLine("Car needs refueling");
                        }
                    }
                    else
                    {
                        if (truck.Drive(dist))
                        {
                            Console.WriteLine("Truck travelled {0} km", dist);
                        }
                        else
                        {
                            Console.WriteLine("Truck needs refueling");
                        }
                    }
                }
                else
                {
                    if (command[1].Equals("Car"))
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
