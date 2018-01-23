using System;
using System.Linq;

namespace SortEvenNumbers
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .Where(n => n % 2 == 0)
                .OrderBy(n => n)));
        }
    }
}
