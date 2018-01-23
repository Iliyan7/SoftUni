using System;
using System.Collections.Generic;
using System.Linq;

namespace Count_Numbers
{
    public class Count_Numbers
    {
        public static void Main()
        {
            List<int> intList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            intList.Sort();

            int[] count = new int[intList.Count];
            count = count.Select(x => 1).ToArray();

            int nextInt = 0, j = 0;

            for (int i = 0; i < intList.Count(); i++)
            {
                nextInt = (i + 1) < intList.Count() ? intList[i + 1] : int.MaxValue;

                if (intList[i] == nextInt)
                {
                    count[j]++;
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", intList[i], count[j]);
                    j++;
                }
            }
        }
    }
}
