using System;
using System.Linq;

namespace AddVAT
{
    public class Program
    {
        public static void Main()
        {
            Func<string, double> parseAndAddVAT = n => double.Parse(n) * 1.20;

            Console.ReadLine()
                .Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(parseAndAddVAT)
                .ToList()
                .ForEach(n => Console.WriteLine("{0:F2}", n));
        }
    }
}
