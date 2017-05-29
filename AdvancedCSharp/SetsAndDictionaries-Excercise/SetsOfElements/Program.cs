using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    public class Program
    {
        public static void Main()
        {
            var lengthSets = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < lengthSets[0]; i++)
            {
                firstSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < lengthSets[1]; i++)
            {
                var m = int.Parse(Console.ReadLine());

                if (firstSet.Contains(m))
                    secondSet.Add(m);  
            }

            Console.WriteLine(string.Join(" ", secondSet));
        }
    }
}
