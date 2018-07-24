using System.Collections.Generic;

namespace App.Models.ViewModels
{
    public class SearchViewModel
    {
        public string SearchTerm { get; set; }

        public IEnumerable<SearchAuthorViewModel> Authors { get; set; }

        public IEnumerable<SearchBookViewModel> Books { get; set; }
    }

    public class SearchAuthorViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class SearchBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
