using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
