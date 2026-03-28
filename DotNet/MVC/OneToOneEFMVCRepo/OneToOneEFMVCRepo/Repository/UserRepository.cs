using Microsoft.EntityFrameworkCore;
using OneToOneEFMVCRepo.Data;
using OneToOneEFMVCRepo.Models;
using OneToOneEFMVCRepo.Repository;

namespace OneToOneEFMVCRepo.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users
                   .Include(u => u.Profile)
                   .ToList();
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}