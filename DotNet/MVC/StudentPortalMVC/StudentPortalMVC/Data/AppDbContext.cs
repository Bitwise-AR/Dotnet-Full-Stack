using Microsoft.EntityFrameworkCore;
using StudentPortalMVC.Models;

namespace StudentPortalMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.Marks)
                .WithOne(m => m.Student)
                .HasForeignKey(m => m.StudentId);

            modelBuilder.Entity<Student>()
                .Property(s => s.Email)
                .IsRequired();

            modelBuilder.Entity<Mark>()
                .HasKey(m => m.Id);
        }
    }
}