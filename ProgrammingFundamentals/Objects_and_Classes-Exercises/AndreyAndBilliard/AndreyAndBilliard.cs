using System;
using System.Collections.Generic;
using System.Linq;

namespace AndreyAndBilliard
{
    public class AndreyAndBilliard
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, decimal> availableProducts = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                string[] productAndPrice = Console.ReadLine().Split('-');

                string prodcut = productAndPrice[0];
                decimal price = decimal.Parse(productAndPrice[1]);

                if (!availableProducts.ContainsKey(prodcut))
                    availableProducts.Add(prodcut, price);
                else
                    availableProducts[prodcut] = price;
            }

            string buyer = String.Empty;

            List<Customer> customers = new List<Customer>();

            while (buyer != "end of clients")
            {
                string[] buyerData = Console.ReadLine().Split('-', ',');

                buyer = buyerData[0];

                if (buyer == "end of clients")
                    break;

                string product = buyerData[1];
                int quantity = int.Parse(buyerData[2]);

                if (!availableProducts.ContainsKey(product))
                    continue;

                Customer customer = new Customer();
                customer.Name = buyer;
                customer.ShopList = new Dictionary<string, int>();

                if (!customers.Any(x => x.Name == buyer))
                {
                    customer.ShopList.Add(product, quantity);
                    customer.Bill = quantity * availableProducts[product];
                }
                else
                {
                    customer = customers.First(x => x.Name == buyer);

                    if (!customer.ShopList.ContainsKey(product))
                    {
                        customer.ShopList.Add(product, quantity);
                    }
                    else
                    {
                        customer.ShopList[product] += quantity;
                    }

                    customer.Bill += quantity * availableProducts[product];

                    customers.Remove(customer);
                }

                customers.Add(customer);
            }

            decimal totalBill = 0;

            foreach (Customer customer in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine(customer.Name);

                foreach (var pair in customer.ShopList)
                {
                    Console.WriteLine("-- {0} - {1}", pair.Key, pair.Value);
                }

                Console.WriteLine("Bill: {0:F2}", customer.Bill);

                totalBill += customer.Bill;
            }

            Console.WriteLine("Total bill: {0:F2}", totalBill);
        }
    }
}
