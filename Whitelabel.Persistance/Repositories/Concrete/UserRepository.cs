using Whitelabel.Domain.Entities.Concrete;
using Whitelabel.Infrastructure.Context;
using Whitelabel.Infrastructure.Repositories.Abstract;
using Whitelabel.Infrastructure.Repositories.Base;

namespace Whitelabel.Infrastructure.Repositories.Concrete;

public class UserRepository : Repository<User,int>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}