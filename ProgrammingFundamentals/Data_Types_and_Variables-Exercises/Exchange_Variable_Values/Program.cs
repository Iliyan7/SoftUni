using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5, b = 10;
            Console.WriteLine("Before:\na = {0}\nb = {1}", a, b);
            Console.WriteLine("After:\na = {0}\nb = {1}", a << 1, b >> 1);
        }
    }
}
