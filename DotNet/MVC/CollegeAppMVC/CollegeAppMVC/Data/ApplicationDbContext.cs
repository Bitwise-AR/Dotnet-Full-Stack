using CollegeAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeAppMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CollegeApplication> CollegeApplications { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CollegeApplication>()
                .HasIndex(c => c.Email)
                .IsUnique();
        }
    }
}
