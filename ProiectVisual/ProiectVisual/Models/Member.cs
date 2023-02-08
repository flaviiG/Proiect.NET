using ProiectVisual.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ProiectVisual.Models
{
    public class Member : BaseEntity
    {
        [Required]
        public Guid Id { get; set; }
        public string? First_Name { get; set; }
        public string? Last_Name { get; set; }
        public string? Status { get; set; }
        public Department? Department { get; set; }
        public Guid? DepartmentId { get; set; }  
        public ICollection<ModelsRelation>?  ModelsRelation { get; set; }
    }
}
