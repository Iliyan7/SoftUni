using System;
using System.Linq;

namespace GroupNumbers
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

            // Create and fill an array with remainder for each cell
            var indexRemainder = new int[numbers.Length];

            for (int i = 0; i < numbers.Length; i++)
            {
                indexRemainder[i] = Math.Abs(numbers[i]) % 3;
            }

            // Creating the jagged array with correct size for each dimension
            var jaggedArray = new int[3][];

            for (int i = 0; i < 3; i++)
            {
                jaggedArray[i] = new int[indexRemainder.Count(x => x == i)];
            }

            // Filling the jagged array
            var indexes = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                jaggedArray[indexRemainder[i]][indexes[indexRemainder[i]]++] = numbers[i];
            }

            // Printing the result
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(string.Join(" ", jaggedArray[i]));
            }
        }
    }
}
