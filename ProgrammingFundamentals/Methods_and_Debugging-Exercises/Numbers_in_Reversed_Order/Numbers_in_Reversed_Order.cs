using System;

namespace Numbers_in_Reversed_Order
{
    public class Numbers_in_Reversed_Order
    {
        public static void Main()
        {
            PrintReversedNum(decimal.Parse(Console.ReadLine()));
        }

        public static void PrintReversedNum(decimal number)
        {
            string strNumber = number.ToString();

            for (int i = 0; i < strNumber.Length; i++)
            {
                Console.Write(strNumber[strNumber.Length - i - 1]);
            }

            Console.WriteLine();
        }
    }
}
