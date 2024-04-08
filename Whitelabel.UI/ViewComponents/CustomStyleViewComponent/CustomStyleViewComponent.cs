using Microsoft.AspNetCore.Mvc;

namespace Whitelabel.UI.ViewComponents.CustomStyleViewComponent;

public class CustomStyleViewComponent : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        var tenantId = 1;
        var defaultCssFilePath = "wwwroot/css/variable.css";
        var tenantCssFilePath = $"wwwroot/css/{tenantId}/variable.css";
        
        if (File.Exists(tenantCssFilePath))
        {
            var tenantFullPath = Path.Combine(Directory.GetCurrentDirectory(), tenantCssFilePath);
            var tenantCssContent = File.ReadAllText(tenantFullPath);
            return View("_CustomerStyle",tenantCssContent);
        }
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), defaultCssFilePath);
        var defaultCssContent = File.ReadAllText(fullPath);
        return View("_CustomerStyle",defaultCssContent);
        
    }
}