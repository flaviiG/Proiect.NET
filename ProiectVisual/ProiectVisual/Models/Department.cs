namespace ProiectVisual.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Member> Members { get; set; }
        public Event Event { get; set; }
    }
}
