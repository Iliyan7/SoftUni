using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalSum = 0; int tempNum = 0; bool special = false;
            for (int num = 1; num <= n; num++)
            {
                tempNum = num;
                while (num > 0)
                {
                    totalSum += num % 10;
                    num = num / 10;
                }
                special = (totalSum == 5) || (totalSum == 7) || (totalSum == 11);
                Console.WriteLine($"{tempNum} -> {special}");
                totalSum = 0;
                num = tempNum;
            }

        }
    }
}
