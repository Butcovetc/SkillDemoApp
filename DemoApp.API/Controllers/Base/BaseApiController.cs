using System.Net.Mime;
using System.Reflection;
using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Exceptions.Api;
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
                throw new ArgumentNullException("Nullable request object");

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
        /// <typeparam name="TOperation">Operation type</typeparam>
        /// <param name="request">ReqBody object</param>
        /// <returns>Result</returns>
        public TResult Run<TResult, TOperation, TRequest>(TRequest request, bool ignoreLogs = false)
            where TResult : ResponseBase, new()
            where TOperation : RequestResultUnitAbstract<TResult,TRequest>
            where TRequest : ReqBase
        {
            //using (var l = new LogUnit())
            {
                try
                {
                    AddIpToRequest(request);

                    var opType = typeof(TOperation);

                    var constuctors = opType.GetConstructors();
                    var constructor = constuctors
                        .FirstOrDefault(x =>
                            x.GetParameters().Any(x => x.ParameterType == typeof(LogUnit))
                            && x.GetParameters().Any(x => x.ParameterType == typeof(TRequest))
                            && x.GetParameters().Count() == 2);//(logunit,reuqest) signature

                    ArgumetMissingException.

                    if (constructor == null)
                        throw new ArgumetMissingException($"Constructor not found! Type {typeof(TOperation)}");

                    //Log request object
                    if (!ignoreLogs)
                        l.SetRequest(request);

                    var operation = constructor.Invoke(new Object[] { request, l });

                    (operation as BaseOperation).ExecuteOperation();

                    var result = (operation as IOperationResult<TResult>).Result;
                    
                    //Log response object
                    if (!ignoreLogs)
                        l.SetResult(result);
                    
                    return result;
                }
                catch (BaseApiException ex)
                {
                    l.SetException(ex);
                    return new TResult
                    {
                        DebugMessage = (ex.InnerException != null)
                            ? ex.Message + ex.InnerException.Message
                            : ex.Message,
                        Error = ex.ErrorCode,
                    };
                }
                catch (Exception ex)
                {
                    return new TResult
                    {
                        DebugMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                        Error = ApiErrors.ErrorCode.InternalError
                    };
                }
            }
        }

        /// <summary>
        /// Run operation 
        /// </summary>
        /// <typeparam name="TResult">Result object</typeparam>
        /// <typeparam name="TOperation">Operation type</typeparam>
        /// <param name="request">ReqBody object</param>
        /// <returns>Result</returns>
        public TResult Run<TResult, TOperation>(ReqBase request, bool ignoreLogs = true)
            where TResult : ResponseBase, new()
            where TOperation : IOperationResult<TResult>
        {
            using (var l = new LogUnit())
            {
                try
                {
                    AddIpToRequest(request);
                    var operationName = "ExecuteOperation";
                    var opType = typeof(TOperation);
                    if (!opType.GetInterfaces().Contains(typeof(IOperationResult<TResult>)))
                        throw new ArgumentException("Operating is not nested from IOperation<" + typeof(TResult) + ">");

                    var constuctors = opType.GetConstructors();
                    var constructor = constuctors.FirstOrDefault(x => x.GetParameters().Count() == 2);
                    //ReqBody + LogUnit
                    var executeMethod = opType.GetMethod(operationName);
                    if (executeMethod == null)
                        throw new ArgumentException("Execute operationmethod not found");

                    if (constructor == null)
                        throw new ArgumetMissingException("Constructor not found");
                    if (!ignoreLogs)
                    {
                        l.SetRequest(request);
                    }

                    var operation = constructor.Invoke(new Object[] { request, l });
                    executeMethod.Invoke(operation, new Object[0]);

                    var result = (operation as IOperationResult<TResult>).Result;
                    if (!ignoreLogs)
                    {
                        l.SetResult(result);
                    }
                    return result;
                }
                catch (BaseApiException ex)
                {
                    l.SetException(ex);
                    return new TResult
                    {
                        DebugMessage = (ex.InnerException != null)
                            ? ex.Message + ex.InnerException.Message
                            : ex.Message,
                        Error = ex.ErrorCode,
                    };
                }
                catch (Exception ex)
                {
                    return new TResult
                    {
                        DebugMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                        Error = ApiErrors.ErrorCode.InternalError
                    };
                }
            }
        }


        /// <summary>
        /// Run operation 
        /// </summary>
        /// <typeparam name="TOperation">Operation type</typeparam>
        /// <returns>Result</returns>
        public RespBodyObject GateWay4Run<TOperation>(ReqBodyObject request)
        {
            using (var logUnit = new LogUnit())
            {
                try
                {
                    var opType = typeof(TOperation);

                    var constuctors = opType.GetConstructors();
                    var constructor = constuctors.FirstOrDefault(x => x.GetParameters().Count() == 2);
                    if (constructor == null)
                        throw new ArgumetMissingException("Constructor not found");

                    var operation = constructor.Invoke(new Object[] { request, logUnit });
                    if (!(operation is IGateWayResult))
                        throw new InvalidArgumentException("Operation is not nested from IGateWayResult");

                    (operation as BaseOperation).ExecuteOperation();
                    var result = (operation as IGateWayResult).ResponseBody;

                    return result;
                }

                //Base api exception
                catch (BaseApiException ex)
                {
                    logUnit.SetException(ex);
                    return new RespBodyObject
                    {
                        DebugMessage = (ex.InnerException != null)
                            ? ex.Message + ex.InnerException.Message
                            : ex.Message,
                        Error = ex.ErrorCode,
                    };
                }

                catch (TargetInvocationException ex)
                {
                    return new RespBodyObject
                    {
                        DebugMessage = ex.InnerException.Message,
                        Error = ApiErrors.ErrorCode.InternalError
                    };
                }
                //Base exception
                catch (Exception ex)
                {
                    return new RespBodyObject
                    {
                        DebugMessage = ex.Message + ex.StackTrace,
                        Error = ApiErrors.ErrorCode.InternalError
                    };
                }
            }
        }

        /// <summary>
        /// Run operation 
        /// </summary>
        /// <typeparam name="TResult">Result object</typeparam>
        /// <typeparam name="TOperation">Operation type</typeparam>
        /// <returns>Result</returns>
        public TResult Run<TResult, TOperation>(bool ignoreLogs = false)
            where TResult : ResponseBase, new()
        {
            using (var l = new LogUnit())
            {
                try
                {
                    var operationName = "ExecuteOperation";
                    var opType = typeof(TOperation);
                    if (!opType.GetInterfaces().Contains(typeof(IOperationResult<TResult>)))
                        throw new ArgumentException("Operating is not nested from IOperation<" + typeof(TResult) + ">");

                    var constuctors = opType.GetConstructors();
                    var constructor = constuctors.FirstOrDefault(x => x.GetParameters().Count() == 1);
                    if (constructor == null)
                        throw new ArgumetMissingException("Constructor not found");

                    //ReqBody + LogUnit
                    var executeMethod = opType.GetMethod(operationName);
                    if (executeMethod == null)
                        throw new ArgumentException("Execute operationmethod not found");



                    var operation = constructor.Invoke(new Object[] { l });
                    executeMethod.Invoke(operation, new Object[0]);

                    var result = (operation as IOperationResult<TResult>).Result;
                    if (!ignoreLogs)
                    {
                        l.SetResult(result);
                    }

                    return result;
                }
                catch (BaseApiException ex)
                {
                    l.SetException(ex);
                    return new TResult
                    {
                        DebugMessage = (ex.InnerException != null)
                            ? ex.Message + ex.InnerException.Message
                            : ex.Message,
                        Error = ex.ErrorCode,
                    };
                }
                catch (Exception ex)
                {
                    return new TResult
                    {
                        DebugMessage = ex.Message + ex.StackTrace,
                        Error = ApiErrors.ErrorCode.InternalError
                    };
                }
            }
        }
    }
}