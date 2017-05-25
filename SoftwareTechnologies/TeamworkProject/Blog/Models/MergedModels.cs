using System.Collections.Generic;

namespace Blog.Models
{
    public class MergedModels
    {
        public Article Article { get; set; }
        public Comment Comment { get; set; }
        public List<Comment> Comments { get; set; }
    }
}