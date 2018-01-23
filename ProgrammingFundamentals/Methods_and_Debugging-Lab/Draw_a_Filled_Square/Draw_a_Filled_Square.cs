using System;

namespace Draw_a_Filled_Square
{
    public class Draw_a_Filled_Square
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            PrintTopOfSquare(n);
            PrintMiddleOfSquare(n);
            PrintBottomOfSquare(n);
        }

        public static void PrintTopOfSquare(int len)
        {
            Console.WriteLine(new string('-', len * 2));
        }

        public static void PrintMiddleOfSquare(int len)
        {
            for (int i = 0; i < len - 2; i++)
            {
                Console.WriteLine("-{0}-", MultipleString("\\/", len - 1));
            }
        }

        public static string MultipleString(string strName, int count)
        {
            string result = null;

            for (int i = 0; i < count; i++)
            {
                result += strName;
            }

            return result;
        }

        public static void PrintBottomOfSquare(int len)
        {
            PrintTopOfSquare(len);
        }
    }
}
