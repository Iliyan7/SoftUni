using Framework.Attributes.Validation;

namespace Application.BindingModels
{
    public class RegisterUserBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
