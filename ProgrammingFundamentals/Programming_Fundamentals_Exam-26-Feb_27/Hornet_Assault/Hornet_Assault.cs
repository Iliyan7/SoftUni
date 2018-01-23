using System;
using System.Collections.Generic;
using System.Linq;

namespace Hornet_Assault
{
    public class Hornet_Assault
    {
        public static void Main()
        {
            var beeHives = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var hornests = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var hornestPower = GetHornestsPower(hornests);

            for (int i = 0; i < beeHives.Count; i++)
            {
                if (hornests.Count == 0)
                    break;

                if (beeHives[i] < hornestPower)
                {
                    beeHives.RemoveAt(i);
                    i--;
                }
                else
                {
                    var leftBees = beeHives[i] - (int)hornestPower;

                    if (leftBees != 0)
                    {
                        beeHives.RemoveAt(i);
                        beeHives.Insert(i, leftBees);
                    }
                    else
                    {
                        beeHives.RemoveAt(i);
                        i--;
                    }

                    hornests.RemoveAt(0);
                    hornestPower = GetHornestsPower(hornests);
                }
            }

            if (beeHives.Count != 0) Console.WriteLine(string.Join(" ", beeHives));
            else Console.WriteLine(string.Join(" ", hornests));
        }

        public static long GetHornestsPower(List<int> hornests)
        {
            var power = 0L;

            foreach (var hornest in hornests)
            {
                power += hornest;
            }

            return power;
        }
    }
}
