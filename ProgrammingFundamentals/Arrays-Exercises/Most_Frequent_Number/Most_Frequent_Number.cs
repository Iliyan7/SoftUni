using System;
using System.Collections.Generic;
using System.Linq;

namespace Most_Frequent_Number
{
    public class Most_Frequent_Number
    {
        public static void Main()
        {
            int[] seq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Console.WriteLine(GetMostFrequentNum(seq, seq.Length));
        }

        public static int GetMostFrequentNum(int[] seq, int len)
        {
            Dictionary<int, int> counts = seq.GroupBy(x => x).ToDictionary(d => d.Key, d => d.Count());

            return counts.FirstOrDefault(x => x.Value == counts.Max(y => y.Value)).Key;
        }
    }
}
