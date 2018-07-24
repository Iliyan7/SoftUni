using App.Models.BindingModels;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using System.Threading.Tasks;

namespace App.Pages.Borrowers
{
    public class AddModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public AddModel(LibraryDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public BorrowerAddModel Borrower { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var borrower = new Borrower()
            {
                Name = this.Borrower.Name,
                PhoneNumber = this.Borrower.PhoneNumber,
                Address = this.Borrower.Address
            };

            _db.Borrowers.Add(borrower);
            await _db.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}