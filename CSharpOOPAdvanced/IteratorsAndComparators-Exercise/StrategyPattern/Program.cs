using StrategyPattern.Comparators;
using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        public static void Main()
        {
            var sortedSetByName = new SortedSet<Person>(new NameComparator());
            var sortedSetByAge = new SortedSet<Person>(new AgeComparator());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                var person = new Person(args[0], int.Parse(args[1]));

                sortedSetByName.Add(person);
                sortedSetByAge.Add(person);
            }

            foreach (var person in sortedSetByName)
            {
                Console.WriteLine(person);
            }

            foreach (var person in sortedSetByAge)
            {
                Console.WriteLine(person);
            }
        }
    }
}
