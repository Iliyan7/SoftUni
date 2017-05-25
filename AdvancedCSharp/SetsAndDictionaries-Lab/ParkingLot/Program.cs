using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ParkingLot
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var parking = new SortedSet<string>();

            while (input != "END")
            {
                var args = Regex.Split(input, ", ");

                if(args[0] == "IN")
                {
                    parking.Add(args[1]);
                }
                else if(args[0] == "OUT")
                {
                    parking.Remove(args[1]);
                }

                input = Console.ReadLine();
            }

            if(parking.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in parking)
            {
                Console.WriteLine(car);
            }
        }
    }
}
