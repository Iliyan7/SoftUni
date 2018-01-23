using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circles_Intersection
{
    public class Circles_Intersection
    {
        public static void Main()
        {
            int[] firstCircleProp = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondCircleProp = Console.ReadLine().Split().Select(int.Parse).ToArray();

            CircleProp firstCircle = new CircleProp
            {
                X = firstCircleProp[0],
                Y = firstCircleProp[1],
                Radius = firstCircleProp[2],
            };

            CircleProp secondCircle = new CircleProp
            {
                X = secondCircleProp[0],
                Y = secondCircleProp[1],
                Radius = secondCircleProp[2],
            };

            Console.WriteLine(IsIntersect(firstCircle, secondCircle) ? "Yes" : "No");

        }

        public static bool IsIntersect(CircleProp c1, CircleProp c2)
        {

            return (CalcDist(c1.X, c1.Y, c2.X, c2.Y) <= (c1.Radius + c2.Radius));
        }

        public static double CalcDist(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }
    }
}
