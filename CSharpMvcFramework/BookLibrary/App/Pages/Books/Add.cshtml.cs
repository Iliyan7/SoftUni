using App.Models.BindingModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Threading.Tasks;

namespace App.Pages.Books
{
    public class AddModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public AddModel(LibraryDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public BookAddModel Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var author = await _db.Authors.FirstOrDefaultAsync(a => a.Name == this.Book.Author);

            if(author == null)
            {
                author = new Author()
                {
                    Name = this.Book.Author
                };
                _db.Authors.Add(author);
            }

            var book = new Book()
            {
                Title = this.Book.Title,
                Author = author,
                Description = this.Book.Description,
                CoverImageUrl = this.Book.ImageUrl
            };

            _db.Books.Add(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Books/Details", new { id = book.Id });
        }
    }
}