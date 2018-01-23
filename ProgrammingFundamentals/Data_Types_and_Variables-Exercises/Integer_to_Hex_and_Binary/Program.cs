using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string hexadecimal = number.ToString("X");
            string binary = Convert.ToString(number, 2);

            Console.WriteLine("{0}\n{1}", hexadecimal, binary);
        }
    }
}
