using ProiectVisual.Data;
using ProiectVisual.Models;
using ProiectVisual.Repositories.GenericRepository;

namespace ProiectVisual.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<User> , IUserRepository
    {
        public UserRepository(Context context) : base(context)
        {

        }

        public User FindByUsername(string username)
        {
            return _table.FirstOrDefault(x => x.UserName == username);
        }

    }
}
