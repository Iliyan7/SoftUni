using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var lake = new Lake(numbers);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
