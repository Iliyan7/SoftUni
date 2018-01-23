using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Book_Library_Modification
{
    public class Book_Library_Modification
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            Library2[] myLibrary = new Library2[n];

            for (int i = 0; i < n; i++)
            {
                string[] bookData = Console.ReadLine().Split(' ');

                myLibrary[i] = new Library2(bookData[0], DateTime.ParseExact(bookData[3], "dd.MM.yyyy", CultureInfo.InvariantCulture));
            }

            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

            Dictionary<string, DateTime> releasedBooks = new Dictionary<string, DateTime>();

            foreach (Library2 book in myLibrary)
            {
                if (book.GetReleaseDate <= date)
                    continue;

                if (!releasedBooks.ContainsKey(book.GetTitle))
                    releasedBooks.Add(book.GetTitle, book.GetReleaseDate);
                else
                    releasedBooks[book.GetTitle] = book.GetReleaseDate;
            }

            foreach (var pair in releasedBooks
                .OrderBy(x => x.Value)
                .ThenBy(x => x.Key))
            {
                    Console.WriteLine("{0} -> {1:d.MM.yyyy}", pair.Key, pair.Value);
            }
        }
    }
}
