using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var petrolPumps = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                petrolPumps.Enqueue(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());
            }

            for (int i = 0; i < n; i++)
            {
                if(IsCorrectPetrolPump(petrolPumps, n))
                {
                    Console.WriteLine(i);
                    break;
                }

                int[] previousPump = petrolPumps.Dequeue();
                petrolPumps.Enqueue(previousPump);
            }
        }

        public static bool IsCorrectPetrolPump(Queue<int[]> petrolPumps, int totalPumps)
        {
            var fuel = 0;
            var isFuelInTank = true;
            for (int i = 0; i < totalPumps; i++)
            {
                var currentPump = petrolPumps.Dequeue();
                petrolPumps.Enqueue(currentPump);

                fuel += currentPump[0] - currentPump[1];

                if (fuel < 0)
                    isFuelInTank = false;
            }

            return isFuelInTank;
        }
    }
}
