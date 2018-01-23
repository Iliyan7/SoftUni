using System;
using System.Linq;

namespace ListOfPredicates
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dividers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 1; i <= n; i++)
            {
                if(dividers.All(x => i % x == 0))
                {
                    Console.Write("{0} ", i);
                }
            }

            Console.WriteLine();
        }
    }
}
