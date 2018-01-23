using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_Numbers
{
    public class Bomb_Numbers
    {
        public static void Main()
        {
            List<int> seqNums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bombNumAndPower = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int bomb = bombNumAndPower[0];
            int power = bombNumAndPower[1];

            for (int i = 0; i < seqNums.Count(); i++)
            {
                if (seqNums[i] == bomb)
                {
                    int startIndex = Math.Max(0, i - power);
                    seqNums.RemoveAt(i);
                    seqNums.RemoveRange(startIndex, i - power < 0 ? i : power);
                    seqNums.RemoveRange(startIndex, Math.Min(power, seqNums.Count() - startIndex));

                    i = -1;
                }
            }

            Console.WriteLine(seqNums.Sum());
        }
    }
}
