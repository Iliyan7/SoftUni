using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest_3_Numbers
{
    public class Largest_3_Numbers
    {
        public static void Main()
        {
            List<double> realNums = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            Console.WriteLine(string.Join(" ", realNums.OrderByDescending(x => x).Take(3)));
        }
    }
}
