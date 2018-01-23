using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                int lastDigit = i, sum = 0;

                while (lastDigit != 0)
                {
                    sum += lastDigit % 10;
                    lastDigit = lastDigit / 10;
                }

                bool isSpecial = ((sum == 5) || (sum == 7) || (sum == 11));
                Console.WriteLine("{0} -> {1}", i, isSpecial);
            }
        }
    }
}
