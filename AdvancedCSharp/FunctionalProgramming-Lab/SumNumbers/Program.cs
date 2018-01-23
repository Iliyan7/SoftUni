using System;
using System.Linq;

namespace SumNumbers
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                  .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(n => int.Parse(n))
                  .ToArray();

            Console.WriteLine(numbers.Count());
            Console.WriteLine(numbers.Sum());
        }
    }
}
