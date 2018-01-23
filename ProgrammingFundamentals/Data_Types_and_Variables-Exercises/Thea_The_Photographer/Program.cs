using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            int picturesAmount = int.Parse(Console.ReadLine());
            int filterTime = int.Parse(Console.ReadLine());
            int filterFactor = int.Parse(Console.ReadLine());
            int uploadTime = int.Parse(Console.ReadLine());

            int usefulPictures = (int)Math.Ceiling(picturesAmount * (filterFactor / 100.0));

            long totalPictures = picturesAmount * (long)filterTime;
            long uploadedPictures = usefulPictures * (long)uploadTime;

            TimeSpan secondsSpan = TimeSpan.FromSeconds(totalPictures + uploadedPictures);

            Console.WriteLine(secondsSpan.ToString(new string('d', 1) + @"\:hh\:mm\:ss"));
        }
    }
}
