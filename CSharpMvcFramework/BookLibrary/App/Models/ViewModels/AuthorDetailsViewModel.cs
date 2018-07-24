using System.Collections.Generic;

namespace App.Models.ViewModels
{
    public class AuthorDetailsViewModel
    {
        public string Name { get; set; }

        public IEnumerable<AuthorDetailsBookViewModel> BookList { get; set; }
    }

    public class AuthorDetailsBookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }
    }
}
