using System;
using System.Linq;

namespace TakeTwo
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .Where(n => 10 <= n && n <= 20)
                .Distinct()
                .Take(2)
                .ToList()
                .ForEach(n => Console.Write("{0} ", n));
        }
    }
}
