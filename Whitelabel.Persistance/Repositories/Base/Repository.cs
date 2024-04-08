using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Whitelabel.Domain.Entities.Abstract;
using Whitelabel.Infrastructure.Context;

namespace Whitelabel.Infrastructure.Repositories.Base
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity, new()
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
            DbSetTable = _context.Set<TEntity>();
        }

        private DbSet<TEntity> DbSetTable { get; }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var addedEntityEntry = await _context.Set<TEntity>().AddAsync(entity);
            return addedEntityEntry.Entity;
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual async Task DeleteAsync(TPrimaryKey id)
        {
            var existing = await DbSetTable.FindAsync(id);
            if (existing != null) DbSetTable.Remove(existing);
        }

        public virtual void DeleteRange(IEnumerable<TEntity?> entities)
        {
            DbSetTable.RemoveRange(entities);
        }

        public virtual void UpdateRange(List<TEntity> entities)
        {
            DbSetTable.UpdateRange(entities);
        }

        public virtual TEntity? Update(TEntity? entity)
        {
            var updatedEntityEntry = DbSetTable.Update(entity);
            return updatedEntityEntry.Entity;
        }

        public virtual async Task<TEntity?> GetByIdAsync(TPrimaryKey id)
        {
            return await DbSetTable.FindAsync(id);
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity?, bool>> predicate, bool isTracking = false)
        {
            return isTracking
                ? await DbSetTable.FirstOrDefaultAsync(predicate)
                : await DbSetTable.AsNoTracking().FirstOrDefaultAsync(predicate);
        }
        

        public virtual async Task<IEnumerable<TEntity?>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
            bool isTracking = false)
        {
            var query = isTracking ? DbSetTable : DbSetTable.AsNoTracking();

            if (predicate == null) return await query.ToListAsync();

            query = query.Where(predicate);

            return await query.ToListAsync();
        }
        
        public virtual async Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null
                ? await DbSetTable.CountAsync()
                : await DbSetTable.CountAsync(predicate);
        }

        public virtual async Task<int> GetCount(Expression<Func<TEntity, bool>>? predicate = null)
        {
            return predicate == null
                ? await DbSetTable.CountAsync()
                : await DbSetTable.CountAsync(predicate);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity?, bool>> predicate)
        {
            return await DbSetTable.AnyAsync(predicate);
        }

        public virtual bool Any(Expression<Func<TEntity?, bool>> predicate)
        {
            return DbSetTable.Any(predicate);
        }

        public IQueryable<TEntity?> Query()
        {
            return DbSetTable.AsQueryable();
        }
    }
}