using System.ComponentModel.DataAnnotations;

namespace OneToOneEFMVCRepo.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        public UserProfile Profile { get; set; }
    }
}