using System;

namespace Center_Point
{
    public class Center_Point
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double firstDistanceToZero = CalculateDistanceToZero(x1, y1);
            double secondDistanceToZero = CalculateDistanceToZero(x2, y2);

            if (firstDistanceToZero < secondDistanceToZero)
                Console.WriteLine("({0}, {1})", x1, y1);
            else
                Console.WriteLine("({0}, {1})", x2, y2);
        }

        public static double CalculateDistanceToZero(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
