using System;
using System.Linq;

namespace Pairs_by_Difference
{
    public class Pairs_by_Difference
    {
        public static void Main()
        {
            int[] seq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int difference = int.Parse(Console.ReadLine());

            Array.Sort(seq);

            int startPos = seq.Length - 1, pairs = 0;

            for (int i = startPos; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (seq[i] - seq[j] == difference)
                        pairs++;
                }
            }

            Console.WriteLine(pairs);
        }
    }
}
