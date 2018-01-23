using System;
using System.Globalization;

namespace Sino_The_Walker
{
    public class Sino_The_Walker
    {
        public static void Main()
        {
            var startingTime = DateTime.ParseExact(
                Console.ReadLine(), "HH:mm:ss", CultureInfo.InvariantCulture);
            var steps = long.Parse(Console.ReadLine());
            var secondsPerStep = long.Parse(Console.ReadLine());

            var secondsPerDay = 60 * 60 * 24;
            Console.WriteLine("Time Arrival: {0:HH:mm:ss}", startingTime.AddSeconds((steps * secondsPerStep) % secondsPerDay));
        }
    }
}
