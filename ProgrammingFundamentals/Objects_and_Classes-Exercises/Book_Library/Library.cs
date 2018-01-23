namespace Book_Library
{
    public class Library
    {
        private string bookAuthor;
        private decimal bookPrice;

        public Library(string author = "", decimal price = 0)
        {
            bookAuthor = author;
            bookPrice = price;
        }

        public string GetAuthor
        {
            get
            {
                return bookAuthor;
            }
        }

        public decimal GetPrice
        {
            get
            {
                return bookPrice;
            }
        }
    }
}
