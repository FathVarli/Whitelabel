using Whitelabel.Domain.Entities.Concrete;
using Whitelabel.Infrastructure.Repositories.Base;

namespace Whitelabel.Infrastructure.Repositories.Abstract;

public interface IUserRepository : IRepository<User, int>
{
    
}