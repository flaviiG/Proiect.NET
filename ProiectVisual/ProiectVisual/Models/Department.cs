using ProiectVisual.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace ProiectVisual.Models
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Member>? Members { get; set; }
        public Event? Event { get; set; }  
    }
}
