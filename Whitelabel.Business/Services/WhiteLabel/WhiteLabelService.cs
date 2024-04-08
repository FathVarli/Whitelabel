using Microsoft.Extensions.Hosting;
using Whitelabel.Business.Helpers.TemplateBuilder;
using Whitelabel.Core.Results.Base;
using Whitelabel.Core.Results.Results;
using Whitelabel.Domain.Dtos.Concrete.WhiteLabel;
using Whitelabel.Domain.Dtos.Concrete.WhiteLabel.Template;
using Whitelabel.Infrastructure.Repositories.Abstract;
using Whitelabel.Infrastructure.UnitOfWork;

namespace Whitelabel.Business.Services.WhiteLabel;

public class WhiteLabelService(IWhiteLabelRepository whiteLabelRepository, IUnitOfWork unitOfWork, IHostEnvironment hostEnvironment, ITemplateBuilder templateBuilder) : IWhiteLabelService
{
    public async Task<IResult> CreateWhiteLabel(CreateWhiteLabelRequestDto createWhiteLabelRequestDto)
    {
        var isTenantWhiteLabelExist =
          await  whiteLabelRepository.GetAsync(x => x.TenantId == createWhiteLabelRequestDto.TenantId);

        if (isTenantWhiteLabelExist is not null)
        {
            isTenantWhiteLabelExist.BrandName = createWhiteLabelRequestDto.BrandName;
            isTenantWhiteLabelExist.PrimaryColor = createWhiteLabelRequestDto.PrimaryColor;
            isTenantWhiteLabelExist.SecondaryColor = createWhiteLabelRequestDto.SecondaryColor;
            isTenantWhiteLabelExist.LogoUrl = createWhiteLabelRequestDto.LogoUrl;
            whiteLabelRepository.Update(isTenantWhiteLabelExist);
            await unitOfWork.CompleteAsync();
        }
        else
        {
            var addedWhiteLabel = new Domain.Entities.Concrete.Whitelabel
            {
                BrandName = createWhiteLabelRequestDto.BrandName,
                PrimaryColor = createWhiteLabelRequestDto.PrimaryColor,
                SecondaryColor = createWhiteLabelRequestDto.SecondaryColor,
                LogoUrl = createWhiteLabelRequestDto.LogoUrl,
                TenantId = createWhiteLabelRequestDto.TenantId
            };
            await whiteLabelRepository.AddAsync(addedWhiteLabel);
            await unitOfWork.CompleteAsync();
        }
        
        var fileName = "customizer-variable.txt";
        var fullPath = Path.Combine(hostEnvironment.ContentRootPath, "wwwroot/css", fileName);
        var cssContent = await File.ReadAllTextAsync(fullPath);

        var templateDto = new WhiteLabelTemplateDto
        {
            PrimaryColor = createWhiteLabelRequestDto.PrimaryColor,
            SecondaryColor = createWhiteLabelRequestDto.SecondaryColor,
            LogoUrl = createWhiteLabelRequestDto.LogoUrl
        };

        var templateResult = await templateBuilder.Build(templateDto, cssContent);
        if (!templateResult.IsSuccess) return new SuccessResult("Whitelabel saved");
        
        var directoryPath = Path.Combine(hostEnvironment.ContentRootPath, $"wwwroot/css/{createWhiteLabelRequestDto.TenantId}");

        var tenantCssPath = Path.Combine(hostEnvironment.ContentRootPath, $"wwwroot/css/{createWhiteLabelRequestDto.TenantId}", "variable.css");
        
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        
        if (File.Exists(tenantCssPath))
        {
            File.Delete(tenantCssPath);
        }

        await using var writer = File.CreateText(tenantCssPath);
        await writer.WriteAsync(templateResult.Template);

        return new SuccessResult("Whitelabel saved");
    }

    public Task<IResult> ResetWhiteLabel(ResetWhiteLabelRequestDto resetWhiteLabelRequestDto)
    {
        var tenantCssPath = Path.Combine(hostEnvironment.ContentRootPath, $"wwwroot/css/{resetWhiteLabelRequestDto.TenantId}", "variable.css");
        
        if (File.Exists(tenantCssPath))
        {
            File.Delete(tenantCssPath);
        }

        return Task.FromResult<IResult>(new SuccessResult("Reset whitelabel"));
    }
}