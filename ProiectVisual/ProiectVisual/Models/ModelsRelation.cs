namespace ProiectVisual.Models
{
    public class ModelsRelation
    {
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }

    }
}
