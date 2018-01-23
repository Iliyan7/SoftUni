using System;

namespace Math_Power
{
    public class Math_Power
    {
        public static void Main()
        {
            double baseNumber = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());

            Console.WriteLine(PowNums(baseNumber, power));
        }

        public static double PowNums(double baseNumber, double power)
        {
            double result = baseNumber;

            for (int i = 1; i < power; i++)
            {
                result *= baseNumber;
            }

            return result;
        }
    }
}
