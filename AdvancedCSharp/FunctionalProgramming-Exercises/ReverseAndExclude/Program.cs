using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            var d = int.Parse(Console.ReadLine());

            var newCollection = new List<int>();

            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Predicate<int> isDivisible = n => n % d == 0;

                if(!isDivisible(numbers[i]))
                    newCollection.Add(numbers[i]);
            }

            Console.WriteLine(string.Join(" ", newCollection));
        }
    }
}
