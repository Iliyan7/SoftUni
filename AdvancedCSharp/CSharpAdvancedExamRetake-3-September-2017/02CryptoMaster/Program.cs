using System;
using System.Linq;

namespace _02CryptoMaster
{
    class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var longestSeqCount = 1;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    var currentSeqCount = 1;
                    var prevNumber = numbers[i];
                    var stepIndex = (i + step) % numbers.Length;

                    while (prevNumber < numbers[stepIndex])
                    {
                        currentSeqCount++;
                        prevNumber = numbers[stepIndex];
                        stepIndex = (stepIndex + step) % numbers.Length;

                        if (currentSeqCount > longestSeqCount)
                        {
                            longestSeqCount = currentSeqCount;
                        }
                    }
                }
            }

            Console.WriteLine(longestSeqCount);
        }
    }
}

