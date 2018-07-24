using App.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace App.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public DetailsModel(LibraryDbContext db)
        {
            _db = db;
        }

        public BookDetailsViewModel Book { get; private set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var book = await _db.Books
                .Include(b => b.Author)
                .Include(b => b.BookBorrowers)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return RedirectToPage("/Index");
            }

            this.Book = new BookDetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author.Name,
                Description = book.Description,
                ImageUrl = book.CoverImageUrl,
                Status = book.BookBorrowers.Any(bb => bb.IsBookReturned == false) ? "Borrowed" : "At Home"
            };

            return Page();
        }

        public async Task<IActionResult> OnGetReturnBookAsync(int id)
        {
            var borrowedBook = await _db.BookBorrowers
                .FirstOrDefaultAsync(bb => bb.BookId == id && bb.IsBookReturned == false);

            if (borrowedBook.EndDate == null || borrowedBook.EndDate > DateTime.Now)
            {
                borrowedBook.EndDate = DateTime.Now;
            }

            borrowedBook.IsBookReturned = true;
            await _db.SaveChangesAsync();

            return RedirectToPage(new { id });
        }
    }
}