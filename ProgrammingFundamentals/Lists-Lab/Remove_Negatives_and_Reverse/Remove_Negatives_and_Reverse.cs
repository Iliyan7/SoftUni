using System;
using System.Collections.Generic;
using System.Linq;

namespace Remove_Negatives_and_Reverse
{
    public class Remove_Negatives_and_Reverse
    {
        public static void Main()
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            for (int i = 0; i < nums.Count(); i++)
            {
                if (nums[i] < 0)
                    nums.RemoveAt(i--);
            }

            nums.Reverse();

            if (nums.Count > 0)
                Console.WriteLine(string.Join(" ", nums));
            else
                Console.WriteLine("empty");
        }
    }
}
