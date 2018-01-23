using System;
using System.Collections.Generic;
using System.Linq;

namespace DefineAClassPerson
{
    class Program
    {
        public static void Main()
        {
            var people = new List<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split();

                people.Add(new Person(args[0], int.Parse(args[1])));
            }

            foreach (var person in people.Where(p => p.Age > 30).OrderBy(p => p.Name))
            {
                Console.WriteLine("{0} - {1}", person.Name, person.Age);
            }
        }
    }
}
