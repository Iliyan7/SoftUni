using System;
using System.Linq;

namespace Closest_Two_Points
{
    public class Closest_Two_Points
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                int[] inputCoords = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                points[i] = new Point()
                {
                    X = inputCoords[0],
                    Y = inputCoords[1]
                };
            }

            Point[] closestPoints = FindClosestPoints(points);

            Console.WriteLine("{0:F3}\r\n({1}, {2})\r\n({3}, {4})",
                CalcDistance(closestPoints[0], closestPoints[1]),
                closestPoints[0].X, closestPoints[0].Y,
                closestPoints[1].X, closestPoints[1].Y);
        }

        public static double CalcDistance(Point firstPoint, Point secondPoint)
        {
            int x1 = firstPoint.X;
            int y1 = firstPoint.Y;
            int x2 = secondPoint.X;
            int y2 = secondPoint.Y;

            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        public static Point[] FindClosestPoints(Point[] points)
        {
            double dist = double.MaxValue;
            Point[] closestPoints = new Point[2];

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    double distanceBetweenPoints = CalcDistance(points[i], points[j]);

                    if (distanceBetweenPoints < dist)
                    {
                        dist = distanceBetweenPoints;

                        closestPoints[0] = new Point()
                        {
                            X = points[i].X,
                            Y = points[i].Y
                        };

                        closestPoints[1] = new Point()
                        {
                            X = points[j].X,
                            Y = points[j].Y
                        };
                    }
                }
            }

            return closestPoints;
        }
    }
}
