using System;

namespace Last_K_Numbers_Sums
{
    public class Last_K_Numbers_Sums
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            long[] seq = new long[n];
            seq[0] = 1;

            for (int i = 1; i < seq.Length; i++)
            {
                long sum = 0;

                for (int j = Math.Max(0, i - k); j < i; j++)
                {
                    sum += seq[j];
                }

                seq[i] = sum;
            }

            Console.WriteLine(string.Join(" ", seq));
        }
    }
}
