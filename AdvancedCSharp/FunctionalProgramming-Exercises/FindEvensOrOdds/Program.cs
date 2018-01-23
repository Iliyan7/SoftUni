using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    public class Program
    {
        public static void Main()
        {
            var range = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var command = Console.ReadLine();

            Predicate<int> isEven = (n) => n % 2 == 0;

            var foundNumbers = new List<int>();

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (command == "even" && isEven(i))
                    foundNumbers.Add(i);
                else if (command == "odd" && !isEven(i))
                    foundNumbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", foundNumbers));
        }
    }
}
