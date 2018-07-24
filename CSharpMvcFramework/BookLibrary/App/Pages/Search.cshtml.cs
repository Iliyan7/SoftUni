using App.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace App.Pages
{
    public class SearchModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public SearchModel(LibraryDbContext db)
        {
            _db = db;
        }

        public SearchViewModel SearchResult { get; private set; }

        public void OnGet(string searchTerm)
        {
            this.SearchResult = new SearchViewModel()
            {
                SearchTerm = searchTerm,
                Authors = _db.Authors
                .Where(a => a.Name.Contains(searchTerm))
                .Select(a => new SearchAuthorViewModel()
                {
                    Id = a.Id,
                    Name = a.Name
                })
                .ToList(),
                Books = _db.Books
                .Where(b => b.Title.Contains(searchTerm))
                .Select(b => new SearchBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title
                })
                .ToList()
            };
        }
    }
}
