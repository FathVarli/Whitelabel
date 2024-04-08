namespace Whitelabel.Business.Helpers.TemplateBuilder
{
    public class TemplateResult
    {
        public TemplateResult(string template)
        {
            IsSuccess = true;
            Template = template;
            Error = string.Empty;
        }
    
        public TemplateResult(bool isSuccess, string error)
        {
            Template = string.Empty;
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; set; }
        public string Template { get; set; }
        public string Error { get; set; }
    }
}