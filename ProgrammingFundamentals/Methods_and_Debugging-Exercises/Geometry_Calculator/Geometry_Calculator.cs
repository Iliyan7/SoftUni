using System;

namespace Geometry_Calculator
{
    public class Geometry_Calculator
    {
        public static void Main()
        {
            string figure = Console.ReadLine();

            double value1 = 0.0, value2 = 0.0;

            switch (figure)
            {
                case "triangle":
                    {
                        value1 = double.Parse(Console.ReadLine());
                        value2 = double.Parse(Console.ReadLine());
                        break;
                    }
                case "square":
                    {
                        value1 = double.Parse(Console.ReadLine());
                        break;
                    }
                case "rectangle":
                    {
                        value1 = double.Parse(Console.ReadLine());
                        value2 = double.Parse(Console.ReadLine());
                        break;
                    }
                case "circle":
                    {
                        value1 = double.Parse(Console.ReadLine());
                        break;
                    }
            }

            Console.WriteLine(CalculateArea(value1, value2, figure));
        }

        public static double CalculateArea(double value1, double value2, string figure)
        {
            double area = 0.0;

            switch (figure)
            {
                case "triangle": area = (value1 * value2) / 2; break;
                case "square": area = value1 * value1; break;
                case "rectangle": area = value1 * value2; break;
                case "circle": area = value1 * value1 * Math.PI; break;
            }

            return Math.Round(area, 2);
        }
    }
}
