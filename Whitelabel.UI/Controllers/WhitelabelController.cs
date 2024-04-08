using Microsoft.AspNetCore.Mvc;
using Whitelabel.Business.Services.WhiteLabel;
using Whitelabel.Core.Results.Base;
using Whitelabel.Domain.Dtos.Concrete;
using Whitelabel.Domain.Dtos.Concrete.WhiteLabel;

namespace Whitelabel.UI.Controllers;

[Route("whitelabel")]
public class WhitelabelController(ILogger<WhitelabelController> logger, IWebHostEnvironment web, IWhiteLabelService whiteLabelService) : Controller
{
    private readonly ILogger<WhitelabelController> _logger = logger;
    private readonly IWebHostEnvironment _web = web;
    private readonly IWhiteLabelService _whiteLabelService = whiteLabelService;


    public IActionResult GetDefaultCssFile()
    {
        // wwwroot klasörünün yolunu al
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/default.css");
        var cssContent = System.IO.File.ReadAllText(filePath);
        return Content(cssContent, "text/css");

    }
    
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create()
    {
        var result = await _whiteLabelService.CreateWhiteLabel(new CreateWhiteLabelRequestDto
        {
            BrandName = "Sec 2",
            PrimaryColor = "#0dfd11",
            SecondaryColor = "#dd0dfd",
            LogoUrl = "../../images/logo2.jpg",
            TenantId = 1
        });

        return Json(new { isSuccess = result.Status == StatusTypeEnum.Success });

    }
    
    [HttpPost]
    [Route("reset")]
    public async Task<IActionResult> Reset()
    {
        var result = await _whiteLabelService.ResetWhiteLabel(new ResetWhiteLabelRequestDto
        {
            TenantId = 1
        });
        return Json(new { isSuccess = result.Status == StatusTypeEnum.Success });

    }
    
}