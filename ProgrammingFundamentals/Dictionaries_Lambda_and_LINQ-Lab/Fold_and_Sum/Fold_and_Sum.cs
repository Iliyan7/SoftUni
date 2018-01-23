using System;
using System.Collections.Generic;
using System.Linq;

namespace Fold_and_Sum
{
    public class Fold_and_Sum
    {
        public static void Main()
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int k = array.Length / 2;
            int fold = k / 2;

            int[] row1 = array
                .Reverse()
                .Skip(k + fold)
                .Take(fold)
                .Concat(array
                .Reverse()
                .Take(fold))
                .ToArray();

            int[] row2 = array
                .Skip(fold)
                .Take(k)
                .ToArray();

            Console.WriteLine(string.Join(" ", row1.Select((x, i) => x + row2[i])));
        }
    }
}
