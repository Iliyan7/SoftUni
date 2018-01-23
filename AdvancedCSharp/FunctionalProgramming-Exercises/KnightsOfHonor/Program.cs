using System;
using System.Linq;

namespace KnightsOfHonor
{
    public class Program
    {
        public static void Main()
        {
            Action<string> appendAndPrint = (w) => Console.WriteLine("Sir {0}", w);

            Console.ReadLine()
                .Split(' ')
                .ToList()
                .ForEach(appendAndPrint);
        }
    }
}
