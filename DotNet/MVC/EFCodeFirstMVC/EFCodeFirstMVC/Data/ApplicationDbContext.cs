using EFCodeFirstMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students{ get; set; }
        //public DbSet<Hostel> Hostels{ get; set; }
    }
}
