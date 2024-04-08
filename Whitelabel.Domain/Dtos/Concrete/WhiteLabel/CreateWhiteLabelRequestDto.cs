namespace Whitelabel.Domain.Dtos.Concrete.WhiteLabel;

public class CreateWhiteLabelRequestDto
{
    public string BrandName { get; set; }
    public string PrimaryColor { get; set; }
    public string SecondaryColor { get; set; }
    public string LogoUrl { get; set; }
    public int TenantId { get; set; }
}