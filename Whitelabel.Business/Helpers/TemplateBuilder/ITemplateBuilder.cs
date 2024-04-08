namespace Whitelabel.Business.Helpers.TemplateBuilder
{
    public interface ITemplateBuilder
    {
        Task<TemplateResult> Build<T>(T buildModel, string source) where T : class , new();
    }
}