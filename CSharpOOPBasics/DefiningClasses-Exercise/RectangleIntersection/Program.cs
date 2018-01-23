using System;
using System.Collections.Generic;
using System.Linq;

namespace RectangleIntersection
{
    public class Program
    {
        public static void Main()
        {
            var rectangles = new Dictionary<string, Rectangle>();

            var args = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < args[0]; i++)
            {
                var rectangleInfo = Console.ReadLine()
                    .Split(' ');

                var id = rectangleInfo[0];
                var width = double.Parse(rectangleInfo[1]);
                var height = double.Parse(rectangleInfo[2]);
                var coords = new double[] { double.Parse(rectangleInfo[3]), double.Parse(rectangleInfo[4]) };

                rectangles.Add(id, new Rectangle(width, height, coords));
            }

            for (int i = 0; i < args[1]; i++)
            {
                var pairOfIDs = Console.ReadLine()
                    .Split(' ');

                Console.WriteLine(rectangles[pairOfIDs[0]].IntersectsWith(rectangles[pairOfIDs[1]]));
            }
        }
    }
}
