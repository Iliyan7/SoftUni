using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 2; i <= n; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= (i / 2); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime}");
            }

        }
    }
}
