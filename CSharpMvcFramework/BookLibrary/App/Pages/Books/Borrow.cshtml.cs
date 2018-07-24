using App.Models.BindingModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Pages.Books
{
    public class BorrowModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public BorrowModel(LibraryDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public BookBorrowModel Borrower { get; set; }

        public IList<SelectListItem> BorrowerList { get; private set; }

        public void OnGet(int id)
        {
            this.BorrowerList = _db.Borrowers.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            })
            .ToList();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                this.BorrowerList = _db.Borrowers.Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                })
                .ToList();

                return Page();
            }

            var bookBorrower = new BookBorrower()
            {
                BookId = id,
                BorrowerId = this.Borrower.BorrowerId,
                StartDate = this.Borrower.StartDate,
                EndDate = this.Borrower.EndDate
            };

            _db.BookBorrowers.Add(bookBorrower);
            await _db.SaveChangesAsync();

            return RedirectToPage("./Details", new { id });
        }
    }
}