using System.ComponentModel.DataAnnotations;

namespace MeTube.BindingModels
{
    public class TubeUploadModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string YoutubeLink { get; set; }

        public string Description { get; set; }
    }
}
