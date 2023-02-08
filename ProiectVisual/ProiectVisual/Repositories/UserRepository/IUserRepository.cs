using ProiectVisual.Models;
using ProiectVisual.Repositories.GenericRepository;

namespace ProiectVisual.Repositories.UserRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User FindByUsername(string username);
    }
}
