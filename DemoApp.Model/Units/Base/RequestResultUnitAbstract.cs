using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;

namespace DemoApp.Model.Units.Base
{
    /// <summary>
    /// Wrapper that adds request and result 
    /// </summary>
    public abstract class RequestResultUnitAbstract<TResult, TRequest>: AuthorizationBasedUnit
        where TResult : ResponseBase, new()
        where TRequest : ReqBase
    {

        public RequestResultUnitAbstract() => Result = new TResult();

        /// <summary>
        /// Result
        /// </summary>
        public TResult Result { get; set; }

        /// <summary>
        /// Set result code success
        /// </summary>
        protected void SetSuccess() 
            => Result.Error = Dal.ErrorCodeEnum.Success;
    }
}
