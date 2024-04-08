using Whitelabel.Domain.Entities.Abstract;
using Whitelabel.Infrastructure.Repositories.Base;

namespace Whitelabel.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity, TPrimaryKey> GetRepository<TEntity, TPrimaryKey>()
            where TEntity : class, IEntity, new() where TPrimaryKey : IEquatable<TPrimaryKey>;

        int Complete();

        Task<int> CompleteAsync();

        void RollBack();

        Task RollBackAsync();
    }
}