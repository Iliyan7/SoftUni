using System;
using System.Globalization;

namespace Softuni_Coffee_Orders
{
    public class Softuni_Coffee_Orders
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var totalPrice = 0M;

            for (int i = 0; i < n; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.CurrentCulture);
                var capsulesCount = int.Parse(Console.ReadLine());

                var currentPrice = (DateTime.DaysInMonth(orderDate.Year, orderDate.Month) * (long)capsulesCount) * pricePerCapsule;
                totalPrice += currentPrice;

                Console.WriteLine("The price for the coffee is: ${0:F2}", currentPrice);
            }

            Console.WriteLine("Total: ${0:F2}", totalPrice);
        }
    }
}
