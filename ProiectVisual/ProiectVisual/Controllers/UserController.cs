using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectVisual.Models;
using ProiectVisual.Models.DTOs;
using ProiectVisual.Models.Enums;
using ProiectVisual.Services.UserService;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ProiectVisual.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                Email = user.Email,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Rol = Role.User,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };

            await _userService.Create(userToCreate);
            return Ok();
        }

    }
}
