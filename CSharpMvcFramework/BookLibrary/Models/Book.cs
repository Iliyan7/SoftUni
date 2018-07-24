using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public string CoverImageUrl { get; set; }

        public ICollection<BookBorrower> BookBorrowers { get; set; } = new List<BookBorrower>();
    }
}
