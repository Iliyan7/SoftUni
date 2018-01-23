using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoundedNumbers
{
    public class Program
    {
        public static void Main()
        {
            var boundedNumbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse);

            var lowerBound = boundedNumbers
                .Min();

            var upperBound = boundedNumbers
                .Max();

           Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => lowerBound <= n && n <= upperBound)
                .ToList()
                .ForEach(n => Console.Write("{0} ", n));

            Console.WriteLine();
        }
    }
}
