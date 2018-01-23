using System;

namespace Printing_Triangle
{
    public class Printing_Triangle
    {
        public static void Main()
        {
            PrintTri(int.Parse(Console.ReadLine()));
        }

        public static void PrintTri(int topNum)
        {
            for (int i = 1; i < topNum; i++)
            {
                PrintLine(i);
            }

            for (int i = topNum; i >= 1; i--)
            {
                PrintLine(i);
            }
        }

        public static void PrintLine(int numPerLine)
        {
            for (int i = 1; i <= numPerLine; i++)
            {
                Console.Write("{0} ", i);
            }
            Console.WriteLine();
        }
    }
}
