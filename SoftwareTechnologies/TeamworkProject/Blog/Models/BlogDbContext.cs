using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Models
{
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }
    }
}