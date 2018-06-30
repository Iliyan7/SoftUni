using Framework.Attributes.Validation;

namespace Application.BindingModels
{
    public class AddNoteBindingModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public int UserId { get; set; }
    }
}
