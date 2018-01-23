using System;

namespace Sign_of_Integer_Number
{
    public class Sign_of_Integer_Number
    {
        public static void Main()
        {
            PrintSign(int.Parse(Console.ReadLine()));
        }

        public static void PrintSign(int number)
        {
            if (number < 0) Console.WriteLine("The number {0} is negative.", number);
            else if (number == 0) Console.WriteLine("The number {0} is zero.", number);
            else Console.WriteLine("The number {0} is positive.", number);
        }
    }
}
