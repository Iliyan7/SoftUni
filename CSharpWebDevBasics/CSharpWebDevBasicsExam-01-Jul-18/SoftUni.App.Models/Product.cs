using System.ComponentModel.DataAnnotations;

namespace SoftUni.App.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public int ProductTypeId { get; set; }

        public ProductType Type { get; set; }
    }
}
