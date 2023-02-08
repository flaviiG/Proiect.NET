using ProiectVisual.Models.Base;

namespace ProiectVisual.Models
{
    public class Job : BaseEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ModelsRelation> ModelsRelation { get; set; }

    }
}
