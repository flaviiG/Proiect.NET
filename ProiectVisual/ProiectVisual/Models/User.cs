using Newtonsoft.Json;
using ProiectVisual.Models.Base;
using ProiectVisual.Models.Enums;

namespace ProiectVisual.Models
{
    public class User : BaseEntity
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
        public Role Rol { get; set; }
    }
}
