using System.ComponentModel.DataAnnotations;

namespace SoftUni.App.Chushka.BindingModels
{
    public class RegisterModel
    {
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters.")]
        public string Username { get; set; }

        [MinLength(3, ErrorMessage = "Password must be at least 3 characters.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passowords doesn't match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }
    }
}
