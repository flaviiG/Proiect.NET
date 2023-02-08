using ProiectVisual.Helper.JwtToken;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;
using ProiectVisual.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProiectVisual.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(UserRequestDTO model)
        {
            var user = _userRepository.FindByUsername(model.UserName);
            if(user == null || !BCryptNet.Verify(model.Password, user.PasswordHash))
            {
                return null;
            }
            var jwtToken = _jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task<User> Create(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            return newUser;
        }

        public User GetById(Guid id)
        {
            var user =  _userRepository.FindById(id);
            return user;
        }
    }
}
