using Microsoft.EntityFrameworkCore;
using OneToOneEFMVCRepo.Models;

namespace OneToOneEFMVCRepo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}