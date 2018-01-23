using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var maxSnowballSnow = 0;
            var maxSnowballTime = 0;
            BigInteger maxSnowballValue = 0;
            var maxSnowballQuality = 0;

            for (int i = 0; i < n; i++)
            {
                var snowballSnow = int.Parse(Console.ReadLine());
                var snowballTime = int.Parse(Console.ReadLine());
                var snowballQuality = int.Parse(Console.ReadLine());

                var snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if(maxSnowballValue < snowballValue)
                {
                    maxSnowballSnow = snowballSnow;
                    maxSnowballTime = snowballTime;
                    maxSnowballValue = snowballValue;
                    maxSnowballQuality = snowballQuality;
                }
            }

            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {maxSnowballValue} ({maxSnowballQuality})");
        }
    }
}
