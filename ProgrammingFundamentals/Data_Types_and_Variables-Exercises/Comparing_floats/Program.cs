using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberA = double.Parse(Console.ReadLine());
            double numberB = double.Parse(Console.ReadLine());

            if (Math.Abs(numberA - numberB) <= 0.000001)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
        }
    }
}
