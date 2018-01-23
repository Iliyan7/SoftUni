using System;
using System.Collections.Generic;
using System.Linq;

namespace Book_Library
{
    public class Book_Library
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Library[] myLibrary = new Library[n];

            for (int i = 0; i < n; i++)
            {
                string[] bookData = Console.ReadLine().Split(' ');

                myLibrary[i] = new Library(bookData[1], decimal.Parse(bookData[5]));
            }

            Dictionary<string, decimal> totalPriceByAuthor = new Dictionary<string, decimal>();

            foreach (Library book in myLibrary)
            {
                if (!totalPriceByAuthor.ContainsKey(book.GetAuthor))
                    totalPriceByAuthor.Add(book.GetAuthor, 0);

                totalPriceByAuthor[book.GetAuthor] += book.GetPrice;
            }

            foreach (var pair in totalPriceByAuthor
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine("{0} -> {1:F2}", pair.Key, pair.Value);
            }
        }
    }
}
