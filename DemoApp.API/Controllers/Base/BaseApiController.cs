using System.Net.Mime;
using System.Reflection;
using DemoApp.Model.Dal;
using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Exceptions;
using DemoApp.Model.Exceptions.Api;
using DemoApp.Model.Exceptions.Critical;
using DemoApp.Model.Factories;
using DemoApp.Model.Units.Base;
using Microsoft.AspNetCore.Mvc;

namespace Monee.RestApi.Controllers.Base
{
    /// <summary>
    /// Basic API controller
    /// </summary>  
    [ApiController]
    [Route("demoSubArea/[controller]")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class BaseApiController : ControllerBase
    {
        /// <summary>
        /// Logger 
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor with ILogger
        /// </summary>
        /// <param name="logger"></param>
        protected BaseApiController(ILogger logger) => _logger = logger;

        /// <summary>
        /// Add ip to request
        /// </summary>
        /// <param name="request">ReqBody object</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected TRequest AddIpToRequest<TRequest>(TRequest request)
            where TRequest: ReqBase
        {
            if (request == null)
                throw new KernerErrorException("Nullable request object");

            if (String.IsNullOrEmpty(request.Ip)
                && HttpContext!=null
                && HttpContext.Connection!=null
                && HttpContext.Connection.RemoteIpAddress != null)
                    request.Ip = HttpContext.Connection.RemoteIpAddress.ToString();

            return request;
        }

        /// <summary>
        /// Run TOperation with TRequest type & TResult. TOperation will be automatically created and excecuted
        /// </summary>
        /// <typeparam name="TUnitOfWorlk">Operation type</typeparam>
        /// <param name="request">ReqBody object</param>
        /// <returns>Result</returns>
        public TResult Run<TResult, TUnitOfWorlk, TRequest>(TRequest request, bool ignoreLogs = false)
            where TResult : ResponseBase, new()
            where TUnitOfWorlk : RequestResultUnitAbstract<TResult,TRequest>
            where TRequest : ReqBase
        {
            //using (var l = new LogUnit())
            {
                try
                {
                    AddIpToRequest(request);

                    var unitObj = UnitFactory
                        .Create()
                        .SetResultType<TResult>()
                        .SetRequestType<TRequest>()
                        .SetUnitType<TUnitOfWorlk>()
                        .CreateUnit(request);
                
                    var unit = unitObj as TUnitOfWorlk;
                    if (unit == null)
                        throw new KernerErrorException($"Unit {typeof(TUnitOfWorlk).GetType()} can't be used!");

                    return unit.Result;
                }
                catch (BaseApiException ex)
                {
                    return new TResult
                    {
                        ErrorDescription = (ex.InnerException != null)
                            ? ex.Message + ex.InnerException.Message
                            : ex.Message,
                        Error = ex.ErrorCode,
                    };
                }
                catch (BaseCriticalException criticatlException)
                {
                    return new TResult
                    {
                        ErrorDescription = (criticatlException.InnerException != null)
                            ? criticatlException.Message + criticatlException.InnerException.Message
                            : criticatlException.Message,
                        Error = criticatlException.ErrorCode,
                    };
                }
                catch (Exception ex)
                {
                    return new TResult
                    {
                        ErrorDescription = ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                        Error = ErrorCodeEnum.CriticalError
                    };
                }
            }
        }
    }
}