using Microsoft.EntityFrameworkCore;
using DocumentVault.Models;

namespace DocumentVault.Data 
{    
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Document> Documents { get; set; }
    }
}
