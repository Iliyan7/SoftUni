using System;
using System.Linq;

namespace UpperStrings
{
    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(' ')
                .Select(s => s.ToUpper())
                .ToList()
                .ForEach(s => Console.Write("{0} ", s));

            Console.WriteLine();
        }
        
    }
}
