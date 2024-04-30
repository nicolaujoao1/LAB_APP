using LAB_APP.Data.Context;
using LAB_APP.Domain.Common;
using LAB_APP.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LAB_APP.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseAuditableEntity
    {
        private readonly DbSet<TEntity> data;
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            data = _context.Set<TEntity>();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await data.AddAsync(entity);
            await _context.Commit();
            return entity;  
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            data.Remove(entity);
            await _context.Commit();
            return entity;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return data.AsEnumerable<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await data.FindAsync(id);
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            data.Update(entity);

             await _context.Commit();

            return entity;
        }
    }
}
