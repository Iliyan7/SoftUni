using System.ComponentModel.DataAnnotations;

namespace FastFood.DataProcessor.Dto.Import
{
    public class ItemDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Category { get; set; }
    }
}
