using System;
using System.Linq;

namespace Rounding_Numbers
{
    public class Rounding_Numbers
    {
        public static void Main()
        {
            double[] realNumbers = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();

            for (int i = 0; i < realNumbers.Length; i++)
            {
                Console.WriteLine("{0} => {1}", realNumbers[i], Math.Round(realNumbers[i], MidpointRounding.AwayFromZero));
            }
        }
    }
}
