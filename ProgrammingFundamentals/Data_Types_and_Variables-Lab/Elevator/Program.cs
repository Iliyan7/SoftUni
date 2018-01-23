using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            int maxCapacity = int.Parse(Console.ReadLine());

            Console.WriteLine(Math.Ceiling(numPeople / (double)maxCapacity));
        }
    }
}
