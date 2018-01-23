using System;
using System.Collections.Generic;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    public class Max_Sequence_of_Equal_Elements
    {
        public static void Main()
        {
            List<int> seq = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            seq.Add(int.MaxValue);

            List<int> longestSeq = new List<int>();
            longestSeq.Add(seq[0]);

            int count = 1;

            for (int i = 0; i < seq.Count() - 1; i++)
            {
                if (seq[i] == seq[i + 1])
                {
                    count++;

                    if (longestSeq.Count() < count)
                    {
                        longestSeq.Clear();
                        longestSeq.AddRange(seq.Skip((i+1)-(count-1)).Take(count));
                    }
                }
                else
                {
                    count = 1;
                }
            }

            Console.WriteLine(string.Join(" ", longestSeq));
        }
    }
}
