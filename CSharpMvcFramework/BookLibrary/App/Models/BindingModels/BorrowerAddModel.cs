using System.ComponentModel.DataAnnotations;

namespace App.Models.BindingModels
{
    public class BorrowerAddModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Phone Number")]
        [Phone(ErrorMessage = "Invalid phone number.")]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }
    }
}
