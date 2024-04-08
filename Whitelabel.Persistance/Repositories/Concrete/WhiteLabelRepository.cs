using Whitelabel.Infrastructure.Context;
using Whitelabel.Infrastructure.Repositories.Abstract;
using Whitelabel.Infrastructure.Repositories.Base;

namespace Whitelabel.Infrastructure.Repositories.Concrete;

public class WhiteLabelRepository : Repository<Domain.Entities.Concrete.Whitelabel,int>, IWhiteLabelRepository
{
    public WhiteLabelRepository(AppDbContext context) : base(context)
    {
    }
}