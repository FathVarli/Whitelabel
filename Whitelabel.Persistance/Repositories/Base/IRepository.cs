using System.Linq.Expressions;
using Whitelabel.Domain.Entities.Abstract;

namespace Whitelabel.Infrastructure.Repositories.Base
{
    public interface IRepository<TEntity, in TPrimaryKey>
        where TEntity : class, IEntity, new()
        where TPrimaryKey : IEquatable<TPrimaryKey>
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TPrimaryKey id);
        void DeleteRange(IEnumerable<TEntity?> entities);
        void UpdateRange(List<TEntity> entities);
        TEntity? Update(TEntity? entity);
        Task<TEntity?> GetByIdAsync(TPrimaryKey id);
        Task<TEntity?> GetAsync(Expression<Func<TEntity?, bool>> predicate, bool isTracking = false);
        Task<IEnumerable<TEntity?>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, bool isTracking = false);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>>? predicate = null);
        Task<int> GetCount(Expression<Func<TEntity, bool>>? predicate = null);
        Task<bool> AnyAsync(Expression<Func<TEntity?, bool>> predicate);
        bool Any(Expression<Func<TEntity?, bool>> predicate);
        IQueryable<TEntity?> Query();
    }
}