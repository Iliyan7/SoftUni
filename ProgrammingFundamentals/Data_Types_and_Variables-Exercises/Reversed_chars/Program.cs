using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversed_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letter = new char[3];

            for (int i = 0; i < 3; i++)
            {
                letter[i] = char.Parse(Console.ReadLine());
            }

            for (int i = 2; i >= 0; i--)
            {
                Console.Write(letter[i]);
            }

            Console.WriteLine();

            /* Easier solution:
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char thirdLetter = char.Parse(Console.ReadLine());

            Console.WriteLine("{0}{1}{2}", thirdLetter, secondLetter, firstLetter);*/
        }
    }
}
