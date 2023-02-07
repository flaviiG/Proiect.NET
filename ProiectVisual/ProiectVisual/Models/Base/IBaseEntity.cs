namespace ProiectVisual.Models.Base
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        DateTime DateCreated { get; set; }
        DateTime? DateModified { get; set; }

    }
}
