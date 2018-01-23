using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    class Program
    {
        public static void Main()
        {
            var inTheCity = new List<IIdentifiable>();

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var args = input.
                    Split(' ');

                if (args.Length > 2)
                {
                    inTheCity.Add(new Pet(args[0], int.Parse(args[1]), args[2]));
                }
                else
                {
                    inTheCity.Add(new Robot(args[0], args[1]));
                }
            }

            var n = Console.ReadLine();

            foreach (var obj in inTheCity.Where(o => o.Id.Substring(o.Id.Length - n.Length).Equals(n)))
            {
                Console.WriteLine(obj.Id);
            }
        }
    }
}
