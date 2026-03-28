using OneToOneEFMVCRepo.Models;

namespace OneToOneEFMVCRepo.Repository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        void Add(User user);
    }
}