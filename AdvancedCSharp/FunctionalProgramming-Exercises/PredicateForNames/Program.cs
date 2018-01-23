using System;
using System.Linq;

namespace PredicateForNames
{
    public class Program
    {
        public static void Main()
        {
            var maxLen = int.Parse(Console.ReadLine());

            Console.ReadLine()
                .Split(' ')
                .Where(w => w.Length <= maxLen)
                .ToList()
                .ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}
