using System;
using System.Collections.Generic;
using System.Linq;

namespace Sort_Numbers
{
    public class Sort_Numbers
    {
        public static void Main()
        {
            List<decimal> unsortedList = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            unsortedList.Sort();

            Console.WriteLine(string.Join(" <= ", unsortedList));
        }
    }
}
