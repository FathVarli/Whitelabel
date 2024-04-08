using System.Net;
using Whitelabel.Core.Results.Base;

namespace Whitelabel.Core.Results.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(StatusTypeEnum.Success, (int)HttpStatusCode.OK, message)
        {
        }

        public SuccessResult() : base(StatusTypeEnum.Success, (int)HttpStatusCode.OK)
        {
        }
    }
}