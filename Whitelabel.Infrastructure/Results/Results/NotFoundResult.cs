using System.Net;
using Whitelabel.Core.Results.Base;

namespace Whitelabel.Core.Results.Results
{
    public class NotFoundResult : Result
    {
        public NotFoundResult(string message) : base(StatusTypeEnum.NotFound, (int)HttpStatusCode.NotFound, message)
        {
        }

        public NotFoundResult() : base(StatusTypeEnum.NotFound, (int)HttpStatusCode.OK)
        {
        }
    }
}