using System;

namespace Book_Library_Modification
{
    class Library2
    {
        private string bookTitle;
        private DateTime bookRelease;

        public Library2(string title = "", DateTime date = new DateTime())
        {
            bookTitle = title;
            bookRelease = date;
        }

        public string GetTitle
        {
            get
            {
                return bookTitle;
            }
        }

        public DateTime GetReleaseDate
        {
            get
            {
                return bookRelease;
            }
        }
    }
}
