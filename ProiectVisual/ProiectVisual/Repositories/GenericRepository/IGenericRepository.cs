using ProiectVisual.Models.Base;

namespace ProiectVisual.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        //Get all data
        Task<List<TEntity>> GetAll();
        IQueryable<TEntity> GetAllQueryable();

        //Create
        void Create(TEntity entity);
        Task CreateAsync(TEntity entity);
        void CreateRange(IEnumerable<TEntity> entities);

        //Update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);


        //Delete
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        //Find
        TEntity FindById(object id);
        Task<TEntity> FindByIdAsync(object id);

        //Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
