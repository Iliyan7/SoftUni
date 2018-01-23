using System;

namespace Hornet_Wings
{
    public class Hornet_Wings
    {
        public static void Main()
        {
            var wingFlaps = int.Parse(Console.ReadLine());
            var distanceFor1000WingFlaps = double.Parse(Console.ReadLine());
            var endurance = int.Parse(Console.ReadLine());

            var metersTraveled = (wingFlaps / 1000.0) * distanceFor1000WingFlaps;
            var secondsPassed = (wingFlaps / 100) + ((wingFlaps / endurance) * 5);

            Console.WriteLine("{0:F2} m.", metersTraveled);
            Console.WriteLine("{0} s.", secondsPassed);
        }
    }
}
