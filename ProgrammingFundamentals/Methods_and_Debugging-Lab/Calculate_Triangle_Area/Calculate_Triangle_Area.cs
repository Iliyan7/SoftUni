using System;

namespace Calculate_Triangle_Area
{
    public class Calculate_Triangle_Area
    {
        public static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine(GetTriangleArea(a, b));
        }

        public static double GetTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}
