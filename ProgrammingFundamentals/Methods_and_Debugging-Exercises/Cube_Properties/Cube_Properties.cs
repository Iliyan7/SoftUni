using System;

namespace Cube_Properties
{
    public class Cube_Properties
    {
        public static void Main()
        {
            double side = double.Parse(Console.ReadLine());
            string param = Console.ReadLine();

            Console.WriteLine(Calculate(side, param)); // "{0:F2}", 
        }

        public static double Calculate(double side, string param)
        {
            double result = 0.0;

            switch (param)
            {
                case "face": result = Math.Sqrt(2 * Math.Pow(side, 2)); break;
                case "space": result = Math.Sqrt(3 * Math.Pow(side, 2)); break;
                case "volume": result = Math.Pow(side, 3);  break;
                case "area": result = 6 * Math.Pow(side, 2);  break;
            }

            return Math.Round(result, 2);
        }
    }
}
