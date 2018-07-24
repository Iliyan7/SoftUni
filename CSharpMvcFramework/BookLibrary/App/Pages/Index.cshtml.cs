using App.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace App.Pages
{
    public class IndexModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public IndexModel(LibraryDbContext db)
        {
            _db = db;
        }

        public IEnumerable<IndexViewModel> Books { get; private set; }

        public void OnGet()
        {
            this.Books = _db.Books
                .Select(b => new IndexViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    AuthorName = b.Author.Name,
                    Status = b.BookBorrowers.Any(bb => bb.IsBookReturned == false) ? "Borrowed" : "At Home"
                })
                .ToList();
        }
    }
}
