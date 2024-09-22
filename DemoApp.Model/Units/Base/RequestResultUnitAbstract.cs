using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Units.Abstract;

namespace DemoApp.Model.Units.Base
{
    /// <summary>
    /// Wrapper that adds request and result 
    /// </summary>
    public abstract class RequestResultUnitAbstract<TResult, TRequest>: TemplateMethodBaseUnit
        where TResult : ResponseBase, new()
        where TRequest : RequestBase
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="request">Request object</param>
        public RequestResultUnitAbstract(TRequest request)
        {
            Request = request;
            Result = new TResult();
        }

        /// <summary>
        /// Request object
        /// </summary>
        protected TRequest Request { get; set; }

        /// <summary>
        /// Result
        /// </summary>
        public TResult Result { get; protected set; }

        /// <summary>
        /// Set result code success
        /// </summary>
        protected void SetSuccess() 
            => Result.Error = Dal.ErrorCodeEnum.Success;
    }
}
