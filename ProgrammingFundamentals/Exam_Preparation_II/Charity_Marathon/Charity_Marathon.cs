using System;

namespace Charity_Marathon
{
    public class Charity_Marathon
    {
        public static void Main()
        {
            var marathonDays = int.Parse(Console.ReadLine());
            var runnersCount = int.Parse(Console.ReadLine());
            var avgLapsPerRunner = int.Parse(Console.ReadLine());
            var trackLength = int.Parse(Console.ReadLine());
            var trackCapacity = int.Parse(Console.ReadLine());
            var donatedMoneyPerKM = double.Parse(Console.ReadLine());

            runnersCount = Math.Min(runnersCount, marathonDays * trackCapacity);
            var totalKilometers = (runnersCount * avgLapsPerRunner * (long)trackLength) / 1000;

            Console.WriteLine("Money raised: {0:F2}", totalKilometers * donatedMoneyPerKM);
        }
    }
}
