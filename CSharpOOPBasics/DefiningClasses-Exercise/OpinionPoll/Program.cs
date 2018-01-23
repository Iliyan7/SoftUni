using System;
using System.Collections.Generic;
using System.Linq;

namespace OpinionPoll
{
    public class Program
    {
        public static void Main()
        {
            var peoples = new List<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                var person = new Person(args[0], int.Parse(args[1]));
                peoples.Add(person);
            }

            foreach (var person in peoples.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.WriteLine("{0} - {1}", person.Name, person.Age);
            }
        }
    }
}
