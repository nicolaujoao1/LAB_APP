using LAB_APP.Domain.Common;

namespace LAB_APP.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseAuditableEntity
    {
        IEnumerable<TEntity> GetAll();
        Task<TEntity> GetById(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
