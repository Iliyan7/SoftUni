using System;
using System.Linq;

namespace Max_Sequence_of_Increasing_Elements
{
    public class Max_Sequence_of_Increasing_Elements
    {
        public static void Main()
        {
            int[] seq = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int count = 1, startIndex = 0, longestIncSeq = 1;

            for (int i = 1; i < seq.Length; i++)
            {
                if ((seq[i - 1] + 1) <= seq[i])
                {
                    count++;

                    if (count > longestIncSeq)
                    {
                        startIndex = (i - count) + 1;
                        longestIncSeq = count;
                    }
                }
                else
                {
                    count = 1;
                }
            }

            int len = startIndex + longestIncSeq;

            for (int i = startIndex; i < len; i++)
            {
                Console.Write("{0} ", seq[i]);
            }

            Console.WriteLine();
        }
    }
}
