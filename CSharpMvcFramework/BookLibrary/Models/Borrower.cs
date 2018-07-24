using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Borrower
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<BookBorrower> BookBorrowers { get; set; } = new List<BookBorrower>();
    }
}
