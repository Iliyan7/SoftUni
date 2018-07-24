using App.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace App.Pages.Authors
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public DetailsModel(LibraryDbContext db)
        {
            _db = db;
        }

        public AuthorDetailsViewModel Author { get; private set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var author = await _db.Authors
                .Include(a => a.Books)
                .ThenInclude(b => b.BookBorrowers)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (author == null)
            {
                return RedirectToPage("/Index");
            }

            this.Author = new AuthorDetailsViewModel()
            {
                Name = author.Name,
                BookList = author.Books
                .Select(b => new AuthorDetailsBookViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Status = b.BookBorrowers.Any(bb => bb.IsBookReturned == false) ? "Borrowed" : "At Home"
                })
                .ToList()
            };

            return Page();
        }
    }
}