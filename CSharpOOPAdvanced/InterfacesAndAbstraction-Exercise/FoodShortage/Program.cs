using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    class Program
    {
        public static void Main()
        {
            var buyers = new List<IBuyer>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(' ');

                if(args.Length > 3)
                {
                    buyers.Add(new Citizen(args[0], int.Parse(args[1]), args[2], args[3]));
                }
                else
                {
                    buyers.Add(new Rebel(args[0], int.Parse(args[1]), args[2]));
                }
            }

            var name = String.Empty;
            while ((name = Console.ReadLine()) != "End")
            {
                var index = buyers.FindIndex(b => (b as IPerson).Name.Equals(name));
                if (index > -1)
                {
                    buyers[index].BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
