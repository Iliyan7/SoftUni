using System;
using System.Collections.Generic;
using System.Linq;

namespace Append_Lists
{
    public class Append_Lists
    {
        public static void Main()
        {
            List<string> lists = Console.ReadLine().Split('|').ToList();

            List<string> resultList = new List<string>();

            for (int i = lists.Count() - 1; i >= 0; i--)
            {
                resultList.Add(string.Join(" ", lists[i].Split(new char[0], StringSplitOptions.RemoveEmptyEntries)));
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
