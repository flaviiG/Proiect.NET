using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;

namespace ProiectVisual.Services.UserService
{
    public interface IUserService
    {
        UserResponseDTO Authenticate(UserRequestDTO model);

        User GetById(Guid id);

        public Task<User> Create(User newUser);
       
    }
}
