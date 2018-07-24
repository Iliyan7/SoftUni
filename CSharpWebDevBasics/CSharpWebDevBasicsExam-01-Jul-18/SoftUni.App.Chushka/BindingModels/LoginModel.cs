using System.ComponentModel.DataAnnotations;

namespace SoftUni.App.Chushka.BindingModels
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
