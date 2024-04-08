using Whitelabel.Domain.Entities.Abstract;

namespace Whitelabel.Domain.Entities.Concrete;

public class Whitelabel : IEntity
{
    public int Id { get; set; }
    public string BrandName { get; set; }
    public string PrimaryColor { get; set; }
    public string SecondaryColor { get; set; }
    public string LogoUrl { get; set; }
    public int TenantId { get; set; }
    public Tenant Tenant { get; set; }
}