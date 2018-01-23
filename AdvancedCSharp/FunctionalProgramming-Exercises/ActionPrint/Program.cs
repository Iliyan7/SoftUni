using System;
using System.Linq;

namespace ActionPrint
{
    public class Program
    {
        public static void Main()
        {
            Action<string> print = (w) => Console.WriteLine(w);

            Console.ReadLine()
                .Split(' ')
                .ToList()
                .ForEach(print);
        }
    }
}
