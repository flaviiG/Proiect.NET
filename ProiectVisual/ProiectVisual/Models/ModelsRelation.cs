namespace ProiectVisual.Models
{
    public class ModelsRelation
    {
        public Guid JobId { get; set; }
        public Job Job { get; set; }
        public Guid MemberId { get; set; }
        public Member Member { get; set; }

    }
}
