using System.ComponentModel.DataAnnotations;

namespace SoftUni.App.Chushka.BindingModels
{
    public class CreateProductModel
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive number!")]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public string ProductType { get; set; }
    }
}
