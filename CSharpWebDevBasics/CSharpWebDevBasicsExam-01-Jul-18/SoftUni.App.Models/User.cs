using System.ComponentModel.DataAnnotations;

namespace SoftUni.App.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
    }
}
