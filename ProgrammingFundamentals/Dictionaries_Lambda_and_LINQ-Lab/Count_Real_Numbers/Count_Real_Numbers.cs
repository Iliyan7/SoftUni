using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Real_Numbers
{
    public class Count_Real_Numbers
    {
        public static void Main()
        {
            List<double> realNumbers = Console.ReadLine().Split(' ').Select(double.Parse).ToList();

            SortedDictionary<double, int> counts = new SortedDictionary<double, int>();

            foreach (var num in realNumbers)
            {
                if (!counts.ContainsKey(num))
                {
                    counts[num] = 0;
                }

                counts[num]++;
            }

            foreach (KeyValuePair<double, int> pair in counts)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}
