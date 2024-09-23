using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Dal;
using DemoApp.Model.Exceptions.Critical;
using DemoApp.Model.Exceptions;
using DemoApp.Model.Units.Base;
using DemoApp.Model.Utils.Factories;
using Microsoft.Extensions.Logging;
using Monee.Logic.DbLayer;

namespace DemoApp.Model.Services
{
    /// <summary>
    /// Model service base class
    /// </summary>
    internal abstract class ServiceBase
    {
        ILogger _logger;
        DataBaseContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="context">Database context</param>
        protected ServiceBase(ILogger logger, DataBaseContext context) {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Run TUnitOfWorlk with TRequest type & TResult. TUnitOfWorlk will be automatically created and excecuted
        /// </summary>
        /// <typeparam name="TUnitOfWorlk">TUnitOfWorlk type</typeparam>
        /// <param name="request">Request object</param>
        /// <returns>Result object</returns>
        internal async Task<TResult> RunAsync<TResult, TUnitOfWorlk, TRequest>(TRequest request, bool ignoreLogs = false)
            where TResult : ResponseBase, new()
            where TUnitOfWorlk : RequestResultUnitAbstract<TResult, TRequest>
            where TRequest : RequestBase
                => await Task.Run(() => Run<TResult, TUnitOfWorlk, TRequest>(request));


        /// <summary>
        /// Run TUnitOfWorlk with TRequest type & TResult. TUnitOfWorlk will be automatically created and excecuted
        /// </summary>
        /// <typeparam name="TUnitOfWorlk">TUnitOfWorlk type</typeparam>
        /// <param name="request">Request object</param>
        /// <returns>Result object</returns>
        internal TResult Run<TResult, TUnitOfWorlk, TRequest>(TRequest request, bool ignoreLogs = false)
            where TResult : ResponseBase, new()
            where TUnitOfWorlk : RequestResultUnitAbstract<TResult, TRequest>
            where TRequest : RequestBase
        {
            try
            {
                var unitObj = UnitFactory
                    .Create()
                    .SetResultType<TResult>()
                    .SetRequestType<TRequest>()
                    .SetUnitType<TUnitOfWorlk>()
                    .CreateUnit(_logger, _context, request);

                var unit = unitObj as TUnitOfWorlk;
                if (unit == null)
                    throw new KernerException($"Unit {typeof(TUnitOfWorlk).GetType()} can't be used!");

                unit.Execute();

                return unit.Result;
            }
            catch (BaseApiException ex)
            {
                return new TResult
                {
                    ErrorDescription = ex.Message,
                    Error = ex.ErrorCode,
                };
            }
            catch (BaseCriticalException criticatlException)
            {
                //TODO:Trace and log data for furture analisis
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
                //TODO:Trace and log data for furture analisis
                return new TResult
                {
                    ErrorDescription = ex.InnerException != null ? ex.InnerException.Message : ex.Message,
                    Error = ErrorCodeEnum.CriticalError
                };
            }
        }
    }
}
