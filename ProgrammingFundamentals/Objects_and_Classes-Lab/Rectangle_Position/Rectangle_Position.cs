using System;
using System.Linq;

namespace Rectangle_Position
{
    public class Rectangle_Position
    {
        public static void Main()
        {
            int[] firstReactangleProp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondReactangleProp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Rectangle firstReactangle = new Rectangle
            {
                Left = firstReactangleProp[0],
                Top = firstReactangleProp[1],
                Width = firstReactangleProp[2],
                Height = firstReactangleProp[3]
            };

            Rectangle secondReactangle = new Rectangle
            {
                Left = secondReactangleProp[0],
                Top = secondReactangleProp[1],
                Width = secondReactangleProp[2],
                Height = secondReactangleProp[3]
            };

            Console.WriteLine(firstReactangle.IsInside(secondReactangle) ? "Inside" : "Not Inside");
        }
    }
}
