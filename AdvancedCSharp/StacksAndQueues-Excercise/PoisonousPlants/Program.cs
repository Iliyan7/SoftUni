using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoisonousPlants
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var plants = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

           
        }
    }
}
