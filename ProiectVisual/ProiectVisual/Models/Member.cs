using ProiectVisual.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ProiectVisual.Models
{
    public class Member : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Status { get; set; }

        public List<Job>? Jobs { get; set; }
    }
}
