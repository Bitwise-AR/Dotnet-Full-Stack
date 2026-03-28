using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToOneEFMVCRepo.Models
{
    public class UserProfile
    {
        [Key, ForeignKey("User")]
        public int UserId { get; set; }

        public string Bio { get; set; }

        public string Website { get; set; }

        public User User { get; set; }
    }
}
