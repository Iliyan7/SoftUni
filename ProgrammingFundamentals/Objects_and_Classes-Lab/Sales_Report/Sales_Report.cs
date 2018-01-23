using System;
using System.Collections.Generic;

namespace Sales_Report
{
    public class Sales_Report
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, double> salesReport = new SortedDictionary<string, double>();

            for (int i = 0; i < n; i++)
            {
                string[] saleByTown = Console.ReadLine()
                    .Split(' ');

                Sales curSale = new Sales
                {
                    Town = saleByTown[0],
                    Product = saleByTown[1],
                    Price = double.Parse(saleByTown[2]),
                    Quantity = double.Parse(saleByTown[3])
                };

                if(!salesReport.ContainsKey(curSale.Town))
                {
                    salesReport.Add(curSale.Town, 0);
                }

                salesReport[curSale.Town] += curSale.Price * curSale.Quantity;
            }

            foreach (KeyValuePair<string, double> pair in salesReport)
            {
                Console.WriteLine("{0} -> {1:F2}", pair.Key, pair.Value);
            }
        }
    }
}
