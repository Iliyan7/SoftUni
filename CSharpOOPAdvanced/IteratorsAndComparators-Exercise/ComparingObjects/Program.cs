using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    class Program
    {
        public static void Main()
        {
            var people = new List<Person>();

            string personData;
            while ((personData = Console.ReadLine()) != "END")
            {
                var args = personData
                    .Split(' ');

                people.Add(new Person(args[0], int.Parse(args[1]), args[2]));
            }

            var personToCompare = people[int.Parse(Console.ReadLine()) - 1];
            var equalPeople = people.Count(p => p.CompareTo(personToCompare) == 0);

            if (equalPeople < 2)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                var notEqualPeople = people.Count - equalPeople;
                Console.WriteLine($"{equalPeople} {notEqualPeople} {people.Count}");
            }
        }
    }
}
