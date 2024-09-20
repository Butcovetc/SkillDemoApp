using DemoApp.Model.Dal.Requests.Base;
using DemoApp.Model.Dal.Response.Base;
using DemoApp.Model.Exceptions;
using DemoApp.Model.Exceptions.Api;
using DemoApp.Model.Exceptions.Critical;
using DemoApp.Model.Units.Abstract;

namespace DemoApp.Model.Factories
{
    /// <summary>
    /// Creates specific Unit of work
    /// </summary>
    public class UnitFactory
    {

        /// <summary>
        /// Unit type
        /// </summary>
        private Type? _unitType;

        /// <summary>
        /// Result unit type
        /// </summary>
        protected Type? _resultType;

        /// <summary>
        /// Request unit type
        /// </summary>
        protected Type? _requestType;


        /// <summary>
        /// Set's UnitFactory result type
        /// </summary>
        /// <typeparam name="TResult">Result type</typeparam>
        /// <returns>Factory object</returns>
        public UnitFactory SetResultType<TResult>()
            where TResult : ResponseBase
        {
            _resultType = typeof(TResult);
            return this;
        }

        /// <summary>
        /// Set's UnitFactory request type
        /// </summary>
        /// <typeparam name="TRequest">Request type</typeparam>
        /// <returns>Factory object</returns>
        public UnitFactory SetRequestType<TRequest>()
            where TRequest : RequestBase
        {
            _requestType = typeof(TRequest);
            return this;
        }

        /// <summary>
        /// Set's UnitFactory unit type
        /// </summary>
        /// <typeparam name="TUnit">Unit type</typeparam>
        /// <returns>Factory object</returns>
        public UnitFactory SetUnitType<TUnit>()
            where TUnit : TemplateMethodUnitAbstract
        {
            _unitType = typeof(TUnit);
            return this;
        }

        /// <summary>
        /// Create's unit of work object base on params
        /// </summary>
        /// <param name="request">Unit request object</param>
        /// <returns></returns>
        /// <exception cref="KernerErrorException">In case in unit can't be created</exception>
        /// /// <exception cref="ArgumetMissingException">If cas is one of params are not set</exception>
        public object CreateUnit(object request)
            => CreateUnit([request]);

        /// <summary>
        /// Create's unit of work object base on params
        /// </summary>
        /// <param name="args">Constructor args</param>
        /// <returns></returns>
        /// <exception cref="KernerErrorException">In case in unit can't be created</exception>
        /// /// <exception cref="ArgumetMissingException">If cas is one of params are not set</exception>
        public object CreateUnit(object[] args)
        {
            try
            {
                ArgumetMissingException.ThrowIfNull(_unitType);

                ArgumetMissingException.ThrowIfNull(_resultType);

                ArgumetMissingException.ThrowIfNull(_requestType);

                var unitObj = Activator.CreateInstance(_unitType, args: args);

                return unitObj ?? throw new KernerErrorException($"Unit {_unitType.GetType()} can't be created!");
            }
            catch (BaseApiException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new KernerErrorException($"Unit {_unitType.GetType()} can't be created!",ex);
            }
        }
        
        public static UnitFactory Create()
            => new UnitFactory();

    }
}
