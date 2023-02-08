namespace ProiectVisual.Models.DTOs
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Token { get; set; }

        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            UserName = user.UserName;
            Email = user.Email;
            First_Name = user.First_Name;
            Last_Name = user.Last_Name;
            Token = token;
        }
    }
}
