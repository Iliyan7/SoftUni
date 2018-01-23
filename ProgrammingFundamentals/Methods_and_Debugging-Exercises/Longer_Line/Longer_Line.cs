using System;

namespace Longer_Line
{
    public class Longer_Line
    {
        public static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstLineDistance = CalculateDistanceBetweenPoints(x1, y1, x2, y2);
            double secondLineDistance = CalculateDistanceBetweenPoints(x3, y3, x4, y4);

            if (firstLineDistance > secondLineDistance)
            {
                if (CalculateDistanceToZero(x1, y1) <= CalculateDistanceToZero(x2, y2))
                    Console.WriteLine("({0}, {1})({2}, {3})", x1, y1, x2, y2);
                else
                    Console.WriteLine("({0}, {1})({2}, {3})", x2, y2, x1, y1);
            }
            else
            {
                if (CalculateDistanceToZero(x3, y3) <= CalculateDistanceToZero(x4, y4))
                    Console.WriteLine("({0}, {1})({2}, {3})", x3, y3, x4, y4);
                else
                    Console.WriteLine("({0}, {1})({2}, {3})", x4, y4, x3, y3);
            }
        }

        public static double CalculateDistanceBetweenPoints(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public static double CalculateDistanceToZero(double x, double y)
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
        }
    }
}
