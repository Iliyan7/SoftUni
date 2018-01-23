using System;

namespace Max_Method
{
    public class Max_Method
    {
        public static void Main()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            int bigger = GetMax(a, b);
            int biggest = GetMax(bigger, c);

            Console.WriteLine(biggest);
        }

        public static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}
