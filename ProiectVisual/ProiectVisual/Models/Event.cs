namespace ProiectVisual.Models
{
    public class Event
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

    }
}
