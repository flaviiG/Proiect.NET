namespace ProiectVisual.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<ModelsRelation> ModelsRelation { get; set; }

    }
}
