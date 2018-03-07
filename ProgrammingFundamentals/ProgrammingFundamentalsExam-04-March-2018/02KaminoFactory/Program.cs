using System;
using System.Linq;

namespace _02KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var bestSequenceIndex = 0;
            var bestSequenceSum = 0;
            var bestDnaSequance = new int[n];

            var longestSubsequanceLen = 0;
            var bestSubsequanceStartIndex = 0;
            var sequanceIndex = 1;
            var firstSequance = true;

            var sequanceStr = string.Empty;
            while ((sequanceStr = Console.ReadLine()) != "Clone them!")
            {
                var dnaSample = sequanceStr
                    .Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var currentSubsequanceLen = 0;
                var currentSubsequanceStartIndex = 0;

                FindLongestSubsequence(dnaSample, out currentSubsequanceLen, out currentSubsequanceStartIndex);

                if (longestSubsequanceLen <= currentSubsequanceLen)
                {
                    if (firstSequance || (bestSubsequanceStartIndex > currentSubsequanceStartIndex))
                    {
                        firstSequance = false;

                        longestSubsequanceLen = currentSubsequanceLen;
                        bestSubsequanceStartIndex = currentSubsequanceStartIndex;

                        bestSequenceIndex = sequanceIndex;
                        bestSequenceSum = dnaSample.Sum();
                        Array.Copy(dnaSample, bestDnaSequance, n);
                    }
                    else if(bestSubsequanceStartIndex == currentSubsequanceStartIndex)
                    {
                        if (bestSequenceSum < dnaSample.Sum())
                        {
                            longestSubsequanceLen = currentSubsequanceLen;
                            bestSubsequanceStartIndex = currentSubsequanceStartIndex;
                            
                            bestSequenceIndex = sequanceIndex;
                            bestSequenceSum = dnaSample.Sum();
                            Array.Copy(dnaSample, bestDnaSequance, n);
                        }
                    }
                }

                sequanceIndex++;
            }

            Console.WriteLine($"Best DNA sample {bestSequenceIndex} with sum: {bestSequenceSum}.");
            Console.WriteLine(string.Join(" ", bestDnaSequance));
        }

        private static void FindLongestSubsequence(int[] dnaSample, out int longestSubsequanceLen, out int longestSubsequanceStartIndex)
        {
            var currentSubsequanceLen = 0;
            longestSubsequanceLen = 0;
            longestSubsequanceStartIndex = 0;

            for (int i = 0; i < dnaSample.Length; i++)
            {       
                if (dnaSample[i] == 1)
                {
                    currentSubsequanceLen++;

                    if(longestSubsequanceLen < currentSubsequanceLen)
                    {
                        longestSubsequanceLen = currentSubsequanceLen;
                        longestSubsequanceStartIndex = i - (longestSubsequanceLen - 1);
                    }
                }
                else
                {
                    currentSubsequanceLen = 0;
                }
            }
        }
    }
}
