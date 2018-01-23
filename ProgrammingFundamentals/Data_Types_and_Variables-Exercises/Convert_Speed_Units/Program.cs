using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine());
            int iHours = int.Parse(Console.ReadLine());
            int iMinutes = int.Parse(Console.ReadLine());
            int iSeconds = int.Parse(Console.ReadLine());

            float hours = iHours, minutes = iMinutes, seconds = iSeconds;

            float speedInMpS = (float)distance / ((hours * 3600) + (minutes * 60) + seconds);
            float speedInKMpH = ((float)distance / 1000) / (hours + (minutes / 60) + (seconds / 3600));
            float speedInMpH = ((float)distance / 1609) / (hours + (minutes / 60) + (seconds / 3600));

            Console.WriteLine("{0}\n{1}\n{2}", speedInMpS, speedInKMpH, speedInMpH);
        }
    }
}
