using System.ComponentModel.DataAnnotations;

namespace MeTube.BindingModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Username is required")]
        [MinLength(6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Compare("Password", ErrorMessage = "Passwords doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
