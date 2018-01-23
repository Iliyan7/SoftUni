using System;
using System.Linq;

namespace _02CryptoMaster
{
    class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var longestSeqCount = 1;
            var currentSeqCount = 0;
            var prevNumber = 0;
            var stepIndex = 0;

            for (int step = 1; step < numbers.Length; step++)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    currentSeqCount = 0;
                    prevNumber = numbers[i];
                    stepIndex = step;

                    while (prevNumber < numbers[stepIndex % numbers.Length])
                    {
                        currentSeqCount++;
                        prevNumber = numbers[stepIndex % numbers.Length];
                        stepIndex += step;

                        if (currentSeqCount > longestSeqCount)
                        {
                            longestSeqCount++;
                        }
                    }
                }
            }

            Console.WriteLine(longestSeqCount);
        }
    }
}

