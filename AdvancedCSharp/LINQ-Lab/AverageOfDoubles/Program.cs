using System;
using System.Linq;

namespace AverageOfDoubles
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("{0:F2}", Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Average());
        }
    }
}
