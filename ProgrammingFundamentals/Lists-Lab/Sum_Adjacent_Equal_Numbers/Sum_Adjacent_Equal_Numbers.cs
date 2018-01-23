using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Adjacent_Equal_Numbers
{
    public class Sum_Adjacent_Equal_Numbers
    {
        public static void Main()
        {
            List<decimal> list = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            for (int i = 0; i < list.Count() - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    list[i] = list[i] + list[i + 1];
                    list.RemoveAt(i + 1);
                    i = -1;
                }

            }

            Console.WriteLine(string.Join(" ", list));
        }
    }
}
