using System.ComponentModel.DataAnnotations;

namespace ProiectVisual.Models
{
    public class Member
    {
        [Required]
        public int Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Status { get; set; }
    }
}
