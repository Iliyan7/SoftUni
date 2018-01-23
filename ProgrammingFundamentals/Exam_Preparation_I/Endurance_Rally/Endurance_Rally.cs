using System;
using System.Collections.Generic;
using System.Linq;

namespace Endurance_Rally
{
    public class Endurance_Rally
    {
        public static void Main()
        {
            var drivers = Console.ReadLine().Split(' ');
            var zones = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var checkpoints = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var driversInfo = new List<Rally>();

            for (int i = 0; i < drivers.Length; i++)
            {
                var reachedZone = 0;
                var fuel = (double)drivers[i][0];

                for (int j = 0; j < zones.Length; j++)
                {
                    if (checkpoints.Contains(j))
                        fuel += zones[j];
                    else
                        fuel -= zones[j];

                    if (fuel <= 0)
                    {
                        reachedZone = j;
                        break;
                    }
                }

                driversInfo.Add(new Rally(drivers[i], fuel, reachedZone));
            }

            foreach (var driver in driversInfo)
            {
                if (driver.FuelLeft <= 0)
                    Console.WriteLine("{0} - reached {1}", driver.DriverName, driver.ReachedZone);
                else
                    Console.WriteLine("{0} - fuel left {1:F2}", driver.DriverName, driver.FuelLeft);
            }
        }
    }
}
