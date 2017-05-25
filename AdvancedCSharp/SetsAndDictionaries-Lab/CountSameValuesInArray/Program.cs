using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var values = new SortedDictionary<double, int>();

            foreach (var entry in input)
            {
                if (!values.ContainsKey(entry))
                    values.Add(entry, 0);

                values[entry]++;
            }

            foreach (var pair in values)
            {
                Console.WriteLine("{0} - {1} times", pair.Key, pair.Value);
            }
        }
    }
}
