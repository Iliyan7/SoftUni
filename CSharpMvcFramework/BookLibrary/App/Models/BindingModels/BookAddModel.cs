using System.ComponentModel.DataAnnotations;

namespace App.Models.BindingModels
{
    public class BookAddModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image URL")]
        [Required]
        [Url(ErrorMessage = "Invalid URL.")]
        public string ImageUrl { get; set; }
    }
}
