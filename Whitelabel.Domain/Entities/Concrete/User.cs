using Whitelabel.Domain.Entities.Abstract;

namespace Whitelabel.Domain.Entities.Concrete;

public class User : IEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}