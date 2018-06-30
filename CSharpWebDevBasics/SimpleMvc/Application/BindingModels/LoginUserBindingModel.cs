using Framework.Attributes.Validation;

namespace Application.BindingModels
{
    public class LoginUserBindingModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
