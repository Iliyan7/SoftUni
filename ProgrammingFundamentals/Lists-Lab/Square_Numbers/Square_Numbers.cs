using System;
using System.Collections.Generic;
using System.Linq;

namespace Square_Numbers
{
    public class Square_Numbers
    {
        public static void Main()
        {
            List<int> intList = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<int> resultList = new List<int>();

            for (int i = 0; i < intList.Count; i++)
            {
                if (Math.Sqrt(intList[i]) % 1 == 0)
                {
                    resultList.Add(intList[i]);
                }
            }

            SortDescending(resultList);
            Console.WriteLine(string.Join(" ", resultList));
        }

        public static void SortDescending(List<int> list)
        {
            list.Sort();
            list.Reverse();
        }
    }
}
