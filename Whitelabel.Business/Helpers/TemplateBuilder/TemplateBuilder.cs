using Fluid;

namespace Whitelabel.Business.Helpers.TemplateBuilder
{
    public class TemplateBuilder : ITemplateBuilder
    {
        private readonly FluidParser _fluidParser;

        public TemplateBuilder(FluidParser fluidParser)
        {
            _fluidParser = fluidParser;
        }

        public async Task<TemplateResult> Build<T>(T buildModel, string source) where T : class, new()
        {
            if (!_fluidParser.TryParse(source, out var template, out var error))
                return new TemplateResult(false, error);

            var context = new TemplateContext(buildModel);
            var result = await template.RenderAsync(context);
            return new TemplateResult(result);
        }
    }
}