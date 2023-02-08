using ProiectVisual.Models;

namespace ProiectVisual.Helper.JwtToken
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public Guid ValidateJwtToken(string token);
    }
}
