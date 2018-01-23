using System;
using System.Linq;

namespace CustomMinFunction
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
                
            Func<int[], int> getMinNumber = (n) =>
            {
                var min = int.MaxValue;

                for (int i = 0; i < n.Length; i++)
                {
                    if (n[i] < min)
                        min = n[i];
                }

                return min;
            };

            Console.WriteLine(getMinNumber(numbers));
        }
    }
}
