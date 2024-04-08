using System.Net;
using Whitelabel.Core.Results.Base;

namespace Whitelabel.Core.Results.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest, message)
        {
        }

        public ErrorResult() : base(StatusTypeEnum.Failed, (int)HttpStatusCode.BadRequest)
        {
        }
    }
}