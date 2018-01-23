using System.Collections;
using System.Collections.Generic;

//namespace Library
//{
public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);

        IComparer<Book> comparer = new BookComparator();
        this.books.Sort(comparer);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        return new LibraryIterator(this.books);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currentIndex;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public Book Current => this.books[this.currentIndex];
        object IEnumerator.Current => this.currentIndex;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            return ++this.currentIndex < this.books.Count;
        }

        public void Reset()
        {
            this.currentIndex = -1;
        }
    }
}
//}