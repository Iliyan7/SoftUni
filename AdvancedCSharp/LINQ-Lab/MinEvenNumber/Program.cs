using System;
using System.Linq;

namespace MinEvenNumber
{
    public class Program
    {
        public static void Main()
        {
            var evenNumbers = Console.ReadLine()
                .Split(' ')
                .Select(double.Parse)
                .Where(n => n % 2 == 0);

            if(evenNumbers.Count() == 0)
            {
                Console.WriteLine("No match");
                return;
            }

            Console.WriteLine("{0:F2}", evenNumbers.Min());
                
        }
    }
}
