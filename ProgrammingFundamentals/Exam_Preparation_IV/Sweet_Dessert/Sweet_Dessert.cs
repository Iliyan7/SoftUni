using System;

namespace Sweet_Dessert
{
    public class Sweet_Dessert
    {
        public static void Main()
        {
            var cash = double.Parse(Console.ReadLine());
            var guests = int.Parse(Console.ReadLine());
            var bananasPrice = double.Parse(Console.ReadLine());
            var eggsPrice = double.Parse(Console.ReadLine());
            var berriesPrice = double.Parse(Console.ReadLine());

            var neededDeserts = (int)Math.Ceiling(guests / 6.0);

            var neededBanans = neededDeserts * 2;
            var neededEggs = neededDeserts * 4;
            var neededBerriesInKilos = neededDeserts * 0.2;

            var neededCash = (neededBanans * bananasPrice) + (neededEggs * eggsPrice) + (neededBerriesInKilos * berriesPrice);

            if (cash >= neededCash)
                Console.WriteLine("Ivancho has enough money - it would cost {0:F2}lv.", neededCash);
            else
                Console.WriteLine("Ivancho will have to withdraw money - he will need {0:F2}lv more.", neededCash - cash);
        }
    }
}
