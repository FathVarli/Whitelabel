using Whitelabel.Core.Results.Base;
using Whitelabel.Domain.Dtos.Concrete;
using Whitelabel.Domain.Dtos.Concrete.WhiteLabel;

namespace Whitelabel.Business.Services.WhiteLabel;

public interface IWhiteLabelService
{
    Task<IResult> CreateWhiteLabel(CreateWhiteLabelRequestDto createWhiteLabelRequestDto);
    Task<IResult> ResetWhiteLabel(ResetWhiteLabelRequestDto resetWhiteLabelRequestDto);
}