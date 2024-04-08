using System.Net;
using Whitelabel.Core.Results.Base;

namespace Whitelabel.Core.Results.Results
{
    public class UnauthorizedResult : Result
    {
        public UnauthorizedResult(string message) : base(StatusTypeEnum.Unauthorized, (int)HttpStatusCode.Unauthorized,
            message)
        {
        }

        public UnauthorizedResult() : base(StatusTypeEnum.Unauthorized, (int)HttpStatusCode.Unauthorized)
        {
        }
    }
}