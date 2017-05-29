using System;
using System.Collections.Generic;

namespace PeriodicTable
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var chemicalCompounds = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                foreach (var arg in args)
                {
                    chemicalCompounds.Add(arg);
                }
            }

            Console.WriteLine(string.Join(" ", chemicalCompounds));
        }
    }
}
