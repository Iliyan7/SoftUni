using App.Models.ViewModels;
using Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace App.Pages.Books
{
    public class HistoryModel : PageModel
    {
        private readonly LibraryDbContext _db;

        public HistoryModel(LibraryDbContext db)
        {
            _db = db;
        }

        public IEnumerable<BookHistoryViewModel> BookHistoryList { get; private set; }

        public void OnGet(int id)
        {
            this.BookHistoryList = _db.BookBorrowers
                .Where(bb => bb.BookId == id)
                .Select(bb => new BookHistoryViewModel
                {
                    BorrowerName = bb.Borrower.Name,
                    Period = $"{bb.StartDate:dd MMM yyyy} - {bb.EndDate:dd MMM yyyy}",
                    Status = bb.IsBookReturned ? "At Home" : "Borrowed"
                })
                .ToList();
        }
    }
}