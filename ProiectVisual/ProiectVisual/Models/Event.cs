using ProiectVisual.Models.Base;

namespace ProiectVisual.Models
{
    public class Event : BaseEntity
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Department Department { get; set; }
        public Guid DepartmentId { get; set; }

    }
}
