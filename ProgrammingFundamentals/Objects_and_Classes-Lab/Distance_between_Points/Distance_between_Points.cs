using System;
using System.Linq;

namespace Distance_between_Points
{
    public class Distance_between_Points
    {
        public static void Main()
        {
            int[] firstPointCoord = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondPointCoord = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Point firstPoint = new Point
            {
                X = firstPointCoord[0],
                Y = firstPointCoord[1]
            };

            Point secondPoint = new Point
            {
                X = secondPointCoord[0],
                Y = secondPointCoord[1]
            };

            Console.WriteLine("{0:F3}", CalcDistance(firstPoint, secondPoint));
        }

        public static double CalcDistance(Point firstPoint, Point secondPoint)
        {
            int x1 = firstPoint.X;
            int y1 = firstPoint.Y;
            int x2 = secondPoint.X;
            int y2 = secondPoint.Y;

            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }
}
